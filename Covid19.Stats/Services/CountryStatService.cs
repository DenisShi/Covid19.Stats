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
            return new()
            {
                Country = country,
                Cases = lastData.Sum(x => x.Confirmed),
                Deaths = lastData.Sum(x => x.Death),
                LastUpdate = lastData.Max(x => x.Last_Update),
                CasesDelta = lastData.Sum(x => x.Confirmed) - penultData.Sum(x => x.Confirmed),
                DeathsDelta = lastData.Sum(x => x.Death) - penultData.Sum(x => x.Death),
                DataPoints =
                _context.Stats
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
