using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class SubTransaction {

        [JsonPropertyName("id")]
        public string Id { get; set; } = "";

        [JsonPropertyName("transaction_id")]
        public string TransactionId { get; set; } = "";

        /// <summary>
        /// The subtransaction amount in milliunits format
        /// See <see cref="Utils.YnabMoney"/>
        /// </summary>
        [JsonPropertyName("amount")]
        public Int64 Amount { get; set; }

        [JsonPropertyName("memo")]
        public string? Memo { get; set; }

        /// <summary>
        /// $uuid
        /// </summary>
        [JsonPropertyName("payee_id")]
        public string? PayeeId { get; set; }

        [JsonPropertyName("payee_name")]
        public string? PayeeName { get; set; }

        /// <summary>
        /// $uuid
        /// </summary>
        [JsonPropertyName("category_id")]
        public string? CategoryId { get; set; }

        [JsonPropertyName("category_name")]
        public string? CategoryName { get; set; }

        /// <summary>
        /// If a transfer, the account_id which the subtransaction transfers to
        /// $uuid
        /// </summary>
        [JsonPropertyName("transfer_account_id")]
        public string? TransferAccountId { get; set; }

        /// <summary>
        /// If a transfer, the id of transaction on the other side of the transfer
        /// </summary>
        [JsonPropertyName("transfer_transaction_id")]
        public string? TransferTransactionId { get; set; }

        /// <summary>
        /// Whether or not the subtransaction has been deleted.Deleted subtransactions will only be included in delta requests.
        /// </summary>
        [JsonPropertyName("deleted")]
        public bool Deleted { get; set; }

    }

    /*
id*	string
transaction_id*	string
amount*	integer($int64)
The subtransaction amount in milliunits format

memo	string
payee_id	string($uuid)
payee_name	string
category_id	string($uuid)
category_name	string
transfer_account_id	string($uuid)
If a transfer, the account_id which the subtransaction transfers to

transfer_transaction_id	string
If a transfer, the id of transaction on the other side of the transfer

deleted*	boolean
Whether or not the subtransaction has been deleted. Deleted subtransactions will only be included in delta requests.
     */
}
