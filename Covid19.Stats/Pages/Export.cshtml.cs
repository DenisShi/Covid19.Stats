using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Covid19.Stats.Services;
using System.IO;

namespace Covid19.Stats.Pages
{
    public class ExportModel : PageModel
    {
        private readonly ExportService _service;
        public ExportModel(ExportService service)
        {
            _service = service;
        }
        //public ActionResult OnGet()
        //{

        //}
        //public ActionResult OnPost(string separator, string[] countries)
        //{
        //    var file =_service.GetData(separator, countries);
        //    return FileResult
        //}
    }
}
