using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Stats.Models
{
    public class CountrySummaryViewModel
    {
        public string Country { get; set; }
        public int Cases { get; set; }
        public int Deaths { get; set; }
        public int CasesDelta { get; set; }
        public int DeathsDelta { get; set; }

        public DateTime LastUpdate { get; set; }
        public IEnumerable<DataPoint> DataPoints;
        public IEnumerable<DataPoint> DataPointsWeekly;
        public IEnumerable<DataPoint> DataPointsMonthly;
        public IEnumerable<RegionSummary> RegionSummaries;
    }
}
