using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class SaveAccountWrapper {

        [JsonPropertyName("account")]
        public SaveAccount Account { get; set; } = new();

    }

    /*
account*	SaveAccount
     */
}
