using Common;
using Common.InteractiveCharts.Data.GroupedData;
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
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using YnabRestApi;
using YnabRestApi.ResponseData;

namespace Desktop_Budget_Planner.Forms {
    public partial class AnalysisForm : Form {

        private readonly IAppData appData = new AppDataFile();
        private YnabApi ynab;
        private YnabCache cache = null;
        private const string CacheFileName = "YNAB Cache.json";

        public AnalysisForm() {
            InitializeComponent();
        }

        private void AnalysisForm_Load(object sender, EventArgs e) {
            // Load app data, if any
            appData.Load();

            // Ask user if they want to add API token (usually on app first run)
            if (appData.Settings.YnabApiToken == null) {
                DialogResult result = MessageBox.Show("YNAB access token is required. Would you like to add it now?", "Access Token Needed", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) {
                    new YnabLoginForm(appData).ShowDialog();
                }
            }
            ynab = ApiClientFactory.Create(appData.Settings.YnabApiToken ?? "");

            // Try to load cached YNAB data
            if (File.Exists(CacheFileName)) {
                string json = File.ReadAllText(CacheFileName);
                cache = JsonSerializer.Deserialize<YnabCache>(json);
                if (cache != null) {
                    DownloadDateLabel.Text = cache.CacheDate.ToString();
                }
            }

            // Load YNAB data into graph
            GenerateGraphData();
        }

        private void GenerateGraphData() {
            if(cache == null || cache.Data == null) {
                GroupCategory cat = new("null");
                cat.Add("N/A", 1);
                BudgetSunburst.Data = cat;
                BudgetSunburst.Reload();
                return;
            }

            DownloadDateLabel.Text = cache.CacheDate.ToString();
            CategoriesData categories = cache.Data;
            GroupCategory data = new("Monthly Spending");

            GroupCategory budgetsGroup = data.Add("Budgets");
            foreach (CategoryGroupWithCategories group in categories.CategoryGroups) {
                GroupCategory groupData = budgetsGroup.Add(group.Name);
                foreach (Category category in group.Categories) {
                    string? goalType = category.GoalType;
                    if (goalType == "NEED") {
                        if (category.GoalTarget != null && category.GoalMonthsToBudget != null) {
                            Money goal = Money.FromLong((long)category.GoalTarget / 10); // TODO add milliunits conversion
                            int months = (int)category.GoalMonthsToBudget;
                            groupData.Add(category.Name, (int)(goal / months).AsLong());
                        }
                    }else if(goalType == "TBD") {
                        if(category.GoalTarget != null && category.GoalMonthsToBudget != null) {
                            Money goal = Money.FromLong((long)category.GoalTarget / 10); // TODO add milliunits conversion
                            int months = (int)category.GoalMonthsToBudget;
                            groupData.Add(category.Name, (int)(goal / months).AsLong());
                        }
                    }
                }
            }

            GroupCategory deductionsGroup = data.Add("Deductions");
            Money averageDeductions = IncomeDeduction.CalculateAverageDeductions(appData, deductionsGroup);

            if (appData.Settings.Income != null) {
                Money income = (appData.Settings.Income.YearlySalary / 12);
                Money net = income - averageDeductions;

                data.Add("Available", (int)net.AsLong() - budgetsGroup.Value);
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

        private void BudgetSunburst_Load(object sender, EventArgs e) {

        }

        private void YnabButton_Click(object sender, EventArgs e) {
            // Get the latest data from YNAB
            Task<ApiResponse<CategoriesData>> task = ynab.GetCategories("last-used");
            // TODO loading bar
            task.Wait();
            if (task.Result != null && task.Result.Data != null) {
                // Successful download, cache the data with a timestamp
                cache = new YnabCache();
                cache.CacheDate = DateTime.Now;
                cache.Data = task.Result.Data;

                // Save the cache to file so it can be loaded next time the app is used
                string json = JsonSerializer.Serialize(cache, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(CacheFileName, json);
            }

            GenerateGraphData();
        }
    }
}
