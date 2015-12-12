
using System.Linq;
using System.Web.Mvc;
using ДвижокНовостейЗМ.Models;

namespace ДвижокНовостейЗМ.Controllers
{
    public class ReplyController : Controller
    {
        ApplicationDBContext db = new ApplicationDBContext();

        // GET: Reply
        public ActionResult Index()
        {
            return PartialView(db.Replys.ToList());
        }
       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}