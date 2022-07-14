using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Stats.Models
{
    public class DataPointsAggregation
    {
        public IEnumerable<DataPoint> DataPointsDaily;
        public IEnumerable<DataPoint> DataPointsMonthly;
        public IEnumerable<DataPoint> DataPointsWeekly;
    }
}
