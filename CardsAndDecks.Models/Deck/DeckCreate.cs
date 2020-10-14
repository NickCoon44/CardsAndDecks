using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAndDecks.Models
{
    public class DeckCreate
    {
        [Required]
        public string Name { get; set; }
       // public string UserID { get; set; }
    }
}
