using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YnabRestApi.ResponseData;

namespace YnabRestApi {

    /// <summary>
    /// An interface containing the REST methods available in the YNAB API.
    /// </summary>
    public interface YnabApi {

        #region User
        /// <summary>
        /// Returns authenticated user information
        /// </summary>
        /// <returns></returns>
        [Get("/user")]
        Task<ResponseData.ApiResponse<UserData>> GetUserInfo();
        #endregion


        #region Budgets
        /// <summary>
        /// Returns budgets list with summary information
        /// </summary>
        /// <param name="includeAccounts">Whether to include the list of budget accounts</param>
        /// <returns></returns>
        [Get("/budgets")]
        Task<ResponseData.ApiResponse<BudgetSummaryData>> GetBudgets([Query][AliasAs("include_account")] bool includeAccounts);


        /// <inheritdoc cref="GetBudgets(bool)"/>
        [Get("/budgets")]
        Task<ResponseData.ApiResponse<BudgetSummaryData>> GetBudgets();


        /// <summary>
        /// Returns a single budget with all related entities. This resource is effectively a full budget export.
        /// </summary>
        /// <param name="budgetId">The id of the budget. “last-used” can be used to specify the last used budget and “default” can be used if default budget selection is enabled (see: https://api.youneedabudget.com/#oauth-default-budget).</param>
        /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since last_knowledge_of_server will be included.</param>
        /// <returns></returns>
        [Get("/budgets/{budgetId}")]
        Task<ResponseData.ApiResponse<BudgetDetailData>> GetBudget(string budgetId, [Query][AliasAs("last_knowledge_of_server")] Int64 lastKnowledgeOfServer);


        /// <inheritdoc cref="GetBudget(string, long)"/>
        [Get("/budgets/{budgetId}")]
        Task<ResponseData.ApiResponse<BudgetDetailData>> GetBudget(string budgetId);


        /// <summary>
        /// Returns settings for a budget
        /// </summary>
        /// <param name="budgetId">The id of the budget. “last-used” can be used to specify the last used budget and “default” can be used if default budget selection is enabled (see: https://api.youneedabudget.com/#oauth-default-budget).</param>
        /// <returns></returns>
        [Get("/budgets/{budgetId}/settings")]
        Task<ResponseData.ApiResponse<BudgetSettingsData>> GetBudgetSettings(string budgetId);
        #endregion


        #region Accounts
        /// <summary>
        /// Returns all accounts
        /// </summary>
        /// <param name="budgetId">The id of the budget. “last-used” can be used to specify the last used budget and “default” can be used if default budget selection is enabled (see: https://api.youneedabudget.com/#oauth-default-budget).</param>
        /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since last_knowledge_of_server will be included.</param>
        /// <returns></returns>
        [Get("/budgets/{budgetId}/accounts")]
        Task<ResponseData.ApiResponse<AccountsData>> GetAccounts(string budgetId, [Query][AliasAs("last_knowledge_of_server")] Int64 lastKnowledgeOfServer);


        /// <inheritdoc cref="GetAccounts(string, long)"/>
        [Get("/budgets/{budgetId}/accounts")]
        Task<ResponseData.ApiResponse<AccountsData>> GetAccounts(string budgetId);


        /// <summary>
        /// Creates a new account
        /// </summary>
        /// <param name="budgetId">The id of the budget (“last-used” can be used to specify the last used budget and “default” can be used if default budget selection is enabled (see: https://api.youneedabudget.com/#oauth-default-budget)</param>
        /// <param name="data">The account to create.</param>
        /// <returns></returns>
        [Post("/budgets/{budgetId}/accounts")]
        Task<ResponseData.ApiResponse<AccountData>> PostAccount(string budgetId, [Body] SaveAccountWrapper data);


        /// <summary>
        /// Returns a single account
        /// </summary>
        /// <param name="budgetId">The id of the budget. “last-used” can be used to specify the last used budget and “default” can be used if default budget selection is enabled (see: https://api.youneedabudget.com/#oauth-default-budget).</param>
        /// <param name="accountId">The id of the account</param>
        /// <returns></returns>
        [Get("/budgets/{budgetId}/accounts/accountId")]
        Task<ResponseData.ApiResponse<AccountsData>> GetAccount(string budgetId, string accountId);
        #endregion


