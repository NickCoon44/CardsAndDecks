using CardsAndDecks.Data;
using CardsAndDecks.Models;
using CardsAndDecks.Models.Template;
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

            var model = new TemplateViewModel()
            {
                TemplateName = template.Name,
                PropertyList = template.PropertyList,
                TemplateId = template.Id
                
            };

            return View(model);
        }

        // GET: Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TemplateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var property = new TemplatePropCreate()
            {
                TemplateId = model.TemplateId,
                PropertyName = model.PropertyName,
                PropertyType = model.PropertyType
            };

            var service = new TemplateService();

            if (service.CreateTemplateProperty(property))
            {
                TempData["SaveResult"] = "Property Added";
                return RedirectToAction("Create", new { templateId = model.TemplateId });
            };

            ModelState.AddModelError("", "Template Property could not be created.");

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = new TemplateService();
            var property = service.GetTemplatePropById(id);
            var model = new TemplatePropEdit
            {
                PropertyId = property.Id,
                PropertyName = property.PropertyName,
                TemplateId = property.TemplateId
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TemplatePropEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PropertyId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new TemplateService();

            if (service.UpdateTemplateProperty(model))
            {
                TempData["SaveResult"] = "The Property Name was updated.";
                return RedirectToAction("Details", "Template", new { id = model.TemplateId });
            }

            ModelState.AddModelError("", "The Property could not be updated.");
            return View(model);
        }
    }
}