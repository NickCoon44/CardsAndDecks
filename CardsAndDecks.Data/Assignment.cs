using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAndDecks.Data
{
    public class Assignment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Deck")]
        public int DeckId { get; set; }
        public virtual Deck Deck { get; set; }
        [Required]
        [ForeignKey("Card")]
        public int CardId { get; set; }
        public virtual Card Card { get; set; }
        public int NumberOfAssignments { get; set; }
    }
}
