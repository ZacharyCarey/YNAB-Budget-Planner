using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class ScheduledSubTransaction {

        /// <summary>
        /// $uuid
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = "";

        /// <summary>
        /// $uuid
        /// </summary>
        [JsonPropertyName("scheduled_transaction_id")]
        public string ScheduledTransactionId { get; set; } = "";

        /// <summary>
        /// The scheduled subtransaction amount in milliunits format
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

        /// <summary>
        /// $uuid
        /// </summary>
        [JsonPropertyName("category_id")]
        public string? CategoryId { get; set; }

        /// <summary>
        /// If a transfer, the account_id which the scheduled subtransaction transfers to
        /// $uuid
        /// </summary>
        [JsonPropertyName("transfer_account_id")]
        public string? TransferAccountId { get; set; }

        /// <summary>
        /// Whether or not the scheduled subtransaction has been deleted. Deleted scheduled subtransactions will only be included in delta requests.
        /// </summary>
        [JsonPropertyName("deleted")]
        public bool Deleted { get; set; }

    }

    /*
id*	string($uuid)
scheduled_transaction_id*	string($uuid)
amount*	integer($int64)
The scheduled subtransaction amount in milliunits format

memo	string
payee_id	string($uuid)
category_id	string($uuid)
transfer_account_id	string($uuid)
If a transfer, the account_id which the scheduled subtransaction transfers to

deleted*	boolean
Whether or not the scheduled subtransaction has been deleted. Deleted scheduled subtransactions will only be included in delta requests.
     */
}
