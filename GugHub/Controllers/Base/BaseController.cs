using GugHub.DataAccess;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Web.Mvc;

namespace GugHub.Controllers.Base
{
    public class BaseController : Controller
    {
        private ApplicationDbContext _context;

        protected ApplicationDbContext DB
        {
            get
            {
                return _context ?? HttpContext.GetOwinContext().Get<ApplicationDbContext>();
            }
            private set { _context = value; }
        }

        protected string UserId
        {
            get { return User.Identity.GetUserId(); }
        }
    }
}