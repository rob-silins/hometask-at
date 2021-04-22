using System;
using System.Globalization;
using Atea.Interfaces;
using Microsoft.WindowsAzure.Storage.Table;

namespace Atea.Models
{
    public class SelectTableDataComponents :TableData, ISelectTableDataComponents
    {
        public DateTime? ConvertToDateTime(string date)
        {
            if (!DateTime.TryParseExact(date, "yyyy-MM-dd-HH-mm",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out var newDate))
            {
                return null;
            }
            return newDate;
        }
    }
}
