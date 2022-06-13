using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid19.Stats.Data;

namespace Covid19.Stats.Models
{
    public class GlobalCountrySummary
    {
        public string Country { get; set; }
        public int Cases { get; set; }
        public int Deaths { get; set; }
        public int CasesDelta { get; set; }
        public int DeathsDelta { get; set; }

        public int FatalityRatio
        {
            get => default;
            set
            {
            }
        }
    }
}
