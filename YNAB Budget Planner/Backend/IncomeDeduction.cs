using YNAB_Budget_Planner.Backend.MoneyUtils;
using JsonSerializable;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace YNAB_Budget_Planner.Backend {
	public class IncomeDeduction : IJsonSerializable {

		public string Name;
		public Money Amount;
		public DeductionFrequency Frequency;

		public IncomeDeduction() {
		}

		public IncomeDeduction(string name) {
			this.Name = name;
		}

		public IncomeDeduction(string name, Money amount, DeductionFrequency frequency) {
			this.Name = name;
			this.Amount = amount;
			this.Frequency = frequency;
		}

		public JsonData SaveToJson() {
			JsonObject obj = new JsonObject();

			obj["Name"] = (JsonString)Name;
			obj["Amount"] = Amount.SaveToJson();
			obj["Frequency"] = (JsonString)Frequency.ToString();

			return obj;
		}

		public void LoadFromJson(JsonData Data) {
			JsonObject obj = (JsonObject)Data;

			Name = (JsonString)obj["Name"];
			Amount = Money.LoadFromJsonData(obj["Amount"]);
			Frequency = Enum.Parse<DeductionFrequency>((JsonString)obj["Frequency"]);
		}

		public override string ToString() {
			return Name;
		}

	}

	public enum DeductionFrequency {
		PerPaycheck,
		Monthly
	}

	public class IncomeDeductionComparer : IComparer<IncomeDeduction> {
		public int Compare([AllowNull] IncomeDeduction x, [AllowNull] IncomeDeduction y) {
			return string.Compare(x?.Name, y?.Name);
		}
	}

}

