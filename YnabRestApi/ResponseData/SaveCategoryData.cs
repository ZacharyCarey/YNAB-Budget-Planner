using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class SaveCategoryData {

        [JsonPropertyName("category")]
        public Category Category { get; set; } = new();

        /// <summary>
        /// The knowledge of the server
        /// </summary>
        public Int64 ServerKnowledge { get; set; } = 0;


        public override string ToString() {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
        }

    }

    /*
category*	Category{...}
server_knowledge*	integer($int64)
The knowledge of the server
     */
}
