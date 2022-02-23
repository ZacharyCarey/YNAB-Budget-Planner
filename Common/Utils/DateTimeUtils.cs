using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils {
    public static class DateTimeUtils {

        public static int MonthsSince(this DateTime endDate, DateTime startDate) {
            return ((endDate.Year - startDate.Year) * 12) + endDate.Month - startDate.Month;
        }

        public static DateTime ParseDateOrDefault(string? parse, DateTime defaultValue = default(DateTime)) {
            DateTime result;
            if(!DateTime.TryParse(parse, out result)) {
                result = defaultValue;
            }
            return result;
        }

    }
}
