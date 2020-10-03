using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAndDecks.Data
{
    public class Card
    {
        public Card(){ }

        public Card(Template template)
        {
            TemplateId = template.Id;
            TemplateName = template.Name;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int TemplateId { get; set; }
        public string TemplateName { get; set; }
        public virtual ICollection<CardProperty> PropertyList { get; set; }
        public virtual ICollection<Assignment> AssignmentList { get; set; }
    }
}
