using System.Text.Json;
using System.Text.Json.Serialization;

namespace YnabRestApi.ResponseData {
    public class PayeeLocation {

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("payee_id")]
        public string? PayeeId { get; set; }

        [JsonPropertyName("latitude")]
        public string? Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public string? Longitude { get; set; }

        [JsonPropertyName("deleted")]
        public bool? Deleted { get; set; }

        public override string ToString() {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
        }

        /* JSON
"id": "string",
"payee_id": "string",
"latitude": "string",
"longitude": "string",
"deleted": true
         */
    }
}