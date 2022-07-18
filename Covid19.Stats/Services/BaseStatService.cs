using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Covid19.Stats.Data;
using Covid19.Stats.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Covid19.Stats.Services
{
    public class BaseStatService
    {
        protected readonly AppDbContext context;
        protected IMemoryCache cache;
        protected readonly TimeSpan cacheDuration = TimeSpan.FromDays(1);
        public BaseStatService(AppDbContext context, IMemoryCache memoryCache)
        {
            this.context = context;
            cache = memoryCache;
        }

        protected IQueryable<CovidStat> GetLastData()
        {
            return context.Stats
                .Where(s => s.Date == context.Stats.Max(x => x.Date));
        }

        protected IQueryable<CovidStat> GetPenultData()
        {
            return context.Stats
                .Where(s => s.Date == context.Stats.Max(x => x.Date).AddDays(-1));
        }
    }
}
