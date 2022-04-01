using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Covid19.Stats.Data;
using Covid19.Stats.Models;


namespace Covid19.Stats.Services
{
    public class CountryStatService : BaseStatService
    {
        public CountryStatService(AppDbContext context) : base(context) { }
        public CountrySummaryViewModel GetCountryStat(string country)
        {
            var lastData = getLastData()
                .Where(x => x.Country_Region == country);
            var penultData = getPenultData()
                .Where(x => x.Country_Region == country);

            var Cases = lastData.Sum(x => x.Confirmed);
            var Deaths = lastData.Sum(x => x.Death);
            return new()
            {
                Country = country,
                Cases = Cases,
                Deaths = Deaths,
                LastUpdate = lastData.Max(x => x.Last_Update),
                CasesDelta = Cases - penultData.Sum(x => x.Confirmed),
                DeathsDelta = Deaths - penultData.Sum(x => x.Death),
                DataPoints =
                _context.Stats
                .Where(x => x.Country_Region == country)
                .GroupBy(
                x => x.Date,
                x => new { x.Confirmed, x.Death })
                .Select(x => new DataPoint
                {
                    Date = x.Key,
                    Cases = x.Sum(y => y.Confirmed),
                    Deaths = x.Sum(y => y.Death),
                }
                ).OrderBy(x => x.Date)
            };
        }
    }
}
