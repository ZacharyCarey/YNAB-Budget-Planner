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
    public partial class YnabLoginForm : Form {

        private IAppData appData;

        public YnabLoginForm(IAppData appData) {
            this.appData = appData;
            InitializeComponent();
        }

        private void YnabLoginForm_Load(object sender, EventArgs e) {
            TokenInputBox.UseSystemPasswordChar = true;
            TokenInputBox.Text = appData.Settings.YnabApiToken;
        }

        private void ShowTokenCheckBox_CheckedChanged(object sender, EventArgs e) {
            TokenInputBox.UseSystemPasswordChar = !ShowTokenCheckBox.Checked;
        }

        private void SaveButton_Click(object sender, EventArgs e) {
            this.appData.Settings.YnabApiToken = TokenInputBox.Text;
            this.appData.Save();
            this.Close();
        }
    }
}
