using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class BudgetDetail {

        /// <summary>
        /// $uuid
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = "";

        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        /// <summary>
        /// The last time any changes were made to the budget from either a web or mobile client
        /// $date-time
        /// </summary>
        [JsonPropertyName("last_modified_on")]
        public DateTime? LastModifiedOn { get; set; }

        /// <summary>
        /// The earliest budget month
        /// $date
        /// </summary>
        [JsonPropertyName("first_month")]
        public DateTime? FirstMonth { get; set; }

        /// <summary>
        /// The latest budget month
        /// $date
        /// </summary>
        [JsonPropertyName("last_month")]
        public DateTime? LastMonth { get; set; }

        [JsonPropertyName("date_format")]
        public DateFormat? DateFormat { get; set; }

        [JsonPropertyName("currency_format")]
        public CurrencyFormat? CurrencyFormat { get; set; }

        /// <summary>
        /// The budget accounts(only included if include_accounts = true specified as query parameter)
        /// </summary>
        [JsonPropertyName("accounts")]
        public IList<Account>? Accounts { get; set; }

        [JsonPropertyName("payees")]
        public IList<Payee>? Payees { get; set; }

        [JsonPropertyName("payee_locations")]
        public IList<PayeeLocation>? PayeeLocations { get; set; }

        [JsonPropertyName("category_groups")]
        public IList<CategoryGroup>? CategoryGroups { get; set; }

        [JsonPropertyName("categories")]
        public IList<Category>? Categories { get; set; }

        [JsonPropertyName("months")]
        public IList<MonthDetail>? Months { get; set; }

        [JsonPropertyName("transactions")]
        public IList<TransactionSummary>? Transactions { get; set; }

        [JsonPropertyName("subtransactions")]
        public IList<SubTransaction>? SubTransactions { get; set; }

        [JsonPropertyName("scheduled_transactions")]
        public IList<ScheduledTransactionSummary>? ScheduledTransactions { get; set; }

        [JsonPropertyName("scheduled_subtransactions")]
        public IList<ScheduledSubTransaction>? ScheduledSubTransactions { get; set; }


        public override string ToString() {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
        }
    }

    /*
id*	string($uuid)
name*	string
last_modified_on	string($date-time)
The last time any changes were made to the budget from either a web or mobile client

first_month	string($date)
The earliest budget month

last_month	string($date)
The latest budget month

date_format	DateFormat{...}
currency_format	CurrencyFormat{...}
accounts	[
The budget accounts (only included if include_accounts=true specified as query parameter)

Account{...}]
payees	[Payee{...}]
payee_locations	[PayeeLocation{...}]
category_groups	[CategoryGroup{...}]
categories	[Category{...}]
months	[MonthDetail{...}]
transactions	[TransactionSummary{...}]
subtransactions	[SubTransaction{...}]
scheduled_transactions	[ScheduledTransactionSummary{...}]
scheduled_subtransactions	[ScheduledSubTransaction{...}]
     */
}
