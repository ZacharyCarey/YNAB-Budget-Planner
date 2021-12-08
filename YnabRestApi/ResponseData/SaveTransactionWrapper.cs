using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class SaveTransactionWrapper {

        [JsonPropertyName("transaction")]
        public SaveTransaction Transaction { get; set; } = new();

    }

    /*
transaction*	SaveTransaction{...}
     */
}
