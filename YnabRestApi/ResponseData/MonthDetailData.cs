using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class MonthDetailData {

        [JsonPropertyName("month")]
        public MonthDetail Month { get; set; } = new();

    }

    /*
month*	MonthDetail{...}
     */
}
