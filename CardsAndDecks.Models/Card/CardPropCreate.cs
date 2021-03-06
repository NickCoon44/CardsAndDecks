﻿using CardsAndDecks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAndDecks.Models
{
    public class CardPropCreate
    {
        // Other properties are handled by a constructor and inheritance
        [Required]
        public int CardId { get; set; }
        [Required]
        public string Value { get; set; }
        [Required]
        public int TemplatePropId { get; set; }
    }
}
