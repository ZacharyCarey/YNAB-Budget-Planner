const ynabAPI = new ynab.API(YnabAccessToken);

(async function () {
    const budgetsResponse = await ynabAPI.budgets.getBudgets();
    const budgets = budgetsResponse.data.budgets;
    for (let budget of budgets) {
        console.log(`Budget Name: ${budget.name}`);
    }
})();