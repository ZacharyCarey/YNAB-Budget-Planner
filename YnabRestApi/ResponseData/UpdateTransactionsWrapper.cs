using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class UpdateTransactionsWrapper {

        [JsonPropertyName("transactions")]
        public IList<UpdateTransaction> Transactions { get; set; } = new List<UpdateTransaction>();


        public override string ToString() {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
        }

    }

    /*
transactions*	[UpdateTransaction{...}]
     */
}
