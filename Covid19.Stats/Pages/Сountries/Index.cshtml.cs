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
        CountryStatService _service;
        public SummaryViewModel CountryStat;
        public IndexModel(CountryStatService service)
        {
            _service = service;
        }
        public IActionResult OnGet(string country)
        {
            CountryStat = _service.GetCountryStat(country);
            return CountryStat is null ? NotFound() : Page();
        }
    }
}
