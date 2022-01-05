using Common.InteractiveCharts.Data.GroupedData;
using Common.MoneyUtils;
using Common.Saving;
using JsonSerializable;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Common {
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

		public static Money CalculateAverageDeductions(IAppData appData, GroupCategory graph = null) {
			GrossIncome income = appData.Settings.Income;
			IEnumerable<IncomeDeduction> deductions = appData.Settings.Deductions;

			// First calculate the number of received paychecks in a year, for per-paycheck deductions
			int numberOfPaychecks = 0;
			if (income.IncomeFrequency == IncomeFrequency.Yearly) {
				numberOfPaychecks = 1;
			} else if (income.IncomeFrequency == IncomeFrequency.Monthly) {
				numberOfPaychecks = 12;
			} else if (income.IncomeFrequency == IncomeFrequency.SemiMonthly) {
				numberOfPaychecks = 24;
			} else if (income.IncomeFrequency == IncomeFrequency.BiWeekly) {
				numberOfPaychecks = 26;
			} else if (income.IncomeFrequency == IncomeFrequency.Weekly) {
				numberOfPaychecks = 52;
			} else {
				throw new InvalidOperationException("Unknown IncomeFrequency enum [" + income.IncomeFrequency.ToString() + "]");
			}

			// Now we can total the deductions for an entire year.
			Money budget = new Money(); //Budget budget = new Budget("Deductions");
			foreach (IncomeDeduction deduction in deductions) {
				Money deductionAmount;
				if (deduction.Frequency == DeductionFrequency.Monthly) {
					deductionAmount = deduction.Amount * 12;
				} else if (deduction.Frequency == DeductionFrequency.PerPaycheck) {
					deductionAmount = deduction.Amount * numberOfPaychecks;
				} else {
					throw new ArgumentOutOfRangeException("Invalid enum: " + deduction.Frequency.ToString());
				}

				// Average the yearly amount to get the monthly average
				deductionAmount /= 12;
				budget += deductionAmount; //budget.Add(new Budget(deduction.Name, deductionAmount));
				if(graph != null) {
					graph.Add(deduction.Name, (int)deductionAmount.AsLong());
                }
			}

			return budget; //budget.Amount; //RootData.Add(budget, false);
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

