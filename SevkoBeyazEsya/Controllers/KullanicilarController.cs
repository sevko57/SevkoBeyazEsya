using SevkoBeyazEsya.Models;
using SevkoBeyazEsya.Models.Yoneticiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SevkoBeyazEsya.Controllers
{
    public class KullanicilarController : Controller
    {
        // GET: Kullanicilar
        
        public ActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KayitOl(Kullaniciler kullaniciler)
        {
            Context database = new Context();
            database.Kullanicilers.Add(kullaniciler);
            database.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(Kullaniciler kullaniciler)
        {
            Context database = new Context();
            var girisyap = database.Kullanicilers.FirstOrDefault(m => m.e_mail == kullaniciler.e_mail && m.sifre == kullaniciler.sifre);
            if (girisyap!=null)
            {
                Session.Add("User", kullaniciler.Kullanici_Adi);
                FormsAuthentication.SetAuthCookie(kullaniciler.e_mail, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        public ActionResult KullaniciListele()
        {
            Context database = new Context();
            List<Kullaniciler> kullanicilers = database.Kullanicilers.ToList();
            return View(kullanicilers);
        }
        public ActionResult KayitEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KayitEkle(Kullaniciler kullaniciler)
        {
            Context database = new Context();
            database.Kullanicilers.Add(kullaniciler);
            database.SaveChanges();
            return RedirectToAction("KullaniciListele", "Kullanicilar");
        }
        public ActionResult Sil(int? kullanici_id)
        {
            Context database = new Context();
            var kullanicilar = database.Kullanicilers.Find(kullanici_id);
            database.Kullanicilers.Remove(kullanicilar);
            database.SaveChanges();
            return RedirectToAction("KullaniciListele");
        }
        public ActionResult Duzenle(int? kullanici_id)
        {
            Context database = new Context();
            var kullanicilar = database.Kullanicilers.FirstOrDefault(x => x.Kullanici_id == kullanici_id);
            return View(kullanicilar);
        }
        [HttpPost]
        public ActionResult Duzenle(Kullaniciler kullanici)
        {
            Context database = new Context();
            var kullanicilar = database.Kullanicilers.Find(kullanici.Kullanici_id);
            kullanicilar.Kullanici_Adi=kullanici.Kullanici_Adi;
            kullanicilar.Kullanici_Soyadi=kullanici.Kullanici_Soyadi;
            kullanicilar.e_mail=kullanici.e_mail;
            kullanicilar.telefon_numarasi=kullanici.telefon_numarasi;
            kullanicilar.sifre=kullanici.sifre;
            database.SaveChanges();
            return RedirectToAction("KullaniciListele");
        }
    }
}