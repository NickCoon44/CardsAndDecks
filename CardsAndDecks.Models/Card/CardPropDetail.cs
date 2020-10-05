﻿using CardsAndDecks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAndDecks.Models
{
    public class CardPropDetail
    {
        public int Id { get; set; }
        public string PropertyName { get; set; }
        public PropertyType PropertyType { get; set; }

        public int CardId { get; set; }
        public string CardName { get; set; }
        public string Value { get; set; }
    }
}
