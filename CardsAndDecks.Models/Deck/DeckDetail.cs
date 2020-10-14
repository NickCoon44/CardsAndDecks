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
        public ICollection<AssignmentDetail> AssignmentList { get; set; }
        public int DeckCount => CardCount(AssignmentList);

        public int CardCount(ICollection<AssignmentDetail> list)
        {
            int count = 0;
            foreach(AssignmentDetail assignment in list)
            {
                count += (1 * assignment.NumberOfAssignments );
            }
            return count;
        }
    }
}
