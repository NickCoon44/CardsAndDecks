using CardsAndDecks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAndDecks.Models
{
    public class CardDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TemplateId { get; set; }
        public string TemplateName { get; set; }
        public ICollection<CardPropDetail> PropertyList { get; set; }
        public ICollection<AssignmentDetail> AssignmentList { get; set; }

    }
}
