﻿using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using System.Web.Mvc;
using ДвижокНовостейЗМ.Models;
using ДвижокНовостейЗМ.Models.Identity;
using ДвижокНовостейЗМ.ViewModels;

namespace ДвижокНовостейЗМ.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public async Task<ActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                using (ApplicationDBContext db = new ApplicationDBContext())
                {
                    var UM = new ApplicationManager(new UserStore<ApplicationUser>(db));
                    var user = await  UM.FindByNameAsync(User.Identity.Name);
                    ViewBag.Age = user?.Year;
                    ViewBag.Sex = user?.Sex;
                }
            }
            return View();
        }
        public ActionResult AboutTheAuthor()
        {
            return View();
        }
        public ActionResult RazorTest()
        {
            return View();
        }

        public ActionResult GetTest(int x = 0, int y = 0)
        {
            ViewBag.Sum = x + y;
            return View();
        }
        [HttpGet]
        public ActionResult Calculator()
        {
            ViewBag.IsError = false;
            return View();
        }

        [HttpPost]
        public ActionResult Calculator(CalcData data)
        {
            if (data.X ==0 || data.Y==0)
            {
                ViewBag.IsError = true;
                return View("Calculator");
            }
            ViewBag.IsError = false;
            Calc calculator = new Calc(data.X, data.Y, data.Oper);
            data.Result = calculator.Res();
            TempData["Res"] = data;
            return RedirectToAction("ShowCalcRes");
        }
        public ActionResult ShowCalcRes()
        {
            CalcData data = (CalcData)TempData["Res"];
            return View(data);
        }
        public ActionResult TestFC()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TestFC(FormCollection f)
        {
            ViewBag.Name = f["Name"];
            return View();
        }
        public PartialViewResult _PartialMy(Human human)
        {
            return PartialView(human);
        }
    }
}