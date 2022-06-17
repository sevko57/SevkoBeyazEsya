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
            List<SelectListItem> kategoriler=(from x in database.Kategoris.ToList()
                                              select new SelectListItem
                                              {
                                                  Text=x.Kategori_Adi,
                                                  Value=x.Kategori_id.ToString()
                                              }
                                              ).ToList();
            ViewBag.kategori = kategoriler;
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
        public ActionResult Getir(int id)
        {
            List<SelectListItem> deger1 = (from x in database.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Kategori_Adi,
                                               Value = x.Kategori_id.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var urundeger = database.Urunlers.Find(id);
            return View("Getir", urundeger);
        }
        [HttpPost]
        public ActionResult Guncelle(Urunler urunler)
        {
            var urn = database.Urunlers.Find(urunler.Urun_id);
            urn.Urun_adi = urunler.Urun_adi;
            urn.Urun_marka = urunler.Urun_marka;
            urn.Urun_stok = urunler.Urun_stok;
            urn.Urun_alisfiyat = urunler.Urun_alisfiyat;
            urn.Urun_satisfiyat = urunler.Urun_satisfiyat;
            urn.Urun_durum = urunler.Urun_durum;
            urn.Urun_Gorsel = urunler.Urun_Gorsel;
            urn.Kategori.Kategori_id = urunler.Kategori.Kategori_id;
            database.SaveChanges();
            return RedirectToAction("UrunListele");
        }
        public ActionResult UrunSil(int id)
        {
            var urunler = database.Urunlers.Find(id);
            database.Urunlers.Remove(urunler);
            database.SaveChanges();
            return RedirectToAction("UrunListele");
        }
        public ActionResult UrunListele()
        {
            List<Urunler> urunlers = database.Urunlers.ToList();
            return View(urunlers);
        }
    }
}