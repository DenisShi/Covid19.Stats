﻿using Covid19.Stats.Data;
using Covid19.Stats.Models;
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

        public IEnumerable<DataPoint> GetAll(string? country = null)
        {
            var stats = country == null ? _context.Stats : _context.Stats.Where(x => x.Country_Region == country);
            return stats
                .GroupBy(
                x => x.Date,
                x => new { x.Confirmed, x.Death })
                .Select(x => new DataPoint
                {
                    Date = x.Key,
                    Cases = x.Sum(y => y.Confirmed),
                    Deaths = x.Sum(y => y.Death),
                }
                ).OrderBy(x => x.Date);
        }

    }
}
