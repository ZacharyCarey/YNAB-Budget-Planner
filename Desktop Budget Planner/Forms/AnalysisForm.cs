using Common;
using Common.Goals;
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
        private Dictionary<string, bool> VisibleCategories = new();

        private Dictionary<string, Goal> goals { get => appData.Settings.Goals; }

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
            GenerateGraphData(null);
        }

        private void GenerateGraphData(YnabCache? OldCache) {
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
                foreach (Category category in group.Categories.Where(x => x.GoalType != null)) {
                    // If updating the cache, check to see if the category changed
                    bool changed = false;
                    if (OldCache != null) {
                        changed = category.HasChanged(OldCache[category.Id]);
                    }

                    // First try to find an existing goal
                    Goal? goal = null;
                    if (!goals.TryGetValue(category.Id, out goal) || changed) {
                        // Ask the user to enter goal information
                        //Money goalTarget = ((category.GoalTarget == null) ? new Money() : Money.FromLong((long)category.GoalTarget / 10));
                        Goal newGoal = TargetManualEntryForm.RequestNewGoal(category.Name, category, goal);
                        goals[category.Id] = newGoal;
                        appData.Save();
                    }

                    // Check if this category should be visible
                    bool visible;
                    if (!VisibleCategories.TryGetValue(category.Id, out visible)) {
                        visible = true;
                        VisibleCategories[category.Id] = true;
                    }

                    if (visible && goal != null) {
                        groupData.Add(category.Name, (int)goal.MonthlyExpense.AsLong());
                    }

                }
            }

            GroupCategory deductionsGroup = data.Add("Deductions");
            Money averageDeductions = IncomeDeduction.CalculateAverageDeductions(appData, deductionsGroup);

            if (appData.Settings.Income != null) {
                Money income = (appData.Settings.Income.YearlySalary / 12);
                Money net = income - averageDeductions;
                int netValue = (int)net.AsLong();
                if (netValue >= budgetsGroup.Value) {
                    data.Add("Available", (int)net.AsLong() - budgetsGroup.Value);
                }
            }

            BudgetSunburst.Data = data;
            BudgetSunburst.Reload();
        }

        private void incomeToolStripMenuItem_Click(object sender, EventArgs e) {
            new IncomeSettingsForm(appData).ShowDialog();
            GenerateGraphData(null);
        }

        private void deductionsToolStripMenuItem_Click(object sender, EventArgs e) {
            new DeductionsSettingsForm(appData).ShowDialog();
            GenerateGraphData(null);
        }

        private void yNABToolStripMenuItem_Click(object sender, EventArgs e) {
            new YnabLoginForm(appData).ShowDialog();
            ynab = ApiClientFactory.Create(appData.Settings.YnabApiToken ?? "");
            GenerateGraphData(null);
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
            YnabCache? oldCache = null;
            if (task.Result != null && task.Result.Data != null) {
                oldCache = cache;

                // Successful download, cache the data with a timestamp
                cache = new YnabCache();
                cache.CacheDate = DateTime.Now;
                cache.Data = task.Result.Data;

                // Save the cache to file so it can be loaded next time the app is used
                string json = JsonSerializer.Serialize(cache, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(CacheFileName, json);

                VisibleCategories.Clear();
            }

            GenerateGraphData(oldCache);
        }

        /*public IEnumerable<KeyValuePair<string, bool>> GetVisibleCategories() {
            return this.VisibleCategories;
        }*/

        public bool IsCategoryVisible(Category category) {
            bool visible;
            if (!VisibleCategories.TryGetValue(category.Id, out visible)) {
                visible = false;
            }
            return visible;
        }

        public void SetVisibleCategory(string id, bool visible) {
            this.VisibleCategories[id] = visible;
            GenerateGraphData(null);
        }

        private void hideCategoriesToolStripMenuItem_Click(object sender, EventArgs e) {
            new CategoryVisibilityForm(this, GetCategoriesWithGroup()).Show();
        }

        private IEnumerable<Tuple<string, Category>> GetCategoriesWithGroup() {
            if (cache == null) {
                yield break;
            }

            foreach (CategoryGroupWithCategories group in cache.Data.CategoryGroups) {
                foreach (Category category in group.Categories.Where(x => x.GoalType != null)) {
                    yield return new Tuple<string, Category>(group.Name, category);

                }
            }
        }
    }
}
