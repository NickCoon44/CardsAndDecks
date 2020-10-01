using CardsAndDecks.Data;
using CardsAndDecks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAndDecks.Services
{
    public class CardPropertyService
    {

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
    }
}
