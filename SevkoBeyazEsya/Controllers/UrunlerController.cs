using SevkoBeyazEsya.Models;
using SevkoBeyazEsya.Models.Yoneticiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SevkoBeyazEsya.Controllers
{
    public class UrunlerController : Controller
    {
        Context database = new Context();
        // GET: Urunler
        public ActionResult Index()
        {
            var urunler = database.Urunlers.ToList();
            return View(urunler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(Urunler urunler)
        {
            database.Urunlers.Add(urunler);
            database.SaveChanges();
            return RedirectToAction("Index", "Urunler");
        }
        [HttpGet]
        public ActionResult UrunGuncelle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UrunGuncelle(Urunler urunler)
        {
            database.Urunlers.Add(urunler);
            database.SaveChanges();
            return RedirectToAction("Index", "Urunler");
        }
        [HttpGet]
        public ActionResult UrunSil()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UrunSil(Urunler urunler)
        {
            database.Urunlers.Remove(urunler);
            database.SaveChanges();
            return RedirectToAction("Index", "Urunler");
        }
        public ActionResult UrunListele()
        {
            List<Urunler> urunlers = database.Urunlers.ToList();
            return View(urunlers);
        }
    }
}