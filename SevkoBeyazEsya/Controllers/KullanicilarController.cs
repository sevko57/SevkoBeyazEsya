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
    }
}