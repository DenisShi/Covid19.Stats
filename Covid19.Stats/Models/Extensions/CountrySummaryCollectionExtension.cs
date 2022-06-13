using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid19.Stats.Models;

namespace Covid19
{
    public static class CountrySummaryCollectionExtension
    {
        public static Dictionary<string, int> GetCasesMapInfo(this IEnumerable<GlobalCountrySummary> countrySummaries)
        {
            Dictionary<string, int> pairs = new();
            foreach (var cs in countrySummaries)
            {
                pairs.Add(cs.Country, cs.Cases);
            }
            return pairs;
        }
        public static Dictionary<string, int> GetDeathsMapInfo(this IEnumerable<GlobalCountrySummary> countrySummaries)
        {
            Dictionary<string, int> pairs = new();
            foreach (var cs in countrySummaries)
            {
                pairs.Add(cs.Country, cs.Deaths);
            }
            return pairs;
        }


        public static Dictionary<string, (int, int)> GetGlobalMapInfo(this IEnumerable<GlobalCountrySummary> countrySummaries)
        {
            Dictionary<string, (int, int)> ps = new();
            foreach (var cs in countrySummaries)
                ps.Add(cs.Country, (cs.Cases, cs.Deaths));

            return ps;
        }
    }
}
