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
    }
}
