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
    public class KategorilersController : Controller
    {
        private finalprojectEntities1 db = new finalprojectEntities1();

        // GET: Kategorilers
        public ActionResult Index()
        {
            var kategoriler = db.Kategoriler.Include(k => k.Cihazlar);
            return View(kategoriler.ToList());
        }
      
    

    // GET: Kategorilers/Details/5
    public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategoriler kategoriler = db.Kategoriler.Find(id);
            if (kategoriler == null)
            {
                return HttpNotFound();
            }
            return View(kategoriler);
        }

        // GET: Kategorilers/Create
        public ActionResult Create()
        {
            ViewBag.cihaz_id = new SelectList(db.Cihazlar, "id", "cihaz_ad");
            return View();
        }

        // POST: Kategorilers/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,kategori_ad,cihaz_id")] Kategoriler kategoriler)
        {
            if (ModelState.IsValid)
            {
                db.Kategoriler.Add(kategoriler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cihaz_id = new SelectList(db.Cihazlar, "id", "cihaz_ad", kategoriler.cihaz_id);
            return View(kategoriler);
        }

        // GET: Kategorilers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategoriler kategoriler = db.Kategoriler.Find(id);
            if (kategoriler == null)
            {
                return HttpNotFound();
            }
            ViewBag.cihaz_id = new SelectList(db.Cihazlar, "id", "cihaz_ad", kategoriler.cihaz_id);
            return View(kategoriler);
        }

        // POST: Kategorilers/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,kategori_ad,cihaz_id")] Kategoriler kategoriler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kategoriler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cihaz_id = new SelectList(db.Cihazlar, "id", "cihaz_ad", kategoriler.cihaz_id);
            return View(kategoriler);
        }

        // GET: Kategorilers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategoriler kategoriler = db.Kategoriler.Find(id);
            if (kategoriler == null)
            {
                return HttpNotFound();
            }
            return View(kategoriler);
        }

        // POST: Kategorilers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kategoriler kategoriler = db.Kategoriler.Find(id);
            db.Kategoriler.Remove(kategoriler);
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
