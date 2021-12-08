using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class ErrorResponse {

        [JsonPropertyName("error")]
        public ErrorDetail Error { get; set; } = new();

    }

    /*
error*	ErrorDetail
     */
}
