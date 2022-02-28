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
        short noOfSources = 0;

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
            string Query = "SELECT Source.SourceName,Source.Section,SourceYear.IncomeBudget,Source.SourceID,SourceYear.SourceYearID " +
                "FROM SourceYear,Source " +
                "WHERE Source.SourceID=SourceYear.SourceID AND SourceYear.Year='{0}'";

            List<string> SourceList = commenMethods.SQLRead(
                String.Format(Query, btnSelectedYear.Text), "SourceName Section IncomeBudget SourceID SourceYearID");

            if (!commenMethods.ReturnListHasError(SourceList))
            {
                FillTable(SourceList); // has source data for selected year
            }
            else
            {
                // can't find data for selected year
                MessageBox.Show("Can't find data for " + btnSelectedYear.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // continue with 2021 data
                btnSelectedYear.Text = "2021";
                FillTable(commenMethods.SQLRead(String.Format(Query, "2021"), "SourceName Section IncomeBudget SourceID SourceYearID"));
            }
        }

        void FillTable(List<string> SourceList)
        {
            int n;
            ComboBoxSource.Items.Clear();

            for (int i = 0; i < SourceList.Count; i += 5)
            {
                ComboBoxSource.Items.Add(SourceList[i]); // source name add to combo box

                n = TableSources.Rows.Add();
                TableSources.Rows[n].Cells["SourceID"].Value = SourceList[i + 3]; // sourceID
                TableSources.Rows[n].Cells["SourceYearID"].Value = SourceList[i + 4]; // sourceYearID
                TableSources.Rows[n].Cells["Source"].Value = SourceList[i]; // source name
                TableSources.Rows[n].Cells["Section"].Value = SourceList[i + 1]; // section
                
                // split number (1000000) by comma like 1,000,000
                TableSources.Rows[n].Cells["IncomeBudget"].Value = commenMethods.SaveOnlyIntegers(SourceList[i + 2]);
            }

            ComboBoxSource.SelectedIndex = 0;

            UpdateIncomeData();
            noOfSources = (short)(TableSources.Rows.Count - 1);
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

            if (TableSources.Rows.Count - 1 == noOfSources) 
            {
                UpdateIncomeData();
            }
        }

        void UpdateIncomeData()
        {
            int SelectedMonth = FindSelectedMonth(), n;
            double CumulativeIncome = 0, MonthlyIncome, MonthlyIncomeBudget = 0;

            // find monthly income budget
            if (TableSources.Rows[TableSources.SelectedRows[0].Index].Cells["IncomeBudget"].Value != null)
            {
                string SelectedSourceMonthlyIncomeBudget = 
                    TableSources.Rows[TableSources.SelectedRows[0].Index].Cells["IncomeBudget"].Value.ToString().Trim();
                
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
                    TableSources.SelectedRows[0].Cells["SourceID"].Value.ToString(), btnSelectedYear.Text, i), "Income");

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
            string sourceYearID = TableSources.SelectedRows[0].Cells["SourceYearID"].Value.ToString();

            int SelectedMonth = FindSelectedMonth();
            string Query;

            if (commenMethods.ReturnListHasError(commenMethods.SQLRead(String.Format(
                "SELECT Income FROM MonthlyIncome WHERE SourceYearID='{0}' AND Month='{1}'",
                sourceYearID, SelectedMonth), "Income")))
            {
                // Income Not avaiable on database. Insert data to Database

                Query = String.Format("INSERT INTO MonthlyIncome (SourceYearID,Month,Income) VALUES ('{0}','{1}','{2}')",
                    sourceYearID, SelectedMonth, txtMonthlyIncome.Text.Replace(",", ""));
            }
            else
            {
                // Income avaiable on database. Update income

                Query = String.Format("UPDATE MonthlyIncome SET Income='{0}' WHERE SourceYearID='{1}' AND Month='{2}'",
                    txtMonthlyIncome.Text.Replace(",", ""), sourceYearID, SelectedMonth);
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

        private void txtIncome_TextChanged(object sender, EventArgs e)
        {
            Guna2TextBox txtIncome = (Guna2TextBox)sender;

            txtIncome.Text = commenMethods.SaveOnlyIntegers(txtIncome.Text);
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            IncomeSource form = new IncomeSource();

            form.btnSelectedYear.Text = btnSelectedYear.Text;

            form.ShowDialog();

            UpdateSourceTable();
        }
    }
}
