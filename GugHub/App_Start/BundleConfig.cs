using System.Web.Optimization;

namespace GugHub
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/underscore-min.js",
                        "~/Scripts/jquery.jscrollpane.min.js",
                        "~/Scripts/jquery.mousewheel.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/tether.js",
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/moment.js",
                      "~/Scripts/bootstrap-datepicker.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/tether.min.css",
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-flex.min.css",
                      "~/Content/animate.css",
                      "~/Content/jquery.jscrollpane.css",
                      "~/Content/bootstrap-datepicker.min.css",
                      "~/Content/site.css"));
        }
    }
}
