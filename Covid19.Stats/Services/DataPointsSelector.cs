using Covid19.Stats.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Stats.Services
{
    public class DataPointsSelector
    {
        protected readonly AppDbContext _context;
        public DataPointsSelector(AppDbContext context)
        {
            _context = context;
        }

    }
}
