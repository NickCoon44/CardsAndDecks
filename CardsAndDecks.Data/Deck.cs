using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAndDecks.Data
{
    public class Deck
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        //FK to ApplicationUser
        //[ForeignKey("User")]
        //public string ApplicationUserId { get; set; }
        //public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Assignment> AssignmentList { get; set; }


    }
}
