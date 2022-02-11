using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid19.Stats.Models;

namespace Covid19
{
    public static class DataPointsCollectionExtension
    {
        public static IEnumerable<string> GetDates(this IEnumerable<DataPoint> dataPoints)
        {
            return dataPoints.Select(x => x.Date.ToShortDateString());
        }
        public static IEnumerable<int> GetCases(this IEnumerable<DataPoint> dataPoints)
        {
            return dataPoints.Select(x => x.Cases);
        }
        public static IEnumerable<int> GetDeaths(this IEnumerable<DataPoint> dataPoints)
        {
            return dataPoints.Select(x => x.Deaths);
        }
    }
}
