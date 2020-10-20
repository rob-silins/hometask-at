using System.Threading.Tasks;
using Atea.Interfaces;
using Atea.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Atea
{
    public class GetTableDataTrigger: TableData
    {
        public readonly ISelectTableData _select;

        public GetTableDataTrigger(ISelectTableData select)
        {
            _select = select;
        }

        [FunctionName("TableEntries")]
        public  async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]
            HttpRequest req)
        {
            string date = req.Query["date"];

            if (string.IsNullOrEmpty(date) )
                return new BadRequestObjectResult("Please enter a valid search range.");

            if (date.Length != 33)
                return new BadRequestObjectResult(
                    "Please enter a valid search range format\n"+ "YYYY-MM-DD-HH-MM-YYYY-MM-DD-HH-MM .");

            var from = date.Substring(0,16);
            var to = date.Substring(17);

            var search = await _select.TableData(from, to);

            if (search  == null)
                return new BadRequestObjectResult("No data found.");

            return new OkObjectResult(search);
        }
    }
}
