using SevkoBeyazEsya.Models;
using SevkoBeyazEsya.Models.Yoneticiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SevkoBeyazEsya.Controllers
{
    public class FaturalarController : Controller
    {
        Context database = new Context();
        // GET: Faturalar
        public ActionResult Listele()
        {
            List<Faturalar> faturalars = database.Faturalars.ToList();
            return View(faturalars);
        }
        public ActionResult Ekle()
        {
            return View();
        }
        public ActionResult Ekle(Faturalar faturalar)
        {
            database.Faturalars.Add(faturalar);
            database.SaveChanges();
            return RedirectToAction("Listele");
        }
        public ActionResult Sil(int? faturaid)
        {
            var faturalar = database.Faturalars.Find(faturaid);
            database.Faturalars.Remove(faturalar);
            database.SaveChanges();
            return RedirectToAction("Listele");
        }
        public ActionResult Duzenle(int? faturaid)
        {
            var faturalar = database.Faturalars.FirstOrDefault(x => x.Fatura_id == faturaid);
            return View(faturalar);
        }
        [HttpPost]
        public ActionResult Duzenle(Faturalar fatura)
        {

            var faturalar = database.Faturalars.Find(fatura.Fatura_id);
            faturalar.FaturaSeri_no=fatura.FaturaSeri_no ;
            faturalar.FaturaSira_no=fatura.FaturaSira_no ;
            faturalar.Tarih=fatura.Tarih ;
            faturalar.Vergi_dairesi=fatura.Vergi_dairesi ;
            faturalar.saat=fatura.saat ;
            faturalar.Teslim_eden=fatura.Teslim_eden;
            faturalar.Teslim_alan=fatura.Teslim_alan ;
            faturalar.ToplamFiyat=fatura.ToplamFiyat;
            database.SaveChanges();
            return RedirectToAction("Listele");
        }
    }
}