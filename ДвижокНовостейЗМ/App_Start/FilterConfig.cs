

using System;
using System.Web.Mvc;
using ДвижокНовостейЗМ.Models;

namespace ДвижокНовостейЗМ.App_Start
{
    class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CounterFilte());
        }
    }
    public class CounterFilte : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {

            using (var transaction = new System.Transactions.TransactionScope())
            {
                using (var db = new ApplicationDBContext())
                {
                    var url = filterContext.RequestContext.HttpContext.Request.RawUrl.ToString();
                    VisitsTable vt = db.Visits.Find(url);
                    if (vt == null)
                    {
                        vt = new VisitsTable { Url = url, Count = 1 };
                        db.Visits.Add(vt);
                    }
                    else
                    {
                        vt.Count = vt.Count+ 1;
                    }
                    db.SaveChanges();
                }
                transaction.Complete();
            }
        }
    }
}
