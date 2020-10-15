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
            var deckService = new DeckService();
            var cardService = new CardService();
            if (isCard)
            {
                var allDecks = deckService.GetDecks();
                var card = cardService.GetCardById(id);
                var cardToDeck = new AssignmentViewModel(isCard)
                {
                    CardId = id,
                    CardName = card.Name,
                    DeckList = allDecks
                };
                return View(cardToDeck);
            }

            var allCards = cardService.GetCards();
            var deck = deckService.GetDeckById(id);
            var deckToCard = new AssignmentViewModel(isCard)
            {
                DeckId = id,
                DeckName = deck.Name,
                CardList = allCards
            };
            return View(deckToCard);
        }

        // GET: Create
        public ActionResult CreateAssignment(int deckId, int cardId, bool isCard)
        {
            var svc = new AssignmentService();
            if (!svc.CheckAssignment(cardId, deckId))
            {
                var assignment = new AssignmentCreate()
                {
                    DeckId = deckId,
                    CardId = cardId
                };

                svc.CreateAssignment(assignment);
            }

            TempData["SaveResult"] = "Card Added to Deck";
            if (isCard)
            {
                return RedirectToAction("Create", new { id = cardId, isCard = true });
            }
            return RedirectToAction("Create", new { id = deckId, isCard = false });
        }

        public ActionResult QuickCreate(int deckId, int cardId)
        {
            var svc = new AssignmentService();
            svc.CheckAssignment(cardId, deckId);
            return RedirectToAction("Details", "Deck", new { id = deckId});
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
            return RedirectToAction("Details", "Deck", new { id = objId });
        }
    }
}