using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class PayeeLocation {

        /// <summary>
        /// $uuid
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = "";

        /// <summary>
        /// $uuid
        /// </summary>
        [JsonPropertyName("payee_id")]
        public string PayeeId { get; set; } = "";

        [JsonPropertyName("latitude")]
        public string Latitude { get; set; } = "";

        [JsonPropertyName("longitude")]
        public string Longitude { get; set; } = "";

        /// <summary>
        /// Whether or not the payee location has been deleted. Deleted payee locations will only be included in delta requests.
        /// </summary>
        [JsonPropertyName("deleted")]
        public bool Deleted { get; set; } = false;

    }

    /*
id*	string($uuid)
payee_id*	string($uuid)
latitude*	string
longitude*	string
deleted*	boolean
Whether or not the payee location has been deleted. Deleted payee locations will only be included in delta requests.
     */
}
