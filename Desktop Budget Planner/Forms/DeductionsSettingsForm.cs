using Common;
using Common.Saving;
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
	public partial class DeductionsSettingsForm : Form {

		private readonly IAppData AppSettings;

		public DeductionsSettingsForm(IAppData settings) {
			InitializeComponent();
			this.AppSettings = settings;
		}

		private void DeductionsSettingsForm_Load(object sender, EventArgs e) {
			UpdateDeductionsList();
		}

		private void UpdateDeductionsList() {
			DeductionsListBox.Items.Clear();
			DeductionsListBox.Items.AddRange(AppSettings.Settings.Deductions.ToArray());
		}

		private void NewBtn_Click(object sender, EventArgs e) {
			new EditDeductionForm(AppSettings).ShowDialog();
			UpdateDeductionsList();
		}

		private void EditBtn_Click(object sender, EventArgs e) {
			if ((DeductionsListBox.SelectedItem != null) && (DeductionsListBox.SelectedItem is IncomeDeduction selection)) {
				new EditDeductionForm(AppSettings, selection).ShowDialog();
				UpdateDeductionsList();
			}
		}

		private void DeleteBtn_Click(object sender, EventArgs e) {
			if ((DeductionsListBox.SelectedItem != null) && (DeductionsListBox.SelectedItem is IncomeDeduction selection)) {
				AppSettings.Settings.Deductions.Remove(selection);
				AppSettings.Save();
				UpdateDeductionsList();
			}
		}

		private void DeductionsListBox_SelectedIndexChanged(object sender, EventArgs e) {
			bool selected = (DeductionsListBox.SelectedItem != null) && (DeductionsListBox.SelectedItem is IncomeDeduction);
			EditBtn.Enabled = selected;
			DeleteBtn.Enabled = selected;
		}
	}
}