        #region Categories
        /// <summary>
        /// Returns all categories grouped by category group. Amounts (budgeted, activity, balance, etc.) are specific to the current budget month (UTC).
        /// </summary>
        /// <param name="budgetId">The id of the budget. “last-used” can be used to specify the last used budget and “default” can be used if default budget selection is enabled (see: https://api.youneedabudget.com/#oauth-default-budget).</param>
        /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since last_knowledge_of_server will be included.</param>
        /// <returns></returns>
        [Get("/budgets/{budgetId}/categories")]
        Task<ResponseData.ApiResponse<AccountsData>> GetCategories(string budgetId, [Query][AliasAs("last_knowledge_of_server")] Int64 lastKnowledgeOfServer);


        /// <inheritdoc cref="GetCategories(string, long)"/>
        [Get("/budgets/{budgetId}/categories")]
        Task<ResponseData.ApiResponse<CategoriesData>> GetCategories(string budgetId);


        /// <summary>
        /// Returns a single category. Amounts (budgeted, activity, balance, etc.) are specific to the current budget month (UTC).
        /// </summary>
        /// <param name="budgetId">The id of the budget. “last-used” can be used to specify the last used budget and “default” can be used if default budget selection is enabled (see: https://api.youneedabudget.com/#oauth-default-budget).</param>
        /// <param name="categoryId">The id of the category</param>
        /// <returns></returns>
        [Get("/budgets/{budgetId}/categories/{categoryId}")]
        Task<ResponseData.ApiResponse<CategoryData>> GetCategory(string budgetId, string categoryId);


        /// <summary>
        /// Returns a single category for a specific budget month. Amounts (budgeted, activity, balance, etc.) are specific to the current budget month (UTC).
        /// </summary>
        /// <param name="budgetId">The id of the budget. “last-used” can be used to specify the last used budget and “default” can be used if default budget selection is enabled (see: https://api.youneedabudget.com/#oauth-default-budget).</param>
        /// <param name="categoryId">The id of the category</param>
        /// <param name="month">The budget month in ISO format (e.g. 2016-12-01) (“current” can also be used to specify the current calendar month (UTC))</param>
        /// <returns></returns>
        [Get("/budgets/{budgetId}/months/{month}/categories/{categoryId}")]
        Task<ResponseData.ApiResponse<CategoryData>> GetCategory(string budgetId, string categoryId, string month);


        /// <summary>
        /// Update a category for a specific month. Only budgeted amount can be updated.
        /// </summary>
        /// <param name="budgetId">The id of the budget. “last-used” can be used to specify the last used budget and “default” can be used if default budget selection is enabled (see: https://api.youneedabudget.com/#oauth-default-budget).</param>
        /// <param name="categoryId">The id of the category</param>
        /// <param name="month">The budget month in ISO format (e.g. 2016-12-01) (“current” can also be used to specify the current calendar month (UTC))</param>
        /// <param name="data">The category to update. Only budgeted amount can be updated and any other fields specified will be ignored.</param>
        /// <returns></returns>
        [Patch("/budgets/{budgetId}/months/{month}/categories/{categoryId}")]
        Task<ResponseData.ApiResponse<SaveCategoryData>> PatchCategory(string budgetId, string categoryId, string month, [Body] SaveMonthCategoryWrapper data);
        #endregion


        #region Payees
        /// <summary>
        /// Returns all payees
        /// </summary>
        /// <param name="budgetId">The id of the budget. “last-used” can be used to specify the last used budget and “default” can be used if default budget selection is enabled (see: https://api.youneedabudget.com/#oauth-default-budget).</param>
        /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since last_knowledge_of_server will be included.</param>
        /// <returns></returns>
        [Get("/budgets/{budgetId}/payees")]
        Task<ResponseData.ApiResponse<PayeesData>> GetPayees(string budgetId, [Query][AliasAs("last_knowledge_of_server")] Int64 lastKnowledgeOfServer);


