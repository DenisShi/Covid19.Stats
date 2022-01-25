using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Covid19.Stats.Data;
using Covid19.Stats.Models;


namespace Covid19.Stats.Services
{
    public class LastDataStatsService
    {
        readonly AppDbContext _context;
        public LastDataStatsService(AppDbContext context)
        {
            _context = context;
        }

        public GlobalStatSummaryViewModel GetGlobalStat()
        {
            var lastData = getLastData();
            var casesSum = lastData.Sum(x => x.Confirmed);
            var deathSum = lastData.Sum(x => x.Death);

            return new GlobalStatSummaryViewModel() { Cases = casesSum, Deaths = deathSum };   
        }
        public IEnumerable<CountrySummaryViewModel> GetCountriesStat()
        {
            return getLastData()
                .GroupBy(
                x => x.Country_Region,
                x => new { x.Confirmed, x.Death })
                .Select(x => new CountrySummaryViewModel
                {
                    Country = x.Key,
                    Cases = x.Sum(y => y.Confirmed),
                    Deaths = x.Sum(y => y.Death),
                });
        }
        public CountrySummaryViewModel GetCountryStat(string country)
        {
            return getLastData()
                .Where(x => x.Country_Region == country)
                .GroupBy(
                x => x.Country_Region,
                x => new { x.Confirmed, x.Death })
                .Select(x => new CountrySummaryViewModel
                {
                    Country = x.Key,
                    Cases = x.Sum(y => y.Confirmed),
                    Deaths = x.Sum(y => y.Death),
                }).FirstOrDefault();
        }
        private IQueryable<CovidStat> getLastData()
        {
            return _context.Stats
                .Where(s => s.Last_Update == _context.Stats.Max(x => x.Last_Update));
        }
    }
}
