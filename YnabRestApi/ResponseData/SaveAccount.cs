using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class SaveAccount {

        /// <summary>
        /// The name of the account
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        /// <summary>
        /// The account type
        /// See <see cref="Utils.AccountType"/>
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; } = "";

        /// <summary>
        /// The current balance of the account in milliunits format
        /// </summary>
        [JsonPropertyName("balance")]
        public Int64 Balance { get; set; } = 0;

    }

    /*
name*	string
The name of the account

type*	string
The account type

Enum:
Array [ checking, savings, creditCard, cash, lineOfCredit, otherAsset, otherLiability ]
balance*	integer($int64)
The current balance of the account in milliunits format
     */
}
