using CardsAndDecks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAndDecks.Models
{
    public class TemplatePropCreate
    {
        [Required]
        public int TemplateId { get; set; }
        [Required]
        public string PropertyName { get; set; }
        [Required]
        public PropertyType PropertyType { get; set; }
    }
}
