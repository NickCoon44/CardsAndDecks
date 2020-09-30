using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAndDecks.Models
{
    public class DeckDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CardDetail> DeckList { get; set; }
    }
}
