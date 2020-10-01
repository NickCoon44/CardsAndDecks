using CardsAndDecks.Data;
using CardsAndDecks.Models;
using CardsAndDecks.Models.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAndDecks.Services
{
    public class CardService
    {
        public int CreateCard(CardCreate model)
        {
            var entity = new Card()
            {
                Name = model.Name,
                TemplateId = model.TemplateId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Cards.Add(entity);
                if (ctx.SaveChanges() == 1)
                {
                    return entity.Id;
                }
                return 0;
            }
        }

        public CardDetail GetCardById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Cards
                        .Single(e => e.Id == id);
                return
                    new CardDetail
                    {
                        Id = id,
                        Name = entity.Name,
                        TemplateId = entity.TemplateId,
                        PropertyList = entity.PropertyList.Select(t => new CardPropDetail
                        {
                            PropertyName = t.PropertyName,
                            PropertyType = t.PropertyType,
                            CardId = t.CardId,
                            Value = t.Value
                        }).ToList()
                    };
            }
        }
    }
}