        /// <inheritdoc cref="GetPayees(string, long)"/>
        [Get("/budgets/{budgetId}/payees")]
        Task<ResponseData.ApiResponse<PayeesData>> GetPayees(string budgetId);


        /// <summary>
        /// Returns a single payee
        /// </summary>
        /// <param name="budgetId">The id of the budget. “last-used” can be used to specify the last used budget and “default” can be used if default budget selection is enabled (see: https://api.youneedabudget.com/#oauth-default-budget).</param>
        /// <param name="payeeId">The id of the payee</param>
        /// <returns></returns>
        [Get("/budgets/{budgetId}/payees/{payeeId}")]
        Task<ResponseData.ApiResponse<PayeeData>> GetPayees(string budgetId, string payeeId);
        #endregion


        #region Payee Locations
        /// <summary>
        /// Returns all payee locations
        /// </summary>
        /// <param name="budgetId">The id of the budget. “last-used” can be used to specify the last used budget and “default” can be used if default budget selection is enabled (see: https://api.youneedabudget.com/#oauth-default-budget).</param>
        /// <returns></returns>
        [Get("/budgets/{budgetId}/payee_locations")]
        Task<ResponseData.ApiResponse<PayeeLocationsData>> GetPayeeLocations(string budgetId);


        /// <summary>
        /// Returns a single payee location
        /// </summary>
        /// <param name="budgetId">The id of the budget. “last-used” can be used to specify the last used budget and “default” can be used if default budget selection is enabled (see: https://api.youneedabudget.com/#oauth-default-budget).</param>
        /// <param name="payeeLocationId">id of payee location</param>
        /// <returns></returns>
        [Get("/budgets/{budgetId}/payee_locations/{payeeLocationId}")]
        Task<ResponseData.ApiResponse<PayeeLocationData>> GetPayeeLocation(string budgetId, string payeeLocationId);


        /// <summary>
        /// Returns all payee locations for a specified payee
        /// </summary>
        /// <param name="budgetId">The id of the budget. “last-used” can be used to specify the last used budget and “default” can be used if default budget selection is enabled (see: https://api.youneedabudget.com/#oauth-default-budget).</param>
        /// <param name="payeeId">id of payee</param>
        /// <returns></returns>
        [Get("/budgets/{budgetId}/payees/{payeeId}/payee_locations")]
        Task<ResponseData.ApiResponse<PayeeLocationsData>> GetPayeeLocations(string budgetId, string payeeId);
        #endregion


        #region Months
        /// <summary>
        /// Returns all budget months
        /// </summary>
        /// <param name="budgetId">The id of the budget. “last-used” can be used to specify the last used budget and “default” can be used if default budget selection is enabled (see: https://api.youneedabudget.com/#oauth-default-budget).</param>
        /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since last_knowledge_of_server will be included.</param>
        /// <returns></returns>
        [Get("/budgets/{budgetId}/months")]
        Task<ResponseData.ApiResponse<MonthSummariesData>> GetMonths(string budgetId, [Query][AliasAs("last_knowledge_of_server")] Int64 lastKnowledgeOfServer);


        /// <inheritdoc cref="GetMonths(string, long)"/>
        [Get("/budgets/{budgetId}/months")]
        Task<ResponseData.ApiResponse<MonthSummariesData>> GetMonths(string budgetId);


        /// <summary>
        /// Returns a single budget month
        /// </summary>
        /// <param name="budgetId">The id of the budget. “last-used” can be used to specify the last used budget and “default” can be used if default budget selection is enabled (see: https://api.youneedabudget.com/#oauth-default-budget).</param>
        /// <param name="month">The budget month in ISO format (e.g. 2016-12-01) (“current” can also be used to specify the current calendar month (UTC))</param>
        /// <returns></returns>
        [Get("/budgets/{budgetId}/months/{month}")]
        Task<ResponseData.ApiResponse<MonthDetailData>> GetMonth(string budgetId, string month);
        #endregion


