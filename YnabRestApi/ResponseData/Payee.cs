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
        public string Id { get; set; } = "";

        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        /// <summary>
        /// If a transfer payee, the account_id to which this payee transfers to
        /// </summary>
        [JsonPropertyName("transfer_account_id")]
        public string? TransferAccountId { get; set; }

        /// <summary>
        /// Whether or not the payee has been deleted. Deleted payees will only be included in delta requests.
        /// </summary>
        [JsonPropertyName("deleted")]
        public bool Deleted { get; set; }


        public override string ToString() {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
        }

    }

    /*
id*	string($uuid)
name*	string
transfer_account_id	string
If a transfer payee, the account_id to which this payee transfers to

deleted*	boolean
Whether or not the payee has been deleted. Deleted payees will only be included in delta requests.
     */
}
