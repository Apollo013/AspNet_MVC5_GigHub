using GugHub.Controllers.Base;
using GugHub.Models.Attendances;
using System.Linq;
using System.Web.Http;

namespace GugHub.Controllers.Api
{
    public class AttendancesController : BaseApiController
    {
        [Authorize]
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto gig)
        {
            var exists = DB.Attendees.Any(a => a.AttendeeId == UserId && a.GigId == gig.GigId);

            if (!exists)
            {
                var attendance = Attendance.Create(gig.GigId, UserId);
                DB.Attendees.Add(attendance);
                DB.SaveChanges();
                return Ok();
            }

            return BadRequest("You are already attending this gig !!!");
        }
    }
}
