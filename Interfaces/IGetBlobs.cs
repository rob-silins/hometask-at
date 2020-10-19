using System.Threading.Tasks;

namespace Atea.Interfaces
{
    public interface IGetBlobs
    {
        public   Task<string> GetBlob(string name);
    }
}
