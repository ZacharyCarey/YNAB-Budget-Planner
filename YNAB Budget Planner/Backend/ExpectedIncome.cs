using YNAB_Budget_Planner.Backend;
using YNAB_Budget_Planner.Backend.MoneyUtils;
using System;
using System.Collections.Generic;
using System.Text;

namespace YNAB_Budget_Planner.Backend {

	/// <summary>
	/// Used to calculate the amount of income that is expected in the given month.
	/// Ex: A monthly salary can expect the same amount each month
	/// Ex: A weekly salary might fluctuate depending on how many Wednesdays are in the month
	/// (assuming Wednesday is payday)
	/// </summary>
	public static class ExpectedIncome {

		/// <summary>
		/// <paramref name="month"/> should be on the first of the month and include the year to correctly calculate for certain income frequencies.
		/// </summary>
		/// <param name="income"></param>
		/// <param name="month"></param>
		/// <returns></returns>
		public static Money Calculate(DateTime month, GrossIncome income, IEnumerable<IncomeDeduction> deductions) {
			(Money salary, int numberOfPaychecks) = CalculateSalary(month, income);
			Money deduction = CalculateDeductions(deductions, numberOfPaychecks, 1);

			return salary - deduction;
		}

		/// <summary>
		/// <paramref name="month"/> should be on the first of the month and include the year to correctly calculate for certain income frequencies.
		/// </summary>
		/// <param name="income"></param>
		/// <param name="month"></param>
		/// <returns></returns>
		private static (Money salary, int numberOfPaychecks) CalculateSalary(DateTime month, GrossIncome income) {
			switch (income.IncomeFrequency) {
				case IncomeFrequency.Yearly: return CalculateYearlySalary(month, income);
				case IncomeFrequency.Monthly: return CalculateMonthlySalary(month, income);
				case IncomeFrequency.SemiMonthly: return CalculateSemiMonthlySalary(month, income);
				case IncomeFrequency.BiWeekly: return CalculateBiWeeklySalary(month, income);
				case IncomeFrequency.Weekly: return CalculateWeeklySalary(month, income);
				default:
					throw new InvalidOperationException("Unknown IncomeFrequency enum [" + income.IncomeFrequency.ToString() + "]");
			}
		}

		private static (Money salary, int numberOfPaychecks) CalculateYearlySalary(DateTime month, GrossIncome income) {
			//TODO technically not supported, so we are going to cheat this one.
			return (income.YearlySalary / 12, 1);
		}

		private static (Money salary, int numberOfPaychecks) CalculateMonthlySalary(DateTime month, GrossIncome income) {
			//Didn't really need its own function, be the others have their own functions so
			//I didn't want it to feel left out.
			return (income.YearlySalary / 12, 1);
		}

		private static (Money salary, int numberOfPaychecks) CalculateSemiMonthlySalary(DateTime month, GrossIncome income) {
			//Semi monthly is easy, since there are always two payments a month
			return (income.YearlySalary / 12, 2);
		}

		private static (Money salary, int numberOfPaychecks) CalculateBiWeeklySalary(DateTime month, GrossIncome income) {
			DateTime startDate = income.StartingOn;
			//They should be the same, but we are going to find the first offurance of the day just to be safe.
			while (startDate.DayOfWeek != income.OnEveryDayOfWeek) {
				startDate.AddDays(1);
			}

			//Now with our starting date, find the first alternate week / payday of the month
			int days = (int)(month - startDate).TotalDays;
			int rem = days % 14;
			DateTime AlternateWeek = month.AddDays((14 - rem) % 14);

			//Find number of pay-days in the month
			int paydays = 0; 
			while(AlternateWeek.Month == month.Month) {
				paydays++;
				AlternateWeek.AddDays(14);
			}

			//Calculate how month money is made bi-weekly
			Money salary = income.YearlySalary / 26; //26 = 52 / 2

			return (salary * paydays, paydays);
		}

		private static (Money salary, int numberOfPaychecks) CalculateWeeklySalary(DateTime month, GrossIncome income) {
			//Find the first payday of the month
			DateTime date = month; //We assume the given date is the correct year on the first of the month.
			while(date.DayOfWeek != income.OnEveryDayOfWeek) {
				date.AddDays(1);
			}

			int paydays = 0;
			while(date.Month == month.Month) {
				paydays++;
				date.AddDays(7);
			}

			//Calculate how much money is made each week
			Money salary = income.YearlySalary / 52;

			return (salary * paydays, paydays);
		}

		private static Money CalculateDeductions(IEnumerable<IncomeDeduction> deductions, int numberOfPaychecks, int numberOfMonths) {
			Money total = new Money();
			foreach(IncomeDeduction deduction in deductions) {
				if (deduction.Frequency == DeductionFrequency.Monthly) {
					total += deduction.Amount * numberOfMonths;
				}else if(deduction.Frequency == DeductionFrequency.PerPaycheck) {
					total += deduction.Amount * numberOfPaychecks;
				} else {
					throw new ArgumentOutOfRangeException("Invalid enum: " + deduction.Frequency.ToString());
				}
			}
			return total;
		}

	}
}