        #region Transactions
        #region GetTransactions
        /// <summary>
        /// Returns budget transactions
        /// </summary>
        /// <param name="budgetId">The id of the budget. “last-used” can be used to specify the last used budget and “default” can be used if default budget selection is enabled (see: https://api.youneedabudget.com/#oauth-default-budget).</param>
        /// <param name="sinceDate">If specified, only transactions on or after this date will be included. The date should be ISO formatted (e.g. 2016-12-30).</param>
        /// <param name="type">If specified, only transactions of the specified type will be included. “uncategorized” and “unapproved” are currently supported.</param>
        /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since last_knowledge_of_server will be included.</param>
        /// <returns></returns>
        [Get("/budgets/{budgetId}/transactions")]
        Task<ResponseData.ApiResponse<TransactionsData>> GetTransactions(
            string budgetId, 
            [Query(Format = "yyyy-MM-dd")][AliasAs("since_date")] DateTime sinceDate,
            [Query] string type,
            [Query][AliasAs("last_knowledge_of_server")] Int64 lastKnowledgeOfServer
        );


        /// <inheritdoc cref="GetTransactions(string, DateTime, string, long)"/>
        [Get("/budgets/{budgetId}/transactions")]
        Task<ResponseData.ApiResponse<TransactionsData>> GetTransactions(
            string budgetId
        );


        /// <inheritdoc cref="GetTransactions(string, DateTime, string, long)"/>
        [Get("/budgets/{budgetId}/transactions")]
        Task<ResponseData.ApiResponse<TransactionsData>> GetTransactions(
            string budgetId,
            [Query(Format = "yyyy-MM-dd")][AliasAs("since_date")] DateTime sinceDate
        );


        /// <inheritdoc cref="GetTransactions(string, DateTime, string, long)"/>
        [Get("/budgets/{budgetId}/transactions")]
        Task<ResponseData.ApiResponse<TransactionsData>> GetTransactions(
            string budgetId,
            [Query] string type
        );


        /// <inheritdoc cref="GetTransactions(string, DateTime, string, long)"/>
        [Get("/budgets/{budgetId}/transactions")]
        Task<ResponseData.ApiResponse<TransactionsData>> GetTransactions(
            string budgetId,
            [Query(Format = "yyyy-MM-dd")][AliasAs("since_date")] DateTime sinceDate,
            [Query] string type
        );


        /// <inheritdoc cref="GetTransactions(string, DateTime, string, long)"/>
        [Get("/budgets/{budgetId}/transactions")]
        Task<ResponseData.ApiResponse<TransactionsData>> GetTransactions(
            string budgetId,
            [Query][AliasAs("last_knowledge_of_server")] Int64 lastKnowledgeOfServer
        );


        /// <inheritdoc cref="GetTransactions(string, DateTime, string, long)"/>
        [Get("/budgets/{budgetId}/transactions")]
        Task<ResponseData.ApiResponse<TransactionsData>> GetTransactions(
            string budgetId,
            [Query(Format = "yyyy-MM-dd")][AliasAs("since_date")] DateTime sinceDate,
            [Query][AliasAs("last_knowledge_of_server")] Int64 lastKnowledgeOfServer
        );


        /// <inheritdoc cref="GetTransactions(string, DateTime, string, long)"/>
        [Get("/budgets/{budgetId}/transactions")]
        Task<ResponseData.ApiResponse<TransactionsData>> GetTransactions(
            string budgetId,
            [Query] string type,
            [Query][AliasAs("last_knowledge_of_server")] Int64 lastKnowledgeOfServer
        );
        #endregion
        /// <summary>
        /// Creates a single transaction or multiple transactions. If you provide a body containing a transaction object, a single transaction will be created and if you provide a body containing a transactions array, multiple transactions will be created. Scheduled transactions cannot be created on this endpoint.
        /// </summary>
        /// <param name="budgetId">The id of the budget. “last-used” can be used to specify the last used budget and “default” can be used if default budget selection is enabled (see: https://api.youneedabudget.com/#oauth-default-budget).</param>
        /// <param name="data">The transaction or transactions to create. To create a single transaction you can specify a value for the transaction object and to create multiple transactions you can specify an array of transactions. It is expected that you will only provide a value for one of these objects.</param>
        /// <returns></returns>
        [Post("/budgets/{budgetId}/transactions")]
        Task<ResponseData.ApiResponse<SaveTransactionsData>> PostTransactions(string budgetId, [Body] SaveTransactionsWrapper data);


