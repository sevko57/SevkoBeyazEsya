using SevkoBeyazEsya.Models;
using SevkoBeyazEsya.Models.Yoneticiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SevkoBeyazEsya.Controllers
{
    public class KategorilerController : Controller
    {
        // GET: Kategoriler
        Context database = new Context();
        public ActionResult Listele()
        {
            List<Kategori> kategoriler = database.Kategoris.ToList();
            return View(kategoriler);
        }
        public ActionResult Ekle()
        {
            return View();
        }
        public ActionResult Ekle(Kategori kategori)
        {
            database.Kategoris.Add(kategori);
            database.SaveChanges();
            return RedirectToAction("Listele");
        }
        public ActionResult Sil(int? kategori_id)
        {
            var kategoriler = database.Kategoris.Find(kategori_id);
            database.Kategoris.Remove(kategoriler);
            database.SaveChanges();
            return RedirectToAction("Listele");
        }
        public ActionResult Duzenle(int? kategori_id)
        {
            var kategoriler = database.Kategoris.FirstOrDefault(x => x.Kategori_id == kategori_id);
            return View(kategoriler);
        }
        [HttpPost]
        public ActionResult Duzenle(Kategori kategori)
        {
            var kategoriler = database.Kategoris.Find(kategori.Kategori_id);
            kategoriler.Kategori_Adi = kategori.Kategori_Adi;
            database.SaveChanges();
            return RedirectToAction("Listele");
        }
    }
}