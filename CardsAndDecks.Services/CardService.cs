using CardsAndDecks.Data;
using CardsAndDecks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAndDecks.Services
{
    public class CardService
    {
        public bool CreateCard(CardCreate model)
        {
            var entity = new Card()
            {
                Name = model.Name,
                DeckId = model.DeckId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Cards.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
