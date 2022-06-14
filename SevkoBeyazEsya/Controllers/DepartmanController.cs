using SevkoBeyazEsya.Models;
using SevkoBeyazEsya.Models.Yoneticiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SevkoBeyazEsya.Controllers
{
    public class DepartmanController : Controller
    {
        Context database = new Context();
        // GET: Departman
        public ActionResult Listele()
        {
            List<Departman> departman = database.Departmans.ToList();
            return View(departman);
        }
        public ActionResult Ekle()
        {
            return View();
        }
        public ActionResult Ekle(Departman departman)
        {
            database.Departmans.Add(departman);
            database.SaveChanges();
            return RedirectToAction("Listele");
        }
        public ActionResult Sil(int? departmanid)
        {
            var departmanlar = database.Departmans.Find(departmanid);
            database.Departmans.Remove(departmanlar);
            database.SaveChanges();
            return RedirectToAction("Listele");
        }
        public ActionResult Duzenle(int? departmanid)
        {
            var departmanlar = database.Departmans.FirstOrDefault(x => x.Departman_id == departmanid);
            return View(departmanlar);
        }
        [HttpPost]
        public ActionResult Duzenle(Departman departman)
        {

            var departmanlar = database.Departmans.Find(departman.Departman_id);
            departmanlar.Departman_adi=departman.Departman_adi;
            database.SaveChanges();
            return RedirectToAction("Listele");
        }
    }
}