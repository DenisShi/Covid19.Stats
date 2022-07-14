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
        DataPointsSelector _dataPointsSelector;
        public CountryStatService(AppDbContext context, DataPointsSelector dataPointsSelector) : base(context) 
        {
            _dataPointsSelector = dataPointsSelector;
        }
        public SummaryViewModel GetCountryStat(string country)
        {
            return new()
            {
                TableData = GetTableData(country),
                DataPoints = new()
                {
                    DataPointsDaily = _dataPointsSelector.GetAll(country),
                    DataPointsMonthly = _dataPointsSelector.GetMonthly(country),
                    DataPointsWeekly = _dataPointsSelector.GetWeekly(country)
                }
            };
        }

        private IEnumerable<TableRowSummary> _getRegionsStat(string country)
        {
            #region PrepareData
            var lastData = getLastData()
                    .Where(x => x.Country_Region == country)
                    .GroupBy(
                    x => x.Province_State,
                    x => new { x.Confirmed, x.Death, x.Case_Fatality_Ratio })
                    .Select(x => new
                    {
                        Region = x.Key,
                        Cases = x.Sum(y => y.Confirmed),
                        Deaths = x.Sum(y => y.Death),
                        FatalityRatio = (float)Math.Round(x.Average(y => y.Case_Fatality_Ratio), 2)
                    });
            var penultData = getPenultData()
                    .Where(x => x.Country_Region == country)
                    .GroupBy(
                    x => x.Province_State,
                    x => new { x.Confirmed, x.Death })
                    .Select(x => new
                    {
                        Region = x.Key,
                        Cases = x.Sum(y => y.Confirmed),
                        Deaths = x.Sum(y => y.Death),
                    });
            #endregion
            var joinedData = lastData.Join(penultData,
                    f => f.Region,
                    s => s.Region,
                    (f, s) => new TableRowSummary
                    {
                        CountryRegion = f.Region,
                        Cases = f.Cases,
                        CasesDelta = f.Cases - s.Cases,
                        Deaths = f.Deaths,
                        DeathsDelta = f.Deaths - s.Deaths,
                        FatalityRatio = f.FatalityRatio
                    }
                    ).OrderByDescending(x => x.Cases);

            return joinedData;

        }

        public TableData GetTableData(string country)
        {
            var lastData = getLastData()
                .Where(x => x.Country_Region == country); ;
            var penultData = getPenultData()
                .Where(x => x.Country_Region == country); ;
            var Cases = lastData.Sum(x => x.Confirmed);
            var Deaths = lastData.Sum(x => x.Death);
            TableData tabledata = new()
            {
                CountryRegion = country,
                Cases = Cases,
                Deaths = Deaths,
                LastUpdate = lastData.Max(x => x.Last_Update),
                CasesDelta = Cases - penultData.Sum(x => x.Confirmed),
                DeathsDelta = Deaths - penultData.Sum(x => x.Death),
                FatalityRatio = (float)Math.Round(lastData.Average(x => x.Case_Fatality_Ratio), 2),
                RowSummary = _getRegionsStat(country)
            };
            return tabledata;
        }
    }
}
