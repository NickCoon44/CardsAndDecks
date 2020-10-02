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
                        Id = entity.Id,
                        Name = entity.Name,
                        PropertyList = entity.PropertyList.Select(t => new TemplatePropDetail
                        {
                            Id = t.Id,
                            PropertyType = t.PropertyType,
                            PropertyName = t.PropertyName,
                            TemplateId = t.TemplateId
                        }).ToList()
                    };
            }
        }

        public TemplatePropDetail GetTemplatePropById(int templateId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TemplateProperties
                        .Single(e => e.Id == templateId);
                return
                    new TemplatePropDetail
                    {
                        Id = entity.Id,
                        PropertyName = entity.PropertyName,
                        PropertyType = entity.PropertyType,
                        TemplateId = entity.TemplateId
                    };
            }
        }

        public IEnumerable<TemplateSimple> GetTemplates()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Templates
                        .Select(e => new TemplateSimple
                        {
                            Id = e.Id,
                            Name = e.Name,
                        });

                return query.ToArray();
            }
        }

        public bool UpdateTemplate(TemplateEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Templates
                        .Single(e => e.Id == model.TemplateId);
                entity.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateTemplateProperty(TemplatePropEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var templateProperty = ctx
                    .TemplateProperties
                    .Single(t => t.Id == model.PropertyId);

                var cardPropList = ctx
                    .CardProperties
                    .Where(c => c.TemplateId == model.TemplateId && c.PropertyName == templateProperty.PropertyName);

                int count = 1;
                if (cardPropList != null)
                {
                    foreach (CardProperty cardProperty in cardPropList)
                    {
                        cardProperty.PropertyName = model.PropertyName;
                        count++;
                    }
                }

                templateProperty.PropertyName = model.PropertyName;

                return ctx.SaveChanges() == count;
            }
        }

        public bool DeleteTemplate(int templateId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Templates
                    .Single(e => e.Id == templateId);

                var cardList = ctx
                    .Cards
                    .Where(c => c.TemplateId == templateId);

                int count = 1;
                if (cardList != null)
                {
                    foreach(Card card in cardList)
                    {
                        ctx.Cards.Remove(card);
                        count++;
                    }
                }

                ctx.Templates.Remove(entity);

                return ctx.SaveChanges() == count;
            }
        }
    }
}
