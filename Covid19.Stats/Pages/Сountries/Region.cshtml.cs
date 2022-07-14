using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Covid19.Stats.Services;
using Covid19.Stats.Models;

namespace Covid19.Stats.Pages.Сountries
{
    public class RegionModel : PageModel
    {
        private readonly RegionStatService _service;
        public RegionViewModel RegionStat;
        public RegionModel(RegionStatService service)
        {
            _service = service;
        }

        public IActionResult OnGet(string country, string region)
        {
            RegionStat = _service.GetCountryStat(country, region);
            return RegionStat is null ? NotFound() : Page();
        }
    }
}
