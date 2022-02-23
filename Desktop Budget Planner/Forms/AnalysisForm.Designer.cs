using InteractiveCharts;

namespace Desktop_Budget_Planner.Forms {
    partial class AnalysisForm {
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.incomeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deductionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yNABToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BudgetSunburst = new InteractiveCharts.Sunburst.ZoomableSunburst();
            this.YnabButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DownloadDateLabel = new System.Windows.Forms.Label();
            this.hideCategoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.incomeToolStripMenuItem,
            this.deductionsToolStripMenuItem,
            this.yNABToolStripMenuItem,
            this.hideCategoriesToolStripMenuItem,
            this.devToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1373, 42);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // incomeToolStripMenuItem
            // 
            this.incomeToolStripMenuItem.Name = "incomeToolStripMenuItem";
            this.incomeToolStripMenuItem.Size = new System.Drawing.Size(113, 38);
            this.incomeToolStripMenuItem.Text = "Income";
            this.incomeToolStripMenuItem.Click += new System.EventHandler(this.incomeToolStripMenuItem_Click);
            // 
            // deductionsToolStripMenuItem
            // 
            this.deductionsToolStripMenuItem.Name = "deductionsToolStripMenuItem";
            this.deductionsToolStripMenuItem.Size = new System.Drawing.Size(155, 38);
            this.deductionsToolStripMenuItem.Text = "Deductions";
            this.deductionsToolStripMenuItem.Click += new System.EventHandler(this.deductionsToolStripMenuItem_Click);
            // 
            // yNABToolStripMenuItem
            // 
            this.yNABToolStripMenuItem.Name = "yNABToolStripMenuItem";
            this.yNABToolStripMenuItem.Size = new System.Drawing.Size(94, 38);
            this.yNABToolStripMenuItem.Text = "YNAB";
            this.yNABToolStripMenuItem.Click += new System.EventHandler(this.yNABToolStripMenuItem_Click);
            // 
            // devToolStripMenuItem
            // 
            this.devToolStripMenuItem.Name = "devToolStripMenuItem";
            this.devToolStripMenuItem.Size = new System.Drawing.Size(76, 38);
            this.devToolStripMenuItem.Text = "Dev";
            this.devToolStripMenuItem.Click += new System.EventHandler(this.devToolStripMenuItem_Click);
            // 
            // BudgetSunburst
            // 
            this.BudgetSunburst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BudgetSunburst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BudgetSunburst.Data = null;
            this.BudgetSunburst.Location = new System.Drawing.Point(0, 98);
            this.BudgetSunburst.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.BudgetSunburst.Name = "BudgetSunburst";
            this.BudgetSunburst.Size = new System.Drawing.Size(1358, 725);
            this.BudgetSunburst.TabIndex = 1;
            this.BudgetSunburst.TooltipContent = "var formatter = new Intl.NumberFormat(\'en-US\', {\r\nstyle: \'currency\',\r\ncurrency: \'" +
    "USD\',\r\n});\r\nreturn \"Amount: \" + formatter.format(d.value / 100);\r\n";
            this.BudgetSunburst.TooltipTitle = "var excludeRoot = false;\r\nreturn getNodeStack(d).slice(excludeRoot ? 1 : 0).map(f" +
    "unction(d) {\r\nreturn d.data.name;\r\n}).join(\' &rarr; \');\r\n";
            this.BudgetSunburst.Load += new System.EventHandler(this.BudgetSunburst_Load);
            // 
            // YnabButton
            // 
            this.YnabButton.Location = new System.Drawing.Point(12, 43);
            this.YnabButton.Name = "YnabButton";
            this.YnabButton.Size = new System.Drawing.Size(150, 46);
            this.YnabButton.TabIndex = 2;
            this.YnabButton.Text = "YNAB";
            this.YnabButton.UseVisualStyleBackColor = true;
            this.YnabButton.Click += new System.EventHandler(this.YnabButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Last downloaded on: ";
            // 
            // DownloadDateLabel
            // 
            this.DownloadDateLabel.AutoSize = true;
            this.DownloadDateLabel.Location = new System.Drawing.Point(415, 50);
            this.DownloadDateLabel.Name = "DownloadDateLabel";
            this.DownloadDateLabel.Size = new System.Drawing.Size(73, 32);
            this.DownloadDateLabel.TabIndex = 4;
            this.DownloadDateLabel.Text = "None";
            // 
            // hideCategoriesToolStripMenuItem
            // 
            this.hideCategoriesToolStripMenuItem.Name = "hideCategoriesToolStripMenuItem";
            this.hideCategoriesToolStripMenuItem.Size = new System.Drawing.Size(204, 38);
            this.hideCategoriesToolStripMenuItem.Text = "Hide Categories";
            this.hideCategoriesToolStripMenuItem.Click += new System.EventHandler(this.hideCategoriesToolStripMenuItem_Click);
            // 
            // AnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1373, 838);
            this.Controls.Add(this.DownloadDateLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.YnabButton);
            this.Controls.Add(this.BudgetSunburst);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AnalysisForm";
            this.Text = "AnalysisForm";
            this.Load += new System.EventHandler(this.AnalysisForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem incomeToolStripMenuItem;
        private ToolStripMenuItem deductionsToolStripMenuItem;
        private ToolStripMenuItem yNABToolStripMenuItem;
        private InteractiveCharts.Sunburst.ZoomableSunburst BudgetSunburst;
        private ToolStripMenuItem devToolStripMenuItem;
        private Button YnabButton;
        private Label label1;
        private Label DownloadDateLabel;
        private ToolStripMenuItem hideCategoriesToolStripMenuItem;
    }
}