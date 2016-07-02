using System.Web.Optimization;

namespace GdsVideoBackend
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/inspinia")
                .Include(new[]
                {
                    "~/Content/js/plugins/metisMenu/jquery.metisMenu.js",
                    "~/Content/js/plugins/pace/pace.min.js",
                    "~/Content/js/plugins/slimscroll/jquery.slimscroll.min.js",
                    "~/Content/js/plugins/peity/jquery.peity.min.js",
                    "~/Content/js/plugins/video/responsible-video.js",
                    "~/Content/js/plugins/blueimp/jquery.blueimp-gallery.min.js",
                    "~/Content/js/plugins/sparkline/jquery.sparkline.min.js",
                    "~/Content/js/plugins/morris/raphael-2.1.0.min.js",
                    "~/Content/js/plugins/morris/morris.js",
                    "~/Content/js/plugins/flot/jquery.flot.js",
                    "~/Content/js/plugins/flot/jquery.flot.tooltip.min.js",
                    "~/Content/js/plugins/flot/jquery.flot.resize.js",
                    "~/Content/js/plugins/flot/jquery.flot.pie.js",
                    "~/Content/js/plugins/flot/jquery.flot.time.js",
                    "~/Content/js/plugins/flot/jquery.flot.spline.js",
                    "~/Content/js/plugins/rickshaw/vendor/d3.v3.js",
                    "~/Content/js/plugins/rickshaw/rickshaw.min.js",
                    "~/Content/js/plugins/chartjs/Chart.min.js",
                    "~/Content/js/plugins/iCheck/icheck.min.js",
                    "~/Content/js/plugins/dataTables/jquery.dataTables.js",
                    "~/Content/js/plugins/dataTables/dataTables.bootstrap.js",
                    "~/Content/js/plugins/dataTables/dataTables.responsive.js",
                    "~/Content/js/plugins/dataTables/dataTables.tableTools.min.js",
                    "~/Content/js/plugins/jeditable/jquery.jeditable.js",
                    "~/Content/js/plugins/jqGrid/i18n/grid.locale-en.js",
                    "~/Content/js/plugins/jqGrid/jquery.jqGrid.min.js",
                    "~/Content/js/plugins/codemirror/codemirror.js",
                    "~/Content/js/plugins/codemirror/mode/javascript/javascript.js",
                    "~/Content/js/plugins/nestable/jquery.nestable.js",
                    "~/Content/js/plugins/validate/jquery.validate.min.js",
                    "~/Content/js/plugins/fullcalendar/moment.min.js",
                    "~/Content/js/plugins/fullcalendar/fullcalendar.min.js",
                    "~/Content/js/plugins/ionRangeSlider/ion.rangeSlider.min.js",
                    "~/Content/js/plugins/datapicker/bootstrap-datepicker.js",
                    "~/Content/js/plugins/datapicker/angular-datepicker.js",
                    "~/Content/js/plugins/nouslider/jquery.nouislider.min.js",
                    "~/Content/js/plugins/jasny/jasny-bootstrap.min.js",
                    "~/Content/js/plugins/switchery/switchery.js",
                    "~/Content/js/plugins/chosen/chosen.jquery.js",
                    "~/Content/js/plugins/jsKnob/jquery.knob.js",
                    "~/Content/js/plugins/staps/jquery.steps.min.js",
                    "~/Content/js/plugins/toastr/toastr.min.js",
                    "~/Content/js/plugins/colorpicker/bootstrap-colorpicker.min.js",
                    "~/Content/js/plugins/cropper/cropper.min.js",
                    "~/Content/js/plugins/jsTree/jstree.min.js",
                    "~/Content/js/plugins/diff_match_patch/javascript/diff_match_patch.js",
                    "~/Content/js/plugins/preetyTextDiff/jquery.pretty-text-diff.min.js",
                    "~/Content/js/plugins/idle-timer/idle-timer.min.js",
                    "~/Content/js/plugins/tinycon/tinycon.min.js",
                    "~/Content/js/plugins/chartist/chartist.min.js",
                    "~/Content/js/plugins/clockpicker/clockpicker.js",
                    "~/Content/js/plugins/fullcalendar/moment.min.js",
                    "~/Content/js/plugins/daterangepicker/daterangepicker.js",
                    "~/Content/js/plugins/daterangepicker/angular-daterangepicker.js",
                    "~/Content/js/plugins/sweetalert/sweetalert.min.js",
                    "~/Content/js/plugins/footable/footable.all.min.js",
                    "~/Content/js/plugins/jquery-ui/jquery-ui.min.js"
                }));

            bundles.Add(new ScriptBundle("~/bundles/base-lib-js")
                .Include("~/Content/js/jquery-2.1.4.min.js")
                .Include("~/Content/js/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/base-inspinia")
                .Include("~/Content/js/inspinia.js"));
            
            RegisterInspiniaTheme(bundles);
        }

        private static void RegisterInspiniaTheme(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/inspinia")
                .Include("~/Content/font-awesome/css/font-awesome.css", new CssRewriteUrlTransform())
                .Include("~/Content/css/bootstrap.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/css/animate.css", new CssRewriteUrlTransform())
                .Include("~/Content/css/style.css", new CssRewriteUrlTransform())
                .Include("~/Content/css/main.css", new CssRewriteUrlTransform())
                .Include("~/Content/css/plugins/footable/footable.core.css", new CssRewriteUrlTransform())
                .Include("~/Content/css/plugins/iCheck/custom.css", new CssRewriteUrlTransform())
                .Include("~/Content/css/plugins/blueimp/css/blueimp-gallery.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/css/plugins/morris/morris-0.4.3.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/css/plugins/dataTables/dataTables.bootstrap.css", new CssRewriteUrlTransform())
                .Include("~/Content/css/plugins/dataTables/dataTables.responsive.css", new CssRewriteUrlTransform())
                .Include("~/Content/css/plugins/dataTables/dataTables.tableTools.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/css/plugins/jqGrid/ui.jqgrid.css", new CssRewriteUrlTransform())
                .Include("~/Content/css/plugins/codemirror/codemirror.css", new CssRewriteUrlTransform())
                .Include("~/Content/css/plugins/codemirror/ambiance.css", new CssRewriteUrlTransform())
                .Include("~/Content/css/plugins/fullcalendar/fullcalendar.css", new CssRewriteUrlTransform())
                .Include("~/Content/css/plugins/ionRangeSlider/ion.rangeSlider.css", new CssRewriteUrlTransform())
                .Include("~/Content/css/plugins/ionRangeSlider/ion.rangeSlider.skinFlat.css", new CssRewriteUrlTransform())
                .Include("~/Content/css/plugins/datapicker/datepicker3.css", new CssRewriteUrlTransform())
                .Include("~/Content/css/plugins/datapicker/angular-datapicker.css", new CssRewriteUrlTransform())
                .Include("~/Content/css/plugins/nouslider/jquery.nouislider.css", new CssRewriteUrlTransform())
                .Include("~/Content/css/plugins/jasny/jasny-bootstrap.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/css/plugins/switchery/switchery.css", new CssRewriteUrlTransform())
                .Include("~/Content/css/plugins/chosen/chosen.css", new CssRewriteUrlTransform())
                .Include("~/Content/css/plugins/steps/jquery.steps.css", new CssRewriteUrlTransform())
                .Include("~/Content/css/plugins/toastr/toastr.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/css/plugins/colorpicker/bootstrap-colorpicker.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/css/plugins/cropper/cropper.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/css/plugins/jsTree/style.css", new CssRewriteUrlTransform())
                .Include("~/Content/css/plugins/chartist/chartist.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/css/plugins/clockpicker/clockpicker.css", new CssRewriteUrlTransform())
                .Include("~/Content/css/plugins/daterangepicker/daterangepicker-bs3.css", new CssRewriteUrlTransform())
                .Include("~/Content/css/plugins/sweetalert/sweetalert.css", new CssRewriteUrlTransform())
                .Include("~/Content/js/plugins/jquery-ui/jquery-ui.min.css", new CssRewriteUrlTransform()));
        }
    }
}
