
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ДвижокНовостейЗМ.Models;

namespace ДвижокНовостейЗМ.Controllers
{
    public class ReplyController : Controller
    {
        ApplicationDBContext db = new ApplicationDBContext();

        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           Reply reply = db.Replys.Find(id);
            if (reply == null)
            {
                return HttpNotFound();
            }
            return View(reply);            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text")] Reply reply)
        {
            Reply oldReply = db.Replys.Find(reply.Id);

            oldReply.Text = reply.Text;
            oldReply.Date = DateTime.Now;
            db.SaveChanges();
           return RedirectToAction("Details","Messages", new { id = oldReply.Message.Id });            
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           Reply reply = db.Replys.Find(id);
            if (reply == null)
            {
                return HttpNotFound();
            }
            return View(reply);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           Reply reply = db.Replys.Find(id);
          int  savedId = reply.Message.Id;
            db.Replys.Remove(reply);
            db.SaveChanges();
            return RedirectToAction("Details", "Messages", new { id = savedId });
        }
        public ActionResult Create(Reply reply, int? id)
        {
           
            if (ModelState.IsValid)
            {
                db.Replys.Add(reply);
                db.SaveChanges();
            }         
            return RedirectToAction("Details", "Messages", new { id = id });
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