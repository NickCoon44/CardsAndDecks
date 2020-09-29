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
        public string Name { get; set; }
        public int DeckId { get; set; }
    }
}
