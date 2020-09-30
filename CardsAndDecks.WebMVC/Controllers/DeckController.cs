using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CardsAndDecks.WebMVC.Controllers
{
    public class DeckController : Controller
    {
        // GET: Deck
        public ActionResult Index()
        {
            return View();
        }
    }
}