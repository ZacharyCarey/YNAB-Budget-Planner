using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class BudgetSettingsData {

        [JsonPropertyName("settings")]
        public BudgetSettings Settings { get; set; } = new();

    }

    /*
settings*	BudgetSettings
     */
}
