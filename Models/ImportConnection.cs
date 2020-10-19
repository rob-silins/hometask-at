using System.IO;
using System.Net;
using System.Threading.Tasks;
using Atea.Interfaces;

namespace Atea.Models
{
    public class ImportConnection : IImportConnection
    {
        public async Task<string> DataImport()
        {
            var sourceUrl = "https://api.publicapis.org/random?auth=null";
            var request = WebRequest.Create(sourceUrl);
            var response = await request.GetResponseAsync();
            var reader = new StreamReader(response.GetResponseStream());
            var importedData = await reader.ReadToEndAsync();

            return importedData;
        }
    }
}
