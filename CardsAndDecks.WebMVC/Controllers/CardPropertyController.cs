using CardsAndDecks.Models;
using CardsAndDecks.Models.Card;
using CardsAndDecks.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CardsAndDecks.WebMVC.Controllers
{
    public class CardPropertyController : Controller
    {
        // GET: CardProperty
        public ActionResult Index()
        {
            return View();
        }

        //GET: Create
        public ActionResult Create(int cardId)
        {
            var cardService = new CardService();
            var card = cardService.GetCardById(cardId);

            var templateService = new TemplateService();
            var template = templateService.GetTemplateById(card.TemplateId);

            var values = new string[template.PropertyList.Count()];
            values[0] = card.Name;

            var model = new CardViewModel()
            {
                CardName = card.Name,
                CardId = card.Id,
                TemplateId = card.TemplateId,
                TemplatePropertyList = template.PropertyList,
                Values = values
            };

            return View(model);
        }

        // GET: Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CardViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var tempService = new TemplateService();
            var tempPropList = tempService.GetTemplateProperties(model.TemplateId);

            var cardService = new CardService();

            for (var i = 0; i < model.Values.Count(); i++)
            {
                var cardProperty = new CardPropCreate()
                {
                    TemplatePropId = tempPropList[i].Id,
                    Value = model.Values[i],
                    CardId = model.CardId
                };
                bool isCreated = cardService.CreateCardProperty(cardProperty);
                if (!isCreated)
                {
                    ModelState.AddModelError("", "Property could not be created.");

                    return View(model);
                }

            }

            TempData["SaveResult"] = "Card Created";
            return RedirectToAction("Index", "Card");
        }

        public ActionResult Edit(int id)
        {
            var service = new CardService();
            var property = service.GetCardPropById(id);
            var model = new CardPropEdit
            {
                PropertyId = property.Id,
                Value = property.Value,
                CardId = property.CardId
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CardPropEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PropertyId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new CardService();

            if (service.UpdateCardProperty(model))
            {
                TempData["SaveResult"] = "The Property was updated.";
                return RedirectToAction("Details", "Card", new { id = model.CardId });
            }

            ModelState.AddModelError("", "The Property could not be updated.");
            return View(model);
        }
    }
}