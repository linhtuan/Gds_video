using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gds.Frontend.Startup))]
namespace Gds.Frontend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
