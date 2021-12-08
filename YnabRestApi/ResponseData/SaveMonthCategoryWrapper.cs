using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class SaveMonthCategoryWrapper {

        [JsonPropertyName("category")]
        public SaveMonthCategory Category { get; set; } = new();


        public override string ToString() {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
        }

    }

    /*
category*	SaveMonthCategory{...}
     */
}
