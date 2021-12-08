using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class AccountData {

        [JsonPropertyName("account")]
        public Account Account { get; set; } = new();

    }

    /*
account*	Account{...}
     */
}
