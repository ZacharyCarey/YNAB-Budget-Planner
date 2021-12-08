// See https://aka.ms/new-console-template for more information
using YNAB_Budget_Planner;
using YnabRestApi.Data;


BudgetData budget = Ynab.GetBudget();
Console.WriteLine(budget);