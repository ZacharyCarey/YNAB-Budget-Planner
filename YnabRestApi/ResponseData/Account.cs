using System.Text.Json;
using System.Text.Json.Serialization;

namespace YnabRestApi.ResponseData {
    public class Account {

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("on_budget")]
        public bool? OnBudget { get; set; }

        [JsonPropertyName("closed")]
        public bool? Closed { get; set; }

        [JsonPropertyName("note")]
        public string? Note { get; set; }

        [JsonPropertyName("balance")]
        public int? Balance { get; set; }

        [JsonPropertyName("cleared_balance")]
        public int? ClearedBalance { get; set; }

        [JsonPropertyName("uncleared_balance")]
        public int? UnclearedBalance { get; set; }

        [JsonPropertyName("transfer_payee_id")]
        public string? TransferPayeeId { get; set; }

        [JsonPropertyName("direct_import_linked")]
        public bool? DirectImportLinked { get; set; }

        [JsonPropertyName("direct_import_in_error")]
        public bool? DirectImportInError { get; set; }

        [JsonPropertyName("deleted")]
        public bool? Deleted { get; set; }

        public override string ToString() {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
        }

        /* JSON
"id": "string",
"name": "string",
"type": "checking",
"on_budget": true,
"closed": true,
"note": "string",
"balance": 0,
"cleared_balance": 0,
"uncleared_balance": 0,
"transfer_payee_id": "string",
"direct_import_linked": true,
"direct_import_in_error": true,
"deleted": true
         */
    }
}