using CardsAndDecks.Data;
using CardsAndDecks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAndDecks.Services
{
    public class TemplateService
    {
        public bool SeedNameProperty(int templateId)
        {
            var seedNameProp = new TemplatePropCreate()
            {
                TemplateId = templateId,
                PropertyName = "Name",
                PropertyType = PropertyType.Text
            };
            var propService = new TemplatePropertyService();
            return propService.CreateTemplateProperty(seedNameProp);
        }

        public int CreateTemplate(TemplateSimple model)
        {
            var entity = new Template()
            {
                Name = model.Name
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Templates.Add(entity);
                if (ctx.SaveChanges() == 1)
                {
                    return entity.Id;
                }
                return 0;
            }
        }

        public TemplateSimple GetTemplateById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Templates
                        .Single(e => e.Id == id);
                return
                    new TemplateSimple
                    {
                        Name = entity.Name,
                        PropertyList = entity.PropertyList.Select(t => new TemplatePropCreate
                        {
                            PropertyType = t.PropertyType,
                            PropertyName = t.PropertyName,
                            TemplateId = t.TemplateId
                        }).ToList()
                    };
            }
        }

        public IEnumerable<TemplateSimple> GetTemplates()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Cards
                        .Select(e => new TemplateSimple
                        {
                            Id = e.Id,
                            Name = e.Name,
                        });

                return query.ToArray();
            }
        }
    }
}
