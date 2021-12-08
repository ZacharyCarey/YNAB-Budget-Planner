using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class CategoryData {

        [JsonPropertyName("category")]
        public Category Category { get; set; } = new();

    }

    /*
category*	Category{...}
     */
}
