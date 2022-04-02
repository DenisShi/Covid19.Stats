using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid19.Stats.Data;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Covid19.Stats.Models
{
    public class GlobalSummaryViewModel
    {
        public int Cases { get; set; }
        public int Deaths { get; set; }
        public int CasesDelta { get; set; }
        public int DeathsDelta { get; set; }
        public DateTime LastUpdate { get; set; }
        public IEnumerable<DataPoint> DataPoints;
        public IEnumerable<DataPoint> DataPointsMonthly;
        public IEnumerable<DataPoint> DataPointsWeekly;
        public GlobalScriptsParams Params { get; set; }
        public void InitParams()
        {
            Params = new();
            Params.BarChartCases = $"{JsonSerializer.Serialize(DataPoints.GetDates())}, " +
                $"{JsonSerializer.Serialize(DataPoints.GetCases())}, " +
                $"'casesChart'," +
                $"\"Cases Chart\"";
        }
    }
}
