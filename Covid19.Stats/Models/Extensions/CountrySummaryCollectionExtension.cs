using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid19.Stats.Models;
using Google.DataTable.Net.Wrapper.Extension;
using Google.DataTable.Net.Wrapper;

namespace Covid19
{
    public static class CountrySummaryCollectionExtension
    {
        public static string GetJsonTableFromCountriesStat(this IEnumerable<TableRowSummary> stats)
        {
            var json = stats.ToGoogleDataTable()
                .NewColumn(new Column(ColumnType.String, "CountryRegion"), x => x.CountryRegion)
                .NewColumn(new Column(ColumnType.Number, "Cases"), x => x.Cases)
                .NewColumn(new Column(ColumnType.Number, "Deaths"), x => x.Deaths)
                .Build()
                .GetJson();
            return json;
        }

    }
}
