﻿using System;

namespace Covid19.Stats.Data 
{
    public class CovidStat
    {
        public int Id { get; set; }
        public string ProvinceState { get; set; }
        public string CountryRegion { get; set; }
        public int Confirmed { get; set; }
        public int Deaths { get; set; }
        public int Recovered { get; set; }
        public int Active { get; set; }
        public DateTime DateTime { get; set; }

    }
}
