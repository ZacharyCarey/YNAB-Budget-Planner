using System.Text.Json;
using System.Text.Json.Serialization;

namespace YnabRestApi.ResponseData {
    public class YnabError {

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("detail")]
        public string? Detail { get; set; }

        public override string ToString() {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
        }

        /* JSON
"id": "123"
"name": "error_name"
"detail": "Error detail"
         */
    }
}