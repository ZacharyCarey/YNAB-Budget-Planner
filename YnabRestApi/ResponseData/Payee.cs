using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class Payee {

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("transfer_account_id")]
        public string? TransferAccountId { get; set; }

        [JsonPropertyName("deleted")]
        public bool? Deleted { get; set; }

        public override string ToString() {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
        }

        /* JSON
"id": "string",
"name": "string",
"transfer_account_id": "string",
"deleted": true
         */
    }
}
