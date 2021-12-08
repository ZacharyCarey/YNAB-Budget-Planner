using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class SaveTransaction {

        /// <summary>
        /// $uuid
        /// </summary>
        [JsonPropertyName("account_id")]
        public string AccountId { get; set; } = "";

        /// <summary>
        /// $date
        /// The transaction date in ISO format(e.g. 2016-12-01). Future dates(scheduled transactions) are not permitted.Split transaction dates cannot be changed and if a different date is supplied it will be ignored.
        /// </summary>
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// The transaction amount in milliunits format.Split transaction amounts cannot be changed and if a different amount is supplied it will be ignored.
        /// </summary>
        [JsonPropertyName("amount")]
        public Int64 Amount { get; set; }

        /// <summary>
        /// The payee for the transaction.To create a transfer between two accounts, use the account transfer payee pointing to the target account. Account transfer payees are specified as tranfer_payee_id on the account resource.
        /// </summary>
        [JsonPropertyName("payee_id")]
        public string? PayeeId { get; set; }

        /// <summary>
        /// Max Length: 50
        /// The payee name.If a payee_name value is provided and payee_id has a null value, the payee_name value will be used to resolve the payee by either (1) a matching payee rename rule(only if import_id is also specified) or(2) a payee with the same name or(3) creation of a new payee.
        /// </summary>
        [JsonPropertyName("payee_name")]
        public string? PayneeName { get; set; }

        /// <summary>
        /// The category for the transaction.To configure a split transaction, you can specify null for category_id and provide a subtransactions array as part of the transaction object. If an existing transaction is a split, the category_id cannot be changed.Credit Card Payment categories are not permitted and will be ignored if supplied.
        /// </summary>
        [JsonPropertyName("category_id")]
        public string? CategoryId { get; set; }

        /// <summary>
        /// Max Length: 200
        /// </summary>
        [JsonPropertyName("memo")]
        public string? Memo { get; set; }

        /// <summary>
        /// The cleared status of the transaction
        /// See <see cref="Utils.ClearedStatus"/>
        /// </summary>
        [JsonPropertyName("cleared")]
        public string? Cleared { get; set; }

        /// <summary>
        /// Whether or not the transaction is approved.If not supplied, transaction will be unapproved by default.
        /// </summary>
        [JsonPropertyName("approved")]
        public bool? Approved { get; set; }

        /// <summary>
        /// The transaction flag
        /// See <see cref="Utils.FlagColor"/>
        /// </summary>
        [JsonPropertyName("flag_color")]
        public string? FlagColor { get; set; }

        /// <summary>
        /// If specified, the new transaction will be assigned this import_id and considered "imported". We will also attempt to match this imported transaction to an existing “user-entered” transation on the same account, with the same amount, and with a date +/-10 days from the imported transaction date.
        ///Transactions imported through File Based Import or Direct Import(not through the API) are assigned an import_id in the format: 'YNAB:[milliunit_amount]:[iso_date]:[occurrence]'. For example, a transaction dated 2015-12-30 in the amount of -$294.23 USD would have an import_id of 'YNAB:-294230:2015-12-30:1’. If a second transaction on the same account was imported and had the same date and same amount, its import_id would be 'YNAB:-294230:2015-12-30:2’. Using a consistent format will prevent duplicates through Direct Import and File Based Import.
        ///If import_id is omitted or specified as null, the transaction will be treated as a “user-entered” transaction.As such, it will be eligible to be matched against transactions later being imported (via DI, FBI, or API).
        /// Max Length: 36
        /// </summary>
        [JsonPropertyName("import_id")]
        public string? ImportId { get; set; }

        /// <summary>
        /// An array of subtransactions to configure a transaction as a split.Updating subtransactions on an existing split transaction is not supported.
        /// </summary>
        [JsonPropertyName("subtransactions")]
        public IList<SaveSubTransaction>? Subtransactions { get; set; }


        public override string ToString() {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
        }

    }

    /*
account_id*	string($uuid)
date*	string($date)
The transaction date in ISO format (e.g. 2016-12-01). Future dates (scheduled transactions) are not permitted. Split transaction dates cannot be changed and if a different date is supplied it will be ignored.

amount*	integer($int64)
The transaction amount in milliunits format. Split transaction amounts cannot be changed and if a different amount is supplied it will be ignored.

payee_id	string($uuid)
The payee for the transaction. To create a transfer between two accounts, use the account transfer payee pointing to the target account. Account transfer payees are specified as tranfer_payee_id on the account resource.

payee_name	string
maxLength: 50
The payee name. If a payee_name value is provided and payee_id has a null value, the payee_name value will be used to resolve the payee by either (1) a matching payee rename rule (only if import_id is also specified) or (2) a payee with the same name or (3) creation of a new payee.

category_id	string($uuid)
The category for the transaction. To configure a split transaction, you can specify null for category_id and provide a subtransactions array as part of the transaction object. If an existing transaction is a split, the category_id cannot be changed. Credit Card Payment categories are not permitted and will be ignored if supplied.

memo	string
maxLength: 200
cleared	string
The cleared status of the transaction

Enum:
[ cleared, uncleared, reconciled ]
approved	boolean
Whether or not the transaction is approved. If not supplied, transaction will be unapproved by default.

flag_color	string
The transaction flag

Enum:
[ red, orange, yellow, green, blue, purple, ]
import_id	string
maxLength: 36
If specified, the new transaction will be assigned this import_id and considered "imported". We will also attempt to match this imported transaction to an existing “user-entered” transation on the same account, with the same amount, and with a date +/-10 days from the imported transaction date.

Transactions imported through File Based Import or Direct Import (not through the API) are assigned an import_id in the format: 'YNAB:[milliunit_amount]:[iso_date]:[occurrence]'. For example, a transaction dated 2015-12-30 in the amount of -$294.23 USD would have an import_id of 'YNAB:-294230:2015-12-30:1’. If a second transaction on the same account was imported and had the same date and same amount, its import_id would be 'YNAB:-294230:2015-12-30:2’. Using a consistent format will prevent duplicates through Direct Import and File Based Import.

If import_id is omitted or specified as null, the transaction will be treated as a “user-entered” transaction. As such, it will be eligible to be matched against transactions later being imported (via DI, FBI, or API).

subtransactions	[
An array of subtransactions to configure a transaction as a split. Updating subtransactions on an existing split transaction is not supported.

SaveSubTransaction{...}]
     */
}
