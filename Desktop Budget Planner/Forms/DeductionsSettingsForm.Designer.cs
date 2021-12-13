namespace Desktop_Budget_Planner.Forms {
	partial class DeductionsSettingsForm {
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
			this.label1 = new System.Windows.Forms.Label();
			this.DeductionsListBox = new System.Windows.Forms.ListBox();
			this.NewBtn = new System.Windows.Forms.Button();
			this.EditBtn = new System.Windows.Forms.Button();
			this.DeleteBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Deductions";
			// 
			// DeductionsListBox
			// 
			this.DeductionsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.DeductionsListBox.FormattingEnabled = true;
			this.DeductionsListBox.ItemHeight = 15;
			this.DeductionsListBox.Location = new System.Drawing.Point(12, 27);
			this.DeductionsListBox.Name = "DeductionsListBox";
			this.DeductionsListBox.Size = new System.Drawing.Size(285, 409);
			this.DeductionsListBox.TabIndex = 1;
			this.DeductionsListBox.SelectedIndexChanged += new System.EventHandler(this.DeductionsListBox_SelectedIndexChanged);
			// 
			// NewBtn
			// 
			this.NewBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.NewBtn.Location = new System.Drawing.Point(303, 27);
			this.NewBtn.Name = "NewBtn";
			this.NewBtn.Size = new System.Drawing.Size(75, 28);
			this.NewBtn.TabIndex = 2;
			this.NewBtn.Text = "New";
			this.NewBtn.UseVisualStyleBackColor = true;
			this.NewBtn.Click += new System.EventHandler(this.NewBtn_Click);
			// 
			// EditBtn
			// 
			this.EditBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.EditBtn.Enabled = false;
			this.EditBtn.Location = new System.Drawing.Point(303, 61);
			this.EditBtn.Name = "EditBtn";
			this.EditBtn.Size = new System.Drawing.Size(75, 28);
			this.EditBtn.TabIndex = 3;
			this.EditBtn.Text = "Edit";
			this.EditBtn.UseVisualStyleBackColor = true;
			this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
			// 
			// DeleteBtn
			// 
			this.DeleteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.DeleteBtn.Enabled = false;
			this.DeleteBtn.Location = new System.Drawing.Point(303, 114);
			this.DeleteBtn.Name = "DeleteBtn";
			this.DeleteBtn.Size = new System.Drawing.Size(75, 28);
			this.DeleteBtn.TabIndex = 4;
			this.DeleteBtn.Text = "Delete";
			this.DeleteBtn.UseVisualStyleBackColor = true;
			this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
			// 
			// DeductionsSettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(387, 450);
			this.Controls.Add(this.DeleteBtn);
			this.Controls.Add(this.EditBtn);
			this.Controls.Add(this.NewBtn);
			this.Controls.Add(this.DeductionsListBox);
			this.Controls.Add(this.label1);
			this.Name = "DeductionsSettingsForm";
			this.Text = "DeductionsSettingsForm";
			this.Load += new System.EventHandler(this.DeductionsSettingsForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox DeductionsListBox;
		private System.Windows.Forms.Button NewBtn;
		private System.Windows.Forms.Button EditBtn;
		private System.Windows.Forms.Button DeleteBtn;
	}
}