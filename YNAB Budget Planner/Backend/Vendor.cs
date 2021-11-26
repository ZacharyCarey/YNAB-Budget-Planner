using YNAB_Budget_Planner.Backend.Saving;
using JsonSerializable;
using System;
using System.Collections.Generic;
using System.Linq;

namespace YNAB_Budget_Planner.Backend {
	public class Vendor : IJsonSerializable {

		/// <summary>
		/// The "Common Name" used by the user. For example, "PNC Bank"
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// A list of statement name aliases. 
		/// For example, Discover may show "Marathon 1234" but PNC will display "1234 Marathon" so both names should be listed here.
		/// </summary>
		public HashSet<string> Aliases { get; set; } = new HashSet<string>();

		/// <summary>
		/// If a vendor is 'ignored', it means that the particular statement will not be imported for processing.
		/// Effecitevly it's an "ignore and don't ask me again" option.
		/// </summary>
		public bool Ignored = false;

		/// <summary>
		/// The category the vendor is assigned to (utilities, entertainment, etc.). This allows for better cost breakdown and budgeting.
		/// </summary>
		public string Category = null;

		/// <summary>
		/// When true, if income is imported from a file for this vendor, the user will not be prompted and will automatically count towards monthly income.
		/// If false and there is a payment from this vendor, the user will be prompted asking if it should count towards the monthly income.
		/// </summary>
		public AllowIncomeType AllowIncome = AllowIncomeType.No;

		public Budget LinkedBudget = null;

		// Used during loading to link to the correct budget
		public uint? BudgetUID;

		public Vendor() {
			Name = null;
		}

		public Vendor(string name, bool ignored = false, string category = null, AllowIncomeType allowIncome = AllowIncomeType.No, Budget linkedBudget = null) {
			this.Name = name;
			this.Ignored = ignored;
			this.Category = category;
			this.AllowIncome = allowIncome;
			this.LinkedBudget = linkedBudget;
		}

		public void LoadFromJson(JsonData Data) {
			JsonObject data = (JsonObject)Data;
			{
				this.Name = (JsonString)data["Name"];

				SerializableList<JsonString> aliasList = new SerializableList<JsonString>();
				aliasList.LoadFromJson(data["Aliases"]);
				this.Aliases = new HashSet<string>(aliasList.Select(x => x.Value));
				this.Ignored = (bool)(JsonBool)(data["Ignored"]);
				this.Category = (string)(JsonString)(data["Category"]);
				this.AllowIncome = AllowIncomeUtils.Parse((string)(JsonString)data["Income Source"]);

				JsonData budgetData = data["Budget UID"];
				this.BudgetUID = null;
				if(budgetData != null && budgetData is JsonInteger budgetID) {
					this.BudgetUID = (uint)(long)budgetID;
				}
			}
		}

		public JsonData SaveToJson() {
			JsonObject data = new JsonObject();
			{
				data["Name"] = (JsonString)Name;
				data["Aliases"] = new SerializableList<JsonString>(Aliases.Select(x => new JsonString(x))).SaveToJson();
				data["Ignored"] = (JsonBool)Ignored;
				data["Category"] = (JsonString)Category;
				data["Income Source"] = (JsonString)AllowIncomeUtils.GetString(AllowIncome);
				if (LinkedBudget != null) {
					data["Budget UID"] = (JsonInteger)(long)LinkedBudget.UID;
				}
			}
			return data;
		}

		/*public static Vendor FindFromAlias(string alias, AppData settings) {
			foreach(Vendor vendor in settings.Vendors.Values) {
				if (vendor.Aliases.Contains(alias)) {
					return vendor;
				}
			}
			return null;
		}*/

		public override string ToString() {
			return this.Name;
		}
	}
}
