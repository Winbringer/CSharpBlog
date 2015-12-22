using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ДвижокНовостейЗМ.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult _PartWord(string word, int start, int end)
        {
            try
            {
                if (end < 0) throw new ArgumentOutOfRangeException();
                word = word.Substring(start, (end - start));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                word = "Переданные неправильные аргументы, индекс начала и конца должны быть больше нуля и эндекс конца должен быть больше начала ";
            }
            catch (Exception e)
            {
                word = e.Message;
            }
            
            return PartialView("_PartWord", word);
        }
    }
}