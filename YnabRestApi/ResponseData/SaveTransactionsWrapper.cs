using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class SaveTransactionsWrapper {

        [JsonPropertyName("transaction")]
        public SaveTransaction? Transaction { get; set; }

        [JsonPropertyName("transactions")]
        public IList<SaveTransaction>? Transactions { get; set; }

    }

    /*
transaction	SaveTransaction{...}
transactions	[SaveTransaction{...}]
     */
}
