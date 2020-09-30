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
                PropertyType = model.PropertyType,
            };

            using (var ctx = new ApplicationDbContext())
            {
                //entity.Template = ctx.Templates.Find(entity.TemplateId);
                ctx.TemplateProperties.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
