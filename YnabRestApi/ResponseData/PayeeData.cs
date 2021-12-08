using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class PayeeData {

        [JsonPropertyName("payee")]
        public Payee Payee { get; set; } = new();

    }

    /*
payee*	Payee{...}
     */
}
