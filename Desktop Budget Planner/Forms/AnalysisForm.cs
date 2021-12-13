using Common;
using Common.InteractiveCharts.Data.GroupedData;
using Common.MoneyUtils;
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
using YnabRestApi;
using YnabRestApi.ResponseData;

namespace Desktop_Budget_Planner.Forms {
    public partial class AnalysisForm : Form {

        private readonly IAppData appData = new AppDataFile();
        private YnabApi ynab;
        private CategoriesData categoriesCache = null;

        public AnalysisForm() {
            InitializeComponent();
        }

        private void AnalysisForm_Load(object sender, EventArgs e) {
            appData.Load();
            if (appData.Settings.YnabApiToken == null) {
                DialogResult result = MessageBox.Show("YNAB access token is required. Would you like to add it now?", "Access Token Needed", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) {
                    new YnabLoginForm(appData).ShowDialog();
                }
            }
            ynab = ApiClientFactory.Create(appData.Settings.YnabApiToken ?? "");
            GenerateGraphData();
        }

        private void GenerateGraphData() {
            if (categoriesCache == null) {
                Task<ApiResponse<CategoriesData>> categoriesTask = ynab.GetCategories("last-used");
                categoriesTask.Wait();
                categoriesCache = categoriesTask.Result.Data;
            }
            CategoriesData categories = categoriesCache;

            GroupCategory data = new("Budget");
            foreach (CategoryGroupWithCategories group in categories.CategoryGroups) {
                GroupCategory groupData = data.Add(group.Name);
                foreach (Category category in group.Categories) {
                    string? goalType = category.GoalType;
                    if (goalType == "NEED") {
                        if (category.GoalTarget != null) {
                            groupData.Add(category.Name, (int)category.GoalTarget / 10);
                        }
                    }
                }
            }

            if (appData.Settings.Income != null) {
                Money income = (appData.Settings.Income.YearlySalary / 12);
                Money totalDeductions = IncomeDeduction.CalculateAverageDeductions(appData);
                Money net = income - totalDeductions;

                data.Add("Available", (int)net.AsLong() - data.Value);
            }

            BudgetSunburst.Data = data;
            BudgetSunburst.Reload();
        }

        private void incomeToolStripMenuItem_Click(object sender, EventArgs e) {
            new IncomeSettingsForm(appData).ShowDialog();
            GenerateGraphData();
        }

        private void deductionsToolStripMenuItem_Click(object sender, EventArgs e) {
            new DeductionsSettingsForm(appData).ShowDialog();
            GenerateGraphData();
        }

        private void yNABToolStripMenuItem_Click(object sender, EventArgs e) {
            new YnabLoginForm(appData).ShowDialog();
            ynab = ApiClientFactory.Create(appData.Settings.YnabApiToken ?? "");
            GenerateGraphData();
        }

        private void devToolStripMenuItem_Click(object sender, EventArgs e) {
            BudgetSunburst.OpenDevTools();
        }
    }
}
