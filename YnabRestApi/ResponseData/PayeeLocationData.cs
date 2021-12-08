using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class PayeeLocationData {

        [JsonPropertyName("payee_location")]
        public PayeeLocation PayeeLocation { get; set; } = new();

    }

    /*
payee_location*	PayeeLocation{...}
     */
}
