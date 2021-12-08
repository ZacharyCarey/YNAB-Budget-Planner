using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YnabRestApi.Utils {
    public enum ClearedStatus {

        [Description("cleared")]
        cleared, 

        [Description("uncleared")]
        Uncleared,
        
        [Description("Reconciled")]
        Reconciled

    }

    public static class ClearedStatusExtensions {
        private static IDictionary<string, ClearedStatus> enumValues = EnumExtensions.GetValues<ClearedStatus>();

        public static ClearedStatus Parse(string name) {
            return enumValues[name];
        }

    }
}
