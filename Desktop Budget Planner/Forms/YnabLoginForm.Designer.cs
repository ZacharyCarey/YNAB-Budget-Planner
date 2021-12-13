namespace Desktop_Budget_Planner.Forms {
    partial class YnabLoginForm {
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
            this.TokenInputBox = new System.Windows.Forms.TextBox();
            this.ShowTokenCheckBox = new System.Windows.Forms.CheckBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "API Access Token:";
            // 
            // TokenInputBox
            // 
            this.TokenInputBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TokenInputBox.Location = new System.Drawing.Point(13, 44);
            this.TokenInputBox.Name = "TokenInputBox";
            this.TokenInputBox.Size = new System.Drawing.Size(775, 39);
            this.TokenInputBox.TabIndex = 1;
            // 
            // ShowTokenCheckBox
            // 
            this.ShowTokenCheckBox.AutoSize = true;
            this.ShowTokenCheckBox.Location = new System.Drawing.Point(12, 89);
            this.ShowTokenCheckBox.Name = "ShowTokenCheckBox";
            this.ShowTokenCheckBox.Size = new System.Drawing.Size(175, 36);
            this.ShowTokenCheckBox.TabIndex = 2;
            this.ShowTokenCheckBox.Text = "Show Token";
            this.ShowTokenCheckBox.UseVisualStyleBackColor = true;
            this.ShowTokenCheckBox.CheckedChanged += new System.EventHandler(this.ShowTokenCheckBox_CheckedChanged);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(638, 171);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(150, 55);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // YnabLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 238);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ShowTokenCheckBox);
            this.Controls.Add(this.TokenInputBox);
            this.Controls.Add(this.label1);
            this.Name = "YnabLoginForm";
            this.Text = "YnabLoginForm";
            this.Load += new System.EventHandler(this.YnabLoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox TokenInputBox;
        private CheckBox ShowTokenCheckBox;
        private Button SaveButton;
    }
}