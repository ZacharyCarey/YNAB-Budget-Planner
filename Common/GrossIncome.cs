using Common.MoneyUtils;
using JsonSerializable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Common {
	public class GrossIncome : IJsonSerializable {

		/// <summary>
		/// Ultimately determines how the other variables are treated.
		/// How often actual income payments are made.
		/// </summary>
		public IncomeFrequency IncomeFrequency { get; set; } = IncomeFrequency.Weekly;

		/// <summary>
		/// For "Weekly" or "Bi-Weekly", determines what day of the week the payment is made.
		/// </summary>
		public DayOfWeek OnEveryDayOfWeek { get; set; } = DayOfWeek.Monday;

		//TODO StartingOn is technically also needed for yearly income, for what day of the year payment is received
		/// <summary>
		/// For "Bi-Weekly", is used to determine which weeks (odd or even) the payments take place. 
		/// This date doesn't have to be the first, just has to be on any valid pay date to determine the week.
		/// 
		/// For "Semi-Monthly" or "Monthly", this is the day of the first (or only) payment received.
		/// </summary>
		public DateTime StartingOn { get; set; } = DateTime.MinValue;

		/// <summary>
		/// Used only for "Semi-Monthly", this value determines on what day the second payment of the month takes places.
		/// If the value is greater than the number of days in a given month, it is assumed to be the last day of the month instead.
		/// (i.e. set to 32 for always end of month)
		/// </summary>
		public int SecondPayment { get; set; } = 32;

		/// <summary>
		/// Used for "Semi-Monthly" (possibly more in the future), if the date falls on a weekend it is assumed that the previous business day is the actual day of payment.
		/// </summary>
		public bool AdjustToWeekends { get; set; } = false;

		/// <summary>
		/// Used to calculate yearly salary.
		/// For example, if salary = 1k and SalaryFrequency = Monthly, then yearly salary = 12k
		/// It's different than IncomeFrequency in that IncomeFrequency determine how often payments
		/// are being made, where as SalaryFrequency is just used to calculate how much is being made.
		/// </summary>
		public IncomeFrequency SalaryFrequency { get; set; } = IncomeFrequency.Yearly;

		/// <summary>
		/// The salary per salary frequency.
		/// </summary>
		public Money Salary { get; set; } = new Money();

		public Money YearlySalary { 
			get {
				if(SalaryFrequency == IncomeFrequency.Yearly) {
					return Salary;
				}else if(SalaryFrequency == IncomeFrequency.Monthly) {
					return Salary * 12;
				}else if(SalaryFrequency == IncomeFrequency.Weekly) {
					return Salary * 52;
				} else {
					throw new ArgumentException("SalaryFrequency was an invalid type.");
				}
			} 
		}

		public void LoadFromJson(JsonData Data) {
			JsonObject data = (JsonObject)Data;
			this.SalaryFrequency = Enum.Parse<IncomeFrequency>((JsonString)data["Salary Frequency"]);
			this.Salary = Money.LoadFromJsonData(data["Salary"]);
			this.IncomeFrequency = Enum.Parse<IncomeFrequency>((JsonString)data["Frequency"]);
			this.OnEveryDayOfWeek = Enum.Parse<DayOfWeek>((JsonString)data["Day of Week"]);
			this.StartingOn = DateTime.Parse((JsonString)data["Starting On"]);
			this.SecondPayment = (int)(JsonInteger)data["Second Payment"];
			this.AdjustToWeekends = (bool)(JsonBool)data["Adjust Weekends"];
		}

		public JsonData SaveToJson() {
			JsonObject data = new JsonObject();
			data["Salary Frequency"] = (JsonString)SalaryFrequency.ToString();
			data["Salary"] = Salary.SaveToJson();
			data["Frequency"] = (JsonString)IncomeFrequency.ToString();
			data["Day of Week"] = (JsonString)OnEveryDayOfWeek.ToString();
			data["Starting On"] = (JsonString)StartingOn.ToString();
			data["Second Payment"] = (JsonInteger)SecondPayment;
			data["Adjust Weekends"] = (JsonBool)AdjustToWeekends;
			return data;
		}

		public static GrossIncome Parse(JsonObject Data) {
			try {
				GrossIncome income = new GrossIncome();
				income.LoadFromJson(Data);
				return income;
			} catch (Exception) {
				return null;
			}
		}
	}

	public enum IncomeFrequency {
		[Description("Weekly")]
		Weekly,

		[Description("Bi-Weekly")]
		BiWeekly,

		[Description("Semi-Monthly")]
		SemiMonthly,

		[Description("Monthly")]
		Monthly,

		[Description("Yearly")]
		Yearly
	}
}
