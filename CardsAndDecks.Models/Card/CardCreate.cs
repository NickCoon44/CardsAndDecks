using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAndDecks.Models
{
    public class CardCreate
    {
        [Required]
        [Display(Name = "Card Name")]
        public string Name { get; set; }
        [Display(Name = "Select Template")]
        public int TemplateId { get; set; }
        //public int DeckId { get; set; }
        public ICollection<CardPropCreate> PropertyList { get; set; }
    }
}
