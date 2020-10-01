﻿using CardsAndDecks.Models;
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
        public ActionResult Create(CardViewModel model) //returns null name and 0 templateId and I don't know why
        {
            if (!ModelState.IsValid) return View(model);

            int templateId = model.TemplateId;
            var tempPropService = new TemplatePropertyService();
            var tempPropList = tempPropService.GetTemplateProperties(templateId);

            var cardPropService = new CardPropertyService();

            for (var i = 0; i < model.Values.Count(); i++)
            {
                var cardProperty = new CardPropCreate()
                {
                    TemplatePropId = tempPropList[i].Id,
                    Value = model.Values[i],
                    CardId = model.CardId
                };
                bool isCreated = cardPropService.CreateCardProperty(cardProperty);
                if (!isCreated)
                {
                    ModelState.AddModelError("", "Template Property could not be created.");

                    return View(model);
                }

            }

            TempData["SaveResult"] = "Property Added";
            return RedirectToAction("Index");
        }
    }
}