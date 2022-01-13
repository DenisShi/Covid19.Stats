using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Covid19.Stats.Data;
using Covid19.Stats.Models;


namespace Covid19.Stats.Services
{
    public class StatsService
    {
        readonly AppDbContext _context;
        public StatsService(AppDbContext context)
        {
            _context = context;
        }

        public GlobalStatSummaryViewModel GetGlobalStat()
        {
            var lastData = getLastData();
            var casesSum = lastData.Sum(x => x.Confirmed);
            var deathSum = lastData.Sum(x => x.Deaths);

            return new GlobalStatSummaryViewModel() { Cases = casesSum, Deaths = deathSum };   
        }
        public IEnumerable<CountrySummaryViewModel> GetCountriesStat()
        {
            return getLastData()
                .GroupBy(
                x => x.CountryRegion,
                x => new { x.Confirmed, x.Deaths })
                .Select(x => new CountrySummaryViewModel
                {
                    Country = x.Key,
                    Cases = x.Sum(y => y.Confirmed),
                    Deaths = x.Sum(y => y.Deaths),
                });
        }
        public CountrySummaryViewModel GetCountryStat(string country)
        {
            return getLastData()
                .Where(x => x.CountryRegion == country)
                .GroupBy(
                x => x.CountryRegion,
                x => new { x.Confirmed, x.Deaths })
                .Select(x => new CountrySummaryViewModel
                {
                    Country = x.Key,
                    Cases = x.Sum(y => y.Confirmed),
                    Deaths = x.Sum(y => y.Deaths),
                }).FirstOrDefault();
        }
        private IQueryable<CovidStat> getLastData()
        {
            return _context.Stats
                .Where(s => s.DateTime == _context.Stats.Max(x => x.DateTime));
        }
    }
}
