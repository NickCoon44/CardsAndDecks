using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAndDecks.Models
{
    public class AssignmentViewModel
    {
        public AssignmentViewModel(bool isCard)
        {
            IsCard = isCard;
        }
        public int DeckId { get; set; }
        public string DeckName { get; set; }
        public int CardId { get; set; }
        public string CardName { get; set; }
        public bool IsCard { get; set; }
        public IEnumerable<CardDetail> CardList { get; set; }
        public IEnumerable<DeckDetail> DeckList { get; set; }
        public int NumberOfAssignments { get; set; }
    }
}
