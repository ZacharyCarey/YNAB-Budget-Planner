using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class PayeeLocationsData {

        [JsonPropertyName("payee_locations")]
        public IList<PayeeLocation> PayeeLocations { get; set; } = new List<PayeeLocation>();

    }

    /*
payee_locations*	[PayeeLocation{...}]
     */
}
