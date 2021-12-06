using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class BudgetData {

        [JsonPropertyName("budget")]
        public Budget? Budget { get; set; }

        [JsonPropertyName("server_knowledge")]
        public int? ServerKnowledge { get; set; }

        public override string ToString() {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
        }

        /* JSON
"budget": {
    ...
},
"server_knowledge": 0
*/
    }
}
