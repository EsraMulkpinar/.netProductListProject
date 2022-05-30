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
    public class Alt_KategorilerController : Controller
    {
        private finalprojectEntities1 db = new finalprojectEntities1();

        // GET: Alt_Kategoriler
        public ActionResult Index()
        {
            var alt_Kategoriler = db.Alt_Kategoriler.Include(a => a.Kategoriler);
            return View(alt_Kategoriler.ToList());
        }
        //public ActionResult KategoriAltındakiler(int id)
        //{
        //    string altkategoriismi = (from k in db.Kategoriler
        //                              where k.id == id
        //                              select k.kategori_ad).FirstOrDefault();
        //    //Kategorinin ismini View'ın başlığı olarak tanımlayalım
        //    ViewBag.Title = altkategoriismi + "Kategorisindeki Alt Kategori listesi";
        //    //Kategorideki ürünleri veritabanından alan sorgu
        //    List<Alt_Kategoriler> altkategorisecimi = (from u in db.Alt_Kategoriler
        //                                               where u.id == id
        //                                               select u).ToList();

        //    return View(altkategorisecimi);
        //}

        // GET: Alt_Kategoriler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alt_Kategoriler alt_Kategoriler = db.Alt_Kategoriler.Find(id);
            if (alt_Kategoriler == null)
            {
                return HttpNotFound();
            }
            return View(alt_Kategoriler);
        }

        // GET: Alt_Kategoriler/Create
        public ActionResult Create()
        {
            ViewBag.kategori_id = new SelectList(db.Kategoriler, "id", "kategori_ad");
            return View();
        }

        // POST: Alt_Kategoriler/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,altKategori_ad,kategori_id")] Alt_Kategoriler alt_Kategoriler)
        {
            if (ModelState.IsValid)
            {
                db.Alt_Kategoriler.Add(alt_Kategoriler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.kategori_id = new SelectList(db.Kategoriler, "id", "kategori_ad", alt_Kategoriler.kategori_id);
            return View(alt_Kategoriler);
        }

        // GET: Alt_Kategoriler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alt_Kategoriler alt_Kategoriler = db.Alt_Kategoriler.Find(id);
            if (alt_Kategoriler == null)
            {
                return HttpNotFound();
            }
            ViewBag.kategori_id = new SelectList(db.Kategoriler, "id", "kategori_ad", alt_Kategoriler.kategori_id);
            return View(alt_Kategoriler);
        }

        // POST: Alt_Kategoriler/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,altKategori_ad,kategori_id")] Alt_Kategoriler alt_Kategoriler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alt_Kategoriler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.kategori_id = new SelectList(db.Kategoriler, "id", "kategori_ad", alt_Kategoriler.kategori_id);
            return View(alt_Kategoriler);
        }

        // GET: Alt_Kategoriler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alt_Kategoriler alt_Kategoriler = db.Alt_Kategoriler.Find(id);
            if (alt_Kategoriler == null)
            {
                return HttpNotFound();
            }
            return View(alt_Kategoriler);
        }

        // POST: Alt_Kategoriler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alt_Kategoriler alt_Kategoriler = db.Alt_Kategoriler.Find(id);
            db.Alt_Kategoriler.Remove(alt_Kategoriler);
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