        /// <summary>
        /// Updates multiple transactions, by id or import_id.
        /// </summary>
        /// <param name="budgetId">The id of the budget. “last-used” can be used to specify the last used budget and “default” can be used if default budget selection is enabled (see: https://api.youneedabudget.com/#oauth-default-budget).</param>
        /// <param name="data">The transactions to update. Each transaction must have either an id or import_id specified. If id is specified as null an import_id value can be provided which will allow transaction(s) to be updated by their import_id. If an id is specified, it will always be used for lookup.</param>
        /// <returns></returns>
        [Patch("/budgets/{budgetId}/transactions")]
        Task<ResponseData.ApiResponse<SaveTransactionsData>> PatchTransactions(string budgetId, [Body] UpdateTransactionsWrapper data);


        /// <summary>
        /// Imports available transactions on all linked accounts for the given budget. Linked accounts allow transactions to be imported directly from a specified financial institution and this endpoint initiates that import. Sending a request to this endpoint is the equivalent of clicking “Import” on each account in the web application or tapping the “New Transactions” banner in the mobile applications. The response for this endpoint contains the transaction ids that have been imported.
        /// </summary>
        /// <param name="budgetId">The id of the budget. “last-used” can be used to specify the last used budget and “default” can be used if default budget selection is enabled (see: https://api.youneedabudget.com/#oauth-default-budget).</param>
        /// <returns></returns>
        [Post("/budgets/{budgetId}/transactions/import")]
        Task<ResponseData.ApiResponse<TransactionsImportData>> PostTransactions(string budgetId);


        /// <summary>
        /// Returns a single transaction
        /// </summary>
        /// <param name="budgetId">The id of the budget. “last-used” can be used to specify the last used budget and “default” can be used if default budget selection is enabled (see: https://api.youneedabudget.com/#oauth-default-budget).</param>
        /// <param name="transactionId">The id of the transaction</param>
        /// <returns></returns>
        [Get("/budgets/{budgetId}/transactions/{transactionId}")]
        Task<ResponseData.ApiResponse<TransactionData>> GetTransaction(string budgetId, string transactionId);


        /// <summary>
        /// Updates a single transaction
        /// </summary>
        /// <param name="budgetId">The id of the budget. “last-used” can be used to specify the last used budget and “default” can be used if default budget selection is enabled (see: https://api.youneedabudget.com/#oauth-default-budget).</param>
        /// <param name="transactionId">The id of the transaction</param>
        /// <param name="data">The transaction to update</param>
        /// <returns></returns>
        [Put("/budgets/{budgetId}/transactions/{transactionId}")]
        Task<ResponseData.ApiResponse<TransactionData>> PutTransaction(string budgetId, string transactionId, [Body] SaveTransactionWrapper data);

        #region GetAccountTransactions
        /// <summary>
        /// Returns all transactions for a specified account
        /// </summary>
        /// <param name="budgetId">The id of the budget. “last-used” can be used to specify the last used budget and “default” can be used if default budget selection is enabled (see: https://api.youneedabudget.com/#oauth-default-budget).</param>
        /// <param name="accountId">The id of the account</param>
        /// <param name="sinceDate">If specified, only transactions on or after this date will be included. The date should be ISO formatted (e.g. 2016-12-30).</param>
        /// <param name="type">If specified, only transactions of the specified type will be included. “uncategorized” and “unapproved” are currently supported.</param>
        /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since last_knowledge_of_server will be included.</param>
        /// <returns></returns>
        [Get("/budgets/{budgetId}/accounts/{accountId}/transactions")]
        Task<ResponseData.ApiResponse<TransactionsData>> GetAccountTransactions(
            string budgetId, 
            string accountId,
            [Query(Format = "yyyy-MM-dd")][AliasAs("since_date")] DateTime sinceDate,
            [Query] string type,
            [Query][AliasAs("last_knowledge_of_server")] Int64 lastKnowledgeOfServer
        );


