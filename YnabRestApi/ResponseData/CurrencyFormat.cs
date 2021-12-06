using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class CurrencyFormat {

        [JsonPropertyName("iso_code")]
        public string? IsoCode { get; set; }

        [JsonPropertyName("exmaple_format")]
        public string? ExmapleFormat { get; set; }

        [JsonPropertyName("decimal_digits")]
        public int? DecimalDigits { get; set; }

        [JsonPropertyName("decimal_separator")]
        public string? DecimalSeparator { get; set; }

        [JsonPropertyName("symbol_first")]
        public bool? SymbolFirst { get; set; }

        [JsonPropertyName("group_separator")]
        public string? GroupSeparator { get; set; }

        [JsonPropertyName("currency_symbol")]
        public string? CurrencySymbol { get; set; }

        [JsonPropertyName("display_symbol")]
        public bool? DisplaySymbol { get; set; }

        public override string ToString() {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
        }

        /* Json
"iso_code": "string",
"example_format": "string",
"decimal_digits": 0,
"decimal_separator": "string",
"symbol_first": true,
"group_separator": "string",
"currency_symbol": "string",
"display_symbol": true
         */
    }
}
