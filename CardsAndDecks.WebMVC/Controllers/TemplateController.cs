using CardsAndDecks.Models;
using CardsAndDecks.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CardsAndDecks.WebMVC.Controllers
{
    public class TemplateController : Controller
    {
        // GET: Template
        public ActionResult Index()
        {
            var service = new TemplateService();
            var model = service.GetTemplates();
            return View(model);
        }

        // GET:
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TemplateSimple model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = new TemplateService();
            int id = service.CreateTemplate(model);
            service.SeedNameProperty(id);

            if (id != 0)
            {
                TempData["SaveResult"] = "Template created. Add Properties.";
                return RedirectToAction("Create", "TemplateProperty", new { templateId = id });
            };

            ModelState.AddModelError("", "Template could not be created.");

            return View(model);
        }

        
    }
}