using System.Web.Optimization;

namespace EPAM.Wunderlist.WebUI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-{version}.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/wunderlist")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/semantic*")
                .Include("~/Scripts/wunderlistApp*"));
            
            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
                .Include("~/Scripts/jquery.validate*"));
            
            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                .Include("~/Scripts/modernizr-*"));
            
            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/wunderlist.css")
                .Include("~/Content/semantic.css"));

            bundles.Add(new ScriptBundle("~/bundles/angularCore")
                .Include("~/Scripts/angular.js")
                .Include("~/Scripts/angular-*"));

            bundles.Add(new ScriptBundle("~/bundles/angularWunderlistApp")
                .Include("~/Scripts/AngularWunderlistApp/coreApp.js")
                .Include("~/Scripts/AngularWunderlistApp/controllers/listCtrl.js")
                .Include("~/Scripts/AngularWunderlistApp/controllers/itemCtrl.js")
                .Include("~/Scripts/AngularWunderlistApp/controllers/userCtrl.js")
                .Include("~/Scripts/AngularWunderlistApp/controllers/mainCtrl.js"));

            //.Include("~/Content/bootstrap.css");
            //.Include("~/Content/site.css")

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));
        }
    }
}
