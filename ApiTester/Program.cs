// See https://aka.ms/new-console-template for more information
using YNAB_Budget_Planner;
using YnabRestApi.ResponseData;

CategoriesData budget = Ynab.GetCategories();
Console.WriteLine(budget);