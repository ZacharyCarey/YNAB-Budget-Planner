using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YnabRestApi.Utils {
    public enum FlagColor {

        [Description("red")]
        Red, 

        [Description("orange")]
        Orange, 

        [Description("yellow")]
        Yellow, 

        [Description("green")]
        Green, 

        [Description("blue")]
        Blue, 

        [Description("purple")]
        Purple

    }

    public static class FlagColorExtensions {
        private static IDictionary<string, FlagColor> enumValues = EnumExtensions.GetValues<FlagColor>();

        public static FlagColor Parse(string name) {
            return enumValues[name];
        }

    }

}
