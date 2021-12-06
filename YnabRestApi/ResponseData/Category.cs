using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class Category {

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("category_group_id")]
        public string? CategoryGroupId { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("hidden")]
        public bool? Hidden { get; set; }

        [JsonPropertyName("original_category_group_id")]
        public string? OriginalCategoryGroupId { get; set; }

        [JsonPropertyName("note")]
        public string? Note { get; set; }

        [JsonPropertyName("budgeted")]
        public int? Budgeted { get; set; }

        [JsonPropertyName("activity")]
        public int? Activity { get; set; }

        [JsonPropertyName("balance")]
        public int? Balance { get; set; }

        [JsonPropertyName("goal_type")]
        public string? GoalType { get; set; }

        [JsonPropertyName("goal_creation_month")]
        public string? GoalCreationMonth { get; set; }

        [JsonPropertyName("goal_target")]
        public int? GoalTarget { get; set; }

        [JsonPropertyName("goal_target_month")]
        public string? GoalTargetMonth { get; set; }

        [JsonPropertyName("goal_percentage_complete")]
        public int? GoalPercentageComplete { get; set; }

        [JsonPropertyName("goal_months_to_budget")]
        public int? GoalMonthsToBudget { get; set; }

        [JsonPropertyName("goal_under_funded")]
        public int? GoalUnderFunded { get; set; }

        [JsonPropertyName("goal_overall_funded")]
        public int? GoalOverallFunded { get; set; }

        [JsonPropertyName("goal_overall_left")]
        public int? GoalOverallLeft { get; set; }

        [JsonPropertyName("deleted")]
        public bool? Deleted { get; set; }

        public override string ToString() {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
        }

        /*
"id": "string",
"category_group_id": "string",
"name": "string",
"hidden": true,
"original_category_group_id": "string",
"note": "string",
"budgeted": 0,
"activity": 0,
"balance": 0,
"goal_type": "TB",
"goal_creation_month": "string",
"goal_target": 0,
"goal_target_month": "string",
"goal_percentage_complete": 0,
"goal_months_to_budget": 0,
"goal_under_funded": 0,
"goal_overall_funded": 0,
"goal_overall_left": 0,
"deleted": true
*/
    }
}
