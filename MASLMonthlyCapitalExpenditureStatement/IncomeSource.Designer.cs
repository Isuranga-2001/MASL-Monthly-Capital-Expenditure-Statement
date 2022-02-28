
namespace MASLMonthlyCapitalExpenditureStatement
{
    partial class IncomeSource
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IncomeSource));
            this.TableSources = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnAddChild = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddSource = new Guna.UI2.WinForms.Guna2Button();
            this.txtSource = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSection = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIncomeBudget = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSelectedYear = new Guna.UI2.WinForms.Guna2Button();
            this.SourceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SourceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SourceYearID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Section = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IncomeBudget = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.TableSources)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableSources
            // 
            this.TableSources.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(190)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.TableSources.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.TableSources.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TableSources.BackgroundColor = System.Drawing.Color.White;
            this.TableSources.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TableSources.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.TableSources.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(45)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(45)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TableSources.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.TableSources.ColumnHeadersHeight = 36;
            this.TableSources.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.TableSources.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SourceType,
            this.SourceID,
            this.SourceYearID,
            this.Source,
            this.Section,
            this.IncomeBudget});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(190)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TableSources.DefaultCellStyle = dataGridViewCellStyle4;
            this.TableSources.EnableHeadersVisualStyles = false;
            this.TableSources.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.TableSources.Location = new System.Drawing.Point(21, 97);
            this.TableSources.MultiSelect = false;
            this.TableSources.Name = "TableSources";
            this.TableSources.ReadOnly = true;
            this.TableSources.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TableSources.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.TableSources.RowHeadersVisible = false;
            this.TableSources.RowTemplate.Height = 31;
            this.TableSources.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TableSources.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TableSources.Size = new System.Drawing.Size(292, 238);
            this.TableSources.TabIndex = 15;
            this.TableSources.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Light;
            this.TableSources.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.TableSources.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TableSources.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TableSources.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(190)))), ((int)(((byte)(240)))));
            this.TableSources.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.TableSources.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.TableSources.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.TableSources.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(45)))), ((int)(((byte)(120)))));
            this.TableSources.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.TableSources.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.TableSources.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.TableSources.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.TableSources.ThemeStyle.HeaderStyle.Height = 36;
            this.TableSources.ThemeStyle.ReadOnly = true;
            this.TableSources.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.TableSources.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.TableSources.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.TableSources.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.TableSources.ThemeStyle.RowsStyle.Height = 31;
            this.TableSources.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(190)))), ((int)(((byte)(240)))));
            this.TableSources.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.TableSources.SelectionChanged += new System.EventHandler(this.TableSources_SelectionChanged);
            // 
            // btnAddChild
            // 
            this.btnAddChild.Animated = true;
            this.btnAddChild.BackColor = System.Drawing.Color.Transparent;
            this.btnAddChild.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.btnAddChild.BorderRadius = 17;
            this.btnAddChild.BorderThickness = 1;
            this.btnAddChild.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btnAddChild.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(190)))), ((int)(((byte)(240)))));
            this.btnAddChild.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnAddChild.CheckedState.Parent = this.btnAddChild;
            this.btnAddChild.CustomImages.Parent = this.btnAddChild;
            this.btnAddChild.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.btnAddChild.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddChild.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.btnAddChild.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddChild.DisabledState.Parent = this.btnAddChild;
            this.btnAddChild.FillColor = System.Drawing.Color.White;
            this.btnAddChild.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.btnAddChild.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(29)))), ((int)(((byte)(40)))));
            this.btnAddChild.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.btnAddChild.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(190)))), ((int)(((byte)(240)))));
            this.btnAddChild.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnAddChild.HoverState.Parent = this.btnAddChild;
            this.btnAddChild.Location = new System.Drawing.Point(187, 16);
            this.btnAddChild.Name = "btnAddChild";
            this.btnAddChild.ShadowDecoration.BorderRadius = 17;
            this.btnAddChild.ShadowDecoration.Parent = this.btnAddChild;
            this.btnAddChild.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2, 2, 3, 3);
            this.btnAddChild.Size = new System.Drawing.Size(119, 36);
            this.btnAddChild.TabIndex = 31;
            this.btnAddChild.Text = "Add Child";
            this.btnAddChild.Visible = false;
            this.btnAddChild.CheckedChanged += new System.EventHandler(this.btnAddChild_CheckedChanged);
            // 
            // btnAddSource
            // 
            this.btnAddSource.Animated = true;
            this.btnAddSource.BackColor = System.Drawing.Color.Transparent;
            this.btnAddSource.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.btnAddSource.BorderRadius = 17;
            this.btnAddSource.BorderThickness = 1;
            this.btnAddSource.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btnAddSource.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(190)))), ((int)(((byte)(240)))));
            this.btnAddSource.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnAddSource.CheckedState.Parent = this.btnAddSource;
            this.btnAddSource.CustomImages.Parent = this.btnAddSource;
            this.btnAddSource.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.btnAddSource.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddSource.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.btnAddSource.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddSource.DisabledState.Parent = this.btnAddSource;
            this.btnAddSource.FillColor = System.Drawing.Color.White;
            this.btnAddSource.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this.btnAddSource.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(29)))), ((int)(((byte)(40)))));
            this.btnAddSource.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.btnAddSource.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(190)))), ((int)(((byte)(240)))));
            this.btnAddSource.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnAddSource.HoverState.Image = global::MASLMonthlyCapitalExpenditureStatement.Properties.Resources.AddWhite;
            this.btnAddSource.HoverState.Parent = this.btnAddSource;
            this.btnAddSource.Image = global::MASLMonthlyCapitalExpenditureStatement.Properties.Resources.Add;
            this.btnAddSource.Location = new System.Drawing.Point(418, 16);
            this.btnAddSource.Name = "btnAddSource";
            this.btnAddSource.ShadowDecoration.BorderRadius = 17;
            this.btnAddSource.ShadowDecoration.Parent = this.btnAddSource;
            this.btnAddSource.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2, 2, 3, 3);
            this.btnAddSource.Size = new System.Drawing.Size(55, 36);
            this.btnAddSource.TabIndex = 32;
            this.btnAddSource.CheckedChanged += new System.EventHandler(this.btnAddSource_CheckedChanged);
            // 
            // txtSource
            // 
            this.txtSource.BorderRadius = 17;
            this.txtSource.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSource.DefaultText = "";
            this.txtSource.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSource.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSource.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSource.DisabledState.Parent = this.txtSource;
            this.txtSource.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSource.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSource.FocusedState.Parent = this.txtSource;
            this.txtSource.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtSource.ForeColor = System.Drawing.Color.DimGray;
            this.txtSource.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSource.HoverState.Parent = this.txtSource;
            this.txtSource.Location = new System.Drawing.Point(333, 123);
            this.txtSource.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSource.Name = "txtSource";
            this.txtSource.PasswordChar = '\0';
            this.txtSource.PlaceholderText = "";
            this.txtSource.SelectedText = "";
            this.txtSource.ShadowDecoration.Parent = this.txtSource;
            this.txtSource.Size = new System.Drawing.Size(262, 36);
            this.txtSource.TabIndex = 38;
            this.txtSource.Tag = "Source";
            this.txtSource.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSource.TextChanged += new System.EventHandler(this.SourceInputTextBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(29)))), ((int)(((byte)(40)))));
            this.label8.Location = new System.Drawing.Point(432, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 21);
            this.label8.TabIndex = 37;
            this.label8.Text = "Source";
            // 
            // txtSection
            // 
            this.txtSection.BorderRadius = 17;
            this.txtSection.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSection.DefaultText = "";
            this.txtSection.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSection.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSection.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSection.DisabledState.Parent = this.txtSection;
            this.txtSection.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSection.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSection.FocusedState.Parent = this.txtSection;
            this.txtSection.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtSection.ForeColor = System.Drawing.Color.DimGray;
            this.txtSection.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSection.HoverState.Parent = this.txtSection;
            this.txtSection.Location = new System.Drawing.Point(333, 210);
            this.txtSection.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSection.Name = "txtSection";
            this.txtSection.PasswordChar = '\0';
            this.txtSection.PlaceholderText = "";
            this.txtSection.SelectedText = "";
            this.txtSection.ShadowDecoration.Parent = this.txtSection;
            this.txtSection.Size = new System.Drawing.Size(262, 36);
            this.txtSection.TabIndex = 40;
            this.txtSection.Tag = "Section";
            this.txtSection.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSection.TextChanged += new System.EventHandler(this.SourceInputTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(29)))), ((int)(((byte)(40)))));
            this.label1.Location = new System.Drawing.Point(432, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 21);
            this.label1.TabIndex = 39;
            this.label1.Text = "Section";
            // 
            // txtIncomeBudget
            // 
            this.txtIncomeBudget.BorderRadius = 17;
            this.txtIncomeBudget.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIncomeBudget.DefaultText = "";
            this.txtIncomeBudget.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtIncomeBudget.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtIncomeBudget.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIncomeBudget.DisabledState.Parent = this.txtIncomeBudget;
            this.txtIncomeBudget.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIncomeBudget.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtIncomeBudget.FocusedState.Parent = this.txtIncomeBudget;
            this.txtIncomeBudget.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.txtIncomeBudget.ForeColor = System.Drawing.Color.DimGray;
            this.txtIncomeBudget.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtIncomeBudget.HoverState.Parent = this.txtIncomeBudget;
            this.txtIncomeBudget.Location = new System.Drawing.Point(333, 299);
            this.txtIncomeBudget.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIncomeBudget.Name = "txtIncomeBudget";
            this.txtIncomeBudget.PasswordChar = '\0';
            this.txtIncomeBudget.PlaceholderText = "";
            this.txtIncomeBudget.SelectedText = "";
            this.txtIncomeBudget.ShadowDecoration.Parent = this.txtIncomeBudget;
            this.txtIncomeBudget.Size = new System.Drawing.Size(262, 36);
            this.txtIncomeBudget.TabIndex = 42;
            this.txtIncomeBudget.Tag = "IncomeBudget";
            this.txtIncomeBudget.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIncomeBudget.TextChanged += new System.EventHandler(this.SourceInputTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(29)))), ((int)(((byte)(40)))));
            this.label2.Location = new System.Drawing.Point(409, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 21);
            this.label2.TabIndex = 41;
            this.label2.Text = "Income Budget";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderRadius = 25;
            this.guna2Panel2.Controls.Add(this.btnDelete);
            this.guna2Panel2.Controls.Add(this.btnSave);
            this.guna2Panel2.Controls.Add(this.label3);
            this.guna2Panel2.Controls.Add(this.btnSelectedYear);
            this.guna2Panel2.Controls.Add(this.btnAddSource);
            this.guna2Panel2.Controls.Add(this.btnAddChild);
            this.guna2Panel2.CustomizableEdges.TopLeft = false;
            this.guna2Panel2.CustomizableEdges.TopRight = false;
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.BorderRadius = 25;
            this.guna2Panel2.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.guna2Panel2.ShadowDecoration.Enabled = true;
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(619, 74);
            this.guna2Panel2.TabIndex = 47;
            // 
            // btnDelete
            // 
            this.btnDelete.Animated = true;
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.btnDelete.BorderRadius = 17;
            this.btnDelete.BorderThickness = 1;
            this.btnDelete.CheckedState.Parent = this.btnDelete;
            this.btnDelete.CustomImages.Parent = this.btnDelete;
            this.btnDelete.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.btnDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.btnDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDelete.DisabledState.Parent = this.btnDelete;
            this.btnDelete.FillColor = System.Drawing.Color.White;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(29)))), ((int)(((byte)(40)))));
            this.btnDelete.HoverState.BorderColor = System.Drawing.Color.White;
            this.btnDelete.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(190)))), ((int)(((byte)(240)))));
            this.btnDelete.HoverState.Image = global::MASLMonthlyCapitalExpenditureStatement.Properties.Resources.RemoveWhite;
            this.btnDelete.HoverState.Parent = this.btnDelete;
            this.btnDelete.Image = global::MASLMonthlyCapitalExpenditureStatement.Properties.Resources.Remove;
            this.btnDelete.Location = new System.Drawing.Point(479, 16);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ShadowDecoration.BorderRadius = 17;
            this.btnDelete.ShadowDecoration.Parent = this.btnDelete;
            this.btnDelete.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2, 2, 3, 3);
            this.btnDelete.Size = new System.Drawing.Size(55, 36);
            this.btnDelete.TabIndex = 49;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Animated = true;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.btnSave.BorderRadius = 17;
            this.btnSave.BorderThickness = 1;
            this.btnSave.CheckedState.Parent = this.btnSave;
            this.btnSave.CustomImages.Parent = this.btnSave;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.DisabledState.Parent = this.btnSave;
            this.btnSave.FillColor = System.Drawing.Color.White;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(29)))), ((int)(((byte)(40)))));
            this.btnSave.HoverState.BorderColor = System.Drawing.Color.White;
            this.btnSave.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(190)))), ((int)(((byte)(240)))));
            this.btnSave.HoverState.Image = global::MASLMonthlyCapitalExpenditureStatement.Properties.Resources.SaveDataWhite;
            this.btnSave.HoverState.Parent = this.btnSave;
            this.btnSave.Image = global::MASLMonthlyCapitalExpenditureStatement.Properties.Resources.SaveData;
            this.btnSave.ImageSize = new System.Drawing.Size(18, 20);
            this.btnSave.Location = new System.Drawing.Point(540, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShadowDecoration.BorderRadius = 17;
            this.btnSave.ShadowDecoration.Parent = this.btnSave;
            this.btnSave.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2, 2, 3, 3);
            this.btnSave.Size = new System.Drawing.Size(55, 36);
            this.btnSave.TabIndex = 48;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(29)))), ((int)(((byte)(40)))));
            this.label3.Location = new System.Drawing.Point(30, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 20);
            this.label3.TabIndex = 25;
            this.label3.Text = "Year";
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
            this.btnSelectedYear.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.btnSelectedYear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSelectedYear.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.btnSelectedYear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSelectedYear.DisabledState.Parent = this.btnSelectedYear;
            this.btnSelectedYear.FillColor = System.Drawing.Color.White;
            this.btnSelectedYear.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnSelectedYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(29)))), ((int)(((byte)(40)))));
            this.btnSelectedYear.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.btnSelectedYear.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(190)))), ((int)(((byte)(240)))));
            this.btnSelectedYear.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnSelectedYear.HoverState.Parent = this.btnSelectedYear;
            this.btnSelectedYear.Location = new System.Drawing.Point(73, 16);
            this.btnSelectedYear.Name = "btnSelectedYear";
            this.btnSelectedYear.ShadowDecoration.BorderRadius = 17;
            this.btnSelectedYear.ShadowDecoration.Parent = this.btnSelectedYear;
            this.btnSelectedYear.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2, 2, 3, 3);
            this.btnSelectedYear.Size = new System.Drawing.Size(108, 36);
            this.btnSelectedYear.TabIndex = 24;
            this.btnSelectedYear.Text = "2020";
            this.btnSelectedYear.Click += new System.EventHandler(this.btnSelectedYear_Click);
            // 
            // SourceType
            // 
            this.SourceType.FillWeight = 10F;
            this.SourceType.HeaderText = "Type";
            this.SourceType.Name = "SourceType";
            this.SourceType.ReadOnly = true;
            this.SourceType.Visible = false;
            // 
            // SourceID
            // 
            this.SourceID.HeaderText = "SourceID";
            this.SourceID.Name = "SourceID";
            this.SourceID.ReadOnly = true;
            this.SourceID.Visible = false;
            // 
            // SourceYearID
            // 
            this.SourceYearID.HeaderText = "SourceYearID";
            this.SourceYearID.Name = "SourceYearID";
            this.SourceYearID.ReadOnly = true;
            this.SourceYearID.Visible = false;
            // 
            // Source
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.Source.DefaultCellStyle = dataGridViewCellStyle3;
            this.Source.HeaderText = "Sources";
            this.Source.Name = "Source";
            this.Source.ReadOnly = true;
            this.Source.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Source.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Section
            // 
            this.Section.HeaderText = "Section";
            this.Section.Name = "Section";
            this.Section.ReadOnly = true;
            this.Section.Visible = false;
            // 
            // IncomeBudget
            // 
            this.IncomeBudget.HeaderText = "IncomeBudget";
            this.IncomeBudget.Name = "IncomeBudget";
            this.IncomeBudget.ReadOnly = true;
            this.IncomeBudget.Visible = false;
            // 
            // IncomeSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(619, 361);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.TableSources);
            this.Controls.Add(this.txtIncomeBudget);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.label8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IncomeSource";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Income Sources";
            this.Load += new System.EventHandler(this.IncomeSource_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TableSources)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView TableSources;
        public Guna.UI2.WinForms.Guna2Button btnAddChild;
        public Guna.UI2.WinForms.Guna2Button btnAddSource;
        public Guna.UI2.WinForms.Guna2TextBox txtSource;
        private System.Windows.Forms.Label label8;
        public Guna.UI2.WinForms.Guna2TextBox txtSection;
        private System.Windows.Forms.Label label1;
        public Guna.UI2.WinForms.Guna2TextBox txtIncomeBudget;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label label3;
        public Guna.UI2.WinForms.Guna2Button btnSelectedYear;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn SourceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn SourceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SourceYearID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Source;
        private System.Windows.Forms.DataGridViewTextBoxColumn Section;
        private System.Windows.Forms.DataGridViewTextBoxColumn IncomeBudget;
    }
}