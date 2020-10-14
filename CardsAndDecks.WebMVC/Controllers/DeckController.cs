using CardsAndDecks.Models;
using CardsAndDecks.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CardsAndDecks.WebMVC.Controllers
{
    [Authorize]

    public class DeckController : Controller
    {
        // GET: Deck
        public ActionResult Index()
        {
            var service = new DeckService();
            var model = service.GetDecks();
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DeckCreate model)
        {
           // var userID = User.Identity.GetUserId();
            if (!ModelState.IsValid) return View(model);
           // model.UserID = userID;
            var service = new DeckService();
            int id = service.CreateDeck(model);

            if (id != 0)
            {
                TempData["SaveResult"] = "Deck created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Deck could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = new DeckService();
            var model = svc.GetDeckById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = new DeckService();
            var detail = service.GetDeckById(id);
            var model = new DeckEdit
            {
                Id = detail.Id,
                Name = detail.Name
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DeckEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new DeckService();

            if (service.UpdateDeck(model))
            {
                TempData["SaveResult"] = "Deck updated.";
                return RedirectToAction("Details", new { id = model.Id});
            }

            ModelState.AddModelError("", "Deck could not be updated.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = new DeckService();
            var model = svc.GetDeckById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new DeckService();

            service.DeleteDeck(id);

            TempData["SaveResult"] = "Deck deleted";

            return RedirectToAction("Index");
        }
    }
}