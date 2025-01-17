﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Covid19.Stats.Data;
using Covid19.Stats.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Covid19.Stats.Services
{
    public class RegionStatService : BaseStatService
    {
        DataPointsSelector _dataPointsSelector;
        public RegionStatService(AppDbContext context, DataPointsSelector dataPointsSelector, IMemoryCache memoryCache) : base(context, memoryCache)
        {
            _dataPointsSelector = dataPointsSelector;
        }
        public RegionViewModel GetRegionStat(string country, string region)
        {
                var lastData = GetLastData()
              .Where(x => x.Country_Region == country && x.Province_State == region);
            var penultData = GetPenultData()
                .Where(x => x.Country_Region == country && x.Province_State == region);
            var cases = lastData.Sum(x => x.Confirmed);
            var deaths = lastData.Sum(x => x.Death);


            return new()
            {
                Country = country,
                Region = region,
                Cases = cases,
                Deaths = deaths,
                LastUpdate = lastData.Max(x => x.Last_Update),
                CasesDelta = cases - penultData.Sum(x => x.Confirmed),
                DeathsDelta = deaths - penultData.Sum(x => x.Death),
                FatalityRatio = (float)Math.Round(lastData.Average(x => x.Case_Fatality_Ratio), 2),
                DataPoints = new()
                {
                    DataPointsDaily = _dataPointsSelector.GetAll(country, region),
                    DataPointsMonthly = _dataPointsSelector.GetMonthly(country, region),
                    DataPointsWeekly = _dataPointsSelector.GetWeekly(country, region)
                }
            };
        }
    }
}
