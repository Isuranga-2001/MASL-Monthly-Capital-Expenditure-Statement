
namespace MASLMonthlyCapitalExpenditureStatement
{
    partial class MonthlyExpenditure
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonthlyExpenditure));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectedYear = new Guna.UI2.WinForms.Guna2Button();
            this.btnUpdate = new Guna.UI2.WinForms.Guna2Button();
            this.txtItemNo = new Guna.UI2.WinForms.Guna2TextBox();
            this.ComboBoxBudgetCode = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.btnSelectMonth = new Guna.UI2.WinForms.Guna2Button();
            this.lblExpenditure = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TableActivities = new Guna.UI2.WinForms.Guna2DataGridView();
            this.ItemNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActivityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShowExpenditure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtExpenditure = new Guna.UI2.WinForms.Guna2TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCulmulativeExpenditure = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblCumulativeExp = new System.Windows.Forms.Label();
            this.NotificationPaintNeedUpdate = new Guna.UI2.WinForms.Guna2NotificationPaint(this.components);
            this.guna2Panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TableActivities)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderRadius = 25;
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.btnSelectedYear);
            this.guna2Panel1.Controls.Add(this.btnUpdate);
            this.guna2Panel1.Controls.Add(this.txtItemNo);
            this.guna2Panel1.Controls.Add(this.ComboBoxBudgetCode);
            this.guna2Panel1.Controls.Add(this.label7);
            this.guna2Panel1.Controls.Add(this.label3);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.btnSearch);
            this.guna2Panel1.Controls.Add(this.btnSelectMonth);
            this.guna2Panel1.CustomizableEdges.TopLeft = false;
            this.guna2Panel1.CustomizableEdges.TopRight = false;
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.BorderRadius = 25;
            this.guna2Panel1.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.guna2Panel1.ShadowDecoration.Enabled = true;
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(815, 104);
            this.guna2Panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(29)))), ((int)(((byte)(40)))));
            this.label1.Location = new System.Drawing.Point(82, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "Year";
            // 
            // btnSelectedYear
            // 
            this.btnSelectedYear.Animated = true;
            this.btnSelectedYear.BackColor = System.Drawing.Color.Transparent;
            this.btnSelectedYear.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.btnSelectedYear.BorderRadius = 17;
            this.btnSelectedYear.BorderThickness = 1;
            this.btnSelectedYear.CheckedState.Parent = this.btnSelectedYear;
            this.btnSelectedYear.CustomImages.Parent = this.btnSelectedYear;
            this.btnSelectedYear.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSelectedYear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSelectedYear.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSelectedYear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSelectedYear.DisabledState.Parent = this.btnSelectedYear;
            this.btnSelectedYear.FillColor = System.Drawing.Color.White;
            this.btnSelectedYear.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnSelectedYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(29)))), ((int)(((byte)(40)))));
            this.btnSelectedYear.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.btnSelectedYear.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(190)))), ((int)(((byte)(240)))));
            this.btnSelectedYear.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnSelectedYear.HoverState.Parent = this.btnSelectedYear;
            this.btnSelectedYear.Location = new System.Drawing.Point(35, 44);
            this.btnSelectedYear.Name = "btnSelectedYear";
            this.btnSelectedYear.ShadowDecoration.BorderRadius = 17;
            this.btnSelectedYear.ShadowDecoration.Parent = this.btnSelectedYear;
            this.btnSelectedYear.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2, 2, 3, 3);
            this.btnSelectedYear.Size = new System.Drawing.Size(136, 36);
            this.btnSelectedYear.TabIndex = 24;
            this.btnSelectedYear.Text = "2020";
            this.btnSelectedYear.Click += new System.EventHandler(this.ChangeSelectedMonth);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Animated = true;
            this.btnUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.btnUpdate.BorderRadius = 17;
            this.btnUpdate.BorderThickness = 1;
            this.btnUpdate.CheckedState.Parent = this.btnUpdate;
            this.btnUpdate.CustomImages.Parent = this.btnUpdate;
            this.btnUpdate.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.btnUpdate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUpdate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.btnUpdate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUpdate.DisabledState.Parent = this.btnUpdate;
            this.btnUpdate.FillColor = System.Drawing.Color.White;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(29)))), ((int)(((byte)(40)))));
            this.btnUpdate.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.btnUpdate.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(190)))), ((int)(((byte)(240)))));
            this.btnUpdate.HoverState.Image = global::MASLMonthlyCapitalExpenditureStatement.Properties.Resources.updateWhite;
            this.btnUpdate.HoverState.Parent = this.btnUpdate;
            this.btnUpdate.Image = global::MASLMonthlyCapitalExpenditureStatement.Properties.Resources.update;
            this.btnUpdate.ImageSize = new System.Drawing.Size(18, 18);
            this.btnUpdate.Location = new System.Drawing.Point(727, 44);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.ShadowDecoration.BorderRadius = 17;
            this.btnUpdate.ShadowDecoration.Parent = this.btnUpdate;
            this.btnUpdate.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2, 2, 3, 3);
            this.btnUpdate.Size = new System.Drawing.Size(55, 36);
            this.btnUpdate.TabIndex = 23;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
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
            this.txtItemNo.Location = new System.Drawing.Point(506, 44);
            this.txtItemNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtItemNo.Name = "txtItemNo";
            this.txtItemNo.PasswordChar = '\0';
            this.txtItemNo.PlaceholderText = "2.2.3";
            this.txtItemNo.SelectedText = "";
            this.txtItemNo.ShadowDecoration.Parent = this.txtItemNo;
            this.txtItemNo.Size = new System.Drawing.Size(153, 36);
            this.txtItemNo.TabIndex = 22;
            this.txtItemNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtItemNo.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // ComboBoxBudgetCode
            // 
            this.ComboBoxBudgetCode.BackColor = System.Drawing.Color.Transparent;
            this.ComboBoxBudgetCode.BorderRadius = 17;
            this.ComboBoxBudgetCode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboBoxBudgetCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxBudgetCode.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboBoxBudgetCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboBoxBudgetCode.FocusedState.Parent = this.ComboBoxBudgetCode;
            this.ComboBoxBudgetCode.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.ComboBoxBudgetCode.ForeColor = System.Drawing.Color.DimGray;
            this.ComboBoxBudgetCode.HoverState.Parent = this.ComboBoxBudgetCode;
            this.ComboBoxBudgetCode.ItemHeight = 30;
            this.ComboBoxBudgetCode.ItemsAppearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(29)))), ((int)(((byte)(40)))));
            this.ComboBoxBudgetCode.ItemsAppearance.Parent = this.ComboBoxBudgetCode;
            this.ComboBoxBudgetCode.ItemsAppearance.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(45)))), ((int)(((byte)(120)))));
            this.ComboBoxBudgetCode.ItemsAppearance.SelectedForeColor = System.Drawing.Color.White;
            this.ComboBoxBudgetCode.Location = new System.Drawing.Point(319, 44);
            this.ComboBoxBudgetCode.Name = "ComboBoxBudgetCode";
            this.ComboBoxBudgetCode.ShadowDecoration.Parent = this.ComboBoxBudgetCode;
            this.ComboBoxBudgetCode.Size = new System.Drawing.Size(180, 36);
            this.ComboBoxBudgetCode.TabIndex = 21;
            this.ComboBoxBudgetCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(29)))), ((int)(((byte)(40)))));
            this.label7.Location = new System.Drawing.Point(550, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 20);
            this.label7.TabIndex = 19;
            this.label7.Text = "Item No";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(29)))), ((int)(((byte)(40)))));
            this.label3.Location = new System.Drawing.Point(341, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "MASL Budget Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(29)))), ((int)(((byte)(40)))));
            this.label2.Location = new System.Drawing.Point(218, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Month";
            // 
            // btnSearch
            // 
            this.btnSearch.Animated = true;
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.btnSearch.BorderRadius = 17;
            this.btnSearch.BorderThickness = 1;
            this.btnSearch.CheckedState.Parent = this.btnSearch;
            this.btnSearch.CustomImages.Parent = this.btnSearch;
            this.btnSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.btnSearch.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.btnSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSearch.DisabledState.Parent = this.btnSearch;
            this.btnSearch.FillColor = System.Drawing.Color.White;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(29)))), ((int)(((byte)(40)))));
            this.btnSearch.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.btnSearch.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(190)))), ((int)(((byte)(240)))));
            this.btnSearch.HoverState.Image = global::MASLMonthlyCapitalExpenditureStatement.Properties.Resources.SearchWhite;
            this.btnSearch.HoverState.Parent = this.btnSearch;
            this.btnSearch.Image = global::MASLMonthlyCapitalExpenditureStatement.Properties.Resources.Search;
            this.btnSearch.Location = new System.Drawing.Point(666, 44);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.ShadowDecoration.BorderRadius = 17;
            this.btnSearch.ShadowDecoration.Parent = this.btnSearch;
            this.btnSearch.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2, 2, 3, 3);
            this.btnSearch.Size = new System.Drawing.Size(55, 36);
            this.btnSearch.TabIndex = 16;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnSelectMonth
            // 
            this.btnSelectMonth.Animated = true;
            this.btnSelectMonth.BackColor = System.Drawing.Color.Transparent;
            this.btnSelectMonth.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.btnSelectMonth.BorderRadius = 17;
            this.btnSelectMonth.BorderThickness = 1;
            this.btnSelectMonth.CheckedState.Parent = this.btnSelectMonth;
            this.btnSelectMonth.CustomImages.Parent = this.btnSelectMonth;
            this.btnSelectMonth.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSelectMonth.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSelectMonth.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSelectMonth.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSelectMonth.DisabledState.Parent = this.btnSelectMonth;
            this.btnSelectMonth.FillColor = System.Drawing.Color.White;
            this.btnSelectMonth.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnSelectMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(29)))), ((int)(((byte)(40)))));
            this.btnSelectMonth.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.btnSelectMonth.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(190)))), ((int)(((byte)(240)))));
            this.btnSelectMonth.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnSelectMonth.HoverState.Parent = this.btnSelectMonth;
            this.btnSelectMonth.Location = new System.Drawing.Point(177, 44);
            this.btnSelectMonth.Name = "btnSelectMonth";
            this.btnSelectMonth.ShadowDecoration.BorderRadius = 17;
            this.btnSelectMonth.ShadowDecoration.Parent = this.btnSelectMonth;
            this.btnSelectMonth.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2, 2, 3, 3);
            this.btnSelectMonth.Size = new System.Drawing.Size(136, 36);
            this.btnSelectMonth.TabIndex = 17;
            this.btnSelectMonth.Text = "JAN";
            this.btnSelectMonth.Click += new System.EventHandler(this.ChangeSelectedMonth);
            // 
            // lblExpenditure
            // 
            this.lblExpenditure.AutoSize = true;
            this.lblExpenditure.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblExpenditure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(29)))), ((int)(((byte)(40)))));
            this.lblExpenditure.Location = new System.Drawing.Point(52, 23);
            this.lblExpenditure.Name = "lblExpenditure";
            this.lblExpenditure.Size = new System.Drawing.Size(217, 25);
            this.lblExpenditure.TabIndex = 18;
            this.lblExpenditure.Text = "Expenditure For 2020 JAN";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.Controls.Add(this.TableActivities, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.guna2Panel2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 104);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(815, 357);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // TableActivities
            // 
            this.TableActivities.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(45)))), ((int)(((byte)(120)))));
            this.TableActivities.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.TableActivities.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TableActivities.BackgroundColor = System.Drawing.Color.White;
            this.TableActivities.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TableActivities.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.TableActivities.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(45)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(45)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.TableActivities.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.TableActivities.ColumnHeadersHeight = 30;
            this.TableActivities.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemNo,
            this.ActivityName,
            this.ShowExpenditure});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(45)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TableActivities.DefaultCellStyle = dataGridViewCellStyle6;
            this.TableActivities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableActivities.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.TableActivities.EnableHeadersVisualStyles = false;
            this.TableActivities.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(45)))), ((int)(((byte)(120)))));
            this.TableActivities.Location = new System.Drawing.Point(434, 31);
            this.TableActivities.MultiSelect = false;
            this.TableActivities.Name = "TableActivities";
            this.TableActivities.ReadOnly = true;
            this.TableActivities.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TableActivities.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TableActivities.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.TableActivities.RowHeadersVisible = false;
            this.TableActivities.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.TableActivities.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.TableActivities.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TableActivities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TableActivities.Size = new System.Drawing.Size(346, 294);
            this.TableActivities.TabIndex = 14;
            this.TableActivities.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Light;
            this.TableActivities.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.TableActivities.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.TableActivities.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.TableActivities.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.TableActivities.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(45)))), ((int)(((byte)(120)))));
            this.TableActivities.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.TableActivities.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(45)))), ((int)(((byte)(120)))));
            this.TableActivities.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(45)))), ((int)(((byte)(120)))));
            this.TableActivities.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.TableActivities.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.TableActivities.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.TableActivities.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.TableActivities.ThemeStyle.HeaderStyle.Height = 30;
            this.TableActivities.ThemeStyle.ReadOnly = true;
            this.TableActivities.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.TableActivities.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.TableActivities.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.TableActivities.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.TableActivities.ThemeStyle.RowsStyle.Height = 22;
            this.TableActivities.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.TableActivities.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(45)))), ((int)(((byte)(120)))));
            this.TableActivities.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TableActivities_CellDoubleClick);
            // 
            // ItemNo
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ItemNo.DefaultCellStyle = dataGridViewCellStyle3;
            this.ItemNo.FillWeight = 30F;
            this.ItemNo.HeaderText = "Month";
            this.ItemNo.Name = "ItemNo";
            this.ItemNo.ReadOnly = true;
            // 
            // ActivityName
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.ActivityName.DefaultCellStyle = dataGridViewCellStyle4;
            this.ActivityName.FillWeight = 50F;
            this.ActivityName.HeaderText = "Expenditure";
            this.ActivityName.Name = "ActivityName";
            this.ActivityName.ReadOnly = true;
            // 
            // ShowExpenditure
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.ShowExpenditure.DefaultCellStyle = dataGridViewCellStyle5;
            this.ShowExpenditure.FillWeight = 50F;
            this.ShowExpenditure.HeaderText = "Cumulative Exp.";
            this.ShowExpenditure.Name = "ShowExpenditure";
            this.ShowExpenditure.ReadOnly = true;
            this.ShowExpenditure.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ShowExpenditure.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Panel2.BorderRadius = 25;
            this.guna2Panel2.BorderThickness = 1;
            this.guna2Panel2.Controls.Add(this.guna2Panel3);
            this.guna2Panel2.Controls.Add(this.label10);
            this.guna2Panel2.Controls.Add(this.label9);
            this.guna2Panel2.Controls.Add(this.txtCulmulativeExpenditure);
            this.guna2Panel2.Controls.Add(this.lblCumulativeExp);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.guna2Panel2.Location = new System.Drawing.Point(33, 31);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(375, 294);
            this.guna2Panel2.TabIndex = 15;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel3.BorderColor = System.Drawing.Color.DimGray;
            this.guna2Panel3.BorderRadius = 20;
            this.guna2Panel3.Controls.Add(this.lblExpenditure);
            this.guna2Panel3.Controls.Add(this.label6);
            this.guna2Panel3.Controls.Add(this.label5);
            this.guna2Panel3.Controls.Add(this.txtExpenditure);
            this.guna2Panel3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(210)))), ((int)(((byte)(21)))));
            this.guna2Panel3.Location = new System.Drawing.Point(28, 31);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.ShadowDecoration.BorderRadius = 20;
            this.guna2Panel3.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.guna2Panel3.ShadowDecoration.Enabled = true;
            this.guna2Panel3.ShadowDecoration.Parent = this.guna2Panel3;
            this.guna2Panel3.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.guna2Panel3.Size = new System.Drawing.Size(322, 131);
            this.guna2Panel3.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(259, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 25);
            this.label6.TabIndex = 18;
            this.label6.Text = "/=";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(38, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 25);
            this.label5.TabIndex = 18;
            this.label5.Text = "Rs.";
            // 
            // txtExpenditure
            // 
            this.txtExpenditure.BorderRadius = 17;
            this.txtExpenditure.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtExpenditure.DefaultText = "";
            this.txtExpenditure.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtExpenditure.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtExpenditure.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtExpenditure.DisabledState.Parent = this.txtExpenditure;
            this.txtExpenditure.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtExpenditure.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtExpenditure.FocusedState.Parent = this.txtExpenditure;
            this.txtExpenditure.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtExpenditure.ForeColor = System.Drawing.Color.DimGray;
            this.txtExpenditure.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtExpenditure.HoverState.Parent = this.txtExpenditure;
            this.txtExpenditure.Location = new System.Drawing.Point(26, 67);
            this.txtExpenditure.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtExpenditure.Name = "txtExpenditure";
            this.txtExpenditure.PasswordChar = '\0';
            this.txtExpenditure.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtExpenditure.PlaceholderText = "500,000";
            this.txtExpenditure.SelectedText = "";
            this.txtExpenditure.ShadowDecoration.Parent = this.txtExpenditure;
            this.txtExpenditure.Size = new System.Drawing.Size(272, 39);
            this.txtExpenditure.TabIndex = 22;
            this.txtExpenditure.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtExpenditure.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label10.ForeColor = System.Drawing.Color.DimGray;
            this.label10.Location = new System.Drawing.Point(308, 230);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 25);
            this.label10.TabIndex = 18;
            this.label10.Text = "/=";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(42, 230);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 25);
            this.label9.TabIndex = 18;
            this.label9.Text = "Rs.";
            // 
            // txtCulmulativeExpenditure
            // 
            this.txtCulmulativeExpenditure.BorderRadius = 17;
            this.txtCulmulativeExpenditure.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCulmulativeExpenditure.DefaultText = "";
            this.txtCulmulativeExpenditure.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCulmulativeExpenditure.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCulmulativeExpenditure.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCulmulativeExpenditure.DisabledState.Parent = this.txtCulmulativeExpenditure;
            this.txtCulmulativeExpenditure.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCulmulativeExpenditure.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCulmulativeExpenditure.FocusedState.Parent = this.txtCulmulativeExpenditure;
            this.txtCulmulativeExpenditure.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtCulmulativeExpenditure.ForeColor = System.Drawing.Color.DimGray;
            this.txtCulmulativeExpenditure.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCulmulativeExpenditure.HoverState.Parent = this.txtCulmulativeExpenditure;
            this.txtCulmulativeExpenditure.Location = new System.Drawing.Point(28, 226);
            this.txtCulmulativeExpenditure.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCulmulativeExpenditure.Name = "txtCulmulativeExpenditure";
            this.txtCulmulativeExpenditure.PasswordChar = '\0';
            this.txtCulmulativeExpenditure.PlaceholderText = "500,000";
            this.txtCulmulativeExpenditure.SelectedText = "";
            this.txtCulmulativeExpenditure.ShadowDecoration.Parent = this.txtCulmulativeExpenditure;
            this.txtCulmulativeExpenditure.Size = new System.Drawing.Size(322, 36);
            this.txtCulmulativeExpenditure.TabIndex = 22;
            this.txtCulmulativeExpenditure.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCulmulativeExpenditure.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // lblCumulativeExp
            // 
            this.lblCumulativeExp.AutoSize = true;
            this.lblCumulativeExp.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCumulativeExp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(29)))), ((int)(((byte)(40)))));
            this.lblCumulativeExp.Location = new System.Drawing.Point(86, 196);
            this.lblCumulativeExp.Name = "lblCumulativeExp";
            this.lblCumulativeExp.Size = new System.Drawing.Size(206, 21);
            this.lblCumulativeExp.TabIndex = 18;
            this.lblCumulativeExp.Text = "Cumulative Exp. (JAN - OCT)";
            // 
            // NotificationPaintNeedUpdate
            // 
            this.NotificationPaintNeedUpdate.BorderColor = System.Drawing.Color.Transparent;
            this.NotificationPaintNeedUpdate.BorderRadius = 7;
            this.NotificationPaintNeedUpdate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(210)))), ((int)(((byte)(21)))));
            this.NotificationPaintNeedUpdate.TargetControl = this.btnUpdate;
            this.NotificationPaintNeedUpdate.Text = "!";
            this.NotificationPaintNeedUpdate.Visible = false;
            // 
            // MonthlyExpenditure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(815, 461);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MonthlyExpenditure";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Monthly Expenditure";
            this.Load += new System.EventHandler(this.MonthlyExpenditure_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TableActivities)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnUpdate;
        public Guna.UI2.WinForms.Guna2TextBox txtItemNo;
        public Guna.UI2.WinForms.Guna2ComboBox ComboBoxBudgetCode;
        private System.Windows.Forms.Label lblExpenditure;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public Guna.UI2.WinForms.Guna2Button btnSearch;
        public Guna.UI2.WinForms.Guna2Button btnSelectMonth;
        private System.Windows.Forms.Label label1;
        public Guna.UI2.WinForms.Guna2Button btnSelectedYear;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2DataGridView TableActivities;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        public Guna.UI2.WinForms.Guna2TextBox txtExpenditure;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        public Guna.UI2.WinForms.Guna2TextBox txtCulmulativeExpenditure;
        private System.Windows.Forms.Label lblCumulativeExp;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActivityName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShowExpenditure;
        private Guna.UI2.WinForms.Guna2NotificationPaint NotificationPaintNeedUpdate;
    }
}