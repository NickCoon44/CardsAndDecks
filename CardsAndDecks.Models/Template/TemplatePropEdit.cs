using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAndDecks.Models
{
    public class TemplatePropEdit
    {
        public int PropertyId { get; set; }
        [Display(Name = "Property Name")]
        public string PropertyName { get; set; }
        public int TemplateId { get; set; }
    }
}
