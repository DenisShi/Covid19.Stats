using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid19.Stats.Models;

namespace Covid19.Stats.Models.Extensions
{
    public static class RegionSummaryCollectionExtension
    {
        public static Dictionary<string, int> GetCasesMapInfo(this IEnumerable<RegionSummary> countrySummaries)
        {
            Dictionary<string, int> pairs = new();
            foreach (var cs in countrySummaries)
            {
                pairs.Add(cs.RegionName, cs.Cases);
            }
            return pairs;
        }
        public static Dictionary<string, int> GetDeathsMapInfo(this IEnumerable<RegionSummary> countrySummaries)
        {
            Dictionary<string, int> pairs = new();
            foreach (var cs in countrySummaries)
            {
                pairs.Add(cs.RegionName, cs.Deaths);
            }
            return pairs;
        }
    }
}
