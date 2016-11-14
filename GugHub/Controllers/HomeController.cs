using GugHub.Controllers.Base;
using GugHub.Models.Gigs;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace GugHub.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController()
        { }

        /// <summary>
        /// Gets a list of all upcoming gigs
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult Index()
        {
            var upcomingGigs = DB.Gigs
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .Where(g => g.DateTime > DateTime.Now && g.IsCanceled == false)
                .OrderBy(g => g.DateTime);

            var vm = GigsViewModel.Create(upcomingGigs, User.Identity.IsAuthenticated, "Upcoming Gigs");

            return View("Gigs", vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}