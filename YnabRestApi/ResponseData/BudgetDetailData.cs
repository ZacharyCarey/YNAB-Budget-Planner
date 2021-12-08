using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class BudgetDetailData {

        [JsonPropertyName("budget")]
        public BudgetDetail Budget { get; set; } = new();

        /// <summary>
        /// The knowledge of the server
        /// </summary>
        [JsonPropertyName("server_knowledge")]
        public Int64 ServerKnowledge { get; set; } = -1;
    }

    /*
budget*	BudgetDetail
server_knowledge*	integer($int64)
The knowledge of the server
     */
}
