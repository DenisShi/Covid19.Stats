using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid19.Stats.Data;
using ServiceStack.Text;
using ServiceStack.Extensions;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace Covid19.Stats.Services
{
    public class ExportService
    {
        protected readonly AppDbContext _context;
        public ExportService(AppDbContext context)
        {
            _context = context;
        }
        public void GetData(string separator = ";", string[] countries = null) 
        {
            CsvConfig.ItemSeperatorString = separator;

            var csv_string = countries == null ? CsvSerializer.SerializeToCsv(_context.Stats) : CsvSerializer.SerializeToCsv(_context.Stats
                .Where(x => countries.Contains(x.Country_Region))
                );

        }
    }
}
