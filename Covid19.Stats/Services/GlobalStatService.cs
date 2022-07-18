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
    public class GlobalStatService : BaseStatService
    {
        private DataPointsSelector _dataPointsSelector;
        public GlobalStatService(AppDbContext context, DataPointsSelector dataPointsSelector, IMemoryCache memoryCache) : base(context, memoryCache) 
        {
            _dataPointsSelector = dataPointsSelector;
        }

        public SummaryViewModel GetGlobalStat()
       {
            SummaryViewModel vm = null;
            if (!cache.TryGetValue("globalstat", out vm))
            {
                vm = new()
                {
                    TableData = GetTableData(),
                    DataPoints = new()
                    {
                        DataPointsDaily = _dataPointsSelector.GetAll(),
                        DataPointsMonthly = _dataPointsSelector.GetMonthly(),
                        DataPointsWeekly = _dataPointsSelector.GetWeekly()
                    }
                };
                if (vm != null)
                    cache.Set("globalstat", vm, cacheDuration);
            }
            return vm;
        }
        private TableRowSummary[] GetCountriesStat()
        {
            #region PrepareData
            var lastData = GetLastData()
                    .GroupBy(
                    x => x.Country_Region,
                    x => new { x.Confirmed, x.Death, x.Case_Fatality_Ratio })
                    .Select(x => new
                    {
                        Country = x.Key,
                        Cases = x.Sum(y => y.Confirmed),
                        Deaths = x.Sum(y => y.Death),
                        FatalityRatio = (float)Math.Round(x.Average(y => y.Case_Fatality_Ratio), 2)
                    });
            var penultData = GetPenultData()
                    .GroupBy(
                    x => x.Country_Region,
                    x => new { x.Confirmed, x.Death })
                    .Select(x => new
                    {
                        Country = x.Key,
                        Cases = x.Sum(y => y.Confirmed),
                        Deaths = x.Sum(y => y.Death),
                    });
            #endregion
            var joinedData = lastData.Join(penultData,
                    f => f.Country,
                    s => s.Country,
                    (f, s) => new TableRowSummary
                    {
                        CountryRegion = f.Country,
                        Cases = f.Cases,
                        CasesDelta = f.Cases - s.Cases,
                        Deaths = f.Deaths,
                        DeathsDelta = f.Deaths - s.Deaths,
                        FatalityRatio = f.FatalityRatio
                    }
                    ).OrderByDescending(x => x.Cases);

            return joinedData.ToArray();
        }

        public TableData GetTableData()
        {
            var lastData = GetLastData().ToList();
            var penultData = GetPenultData().ToList();
            var Cases = GetLastData().Sum(x => x.Confirmed);
            var Deaths = GetLastData().Sum(x => x.Death);
            TableData tabledata = new()
            {
                IsGlobalTable = true,
                CountryRegion = "Total",
                Cases = Cases,
                Deaths = Deaths,
                LastUpdate = lastData.Max(x => x.Last_Update),
                CasesDelta = Cases - penultData.Sum(x => x.Confirmed),
                DeathsDelta = Deaths - penultData.Sum(x => x.Death),
                FatalityRatio = (float)Math.Round(lastData.Average(x => x.Case_Fatality_Ratio), 2),
                RowSummary = GetCountriesStat()
            };
            return tabledata;
        }
        public async Task<TableData> GetTableDataAsync()
        {
            return await Task.Run(() => GetTableData());
        }

        public TableRowSummary[] GetCountriesWithoutDelta()
        {
            var lastData = GetLastData()
                      .GroupBy(
                      x => x.Country_Region,
                      x => new { x.Confirmed, x.Death })
                      .Select(x => new TableRowSummary
                      {
                          CountryRegion = x.Key,
                          Cases = x.Sum(y => y.Confirmed),
                          Deaths = x.Sum(y => y.Death),
                      });
            return lastData.AsEnumerable().ToArray();
        }

    }
}
