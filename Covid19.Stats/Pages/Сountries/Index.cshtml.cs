using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Covid19.Stats.Models;
using Covid19.Stats.Services;

namespace Covid19.Stats.Pages.Сountries
{
    public class IndexModel : PageModel
    {
        LastDataStatsService _service;
        public CountrySummaryViewModel CountrySummary;
        public IndexModel(LastDataStatsService service)
        {
            _service = service;
        }
        public IActionResult OnGet(string country)
        {
            CountrySummary = _service.GetCountryStat(country);
            if (CountrySummary is null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
