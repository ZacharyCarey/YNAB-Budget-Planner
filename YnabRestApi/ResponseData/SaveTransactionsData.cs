using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class SaveTransactionsData {

        /// <summary>
        /// The transaction ids that were saved
        /// </summary>
        [JsonPropertyName("transaction_ids")]
        public IList<string> TransactionIds { get; set; } = new List<string>();

        [JsonPropertyName("transaction")]
        public TransactionDetail? Transaction { get; set; }

        /// <summary>
        /// If multiple transactions were specified, the transactions that were saved
        /// </summary>
        [JsonPropertyName("transactions")]
        public IList<TransactionDetail>? Transactions { get; set; }

        /// <summary>
        /// If multiple transactions were specified, a list of import_ids that were not created because of an existing import_id found on the same account
        /// </summary>
        [JsonPropertyName("duplicate_import_ids")]
        public IList<string>? DuplicateImportIds { get; set; }

        /// <summary>
        /// The knowledge of the server
        /// </summary>
        [JsonPropertyName("server_knowledge")]
        public Int64 ServerKnowledge { get; set; }

    }

    /*
transaction_ids*	[
The transaction ids that were saved

string]
transaction	TransactionDetail{...}
transactions	[
If multiple transactions were specified, the transactions that were saved

TransactionDetail{...}]
duplicate_import_ids	[
If multiple transactions were specified, a list of import_ids that were not created because of an existing import_id found on the same account

string]
server_knowledge*	integer($int64)
The knowledge of the server
     */
}
