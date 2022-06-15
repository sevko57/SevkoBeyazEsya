using SevkoBeyazEsya.Models;
using SevkoBeyazEsya.Models.Yoneticiler;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SevkoBeyazEsya.Controllers
{
    public class YoneticiController : Controller
    {
        // GET: Yonetici
        [Authorize]
        public ActionResult Panel()
        {
            return View();
        }
        public ActionResult CikisYap()
        {
            Session.Remove("Admin");
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(Yonetici yonetici)
        {
            Context database = new Context();
            var girisyap = database.Yoneticis.FirstOrDefault(m => m.Yonetici_adi == yonetici.Yonetici_adi && m.sifre == yonetici.sifre);
            if (girisyap != null)
            {
                Session.Add("Admin", yonetici.Yonetici_adi);
                FormsAuthentication.SetAuthCookie(yonetici.Yonetici_adi, false);
                return RedirectToAction("Panel", "Yonetici");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Listele()
        {
            Context database = new Context();
            List<Yonetici> yoneticiler= database.Yoneticis.ToList();
            return View(yoneticiler);
        }
        public ActionResult Ekle()
        {
            return View();
        }
        public ActionResult Ekle(Yonetici yoneticiler)
        {
            Context database = new Context();
            database.Yoneticis.Add(yoneticiler);
            database.SaveChanges();
            return RedirectToAction("Listele");
        }
        public ActionResult Sil(int? yonetici_id)
        {
            Context database = new Context();
            var yoneticiler = database.Yoneticis.Find(yonetici_id);
            database.Yoneticis.Remove(yoneticiler);
            database.SaveChanges();
            return RedirectToAction("Listele");
        }
        public ActionResult Duzenle(int? yonetici_id)
        {
            Context database = new Context();
            var yoneticiler = database.Yoneticis.FirstOrDefault(x => x.Yonetici_id == yonetici_id);
            return View(yoneticiler);
        }
        [HttpPost]
        public ActionResult Duzenle(Yonetici yonetici)
        {
            Context database = new Context();
            var yoneticiler = database.Yoneticis.Find(yonetici.Yonetici_id);
            yoneticiler.Yonetici_adi = yonetici.Yonetici_adi;
            yoneticiler.sifre = yonetici.sifre;
            yoneticiler.yetki = yonetici.yetki;
            database.SaveChanges();
            return RedirectToAction("Listele");
        }
    }
}