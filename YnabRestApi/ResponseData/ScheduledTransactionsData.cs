using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class ScheduledTransactionsData {

        [JsonPropertyName("scheduled_transactions")]
        public IList<ScheduledTransactionDetail> ScheduledTransactions { get; set; } = new List<ScheduledTransactionDetail>();

        /// <summary>
        /// The knowledge of the server
        /// </summary>
        [JsonPropertyName("server_knowledge")]
        public Int64 ServerKnowledge { get; set; }

    }

    /*
scheduled_transactions*	[ScheduledTransactionDetail{...}]
server_knowledge*	integer($int64)
The knowledge of the server
     */
}
