using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class TransactionData {

        [JsonPropertyName("transaction")]
        public TransactionDetail Transaction { get; set; } = new();

    }

    /*
transaction*	TransactionDetail{...}
     */
}
