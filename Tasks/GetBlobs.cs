using System;
using System.Linq;
using System.Threading.Tasks;
using Atea.Interfaces;
using Microsoft.WindowsAzure.Storage;

namespace Atea.Models
{
    class GetBlobs :IGetBlobs
    {
        public async Task<string> GetBlob(string name)
        {
            string connectionString = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            var serviceClient = storageAccount.CreateCloudBlobClient();
            var container = serviceClient.GetContainerReference("imported-data");
            var blob = container.GetBlockBlobReference(name);

            string  contents = await blob.DownloadTextAsync();

            return !contents.Any()? null :contents;
        }
    }
}
