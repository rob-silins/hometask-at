﻿using System.Collections.Generic;
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
            
            var filterBySelectedDates = _components.FilteredDates(startRange, endRange);

            var query = new TableQuery<TableData>().Where(filterBySelectedDates);

            var result = logTable.ExecuteQuerySegmentedAsync(query, null);

            logList.AddRange(result.Result);

            return (!logList.Any()) ? null : logList;
        }
    }
}