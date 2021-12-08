using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class SaveSubTransaction {

        /// <summary>
        /// The subtransaction amount in milliunits format.
        /// See <see cref="Utils.YnabMoney"/>
        /// </summary>
        [JsonPropertyName("amount")]
        public Int64 Amount { get; set; } = 0;

        /// <summary>
        /// The payee for the subtransaction.
        /// $uuid
        /// </summary>
        [JsonPropertyName("payee_id")]
        public string? PayeeId { get; set; }

        /// <summary>
        /// maxLength: 50
        /// The payee name.If a payee_name value is provided and payee_id has a null value, the payee_name value will be used to resolve the payee by either(1) a matching payee rename rule(only if import_id is also specified on parent transaction) or(2) a payee with the same name or(3) creation of a new payee.
        /// </summary>
        [JsonPropertyName("payee_name")]
        public string? PayeeName { get; set; }

        /// <summary>
        /// The category for the subtransaction. Credit Card Payment categories are not permitted and will be ignored if supplied.
        /// $uuid
        /// </summary>
        [JsonPropertyName("category_id")]
        public string? CategoryId { get; set; }

        /// <summary>
        /// maxLength: 200
        /// </summary>
        [JsonPropertyName("memo")]
        public string? Memo { get; set; }


        public override string ToString() {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
        }

    }

    /*
amount*	integer($int64)
The subtransaction amount in milliunits format.

payee_id	string($uuid)
The payee for the subtransaction.

payee_name	string
maxLength: 50
The payee name. If a payee_name value is provided and payee_id has a null value, the payee_name value will be used to resolve the payee by either (1) a matching payee rename rule (only if import_id is also specified on parent transaction) or (2) a payee with the same name or (3) creation of a new payee.

category_id	string($uuid)
The category for the subtransaction. Credit Card Payment categories are not permitted and will be ignored if supplied.

memo	string
maxLength: 200
     */
}
