﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PCE_Web.Classes;

namespace PCE_Web.Models
{
    public class SuggestionsSpecificationsView : IEnumerable
    {
        public static string AlertBoxText { get; set; }
        public List<Item> Products { get; set; }
        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
