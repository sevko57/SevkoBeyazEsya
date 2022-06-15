using SevkoBeyazEsya.Models;
using SevkoBeyazEsya.Models.Yoneticiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SevkoBeyazEsya.Controllers
{
    public class SubelerController : Controller
    {
        // GET: Subeler
        Context database = new Context();
        public ActionResult Panel()
        {
            return View();
        }
        public ActionResult Listele()
        {
            List<Subeler> subeler= database.Subelers.ToList();
            return View(subeler);
        }
        public ActionResult Ekle()
        {
            return View();
        }
        public ActionResult Ekle(Subeler subeler)
        {
            database.Subelers.Add(subeler);
            database.SaveChanges();
            return RedirectToAction("Listele");
        }
        public ActionResult Sil(int? subeid)
        {
            var subeler = database.Subelers.Find(subeid);
            database.Subelers.Remove(subeler);
            database.SaveChanges();
            return RedirectToAction("Listele");
        }
        public ActionResult Duzenle(int? subeid)
        {
            var subeler = database.Subelers.FirstOrDefault(x => x.Sube_id == subeid);
            return View(subeler);
        }
        [HttpPost]
        public ActionResult Duzenle(Subeler sube)
        {
            var subeler = database.Subelers.Find(sube.Sube_id);
            subeler.Sube_Adi = sube.Sube_Adi;
            subeler.sehir = sube.sehir;
            subeler.e_mail = sube.e_mail;
            subeler.Telefon_Numarasi = sube.Telefon_Numarasi;
            database.SaveChanges();
            return RedirectToAction("Listele");
        }
    }
}