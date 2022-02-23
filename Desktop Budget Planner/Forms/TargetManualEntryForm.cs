using Common;
using Common.Goals;
using Common.MoneyUtils;
using Desktop_Budget_Planner.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YnabRestApi.ResponseData;

namespace Desktop_Budget_Planner.Forms {
    public partial class TargetManualEntryForm : Form {

        private readonly Color ErrorColor = Color.Red;

        private TargetType? selectedTargetType;
        private Frequency? selectedFrequency;
        private DayOfWeek? selectedEvery_Weekly;
        private int? selectedEvery_Monthly;
        private DateTime selectedEveryDate;
        private bool repeatChecked;
        private int? selectedRepeats;
        private RepeatType? selectedRepeatType;
        private bool byDateChecked;
        private int? selectedByDate_Month;
        private int? selectedByDate_Year;

        private Color Color_TargetTypeDropDown;

        private Goal goal = null;
        private Category category;
        private ParsedCategory parsedCategory;

        public static Goal RequestNewGoal(string name, Category category, Goal? existingGoal) {
            TargetManualEntryForm form = new(name, category, new ParsedCategory(category), existingGoal);
            form.ShowDialog();
            return form.goal;
        }

        private TargetManualEntryForm(string name, Category category, ParsedCategory parsedCategory, Goal? existingGoal) {
            InitializeComponent();

            this.category = category;
            this.parsedCategory = parsedCategory;

            CategoryNameLabel.Text = name;
            CategoryAmountLabel.Text = ((Money)parsedCategory.GoalTarget).ToString(true);

            // Populate TargetTypeDropDown
            Color_TargetTypeDropDown = TargetTypeDropDown.BackColor;
            TargetTypeDropDown.Items.Clear();
            foreach(TargetType type in Enum.GetValues<TargetType>()) {
                TargetTypeDropDown.Items.Add(type);
            }

            // Populate FrequencyDropDown
            FrequencyDropDown.Items.Clear();
            foreach(Frequency frequency in Enum.GetValues<Frequency>()) {
                FrequencyDropDown.Items.Add(frequency);
            }

            // Populate RepeatTypeDropDown
            RepeatTypeDropDown.Items.Clear();
            foreach(RepeatType type in Enum.GetValues<RepeatType>()) {
                RepeatTypeDropDown.Items.Add(type);
            }

            // Populate DateMonthDropDown
            DateMonthDropDown.Items.Clear();
            foreach(MonthValue month in MonthValue.GetValues()) {
                DateMonthDropDown.Items.Add(month);
            }

            // Populate DateYearDropDown
            int currentYear = DateTime.Now.Year;
            DateYearDropDown.Items.Clear();
            for(int i = 0; i < 50; i++) {
                DateYearDropDown.Items.Add(currentYear + i);
            }

            // Store the default values
            selectedEveryDate = EveryDatePicker.Value;
            repeatChecked = RepeatCheckBox.Checked;
            byDateChecked = ByDateCheckBox.Checked;

            Verify_TargetTypeDropDown();

            if (existingGoal != null) {
                // TODO load previous settings
                //existingGoal.
            }
        }

        private void TargetTypeDropDown_SelectedIndexChanged(object sender, EventArgs e) {
            if (TargetTypeDropDown.SelectedItem != null && TargetTypeDropDown.SelectedItem is TargetType type) {
                selectedTargetType = type;
            } else {
                selectedTargetType = null;
            }

            Verify_TargetTypeDropDown();
        }

        private void Verify_TargetTypeDropDown() {
            if (selectedTargetType == TargetType.MonthlyDebtPayment) {
                //TargetTypeDropDown.BackColor = ErrorColor;
                MessageBox.Show("Sorry, that type isn't supported right now.");
            }

            Verify_FrequencyDropDown();
        }

        private void FrequencyDropDown_SelectedIndexChanged(object sender, EventArgs e) {
            if (FrequencyDropDown.SelectedItem != null && FrequencyDropDown.SelectedItem is Frequency frequency) {
                selectedFrequency = frequency;
            } else {
                selectedFrequency = null;
            }

            Verify_FrequencyDropDown();
        }

        private void Verify_FrequencyDropDown() {
            FrequencyDropDown.Visible = (selectedTargetType == TargetType.NeededForSpending);
            FrequencyLabel.Visible = FrequencyDropDown.Visible;

            Verify_EveryDropDown();
            Verify_EveryDatePicker();
            Verify_RepeatCheckBox();
            Verify_ByDateCheckBox();
        }

