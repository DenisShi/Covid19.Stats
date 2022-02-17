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
        //Константа из-за особенности даты последнего обновления в базе (число секунд от 2010.01.01 00:00:00)
        protected readonly DateTime _startDate = new(2010, 1, 1, 0, 0, 0);
        protected readonly AppDbContext _context;
        public BaseStatService(AppDbContext context)
        {
            _context = context;
        }

        protected IQueryable<CovidStat> getLastData()
        {
            return _context.Stats
                .Where(s => s.Date2 == _context.Stats.Max(x => x.Date2));
        }
    }
}
