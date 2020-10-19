using System.Threading.Tasks;

namespace Atea.Interfaces
{
    public interface IAddBlobs
    {
        public Task Add(string importedData);
    }
}
