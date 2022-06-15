using SevkoBeyazEsya.Models;
using SevkoBeyazEsya.Models.Yoneticiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SevkoBeyazEsya.Controllers
{
    public class GiderController : Controller
    {
        Context database = new Context();
        // GET: Gider
        public ActionResult Listele()
        {
            List<Giderler> giderlers = database.Giderlers.ToList();
            return View(giderlers);
        }
        public ActionResult Ekle()
        {
            return View();
        }
        public ActionResult Ekle(Giderler giderler)
        {
            database.Giderlers.Add(giderler);
            database.SaveChanges();
            return RedirectToAction("Listele");
        }
        public ActionResult Sil(int? giderid)
        {
            var giderler = database.Giderlers.Find(giderid);
            database.Giderlers.Remove(giderler);
            database.SaveChanges();
            return RedirectToAction("Listele");
        }
        public ActionResult Duzenle(int? giderid)
        {
            var giderler = database.Giderlers.FirstOrDefault(x => x.Gider_id == giderid);
            return View(giderler);
        }
        [HttpPost]
        public ActionResult Duzenle(Giderler gider)
        {
            var giderler = database.Giderlers.Find(gider.Gider_id);
            giderler.Aciklama = gider.Aciklama;
            giderler.Tarih  = gider.Tarih;
            giderler.Tutar  = gider.Tutar;
            database.SaveChanges();
            return RedirectToAction("Listele");
        }
    }
}