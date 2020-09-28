using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAndDecks.Data
{
    public class CardProperty
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Card")]
        public int CardId { get; set; }
        [Required]
        public Card Card { get; set; }
        [Required]
        [ForeignKey("TemplateProperty")]
        public int TemplatePropertyId { get; set; }
        [Required]
        public TemplateProperty TemplateProperty { get; set; }
    }
}
