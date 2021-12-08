using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class ScheduledTransactionData {

        [JsonPropertyName("scheduled_transaction")]
        public ScheduledTransactionDetail ScheduledTransaction { get; set; } = new();

    }

    /*
scheduled_transaction*	ScheduledTransactionDetail{...}
     */
}
