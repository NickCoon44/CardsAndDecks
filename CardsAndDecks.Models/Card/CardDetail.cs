using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAndDecks.Models.Card
{
    public class CardDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TemplateId { get; set; }
        //public int DeckId { get; set; }
        public ICollection<CardPropDetail> PropertyList { get; set; }
    }
}
