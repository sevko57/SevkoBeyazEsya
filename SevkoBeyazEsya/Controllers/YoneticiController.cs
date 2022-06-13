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
    }
}