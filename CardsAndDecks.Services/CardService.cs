using CardsAndDecks.Data;
using CardsAndDecks.Models;
using CardsAndDecks.Models.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAndDecks.Services
{
    public class CardService
    {
        private readonly string _userid;

        public CardService() { }
        public CardService(string userId)
        {
            _userid = userId;
        }
        public int CreateCard(CardCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var template = ctx.Templates.Single(t => t.Id == model.TemplateId);

                var entity = new Card(template)
                {
                    Name = model.Name,
                };

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
                var entity = ctx
                    .Cards
                    .Single(e => e.Id == id);
                
                return
                    new CardDetail
                    {
                        Id = id,
                        Name = entity.Name,
                        TemplateId = entity.TemplateId,
                        TemplateName = entity.TemplateName,
                        PropertyList = entity.PropertyList.Select(p => new CardPropDetail
                        {
                            Id = p.Id,
                            PropertyName = p.PropertyName,
                            PropertyType = p.PropertyType,
                            CardId = p.CardId,
                            Value = p.Value
                        }).ToList(),
                        AssignmentList = entity.AssignmentList.Where(a => a.ApplicationUserId == _userid).Select(a => new AssignmentDetail
                        {
                            Id = a.Id,
                            CardId = a.Id,
                            Card = a.Card,
                            DeckId = a.DeckId,
                            Deck = a.Deck
                        }).ToList()
                    };
            }
        }

        public CardPropDetail GetCardPropById(int propertyId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
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
                var query = ctx
                    .Cards
                    .Select(e => new CardDetail
                    {
                        Id = e.Id,
                        TemplateName = e.TemplateName,
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
                var entity = ctx
                    .Cards
                    .Single(e => e.Id == model.CardId);

                entity.Name = model.Name;
                //entity.PropertyList = model.PropertyList.Select(c => new CardProperty
                //{
                //    CardId = entity.Id,
                //    TemplateId = entity.TemplateId,
                //    PropertyName = c.PropertyName,
                //    PropertyType = c.PropertyType,
                //    Value = c.Value
                //}).ToList();

                var changes = ctx.SaveChanges();

                return changes == 1;
            }
        }

        public bool UpdateCardProperty(CardPropEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .CardProperties
                    .Single(e => e.Id == model.PropertyId);
                entity.Value = model.Value;

                return ctx.SaveChanges() == 1;
            }
        }

        public void SeedValues(int cardId, IList<TemplatePropDetail> tempPropList)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Cards.Single(e => e.Id == cardId);

                foreach (var property in tempPropList)
                {
                    var cardProp = new CardPropCreate
                    {
                        TemplatePropId = property.Id,
                        CardId = cardId,
                        Value = "x"
                    };
                    CreateCardProperty(cardProp);
                }
            }
        }

        public bool DeleteCard(int cardId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Cards
                        .Single(e => e.Id == cardId);

                ctx.Cards.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public void ClearProperties(int cardId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.CardProperties.Where(e => e.CardId == cardId);
                foreach (var property in query)
                {
                    ctx.CardProperties.Remove(property);
                }
                ctx.SaveChanges();
            }
        }
    }
}
