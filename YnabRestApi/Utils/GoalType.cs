using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YnabRestApi.Utils {
    public enum GoalType {

        [Description("TB")]
        TargetCategoryBalance,

        [Description("TBD")]
        TargetCategoryBalanceByDate,

        [Description("MF")]
        MonthlyFunding,

        [Description("NEED")]
        PlanYourSpending
    }

    public static class GoalTypeExtensions {
        private static IDictionary<string, GoalType> enumValues = EnumExtensions.GetValues<GoalType>();

        public static GoalType Parse(string name) {
            return enumValues[name];
        }

    }

}
