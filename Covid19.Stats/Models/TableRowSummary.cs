﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid19.Stats.Data;

namespace Covid19.Stats.Models
{
    public class TableRowSummary
    {
        public string CountryRegion { get; set; }
        public int Cases { get; set; }
        public int Deaths { get; set; }
        public int CasesDelta { get; set; }
        public int DeathsDelta { get; set; }
        public float FatalityRatio { get; set; }
    }
}
