using Common.MoneyUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YnabRestApi.ResponseData;
using YnabRestApi.Utils;

namespace Desktop_Budget_Planner.Utils {
    public class ParsedCategory {

        public readonly Money Budgeted;
        public readonly Money Activity;
        public readonly Money Balance;
        public readonly GoalType? GoalType;
        public readonly Money? GoalTarget;
        public readonly Money? GoalUnderFunded;
        public readonly Money? GoalOverallFunded;
        public readonly Money? GoalOverallLeft;

        public ParsedCategory(Category ynab) {
            Budgeted = Money.FromLong(ynab.Budgeted / 10);
            Activity = Money.FromLong(ynab.Activity / 10);
            Balance = Money.FromLong(ynab.Balance / 10);

            this.GoalType = (ynab.GoalType == null) ? null : GoalTypeExtensions.Parse(ynab.GoalType);
            GoalTarget = (ynab.GoalTarget == null) ? null : Money.FromLong((long)ynab.GoalTarget / 10);
            GoalUnderFunded = (ynab.GoalUnderFunded == null) ? null : Money.FromLong((long)ynab.GoalUnderFunded / 10);
            GoalOverallFunded = (ynab.GoalOverallFunded == null) ? null : Money.FromLong((long)ynab.GoalOverallFunded);
            GoalOverallLeft = (ynab.GoalOverallLeft == null) ? null : Money.FromLong((long)ynab.GoalOverallLeft);
        }

    }
}
