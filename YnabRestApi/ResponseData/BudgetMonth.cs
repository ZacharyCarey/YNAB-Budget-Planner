using System.Text.Json;
using System.Text.Json.Serialization;

namespace YnabRestApi.ResponseData {
    public class BudgetMonth {

        [JsonPropertyName("month")]
        public string? Month { get; set; }

        [JsonPropertyName("note")]
        public string? Note { get; set; }

        [JsonPropertyName("income")]
        public int? Income { get; set; }

        [JsonPropertyName("budgeted")]
        public int? Budgeted { get; set; }

        [JsonPropertyName("activity")]
        public int? Activity { get; set; }

        [JsonPropertyName("to_be_budgeted")]
        public int? ToBeBudgeted { get; set; }

        [JsonPropertyName("age_of_money")]
        public int? AgeOfMoney { get; set; }

        [JsonPropertyName("deleted")]
        public bool? Deleted { get; set; }

        [JsonPropertyName("categories")]
        public IList<Category>? Categories { get; set; }

        public override string ToString() {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
        }

        /* JSON
"month": "string",
"note": "string",
"income": 0,
"budgeted": 0,
"activity": 0,
"to_be_budgeted": 0,
"age_of_money": 0,
"deleted": true,
"categories": [
    {
        ...
    }
]
         */
    }
}