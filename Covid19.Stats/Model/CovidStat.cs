namespace Covid19.Stats.Model
{
    public class CovidStat
    {
        public string ProvinceState { get; set; }
        public string CountryRegion { get; set; }
        public int Confirmed { get; set; }
        public int Deaths { get; set; }
        public int Recovered { get; set; }
        public int Active { get; set; }
    }
}
