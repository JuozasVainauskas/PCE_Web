﻿using System;
using System.Collections.Generic;

namespace PCE_Web.Tables
{
    public partial class ReportsTable
    {
        public int ReportsId { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public int Solved { get; set; }
        public string Date { get; set; }
    }
}