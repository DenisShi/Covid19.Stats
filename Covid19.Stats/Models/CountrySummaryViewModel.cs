using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Stats.Models
{
    public class CountrySummaryViewModel
    {
        public string Country { get; set; }
        public int Confirmed { get; set; }
        public int Deaths { get; set; }
    }
}