        /// <inheritdoc cref="GetAccountTransactions(string, string, DateTime, string, long)"/>
        [Get("/budgets/{budgetId}/accounts/{accountId}/transactions")]
        Task<ResponseData.ApiResponse<TransactionsData>> GetAccountTransactions(
            string budgetId,
            string accountId
        );


        /// <inheritdoc cref="GetAccountTransactions(string, string, DateTime, string, long)"/>
        [Get("/budgets/{budgetId}/accounts/{accountId}/transactions")]
        Task<ResponseData.ApiResponse<TransactionsData>> GetAccountTransactions(
            string budgetId,
            string accountId,
            [Query(Format = "yyyy-MM-dd")][AliasAs("since_date")] DateTime sinceDate
        );


        /// <inheritdoc cref="GetAccountTransactions(string, string, DateTime, string, long)"/>
        [Get("/budgets/{budgetId}/accounts/{accountId}/transactions")]
        Task<ResponseData.ApiResponse<TransactionsData>> GetAccountTransactions(
            string budgetId,
            string accountId,
            [Query] string type
        );


        /// <inheritdoc cref="GetAccountTransactions(string, string, DateTime, string, long)"/>
        [Get("/budgets/{budgetId}/accounts/{accountId}/transactions")]
        Task<ResponseData.ApiResponse<TransactionsData>> GetAccountTransactions(
            string budgetId,
            string accountId,
            [Query(Format = "yyyy-MM-dd")][AliasAs("since_date")] DateTime sinceDate,
            [Query] string type
        );


        /// <inheritdoc cref="GetAccountTransactions(string, string, DateTime, string, long)"/>
        [Get("/budgets/{budgetId}/accounts/{accountId}/transactions")]
        Task<ResponseData.ApiResponse<TransactionsData>> GetAccountTransactions(
            string budgetId,
            string accountId,
            [Query][AliasAs("last_knowledge_of_server")] Int64 lastKnowledgeOfServer
        );


        /// <inheritdoc cref="GetAccountTransactions(string, string, DateTime, string, long)"/>
        [Get("/budgets/{budgetId}/accounts/{accountId}/transactions")]
        Task<ResponseData.ApiResponse<TransactionsData>> GetAccountTransactions(
            string budgetId,
            string accountId,
            [Query(Format = "yyyy-MM-dd")][AliasAs("since_date")] DateTime sinceDate,
            [Query][AliasAs("last_knowledge_of_server")] Int64 lastKnowledgeOfServer
        );


        /// <inheritdoc cref="GetAccountTransactions(string, string, DateTime, string, long)"/>
        [Get("/budgets/{budgetId}/accounts/{accountId}/transactions")]
        Task<ResponseData.ApiResponse<TransactionsData>> GetAccountTransactions(
            string budgetId,
            string accountId,
            [Query] string type,
            [Query][AliasAs("last_knowledge_of_server")] Int64 lastKnowledgeOfServer
        );
        #endregion


        #region GetCategoryTransactions
        /// <summary>
        /// Returns all transactions for a specified category
        /// </summary>
        /// <param name="budgetId">The id of the budget. “last-used” can be used to specify the last used budget and “default” can be used if default budget selection is enabled (see: https://api.youneedabudget.com/#oauth-default-budget).</param>
        /// <param name="categoryId">The id of the category</param>
        /// <param name="sinceDate">If specified, only transactions on or after this date will be included. The date should be ISO formatted (e.g. 2016-12-30).</param>
        /// <param name="type">If specified, only transactions of the specified type will be included. “uncategorized” and “unapproved” are currently supported.</param>
        /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since last_knowledge_of_server will be included.</param>
        /// <returns></returns>
        [Get("/budgets/{budgetId}/categories/{categoryId}/transactions")]
        Task<ResponseData.ApiResponse<HybridTransactionsData>> GetCategoryTransactions(
            string budgetId,
            string categoryId,
            [Query(Format = "yyyy-MM-dd")][AliasAs("since_date")] DateTime sinceDate,
            [Query] string type,
            [Query][AliasAs("last_knowledge_of_server")] Int64 lastKnowledgeOfServer
        );


