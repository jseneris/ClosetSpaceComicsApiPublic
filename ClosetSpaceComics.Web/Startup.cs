using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClosetSpaceComics.Web.Startup))]
namespace ClosetSpaceComics.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
