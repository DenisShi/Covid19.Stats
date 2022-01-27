using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Covid19.Stats.Data;
using Covid19.Stats.Models;


namespace Covid19.Stats.Services
{
    public class GlobalStatService
    {
        //Константа из-за особенности даты последнего обновления в базе (число секунд от 2010.01.01 00:00:00)
        DateTime _startDate = new(2010, 1, 1, 0, 0, 0);

        readonly AppDbContext _context;
        public GlobalStatService(AppDbContext context)
        {
            _context = context;
        }

        public GlobalSummaryViewModel GetGlobalStat()
        {
            var lastData = getLastData();
            return new() { 
                Cases = lastData.Sum(x => x.Confirmed), 
                Deaths = lastData.Sum(x => x.Death), 
                DataPoints =
                _context.Stats
                .GroupBy(
                x => x.Last_Update,
                x => new { x.Confirmed, x.Death })
                .Select(x => new DataPoint
                {
                    Date = _startDate.AddSeconds(x.Key),
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
