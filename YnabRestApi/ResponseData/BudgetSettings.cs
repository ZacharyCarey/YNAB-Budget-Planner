using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class BudgetSettings {

        [JsonPropertyName("date_format")]
        public DateFormat DateFormat { get; set; } = new();

        [JsonPropertyName("currency_format")]
        public CurrencyFormat CurrencyFormat { get; set; } = new();

    }

    /*
date_format*	DateFormat{...}
currency_format*	CurrencyFormat{...}
     */
}
