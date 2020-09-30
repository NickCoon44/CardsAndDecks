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

        //public bool CreateTemplateProperty(TemplatePropCreate model)
        //{
        //    var entity = new TemplateProperty()
        //    {
        //        TemplateId = model.TemplateId,
        //        PropertyName = model.PropertyName,
        //        PropertyType = model.PropertyType
        //    };

        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        ctx.TemplateProperties.Add(entity);
        //        return ctx.SaveChanges() == 1;
        //    }
        //}

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
    }
}
