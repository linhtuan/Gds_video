using System.Web;
using System.Web.Optimization;

namespace GiaoDucSomVideo
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/base-lib-js")
                .Include("~/Scripts/jquery-2.1.4.min.js")
                .Include("~/Scripts/plugins/jquery-ui/jquery-ui.min.js")
                .Include("~/Scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/SiteAll.css",
                      "~/Content/site.css"));
        }
    }
}
