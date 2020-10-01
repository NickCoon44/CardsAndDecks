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

        public bool CreateCardProperty(CardPropCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                TemplateProperty tempProp = ctx.TemplateProperties.Find(model.TemplatePropId);
                var entity = new CardProperty(tempProp)
                {
                    CardId = model.CardId,
                    Value = model.Value
                };

                ctx.CardProperties.Add(entity);
                return ctx.SaveChanges() == 1;
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
                            Id = t.Id,
                            PropertyName = t.PropertyName,
                            PropertyType = t.PropertyType,
                            CardId = t.CardId,
                            Value = t.Value
                        }).ToList()
                    };
            }
        }

        public CardPropDetail GetCardPropById(int propertyId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CardProperties
                        .Single(e => e.Id == propertyId);
                return
                    new CardPropDetail
                    {
                        Id = entity.Id,
                        PropertyName = entity.PropertyName,
                        PropertyType = entity.PropertyType,
                        CardId = entity.CardId,
                        Value = entity.Value,
                    };
            }
        }

        public IEnumerable<CardDetail> GetCards()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Cards
                        .Select(e => new CardDetail
                        {
                            Id = e.Id,
                            Name = e.Name,
                            TemplateId = e.TemplateId
                        });

                return query.ToArray();
            }
        }

        public bool UpdateCard(CardEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Cards
                        .Single(e => e.Id == model.CardId);
                entity.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateCardProperty(CardPropEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CardProperties
                        .Single(e => e.Id == model.PropertyId);
                entity.Value = model.Value;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
