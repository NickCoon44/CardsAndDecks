using CardsAndDecks.Data;
using CardsAndDecks.Models.Template;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAndDecks.Models
{
    public class TemplateViewModel
    {
        // Display these: TemplateSimple
        public string TemplateName { get; set; }
        public ICollection<TemplatePropDetail> PropertyList { get; set; }

        // User Edits these: TemplatePropCreate
        public int TemplateId { get; set; } // Except this, which will be assigned and Hidden
        [Display(Name = "Property Name")]
        public string PropertyName { get; set; }
        [Display(Name = "Property Type")]
        public PropertyType PropertyType { get; set; }
    }
}
