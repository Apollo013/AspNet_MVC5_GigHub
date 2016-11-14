using GugHub.DataAccess;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Web.Http;

namespace GugHub.Controllers.Base
{
    public class BaseApiController : ApiController
    {
        private ApplicationDbContext _context;

        protected ApplicationDbContext DB
        {
            get
            {
                return _context ?? HttpContext.Current.GetOwinContext().Get<ApplicationDbContext>();
            }
            private set { _context = value; }
        }

        protected string UserId
        {
            get { return User.Identity.GetUserId(); }
        }
    }
}