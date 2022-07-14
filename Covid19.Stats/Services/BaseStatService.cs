using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Covid19.Stats.Data;
using Covid19.Stats.Models;

namespace Covid19.Stats.Services
{
    public class BaseStatService
    {
        protected readonly AppDbContext _context;
        public BaseStatService(AppDbContext context)
        {
            _context = context;
        }

        protected IQueryable<CovidStat> getLastData()
        {
            return _context.Stats
                .Where(s => s.Date == _context.Stats.Max(x => x.Date));
        }

        protected IQueryable<CovidStat> getPenultData()
        {
            return _context.Stats
                .Where(s => s.Date == _context.Stats.Max(x => x.Date).AddDays(-1));
        }
    }
}
