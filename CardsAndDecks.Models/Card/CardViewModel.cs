using CardsAndDecks.Data;
using CardsAndDecks.Models.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAndDecks.Models
{
    public class CardViewModel
    {
        public string CardName { get; set; }
        public int TemplateId { get; set; }
        public string TemplateName { get; set; }
        public int CardId { get; set; }
        public IList<TemplatePropDetail> TemplatePropertyList { get; set; }
        public string[] Values { get; set; }
    }
}
