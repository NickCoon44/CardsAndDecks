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
            var service = new CardService();
            var model = service.GetCards();

            return View(model);
        }

        // GET: Create
        public ActionResult Create()
        {
            var service = new TemplateService();
            var templates = service.GetTemplates();
            List<SelectListItem> templateSelect = templates.Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name }).ToList();
            ViewBag.Templates = templateSelect;

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
                TempData["SaveResult"] = "Enter Values";
                return RedirectToAction("Create", "CardProperty", new { cardId = id });
            };

            ModelState.AddModelError("", "Card could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = new CardService();
            var model = svc.GetCardById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = new CardService();
            var card = service.GetCardById(id);
            var model = new CardEdit
            {
                CardId = card.Id,
                Name = card.Name,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CardEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CardId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new CardService();

            if (service.UpdateCard(model))
            {
                TempData["SaveResult"] = "The Card name was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The Card name could not be updated.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = new CardService();
            var model = svc.GetCardById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new CardService();

            service.DeleteCard(id);

            TempData["SaveResult"] = "Card Deleted";

            return RedirectToAction("Index");
        }
    }
}