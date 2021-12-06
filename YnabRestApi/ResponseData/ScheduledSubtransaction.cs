using System.Text.Json;
using System.Text.Json.Serialization;

namespace YnabRestApi.ResponseData {
    public class ScheduledSubtransaction {

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("scheduled_transaction_id")]
        public string? ScheduledTransactionId { get; set; }

        [JsonPropertyName("amount")]
        public int? Amount { get; set; }

        [JsonPropertyName("memo")]
        public string? Memo { get; set; }

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
"scheduled_transaction_id": "string",
"amount": 0,
"memo": "string",
"payee_id": "string",
"category_id": "string",
"transfer_account_id": "string",
"deleted": true
         */

    }
}