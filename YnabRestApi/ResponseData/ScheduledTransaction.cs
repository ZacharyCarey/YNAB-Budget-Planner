using System.Text.Json;
using System.Text.Json.Serialization;

namespace YnabRestApi.ResponseData {
    public class ScheduledTransaction {

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("date_first")]
        public string? DateFirst { get; set; }

        [JsonPropertyName("date_next")]
        public string? DateNext { get; set; }

        [JsonPropertyName("frequency")]
        public string? Frequency { get; set; }

        [JsonPropertyName("amount")]
        public int? Amount { get; set; }

        [JsonPropertyName("memo")]
        public string? Memo { get; set; }

        [JsonPropertyName("flag_color")]
        public string? FlagColor { get; set; }

        [JsonPropertyName("account_id")]
        public string? AccountId { get; set; }

        [JsonPropertyName("payee_id")]
        public string? PayeeId { get; set; }
        
        [JsonPropertyName("category_id")]
        public string? CategoryId { get; set; }

        [JsonPropertyName("transfer_account_id")]
        public string? TransferAccountId { get; set; }

        [JsonPropertyName("deleted")]
        public bool? Deleted { get; set; }

        public override string ToString() {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
        }

        /* JSON
"id": "string",
"date_first": "string",
"date_next": "string",
"frequency": "never",
"amount": 0,
"memo": "string",
"flag_color": "red",
"account_id": "string",
"payee_id": "string",
"category_id": "string",
"transfer_account_id": "string",
"deleted": true
         */

    }
}