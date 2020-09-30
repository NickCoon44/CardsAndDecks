using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAndDecks.Data
{
    public class TemplateProperty
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Template")]
        public int TemplateId { get; set; }
        //[Required]
        public virtual Template Template { get; set; }
        [Required]
        public string PropertyName { get; set; }
        [Required]
        public PropertyType PropertyType { get; set; }
    }
    public enum PropertyType { Text, Number };
}
