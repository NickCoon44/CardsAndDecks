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
        // Use Empty Constructor for Custom cards
        public CardProperty() {}
        // Use overloaded Constructor when using Template, by passing in Template Properties
        // each Template Property will be passed in and assigned to the Card of CardId
        public CardProperty(TemplateProperty tempProp)
        {
            PropertyName = tempProp.PropertyName;
            PropertyType = tempProp.PropertyType;
            TemplateId = tempProp.TemplateId;
            Template = tempProp.Template;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string PropertyName { get; set; }
        [Required]
        public PropertyType PropertyType { get; set; }
        [Required]
        [ForeignKey("Template")]
        public int TemplateId { get; set; }
        public Template Template { get; set; }
        [Required]
        [ForeignKey("Card")]
        public int CardId { get; set; }
        public Card Card { get; set; }
        [Required]
        public string Value { get; set; }
        public int ValueInt => ReadNumber(Value);

        public int ReadNumber(string value)
        {
            int parsedNum;
            bool isParsed = int.TryParse(value, out parsedNum);
            if (isParsed)
            {
                return parsedNum;
            }
            return 0;
        }

    }
}
