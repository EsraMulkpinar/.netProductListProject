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
    public class UrunlersController : Controller
    {
        private finalprojectEntities1 db = new finalprojectEntities1();

        // GET: Urunlers
        public ActionResult Index()
        {
            var urunler = db.Urunler.Include(u => u.Alt_Kategoriler);
            return View(urunler.ToList());
        }

        // GET: Urunlers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urunler urunler = db.Urunler.Find(id);
            if (urunler == null)
            {
                return HttpNotFound();
            }
            ViewBag.urunler = new SelectList(db.Urunler, "id", "indirme_linki");
            return View(urunler);
        }

        // GET: Urunlers/Create
        public ActionResult Create()
        {
            ViewBag.altKategori_id = new SelectList(db.Alt_Kategoriler, "id", "altKategori_ad");
            return View();
        }

        // POST: Urunlers/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,urun_ad,altKategori_id,urun_img,indirme_linki")] Urunler urunler)
        {
           
                try
                {
                    string DosyaAdi = Guid.NewGuid().ToString().Replace("-", "");
                    //Kaydetceğimiz resmin uzantısını aldık.
                    string uzanti = System.IO.Path.GetExtension(Request.Files[0].FileName);
                    string TamYolYeri = "~/Content/assets/img/" + DosyaAdi + uzanti;
                    //Eklediğimiz Resni Server.MapPath methodu ile Dosya Adıyla birlikte kaydettik.
                    Request.Files[0].SaveAs(Server.MapPath(TamYolYeri));
                    //Ve veritabanına kayıt için dosya adımızı değişkene aktarıyoruz.
                    urunler.urun_img = DosyaAdi + uzanti;
                    db.Urunler.Add(urunler);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    var newException = new Exception();
                    throw newException;
                }
               
                return RedirectToAction("Index");

      
        

            ViewBag.altKategori_id = new SelectList(db.Alt_Kategoriler, "id", "altKategori_ad", urunler.altKategori_id);
            return View(urunler);
        }

        // GET: Urunlers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urunler urunler = db.Urunler.Find(id);
            if (urunler == null)
            {
                return HttpNotFound();
            }
            ViewBag.altKategori_id = new SelectList(db.Alt_Kategoriler, "id", "altKategori_ad", urunler.altKategori_id);
            return View(urunler);
        }

        // POST: Urunlers/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,urun_ad,altKategori_id,urun_img,indirme_linki")] Urunler urunler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(urunler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.altKategori_id = new SelectList(db.Alt_Kategoriler, "id", "altKategori_ad", urunler.altKategori_id);
            return View(urunler);
        }

        // GET: Urunlers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urunler urunler = db.Urunler.Find(id);
            if (urunler == null)
            {
                return HttpNotFound();
            }
            return View(urunler);
        }

        // POST: Urunlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Urunler urunler = db.Urunler.Find(id);
            db.Urunler.Remove(urunler);
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
