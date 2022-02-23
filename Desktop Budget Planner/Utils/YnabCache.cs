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

        private Dictionary<string, Category> IdLookup = new();
        private CategoriesData data = new CategoriesData();
        public CategoriesData Data { 
            get => data; 
            set {
                data = value;

                // Update ID lookup
                IdLookup.Clear();
                if (value != null) {
                    foreach (CategoryGroupWithCategories group in value.CategoryGroups) {
                        foreach (Category category in group.Categories) {
                            IdLookup[category.Id] = category;
                        }
                    }
                }
            } 
        }

        public Category? this[string Id] {
            get {
                Category? category;
                if (!IdLookup.TryGetValue(Id, out category)) {
                    category = null;
                }

                return category;
            }
        }

    }
}
