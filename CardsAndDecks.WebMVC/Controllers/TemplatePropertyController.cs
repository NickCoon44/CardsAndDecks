using CardsAndDecks.Data;
using CardsAndDecks.Models;
using CardsAndDecks.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CardsAndDecks.WebMVC.Controllers
{
    public class TemplatePropertyController : Controller
    {
        // GET: TemplateProperty
        public ActionResult Index()
        {
            return View();
        }

        // GET: Create
        public ActionResult Create(int templateId)
        {
            var service = new TemplateService();
            var template = service.GetTemplateById(templateId);
            return View(template);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TemplatePropCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = new TemplatePropertyService();

            if (service.CreateTemplateProperty(model))
            {
                int id = model.TemplateId;
                TempData["SaveResult"] = "Property Added";
                return RedirectToAction("Create", id);
            };

            ModelState.AddModelError("", "Template Property could not be created.");

            return View(model);
        }
    }
}