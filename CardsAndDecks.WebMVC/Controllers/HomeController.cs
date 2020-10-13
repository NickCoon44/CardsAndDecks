using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CardsAndDecks.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Well,";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Call me, or Beep me. If you want to reach me, or if you want to page me. It's okay.";

            return View();
        }
    }
}