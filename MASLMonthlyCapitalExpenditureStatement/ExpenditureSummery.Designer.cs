
namespace MASLMonthlyCapitalExpenditureStatement
{
    partial class ExpenditureSummery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpenditureSummery));
            this.ChartExpenditure = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.PrecentageProgressBar = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.txtItemNo = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtActivity = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtCumulativeExpen = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtAllocation = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCommitment = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBudgetCode = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtSelectedYear = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ChartExpenditure)).BeginInit();
            this.SuspendLayout();
            // 
            // ChartExpenditure
            // 
            chartArea1.AxisX.IsMarginVisible = false;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.Name = "ChartArea1";
            this.ChartExpenditure.ChartAreas.Add(chartArea1);
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.ChartExpenditure.Legends.Add(legend1);
            this.ChartExpenditure.Location = new System.Drawing.Point(12, 301);
            this.ChartExpenditure.Name = "ChartExpenditure";
            this.ChartExpenditure.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.ChartExpenditure.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(210)))), ((int)(((byte)(21))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(190)))), ((int)(((byte)(240))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(45)))), ((int)(((byte)(120)))))};
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Budget";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Progress";
            this.ChartExpenditure.Series.Add(series1);
            this.ChartExpenditure.Series.Add(series2);
            this.ChartExpenditure.Size = new System.Drawing.Size(680, 298);
            this.ChartExpenditure.TabIndex = 1;
            this.ChartExpenditure.Text = "chart1";
            // 
            // PrecentageProgressBar
            // 
            this.PrecentageProgressBar.FillColor = System.Drawing.Color.White;
            this.PrecentageProgressBar.FillThickness = 20;
            this.PrecentageProgressBar.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.PrecentageProgressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(45)))), ((int)(((byte)(120)))));
            this.PrecentageProgressBar.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.PrecentageProgressBar.InnerColor = System.Drawing.Color.White;
            this.PrecentageProgressBar.Location = new System.Drawing.Point(530, 48);
            this.PrecentageProgressBar.Minimum = 0;
            this.PrecentageProgressBar.Name = "PrecentageProgressBar";
            this.PrecentageProgressBar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(210)))), ((int)(((byte)(21)))));
            this.PrecentageProgressBar.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(190)))), ((int)(((byte)(240)))));
            this.PrecentageProgressBar.ProgressEndCap = System.Drawing.Drawing2D.LineCap.Round;
            this.PrecentageProgressBar.ProgressStartCap = System.Drawing.Drawing2D.LineCap.Round;
            this.PrecentageProgressBar.ProgressThickness = 20;
            this.PrecentageProgressBar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.PrecentageProgressBar.ShadowDecoration.Parent = this.PrecentageProgressBar;
            this.PrecentageProgressBar.ShowPercentage = true;
            this.PrecentageProgressBar.Size = new System.Drawing.Size(154, 154);
            this.PrecentageProgressBar.TabIndex = 13;
            this.PrecentageProgressBar.Text = "guna2CircleProgressBar1";
            this.PrecentageProgressBar.Value = 65;
            // 
            // txtItemNo
            // 
            this.txtItemNo.BorderRadius = 17;
            this.txtItemNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtItemNo.DefaultText = "";
            this.txtItemNo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtItemNo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtItemNo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtItemNo.DisabledState.Parent = this.txtItemNo;
            this.txtItemNo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtItemNo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtItemNo.FocusedState.Parent = this.txtItemNo;
            this.txtItemNo.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtItemNo.ForeColor = System.Drawing.Color.DimGray;
            this.txtItemNo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtItemNo.HoverState.Parent = this.txtItemNo;
            this.txtItemNo.Location = new System.Drawing.Point(352, 48);
            this.txtItemNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtItemNo.Name = "txtItemNo";
            this.txtItemNo.PasswordChar = '\0';
            this.txtItemNo.PlaceholderText = "";
            this.txtItemNo.ReadOnly = true;
            this.txtItemNo.SelectedText = "";
            this.txtItemNo.ShadowDecoration.Parent = this.txtItemNo;
            this.txtItemNo.Size = new System.Drawing.Size(153, 36);
            this.txtItemNo.TabIndex = 18;
            this.txtItemNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(29)))), ((int)(((byte)(40)))));
            this.label4.Location = new System.Drawing.Point(397, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Item No";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(29)))), ((int)(((byte)(40)))));
            this.label3.Location = new System.Drawing.Point(194, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "MASL Budget Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(29)))), ((int)(((byte)(40)))));
            this.label2.Location = new System.Drawing.Point(70, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Year";
            // 
            // txtActivity
            // 
            this.txtActivity.Animated = true;
            this.txtActivity.BackColor = System.Drawing.Color.White;
            this.txtActivity.BorderRadius = 17;
            this.txtActivity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtActivity.DefaultText = "";
            this.txtActivity.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtActivity.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtActivity.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtActivity.DisabledState.Parent = this.txtActivity;
            this.txtActivity.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtActivity.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtActivity.FocusedState.Parent = this.txtActivity;
            this.txtActivity.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtActivity.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtActivity.HoverState.Parent = this.txtActivity;
            this.txtActivity.Location = new System.Drawing.Point(23, 123);
            this.txtActivity.Margin = new System.Windows.Forms.Padding(4);
            this.txtActivity.Multiline = true;
            this.txtActivity.Name = "txtActivity";
            this.txtActivity.PasswordChar = '\0';
            this.txtActivity.PlaceholderText = "Activity Name";
            this.txtActivity.ReadOnly = true;
            this.txtActivity.SelectedText = "";
            this.txtActivity.ShadowDecoration.Parent = this.txtActivity;
            this.txtActivity.Size = new System.Drawing.Size(482, 79);
            this.txtActivity.TabIndex = 20;
            this.txtActivity.TextOffset = new System.Drawing.Point(10, 0);
            // 
            // txtCumulativeExpen
            // 
            this.txtCumulativeExpen.BorderRadius = 17;
            this.txtCumulativeExpen.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCumulativeExpen.DefaultText = "";
            this.txtCumulativeExpen.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCumulativeExpen.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCumulativeExpen.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCumulativeExpen.DisabledState.Parent = this.txtCumulativeExpen;
            this.txtCumulativeExpen.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCumulativeExpen.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCumulativeExpen.FocusedState.Parent = this.txtCumulativeExpen;
            this.txtCumulativeExpen.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtCumulativeExpen.ForeColor = System.Drawing.Color.DimGray;
            this.txtCumulativeExpen.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCumulativeExpen.HoverState.Parent = this.txtCumulativeExpen;
            this.txtCumulativeExpen.Location = new System.Drawing.Point(247, 249);
            this.txtCumulativeExpen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCumulativeExpen.Name = "txtCumulativeExpen";
            this.txtCumulativeExpen.PasswordChar = '\0';
            this.txtCumulativeExpen.PlaceholderText = "Cumulative Expen.";
            this.txtCumulativeExpen.ReadOnly = true;
            this.txtCumulativeExpen.SelectedText = "";
            this.txtCumulativeExpen.ShadowDecoration.Parent = this.txtCumulativeExpen;
            this.txtCumulativeExpen.Size = new System.Drawing.Size(210, 36);
            this.txtCumulativeExpen.TabIndex = 22;
            this.txtCumulativeExpen.Tag = "2";
            this.txtCumulativeExpen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAllocation
            // 
            this.txtAllocation.BackColor = System.Drawing.Color.Transparent;
            this.txtAllocation.BorderRadius = 17;
            this.txtAllocation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAllocation.DefaultText = "";
            this.txtAllocation.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAllocation.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAllocation.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAllocation.DisabledState.Parent = this.txtAllocation;
            this.txtAllocation.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAllocation.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAllocation.FocusedState.Parent = this.txtAllocation;
            this.txtAllocation.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtAllocation.ForeColor = System.Drawing.Color.DimGray;
            this.txtAllocation.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAllocation.HoverState.Parent = this.txtAllocation;
            this.txtAllocation.Location = new System.Drawing.Point(23, 249);
            this.txtAllocation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAllocation.Name = "txtAllocation";
            this.txtAllocation.PasswordChar = '\0';
            this.txtAllocation.PlaceholderText = "Allocation";
            this.txtAllocation.ReadOnly = true;
            this.txtAllocation.SelectedText = "";
            this.txtAllocation.ShadowDecoration.Parent = this.txtAllocation;
            this.txtAllocation.Size = new System.Drawing.Size(210, 36);
            this.txtAllocation.TabIndex = 23;
            this.txtAllocation.Tag = "1";
            this.txtAllocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(29)))), ((int)(((byte)(40)))));
            this.label8.Location = new System.Drawing.Point(270, 228);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(166, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "Cumulative Expenditure";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(29)))), ((int)(((byte)(40)))));
            this.label5.Location = new System.Drawing.Point(75, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 25;
            this.label5.Text = "Activity";
            // 
            // txtCommitment
            // 
            this.txtCommitment.BorderRadius = 17;
            this.txtCommitment.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCommitment.DefaultText = "";
            this.txtCommitment.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCommitment.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCommitment.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCommitment.DisabledState.Parent = this.txtCommitment;
            this.txtCommitment.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCommitment.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCommitment.FocusedState.Parent = this.txtCommitment;
            this.txtCommitment.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtCommitment.ForeColor = System.Drawing.Color.DimGray;
            this.txtCommitment.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCommitment.HoverState.Parent = this.txtCommitment;
            this.txtCommitment.Location = new System.Drawing.Point(474, 249);
            this.txtCommitment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCommitment.Name = "txtCommitment";
            this.txtCommitment.PasswordChar = '\0';
            this.txtCommitment.PlaceholderText = "Commitment";
            this.txtCommitment.ReadOnly = true;
            this.txtCommitment.SelectedText = "";
            this.txtCommitment.ShadowDecoration.Parent = this.txtCommitment;
            this.txtCommitment.Size = new System.Drawing.Size(210, 36);
            this.txtCommitment.TabIndex = 27;
            this.txtCommitment.Tag = "2";
            this.txtCommitment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(29)))), ((int)(((byte)(40)))));
            this.label1.Location = new System.Drawing.Point(526, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = "Commitment";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(29)))), ((int)(((byte)(40)))));
            this.label6.Location = new System.Drawing.Point(88, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 20);
            this.label6.TabIndex = 28;
            this.label6.Text = "Allocation";
            // 
            // txtBudgetCode
            // 
            this.txtBudgetCode.BorderRadius = 17;
            this.txtBudgetCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBudgetCode.DefaultText = "";
            this.txtBudgetCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBudgetCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBudgetCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBudgetCode.DisabledState.Parent = this.txtBudgetCode;
            this.txtBudgetCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBudgetCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBudgetCode.FocusedState.Parent = this.txtBudgetCode;
            this.txtBudgetCode.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtBudgetCode.ForeColor = System.Drawing.Color.DimGray;
            this.txtBudgetCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBudgetCode.HoverState.Parent = this.txtBudgetCode;
            this.txtBudgetCode.Location = new System.Drawing.Point(166, 48);
            this.txtBudgetCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBudgetCode.Name = "txtBudgetCode";
            this.txtBudgetCode.PasswordChar = '\0';
            this.txtBudgetCode.PlaceholderText = "";
            this.txtBudgetCode.ReadOnly = true;
            this.txtBudgetCode.SelectedText = "";
            this.txtBudgetCode.ShadowDecoration.Parent = this.txtBudgetCode;
            this.txtBudgetCode.Size = new System.Drawing.Size(178, 36);
            this.txtBudgetCode.TabIndex = 29;
            this.txtBudgetCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSelectedYear
            // 
            this.txtSelectedYear.BorderRadius = 17;
            this.txtSelectedYear.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSelectedYear.DefaultText = "";
            this.txtSelectedYear.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSelectedYear.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSelectedYear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSelectedYear.DisabledState.Parent = this.txtSelectedYear;
            this.txtSelectedYear.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSelectedYear.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSelectedYear.FocusedState.Parent = this.txtSelectedYear;
            this.txtSelectedYear.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtSelectedYear.ForeColor = System.Drawing.Color.DimGray;
            this.txtSelectedYear.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSelectedYear.HoverState.Parent = this.txtSelectedYear;
            this.txtSelectedYear.Location = new System.Drawing.Point(23, 48);
            this.txtSelectedYear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSelectedYear.Name = "txtSelectedYear";
            this.txtSelectedYear.PasswordChar = '\0';
            this.txtSelectedYear.PlaceholderText = "";
            this.txtSelectedYear.ReadOnly = true;
            this.txtSelectedYear.SelectedText = "";
            this.txtSelectedYear.ShadowDecoration.Parent = this.txtSelectedYear;
            this.txtSelectedYear.Size = new System.Drawing.Size(135, 36);
            this.txtSelectedYear.TabIndex = 30;
            this.txtSelectedYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ExpenditureSummery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(704, 611);
            this.Controls.Add(this.txtSelectedYear);
            this.Controls.Add(this.txtBudgetCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCommitment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCumulativeExpen);
            this.Controls.Add(this.txtAllocation);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtActivity);
            this.Controls.Add(this.txtItemNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PrecentageProgressBar);
            this.Controls.Add(this.ChartExpenditure);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ExpenditureSummery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Expenditure Summery";
            ((System.ComponentModel.ISupportInitialize)(this.ChartExpenditure)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataVisualization.Charting.Chart ChartExpenditure;
        public Guna.UI2.WinForms.Guna2CircleProgressBar PrecentageProgressBar;
        public Guna.UI2.WinForms.Guna2TextBox txtItemNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public Guna.UI2.WinForms.Guna2TextBox txtActivity;
        public Guna.UI2.WinForms.Guna2TextBox txtCumulativeExpen;
        public Guna.UI2.WinForms.Guna2TextBox txtAllocation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        public Guna.UI2.WinForms.Guna2TextBox txtCommitment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        public Guna.UI2.WinForms.Guna2TextBox txtBudgetCode;
        public Guna.UI2.WinForms.Guna2TextBox txtSelectedYear;
    }
}