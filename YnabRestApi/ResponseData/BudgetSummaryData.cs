using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class BudgetSummaryData {

        [JsonPropertyName("budgets")]
        public IList<BudgetSummary> Budgets { get; set; } = new List<BudgetSummary>();

        [JsonPropertyName("default_budget")]
        public BudgetSummary? DefaultBudget { get; set; }


        public override string ToString() {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
        }

    }

    /*
budgets*	[BudgetSummary]
default_budget	BudgetSummary{...}
     */
}
