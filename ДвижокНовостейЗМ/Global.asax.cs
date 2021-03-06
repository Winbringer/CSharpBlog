﻿using System;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ДвижокНовостейЗМ.App_Start;
using ДвижокНовостейЗМ.DAL;
using ДвижокНовостейЗМ.Models;

namespace ДвижокНовостейЗМ
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            System.Web.HttpContext.Current.Application["OnlaynUsers"] = 0;
            Database.SetInitializer(new DBInitalazer());
            using (var db = new ApplicationDBContext())
            {
                db.Database.Initialize(true);
            }

        }
        protected void Session_Start(object sender, EventArgs e)
        {
            System.Web.HttpContext.Current.Application.Lock();
            System.Web.HttpContext.Current.Application["OnlaynUsers"] = (int)System.Web.HttpContext.Current.Application["OnlaynUsers"] + 1;
            System.Web.HttpContext.Current.Application.UnLock();
        }
        protected void Session_End(object sender, EventArgs e)
        {
            System.Web.HttpContext.Current.Application.Lock();
            System.Web.HttpContext.Current.Application["OnlaynUsers"] = (int)System.Web.HttpContext.Current.Application["OnlaynUsers"] - 1;
            System.Web.HttpContext.Current.Application.UnLock();
        }
    }
}
