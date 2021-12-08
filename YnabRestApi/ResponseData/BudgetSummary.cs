using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class BudgetSummary {

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
        /// The budget accounts (only included if include_accounts=true specified as query parameter)
        /// </summary>
        [JsonPropertyName("accounts")]
        public IList<Account>? Accounts { get; set; }

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
accounts	[Account] 
     */
}
