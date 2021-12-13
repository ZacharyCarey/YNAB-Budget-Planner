namespace Desktop_Budget_Planner.Forms {
	partial class EditDeductionForm {
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
			this.PerPaycheckRadioBtn = new System.Windows.Forms.RadioButton();
			this.MonthlyRadioBtn = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.NameTextBox = new System.Windows.Forms.TextBox();
			this.AmountTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SaveBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// PerPaycheckRadioBtn
			// 
			this.PerPaycheckRadioBtn.AutoSize = true;
			this.PerPaycheckRadioBtn.Location = new System.Drawing.Point(12, 101);
			this.PerPaycheckRadioBtn.Name = "PerPaycheckRadioBtn";
			this.PerPaycheckRadioBtn.Size = new System.Drawing.Size(95, 19);
			this.PerPaycheckRadioBtn.TabIndex = 0;
			this.PerPaycheckRadioBtn.TabStop = true;
			this.PerPaycheckRadioBtn.Text = "Per Paycheck";
			this.PerPaycheckRadioBtn.UseVisualStyleBackColor = true;
			// 
			// MonthlyRadioBtn
			// 
			this.MonthlyRadioBtn.AutoSize = true;
			this.MonthlyRadioBtn.Location = new System.Drawing.Point(12, 126);
			this.MonthlyRadioBtn.Name = "MonthlyRadioBtn";
			this.MonthlyRadioBtn.Size = new System.Drawing.Size(70, 19);
			this.MonthlyRadioBtn.TabIndex = 1;
			this.MonthlyRadioBtn.TabStop = true;
			this.MonthlyRadioBtn.Text = "Monthly";
			this.MonthlyRadioBtn.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(45, 15);
			this.label1.TabIndex = 2;
			this.label1.Text = "Name: ";
			// 
			// NameTextBox
			// 
			this.NameTextBox.Location = new System.Drawing.Point(75, 12);
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.Size = new System.Drawing.Size(317, 23);
			this.NameTextBox.TabIndex = 3;
			// 
			// AmountTextBox
			// 
			this.AmountTextBox.Location = new System.Drawing.Point(75, 41);
			this.AmountTextBox.Name = "AmountTextBox";
			this.AmountTextBox.Size = new System.Drawing.Size(142, 23);
			this.AmountTextBox.TabIndex = 4;
			this.AmountTextBox.Text = "$0.00";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 15);
			this.label2.TabIndex = 5;
			this.label2.Text = "Amount: ";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 73);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(65, 15);
			this.label3.TabIndex = 6;
			this.label3.Text = "Frequency:";
			// 
			// SaveBtn
			// 
			this.SaveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.SaveBtn.Location = new System.Drawing.Point(349, 150);
			this.SaveBtn.Name = "SaveBtn";
			this.SaveBtn.Size = new System.Drawing.Size(75, 27);
			this.SaveBtn.TabIndex = 7;
			this.SaveBtn.Text = "Save";
			this.SaveBtn.UseVisualStyleBackColor = true;
			this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
			// 
			// EditDeductionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(436, 189);
			this.Controls.Add(this.SaveBtn);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.AmountTextBox);
			this.Controls.Add(this.NameTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.MonthlyRadioBtn);
			this.Controls.Add(this.PerPaycheckRadioBtn);
			this.Name = "EditDeductionForm";
			this.Text = "EditDeductionForm";
			this.Load += new System.EventHandler(this.EditDeductionForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RadioButton PerPaycheckRadioBtn;
		private System.Windows.Forms.RadioButton MonthlyRadioBtn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox NameTextBox;
		private System.Windows.Forms.TextBox AmountTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button SaveBtn;
	}
}