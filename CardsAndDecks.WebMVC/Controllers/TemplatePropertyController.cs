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

            //var templateProp = new TemplatePropCreate()
            //{
            //    TemplateId = templateId
            //};

            var model = new TemplateViewModel()
            {
                TemplateName = template.Name,
                PropertyList = template.PropertyList,
                TemplateId = templateId
                
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

            var service = new TemplatePropertyService();

            if (service.CreateTemplateProperty(property))
            {
                TempData["SaveResult"] = "Property Added";
                return RedirectToAction("Create", new { templateId = model.TemplateId });
            };

            ModelState.AddModelError("", "Template Property could not be created.");

            return View(model);
        }
    }
}