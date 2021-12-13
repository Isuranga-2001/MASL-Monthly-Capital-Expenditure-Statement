
namespace MASLMonthlyCapitalExpenditureStatement
{
    partial class ExportWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.ExpenditureTableCheckBox = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.IncomeTableCheckBox = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.BudgetTableCheckBox = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.MainTableCheckBox = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnExport = new Guna.UI2.WinForms.Guna2Button();
            this.label6 = new System.Windows.Forms.Label();
            this.ToggleSwitchIsSingleFile = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.ProgressBarStatusOfExportProcess = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12.5F);
            this.label1.Location = new System.Drawing.Point(26, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Tables For Export :";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderRadius = 20;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.ExpenditureTableCheckBox);
            this.guna2Panel1.Controls.Add(this.IncomeTableCheckBox);
            this.guna2Panel1.Controls.Add(this.BudgetTableCheckBox);
            this.guna2Panel1.Controls.Add(this.MainTableCheckBox);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.label3);
            this.guna2Panel1.Controls.Add(this.label4);
            this.guna2Panel1.Controls.Add(this.label5);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.guna2Panel1.Location = new System.Drawing.Point(25, 28);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.BorderRadius = 20;
            this.guna2Panel1.ShadowDecoration.Color = System.Drawing.Color.DimGray;
            this.guna2Panel1.ShadowDecoration.Enabled = true;
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2, 2, 3, 3);
            this.guna2Panel1.Size = new System.Drawing.Size(432, 231);
            this.guna2Panel1.TabIndex = 1;
            // 
            // ExpenditureTableCheckBox
            // 
            this.ExpenditureTableCheckBox.Animated = true;
            this.ExpenditureTableCheckBox.Checked = true;
            this.ExpenditureTableCheckBox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(45)))), ((int)(((byte)(120)))));
            this.ExpenditureTableCheckBox.CheckedState.BorderRadius = 5;
            this.ExpenditureTableCheckBox.CheckedState.BorderThickness = 0;
            this.ExpenditureTableCheckBox.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(45)))), ((int)(((byte)(120)))));
            this.ExpenditureTableCheckBox.CheckedState.Parent = this.ExpenditureTableCheckBox;
            this.ExpenditureTableCheckBox.Location = new System.Drawing.Point(43, 178);
            this.ExpenditureTableCheckBox.Name = "ExpenditureTableCheckBox";
            this.ExpenditureTableCheckBox.ShadowDecoration.Parent = this.ExpenditureTableCheckBox;
            this.ExpenditureTableCheckBox.Size = new System.Drawing.Size(21, 21);
            this.ExpenditureTableCheckBox.TabIndex = 6;
            this.ExpenditureTableCheckBox.Tag = "Expenditure";
            this.ExpenditureTableCheckBox.Text = "guna2CustomCheckBox1";
            this.ExpenditureTableCheckBox.UncheckedState.BorderColor = System.Drawing.Color.Silver;
            this.ExpenditureTableCheckBox.UncheckedState.BorderRadius = 5;
            this.ExpenditureTableCheckBox.UncheckedState.BorderThickness = 0;
            this.ExpenditureTableCheckBox.UncheckedState.FillColor = System.Drawing.Color.Silver;
            this.ExpenditureTableCheckBox.UncheckedState.Parent = this.ExpenditureTableCheckBox;
            this.ExpenditureTableCheckBox.CheckedChanged += new System.EventHandler(this.AvailabilityCheckBox_CheckedChanged);
            // 
            // IncomeTableCheckBox
            // 
            this.IncomeTableCheckBox.Animated = true;
            this.IncomeTableCheckBox.Checked = true;
            this.IncomeTableCheckBox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(45)))), ((int)(((byte)(120)))));
            this.IncomeTableCheckBox.CheckedState.BorderRadius = 5;
            this.IncomeTableCheckBox.CheckedState.BorderThickness = 0;
            this.IncomeTableCheckBox.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(45)))), ((int)(((byte)(120)))));
            this.IncomeTableCheckBox.CheckedState.Parent = this.IncomeTableCheckBox;
            this.IncomeTableCheckBox.Location = new System.Drawing.Point(43, 139);
            this.IncomeTableCheckBox.Name = "IncomeTableCheckBox";
            this.IncomeTableCheckBox.ShadowDecoration.Parent = this.IncomeTableCheckBox;
            this.IncomeTableCheckBox.Size = new System.Drawing.Size(21, 21);
            this.IncomeTableCheckBox.TabIndex = 6;
            this.IncomeTableCheckBox.Tag = "Income";
            this.IncomeTableCheckBox.Text = "guna2CustomCheckBox1";
            this.IncomeTableCheckBox.UncheckedState.BorderColor = System.Drawing.Color.Silver;
            this.IncomeTableCheckBox.UncheckedState.BorderRadius = 5;
            this.IncomeTableCheckBox.UncheckedState.BorderThickness = 0;
            this.IncomeTableCheckBox.UncheckedState.FillColor = System.Drawing.Color.Silver;
            this.IncomeTableCheckBox.UncheckedState.Parent = this.IncomeTableCheckBox;
            this.IncomeTableCheckBox.CheckedChanged += new System.EventHandler(this.AvailabilityCheckBox_CheckedChanged);
            // 
            // BudgetTableCheckBox
            // 
            this.BudgetTableCheckBox.Animated = true;
            this.BudgetTableCheckBox.Checked = true;
            this.BudgetTableCheckBox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(45)))), ((int)(((byte)(120)))));
            this.BudgetTableCheckBox.CheckedState.BorderRadius = 5;
            this.BudgetTableCheckBox.CheckedState.BorderThickness = 0;
            this.BudgetTableCheckBox.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(45)))), ((int)(((byte)(120)))));
            this.BudgetTableCheckBox.CheckedState.Parent = this.BudgetTableCheckBox;
            this.BudgetTableCheckBox.Location = new System.Drawing.Point(43, 102);
            this.BudgetTableCheckBox.Name = "BudgetTableCheckBox";
            this.BudgetTableCheckBox.ShadowDecoration.Parent = this.BudgetTableCheckBox;
            this.BudgetTableCheckBox.Size = new System.Drawing.Size(21, 21);
            this.BudgetTableCheckBox.TabIndex = 6;
            this.BudgetTableCheckBox.Tag = "Budget";
            this.BudgetTableCheckBox.Text = "guna2CustomCheckBox1";
            this.BudgetTableCheckBox.UncheckedState.BorderColor = System.Drawing.Color.Silver;
            this.BudgetTableCheckBox.UncheckedState.BorderRadius = 5;
            this.BudgetTableCheckBox.UncheckedState.BorderThickness = 0;
            this.BudgetTableCheckBox.UncheckedState.FillColor = System.Drawing.Color.Silver;
            this.BudgetTableCheckBox.UncheckedState.Parent = this.BudgetTableCheckBox;
            this.BudgetTableCheckBox.CheckedChanged += new System.EventHandler(this.AvailabilityCheckBox_CheckedChanged);
            // 
            // MainTableCheckBox
            // 
            this.MainTableCheckBox.Animated = true;
            this.MainTableCheckBox.Checked = true;
            this.MainTableCheckBox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(45)))), ((int)(((byte)(120)))));
            this.MainTableCheckBox.CheckedState.BorderRadius = 5;
            this.MainTableCheckBox.CheckedState.BorderThickness = 0;
            this.MainTableCheckBox.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(45)))), ((int)(((byte)(120)))));
            this.MainTableCheckBox.CheckedState.Parent = this.MainTableCheckBox;
            this.MainTableCheckBox.Location = new System.Drawing.Point(43, 61);
            this.MainTableCheckBox.Name = "MainTableCheckBox";
            this.MainTableCheckBox.ShadowDecoration.Parent = this.MainTableCheckBox;
            this.MainTableCheckBox.Size = new System.Drawing.Size(21, 21);
            this.MainTableCheckBox.TabIndex = 6;
            this.MainTableCheckBox.Tag = "Main";
            this.MainTableCheckBox.Text = "guna2CustomCheckBox1";
            this.MainTableCheckBox.UncheckedState.BorderColor = System.Drawing.Color.Silver;
            this.MainTableCheckBox.UncheckedState.BorderRadius = 5;
            this.MainTableCheckBox.UncheckedState.BorderThickness = 0;
            this.MainTableCheckBox.UncheckedState.FillColor = System.Drawing.Color.Silver;
            this.MainTableCheckBox.UncheckedState.Parent = this.MainTableCheckBox;
            this.MainTableCheckBox.CheckedChanged += new System.EventHandler(this.AvailabilityCheckBox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(75, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Table Last Month Total Expenditure";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(75, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Table Budget Details";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(75, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "Table Income Details";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(75, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(287, 21);
            this.label5.TabIndex = 5;
            this.label5.Text = "Table Details of Expenditures of Activties";
            // 
            // btnExport
            // 
            this.btnExport.Animated = true;
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.btnExport.BorderRadius = 17;
            this.btnExport.CheckedState.Parent = this.btnExport;
            this.btnExport.CustomImages.Parent = this.btnExport;
            this.btnExport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExport.DisabledState.Parent = this.btnExport;
            this.btnExport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(190)))), ((int)(((byte)(240)))));
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.btnExport.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(45)))), ((int)(((byte)(120)))));
            this.btnExport.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnExport.HoverState.Parent = this.btnExport;
            this.btnExport.Location = new System.Drawing.Point(329, 282);
            this.btnExport.Name = "btnExport";
            this.btnExport.ShadowDecoration.BorderRadius = 17;
            this.btnExport.ShadowDecoration.Enabled = true;
            this.btnExport.ShadowDecoration.Parent = this.btnExport;
            this.btnExport.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1, 1, 4, 4);
            this.btnExport.Size = new System.Drawing.Size(128, 38);
            this.btnExport.TabIndex = 27;
            this.btnExport.Text = "Export";
            this.btnExport.TextOffset = new System.Drawing.Point(0, -1);
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 290);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(207, 21);
            this.label6.TabIndex = 4;
            this.label6.Text = "Export all tables to single file";
            // 
            // ToggleSwitchIsSingleFile
            // 
            this.ToggleSwitchIsSingleFile.Animated = true;
            this.ToggleSwitchIsSingleFile.Checked = true;
            this.ToggleSwitchIsSingleFile.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(45)))), ((int)(((byte)(120)))));
            this.ToggleSwitchIsSingleFile.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(45)))), ((int)(((byte)(120)))));
            this.ToggleSwitchIsSingleFile.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.ToggleSwitchIsSingleFile.CheckedState.InnerColor = System.Drawing.Color.White;
            this.ToggleSwitchIsSingleFile.CheckedState.Parent = this.ToggleSwitchIsSingleFile;
            this.ToggleSwitchIsSingleFile.Location = new System.Drawing.Point(239, 291);
            this.ToggleSwitchIsSingleFile.Name = "ToggleSwitchIsSingleFile";
            this.ToggleSwitchIsSingleFile.ShadowDecoration.Parent = this.ToggleSwitchIsSingleFile;
            this.ToggleSwitchIsSingleFile.Size = new System.Drawing.Size(35, 20);
            this.ToggleSwitchIsSingleFile.TabIndex = 28;
            this.ToggleSwitchIsSingleFile.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.ToggleSwitchIsSingleFile.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.ToggleSwitchIsSingleFile.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.ToggleSwitchIsSingleFile.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.ToggleSwitchIsSingleFile.UncheckedState.Parent = this.ToggleSwitchIsSingleFile;
            // 
            // ProgressBarStatusOfExportProcess
            // 
            this.ProgressBarStatusOfExportProcess.BorderRadius = 15;
            this.ProgressBarStatusOfExportProcess.Location = new System.Drawing.Point(25, 356);
            this.ProgressBarStatusOfExportProcess.Name = "ProgressBarStatusOfExportProcess";
            this.ProgressBarStatusOfExportProcess.ProgressBrushMode = Guna.UI2.WinForms.Enums.BrushMode.SolidTransition;
            this.ProgressBarStatusOfExportProcess.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(210)))), ((int)(((byte)(21)))));
            this.ProgressBarStatusOfExportProcess.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ProgressBarStatusOfExportProcess.ShadowDecoration.Parent = this.ProgressBarStatusOfExportProcess;
            this.ProgressBarStatusOfExportProcess.Size = new System.Drawing.Size(432, 30);
            this.ProgressBarStatusOfExportProcess.TabIndex = 29;
            this.ProgressBarStatusOfExportProcess.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.ProgressBarStatusOfExportProcess.UseWaitCursor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(31, 332);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 21);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status";
            // 
            // ExportWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 411);
            this.Controls.Add(this.ProgressBarStatusOfExportProcess);
            this.Controls.Add(this.ToggleSwitchIsSingleFile);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export";
            this.Load += new System.EventHandler(this.ExportWindow_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2CustomCheckBox ExpenditureTableCheckBox;
        private Guna.UI2.WinForms.Guna2CustomCheckBox IncomeTableCheckBox;
        private Guna.UI2.WinForms.Guna2CustomCheckBox BudgetTableCheckBox;
        private Guna.UI2.WinForms.Guna2CustomCheckBox MainTableCheckBox;
        public Guna.UI2.WinForms.Guna2Button btnExport;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2ToggleSwitch ToggleSwitchIsSingleFile;
        private Guna.UI2.WinForms.Guna2ProgressBar ProgressBarStatusOfExportProcess;
        private System.Windows.Forms.Label lblStatus;
    }
}