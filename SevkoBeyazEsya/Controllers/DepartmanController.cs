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
        // GET: Departman
        public ActionResult Index()
        {
            Context database = new Context();
            List<Departman> departman = database.Departmans.ToList();
            return View(departman);
        }
    }
}