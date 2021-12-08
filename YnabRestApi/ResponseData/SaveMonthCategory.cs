using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class SaveMonthCategory {

        /// <summary>
        /// Budgeted amount in milliunits format
        /// See <see cref="Utils.YnabMoney"/>
        /// </summary>
        [JsonPropertyName("budgeted")]
        public Int64 Budgeted { get; set; }

    }

    /*
budgeted*	integer($int64)
Budgeted amount in milliunits format
     */
}
