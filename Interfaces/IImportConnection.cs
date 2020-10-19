using System.Threading.Tasks;

namespace Atea.Interfaces
{
    public interface IImportConnection
    {
        public Task<string> DataImport();
    }
}
