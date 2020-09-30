using CardsAndDecks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAndDecks.Models
{
    public class CardPropCreate
    {
        [Required]
        public string PropertyName { get; set; }
        [Required]
        public PropertyType Type { get; set; }
        [Required]
        public int TemplateId { get; set; }
        [Required]
        public int CardId { get; set; }
        [Required]
        public string Value { get; set; }
    }
}
