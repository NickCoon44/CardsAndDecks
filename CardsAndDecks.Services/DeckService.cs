using CardsAndDecks.Data;
using CardsAndDecks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAndDecks.Services
{
    public class DeckService
    {
        public int CreateDeck(DeckCreate model)
        {
            var entity = new Deck()
            {
                Name = model.Name
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Decks.Add(entity);
                if (ctx.SaveChanges() == 1)
                {
                    return entity.Id;
                }
                return 0;
            }
        }

        public IEnumerable<DeckDetail> GetDecks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Decks
                    .Select(e => new DeckDetail
                    {
                        Id = e.Id,
                        Name = e.Name,
                    });

                return query.ToArray();
            }
        }

        public DeckDetail GetDeckById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Decks
                    .Single(e => e.Id == id);
                return
                    new DeckDetail
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        AssignmentList = entity.AssignmentList.Select(c => new AssignmentDetail
                        {
                            Id = c.Id,
                            CardId = c.Id,
                            Card = c.Card,
                            DeckId = c.DeckId,
                            Deck = c.Deck
                        }).ToList()
                    };
            }
        }

        public bool UpdateDeck(DeckEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                .Decks
                .Single(e => e.Id == model.Id);

                entity.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteDeck(int deckId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Decks
                    .Single(e => e.Id == deckId);

                ctx.Decks.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
