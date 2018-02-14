using System.Web;
using System.Web.Optimization;

namespace StaitEstate.View
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/InnerLayout").Include(
                "~/Scripts/jquery-1.7.2.min.js",
                "~/Scripts/jquery-ui-1.8.21.custom.min.js",
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.unobtrusive-ajax.js",
                "~/Scripts/jquery.pjax.js",
                "~/Scripts/bootstrap-transition.js",
                "~/Scripts/bootstrap-alert.js",
                "~/Scripts/bootstrap-modal.js",
                "~/Scripts/bootstrap-dropdown.js",
                "~/Scripts/bootstrap-scrollspy.js",
                "~/Scripts/bootstrap-collapse.js",
                "~/Scripts/jquery.autocomplete.js",
                "~/Scripts/jquery-ui-1.8.11.min.js",
                "~/Scripts/jqDnR.js",
                "~/Scripts/jqModal.js",
                "~/Scripts/handlebars-1.0.rc.1.js",
                "~/Scripts/jquery.nicescroll.min.js",
                "~/Scripts/JsFile/common-directives.js",
                "~/Scripts/angucomplete-alt.js",
                "~/Scripts/angular/angular1.6.7.js",
                "~/Scripts/angular-block-ui.js",
                "~/Scripts/JsFile/ui-bootstrap-tpls-0.10.0.js",
                "~/Scripts/JsFile/AdminHighChart.js",
                "~/Scripts/JsFile/highcharts-ng.js",
                "~/Scripts/JsFile/bootbox.js",
                "~/Scripts/JsFile/ngBootbox.js",
                "~/Scripts/angular-animate.min.js",
                "~/Scripts/angular-sanitize.min.js",
                "~/Scripts/angular-strap.js",
                "~/Scripts/angular-strap.tpl.js",
                "~/Scripts/angular-strap.docs.tpl.js",
                "~/Scripts/JsFile/angular-base64-upload.js",
                "~/Scripts/JsFile/sortable.js",
                "~/Scripts/JsFile/autocomplete.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/InnerLayout").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-responsive.css",
                "~/Content/HomePage.css",
                "~/Content/jquery-ui-1.8.21.custom.css",
                "~/Content/jqModal.css",
                "~/Content/otherstyle.css",
                "~/Content/jquery.jqplot.min.css",
                "~/Content/normalize.css",
                "~/Content/angucomplete-alt.css",
                "~/Content/angular-block-ui.css",
                "~/Content/angular-strap_styles_libs_min.css",
                "~/Content/font-awesome-4.5.0/css/font-awesome.css",
                "~/Content/Tabs.css",
                "~/Content/common.css",
                "~/Content/InnerLayoutPanel.css",
                "~/Content/Menu/style-responsive.css",
                "~/Content/angucomplete-alt.css"));
        }
    }
}
