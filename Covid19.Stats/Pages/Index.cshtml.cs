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
        private readonly GlobalStatService _service;
        public SummaryViewModel GlobalStat;
        public IndexModel(GlobalStatService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            GlobalStat = _service.GetGlobalStat();
            return GlobalStat is null ? NotFound() : Page();
        }
    }
}
