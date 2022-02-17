using System;

namespace Covid19.Stats.Data
{
    public class CovidStat
    {
        public int Id { get; set; }
        public string FIPS { get; set; }
        public string Admin2 { get; set; }
        public string Province_State { get; set; }
        public string Country_Region { get; set; }
        public int Date { get; set; }
        public int Last_Update { get; set; }
        public float Lat { get; set; }
        public float Long { get; set; }
        public int Confirmed { get; set; }
        public int Death { get; set; }
        public int Recovered { get; set; }
        public int Active { get; set; }
        public string Combined_key { get; set; }
        public float Incident_Rate { get; set; }
        public float Case_Fatality_Ratio { get; set; }

        public DateTime Date2 { get; set; }
        public DateTime Last_Update2 { get; set; }
    }
}
