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
	public partial class EditDeductionForm : Form {

		private readonly IncomeDeduction oldDeduction;
		private readonly IAppData settings;

		public EditDeductionForm(IAppData settings, IncomeDeduction editDeduction = null) {
			InitializeComponent();
			new MoneyTextBoxUtils(AmountTextBox);
			this.settings = settings;

			oldDeduction = editDeduction;
			if (editDeduction != null) {
				NameTextBox.Text = editDeduction.Name;
				AmountTextBox.Text = editDeduction.Amount.ToString(true);
				if (editDeduction.Frequency == DeductionFrequency.PerPaycheck) {
					PerPaycheckRadioBtn.Checked = true;
				} else if (editDeduction.Frequency == DeductionFrequency.Monthly) {
					MonthlyRadioBtn.Checked = true;
				} else {
					throw new InvalidEnumArgumentException("editDeduction.Frequency", (int)editDeduction.Frequency, typeof(DeductionFrequency));
				}
			}
		}
		private void EditDeductionForm_Load(object sender, EventArgs e) {

		}

		private void SaveBtn_Click(object sender, EventArgs e) {
			IncomeDeduction deduction = new IncomeDeduction(NameTextBox.Text);
			if (!Money.TryParse(AmountTextBox.Text, out deduction.Amount)) {
				MessageBox.Show("Please eneter a valid amount.");
				return;
			}

			if (PerPaycheckRadioBtn.Checked) {
				deduction.Frequency = DeductionFrequency.PerPaycheck;
			} else if (MonthlyRadioBtn.Checked) {
				deduction.Frequency = DeductionFrequency.Monthly;
			} else {
				MessageBox.Show("Please select a deduction frequency.");
				return;
			}

			//Save the new deduction to the settings, deleting the old one if this is an edit.
			if (oldDeduction != null) {
				settings.Settings.Deductions.Remove(oldDeduction);
			}

			//Check for name conflicts
			IncomeDeduction sameName = settings.Settings.Deductions.FirstOrDefault(x => x.Name == deduction.Name);
			if (sameName != null) {
				MessageBox.Show("That name already exists!");
				if (oldDeduction != null) {
					settings.Settings.Deductions.Add(oldDeduction);
					settings.Settings.Deductions.Sort(new IncomeDeductionComparer());
				}
				return;
			} else {
				settings.Settings.Deductions.Add(deduction);
				settings.Settings.Deductions.Sort(new IncomeDeductionComparer());
				settings.Save();
				this.Close();
			}
		}

	}
}
