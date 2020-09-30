using CardsAndDecks.Data;
using CardsAndDecks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAndDecks.Services
{
    public class CardPropertiesService
    {
        public bool CreateCardProperty(CardPropCreate model)
        {
            var entity = new CardProperty()
            {
                PropertyName = model.PropertyName,
                PropertyType = model.PropertyType,
                TemplateId = model.TemplateId,
                CardId = model.CardId,
                Value = model.Value
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CardProperties.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool CreateCardPropertyByTemp(CardPropCreate model, int templatePropId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                TemplateProperty tempProp = ctx.TemplateProperties.Find(templatePropId);
                var entity = new CardProperty(tempProp)
                {
                    CardId = model.CardId,
                    Value = model.Value
                };

                ctx.CardProperties.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
