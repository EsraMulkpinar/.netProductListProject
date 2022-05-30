using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        private finalprojectEntities1 db = new finalprojectEntities1();
        public ActionResult Index()
        {
            ViewBag.OnlineUyeSayisi = HttpContext.Application["OnlineUyeSayisi"];

            return View(db.Populer_Icerikler.ToList());
        }

       [HttpPost]

//public ActionResult Index([ModelBinder(typeof(ZamanModelBinder))]
//DateTime tarih)
//{
//return View();
//}


        public ActionResult About()
        {
            ViewBag.Message = Session["adres"]; //Session değerini okutmak
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}