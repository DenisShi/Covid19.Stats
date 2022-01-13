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
            var CasesSum = lastData.Sum(x => x.Confirmed);
            var DeathSum = lastData.Sum(x => x.Deaths);

            return new GlobalStatSummaryViewModel() { Cases = CasesSum, Deaths = DeathSum };
                
        }
        private IQueryable<CovidStat> getLastData()
        {
            return _context.Stats
                .Where(s => s.DateTime == _context.Stats.Max(x => x.DateTime));
        }
    }
}
