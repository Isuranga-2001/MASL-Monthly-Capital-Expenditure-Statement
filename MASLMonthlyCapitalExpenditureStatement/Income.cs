using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace MASLMonthlyCapitalExpenditureStatement
{
    public partial class Income : Form
    {
        public Income()
        {
            InitializeComponent();
        }

        CommenMethods commenMethods = new CommenMethods();

        private void btnNavigationButton_Click(object sender, EventArgs e)
        {
            Guna2Button btnNavigation = (Guna2Button)sender;
            commenMethods.NavigateTo(btnNavigation.Tag.ToString());
            this.Close();
        }

        private void Income_Load(object sender, EventArgs e)
        {
            btnSelectedYear.Text = DateTime.Now.Year.ToString();
            btnSelectMonth.Text = commenMethods.MonthList[DateTime.Now.Month - 1];

            UpdateSourceTable();
        }

        void UpdateSourceTable()
        {
            TableSources.Rows.Clear();

            // Find Sources for selected year
            string Query = "SELECT Source.SourceName,Source.Section,SourceYear.IncomeBudget " +
                "FROM SourceYear,Source " +
                "WHERE Source.SourceID=SourceYear.SourceID AND SourceYear.Year='{0}'";

            List<string> SourceList = commenMethods.SQLRead(
                String.Format(Query, btnSelectedYear.Text), "SourceName Section IncomeBudget");

            if (!commenMethods.ReturnListHasError(SourceList))
            {
                FillTable(SourceList); // has source data for selected year
            }
            else
            {
                // can't find data for selected year
                // continue with 2021 data
                FillTable(commenMethods.SQLRead(String.Format(Query, "2021"), "SourceName Section IncomeBudget"));
            }
        }

        void FillTable(List<string> SourceList)
        {
            int n;
            ComboBoxSource.Items.Clear();

            for (int i = 0; i < SourceList.Count; i += 3)
            {
                ComboBoxSource.Items.Add(SourceList[i]); // source name add to combo box

                n = TableSources.Rows.Add();
                TableSources.Rows[n].Cells[0].Value = SourceList[i]; // source name
                TableSources.Rows[n].Cells[1].Value = SourceList[i + 1]; // section
                
                // split number (1000000) by comma like 1,000,000
                TableSources.Rows[n].Cells[2].Value = commenMethods.SaveOnlyIntegers(SourceList[i + 2]);
            }

            ComboBoxSource.SelectedIndex = 0;

            UpdateIncomeData();
        }

        private void ChangeSelectedMonth(object sender, EventArgs e)
        {
            SelectMonth form = new SelectMonth();

            form.CurrentSelectedMonth = btnSelectMonth.Text;
            form.txtSelectedYear.Text = btnSelectedYear.Text;
            form.ShowDialog();

            if (form.UpdateEnabled)
            {
                string currentYear = btnSelectedYear.Text;
                string currentMonth = btnSelectMonth.Text;

                btnSelectMonth.Text = form.btnSelectedMonth.Text;
                btnSelectedYear.Text = form.txtSelectedYear.Text;

                if (currentYear == btnSelectedYear.Text && currentMonth != btnSelectMonth.Text)
                {
                    TableIncome.SelectedRows[0].Selected = false;
                    TableIncome.Rows[FindSelectedMonth() - 1].Selected = true;
                }
                else
                {
                    UpdateSourceTable();
                    UpdateIncomeData();
                }
            }
        }

        private void TableSources_SelectionChanged(object sender, EventArgs e)
        {
            if (TableSources.SelectedRows.Count > 0 
                && TableSources.SelectedRows[0].Index != ComboBoxSource.SelectedIndex 
                && TableSources.SelectedRows[0].Index <= ComboBoxSource.Items.Count)
            {
                try
                {
                    // change combo box selected item
                    ComboBoxSource.SelectedIndex = TableSources.SelectedRows[0].Index;
                }
                catch
                {
                    // set tablesource selected row as 0
                    TableSources.Rows[TableSources.SelectedRows[0].Index].Selected = false;
                    TableSources.Rows[0].Selected = true;
                }
            }
        }

        private void ComboBoxSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            // change tablesource selected row
            TableSources.Rows[TableSources.SelectedRows[0].Index].Selected = false;
            TableSources.Rows[ComboBoxSource.SelectedIndex].Selected = true;

            if (TableSources.Rows.Count > 4)
            {
                UpdateIncomeData();
            }
        }

        void UpdateIncomeData()
        {
            int SelectedMonth = FindSelectedMonth(), n;
            double CumulativeIncome = 0, MonthlyIncome, MonthlyIncomeBudget = 0;

            // find monthly income budget
            if (TableSources.Rows[TableSources.SelectedRows[0].Index].Cells[2].Value != null)
            {
                string SelectedSourceMonthlyIncomeBudget = 
                    TableSources.Rows[TableSources.SelectedRows[0].Index].Cells[2].Value.ToString().Trim();
                
                if (SelectedSourceMonthlyIncomeBudget != "")
                {
                    // set monthly income budget / 12 to variable
                    // for update chart like cumulative type
                    MonthlyIncomeBudget = Convert.ToDouble(SelectedSourceMonthlyIncomeBudget) / 12;
                }
            }

            List<string> MonthlyIncomeList;
            string SelectedMonthName;

            ClearData();

            for (int i = 1; i <= 12; i++)
            {
                n = TableIncome.Rows.Add();

                SelectedMonthName = commenMethods.MonthList[i - 1];

                // add month name to tableincome
                TableIncome.Rows[n].Cells[0].Value = SelectedMonthName;

                // add unit of monthly income budget to series 0 of chart
                ChartIncome.Series[0].Points.AddXY(SelectedMonthName, MonthlyIncomeBudget * i);

                // find income of month
                MonthlyIncomeList = commenMethods.SQLRead(String.Format(
                    "SELECT MonthlyIncome.Income FROM MonthlyIncome,SourceYear " +
                    "WHERE MonthlyIncome.SourceYearID=SourceYear.SourceYearID " +
                    "AND SourceYear.SourceID='{0}' AND SourceYear.Year='{1}' AND MonthlyIncome.Month='{2}'",
                    ComboBoxSource.SelectedIndex, btnSelectedYear.Text, i), "Income");

                if (!commenMethods.ReturnListHasError(MonthlyIncomeList))
                {
                    // calculate cumulative expenditure
                    MonthlyIncome = Convert.ToDouble(MonthlyIncomeList[0]);
                    CumulativeIncome += MonthlyIncome;

                    // add income and cumulative income into tableincome
                    TableIncome.Rows[n].Cells[1].Value = MonthlyIncome;
                    TableIncome.Rows[n].Cells[2].Value = CumulativeIncome;
                }
                else
                {
                    // add income and cumulative income into tableincome when income month not avaiable in database table
                    TableIncome.Rows[n].Cells[1].Value = 0;
                    TableIncome.Rows[n].Cells[2].Value = CumulativeIncome;
                }

                // add cumulative income to series 1 in chart
                ChartIncome.Series[1].Points.AddXY(SelectedMonthName, CumulativeIncome);
            }  

            // Select Current month
            TableIncome.Rows[SelectedMonth - 1].Selected = true;

            lblChartTitle.Text = String.Format("Cumulative Income of {0}", ComboBoxSource.SelectedItem.ToString());

            // show last cumulative in cumulative textbox
            if (txtCumulativeIncome.Text == "")
            {
                txtCumulativeIncome.Text = CumulativeIncome.ToString();
            }

            // reset selected month
            btnSelectMonth.Text = commenMethods.MonthList[DateTime.Now.Month - 1];
            TableIncome.Rows[DateTime.Now.Month - 1].Selected = true;
        }

        void ClearData()
        {
            TableIncome.Rows.Clear();
            txtMonthlyIncome.Clear();
            txtCumulativeIncome.Clear();
            ChartIncome.Series[0].Points.Clear();
            ChartIncome.Series[1].Points.Clear();
        }

        int FindSelectedMonth()
        {
            for (int i = 1; i <= 12; i++)
            {
                if (commenMethods.MonthList[i - 1] == btnSelectMonth.Text)
                {
                    return i;
                }
            }

            return 1;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // find SourceyearId for selected year and source
            List<string> SourceYearID = commenMethods.SQLRead(String.Format(
                "SELECT SourceYearID FROM SourceYear WHERE SourceYear.Year='{0}' AND SourceYear.SourceID='{1}'",
                btnSelectedYear.Text, ComboBoxSource.SelectedIndex), "SourceYearID");

            if (!commenMethods.ReturnListHasError(SourceYearID))
            {
                int SelectedMonth = FindSelectedMonth();
                string Query;

                if (commenMethods.ReturnListHasError(commenMethods.SQLRead(String.Format(
                    "SELECT Income FROM MonthlyIncome WHERE SourceYearID='{0}' AND Month='{1}'",
                    SourceYearID[0], SelectedMonth), "Income")))
                {
                    // Income Not avaiable on database. Insert data to Database

                    Query = String.Format("INSERT INTO MonthlyIncome (SourceYearID,Month,Income) VALUES ('{0}','{1}','{2}')",
                        SourceYearID[0], SelectedMonth, txtMonthlyIncome.Text.Replace(",", ""));
                }
                else
                {
                    // Income avaiable on database. Update income

                    Query = String.Format("UPDATE MonthlyIncome SET Income='{0}' WHERE SourceYearID='{1}' AND Month='{2}'",
                        txtMonthlyIncome.Text.Replace(",", ""), SourceYearID[0], SelectedMonth);
                }

                // execute query
                if (commenMethods.ExecuteSQL(Query))
                {
                    MessageBox.Show("Successfully Updated Database", "Report",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    UpdateIncomeData();
                }
                else
                {
                    commenMethods.UpdateErrorMessageShow();
                }
            }
            else
            {
                commenMethods.UpdateErrorMessageShow();
            }
        }

        private void txtIncome_TextChanged(object sender, EventArgs e)
        {
            Guna2TextBox txtIncome = (Guna2TextBox)sender;

            txtIncome.Text = commenMethods.SaveOnlyIntegers(txtIncome.Text);
        }

        private void TableSources_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex < 5)
            {
                MenuSourceTable.Visible = true;
                MenuSourceTable.Left = MousePosition.X;
                MenuSourceTable.Top = MousePosition.Y;
                MenuSourceTable.Tag = e.RowIndex;
            }
        }

        private void MenuSourceTable_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // check enterd value is null
            if (TableSources.Rows[Convert.ToInt32(MenuSourceTable.Tag)].Cells[2].Value != null)
            {
                string Query, 
                    IncomeBudget = TableSources.Rows[Convert.ToInt32(MenuSourceTable.Tag)].Cells[2].Value.ToString().Trim().Replace(",","");

                List<string> CurrentSourceYearID = commenMethods.SQLRead(String.Format(
                    "SELECT SourceYearID FROM SourceYear WHERE SourceID='{0}' AND Year='{1}'",
                    ComboBoxSource.SelectedIndex, btnSelectedYear.Text), "SourceYearID");

                // find income budget currently available on database
                if (commenMethods.ReturnListHasError(CurrentSourceYearID))
                {
                    // Income budget not available on database table. Insert all rows to database
                    int SourceYearID, ErrorCount = 0;

                    for (int i = 0; i < TableSources.Rows.Count - 1; i++) 
                    {
                        IncomeBudget = TableSources.Rows[i].Cells[2].Value.ToString().Trim().Replace(",", ""); ;

                        // find last sourceyearID
                        SourceYearID = Convert.ToInt32(commenMethods.SQLRead(
                            "SELECT MAX(SourceYearID) AS LastSourceYearID FROM SourceYear", "LastSourceYearID")[0]) + 1;

                        Query = String.Format("INSERT INTO SourceYear (SourceYearID,SourceID,Year,IncomeBudget) " +
                            "VALUES ('{0}','{1}','{2}','{3}')",
                            SourceYearID, i, btnSelectedYear.Text, IncomeBudget);

                        // execute query
                        if (!commenMethods.ExecuteSQL(Query))
                        {
                            ErrorCount += 1; // count errors
                        }
                    }

                    MessageBox.Show(String.Format("Update {0} rows successful and {1} rows failed", TableSources.Rows.Count - 1 - ErrorCount, ErrorCount),
                        "Update Result", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    // income budget available on database. Update row

                    Query = String.Format("UPDATE SourceYear SET IncomeBudget='{0}' WHERE SourceYearID='{1}'",
                        IncomeBudget, CurrentSourceYearID[0]);

                    // execute query
                    if (commenMethods.ExecuteSQL(Query))
                    {
                        MessageBox.Show("Database Updated Successfully", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        commenMethods.UpdateErrorMessageShow();
                    }
                }            

                // Update Table
                UpdateSourceTable();
            }
            else
            {
                MessageBox.Show("Can't save null value for income budget in database", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNavigation_Click(object sender, EventArgs e)
        {
            Guna2Button btnNavigation = (Guna2Button)sender;
            commenMethods.NavigateTo(btnNavigation.Tag.ToString());
            this.Close();
        }

        private void TableIncome_SelectionChanged(object sender, EventArgs e)
        {
            if (TableIncome.Rows.Count == 13 && TableIncome.SelectedRows.Count > 0) 
            {
                DataGridViewRow SelectedRow = TableIncome.Rows[TableIncome.SelectedRows[0].Index];

                if (SelectedRow.DefaultCellStyle.BackColor != Color.FromArgb(58, 190, 240))
                {
                    // show selected row data in main text boxes 
                    btnSelectMonth.Text = SelectedRow.Cells[0].Value.ToString().Trim();
                    txtMonthlyIncome.Text = SelectedRow.Cells[1].Value.ToString().Trim();
                    txtCumulativeIncome.Text = SelectedRow.Cells[2].Value.ToString().Trim();
                }
            }
        }
    }
}
