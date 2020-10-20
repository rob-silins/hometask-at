using System;

namespace Atea.Interfaces
{
    public interface ISelectTableDataComponents
    {
        public DateTime? ConvertToDateTime(string date);
        public string FilteredDates(DateTime? startRange, DateTime? endRange);

    }
}
