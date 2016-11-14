using GugHub.Controllers.Base;
using GugHub.Models.Followers;
using GugHub.Models.Gigs;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace GugHub.Controllers
{

    [Authorize]
    public class GigsController : BaseController
    {
        public GigsController()
        { }

        // GET: Gigs/Create
        public ActionResult Create()
        {
            var vm = GigCreateResponseModel.Create(DB.Genres.ToList(), "Add Gig");
            return View("GigForm", vm);
        }

        /// <summary>
        /// Creates a gig
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        // POST: Gigs/Create
        public ActionResult Create(GigCreateRequestModel vm)
        {
            if (!ModelState.IsValid)
            {
                var vmr = GigCreateResponseModel.Create(vm, DB.Genres.ToList(), "Add Gig");
                return View("GigForm", vmr);
            }

            // Get a list of all users for notification
            var users = DB.Users.Where(u => u.Id != UserId).ToList();

            // Create gig
            var gig = Gig.Create(vm, UserId, users);
            DB.Gigs.Add(gig);

            // Save
            DB.SaveChanges();
            return RedirectToAction("MyUpcomingGigs", "Gigs");
        }

        /// <summary>
        /// Updates a gig
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        // POST: Gigs/Create
        public ActionResult Update(GigCreateRequestModel vm)
        {
            // Check gig state
            if (!ModelState.IsValid)
            {
                var vmr = GigCreateResponseModel.Create(vm, DB.Genres.ToList(), "Edit Gig");
                return View("GigForm", vmr);
            }

            // Get the gig and any attendees
            var gig = DB.Gigs
                .Include(g => g.Attendances.Select(a => a.Attendee))
                .Where(g => g.Id == vm.Id && g.ArtistId == UserId)
                .FirstOrDefault();

            // Check it exists
            if (gig == null)
            {
                return new HttpStatusCodeResult(404);
            }

            // Update gig
            gig.Update(vm);

            // Save
            DB.SaveChanges();
            return RedirectToAction("MyUpcomingGigs", "Gigs");
        }

        /// <summary>
        /// Gets a gig entity to update
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var gig = DB.Gigs.Where(g => g.Id == id && g.ArtistId == UserId).FirstOrDefault();

            // Check it exists
            if (gig == null)
            {
                return new HttpStatusCodeResult(404);
            }

            var genres = DB.Genres.ToList();
            var vm = GigCreateResponseModel.Create(gig, DB.Genres.ToList(), "Edit Gig");
            return View("GigForm", vm);
        }

        /// <summary>
        /// Gets a list of upcoming gigs for a user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult MyUpcomingGigs()
        {
            var mygigs = DB.Gigs
                .Where(g => g.ArtistId == UserId && g.DateTime > DateTime.Now && g.IsCanceled == false)
                .Include(g => g.Genre)
                .ToList();
            return View(mygigs);
        }

        /// <summary>
        /// Gets a list of gigs being attended by the user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Attending()
        {
            var gigs = DB.Attendees
                .Where(a => a.AttendeeId == UserId)
                .Select(a => a.Gig)
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .ToList();

            var vm = GigsViewModel.Create(gigs, User.Identity.IsAuthenticated, "Gigs I'm Going To");

            return View("Gigs", vm);
        }

        /// <summary>
        /// Gets a list of artists being followed by the user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Following()
        {
            var userId = User.Identity.GetUserId();

            var followers = DB.Followings
                .Include(u => u.Follower)
                .Where(f => f.FolloweeId == userId)
                .Select(f => f.Follower)
                .ToList();

            var vm = FollowersViewModel.Create(followers, "Artists I'm Following");

            return View("Following", vm);
        }

        [HttpGet]
        public ActionResult Search(string searchTerm)
        {
            var upcomingGigs = DB.Gigs
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .Where(g => (g.DateTime > DateTime.Now && !g.IsCanceled) &&
                            (g.Venue.Contains(searchTerm) || g.Artist.Name.Contains(searchTerm) || g.Genre.Name.Contains(searchTerm)))
                .OrderBy(g => g.DateTime);

            var heading = (string.IsNullOrWhiteSpace(searchTerm) || string.IsNullOrEmpty(searchTerm)) ? "Upcoming Gigs" : $"Search: {searchTerm}";

            var vm = GigsViewModel.Create(upcomingGigs, User.Identity.IsAuthenticated, heading);

            return View("Gigs", vm);
        }
    }
}