using System.Text.Json;
using System.Text.Json.Serialization;

namespace YnabRestApi.ResponseData {
    public class Transaction {

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("date")]
        public string? Date { get; set; }

        [JsonPropertyName("amount")]
        public int? Amount { get; set; }

        [JsonPropertyName("memo")]
        public string? Memo { get; set; }

        [JsonPropertyName("cleared")]
        public string? Cleared { get; set; }

        [JsonPropertyName("approved")]
        public bool? Approved { get; set; }

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

        [JsonPropertyName("transfer_transaction_id")]
        public string? TransferTransactionId { get; set; }

        [JsonPropertyName("matched_transaction_id")]
        public string? MatchedTransactionId { get; set; }

        [JsonPropertyName("import_id")]
        public string? ImportId { get; set; }

        [JsonPropertyName("deleted")]
        public bool? Deleted { get; set; }

        public override string ToString() {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
        }

        /* JSON
"id": "string",
"date": "string",
"amount": 0,
"memo": "string",
"cleared": "cleared",
"approved": true,
"flag_color": "red",
"account_id": "string",
"payee_id": "string",
"category_id": "string",
"transfer_account_id": "string",
"transfer_transaction_id": "string",
"matched_transaction_id": "string",
"import_id": "string",
"deleted": true
         */
    }
}