using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using ДвижокНовостейЗМ.Models;
using ДвижокНовостейЗМ.Models.Identity;
using PagedList.Mvc;
using PagedList;
using System.Collections.Generic;

namespace ДвижокНовостейЗМ.Controllers
{
    public class MessagesController : Controller
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: Messages
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(db.Messages.Include("Replys").OrderBy(m => m.Title).ToPagedList(pageNumber,pageSize));
        }

        // GET: Messages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> Details([Bind(Include = "Text")]Reply reply, int? id)
        {
            var url = Request.UrlReferrer.AbsolutePath;
            reply.Date = DateTime.Now;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                reply.Message = message;
                var UM = new ApplicationManager(new UserStore<ApplicationUser>(db));
                if (User.Identity.IsAuthenticated) reply.Avtor = await UM.FindByNameAsync(User.Identity.Name);
                db.Replys.Add(reply);
                db.SaveChanges();
            }
            return View(reply.Message);
        }
        // GET: Messages/Create
        [Authorize(Roles ="admin")]
        public ActionResult Create()
        {
            Session["Create"] = "Yes";
            return View();
        }

        // POST: Messages/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task< ActionResult> Create([Bind(Include = "Id,Title,Text,PubDate")] Message message)
        {
            Session["Create"] = "Yes";

            if (ModelState.IsValid)
            {
                var UM = new ApplicationManager(new UserStore<ApplicationUser>(db));
              if(User.Identity.IsAuthenticated) message.Avtor =await UM.FindByNameAsync(User.Identity.Name);
                db.Messages.Add(message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(message);
        }

        // GET: Messages/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            Session["Create"] = "No";
            return View(message);
        }

        // POST: Messages/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "Id,Title,Text,PubDate")] Message message)
        {
            Session["Create"] = "No";
            if (ModelState.IsValid)
            {
                Message message2 = db.Messages.Find(message.Id);
                message2.Text = message.Text;
                message2.Title = message.Title;
                message2.PubDate = message.PubDate;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(message);
        }

        // GET: Messages/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Messages/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult CheckTitle(string title)
        {
            var messages = db.Messages.Where(x => x.Title == title).FirstOrDefault();
            var result = (messages == null);
            if (Session["Create"].ToString() == "No") result = true;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult _Index(int mId)
        {
           Message message = db.Messages.Find(mId);
            List<Reply> reply = message.Replys.ToList();
            return PartialView("_Index", reply);
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
