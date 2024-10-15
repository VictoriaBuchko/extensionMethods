using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace extensionMethods
{
    public class DailyTemperature
    {
        public decimal High { get; }
        public decimal Low { get; }

        public DailyTemperature(decimal high, decimal low)
        {
            High = high;
            Low = low;
        }

        public decimal GetTemperatureDifference()
        {
            return High - Low;
        }

        public static int GetMaxDifference(DailyTemperature[] temperatures)
        {
            return temperatures
                .Select((temp, index) => new { Index = index, Difference = temp.GetTemperatureDifference() })
                .OrderByDescending(x => x.Difference)
                .FirstOrDefault()?.Index ?? -1;
        }
    }
}
