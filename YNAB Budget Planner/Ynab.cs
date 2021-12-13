
using YnabRestApi;
using YnabRestApi.ResponseData;

namespace YNAB_Budget_Planner {

    public static class Ynab {

        private static YnabApi ynab;

        static Ynab() {
            ynab = ApiClientFactory.Create(YnabAccessToken.Token);
        }

        public static void SetAccessToken(string Token) {
            ynab = ApiClientFactory.Create(Token);
        }

        private static T? GetResponse<T>(Task<ApiResponse<T>> task) where T : class, new() {
            // HTTP Error codes show up during task.Wait().
            // See errors here: https://api.youneedabudget.com/#errors
            try {
                task.Wait();
                return task.Result.Data;
            } catch (Exception) {
                return null;
            }
        }

        public static CategoriesData GetCategories(string budgetId = "last-used") {
            return GetResponse(ynab.GetCategories(budgetId));
        }

    }
}
