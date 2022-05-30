using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FinalProject.Models;
using System.Linq.Dynamic.Core;

namespace FinalProject.Controllers
{
    public class Uye_girisController : Controller
    {
        private finalprojectEntities1 db = new finalprojectEntities1();

        // GET: Uye_giris
        public ActionResult Index(string sort = "ad", string sortdir = "asc", string search = "")

        {
            int totalRecord = 0;
            var data = GetUye_Giris(search, sort, sortdir);
            ViewBag.TotalRows = totalRecord;
            ViewBag.search = search;
            return View(data);
        }
        public List<Uye_giris> GetUye_Giris(string search, string sort, string sortdir)

        {
            //burada AlbümEntities veritabanı içeriğini oluşturmaktadır
            using (finalprojectEntities1 db = new finalprojectEntities1())
            {
                var v = (from a in db.Uye_giris

                         where a.ad.Contains(search) ||
                         a.soyad.Contains(search) ||
                         a.mail.Contains(search)

                         select a
                );

             
                v = v.OrderBy(sort + " " + sortdir);
                return v.ToList();
            }
        }
        public ActionResult Login()

        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Uye_giris objUser)
        {
            if (ModelState.IsValid)
            {
                {
                    var obj = db.Uye_giris.Where(a => a.ad.Equals(objUser.ad) &&

                    a.soyad.Equals(objUser.soyad) &&

                    a.mail.Equals(objUser.mail) &&

                    a.sifre.Equals(objUser.sifre)).FirstOrDefault();

                    if (obj != null)
                    {
                        Session["KULLANICIID"] = obj.id.ToString();
                        Session["KULLANICIAD"] = obj.ad.ToString();
                        Session["KULLANICISOYAD"] = obj.soyad.ToString();
                        Session["KULLANICIMAIL"] = obj.mail.ToString();
                        Session["KULLANICISIFRE"] = obj.sifre.ToString();
                        return RedirectToAction("", new RouteValueDictionary(
                    new { controller = "", action = "" }));
                    }
                }
            }
            return View(objUser);
        }
       
        // GET: Uye_giris/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uye_giris uye_giris = db.Uye_giris.Find(id);
            if (uye_giris == null)
            {
                return HttpNotFound();
            }
            return View(uye_giris);
        }

        // GET: Uye_giris/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Uye_giris/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ad,soyad,mail,sifre")] Uye_giris uye_giris)
        {
            if (ModelState.IsValid)
            {
                db.Uye_giris.Add(uye_giris);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uye_giris);
        }

        // GET: Uye_giris/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uye_giris uye_giris = db.Uye_giris.Find(id);
            if (uye_giris == null)
            {
                return HttpNotFound();
            }
            return View(uye_giris);
        }

        // POST: Uye_giris/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ad,soyad,mail,sifre")] Uye_giris uye_giris)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uye_giris).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uye_giris);
        }

        // GET: Uye_giris/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uye_giris uye_giris = db.Uye_giris.Find(id);
            if (uye_giris == null)
            {
                return HttpNotFound();
            }
            return View(uye_giris);
        }

        // POST: Uye_giris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Uye_giris uye_giris = db.Uye_giris.Find(id);
            db.Uye_giris.Remove(uye_giris);
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
