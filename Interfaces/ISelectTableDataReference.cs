using Microsoft.WindowsAzure.Storage.Table;

namespace Atea.Interfaces
{
    public interface ISelectTableDataReference
    {
        public CloudTable Reference();
    }
}
