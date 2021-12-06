using System.Text.Json;
using System.Text.Json.Serialization;

namespace YnabRestApi.ResponseData {
    public class Subtransaction {

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("transaction_id")]
        public string? TransactionId { get; set; }

        [JsonPropertyName("amount")]
        public int? Amount { get; set; }

        [JsonPropertyName("memo")]
        public string? Memo { get; set; }

        [JsonPropertyName("payee_id")]
        public string? PayeeId { get; set; }

        [JsonPropertyName("payee_name")]
        public string? PayeeName { get; set; }

        [JsonPropertyName("category_id")]
        public string? CategoryId { get; set; }

        [JsonPropertyName("category_name")]
        public string? CategoryName { get; set; }

        [JsonPropertyName("transfer_account_id")]
        public string? TransferAccountId { get; set; }

        [JsonPropertyName("transfer_transaction_id")]
        public string? TransferTransactionId { get; set; }

        [JsonPropertyName("deleted")]
        public bool? Deleted { get; set; }

        public override string ToString() {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
        }

        /* JSON
"id": "string",
"transaction_id": "string",
"amount": 0,
"memo": "string",
"payee_id": "string",
"payee_name": "string",
"category_id": "string",
"category_name": "string",
"transfer_account_id": "string",
"transfer_transaction_id": "string",
"deleted": true
         */
    }
}