        /// <inheritdoc cref="GetCategoryTransactions(string, string, DateTime, string, long)"/>
        [Get("/budgets/{budgetId}/categories/{categoryId}/transactions")]
        Task<ResponseData.ApiResponse<HybridTransactionsData>> GetCategoryTransactions(
            string budgetId,
            string categoryId,
            [Query(Format = "yyyy-MM-dd")][AliasAs("since_date")] DateTime sinceDate
        );


        /// <inheritdoc cref="GetCategoryTransactions(string, string, DateTime, string, long)"/>
        [Get("/budgets/{budgetId}/categories/{categoryId}/transactions")]
        Task<ResponseData.ApiResponse<HybridTransactionsData>> GetCategoryTransactions(
            string budgetId,
            string categoryId,
            [Query] string type
        );


        /// <inheritdoc cref="GetCategoryTransactions(string, string, DateTime, string, long)"/>
        [Get("/budgets/{budgetId}/categories/{categoryId}/transactions")]
        Task<ResponseData.ApiResponse<HybridTransactionsData>> GetCategoryTransactions(
            string budgetId,
            string categoryId,
            [Query(Format = "yyyy-MM-dd")][AliasAs("since_date")] DateTime sinceDate,
            [Query] string type
        );


        /// <inheritdoc cref="GetCategoryTransactions(string, string, DateTime, string, long)"/>
        [Get("/budgets/{budgetId}/categories/{categoryId}/transactions")]
        Task<ResponseData.ApiResponse<HybridTransactionsData>> GetCategoryTransactions(
            string budgetId,
            string categoryId,
            [Query][AliasAs("last_knowledge_of_server")] Int64 lastKnowledgeOfServer
        );


        /// <inheritdoc cref="GetCategoryTransactions(string, string, DateTime, string, long)"/>
        [Get("/budgets/{budgetId}/categories/{categoryId}/transactions")]
        Task<ResponseData.ApiResponse<HybridTransactionsData>> GetCategoryTransactions(
            string budgetId,
            string categoryId,
            [Query(Format = "yyyy-MM-dd")][AliasAs("since_date")] DateTime sinceDate,
            [Query][AliasAs("last_knowledge_of_server")] Int64 lastKnowledgeOfServer
        );


        /// <inheritdoc cref="GetCategoryTransactions(string, string, DateTime, string, long)"/>
        [Get("/budgets/{budgetId}/categories/{categoryId}/transactions")]
        Task<ResponseData.ApiResponse<HybridTransactionsData>> GetCategoryTransactions(
            string budgetId,
            string categoryId,
            [Query] string type,
            [Query][AliasAs("last_knowledge_of_server")] Int64 lastKnowledgeOfServer
        );
        #endregion


        #region GetPayeeTransactions
        /// <summary>
        /// Returns all transactions for a specified payee
        /// </summary>
        /// <param name="budgetId">The id of the budget. “last-used” can be used to specify the last used budget and “default” can be used if default budget selection is enabled (see: https://api.youneedabudget.com/#oauth-default-budget).</param>
        /// <param name="payeeId">The id of the payee</param>
        /// <param name="sinceDate">If specified, only transactions on or after this date will be included. The date should be ISO formatted (e.g. 2016-12-30).</param>
        /// <param name="type">If specified, only transactions of the specified type will be included. “uncategorized” and “unapproved” are currently supported.</param>
        /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since last_knowledge_of_server will be included.</param>
        /// <returns></returns>
        [Get("/budgets/{budgetId}/payees/{payeeId}/transactions")]
        Task<ResponseData.ApiResponse<HybridTransactionsData>> GetPayeeTransactions(
            string budgetId,
            string payeeId,
            [Query(Format = "yyyy-MM-dd")][AliasAs("since_date")] DateTime sinceDate,
            [Query] string type,
            [Query][AliasAs("last_knowledge_of_server")] Int64 lastKnowledgeOfServer
        );


        /// <inheritdoc cref="GetPayeeTransactions(string, string, DateTime, string, long)"/>
        [Get("/budgets/{budgetId}/payees/{payeeId}/transactions")]
        Task<ResponseData.ApiResponse<HybridTransactionsData>> GetPayeeTransactions(
            string budgetId,
            string payeeId,
            [Query(Format = "yyyy-MM-dd")][AliasAs("since_date")] DateTime sinceDate
        );


