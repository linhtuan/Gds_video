using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using GdsVideoBackend.Infrastructure;

namespace GdsVideoBackend
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            AutofacInstaller.Register();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
