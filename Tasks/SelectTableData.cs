using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atea.Interfaces;
using Atea.Models;
using Microsoft.WindowsAzure.Storage.Table;

namespace Atea.Tasks
{
    public class SelectTableData :  ISelectTableData
    {
        public readonly ISelectTableDataComponents _components;
        public readonly ISelectTableDataReference _table;

        public SelectTableData(ISelectTableDataComponents components, ISelectTableDataReference table)
        {
            _components = components;
            _table = table;
        }

        public async Task<List<TableData>> TableData(string from, string to)
        {
            var logTable = _table.Reference();

            var logList = new List<TableData>();
            
            var startRange = _components.ConvertToDateTime(from);
            var endRange = _components.ConvertToDateTime(to);

            if (startRange > endRange) return null;
            
            var filterBySelectedDates = $"RowKey ge '{startRange}' and RowKey le '{endRange}'";
            var query = new TableQuery<TableData>().Where(filterBySelectedDates);

            var result = await logTable.ExecuteQuerySegmentedAsync(query, null);

            logList.AddRange(result);

            return (!logList.Any()) ? null : logList;
        }
    }
}
