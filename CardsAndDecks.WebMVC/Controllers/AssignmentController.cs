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
    public class AssignmentController : Controller
    {
        // GET: Create
        public ActionResult Create(int id, bool isCard)
        {
            if (isCard)
            {
                var deckService = new DeckService();
                var allDecks = deckService.GetDecks();
                var cardToDeck = new AssignmentViewModel(isCard)
                {
                    CardId = id,
                    DeckList = allDecks,
                };
                return View(cardToDeck);
            }
            var cardService = new CardService();
            var allCards = cardService.GetCards();
            var deckToCard = new AssignmentViewModel(isCard)
            {
                DeckId = id,
                CardList = allCards,
            };
            return View(deckToCard);
        }

        // GET: Create
        public ActionResult CreateAssignment(int deckId, int cardId, bool isCard)
        {
            var assignment = new AssignmentCreate()
            {
                DeckId = deckId,
                CardId = cardId
            };

            var svc = new AssignmentService();
            svc.CreateAssignment(assignment);
            TempData["SaveAdd"] = "Card Added to Deck";
            if (isCard)
            {
                return RedirectToAction("Create", new { id = cardId, isCard = true });
            }
            return RedirectToAction("Create", new { id = deckId, isCard = false });
        }

        public ActionResult Delete(int assignmentId, bool fromCard, int objId)
        {
            var svc = new AssignmentService();
            svc.DeleteAssignment(assignmentId);

            if (fromCard)
            {
                TempData["SaveRemove"] = "Removed from Deck";
                return RedirectToAction("Details", "Card", new { id = objId });
            }
            TempData["SaveResult"] = "Card Removed";
            return RedirectToAction("Details", "Deck", new { id = objId });
        }
    }
}