using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Avisos.Dal;
using Avisos.Models;

namespace Avisos.Controllers
{
    public class HomeController : Controller
    {

        private AvisoContext db = new AvisoContext();

        public ActionResult Index()
        {
            ViewBag.Message = "Aviso Dashboard";
            var avisos = db.Avisos.ToList();
            HomePageAvisos model = new HomePageAvisos(){Avisos = avisos };
            return View("Index", model);
        }

        public ActionResult HowTo()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

    }
}
