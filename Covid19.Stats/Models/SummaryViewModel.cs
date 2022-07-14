using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid19.Stats.Data;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Covid19.Stats.Models
{
    public class SummaryViewModel
    {
        public DataPointsAggregation DataPoints = new();
        public IEnumerable<DataPoint> DataPointsDaily;
        public IEnumerable<DataPoint> DataPointsMonthly;
        public IEnumerable<DataPoint> DataPointsWeekly;
  
        public TableData TableData;

        string _jsonMapDataTable;
        public string JsonMapDataTable
        {
            get => _jsonMapDataTable ??= TableData.RowSummary.GetJsonTableFromCountriesStat();
            private set => _jsonMapDataTable = value;
        }
        //string _jsonBarChartLabels;
        //public string JsonBarChartLabels
        //{
        //    get => _jsonBarChartLabels ??= JsonSerializer.Serialize(DataPointsDaily.GetDates());
        //    private set => _jsonBarChartLabels = value;
        //}
    }
}
