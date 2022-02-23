namespace Desktop_Budget_Planner.Forms {
    partial class TargetManualEntryForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.TargetTypeDropDown = new System.Windows.Forms.ComboBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CategoryAmountLabel = new System.Windows.Forms.Label();
            this.CategoryNameLabel = new System.Windows.Forms.Label();
            this.FrequencyLabel = new System.Windows.Forms.Label();
            this.EveryLabel1 = new System.Windows.Forms.Label();
            this.FrequencyDropDown = new System.Windows.Forms.ComboBox();
            this.EveryDropDown = new System.Windows.Forms.ComboBox();
            this.EveryDatePicker = new System.Windows.Forms.DateTimePicker();
            this.RepeatCheckBox = new System.Windows.Forms.CheckBox();
            this.EveryLabel2 = new System.Windows.Forms.Label();
            this.RepeatsDropDown = new System.Windows.Forms.ComboBox();
            this.RepeatTypeDropDown = new System.Windows.Forms.ComboBox();
            this.ByDateCheckBox = new System.Windows.Forms.CheckBox();
            this.DateMonthDropDown = new System.Windows.Forms.ComboBox();
            this.DateYearDropDown = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // TargetTypeDropDown
            // 
            this.TargetTypeDropDown.FormattingEnabled = true;
            this.TargetTypeDropDown.Items.AddRange(new object[] {
            "Needed For Spending",
            "Savings Balance",
            "Monthly Savings Builder",
            "Monthly Debt Payment"});
            this.TargetTypeDropDown.Location = new System.Drawing.Point(12, 177);
            this.TargetTypeDropDown.Name = "TargetTypeDropDown";
            this.TargetTypeDropDown.Size = new System.Drawing.Size(478, 40);
            this.TargetTypeDropDown.TabIndex = 0;
            this.TargetTypeDropDown.SelectedIndexChanged += new System.EventHandler(this.TargetTypeDropDown_SelectedIndexChanged);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveBtn.Location = new System.Drawing.Point(327, 555);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(165, 66);
            this.SaveBtn.TabIndex = 1;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.Enabled = false;
            this.CancelBtn.Location = new System.Drawing.Point(106, 555);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(165, 66);
            this.CancelBtn.TabIndex = 2;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select the target type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "Category Name: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "Category Amount: ";
            // 
            // CategoryAmountLabel
            // 
            this.CategoryAmountLabel.AutoSize = true;
            this.CategoryAmountLabel.Location = new System.Drawing.Point(233, 50);
            this.CategoryAmountLabel.Name = "CategoryAmountLabel";
            this.CategoryAmountLabel.Size = new System.Drawing.Size(56, 32);
            this.CategoryAmountLabel.TabIndex = 6;
            this.CategoryAmountLabel.Text = "N/A";
            // 
            // CategoryNameLabel
            // 
            this.CategoryNameLabel.AutoSize = true;
            this.CategoryNameLabel.Location = new System.Drawing.Point(233, 9);
            this.CategoryNameLabel.Name = "CategoryNameLabel";
            this.CategoryNameLabel.Size = new System.Drawing.Size(56, 32);
            this.CategoryNameLabel.TabIndex = 7;
            this.CategoryNameLabel.Text = "N/A";
            // 
            // FrequencyLabel
            // 
            this.FrequencyLabel.AutoSize = true;
            this.FrequencyLabel.Location = new System.Drawing.Point(12, 243);
            this.FrequencyLabel.Name = "FrequencyLabel";
            this.FrequencyLabel.Size = new System.Drawing.Size(137, 32);
            this.FrequencyLabel.TabIndex = 8;
            this.FrequencyLabel.Text = "Frequency: ";
            // 
            // EveryLabel1
            // 
            this.EveryLabel1.AutoSize = true;
            this.EveryLabel1.Location = new System.Drawing.Point(66, 292);
            this.EveryLabel1.Name = "EveryLabel1";
            this.EveryLabel1.Size = new System.Drawing.Size(83, 32);
            this.EveryLabel1.TabIndex = 9;
            this.EveryLabel1.Text = "Every: ";
            // 
            // FrequencyDropDown
            // 
            this.FrequencyDropDown.FormattingEnabled = true;
            this.FrequencyDropDown.Items.AddRange(new object[] {
            "Monthly",
            "Weekly",
            "By Date"});
            this.FrequencyDropDown.Location = new System.Drawing.Point(155, 243);
            this.FrequencyDropDown.Name = "FrequencyDropDown";
            this.FrequencyDropDown.Size = new System.Drawing.Size(335, 40);
            this.FrequencyDropDown.TabIndex = 10;
            this.FrequencyDropDown.SelectedIndexChanged += new System.EventHandler(this.FrequencyDropDown_SelectedIndexChanged);
            // 
            // EveryDropDown
            // 
            this.EveryDropDown.FormattingEnabled = true;
            this.EveryDropDown.Items.AddRange(new object[] {
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday Saturday"});
            this.EveryDropDown.Location = new System.Drawing.Point(155, 292);
            this.EveryDropDown.Name = "EveryDropDown";
            this.EveryDropDown.Size = new System.Drawing.Size(335, 40);
            this.EveryDropDown.TabIndex = 11;
            this.EveryDropDown.SelectedIndexChanged += new System.EventHandler(this.EveryDropDown_SelectedIndexChanged);
            // 
            // EveryDatePicker
            // 
            this.EveryDatePicker.CustomFormat = "MMMM dd, yyyy";
            this.EveryDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EveryDatePicker.Location = new System.Drawing.Point(155, 335);
            this.EveryDatePicker.Name = "EveryDatePicker";
            this.EveryDatePicker.Size = new System.Drawing.Size(335, 39);
            this.EveryDatePicker.TabIndex = 12;
            this.EveryDatePicker.ValueChanged += new System.EventHandler(this.EveryDatePicker_ValueChanged);
            // 
            // RepeatCheckBox
            // 
            this.RepeatCheckBox.AutoSize = true;
            this.RepeatCheckBox.Location = new System.Drawing.Point(12, 380);
            this.RepeatCheckBox.Name = "RepeatCheckBox";
            this.RepeatCheckBox.Size = new System.Drawing.Size(119, 36);
            this.RepeatCheckBox.TabIndex = 13;
            this.RepeatCheckBox.Text = "Repeat";
            this.RepeatCheckBox.UseVisualStyleBackColor = true;
            this.RepeatCheckBox.CheckedChanged += new System.EventHandler(this.RepeatCheckBox_CheckedChanged);
            // 
            // EveryLabel2
            // 
            this.EveryLabel2.AutoSize = true;
            this.EveryLabel2.Location = new System.Drawing.Point(66, 419);
            this.EveryLabel2.Name = "EveryLabel2";
            this.EveryLabel2.Size = new System.Drawing.Size(83, 32);
            this.EveryLabel2.TabIndex = 14;
            this.EveryLabel2.Text = "Every: ";
            // 
            // RepeatsDropDown
            // 
            this.RepeatsDropDown.FormattingEnabled = true;
            this.RepeatsDropDown.Items.AddRange(new object[] {
            "1",
            "2"});
            this.RepeatsDropDown.Location = new System.Drawing.Point(155, 416);
            this.RepeatsDropDown.Name = "RepeatsDropDown";
            this.RepeatsDropDown.Size = new System.Drawing.Size(114, 40);
            this.RepeatsDropDown.TabIndex = 15;
            this.RepeatsDropDown.SelectedIndexChanged += new System.EventHandler(this.RepeatsDropDown_SelectedIndexChanged);
            // 
            // RepeatTypeDropDown
            // 
            this.RepeatTypeDropDown.FormattingEnabled = true;
            this.RepeatTypeDropDown.Items.AddRange(new object[] {
            "Months",
            "Years"});
            this.RepeatTypeDropDown.Location = new System.Drawing.Point(275, 416);
            this.RepeatTypeDropDown.Name = "RepeatTypeDropDown";
            this.RepeatTypeDropDown.Size = new System.Drawing.Size(215, 40);
            this.RepeatTypeDropDown.TabIndex = 16;
            this.RepeatTypeDropDown.SelectedIndexChanged += new System.EventHandler(this.RepeatTypeDropDown_SelectedIndexChanged);
            // 
            // ByDateCheckBox
            // 
            this.ByDateCheckBox.AutoSize = true;
            this.ByDateCheckBox.Location = new System.Drawing.Point(12, 469);
            this.ByDateCheckBox.Name = "ByDateCheckBox";
            this.ByDateCheckBox.Size = new System.Drawing.Size(129, 36);
            this.ByDateCheckBox.TabIndex = 17;
            this.ByDateCheckBox.Text = "By Date";
            this.ByDateCheckBox.UseVisualStyleBackColor = true;
            this.ByDateCheckBox.CheckedChanged += new System.EventHandler(this.ByDateCheckBox_CheckedChanged);
            // 
            // DateMonthDropDown
            // 
            this.DateMonthDropDown.FormattingEnabled = true;
            this.DateMonthDropDown.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.DateMonthDropDown.Location = new System.Drawing.Point(147, 467);
            this.DateMonthDropDown.Name = "DateMonthDropDown";
            this.DateMonthDropDown.Size = new System.Drawing.Size(198, 40);
            this.DateMonthDropDown.TabIndex = 18;
            this.DateMonthDropDown.SelectedIndexChanged += new System.EventHandler(this.DateMonthDropDown_SelectedIndexChanged);
            // 
            // DateYearDropDown
            // 
            this.DateYearDropDown.FormattingEnabled = true;
            this.DateYearDropDown.Items.AddRange(new object[] {
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027"});
            this.DateYearDropDown.Location = new System.Drawing.Point(351, 467);
            this.DateYearDropDown.Name = "DateYearDropDown";
            this.DateYearDropDown.Size = new System.Drawing.Size(139, 40);
            this.DateYearDropDown.TabIndex = 19;
            this.DateYearDropDown.SelectedIndexChanged += new System.EventHandler(this.DateYearDropDown_SelectedIndexChanged);
            // 
            // TargetManualEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 633);
            this.Controls.Add(this.DateYearDropDown);
            this.Controls.Add(this.DateMonthDropDown);
            this.Controls.Add(this.ByDateCheckBox);
            this.Controls.Add(this.RepeatTypeDropDown);
            this.Controls.Add(this.RepeatsDropDown);
            this.Controls.Add(this.EveryLabel2);
            this.Controls.Add(this.RepeatCheckBox);
            this.Controls.Add(this.EveryDatePicker);
            this.Controls.Add(this.EveryDropDown);
            this.Controls.Add(this.FrequencyDropDown);
            this.Controls.Add(this.EveryLabel1);
            this.Controls.Add(this.FrequencyLabel);
            this.Controls.Add(this.CategoryNameLabel);
            this.Controls.Add(this.CategoryAmountLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.TargetTypeDropDown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TargetManualEntryForm";
            this.Text = "TargetTypeSelectorForm";
            this.Load += new System.EventHandler(this.TargetManualEntryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox TargetTypeDropDown;
        private Button SaveBtn;
        private Button CancelBtn;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label CategoryAmountLabel;
        private Label CategoryNameLabel;
        private Label FrequencyLabel;
        private Label EveryLabel1;
        private ComboBox FrequencyDropDown;
        private ComboBox EveryDropDown;
        private DateTimePicker EveryDatePicker;
        private CheckBox RepeatCheckBox;
        private Label EveryLabel2;
        private ComboBox RepeatsDropDown;
        private ComboBox RepeatTypeDropDown;
        private CheckBox ByDateCheckBox;
        private ComboBox DateMonthDropDown;
        private ComboBox DateYearDropDown;
        private ToolTip toolTip1;
    }
}