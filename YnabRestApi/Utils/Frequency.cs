using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YnabRestApi.Utils {
    public enum Frequency {

        [Description("never")]
        Never,

        [Description("daily")]
        Daily,

        [Description("weekly")]
        Weekly,

        [Description("everyOtherWeek")]
        EveryOtherWeek,

        [Description("twiceAMonth")]
        TwiceAMonth,

        [Description("every4Weeks")]
        Every4Weeks,

        [Description("monthly")]
        Monthly,

        [Description("everyOtherMonth")]
        EveryOtherMonth,

        [Description("every3Months")]
        Every3Months,

        [Description("every4Months")]
        Every4Months,

        [Description("twiceAYear")]
        TwiceAYear,

        [Description("yearly")]
        Yearly,

        [Description("everyOtherYear")]
        EveryOtherYear

    }

    public static class FrequencyExtensions {
        private static IDictionary<string, Frequency> enumValues = EnumExtensions.GetValues<Frequency>();

        public static Frequency Parse(string name) {
            return enumValues[name];
        }

    }
}
