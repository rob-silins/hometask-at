using Microsoft.WindowsAzure.Storage.Table;

namespace Atea.Models
{
    public class TableData : TableEntity
    {
        public bool Success { get; set; }
        public string Id { get; set; }

        public TableData(string partitionKey, string rowKey)
        {
            PartitionKey = partitionKey;
            RowKey = rowKey;
        }

        public TableData()
        {

        }
    }
}
