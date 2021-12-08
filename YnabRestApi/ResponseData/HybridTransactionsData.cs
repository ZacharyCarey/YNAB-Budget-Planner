using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class HybridTransactionsData {

        [JsonPropertyName("transactions")]
        public IList<HybridTransaction> Transactions { get; set; } = new List<HybridTransaction>();

    }

    /*
transactions*	[HybridTransaction{...}]
     */
}
