using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class MonthSummary {

        /// <summary>
        /// $date
        /// </summary>
        [JsonPropertyName("month")]
        public DateTime Month { get; set; }

        [JsonPropertyName("note")]
        public string? Note { get; set; }

        /// <summary>
        /// The total amount of transactions categorized to ‘Inflow: Ready to Assign’ in the month
        /// See <see cref="Utils.YnabMoney"/>
        /// </summary>
        [JsonPropertyName("income")]
        public Int64 Income { get; set; }

        /// <summary>
        /// The total amount budgeted in the month
        /// </summary>
        [JsonPropertyName("budgeted")]
        public Int64 Budgeted { get; set; }

        /// <summary>
        /// The total amount of transactions in the month, excluding those categorized to ‘Inflow: Ready to Assign’
        /// See <see cref="Utils.YnabMoney"/>
        /// </summary>
        [JsonPropertyName("activity")]
        public Int64 Activity { get; set; }

        /// <summary>
        /// The available amount for ‘Ready to Assign’
        /// See <see cref="Utils.YnabMoney"/>
        /// </summary>
        [JsonPropertyName("to_be_budgeted")]
        public Int64 ToBeBudgeted { get; set; }

        /// <summary>
        /// The Age of Money as of the month
        /// </summary>
        [JsonPropertyName("age_of_money")]
        public Int32? AgeOfMoney { get; set; }

        /// <summary>
        /// Whether or not the month has been deleted. Deleted months will only be included in delta requests.
        /// </summary>
        [JsonPropertyName("deleted")]
        public bool Deleted { get; set; }


        public override string ToString() {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
        }

    }

    /*
month*	string($date)
note	string
income*	integer($int64)
The total amount of transactions categorized to ‘Inflow: Ready to Assign’ in the month

budgeted*	integer($int64)
The total amount budgeted in the month

activity*	integer($int64)
The total amount of transactions in the month, excluding those categorized to ‘Inflow: Ready to Assign’

to_be_budgeted*	integer($int64)
The available amount for ‘Ready to Assign’

age_of_money	integer($int32)
The Age of Money as of the month

deleted*	boolean
Whether or not the month has been deleted. Deleted months will only be included in delta requests.
     */
}
