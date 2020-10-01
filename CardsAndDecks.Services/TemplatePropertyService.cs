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
                ctx.TemplateProperties.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IList<TemplatePropDetail> GetTemplateProperties(int templateId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.TemplateProperties.Where(t => t.TemplateId == templateId).Select(
                    e =>
                    new TemplatePropDetail
                    {
                        Id = e.Id,
                        TemplateId = e.TemplateId,
                        PropertyName = e.PropertyName,
                        PropertyType = e.PropertyType

                    }).ToList();
                return query;
            }
        }
    }
}
