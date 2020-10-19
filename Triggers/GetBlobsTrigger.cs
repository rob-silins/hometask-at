using System.Threading.Tasks;
using Atea.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Atea
{
    public class GetBlobsTrigger
    {
        public readonly IGetBlobs _get;

        public GetBlobsTrigger(IGetBlobs get)
        {
            _get = get;
        }

        [FunctionName("GetBlob")]
        public  async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
        {
            string date = req.Query["blob"];

            if (string.IsNullOrEmpty(date))
                return new BadRequestObjectResult("Please enter a search request.");

            if (date.Length != 16)
                return new BadRequestObjectResult(
                    "Please enter a valid search request format\n" + "YYYY-MM-DD-HH-MM .");

            var search =_get.GetBlob(date);

            if (!search.IsCompletedSuccessfully)
                return new BadRequestObjectResult(
                    "Selected entry does not exist.");

            return new OkObjectResult(search);
        }
    }
}
