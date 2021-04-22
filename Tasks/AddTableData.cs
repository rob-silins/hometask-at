using Atea.Interfaces;
using Atea.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Threading.Tasks;

namespace Atea.Tasks
{
    public class AddTableData : IAddTableData
    {
        public async Task Add( bool success)
        {
            var cloudAccount = CloudStorageAccount.Parse(Environment.GetEnvironmentVariable("AzureWebJobsStorage"));
            var tableClient = cloudAccount.CreateCloudTableClient();
            var logTable = tableClient.GetTableReference("LogDataTable");
            await logTable.CreateIfNotExistsAsync();

            DateTime rowKey = DateTime.Now;
            rowKey = rowKey.AddSeconds(-rowKey.Second);

            var tableData = new TableData(DateTime.Now.ToString("yyyy-MM-dd-HH-mm"), rowKey.ToString())
            {
                Success = success
            };
            var dataToTable = TableOperation.Insert(tableData);
            await  logTable.ExecuteAsync(dataToTable);
        }
    }
}
