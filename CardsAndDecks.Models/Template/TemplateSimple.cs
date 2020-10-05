using CardsAndDecks.Models.Template;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAndDecks.Models
{
    public class TemplateSimple
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Template Name")]
        public string Name { get; set; }
        public IList<TemplatePropDetail> PropertyList { get; set; }
    }
}
