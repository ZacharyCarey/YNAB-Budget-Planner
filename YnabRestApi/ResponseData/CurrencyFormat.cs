using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {

    /// <summary>
    /// The currency format setting for the budget. In some cases the format will not be available and will be specified as null.
    /// </summary>
    public class CurrencyFormat {

        [JsonPropertyName("iso_code")]
        public string IsoCode { get; set; } = "";

        [JsonPropertyName("example_format")]
        public string ExampleFormat { get; set; } = "";

        [JsonPropertyName("decimal_digits")]
        public Int32 DecimalDigits { get; set; } = 0;

        [JsonPropertyName("decimal_separator")]
        public string DecimalSeparator { get; set; } = "";

        [JsonPropertyName("symbol_first")]
        public bool SymbolFirst { get; set; } = false;

        [JsonPropertyName("group_separator")]
        public string GroupSeparator { get; set; } = "";

        [JsonPropertyName("currency_symbol")]
        public string CurrencySymbol { get; set; } = "";

        [JsonPropertyName("display_symbol")]
        public bool DisplaySymbol { get; set; } = false;


        public override string ToString() {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
        }

    }

    /*
iso_code*	string
example_format*	string
decimal_digits*	integer($int32)
decimal_separator*	string
symbol_first*	boolean
group_separator*	string
currency_symbol*	string
display_symbol*	boolean
     */
}
