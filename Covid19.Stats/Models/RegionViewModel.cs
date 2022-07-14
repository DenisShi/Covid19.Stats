using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Stats.Models
{
    public class RegionViewModel
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public int Cases { get; set; }
        public int Deaths { get; set; }
        public int CasesDelta { get; set; }
        public int DeathsDelta { get; set; }
        public float FatalityRatio { get; set; }
        public DateTime LastUpdate { get; set; }
        public DataPointsAggregation DataPoints;
        public IEnumerable<DataPoint> DataPointsDaily;
        public IEnumerable<DataPoint> DataPointsMonthly;
        public IEnumerable<DataPoint> DataPointsWeekly;
    }
}
