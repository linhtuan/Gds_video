using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gds.VideoFrontend.Startup))]
namespace Gds.VideoFrontend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
