using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Covid19.Stats.Services;

namespace Covid19.Stats.Pages
{
    public class ExportModel : PageModel
    {
        private readonly ExportService _service;
        public ExportModel(ExportService service)
        {
            _service = service;
        }
        public void OnGet()
        {
        }
        public void OnPost(string separator, string[] countries)
        {
            _service.GetData(separator, countries);
           
        }
    }
}
