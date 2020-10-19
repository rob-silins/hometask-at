using System;
using Atea.Interfaces;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Atea.Models
{
    public class SelectTableDataReference : ISelectTableDataReference
    {
        public CloudTable Reference()
        {
            string connectionString = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
            CloudStorageAccount tableAccount = CloudStorageAccount.Parse(connectionString);
            var tableClient = tableAccount.CreateCloudTableClient();
            var logTable = tableClient.GetTableReference("LogDataTable");

            return logTable;
        }
    }
}
