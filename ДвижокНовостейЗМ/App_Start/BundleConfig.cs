
using System.Web;
using System.Web.Optimization;


namespace ДвижокНовостейЗМ.App_Start
{
    public class BundleConfig
        {
            public static void RegisterBundles(BundleCollection bundles)
            {

                bundles.Add(new ScriptBundle("~/bundles/myscripts").Include(
                            "~/Scripts/jquery-{version}.js",
                            "~/Scripts/jquery.validate*",
                            "~/Scripts/jquery.unobtrusive-ajax.js"));
            bundles.Add(new StyleBundle("~/bundles/mystyles").Include(
                "~/Content/PagedList.css"));
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            // Далее идет подключение остальных бандлов       
              
            }
        }
    
}
