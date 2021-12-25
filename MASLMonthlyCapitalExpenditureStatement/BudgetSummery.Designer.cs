
namespace MASLMonthlyCapitalExpenditureStatement
{
    partial class BudgetSummery
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BudgetSummery));
            this.ChartBudget = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ComboBoxSource = new Guna.UI2.WinForms.Guna2ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.ChartBudget)).BeginInit();
            this.SuspendLayout();
            // 
            // ChartBudget
            // 
            chartArea1.AxisX.IsMarginVisible = false;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.Name = "ChartArea1";
            this.ChartBudget.ChartAreas.Add(chartArea1);
            this.ChartBudget.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.ChartBudget.Legends.Add(legend1);
            this.ChartBudget.Location = new System.Drawing.Point(0, 0);
            this.ChartBudget.Name = "ChartBudget";
            this.ChartBudget.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.ChartBudget.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(210)))), ((int)(((byte)(21))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(190)))), ((int)(((byte)(240))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(45)))), ((int)(((byte)(120))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(29)))), ((int)(((byte)(40)))))};
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Budget - Capital";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Budget - Recurrent";
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Prograss - Capital";
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "Progress - Recurrent";
            this.ChartBudget.Series.Add(series1);
            this.ChartBudget.Series.Add(series2);
            this.ChartBudget.Series.Add(series3);
            this.ChartBudget.Series.Add(series4);
            this.ChartBudget.Size = new System.Drawing.Size(684, 461);
            this.ChartBudget.TabIndex = 2;
            this.ChartBudget.Text = "chart1";
            title1.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            title1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Budget 2020 JAN";
            this.ChartBudget.Titles.Add(title1);
            // 
            // ComboBoxSource
            // 
            this.ComboBoxSource.BackColor = System.Drawing.Color.Transparent;
            this.ComboBoxSource.BorderRadius = 17;
            this.ComboBoxSource.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboBoxSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxSource.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboBoxSource.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboBoxSource.FocusedState.Parent = this.ComboBoxSource;
            this.ComboBoxSource.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ComboBoxSource.ForeColor = System.Drawing.Color.DimGray;
            this.ComboBoxSource.HoverState.Parent = this.ComboBoxSource;
            this.ComboBoxSource.ItemHeight = 30;
            this.ComboBoxSource.ItemsAppearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(29)))), ((int)(((byte)(40)))));
            this.ComboBoxSource.ItemsAppearance.Parent = this.ComboBoxSource;
            this.ComboBoxSource.ItemsAppearance.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(45)))), ((int)(((byte)(120)))));
            this.ComboBoxSource.ItemsAppearance.SelectedForeColor = System.Drawing.Color.White;
            this.ComboBoxSource.Location = new System.Drawing.Point(458, 17);
            this.ComboBoxSource.Name = "ComboBoxSource";
            this.ComboBoxSource.ShadowDecoration.Parent = this.ComboBoxSource;
            this.ComboBoxSource.Size = new System.Drawing.Size(207, 36);
            this.ComboBoxSource.TabIndex = 39;
            this.ComboBoxSource.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ComboBoxSource.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSource_SelectedIndexChanged);
            // 
            // BudgetSummery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.ComboBoxSource);
            this.Controls.Add(this.ChartBudget);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BudgetSummery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Budget Summery";
            this.Load += new System.EventHandler(this.BudgetSummery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ChartBudget)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataVisualization.Charting.Chart ChartBudget;
        public Guna.UI2.WinForms.Guna2ComboBox ComboBoxSource;
    }
}