using CardsAndDecks.Data;
using CardsAndDecks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAndDecks.Services
{
    public class TemplatePropertyService
    {
        public bool CreateTemplateProperty(TemplatePropCreate model)
        {
            var entity = new TemplateProperty()
            {
                TemplateId = model.TemplateId,
                PropertyName = model.PropertyName,
                Type = model.Type,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.TemplateProperties.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
