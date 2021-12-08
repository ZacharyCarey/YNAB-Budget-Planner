using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class TransactionsImportData {

        /// <summary>
        /// The list of transaction ids that were imported.
        /// </summary>
        [JsonPropertyName("transaction_ids")]
        public IList<string> TransactionIds { get; set; } = new List<string>();


        public override string ToString() {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
        }

    }

    /*
transaction_ids*	[
The list of transaction ids that were imported.

string]
     */

}
