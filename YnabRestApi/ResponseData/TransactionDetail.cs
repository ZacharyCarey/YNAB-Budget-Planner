using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class TransactionDetail {

        [JsonPropertyName("id")]
        public string Id { get; set; } = "";

        /// <summary>
        /// The transaction date in ISO format(e.g. 2016-12-01)
        /// $date
        /// </summary>
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// The transaction amount in milliunits format
        /// See <see cref="Utils.YnabMoney"/>
        /// </summary>
        [JsonPropertyName("amount")]
        public Int64 Amount { get; set; }

        [JsonPropertyName("memo")]
        public string? Memo { get; set; }

        /// <summary>
        /// The cleared status of the transaction
        /// See <see cref="Utils.ClearedStatus"/>
        /// </summary>
        [JsonPropertyName("cleared")]
        public string Cleared { get; set; } = "";

        /// <summary>
        /// Whether or not the transaction is approved
        /// </summary>
        [JsonPropertyName("approved")]
        public bool Approved { get; set; }

        /// <summary>
        /// The transaction flag
        /// See <see cref="Utils.FlagColor"/>
        /// </summary>
        [JsonPropertyName("flag_color")]
        public string? FlagColor { get; set; }

        /// <summary>
        /// $uuid
        /// </summary>
        [JsonPropertyName("account_id")]
        public string AccountId { get; set; } = "";

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
        /// If a transfer transaction, the account to which it transfers
        /// $uuid
        /// </summary>
        [JsonPropertyName("transfer_account_id")]
        public string? TransferAccountId { get; set; }


        /// <summary>
        /// If a transfer transaction, the id of transaction on the other side of the transfer
        /// </summary>
        [JsonPropertyName("transfer_transaction_id")]
        public string? TransferTransactionId { get; set; }

        /// <summary>
        /// If transaction is matched, the id of the matched transaction
        /// </summary>
        [JsonPropertyName("matched_transaction_id")]
        public string? MatchedTransactionId { get; set; }

        /// <summary>
        /// If the Transaction was imported, this field is a unique(by account) import identifier.If this transaction was imported through File Based Import or Direct Import and not through the API, the import_id will have the format: 'YNAB:[milliunit_amount]:[iso_date]:[occurrence]'. For example, a transaction dated 2015-12-30 in the amount of -$294.23 USD would have an import_id of 'YNAB:-294230:2015-12-30:1’. If a second transaction on the same account was imported and had the same date and same amount, its import_id would be 'YNAB:-294230:2015-12-30:2’.

        /// </summary>
        [JsonPropertyName("import_id")]
        public string? ImportId { get; set; }

        /// <summary>
        /// Whether or not the transaction has been deleted. Deleted transactions will only be included in delta requests.
        /// </summary>
        [JsonPropertyName("deleted")]
        public bool Deleted { get; set; }

        [JsonPropertyName("account_name")]
        public string AccountName { get; set; } = "";

        [JsonPropertyName("payee_name")]
        public string? PayeeName { get; set; }

        [JsonPropertyName("category_name")]
        public string? CategoryName { get; set; }

        /// <summary>
        /// If a split transaction, the subtransactions.
        /// </summary>
        [JsonPropertyName("subtransaction")]
        public IList<SubTransaction> Subtransactions { get; set; } = new List<SubTransaction>();

    }

    /*
id*	string
date*	string($date)
The transaction date in ISO format (e.g. 2016-12-01)

amount*	integer($int64)
The transaction amount in milliunits format

memo	string
cleared*	string
The cleared status of the transaction

Enum:
[ cleared, uncleared, reconciled ]
approved*	boolean
Whether or not the transaction is approved

flag_color	string
The transaction flag

Enum:
[ red, orange, yellow, green, blue, purple, ]
account_id*	string($uuid)
payee_id	string($uuid)
category_id	string($uuid)
transfer_account_id	string($uuid)
If a transfer transaction, the account to which it transfers

transfer_transaction_id	string
If a transfer transaction, the id of transaction on the other side of the transfer

matched_transaction_id	string
If transaction is matched, the id of the matched transaction

import_id	string
If the Transaction was imported, this field is a unique (by account) import identifier. If this transaction was imported through File Based Import or Direct Import and not through the API, the import_id will have the format: 'YNAB:[milliunit_amount]:[iso_date]:[occurrence]'. For example, a transaction dated 2015-12-30 in the amount of -$294.23 USD would have an import_id of 'YNAB:-294230:2015-12-30:1’. If a second transaction on the same account was imported and had the same date and same amount, its import_id would be 'YNAB:-294230:2015-12-30:2’.

deleted*	boolean
Whether or not the transaction has been deleted. Deleted transactions will only be included in delta requests.

account_name*	string
payee_name	string
category_name	string
subtransactions*	[
If a split transaction, the subtransactions.

SubTransaction{...}]
     */
}
