using GugHub.Controllers.Base;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
namespace GugHub.Controllers.Api
{
    [Authorize]
    public class GigApiController : BaseApiController
    {
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            // Get the gig and any attendees
            var gig = DB.Gigs
                .Include(g => g.Attendances.Select(a => a.Attendee))
                .Where(g => g.Id == id && g.ArtistId == UserId)
                .FirstOrDefault();

            // Check if already cancelled
            if (gig.IsCanceled)
            {
                return NotFound();
            }

            // Cancel Gig
            gig.Cancel();

            // Save
            DB.SaveChanges();
            return Ok();
        }
    }
}