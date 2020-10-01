using CardsAndDecks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAndDecks.Models.Template
{
    public class TemplatePropDetail
    {
        public int Id { get; set; }
        public int TemplateId { get; set; }
        public string PropertyName { get; set; }
        public PropertyType PropertyType { get; set; }
    }
}
