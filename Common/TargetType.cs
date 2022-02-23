using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
    public enum TargetType {

        [Description("Needed For Spending")]
        NeededForSpending,

        [Description("Savings Balance")]
        SavingsBalance,

        [Description("Monthly Savings Builder")]
        MonthlySavingsBuilder,

        [Description("Monthly Debt Payment")]
        MonthlyDebtPayment

    }
}
