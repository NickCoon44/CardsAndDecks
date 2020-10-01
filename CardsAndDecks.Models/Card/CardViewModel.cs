using CardsAndDecks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAndDecks.Models.Card
{
    public class CardViewModel
    {
        public string CardName { get; set; }
        public int TemplateId { get; set; }
        public int CardId { get; set; }
        public IList<TemplatePropCreate> TemplatePropertyList { get; set; }
        public string[] Values { get; set; }
    }
}
