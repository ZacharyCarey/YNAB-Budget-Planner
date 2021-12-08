using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class CategoriesData {

        [JsonPropertyName("category_groups")]
        public IList<CategoryGroupWithCategories> CategoryGroups { get; set; } = new List<CategoryGroupWithCategories>();

        /// <summary>
        /// The knowledge of the server
        /// </summary>
        [JsonPropertyName("server_knowledge")]
        public Int64 ServerKnowledge { get; set; }


        public override string ToString() {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
        }

    }

    /*
category_groups*	[CategoryGroupWithCategories{...}]
server_knowledge*	integer($int64)
The knowledge of the server
     */
}