        private void EveryDropDown_SelectedIndexChanged(object sender, EventArgs e) {
            if (selectedFrequency == Frequency.Weekly) {
                if (EveryDropDown.SelectedItem != null && EveryDropDown.SelectedItem is DayOfWeek weekday) {
                    selectedEvery_Weekly = weekday;
                } else {
                    selectedEvery_Weekly = null;
                }
            } else if (selectedFrequency == Frequency.Monthly) {
                if (EveryDropDown.SelectedItem != null && EveryDropDown.SelectedItem is DayOfMonth day) {
                    selectedEvery_Monthly = day.Day;
                    return;
                } else {
                    selectedEvery_Monthly = null;
                }
            }

            Verify_EveryDropDown();
        }

        private void Verify_EveryDropDown() {
            if (selectedTargetType != TargetType.NeededForSpending) {
                EveryDropDown.Visible = false;
                EveryLabel1.Visible = false;
                return;
            }

            // Needed for Spending is selected
            if (selectedFrequency == Frequency.Monthly) {
                EveryDropDown.Visible = true;
                EveryLabel1.Visible = true;
                if (EveryDropDown.Items.Count == 0 || !(EveryDropDown.Items[0] is DayOfMonth)) {
                    EveryDropDown.Items.Clear();
                    foreach(DayOfMonth day in DayOfMonth.GetValues()) {
                        EveryDropDown.Items.Add(day);
                    }
                    EveryDropDown.SelectedIndex = EveryDropDown.Items.IndexOf(selectedEvery_Monthly == null ? null : new DayOfMonth((int)selectedEvery_Monthly));
                    if (selectedEvery_Monthly == null) EveryDropDown.Text = "";
                } 
            } else if (selectedFrequency == Frequency.Weekly) {
                EveryDropDown.Visible = true;
                EveryLabel1.Visible = true;
                if (EveryDropDown.Items.Count == 0 || !(EveryDropDown.Items[0] is DayOfWeek)) {
                    EveryDropDown.Items.Clear();
                    foreach (DayOfWeek day in Enum.GetValues<DayOfWeek>()) {
                        EveryDropDown.Items.Add(day);
                    }
                    EveryDropDown.SelectedIndex = EveryDropDown.Items.IndexOf(selectedEvery_Weekly == null ? null : (DayOfWeek)selectedEvery_Weekly);
                    if (selectedEvery_Weekly == null) EveryDropDown.Text = "";
                }
            } else {
                EveryDropDown.Visible = false;
                EveryLabel1.Visible = false;
            }
        }

        private void EveryDatePicker_ValueChanged(object sender, EventArgs e) {
            selectedEveryDate = EveryDatePicker.Value;

            Verify_EveryDatePicker();
        }

        private void Verify_EveryDatePicker() {
            if (selectedTargetType == TargetType.NeededForSpending && selectedFrequency == Frequency.ByDate) {
                EveryDatePicker.Visible = true;
                EveryLabel1.Visible = true;
            } else {
                EveryDatePicker.Visible = false;
                // Label should already be set invisible by EveryDropDown
            }
        }

        private void RepeatCheckBox_CheckedChanged(object sender, EventArgs e) {
            repeatChecked = RepeatCheckBox.Checked;

            Verify_RepeatCheckBox();
        }

        private void Verify_RepeatCheckBox() {
            if (selectedTargetType == TargetType.NeededForSpending && selectedFrequency == Frequency.ByDate) {
                RepeatCheckBox.Visible = true;
            } else {
                RepeatCheckBox.Visible = false;
            }

            Verify_RepeatTypeDropDown();
        }

        private void RepeatsDropDown_SelectedIndexChanged(object sender, EventArgs e) {
            if (RepeatsDropDown.SelectedItem != null && RepeatsDropDown.SelectedItem is int repeats) {
                selectedRepeats = repeats;
            } else {
                selectedRepeats = null;
            }

            Verify_RepeatsDropDown();
        }

        private void Verify_RepeatsDropDown() {
            if (RepeatTypeDropDown.Visible) {
                RepeatsDropDown.Visible = true;

                if (selectedRepeatType == RepeatType.Years) {
                    if (RepeatsDropDown.Items.Count != 2) {
                        RepeatsDropDown.Items.Clear();
                        RepeatsDropDown.Items.Add(1);
                        RepeatsDropDown.Items.Add(2);
                        selectedRepeats = 1;
                        RepeatsDropDown.SelectedItem = 1;
                    }
                } else if (selectedRepeatType == RepeatType.Months) {
                    if (RepeatsDropDown.Items.Count != 11) {
                        RepeatsDropDown.Items.Clear();
                        for(int i = 1; i <= 11; i++) {
                            RepeatsDropDown.Items.Add(i);
                        }
                        selectedRepeats = 1;
                        RepeatsDropDown.SelectedItem = 1;
                    }
                } else {
                    RepeatsDropDown.Items.Clear();
                    RepeatsDropDown.SelectedItem = null;
                }
            } else {
                RepeatsDropDown.Visible = false;
            }
        }

