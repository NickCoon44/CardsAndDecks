﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAndDecks.Models
{
    public class CardEdit
    {
        public int CardId { get; set; }
        public string Name { get; set; }
        public ICollection<CardPropDetail> PropertyList { get; set; }
    }
}
