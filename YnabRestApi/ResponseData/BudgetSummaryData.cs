using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class BudgetSummaryData {

        [JsonPropertyName("budgets")]
        public IList<BudgetSummary> Budgets { get; set; } = new List<BudgetSummary>();

        [JsonPropertyName("default_budget")]
        public BudgetSummary? DefaultBudget { get; set; }

    }

    /*
budgets*	[BudgetSummary]
default_budget	BudgetSummary{...}
     */
}
