using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Covid19.Stats.Data;


namespace Covid19.Stats.Services
{
    public class StatsService
    {
        readonly AppDbContext _context;
        public StatsService(AppDbContext context)
        {
            _context = context;
        }
    }
}
