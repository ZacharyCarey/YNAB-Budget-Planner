using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YnabRestApi.ResponseData {
    public class CategoryGroupWithCategories {

        /// <summary>
        /// $uuid
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = "";

        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        /// <summary>
        /// Whether or not the category group is hidden
        /// </summary>
        [JsonPropertyName("hidden")]
        public bool Hidden { get; set; } = false;

        /// <summary>
        /// Whether or not the category group has been deleted. Deleted category groups will only be included in delta requests.
        /// </summary>
        [JsonPropertyName("deleted")]
        public bool Deleted { get; set; } = false;

        /// <summary>
        /// Category group categories. Amounts (budgeted, activity, balance, etc.) are specific to the current budget month (UTC).
        /// </summary>
        [JsonPropertyName("categories")]
        public IList<Category> Categories { get; set; } = new List<Category>();

    }

    /*
id*	string($uuid)
name*	string
hidden*	boolean
Whether or not the category group is hidden

deleted*	boolean
Whether or not the category group has been deleted. Deleted category groups will only be included in delta requests.

categories*	[
Category group categories. Amounts (budgeted, activity, balance, etc.) are specific to the current budget month (UTC).

Category{...}]
     */
}
