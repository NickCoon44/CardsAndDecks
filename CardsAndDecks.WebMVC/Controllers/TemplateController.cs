using CardsAndDecks.Models;
using CardsAndDecks.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CardsAndDecks.WebMVC.Controllers
{
    [Authorize]

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
                TempData["SaveResult"] = "Add Properties.";
                return RedirectToAction("Create", "TemplateProperty", new { templateId = id });
            };

            ModelState.AddModelError("", "Template could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = new TemplateService();
            var model = svc.GetTemplateById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = new TemplateService();
            var template = service.GetTemplateById(id);
            var model = new TemplateEdit
            {
                TemplateId = template.Id,
                Name = template.Name,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TemplateEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TemplateId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new TemplateService();

            if (service.UpdateTemplate(model))
            {
                TempData["SaveResult"] = "The Template Name was updated.";
                return RedirectToAction("Details", new { id = model.TemplateId});
            }

            ModelState.AddModelError("", "The Template name could not be updated.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = new TemplateService();
            var model = svc.GetTemplateById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new TemplateService();

            service.DeleteTemplate(id);

            TempData["SaveResult"] = "Template Deleted";

            return RedirectToAction("Index");
        }
    }
}