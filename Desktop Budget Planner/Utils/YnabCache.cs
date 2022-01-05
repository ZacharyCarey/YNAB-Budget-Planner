using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using YnabRestApi.ResponseData;

namespace Desktop_Budget_Planner.Utils {
    public class YnabCache {

        [JsonPropertyName("Cache Date")]
        public DateTime CacheDate { get; set; }

        public CategoriesData Data { get; set; }

    }
}
