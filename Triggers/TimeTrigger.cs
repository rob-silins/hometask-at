using System.Threading.Tasks;
using Atea.Interfaces;
using Microsoft.Azure.WebJobs;

namespace Atea
{
    public class TimeTrigger
    {
        public readonly IAddTableData _tabledata;
        public readonly IAddBlobs _blobs;
        public readonly IImportConnection _connection;

        public TimeTrigger( IAddTableData addTableData, IAddBlobs addBlobs, IImportConnection connection)
        {
            _tabledata = addTableData;
            _blobs = addBlobs;
            _connection = connection;
        }

        [FunctionName("FetchData")]

        public async Task RunTimer([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer, ExecutionContext ec)
        {
            var importedData = _connection.DataImport();
            var success = myTimer.Schedule != null;
            await _blobs.Add(await importedData);
            await _tabledata.Add(ec, success);
        }
    }
}