using System.Web;
using System.Web.Optimization;

namespace WebApplication.Arch
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

            // Jquery UI
            bundles.Add(new StyleBundle("~/Content/jqueryui").Include(
                      "~/Content/themes/base/jquery-ui.min.css"));

            bundles.Add(new ScriptBundle("~/bundle/jqueryui").Include(
                      "~/Scripts/jquery-ui-1.12.1.min.js"));

            // Theme Bundles

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                      "~/Scripts/DataTables/jquery.dataTables.min.js",
                      "~/Scripts/DataTables/dataTables.bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/datatables").Include(
                      "~/Content/DataTables/css/dataTables.bootstrap.css"));

            bundles.Add(new StyleBundle("~/StartminContent/datatables").Include(
                      "~/Content/Startmin-T/dataTables/dataTables.bootstrap.css",
                      "~/Content/Startmin-T/dataTables/dataTables.responsive.css"));

            bundles.Add(new StyleBundle("~/StartminContent/css").Include(
                      "~/Content/Startmin-T/bootstrap.min.css",
                      "~/Content/Startmin-T/font-awesome.css",
                      "~/Content/Startmin-T/startmin.css"));

            bundles.Add(new ScriptBundle("~/bundles/Startmin").Include(
                      "~/Scripts/Startmin-T/startmin.js",
                      "~/Scripts/Startmin-T/metisMenu.min.js"));

            bundles.Add(new StyleBundle("~/metisMenu/css").Include(
                      "~/Content/Startmin-T/metisMenu.min.css"));
        }
    }
}
