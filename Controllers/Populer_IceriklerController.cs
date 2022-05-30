using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class Populer_IceriklerController : Controller
    {
        private finalprojectEntities1 db = new finalprojectEntities1();

        // GET: Populer_Icerikler
        public ActionResult Index()
        {
            return View(db.Populer_Icerikler.ToList());
        }

        // GET: Populer_Icerikler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Populer_Icerikler populer_Icerikler = db.Populer_Icerikler.Find(id);
            if (populer_Icerikler == null)
            {
                return HttpNotFound();
            }
            return View(populer_Icerikler);
        }

        // GET: Populer_Icerikler/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Populer_Icerikler/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,pop_icerik_adi,pop_icerik_img,pop_icerik_link")] Populer_Icerikler populer_Icerikler)
        {
            if (ModelState.IsValid)
            {
                string DosyaAdi = Guid.NewGuid().ToString().Replace("-", "");
                //Kaydetceğimiz resmin uzantısını aldık.
                string uzanti = System.IO.Path.GetExtension(Request.Files[0].FileName);
                string TamYolYeri = "~/Content/assets/img/" + DosyaAdi + uzanti;
                //Eklediğimiz Resni Server.MapPath methodu ile Dosya Adıyla birlikte kaydettik.
                Request.Files[0].SaveAs(Server.MapPath(TamYolYeri));
                //Ve veritabanına kayıt için dosya adımızı değişkene aktarıyoruz.
                populer_Icerikler.pop_icerik_img = DosyaAdi + uzanti;
                db.Populer_Icerikler.Add(populer_Icerikler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(populer_Icerikler);
        }

        // GET: Populer_Icerikler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Populer_Icerikler populer_Icerikler = db.Populer_Icerikler.Find(id);
            if (populer_Icerikler == null)
            {
                return HttpNotFound();
            }
            return View(populer_Icerikler);
        }

        // POST: Populer_Icerikler/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,pop_icerik_adi,pop_icerik_img,pop_icerik_link")] Populer_Icerikler populer_Icerikler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(populer_Icerikler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(populer_Icerikler);
        }

        // GET: Populer_Icerikler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Populer_Icerikler populer_Icerikler = db.Populer_Icerikler.Find(id);
            if (populer_Icerikler == null)
            {
                return HttpNotFound();
            }
            return View(populer_Icerikler);
        }

        // POST: Populer_Icerikler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Populer_Icerikler populer_Icerikler = db.Populer_Icerikler.Find(id);
            db.Populer_Icerikler.Remove(populer_Icerikler);
            db.SaveChanges();
            return RedirectToAction("Index");
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
