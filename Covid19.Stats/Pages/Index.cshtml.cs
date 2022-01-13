using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid19.Stats.Services;
namespace Covid19.Stats.Pages
{
    public class IndexModel : PageModel
    {
        private readonly StatsService _service;
        public IndexModel(StatsService service)
        {
            _service = service;
        }

        public void OnGet()
        {

        }
    }
}
