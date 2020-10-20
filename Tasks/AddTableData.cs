using System;
using System.Threading.Tasks;
using Atea.Interfaces;
using Atea.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Atea.Tasks
{
    public class AddTableData : IAddTableData
    {
        public async Task Add(ExecutionContext ec, bool success)
        {
            var cloudAccount = CloudStorageAccount.Parse(Environment.GetEnvironmentVariable("AzureWebJobsStorage"));
            var tableClient = cloudAccount.CreateCloudTableClient();
            var logTable = tableClient.GetTableReference("LogDataTable");
            await logTable.CreateIfNotExistsAsync();

            DateTime rowKey = DateTime.Now;
            rowKey = rowKey.AddSeconds(-rowKey.Second);

            var tableData = new TableData(DateTime.Now.ToString("yyyy-MM-dd-HH-mm"), rowKey.ToString())
            {
                Id = ec.InvocationId.ToString(),
                Success = success
            };
            var dataToTable = TableOperation.Insert(tableData);
            await  logTable.ExecuteAsync(dataToTable);
        }
    }
}
