using CardsAndDecks.Models;
using CardsAndDecks.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CardsAndDecks.WebMVC.Controllers
{
    public class CardController : Controller
    {
        // GET: Card
        public ActionResult Index()
        {
            return View();
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CardCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = new CardService();
            int id = service.CreateCard(model);
            if (id != 0)
            {
                TempData["SaveResult"] = "Card created. Add Properties.";
                return RedirectToAction("Create", "CardProperty", new { cardId = id });
            };

            ModelState.AddModelError("", "Template could not be created.");

            return View(model);
        }
    }
}