using SevkoBeyazEsya.Models;
using SevkoBeyazEsya.Models.Yoneticiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SevkoBeyazEsya.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context database = new Context();
        public ActionResult Listele()
        {
            List<Personel> personeller = database.Personels.ToList();
            return View(personeller);
        }
        public ActionResult Ekle()
        {
            List<SelectListItem> deger1 = (from x in database.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Departman_adi,
                                               Value = x.Departman_id.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Personel personel)
        {
            database.Personels.Add(personel);
            database.SaveChanges();
            return RedirectToAction("Listele");
        }
        public ActionResult Sil(int? personel_id)
        {
            var personeller = database.Personels.Find(personel_id);
            database.Personels.Remove(personeller);
            database.SaveChanges();
            return RedirectToAction("Listele");
        }
        public ActionResult Getir(int id)
        {
            List<SelectListItem> deger1 = (from x in database.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Departman_adi,
                                               Value = x.Departman_id.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var prs = database.Personels.Find(id);
            return View("Getir", prs);
        }
        
        public ActionResult Duzenle(Personel personel)
        {
            var personeller = database.Personels.Find(personel.Personel_id);
           personeller.Personel_adi = personel.Personel_adi;
           personeller.Personel_Soyadi = personel.Personel_Soyadi;
           personeller.Personel_Gorsel = personel.Personel_Gorsel;
            personeller.Departman_id = personel.Departman_id;
            database.SaveChanges();
            return RedirectToAction("Listele");
        }
    }
}