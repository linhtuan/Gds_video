using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GiaoDucSomVideo.Startup))]
namespace GiaoDucSomVideo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
