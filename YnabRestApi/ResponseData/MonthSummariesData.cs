using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class MonthSummariesData {

        [JsonPropertyName("months")]
        public IList<MonthSummary> Months = new List<MonthSummary>();

        /// <summary>
        /// The knowledge of the server
        /// </summary>
        [JsonPropertyName("server_knowledge")]
        public Int64 ServerKnowledge { get; set; }

    }

    /*
months*	[MonthSummary{...}]
server_knowledge*	integer($int64)
The knowledge of the server
     */
}
