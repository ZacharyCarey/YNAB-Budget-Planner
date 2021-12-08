using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {

    /// <summary>
    /// The date format setting for the budget. In some cases the format will not be available and will be specified as null.
    /// </summary>
    public class DateFormat {

        [JsonPropertyName("format")]
        public string Format { get; set; } = "";

    }

    /*
format*	string
     */
}
