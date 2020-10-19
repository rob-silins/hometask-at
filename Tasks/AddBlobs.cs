using System;
using System.Threading.Tasks;
using Atea.Interfaces;
using Microsoft.WindowsAzure.Storage;

namespace Atea.Models
{
    public class AddBlobs : IAddBlobs
    {
        public async Task Add(string importedData)
        {
            var cloudAccount = CloudStorageAccount.Parse(
                Environment.GetEnvironmentVariable("AzureWebJobsStorage"));

            var blobClient = cloudAccount.CreateCloudBlobClient();

            var blobName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm");

            var container = blobClient.GetContainerReference("imported-data");

            await container.CreateIfNotExistsAsync();

            var blob = container.GetBlockBlobReference(blobName);
            await blob.UploadTextAsync(importedData);
        }
    }
}
