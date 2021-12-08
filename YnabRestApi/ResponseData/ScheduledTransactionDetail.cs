using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class ScheduledTransactionDetail {

        /// <summary>
        /// $uuid
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = "";

        /// <summary>
        /// The first date for which the Scheduled Transaction was scheduled.
        /// $date
        /// </summary>
        [JsonPropertyName("date_first")]
        public DateTime DateFirst { get; set; }

        /// <summary>
        /// The next date for which the Scheduled Transaction is scheduled.
        /// $date
        /// </summary>
        [JsonPropertyName("date_next")]
        public DateTime DateNext { get; set; }

        /// <summary>
        /// See <see cref="Utils.Frequency"/>
        /// </summary>
        [JsonPropertyName("frequency")]
        public string Frequency { get; set; } = "";

        /// <summary>
        /// The scheduled transaction amount in milliunits format
        /// See <see cref="Utils.YnabMoney"/>
        /// </summary>
        [JsonPropertyName("amount")]
        public Int64 Amount { get; set; }

        [JsonPropertyName("memo")]
        public string? Memo { get; set; }

        /// <summary>
        /// The scheduled transaction flag
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
        [JsonPropertyName("payee_id")]
        public string? CategoryId { get; set; }

        /// <summary>
        /// If a transfer, the account_id which the scheduled transaction transfers to
        /// $uuid
        /// </summary>
        [JsonPropertyName("transfer_account_id")]
        public string? TransferAccountId { get; set; }

        /// <summary>
        /// Whether or not the scheduled transaction has been deleted.Deleted scheduled transactions will only be included in delta requests.
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
        /// If a split scheduled transaction, the subtransactions.
        /// </summary>
        [JsonPropertyName("subtransactions")]
        public IList<ScheduledSubTransaction> Subtransactions { get; set; } = new List<ScheduledSubTransaction>();


        public override string ToString() {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
        }

    }

    /*
id*	string($uuid)
date_first*	string($date)
The first date for which the Scheduled Transaction was scheduled.

date_next*	string($date)
The next date for which the Scheduled Transaction is scheduled.

frequency*	string
Enum:
[ never, daily, weekly, everyOtherWeek, twiceAMonth, every4Weeks, monthly, everyOtherMonth, every3Months, every4Months, twiceAYear, yearly, everyOtherYear ]
amount*	integer($int64)
The scheduled transaction amount in milliunits format

memo	string
flag_color	string
The scheduled transaction flag

Enum:
[ red, orange, yellow, green, blue, purple, ]
account_id*	string($uuid)
payee_id	string($uuid)
category_id	string($uuid)
transfer_account_id	string($uuid)
If a transfer, the account_id which the scheduled transaction transfers to

deleted*	boolean
Whether or not the scheduled transaction has been deleted. Deleted scheduled transactions will only be included in delta requests.

account_name*	string
payee_name	string
category_name	string
subtransactions*	[
If a split scheduled transaction, the subtransactions.

ScheduledSubTransaction{...}]
     */
}
