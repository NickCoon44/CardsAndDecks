using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAndDecks.Models
{
    public class CardEditViewModel
    {
        public int PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string Value { get; set; }
        public int CardId { get; set; }
        public string CardName { get; set; }
    }
}
