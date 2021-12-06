using System.Text.Json;
using System.Text.Json.Serialization;

namespace YnabRestApi.ResponseData {
    public class DateFormat {

        [JsonPropertyName("format")]
        public string? Format { get; set; }

        public override string ToString() {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
        }

        /* JSON
"format": "string"
         */
    }
}