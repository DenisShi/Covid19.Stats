using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid19.Stats.Services;
using Covid19.Stats.Models;

namespace Covid19.Stats.Pages
{
    public class IndexModel : PageModel
    {
        private readonly StatsService _service;
        public GlobalStatSummaryViewModel GlobalStat { get; set; }
        public IEnumerable<CountrySummaryViewModel> CountriesSummary { get; set; }
        
        public IndexModel(StatsService service)
        {
            _service = service;
        }

        public void OnGet()
        {
            GlobalStat = _service.GetGlobalStat();
            CountriesSummary = _service.GetCountriesStat();
        }
    }
}
