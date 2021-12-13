using Common;
using Common.MoneyUtils;
using Common.Saving;
using Desktop_Budget_Planner.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_Budget_Planner.Forms {
	public partial class IncomeSettingsForm : Form {

		private IAppData settings;

		public IncomeSettingsForm(IAppData settings) {
			InitializeComponent();
			this.settings = settings;
			new MoneyTextBoxUtils(YearlySalaryTextBox).OnTextChanged += (TextBox sender, string NewText) => UpdateSalaryLabels(NewText, IncomeFrequency.Yearly);
			new MoneyTextBoxUtils(MonthlySalaryTextBox).OnTextChanged += (TextBox sender, string NewText) => UpdateSalaryLabels(NewText, IncomeFrequency.Monthly);
			new MoneyTextBoxUtils(WeeklySalaryTextBox).OnTextChanged += (TextBox sender, string NewText) => UpdateSalaryLabels(NewText, IncomeFrequency.Weekly);
		}

		private void IncomeSettingsForm_Load(object sender, EventArgs e) {
			GrossIncome income = settings.Settings.Income;
			if (income != null) {
				if (income.SalaryFrequency == IncomeFrequency.Yearly) {
					YearlySalaryRadioBtn.PerformClick();
					YearlySalaryTextBox.Text = income.Salary.ToString();
				} else if (income.SalaryFrequency == IncomeFrequency.Monthly) {
					MonthlySalaryRadioBtn.PerformClick();
					MonthlySalaryTextBox.Text = income.Salary.ToString();
				} else if (income.SalaryFrequency == IncomeFrequency.Weekly) {
					WeeklySalaryRadioBtn.PerformClick();
					WeeklySalaryTextBox.Text = income.Salary.ToString();
				} else {
					throw new ArgumentException("SelectedSalaryType was an unknown state.");
				}

				if (income.IncomeFrequency == IncomeFrequency.Weekly) {
					WeeklyRadioBtn.PerformClick();
					WeeklyDaySelector.SelectedValue = income.OnEveryDayOfWeek.ToString();
				} else if (income.IncomeFrequency == IncomeFrequency.BiWeekly) {
					BiWeeklyRadioBtn.PerformClick();
					BiWeeklyDaySelector.SelectedValue = income.OnEveryDayOfWeek.ToString();
					BiWeeklyDatePicker.Value = income.StartingOn;
				} else if (income.IncomeFrequency == IncomeFrequency.SemiMonthly) {
					SemiMonthlyRadioBtn.PerformClick();
					SemiMonthlyFirstDaySelector.Value = income.StartingOn.Day;
					if (income.SecondPayment <= 31) {
						SemiMonthlySecondDayRadioBtn.PerformClick();
						SemiMonthlySecondDaySelector.Value = income.SecondPayment;
					} else {
						SemiMonthlyLastDayRadioBtn.PerformClick();
					}
					AdjustWeekendsCheckBox.Checked = income.AdjustToWeekends;
				} else if (income.IncomeFrequency == IncomeFrequency.Monthly) {
					MonthlyRadioBtn.PerformClick();
					MonthlyDayPicker.Value = income.StartingOn.Day;
				} else {
					throw new ArgumentException("IncomeFrequency was an unknown state.");
				}
			}
		}

		private void UpdateSalaryLabels(string input, IncomeFrequency frequency) {
			Money money;
			if (!Money.TryParse(input, out money)) {
				money = new Money();
			}

			//Transform our input into the yearly amount
			if (frequency == IncomeFrequency.Monthly) {
				money *= 12;
			} else if (frequency == IncomeFrequency.Weekly) {
				money *= 52;
			} else if (frequency != IncomeFrequency.Yearly) {
				money = new Money();
			}

			YearlySalaryLabel.Text = money.ToString(true, true);
			MonthlySalaryLabel.Text = (money / 12).ToString(true, true);
			WeeklySalaryLabel.Text = (money / 52).ToString(true, true);
			HourlySalaryLabel.Text = (money / 2080).ToString(true, true);
		}

		private void SetWeeklyState(bool enabled) {
			WeeklyLabel1.Enabled = enabled;
			WeeklyDaySelector.Enabled = enabled;
		}

		private void WeeklyRadioBtn_CheckedChanged(object sender, EventArgs e) {
			SetWeeklyState(WeeklyRadioBtn.Checked);
		}

		private void SetBiWeeklyState(bool enabled) {
			BiWeeklyLabel1.Enabled = enabled;
			BiWeeklyLabel2.Enabled = enabled;
			BiWeeklyDaySelector.Enabled = enabled;
			BiWeeklyDatePicker.Enabled = enabled;
		}

		private void BiWeeklyRadioBtn_CheckedChanged(object sender, EventArgs e) {
			SetBiWeeklyState(BiWeeklyRadioBtn.Checked);
		}

		private void SetSemiMonthlyState(bool enabled) {
			SemiMonthlyLabel1.Enabled = enabled;
			SemiMonthlyLabel2.Enabled = enabled;
			SemiMonthlyLabel3.Enabled = enabled;
			SemiMonthlyLabel4.Enabled = enabled;
			SemiMonthlyFirstDaySelector.Enabled = enabled;
			SemiMonthlySecondDayRadioBtn.Enabled = enabled;
			SemiMonthlyLastDayRadioBtn.Enabled = enabled;
			SemiMonthlySecondDaySelector.Enabled = enabled;
		}

		private void SemiMonthlyRadioBtn_CheckedChanged(object sender, EventArgs e) {
			SetSemiMonthlyState(SemiMonthlyRadioBtn.Checked);
		}

		private void SetMonthlyState(bool enabled) {
			MonthlyLabel1.Enabled = enabled;
			MonthlyLabel2.Enabled = enabled;
			MonthlyDayPicker.Enabled = enabled;
		}

		private void MonthlyRadioBtn_CheckedChanged(object sender, EventArgs e) {
			SetMonthlyState(MonthlyRadioBtn.Checked);
		}

		private void SaveBtn_Click(object sender, EventArgs e) {
			GrossIncome income = new GrossIncome();
			if (YearlySalaryRadioBtn.Checked) {
				Money money;
				if (Money.TryParse(YearlySalaryTextBox.Text, out money)) {
					income.SalaryFrequency = IncomeFrequency.Yearly;
					income.Salary = money;
				} else {
					MessageBox.Show("Please enter a valid salary.");
					return;
				}
			} else if (MonthlySalaryRadioBtn.Checked) {
				Money money;
				if (Money.TryParse(MonthlySalaryTextBox.Text, out money)) {
					income.SalaryFrequency = IncomeFrequency.Monthly;
					income.Salary = money;
				} else {
					MessageBox.Show("Please enter a valid salary.");
					return;
				}
			} else if (WeeklySalaryRadioBtn.Checked) {
				Money money;
				if (Money.TryParse(WeeklySalaryTextBox.Text, out money)) {
					income.SalaryFrequency = IncomeFrequency.Weekly;
					income.Salary = money;
				} else {
					MessageBox.Show("Please enter a valid salary.");
					return;
				}
			} else {
				MessageBox.Show("Please select an valid salary frequency.");
				return;
			}

			if (WeeklyRadioBtn.Checked) {
				income.IncomeFrequency = IncomeFrequency.Weekly;
				DayOfWeek day;
				if (Enum.TryParse<DayOfWeek>(WeeklyDaySelector.Text, out day)) {
					income.OnEveryDayOfWeek = day;
				} else {
					MessageBox.Show("Please select a valid day of the week.");
					return;
				}
			} else if (BiWeeklyRadioBtn.Checked) {
				income.IncomeFrequency = IncomeFrequency.BiWeekly;
				DayOfWeek day;
				if (Enum.TryParse<DayOfWeek>(WeeklyDaySelector.Text, out day)) {
					income.OnEveryDayOfWeek = day;
				} else {
					MessageBox.Show("Please select a valid day of the week.");
					return;
				}
				DateTime date = BiWeeklyDatePicker.Value;
				income.StartingOn = date;
				if (date.DayOfWeek != day) {
					MessageBox.Show("The starting date must match the selected day of the week.");
					return;
				}
			} else if (SemiMonthlyRadioBtn.Checked) {
				income.IncomeFrequency = IncomeFrequency.SemiMonthly;
				income.StartingOn = new DateTime(1, 1, decimal.ToInt32(SemiMonthlyFirstDaySelector.Value));
				if (SemiMonthlySecondDayRadioBtn.Checked) {
					income.SecondPayment = decimal.ToInt32(SemiMonthlySecondDaySelector.Value);
				} else if (SemiMonthlyLastDayRadioBtn.Checked) {
					income.SecondPayment = 32; //Anything  >31 is considered the last day of the month.
				} else {
					MessageBox.Show("Please choose a valid second payment date.");
					return;
				}
				if (income.StartingOn.Day >= income.SecondPayment) {
					MessageBox.Show("Please choose a valid first and second payment date. The second payment should be on a day after the first payment.");
					return;
				}
				income.AdjustToWeekends = AdjustWeekendsCheckBox.Checked;
			} else if (MonthlyRadioBtn.Checked) {
				income.IncomeFrequency = IncomeFrequency.Monthly;
				income.StartingOn = new DateTime(1, 1, decimal.ToInt32(MonthlyDayPicker.Value));
			} else {
				MessageBox.Show("Please select an income frequency.");
				return;
			}

			settings.Settings.Income = income;
			settings.Save();
			MessageBox.Show("Income successfully saved.");
		}

		private void YearlySalaryRadioBtn_CheckedChanged(object sender, EventArgs e) {
			YearlySalaryTextBox.Enabled = YearlySalaryRadioBtn.Checked;
		}

		private void MonthlySalaryRadioBtn_CheckedChanged(object sender, EventArgs e) {
			MonthlySalaryTextBox.Enabled = MonthlySalaryRadioBtn.Checked;
		}

		private void WeeklySalaryRadioBtn_CheckedChanged(object sender, EventArgs e) {
			WeeklySalaryTextBox.Enabled = WeeklySalaryRadioBtn.Checked;
		}

		private void YearlySalaryTextBox_TextChanged(object sender, EventArgs e) {

		}

		private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e) {

		}
	}
}
