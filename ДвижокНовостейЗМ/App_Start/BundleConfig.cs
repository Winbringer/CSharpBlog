
using System.Web;
using System.Web.Optimization;


namespace ДвижокНовостейЗМ.App_Start
{
    public class BundleConfig
        {
            public static void RegisterBundles(BundleCollection bundles)
            {

                bundles.Add(new ScriptBundle("~/bundles/myscripts").Include(
                            "~/App_FrontEnd/Scripts/jquery-{version}.js",
                            "~/App_FrontEnd/Scripts/jquery.validate*",
                            "~/App_FrontEnd/Scripts/jquery.unobtrusive-ajax.js"));
            bundles.Add(new StyleBundle("~/bundles/mystyles").Include(
                "~/App_FrontEnd/Content/PagedList.css"));
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            // Далее идет подключение остальных бандлов       
              
            }
        }
    
}
