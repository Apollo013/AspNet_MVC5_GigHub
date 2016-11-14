using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GugHub.Startup))]
namespace GugHub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
