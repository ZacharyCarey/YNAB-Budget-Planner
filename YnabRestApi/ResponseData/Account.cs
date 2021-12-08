using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class Account {

        [JsonPropertyName("id")]
        public string Id { get; set; } = "";

        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        /// <summary>
        /// Enum, see <see cref="Utils.AccountType"/>
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; } = "";

        /// <summary>
        /// Whether this account is on budget or not
        /// </summary>
        [JsonPropertyName("on_budget")]
        public bool OnBudget { get; set; } = false;

        /// <summary>
        /// Whether this account is closed or not
        /// </summary>
        [JsonPropertyName("closed")]
        public bool Closed { get; set; } = false;

        [JsonPropertyName("note")]
        public string? Note { get; set; }

        /// <summary>
        /// The current balance of the account in milliunits format
        /// See <see cref="Utils.YnabMoney"/>
        /// </summary>
        [JsonPropertyName("balance")]
        public Int64 Balance { get; set; }

        /// <summary>
        /// The current cleared balance of the account in milliunits format
        /// See <see cref="Utils.YnabMoney"/>
        /// </summary>
        [JsonPropertyName("cleared_balance")]
        public Int64 ClearedBalance { get; set; }

        /// <summary>
        /// The current uncleared balance of the account in milliunits format
        /// See <see cref="Utils.YnabMoney"/>
        /// </summary>
        [JsonPropertyName("uncleared_balance")]
        public Int64 UnclearedBalance { get; set; }

        /// <summary>
        /// The payee id which should be used when transferring to this account
        /// $uuid
        /// </summary>
        [JsonPropertyName("transfer_payee_id")]
        public string TransferPayeeId { get; set; } = "";

        /// <summary>
        /// Whether or not the account is linked to a financial institution for automatic transaction import.
        /// </summary>
        [JsonPropertyName("direct_import_linked")]
        public bool? DirectImportLinked { get; set; }

        /// <summary>
        /// If an account linked to a financial institution (direct_import_linked=true) and the linked connection is not in a healthy state, this will be true.
        /// </summary>
        [JsonPropertyName("direct_import_in_error")]
        public bool? DirectImportInError { get; set; }

        /// <summary>
        /// Whether or not the account has been deleted. Deleted accounts will only be included in delta requests.
        /// </summary>
        [JsonPropertyName("deleted")]
        public bool Deleted { get; set; } = false;


        public override string ToString() {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
        }
    }

    /*
id*	string($uuid)
name*	string
type*	string
The type of account. Note: payPal, merchantAccount, investmentAccount, and mortgage types have been deprecated and will be removed in the future.

Enum:
Array [ checking, savings, cash, creditCard, lineOfCredit, otherAsset, otherLiability, payPal, merchantAccount, investmentAccount, mortgage ]
on_budget*	boolean
Whether this account is on budget or not

closed*	boolean
Whether this account is closed or not

note	string
balance*	integer($int64)
The current balance of the account in milliunits format

cleared_balance*	integer($int64)
The current cleared balance of the account in milliunits format

uncleared_balance*	integer($int64)
The current uncleared balance of the account in milliunits format

transfer_payee_id*	string($uuid)
The payee id which should be used when transferring to this account

direct_import_linked	boolean
Whether or not the account is linked to a financial institution for automatic transaction import.

direct_import_in_error	boolean
If an account linked to a financial institution (direct_import_linked=true) and the linked connection is not in a healthy state, this will be true.

deleted*	boolean
Whether or not the account has been deleted. Deleted accounts will only be included in delta requests.
     */
}
