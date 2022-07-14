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
        public static IEnumerable<int> GetCasesDelta(this IEnumerable<DataPoint> dataPoints)
        {
            return dataPoints.Select(x => x.CasesDelta);
        }
        public static IEnumerable<int> GetDeathsDelta(this IEnumerable<DataPoint> dataPoints)
        {
            return dataPoints.Select(x => x.DeathsDelta);
        }
        public static IEnumerable<DataPoint> InitDeltas(this IEnumerable<DataPoint> dataPoints)
        {
            var array = dataPoints.ToArray();
            var previousDataPoint = array.First();

            foreach (var datapoint in array.Skip(1))
            {
                datapoint.CasesDelta = datapoint.Cases - previousDataPoint.Cases;
                datapoint.DeathsDelta = datapoint.Deaths - previousDataPoint.Deaths;
                previousDataPoint = datapoint;
            }
            return array.AsEnumerable();
        }
    }
}
