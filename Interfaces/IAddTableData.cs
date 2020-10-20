using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace Atea.Interfaces
{
    public interface IAddTableData
    {
        Task Add(ExecutionContext ec, bool success);
    }
}
