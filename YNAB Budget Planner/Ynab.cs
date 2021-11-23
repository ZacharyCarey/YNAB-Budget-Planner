using YNAB.Rest;

namespace YNAB_Budget_Planner {
    public static class Ynab {

        private static IApiClient ynab;

        static Ynab() {
            ynab = ApiClientFactory.Create(YnabAccessToken.Token);
        }

        public static async Task<string> GetBudgetName() {
            ApiResponse<BudgetsData> response = await ynab.GetBudgets();
            return response.Data.Budgets[0].Name;
        }

    }
}
