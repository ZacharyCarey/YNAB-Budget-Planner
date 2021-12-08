using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class AccountsData {

        [JsonPropertyName("accounts")]
        public IList<Account> Accounts { get; set; } = new List<Account>();

        /// <summary>
        /// The knowledge of the server
        /// </summary>
        [JsonPropertyName("server_knowledge")]
        public Int64 ServerKnowledge { get; set; }

    }

    /*
accounts*	[Account{...}]
server_knowledge*	integer($int64)
The knowledge of the server
     */
}
