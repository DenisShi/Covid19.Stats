﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Stats.Models
{
    public class DataPoint
    {
        public int Cases { get; set; }
        public int Deaths { get; set; }
        public int CasesDelta { get; set; }
        public int DeathsDelta { get; set; }
        public DateTime Date;
    }
}
