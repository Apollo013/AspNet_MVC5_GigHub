using GugHub.Controllers.Base;
using GugHub.Models.Followers;
using System.Linq;
using System.Web.Http;

namespace GugHub.Controllers.Api
{
    [RoutePrefix("api/followings")]
    [Authorize]
    public class FollowingsController : BaseApiController
    {
        /// <summary>
        /// Allows the user to follow an artist
        /// </summary>
        /// <param name="following"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("follow")]
        public IHttpActionResult Follow(FollowingDto following)
        {
            var exists = DB.Followings.Any(f => f.FolloweeId == UserId && f.FollowerId == following.FollowerId);

            if (!exists)
            {
                var follow = Following.Create(following.FollowerId, UserId);
                DB.Followings.Add(follow);
                DB.SaveChanges();
                return Ok();
            }
            return BadRequest("Already Following this artist");
        }

        /// <summary>
        /// Allows the user to unfollow an artist
        /// </summary>
        /// <param name="following"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("unfollow")]
        public IHttpActionResult Unfollow(FollowingDto following)
        {
            var exists = DB.Followings.Where(f => f.FolloweeId == UserId && f.FollowerId == following.FollowerId).FirstOrDefault();


            if (exists != null)
            {
                DB.Followings.Remove(exists);
                DB.SaveChanges();
                return Ok();
            }
            return BadRequest("You were not following this artist");
        }
    }
}