using SevkoBeyazEsya.Models;
using SevkoBeyazEsya.Models.Yoneticiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SevkoBeyazEsya.Controllers
{
    public class SatislarController : Controller
    {
        Context database = new Context();
        // GET: Satislar
        public ActionResult Listele()
        {
            List<Satisler> satislers = database.Satislers.ToList();
            return View(satislers);
        }
        public ActionResult Ekle()
        {
            List<SelectListItem> urunler = (from x in database.Urunlers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.Urun_adi,
                                                Value = x.Urun_id.ToString()
                                            }
                                          ).ToList();
            ViewBag.urunler = urunler;
            List<SelectListItem> subeler = (from x in database.Subelers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.Sube_Adi,
                                                Value = x.Sube_id.ToString()
                                            }
                                          ).ToList();
            ViewBag.subeler = subeler;
            List<SelectListItem> personel = (from x in database.Personels.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.Personel_adi,
                                                Value = x.Personel_id.ToString()
                                            }
                                          ).ToList();
            ViewBag.personel = personel;
            List<SelectListItem> kategoriler = (from x in database.Kategoris.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.Kategori_Adi,
                                                Value = x.Kategori_id.ToString()
                                            }
                                          ).ToList();
            ViewBag.kategoriler = kategoriler;
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Satisler satisler)
        {
            database.Satislers.Add(satisler);
            database.SaveChanges();
            return RedirectToAction("Listele");
        }
        public ActionResult Sil(int satis_id)
        {
            var satis = database.Satislers.Find(satis_id);
            database.Satislers.Remove(satis);
            database.SaveChanges();
            return RedirectToAction("Listele");
        }
        public ActionResult Getir(int satis_id)
        {
            List<SelectListItem> urunler = (from x in database.Urunlers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.Urun_adi,
                                                Value = x.Urun_id.ToString()
                                            }
                                          ).ToList();
            ViewBag.urunler = urunler;
            List<SelectListItem> subeler = (from x in database.Subelers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.Sube_Adi,
                                                Value = x.Sube_id.ToString()
                                            }
                                          ).ToList();
            ViewBag.subeler = subeler;
            List<SelectListItem> personel = (from x in database.Personels.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Personel_adi,
                                                 Value = x.Personel_id.ToString()
                                             }
                                          ).ToList();
            ViewBag.personel = personel;
            List<SelectListItem> kategoriler = (from x in database.Kategoris.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.Kategori_Adi,
                                                    Value = x.Kategori_id.ToString()
                                                }
                                          ).ToList();
            ViewBag.kategoriler = kategoriler;
            var satis = database.Satislers.Find(satis_id);
            return View("Listele",satis);
        }
        [HttpPost]
        public ActionResult Duzenle(Satisler satisler)
        {
            var satis = database.Satislers.Find(satisler.Satis_id);
            satis.Urun_id = satisler.Urun_id;
            satis.Personel_id = satisler.Personel_id;
            satis.Sube_id = satisler.Sube_id;
            satis.Kategori_id = satisler.Kategori_id;
            satis.Tarih = satisler.Tarih;
            satis.Adet = satisler.Adet;
            satis.Fiyat = satisler.Fiyat;
            satis.ToplamTutar = satis.ToplamTutar;
            database.SaveChanges();
            return RedirectToAction("Listele");
        }
    }
}