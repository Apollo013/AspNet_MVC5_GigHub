using AutoMapper;
using GugHub.Controllers.Base;
using GugHub.Models.Notifications;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace GugHub.Controllers.Api
{
    [Authorize]
    public class NotificationController : BaseApiController
    {
        /// <summary>
        /// Gets a list of NEW notifications for the current user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var nots = DB.UserNotifications
                .Where(un => un.UserId == UserId && un.IsRead == false)
                .OrderBy(un => un.NotificationId)
                .Select(un => un.Notification)
                .Include(ng => ng.Gig.Artist)
                .ToList();

            var mapper = Mapper.Configuration.CreateMapper();
            return nots.Select(mapper.Map<Notification, NotificationDto>);
        }

        [HttpPost]
        public IHttpActionResult MarkRead()
        {
            var nots = DB.UserNotifications
                .Where(un => un.UserId == UserId && un.IsRead == false)
                .ToList();

            nots.ForEach(un => un.MarkRead());
            DB.SaveChanges();
            return Ok();
        }
    }
}