        private void RepeatTypeDropDown_SelectedIndexChanged(object sender, EventArgs e) {
            if (RepeatTypeDropDown.SelectedItem != null && RepeatTypeDropDown.SelectedItem is RepeatType type) {
                selectedRepeatType = type;
            } else {
                selectedRepeatType = null;
            }

            Verify_RepeatTypeDropDown();
        }

        private void Verify_RepeatTypeDropDown() {
            if (RepeatCheckBox.Visible && repeatChecked) {
                RepeatTypeDropDown.Visible = true;
                EveryLabel2.Visible = true;
            } else {
                RepeatTypeDropDown.Visible = false;
                EveryLabel2.Visible = false;
            }

            Verify_RepeatsDropDown();
        }

        private void ByDateCheckBox_CheckedChanged(object sender, EventArgs e) {
            byDateChecked = ByDateCheckBox.Checked;

            Verify_ByDateCheckBox();
        }

        private void Verify_ByDateCheckBox() {
            ByDateCheckBox.Visible = (selectedTargetType == TargetType.SavingsBalance);

            Verify_DateMonthDropDown();
            Verify_DateYearDropDown();
        }

        private void DateMonthDropDown_SelectedIndexChanged(object sender, EventArgs e) {
            if (DateMonthDropDown.SelectedItem != null && DateMonthDropDown.SelectedItem is MonthValue month) {
                selectedByDate_Month = month.Month;
                return;
            } else {
                selectedByDate_Month = null;
            }
        }

        private void Verify_DateMonthDropDown() {
            DateMonthDropDown.Visible = (ByDateCheckBox.Visible && byDateChecked);
        }

        private void DateYearDropDown_SelectedIndexChanged(object sender, EventArgs e) {
            if (DateYearDropDown.SelectedItem != null && DateYearDropDown.SelectedItem is int year) {
                selectedByDate_Year = year;
                return;
            } else {
                selectedByDate_Year = null;
            }
        }

        private void Verify_DateYearDropDown() {
            DateYearDropDown.Visible = (ByDateCheckBox.Visible && byDateChecked);
        }

        private void TargetManualEntryForm_Load(object sender, EventArgs e) {
            
        }

        private void SaveBtn_Click(object sender, EventArgs e) {
            this.goal = CreateGoal();
            if (this.goal != null) {
                this.Close();
            }
        }

        private Goal? CreateGoal() {
            // TODO error checking
            Money goal_target = (Money)parsedCategory.GoalTarget;
            if (selectedTargetType == TargetType.NeededForSpending) {
                if (selectedFrequency == Frequency.Monthly) {
                    return new NeededForSpending(goal_target, (int)selectedEvery_Monthly);
                } else if (selectedFrequency == Frequency.Weekly) {
                    return new NeededForSpending(goal_target, (DayOfWeek)selectedEvery_Weekly);
                } else if (selectedFrequency == Frequency.ByDate) {
                    if (repeatChecked) {
                        return new NeededForSpending(goal_target, (DateTime)category.GoalCreationMonth, (DateTime)category.GoalTargetMonth, (int)selectedRepeats, (RepeatType)selectedRepeatType);
                    } else {
                        return new NeededForSpending(goal_target, (DateTime)category.GoalCreationMonth, (DateTime)category.GoalTargetMonth);
                    }
                } else {
                    MessageBox.Show("Unknown selected frequency.");
                    return null;
                }
            } else if (selectedTargetType == TargetType.SavingsBalance) {
                if (byDateChecked) {
                    return new SavingsBalance(goal_target, (DateTime)category.GoalCreationMonth, (int)selectedByDate_Month, (int)selectedByDate_Year);
                } else {
                    return new SavingsBalance(goal_target);
                }
            } else if (selectedTargetType == TargetType.MonthlySavingsBuilder) {
                return new MonthlySavingsBuilder(goal_target);
            } else if (selectedTargetType == TargetType.MonthlyDebtPayment) {
                MessageBox.Show("That goal type is not currently supported.");
                return null;
            } else {
                MessageBox.Show("Unknown goal type.");
                return null;
            }
        }
    }
}
