using System.Web;
using System.Web.Optimization;

namespace Administrator
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Default
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.js", "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js"));

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
            #endregion

            #region Remark-403
            // Stylesheets
            bundles.Add(new StyleBundle("~/Global/css").Include(
                "~/Global/css/bootstrap.min.css",
                "~/Global/css/bootstrap-extend.min.css",
                "~/Global/Assets/css/site.min.css"));

            bundles.Add(new StyleBundle("~/Global/css-plugins").Include(
                "~/Content/themes/base/jquery-ui.css",
                "~/Global/Vendor/animsition/animsition.css",
                "~/Global/Vendor/asscrollable/asScrollable.css",
                "~/Global/Vendor/switchery/switchery.css",
                "~/Global/Vendor/intro-js/introjs.css",
                "~/Global/Vendor/slidepanel/slidePanel.css",
                "~/Global/Vendor/flag-icon-css/flag-icon.css",
                "~/Global/Vendor/chartist/chartist.css",
                "~/Global/Vendor/chartist-plugin-tooltip/chartist-plugin-tooltip.css",
                "~/Global/Vendor/jvectormap/jquery-jvectormap.css",
                "~/Global/Assets/css/Dashboard/site.min.css"));

            bundles.Add(new StyleBundle("~/Global/css-fonts").Include(
                "~/Global/Fonts/weather-icons/weather-icons.css",
                "~/Global/Fonts/web-icons/web-icons.min.css",
                "~/Global/Fonts/brand-icons/brand-icons.min.css"));

            // Scripts
            // Core
            bundles.Add(new ScriptBundle("~/Global/js_core").Include(
                "~/Global/Vendor/babel-external-helpers/babel-external-helpers.js",
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery-ui-{version}.js",
                "~/Global/Vendor/animsition/animsition.js",
                "~/Global/Vendor/popper-js/umd/popper.min.js",
                "~/Global/Vendor/bootstrap/bootstrap.js",
                "~/Global/Vendor/mousewheel/jquery.mousewheel.js",
                "~/Global/Vendor/asscrollbar/jquery-asScrollbar.js",
                //"~/Global/Vendor/jquery/jquery.js",
                "~/Global/Vendor/asscrollable/jquery-asScrollable.js",
                "~/Global/Vendor/ashoverscroll/jquery-asHoverScroll.js"));

            // Plugins
            bundles.Add(new ScriptBundle("~/Global/js_plugins").Include(
                "~/Global/Vendor/switchery/switchery.js",
                "~/Global/Vendor/intro-js/intro.js",
                "~/Global/Vendor/screenfull/screenfull.js",
                "~/Global/Vendor/slidepanel/jquery-slidePanel.js",
                "~/Global/Vendor/skycons/skycons.js",
                "~/Global/Vendor/chartist/chartist.min.js",
                "~/Global/Vendor/chartist-plugin-tooltip/chartist-plugin-tooltip.js",
                "~/Global/Vendor/aspieprogress/jquery-asPieProgress.min.js",
                "~/Global/Vendor/jvectormap/jquery-jvectormap.min.js",
                "~/Global/Vendor/jvectormap/maps/jquery-jvectormap-au-mill-en.js",
                "~/Global/Vendor/matchheight/jquery.matchHeight-min.js"));

            // Scripts
            bundles.Add(new ScriptBundle("~/Global/js").Include(
                "~/Global/js/Component.js",
                "~/Global/js/Plugin.js",
                "~/Global/js/Base.js",
                "~/Global/js/Config.js",
                "~/Global/Assets/js/Section/Menubar.js",
                "~/Global/Assets/js/Section/GridMenu.js",
                "~/Global/Assets/js/Section/Sidebar.js",
                "~/Global/Assets/js/Section/PageAside.js",
                "~/Global/Assets/js/Plugin/menu.js",
                "~/Global/js/config/colors.js",
                "~/Global/Assets/js/config/tour.js"));

            // Page
            bundles.Add(new ScriptBundle("~/Global/js-page").Include(
                "~/Global/Assets/js/Site.js",
                "~/Global/js/Plugin/asscrollable.js",
                "~/Global/js/Plugin/slidepanel.js",
                "~/Global/js/Plugin/switchery.js",
                "~/Global/js/Plugin/matchheight.js",
                "~/Global/js/Plugin/jvectormap.js",
                "~/Global/Assets/examples/js/dashboard/v1.js"));
            #endregion
        }
    }
}
