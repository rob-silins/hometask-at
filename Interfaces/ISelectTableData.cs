using System.Collections.Generic;
using System.Threading.Tasks;
using Atea.Models;

namespace Atea.Interfaces
{
    public interface ISelectTableData
    {
        public   Task<List<TableData>> TableData(string from, string to);
    }
}
