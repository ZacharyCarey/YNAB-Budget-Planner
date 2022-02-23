using Common.Goals;
using JsonSerializable;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Saving {
	public class AppData : IJsonSerializable {

		internal AppData() { }

		/*private static readonly string AvailableIncomeCategory = "Available Income";
		public static readonly HashSet<string> ReservedCategories = new HashSet<string>() {
			AvailableIncomeCategory
		};*/

		//public SerializableDictionary<Vendor> Vendors { get; set; } = new SerializableDictionary<Vendor>();
		//public HashSet<string> Categories { get; set; } = new HashSet<string>();
		public GrossIncome? Income { get; set; } = null;
		public SerializableList<IncomeDeduction> Deductions { get; set; } = new SerializableList<IncomeDeduction>();
		//public Budget Budgets { get; set; } = new Budget("Budgets");

		//public Dictionary<uint, Budget> BudgetUidLookup = new Dictionary<uint, Budget>(); 

		/*private void StoreBudgetUIDs(Budget budget) {
			BudgetUidLookup.Add(budget.UID, budget);
			foreach(Budget child in budget) {
				StoreBudgetUIDs(child);
			}
		}*/
		public string? YnabApiToken { get; set; } = null;

		public Dictionary<string, Goal> Goals = new Dictionary<string, Goal>();

		public void LoadFromJson(JsonData Data) {
			JsonObject data = (JsonObject)Data;
			{
				// Budgets MUST be loaded before Vendors to load links correctly
/*				BudgetUidLookup.Clear();
				Budgets = new Budget("Budgets");
				try {
					Budgets.LoadFromJson(data["Budgets"]);
				} catch (Exception) {
					Budgets = new Budget("Budgets");
				}
				StoreBudgetUIDs(Budgets);

				Vendors.Clear();
				SerializableList<Vendor> vendors = new SerializableList<Vendor>();
				vendors.LoadFromJson(data["Vendors"]);
				foreach (Vendor vendor in vendors) {
					Vendors[vendor.Name] = vendor;
					if (vendor.Category != null && !ReservedCategories.Contains(vendor.Category))
						Categories.Add(vendor.Category);

					if(vendor.BudgetUID != null) {
						vendor.LinkedBudget = BudgetUidLookup[(uint)vendor.BudgetUID];
					}
				}
*/
				JsonData IncomeData = data["Income"];
				if (IncomeData == null) {
					Income = null;
				} else {
					Income = new GrossIncome();
					Income.LoadFromJson(IncomeData);
				}

				Deductions = new SerializableList<IncomeDeduction>();
				try {
					Deductions.LoadFromJson(data["Deductions"]);
					Deductions.Sort(new IncomeDeductionComparer());
				} catch (Exception) {
					Deductions = new SerializableList<IncomeDeduction>();
				}

				try {
					YnabApiToken = (JsonString)data["YNAB API Token"];
				} catch (Exception) {
					YnabApiToken = null;
				}

                // Load goals
                try {
					Goals = new Dictionary<string, Goal>();
					foreach(var goal in ((JsonObject)data["Goals"]).Items) {
						Goals[goal.Key] = Goal.ParseFromJson(goal.Value);
                    }
                } catch (Exception) {
					Goals = new Dictionary<string, Goal>();
                }
			}
		}

		private uint ApplyUID(uint nextUid, Budget nextBudget) {
			checked { // Check for the UID overflowing / running out of numbers
				nextBudget.UID = nextUid++;
			}
			foreach (Budget child in nextBudget) {
				nextUid = ApplyUID(nextUid, child);
			}

			return nextUid;
		}

		public JsonData SaveToJson() {
			JsonObject data = new JsonObject();
			{
				// Assign a Unique ID to budgets to save vendor/budget links
				//ApplyUID(0, Budgets);

				//data["Vendors"] = new SerializableList<Vendor>(Vendors.Values).SaveToJson();
				data["Income"] = Income?.SaveToJson();
				data["Deductions"] = Deductions.SaveToJson();
				//data["Budgets"] = Budgets.SaveToJson();
				data["YNAB API Token"] = (JsonString)YnabApiToken;

				// Save goals
				JsonObject goalsData = new JsonObject();
				foreach(var goal in Goals) {
					goalsData[goal.Key] = goal.Value.SaveToJson();
                }
				data["Goals"] = goalsData;
			}
			return data;
		}
	}
}
