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
    public class CihazlarsController : Controller
    {
        private finalprojectEntities1 db = new finalprojectEntities1();

        // GET: Cihazlars
        public ActionResult Index()
        {
            return View(db.Cihazlar.ToList());
        }

        // GET: Cihazlars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cihazlar cihazlar = db.Cihazlar.Find(id);
            if (cihazlar == null)
            {
                return HttpNotFound();
            }
            return View(cihazlar);
        }

        // GET: Cihazlars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cihazlars/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cihaz_ad")] Cihazlar cihazlar)
        {
            if (ModelState.IsValid)
            {
                db.Cihazlar.Add(cihazlar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cihazlar);
        }

        // GET: Cihazlars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cihazlar cihazlar = db.Cihazlar.Find(id);
            if (cihazlar == null)
            {
                return HttpNotFound();
            }
            return View(cihazlar);
        }

        // POST: Cihazlars/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cihaz_ad")] Cihazlar cihazlar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cihazlar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cihazlar);
        }

        // GET: Cihazlars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cihazlar cihazlar = db.Cihazlar.Find(id);
            if (cihazlar == null)
            {
                return HttpNotFound();
            }
            return View(cihazlar);
        }

        // POST: Cihazlars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cihazlar cihazlar = db.Cihazlar.Find(id);
            db.Cihazlar.Remove(cihazlar);
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
