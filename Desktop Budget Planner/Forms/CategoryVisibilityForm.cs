using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YnabRestApi.ResponseData;

namespace Desktop_Budget_Planner.Forms {
    public partial class CategoryVisibilityForm : Form {

        private AnalysisForm MainForm;

        public CategoryVisibilityForm(AnalysisForm parentForm, IEnumerable<Tuple<string, Category>> categories) {
            InitializeComponent();
            this.MainForm = parentForm;
            this.CheckedListBox.Items.Clear();
            foreach(Tuple<string, Category> category in categories) {
                bool visible = parentForm.IsCategoryVisible(category.Item2);
                CheckedListBox.Items.Add(new CategoryItem(category.Item1, category.Item2), visible);
            }


            CheckedListBox.ItemCheck += CheckedListBox_ItemCheck;
        }

        private void CategoryVisibilityForm_Load(object sender, EventArgs e) {

        }

        private class CategoryItem {
            public Category Category;
            public readonly string DisplayName;

            public CategoryItem(string groupName, Category category) {
                this.Category = category;
                this.DisplayName = groupName + "/" + category.Name;
            }

            public override string ToString() {
                return DisplayName;
            }
        }

        private void CheckedListBox_ItemCheck(object? sender, ItemCheckEventArgs e) {
            int index = e.Index;
            if (CheckedListBox.Items[index] is CategoryItem item) {
                MainForm.SetVisibleCategory(item.Category.Id, e.NewValue == CheckState.Checked);
            }
        }
    }
}
