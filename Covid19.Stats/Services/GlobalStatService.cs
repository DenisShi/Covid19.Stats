using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Covid19.Stats.Data;
using Covid19.Stats.Models;


namespace Covid19.Stats.Services
{
    public class GlobalStatService : BaseStatService
    {
        public GlobalStatService(AppDbContext context) : base(context) { }

        public GlobalSummaryViewModel GetGlobalStat()
        {
            var lastData = getLastData();
            return new() { 
                Cases = lastData.Sum(x => x.Confirmed), 
                Deaths = lastData.Sum(x => x.Death), 
                DataPoints =
                _context.Stats
                .GroupBy(
                x => _startDate.AddSeconds(x.Date).Date,
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
        public IEnumerable<CountrySummaryViewModel> GetCountriesStat()
        {
            return getLastData()
                .GroupBy(
                x => x.Country_Region,
                x => new { x.Confirmed, x.Death})
                .Select(x => new CountrySummaryViewModel
                {
                    Country = x.Key,
                    Cases = x.Sum(y => y.Confirmed),
                    Deaths = x.Sum(y => y.Death),
                }).
                OrderByDescending(x => x.Cases);
        }

    }
}
