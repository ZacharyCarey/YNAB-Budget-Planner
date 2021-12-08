using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class TransactionsData {

        [JsonPropertyName("transactions")]
        public IList<TransactionDetail> Transactions { get; set; } = new List<TransactionDetail>();

        /// <summary>
        /// The knowledge of the server
        /// </summary>
        [JsonPropertyName("server_knowledge")]
        public Int64 ServerKnowledge { get; set; } = 0;


        public override string ToString() {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
        }

    }

    /*
transactions*	[TransactionDetail{...}]
server_knowledge*	integer($int64)
The knowledge of the server
     */
}