        /// <inheritdoc cref="GetPayeeTransactions(string, string, DateTime, string, long)"/>
        [Get("/budgets/{budgetId}/payees/{payeeId}/transactions")]
        Task<ResponseData.ApiResponse<HybridTransactionsData>> GetPayeeTransactions(
            string budgetId,
            string payeeId,
            [Query] string type
        );


        /// <inheritdoc cref="GetPayeeTransactions(string, string, DateTime, string, long)"/>
        [Get("/budgets/{budgetId}/payees/{payeeId}/transactions")]
        Task<ResponseData.ApiResponse<HybridTransactionsData>> GetPayeeTransactions(
            string budgetId,
            string payeeId,
            [Query(Format = "yyyy-MM-dd")][AliasAs("since_date")] DateTime sinceDate,
            [Query] string type
        );


        /// <inheritdoc cref="GetPayeeTransactions(string, string, DateTime, string, long)"/>
        [Get("/budgets/{budgetId}/payees/{payeeId}/transactions")]
        Task<ResponseData.ApiResponse<HybridTransactionsData>> GetPayeeTransactions(
            string budgetId,
            string payeeId,
            [Query][AliasAs("last_knowledge_of_server")] Int64 lastKnowledgeOfServer
        );


        /// <inheritdoc cref="GetPayeeTransactions(string, string, DateTime, string, long)"/>
        [Get("/budgets/{budgetId}/payees/{payeeId}/transactions")]
        Task<ResponseData.ApiResponse<HybridTransactionsData>> GetPayeeTransactions(
            string budgetId,
            string payeeId,
            [Query(Format = "yyyy-MM-dd")][AliasAs("since_date")] DateTime sinceDate,
            [Query][AliasAs("last_knowledge_of_server")] Int64 lastKnowledgeOfServer
        );


        /// <inheritdoc cref="GetPayeeTransactions(string, string, DateTime, string, long)"/>
        [Get("/budgets/{budgetId}/payees/{payeeId}/transactions")]
        Task<ResponseData.ApiResponse<HybridTransactionsData>> GetPayeeTransactions(
            string budgetId,
            string payeeId,
            [Query] string type,
            [Query][AliasAs("last_knowledge_of_server")] Int64 lastKnowledgeOfServer
        );
        #endregion
        #endregion


        #region Scheduled Transactions
        /// <summary>
        /// Returns all scheduled transactions
        /// </summary>
        /// <param name="budgetId">The id of the budget. “last-used” can be used to specify the last used budget and “default” can be used if default budget selection is enabled (see: https://api.youneedabudget.com/#oauth-default-budget).</param>
        /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since last_knowledge_of_server will be included.</param>
        /// <returns></returns>
        [Get("/budgets/{budgetId}/scheduled_transactions")]
        Task<ResponseData.ApiResponse<ScheduledTransactionsData>> GetScheduledTransactions(string budgetId, [Query][AliasAs("last_knowledge_of_server")] Int64 lastKnowledgeOfServer);


        /// <inheritdoc cref="GetScheduledTransaction(string, long)"/>
        [Get("/budgets/{budgetId}/scheduled_transactions")]
        Task<ResponseData.ApiResponse<ScheduledTransactionsData>> GetScheduledTransactions(string budgetId);


        /// <summary>
        /// Returns a single scheduled transaction
        /// </summary>
        /// <param name="budgetId">The id of the budget. “last-used” can be used to specify the last used budget and “default” can be used if default budget selection is enabled (see: https://api.youneedabudget.com/#oauth-default-budget).</param>
        /// <param name="scheduledTransactionId">The id of the scheduled transaction</param>
        /// <returns></returns>
        [Get("/budgets/{budgetId}/scheduled_transactions/{scheduledTransactionId}")]
        Task<ResponseData.ApiResponse<ScheduledTransactionData>> GetScheduledTransaction(string budgetId, string scheduledTransactionId);
        #endregion

    }
}
