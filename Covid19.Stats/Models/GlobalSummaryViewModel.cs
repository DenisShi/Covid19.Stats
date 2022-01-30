using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid19.Stats.Data;

namespace Covid19.Stats.Models
{
    public class GlobalSummaryViewModel
    {
         public int Cases { get; set; }
         public int Deaths { get; set; }
         public IEnumerable<DataPoint> DataPoints;
         
         public IEnumerable<string> getDates() 
         {
            return DataPoints.Select(x => x.Date.ToString());
         }
        public IEnumerable<int> getCases()
        {
            return DataPoints.Select(x => x.Cases);
        }
    }
}
