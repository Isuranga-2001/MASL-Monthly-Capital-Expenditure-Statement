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
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        CommenMethods commenMethods = new CommenMethods();
        ExpenditureSummery expenditureSummeryform = new ExpenditureSummery();
        ExportWindow exportForm = new ExportWindow();

        // Declear LocationList Dictionary for find locations of btnDownArrows in expand mode of each table
        Dictionary<char, int> expandLocationList = new Dictionary<char, int> { { 'M', 117 }, { 'B', 171 }, { 'I', 219 }, { 'E', 445 } };

        List<Guna2DataGridView> tableList; // table List
        List<Guna2CustomCheckBox> checkBoxList; // checkBoxList

        const byte collapseLocation = 13; // locatin of btnDownArrows in collapse mode of any table

        private void btnNavigationButton_Click(object sender, EventArgs e)
        {
            Guna2Button btnNavigation = (Guna2Button)sender;
            commenMethods.NavigateTo(btnNavigation.Tag.ToString());
            this.Close();
        }

        private void ChangeSelectedMonth(object sender, EventArgs e)
        {
            SelectMonth form = new SelectMonth();

            form.CurrentSelectedMonth = btnSelectMonth.Text;
            form.txtSelectedYear.Text = btnSelectedYear.Text;
            form.ShowDialog();

            if (form.UpdateEnabled)
            {
                btnSelectMonth.Text = form.btnSelectedMonth.Text;
                btnSelectedYear.Text = form.txtSelectedYear.Text;

                FillTables(new List<bool> { true, true, true, true });
            }
        }

        private void Report_Load(object sender, EventArgs e)
        {
            btnSelectedYear.Text = DateTime.Now.Year.ToString();
            btnSelectMonth.Text = commenMethods.MonthList[DateTime.Now.Month - 1];

            tableList = new List<Guna2DataGridView> { TableMain, TableBudget, TableIncome, TableExpenditure };
            checkBoxList = new List<Guna2CustomCheckBox> { MainTableCheckBox, BudgetTableCheckBox, IncomeTableCheckBox, ExpenditureTableCheckBox };

            FillTables(new List<bool> { true, true, true, true });

            foreach (Guna2Panel guna2Panel in 
                new List<Guna2Panel> { MainTableBackPanel, BudgetTableBackPanel, IncomeTableBackPanel, ExpenditureTableBackPanel })
            {
                guna2Panel.Size = guna2Panel.MinimumSize;
            }
        }

        short FindSelectedMonth()
        {
            for (short i = 1; i <= 12; i++)
            {
                if (commenMethods.MonthList[i - 1] == btnSelectMonth.Text)
                {
                    return i;
                }
            }

            return 1;
        }

        private void btnDownArrow_Click(object sender, EventArgs e)
        {
            Guna2CircleButton btnDownArrow = (Guna2CircleButton)sender;

            if (btnDownArrow.Top == collapseLocation) 
            {
                // set location as expand location of each btn
                btnDownArrow.Top = expandLocationList[Convert.ToChar(btnDownArrow.Tag)];
                btnDownArrow.Image = Properties.Resources.Collapse_arrow;
                btnDownArrow.Parent.Size = btnDownArrow.Parent.MaximumSize;
            }
            else
            {
                // set collapse location
                btnDownArrow.Top = collapseLocation;
                btnDownArrow.Image = Properties.Resources.Expand_arrow;
                btnDownArrow.Parent.Size = btnDownArrow.Parent.MinimumSize;
            }
        }

        void FillTables(List<bool> avaiableTableList)
        {
            List<string> returnValue_Expend, // get monthly expenditure for each month
                returnValue_CumExpend, // get cumulative expenditure form Jan to each month
                returnValue_BudgetDetails, // get annual capital, recurrent, monthly fund recieved, recurrent expenditure
                returnValue_RecurrentExpend, // get recurrent expenditure
                returnValue_CumRecurrentExpend, // get cumulative recurrent expenditure form Jan to each month
                returnValue_FundReceived; // get Fund received value for selected month 

            string query;

            short SelectedYear = Convert.ToInt16(btnSelectedYear.Text), 
                SelectedMonth = FindSelectedMonth();

            int previouseMonth = SelectedMonth - 1;

            // clear rows of all avaiable tables
            for (byte k = 0; k < tableList.Count; k++)
            {
                if (avaiableTableList[k])
                {
                    tableList[k].Rows.Clear();
                }
            }

            // Fill second table (Budget Details)
            // rename headers
            TableBudget.Columns[2].HeaderText = "Expenditure For " + btnSelectMonth.Text;

            if (avaiableTableList[1])
            {
                // find budget for year
                returnValue_BudgetDetails = commenMethods.SQLRead(String.Format(
                    "SELECT Capital,Recurrent FROM AllocationBudget WHERE Year='{0}'", SelectedYear),
                    "Capital Recurrent");

                // find cumulative expenditure for each year
                query = String.Format(
                    "SELECT SUM(ExpenditureMonth.Expenditure) AS TotalExpenditure " +
                    "FROM ExpenditureMonth,ActivityCode,MainActivity " +
                    "WHERE ExpenditureMonth.ActivityCodeID=ActivityCode.ActivityCodeID " +
                    "AND MainActivity.ActivityID=ActivityCode.ActivityID " +
                    "AND MainActivity.Year='{0}'", SelectedYear);

                // find cumulative expenditure for each year between Jan and selected month
                returnValue_CumExpend = commenMethods.SQLRead(query +
                    String.Format(" AND ExpenditureMonth.Month>=1 AND ExpenditureMonth.Month<={0}", SelectedMonth), "TotalExpenditure");

                // find monthly expenditure for each month
                query += String.Format(" AND ExpenditureMonth.Month='{0}'", SelectedMonth);
                returnValue_Expend = commenMethods.SQLRead(query, "TotalExpenditure");

                // find recurrent details
                returnValue_RecurrentExpend = commenMethods.SQLRead(String.Format(
                    "SELECT RecurrentExpenditure FROM MonthyBudget WHERE Year='{0}' AND Month='{1}'",
                    SelectedYear, SelectedMonth), "RecurrentExpenditure");

                // find cumulative recurrent expenditure
                returnValue_CumRecurrentExpend = commenMethods.SQLRead(String.Format(
                    "SELECT SUM(RecurrentExpenditure) AS CumulativeRecurrentExpenditure " +
                    "FROM MonthyBudget WHERE Year='{0}'", SelectedYear), "CumulativeRecurrentExpenditure");

                // find fund received data
                returnValue_FundReceived = commenMethods.SQLRead(String.Format(
                    "SELECT MonthyBudget.CapitalFundReceived,MonthyBudget.RecurrentFundReceived " +
                    "FROM AllocationBudget,MonthyBudget " +
                    "WHERE AllocationBudget.Year=MonthyBudget.Year " +
                    "AND AllocationBudget.Year='{0}' AND MonthyBudget.Month='{1}'",
                    SelectedYear, SelectedMonth), "CapitalFundReceived RecurrentFundReceived");

                TableBudget.Rows.Add();
                AddToTable(TableBudget.Rows[0], new List<string> { "Capital", "0.00", "0.00", "0.00", "0.00" });

                TableBudget.Rows.Add();
                AddToTable(TableBudget.Rows[1], new List<string> { "Recurrent", "0.00", "0.00", "0.00", "0.00" });

                if (!commenMethods.ReturnListHasError(returnValue_BudgetDetails))
                {
                    TableBudget.Rows[0].Cells[1].Value = SetAsNumber(returnValue_BudgetDetails[0]);
                    TableBudget.Rows[1].Cells[1].Value = SetAsNumber(returnValue_BudgetDetails[1]);

                    if (!commenMethods.ReturnListHasError(returnValue_CumExpend))
                    {
                        TableBudget.Rows[0].Cells[3].Value = SetAsNumber(returnValue_CumExpend[0]);
                    }

                    if (!commenMethods.ReturnListHasError(returnValue_CumExpend))
                    {
                        TableBudget.Rows[0].Cells[2].Value = SetAsNumber(returnValue_Expend[0]);
                    }
                    
                    if (!commenMethods.ReturnListHasError(returnValue_CumRecurrentExpend))
                    {
                        TableBudget.Rows[1].Cells[3].Value = SetAsNumber(returnValue_CumRecurrentExpend[0]);
                    }

                    if (!commenMethods.ReturnListHasError(returnValue_RecurrentExpend))
                    {
                        TableBudget.Rows[1].Cells[2].Value = SetAsNumber(returnValue_RecurrentExpend[0]);
                    }

                    if (!commenMethods.ReturnListHasError(returnValue_FundReceived))
                    {
                        TableBudget.Rows[0].Cells[4].Value = SetAsNumber(returnValue_FundReceived[0]);
                        TableBudget.Rows[1].Cells[4].Value = SetAsNumber(returnValue_FundReceived[1]);
                    }
                }

                // find total
                FindTotal(TableBudget, TableBudget.Rows[2], new List<byte> { 1, 2, 3, 4 }, new List<short> { 0, 1 }, 0);
            }

            if (avaiableTableList[0])
            {
                // Fill first table (Main Table)
                // Rename headers
                TableMain.Columns[2].HeaderText = "Budget For " + btnSelectedYear.Text;

                if (previouseMonth > 0)
                    TableMain.Columns[3].HeaderText = "Expenditure For " + commenMethods.MonthList[previouseMonth];
                else
                    TableMain.Columns[3].HeaderText = "";

                if (SelectedMonth != 1)
                {
                    AddToTable(TableMain.Rows[0],
                        new List<string> { "MASL", "CF", "Total", TableBudget.Rows[2].Cells[2].Value.ToString(),
                            TableBudget.Rows[2].Cells[3].Value.ToString() });
                }
                else
                {
                    AddToTable(TableMain.Rows[0], new List<string> { "MASL", "CF", "Total", "0.00", "0.00" });
                }
            }

            if (avaiableTableList[2])
            {
                // fill third table (Income Table)
                // rename headers
                TableIncome.Columns[3].HeaderText = "Income For " + commenMethods.MonthList[SelectedMonth - 1];

                // find source table default data
                List<string> incomeTableDataList =
                    commenMethods.SQLRead(String.Format(
                        "SELECT Source.SourceName,Source.Section,SourceYear.IncomeBudget,SourceYear.SourceYearID " +
                        "FROM Source,SourceYear " +
                        "WHERE Source.SourceID=SourceYear.SourceID AND SourceYear.Year='{0}'", SelectedYear),
                        "SourceName Section IncomeBudget SourceYearID");

                List<string> incomeForMonth, cumulativeIncome;

                if (!commenMethods.ReturnListHasError(incomeTableDataList))
                {
                    for (byte i = 0; i < incomeTableDataList.Count; i += 4)
                    {
                        TableIncome.Rows.Add();
                        TableIncome.Rows[i / 4].Cells[0].Value = incomeTableDataList[i]; // income source name
                        TableIncome.Rows[i / 4].Cells[1].Value = incomeTableDataList[i + 1]; // section of income source
                        TableIncome.Rows[i / 4].Cells[2].Value = SetAsNumber(incomeTableDataList[i + 2]); // imcome budget for selected year

                        // for find income of each ncome source for selected month 
                        incomeForMonth = commenMethods.SQLRead(String.Format(
                            "SELECT Income FROM MonthlyIncome WHERE SourceYearID='{0}' AND Month='{1}'",
                            incomeTableDataList[i + 3], SelectedMonth), "Income");

                        // for find cumulative income of each source till selected month from jan
                        cumulativeIncome = commenMethods.SQLRead(String.Format(
                            "SELECT SUM(Income) AS CumulativeIncome FROM MonthlyIncome WHERE SourceYearID='{0}' AND Month<={1}",
                            incomeTableDataList[i + 3], SelectedMonth), "CumulativeIncome");

                        if (!commenMethods.ReturnListHasError(incomeForMonth))
                            TableIncome.Rows[i / 4].Cells[3].Value = SetAsNumber(incomeForMonth[0]); // income

                        else
                            TableIncome.Rows[i / 4].Cells[3].Value = "0"; // set income as zero

                        if (!commenMethods.ReturnListHasError(cumulativeIncome))
                            TableIncome.Rows[i / 4].Cells[4].Value = SetAsNumber(cumulativeIncome[0]); // cumulative income
                        else
                            TableIncome.Rows[i / 4].Cells[4].Value = "0"; // set cumulative income as zero
                    }

                    FindTotal(TableIncome, TableIncome.Rows[4], new List<byte> { 2, 3, 4 }, new List<short> { 0, 1, 2, 3 }, 0);

                    FindTableIncomePercentage();
                }
                else
                {
                    MessageBox.Show("Something went wrong. Can't load income table successfully. You should update manually",
                        "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            if (avaiableTableList[3])
            {
                // forth table (expenditure table)
                // rename headers
                TableExpenditure.Columns[3].HeaderText = "Allocation " + SelectedYear;
                TableExpenditure.Columns[4].HeaderText = "Expenditure Of " + commenMethods.MonthList[SelectedMonth - 1];
                
                // find main activity data from database
                DataTable mainActivityTable = commenMethods.RetrieveDataOnDataTable(String.Format(
                    "SELECT MainActivity.BudgectCode,MainActivity.ItemNo,MainActivity.MainActivityName," +
                    "SUM(SubActivity.Allocation) AS Allocation,SUM(SubActivity.Commitment) AS Commitment " +
                    "FROM MainActivity,ActivityCode,SubActivity " +
                    "WHERE MainActivity.ActivityID=ActivityCode.ActivityID " +
                    "AND ActivityCode.ActivityCodeID=SubActivity.ActivityCodeID " +
                    "AND MainActivity.Year='{0}' " +
                    "GROUP BY MainActivity.BudgectCode,MainActivity.ItemNo,MainActivity.MainActivityName " +
                    "ORDER BY ItemNo", SelectedYear));

                // find sub activities (INsub1 != 0)
                DataTable subActivityTable = commenMethods.RetrieveDataOnDataTable(String.Format(
                    "SELECT MainActivity.BudgectCode,MainActivity.ItemNo,ActivityCode.INSub1,ActivityCode.INSub2," +
                    "SubActivity.ActivityName,SubActivity.Allocation,SubActivity.Commitment " +
                    "FROM MainActivity,ActivityCode,SubActivity " +
                    "WHERE MainActivity.ActivityID=ActivityCode.ActivityID " +
                    "AND ActivityCode.ActivityCodeID=SubActivity.ActivityCodeID " +
                    "AND MainActivity.Year='{0}' AND ActivityCode.INSub1<>0 " +
                    "ORDER BY MainActivity.ItemNo,ActivityCode.INSub1", SelectedYear));

                if (mainActivityTable != null && subActivityTable != null)
                {
                    // Combine Item No Rows of subActivityTable
                    // add new column to save combined columns
                    subActivityTable.Columns.Add("CombinedItemNo");

                    foreach (DataRow subActivityTableRow in subActivityTable.Rows)
                    {
                        // save combined item no on new column (index 7) 
                        subActivityTableRow[7] = subActivityTableRow.ItemArray[1] + "." + subActivityTableRow.ItemArray[2];

                        // check insub2 is not null and add to combined item no
                        if (subActivityTableRow.ItemArray[3].ToString().Length != 0)
                        {
                            subActivityTableRow[7] += "." + subActivityTableRow.ItemArray[3];
                        }
                    }

                    // remove extra columns form DataTable
                    //subActivityTable.Columns.RemoveAt(1); // Item No
                    subActivityTable.Columns.RemoveAt(2); // InSub1
                    subActivityTable.Columns.RemoveAt(2); // INsub2

                    // define a variable for store resently added datagridview row
                    DataGridViewRow newTableRow;

                    foreach (DataRow mainActivityTableRow in mainActivityTable.Rows)
                    {
                        // add new row
                        newTableRow = TableExpenditure.Rows[TableExpenditure.Rows.Add()];
                                                
                        // show mainActivityTable data on TableExpenditure
                        for (byte i = 0; i <= 3; i++) 
                            newTableRow.Cells[i].Value = mainActivityTableRow[i];

                        newTableRow.Cells[6].Value = mainActivityTableRow[4];

                        // change color of main activity cell
                        newTableRow.DefaultCellStyle.BackColor = Color.FromArgb(58, 190, 240);
                        newTableRow.DefaultCellStyle.SelectionBackColor = Color.FromArgb(58, 190, 240);

                        foreach (DataRow subActivityTableRow in subActivityTable.Rows)
                        {
                            // check relationship subActivityTableRow details to mianActivityTableRow details
                            if (subActivityTableRow.ItemArray[1].ToString() == mainActivityTableRow.ItemArray[1].ToString() 
                                && subActivityTableRow.ItemArray[0].ToString() == mainActivityTableRow.ItemArray[0].ToString())
                            {
                                // add new row for show sub activity details
                                newTableRow = TableExpenditure.Rows[TableExpenditure.Rows.Add()];

                                // show subActivityTable data on TableExpenditure
                                for (byte i = 0; i <= 3; i++)
                                    newTableRow.Cells[i].Value = subActivityTableRow[i];

                                newTableRow.Cells[1].Value = subActivityTableRow[5];
                                newTableRow.Cells[6].Value = subActivityTableRow[4];
                            }
                        }
                    }

                    // Update expenditure for selected month and cumulaive expenditure
                    UpdateExpenditureForSelectedMonth();

                    // Update Allocation and commitment os Sub main activities like 2.2 (parent of 2.2.1 and 2.2.2)
                    UpdateAllocationAndCommitmentOfSubMainActivities();

                    // show expenditure progress as percentage
                    UpdateExpenditureProgress();

                    // split numbers by comma in cell (for easy idetify)
                    for (short i = 0; i < TableExpenditure.Rows.Count - 1; i++)
                    {
                        for (short j = 3; j <= 6; j++)
                        {
                            TableExpenditure.Rows[i].Cells[j].Value = SetAsNumber(TableExpenditure.Rows[i].Cells[j].Value.ToString());
                        }
                    }

                    // find row to calculate total
                    List<short> countableRowIndexList = new List<short> { };

                    for (short i = 0; i < TableExpenditure.Rows.Count - 1; i++) 
                    {
                        if (TableExpenditure.Rows[i].DefaultCellStyle.BackColor == Color.FromArgb(58, 190, 240))
                        {
                            countableRowIndexList.Add(i);
                        }
                    }

                    DataGridViewRow lastRow = TableExpenditure.Rows[TableExpenditure.Rows.Count - 1];

                    // find total
                    FindTotal(TableExpenditure, lastRow, new List<byte> { 3, 4, 5, 6 }, countableRowIndexList, 2);

                    lastRow.Cells[7].Value = Math.Round(((Convert.ToDouble(lastRow.Cells[5].Value) + Convert.ToDouble(lastRow.Cells[6].Value)) / Convert.ToDouble(lastRow.Cells[3].Value)) * 100, 1) + "%";
                    lastRow.Cells[0].Value = lastRow.Cells[1].Value = "";

                    // deselect selected row
                    if (TableExpenditure.SelectedRows.Count > 0) 
                        TableExpenditure.SelectedRows[0].Selected = false;
                }
                else
                {
                    MessageBox.Show("Something went wrong. Can't load expenditure table successfully. You should update manually",
                       "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void UpdateExpenditureProgress()
        {
            foreach (DataGridViewRow dataGridViewRow in TableExpenditure.Rows)
            {
                if (dataGridViewRow.Cells[0].Value == null)
                    break;

                if (dataGridViewRow.Cells[3].Value.ToString() != "0")
                {
                    // Percetage = ((CumulativeExpenditure + Commitment) / Allocation) * 100

                    dataGridViewRow.Cells[7].Value = Math.Round(((Convert.ToDouble(dataGridViewRow.Cells[5].Value) + Convert.ToDouble(dataGridViewRow.Cells[6].Value)) / Convert.ToDouble(dataGridViewRow.Cells[3].Value)) * 100, 1) + "%";
                }
                else
                {
                    dataGridViewRow.Cells[7].Value = "0%";
                }
            }
        }

        void UpdateAllocationAndCommitmentOfSubMainActivities()
        {
            // find Allocation and commitment os Sub main activities and save on data table
            DataTable allocationCommitmentTable = commenMethods.RetrieveDataOnDataTable(String.Format(
                "SELECT MainActivity.BudgectCode,MainActivity.ItemNo,ActivityCode.INSub1," +
                "SUM(SubActivity.Allocation) AS Allocation,SUM(SubActivity.Commitment) AS Commitment " +
                "FROM MainActivity,ActivityCode,SubActivity " +
                "WHERE MainActivity.ActivityID=ActivityCode.ActivityID " +
                "AND ActivityCode.ActivityCodeID=SubActivity.ActivityCodeID " +
                "AND MainActivity.Year='{0}' AND ActivityCode.INSub1<>0 " +
                "AND (ActivityCode.INSub2 IS NOT NULL OR ActivityCode.INSub2='') " +
                "GROUP BY MainActivity.BudgectCode,MainActivity.ItemNo,ActivityCode.INSub1",
                btnSelectedYear.Text));

            string itemNo;

            // select row of above data table
            foreach (DataRow dataRow in allocationCommitmentTable.Rows)
            {
                // create item no usinf item no parts
                itemNo = dataRow.ItemArray[1].ToString() + "." + dataRow.ItemArray[2];

                // select row of table expenditure
                foreach (DataGridViewRow dataGridViewRow in TableExpenditure.Rows)
                {
                    // last row (stop the loop)
                    if (dataGridViewRow.Cells[0].Value == null)
                        break;

                    if (dataGridViewRow.Cells[3].Value.ToString().Trim() == "") // is allocation is non
                        dataGridViewRow.Cells[3].Value = "0"; // set allocation as 0 

                    if (dataGridViewRow.Cells[6].Value.ToString().Trim() == "") // is commitment is non
                        dataGridViewRow.Cells[6].Value = "0"; // set commitment as 0 

                    // check bugetcode and item no to find correct row
                    if (dataGridViewRow.Cells[0].Value.ToString() == dataRow.ItemArray[0].ToString()
                        && dataGridViewRow.Cells[1].Value.ToString() == itemNo) 
                    {
                        dataGridViewRow.Cells[3].Value = dataRow.ItemArray[3]; // set allocation
                        dataGridViewRow.Cells[6].Value = dataRow.ItemArray[4]; // set commitment

                        dataGridViewRow.DefaultCellStyle.BackColor = Color.FromArgb(144, 238, 144);

                    }
                }
            }
        }

        void UpdateExpenditureForSelectedMonth()
        {
            string[] itemNoParts;
            string budgetCode, query;
            short selectedMonth = FindSelectedMonth();
            List<string> expenditureList, queryList;
                        
            foreach (DataGridViewRow tableExpenditureRow in TableExpenditure.Rows)
            {
                if (tableExpenditureRow.Cells[1].Value == null)
                    continue;

                itemNoParts = tableExpenditureRow.Cells[1].Value.ToString().Trim().Split('.');
                budgetCode = tableExpenditureRow.Cells[0].Value.ToString();

                if (tableExpenditureRow.DefaultCellStyle.BackColor != Color.FromArgb(58, 190, 240)) 
                {
                    queryList = new List<string>
                    {
                        String.Format(
                            "SELECT ExpenditureMonth.Expenditure FROM ExpenditureMonth,ActivityCode,MainActivity " +
                            "WHERE ActivityCode.ActivityID=MainActivity.ActivityID " +
                            "AND ExpenditureMonth.ActivityCodeID=ActivityCode.ActivityCodeID " +
                            "AND MainActivity.BudgectCode='{0}' AND MainActivity.ItemNo='{1}' " +
                            "AND ActivityCode.INSub1='{2}' AND ExpenditureMonth.Month='{3}' AND MainActivity.Year='{4}'",
                            budgetCode, itemNoParts[0], itemNoParts[1], selectedMonth, btnSelectedYear.Text),

                        String.Format(
                            "SELECT SUM(ExpenditureMonth.Expenditure) AS Expenditure " +
                            "FROM ExpenditureMonth,ActivityCode,MainActivity " +
                            "WHERE ActivityCode.ActivityID=MainActivity.ActivityID " +
                            "AND ExpenditureMonth.ActivityCodeID=ActivityCode.ActivityCodeID " +
                            "AND MainActivity.BudgectCode='{0}' AND MainActivity.ItemNo='{1}' " +
                            "AND ActivityCode.INSub1='{2}' AND ExpenditureMonth.Month<={3} AND MainActivity.Year='{4}'",
                            budgetCode, itemNoParts[0], itemNoParts[1], selectedMonth, btnSelectedYear.Text)
                    };

                    for (byte i = 4; i <= 5; i++) 
                    {
                        query = queryList[i - 4];

                        if (itemNoParts.Length == 3)
                        {
                            query += String.Format(" AND ActivityCode.INSub2='{0}'", itemNoParts[2]);
                        }

                        expenditureList = commenMethods.SQLRead(query, "Expenditure");

                        if (!commenMethods.ReturnListHasError(expenditureList))
                        {
                            if (expenditureList.Count > 1)
                            {
                                double total = 0;

                                foreach (string expenditure in expenditureList)
                                {
                                    total += Convert.ToDouble(expenditure);
                                }

                                tableExpenditureRow.Cells[i].Value = total;
                            }
                            else
                            {
                                tableExpenditureRow.Cells[i].Value = expenditureList[0];
                            }
                        }
                        else
                        {
                            tableExpenditureRow.Cells[i].Value = "0";
                        }
                    }
                }
                else
                {
                    // Update expenditure for selected month
                    expenditureList = commenMethods.SQLRead(String.Format(
                        "SELECT SUM(ExpenditureMonth.Expenditure) AS TotalExpenditure " +
                        "FROM ExpenditureMonth,ActivityCode,MainActivity " +
                        "WHERE ActivityCode.ActivityID=MainActivity.ActivityID " +
                        "AND ExpenditureMonth.ActivityCodeID=ActivityCode.ActivityCodeID " +
                        "AND MainActivity.BudgectCode='{0}' AND MainActivity.ItemNo='{1}' " +
                        "AND ExpenditureMonth.Month='{2}' AND MainActivity.Year='{3}'",
                        budgetCode, itemNoParts[0], selectedMonth, btnSelectedYear.Text), "TotalExpenditure");

                    if (!commenMethods.ReturnListHasError(expenditureList))
                    {
                        tableExpenditureRow.Cells[4].Value = expenditureList[0];
                    }
                    else
                    {
                        tableExpenditureRow.Cells[4].Value = "0";
                    }

                    // update cumulative expenditure
                    expenditureList = commenMethods.SQLRead(String.Format(
                        "SELECT SUM(ExpenditureMonth.Expenditure) AS CumulativeExpenditure " +
                        "FROM ExpenditureMonth,ActivityCode,MainActivity " +
                        "WHERE ActivityCode.ActivityID=MainActivity.ActivityID " +
                        "AND ExpenditureMonth.ActivityCodeID=ActivityCode.ActivityCodeID " +
                        "AND MainActivity.BudgectCode='{0}' AND MainActivity.ItemNo='{1}' " +
                        "AND ExpenditureMonth.Month<={2} AND MainActivity.Year='{3}'",
                        budgetCode, itemNoParts[0], selectedMonth, btnSelectedYear.Text),
                        "CumulativeExpenditure");

                    if (!commenMethods.ReturnListHasError(expenditureList))
                    {
                        tableExpenditureRow.Cells[5].Value = expenditureList[0];
                    }
                    else
                    {
                        tableExpenditureRow.Cells[5].Value = "0";
                    }
                }
            }
        }

        void FindTotal(DataGridView selectedTable, DataGridViewRow selectedTableRow, List<byte> targetColumnIndexList, List<short> targetRowIndexList, byte nameColumnIndex)
        {
            selectedTableRow.Cells[nameColumnIndex].Value = "Total";
            selectedTableRow.DefaultCellStyle.BackColor = Color.FromArgb(254, 210, 21);
            selectedTableRow.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 210, 21);

            double total = 0;
            string cellValueWithOnlyInt;
            DataGridViewCell selectedCell;

            foreach (byte targetColumnIndex in targetColumnIndexList)
            {
                foreach (short targetRowIndex in targetRowIndexList)
                {
                    selectedCell = selectedTable.Rows[targetRowIndex].Cells[targetColumnIndex];

                    if (selectedCell.Value.ToString().Trim() != "")
                    {
                        // remove another characters for value
                        cellValueWithOnlyInt = commenMethods.SaveOnlyIntegers(selectedCell.Value.ToString());

                        if (cellValueWithOnlyInt != "")
                            total += Convert.ToDouble(cellValueWithOnlyInt); // caculate total
                        else
                            selectedCell.Value = "";// change cell value to empty string
                    }
                }

                selectedTableRow.Cells[targetColumnIndex].Value = (total).ToString("N2");
                total = 0;
            }
        }

        string SetAsNumber(string number)
        {            
            number = commenMethods.SaveOnlyIntegers(number);

            if (number == "")
            {
                return "0.00";
            }
            else
            {
                return Convert.ToDouble(number).ToString("N2");
            }
        }

        void AddToTable(DataGridViewRow SelectedRow, List<string> cellValueList)
        {
            for (int i = 0; i < cellValueList.Count; i++) 
            {
                SelectedRow.Cells[i].Value = cellValueList[i];
            }
        }

        private void Table_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Guna2DataGridView selectedTable = (Guna2DataGridView)sender;

            if (selectedTable.Name == TableBudget.Name 
                && e.RowIndex > -1 && e.RowIndex < 2 && e.ColumnIndex > 0 
                && selectedTable.Rows.Count >= 3)
            {
                if (selectedTable.Rows[2].DefaultCellStyle.BackColor == Color.FromArgb(254, 210, 21)) 
                {
                    // true all conditions of budget table
                    AddComma();

                    // update total row
                    FindTotal(TableBudget, TableBudget.Rows[2],
                        new List<byte> { Convert.ToByte(e.ColumnIndex) }, new List<short> { 0, 1 }, 0);

                    FillTables(new List<bool> { true, false, false, false });
                }
            }
            else if (selectedTable.Name == TableIncome.Name // is table income
                && e.RowIndex > -1 && e.RowIndex < 5 && e.ColumnIndex > 1 && e.ColumnIndex != 5 // is correct cell
                && selectedTable.Rows.Count == 5) // is user input
            {
                // true all conditions of income table
                AddComma();

                // update total row
                FindTotal(TableIncome, TableIncome.Rows[4],
                    new List<byte> { Convert.ToByte(e.ColumnIndex) }, new List<short> { 0, 1, 2, 3 }, 0);

                // calculate percentage of income
                FindTableIncomePercentage();
            }

            void AddComma()
            {
                // set value with comma
                selectedTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value =
                    SetAsNumber(selectedTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
        }

        void FindTableIncomePercentage()
        {
            foreach (DataGridViewRow dataGridViewRow in TableIncome.Rows)
            {
                if (dataGridViewRow.Cells[2].Value != null && dataGridViewRow.Cells[4].Value != null)
                {
                    double incomeBudget = Convert.ToDouble(dataGridViewRow.Cells[2].Value.ToString().Replace(",", "")),
                        cumulativeIncome = Convert.ToDouble(dataGridViewRow.Cells[4].Value.ToString().Replace(",", ""));

                    if (Convert.ToDouble(dataGridViewRow.Cells[2].Value.ToString().Replace(",", "")) > 0)
                    {
                        dataGridViewRow.Cells[5].Value = Math.Round(cumulativeIncome / incomeBudget * 100, 1) + "%";
                    }
                    else
                    {
                        dataGridViewRow.Cells[5].Value = "0%";
                    }
                }
                else
                {
                    dataGridViewRow.Cells[5].Value = "0%";
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e) // this button located in top of the table budget
        {
            bool updateTables = false;

            if (TableBudget.Rows.Count == 3)
            {
                if (!commenMethods.ReturnListHasError(commenMethods.SQLRead(String.Format(
                    "SELECT Capital,Recurrent FROM AllocationBudget WHERE Year='{0}'",
                    btnSelectedYear.Text), "Capital Recurrent")))
                {
                    if (!commenMethods.ReturnListHasError(commenMethods.SQLRead(String.Format(
                        "SELECT RecurrentExpenditure,RecurrentFundReceived,CapitalFundReceived " +
                        "FROM MonthyBudget WHERE Year='{0}' AND Month='{1}'", btnSelectedYear.Text, FindSelectedMonth()),
                        "RecurrentExpenditure RecurrentFundReceived CapitalFundReceived")))
                    {
                        updateTables = true;
                    }
                }
            }

            List<string> QueryList = null;

            if (updateTables)
            {
                // Update database

                QueryList = new List<string> 
                { 
                    String.Format("UPDATE AllocationBudget SET " +
                    "Capital='{0}',Recurrent='{1}' WHERE Year='{2}'",
                    commenMethods.SaveOnlyIntegers(TableBudget.Rows[0].Cells[1].Value.ToString()),
                    commenMethods.SaveOnlyIntegers(TableBudget.Rows[1].Cells[1].Value.ToString()),
                    btnSelectedYear.Text),

                    String.Format("UPDATE MonthyBudget SET " +
                    "RecurrentExpenditure='{0}',RecurrentFundReceived='{1}',CapitalFundReceived='{2}' " +
                    "WHERE Year='{3}' AND Month='{4}'",
                    commenMethods.SaveOnlyIntegers(TableBudget.Rows[1].Cells[2].Value.ToString()),
                    commenMethods.SaveOnlyIntegers(TableBudget.Rows[1].Cells[4].Value.ToString()),
                    commenMethods.SaveOnlyIntegers(TableBudget.Rows[0].Cells[4].Value.ToString()),
                    btnSelectedYear.Text, FindSelectedMonth())
                };
            }
            else
            {
                // Insert new record

                QueryList = new List<string>
                {
                    String.Format("INSERT INTO MonthyBudget " +
                    "(Year,Month,RecurrentExpenditure,RecurrentFundReceived,CapitalFundReceived) " +
                    "VALUES ('{0}','{1}','{2}','{3}','{4}')",
                    btnSelectedYear.Text, FindSelectedMonth(),
                    commenMethods.SaveOnlyIntegers(TableBudget.Rows[1].Cells[2].Value.ToString()),
                    commenMethods.SaveOnlyIntegers(TableBudget.Rows[1].Cells[4].Value.ToString()),
                    commenMethods.SaveOnlyIntegers(TableBudget.Rows[0].Cells[4].Value.ToString()))
                };

                List<string> returnValue = commenMethods.SQLRead(String.Format(
                    "SELECT Capital,Recurrent FROM AllocationBudget WHERE Year='{0}'",
                    btnSelectedYear.Text), "Capital Recurrent");

                if (returnValue != null)
                {
                    if (returnValue.Count > 0)
                    {
                        // now avaiable on database
                        AddToQueryList(true);
                    }
                    else
                    {
                        // currently unavaiable on database
                        AddToQueryList(false);
                    }
                }
                else
                {
                    // currently unavaiable on database
                    AddToQueryList(false);
                }

                void AddToQueryList(bool IsUpdateQuery)
                {
                    if (IsUpdateQuery)
                    {
                        QueryList.Add(String.Format("UPDATE AllocationBudget SET " +
                            "Capital='{0}',Recurrent='{1}' WHERE Year='{2}'",
                            commenMethods.SaveOnlyIntegers(TableBudget.Rows[0].Cells[1].Value.ToString()),
                            commenMethods.SaveOnlyIntegers(TableBudget.Rows[1].Cells[1].Value.ToString()),
                            btnSelectedYear.Text));
                    }
                    else
                    {
                        QueryList.Add(
                            String.Format("INSERT INTO AllocationBudget (Year,Capital,Recurrent) VALUES ('{0}','{1}','{2}')",
                            btnSelectedYear.Text,
                            commenMethods.SaveOnlyIntegers(TableBudget.Rows[0].Cells[1].Value.ToString()),
                            commenMethods.SaveOnlyIntegers(TableBudget.Rows[1].Cells[1].Value.ToString())));
                    }
                }
            }

            foreach (string Query in QueryList)
            {
                commenMethods.ExecuteSQL(Query);
            }

            MessageBox.Show("Database Updated Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FillTables(new List<bool> { false, true, false, false });
        }

        private void TableExpenditure_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < TableExpenditure.RowCount && e.RowIndex >= 0) 
            {
                DataGridViewRow selectedRow = TableExpenditure.Rows[e.RowIndex];

                expenditureSummeryform.txtSelectedYear.Text = btnSelectedYear.Text;
                expenditureSummeryform.txtBudgetCode.Text = selectedRow.Cells[0].Value.ToString();
                expenditureSummeryform.txtItemNo.Text = selectedRow.Cells[1].Value.ToString();
                expenditureSummeryform.txtActivity.Text = selectedRow.Cells[2].Value.ToString();
                expenditureSummeryform.txtAllocation.Text = selectedRow.Cells[3].Value.ToString();
                expenditureSummeryform.txtCumulativeExpen.Text = selectedRow.Cells[5].Value.ToString();
                expenditureSummeryform.txtCommitment.Text = selectedRow.Cells[6].Value.ToString();
                expenditureSummeryform.PrecentageProgressBar.Value = Convert.ToInt32(selectedRow.Cells[7].Value.ToString().Replace("%", "").Split('.')[0]);
                expenditureSummeryform.lblPrecentage.Text = expenditureSummeryform.PrecentageProgressBar.Value + "%";

                expenditureSummeryform.ChartExpenditure.Series[0].Points.Clear();
                expenditureSummeryform.ChartExpenditure.Series[1].Points.Clear();

                commenMethods.UpdateChart(
                    selectedRow.Cells[1].Value.ToString().Split('.'),
                    selectedRow.Cells[0].Value.ToString(),
                    btnSelectedYear.Text,
                    selectedRow.Cells[3].Value.ToString(),
                    expenditureSummeryform.ChartExpenditure,
                    null);

                expenditureSummeryform.ShowDialog();
            }
            
        }

        private void btnNavigation_Click(object sender, EventArgs e)
        {
            Guna2Button btnNavigation = (Guna2Button)sender;
            commenMethods.NavigateTo(btnNavigation.Tag.ToString());
            this.Close();
        }

        private void BtnExpandAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Guna2CircleButton btnDownArrow in new List<Guna2CircleButton> { btnExpandTableMain, btnExpandTableBudget, btnExpandTableIncome, btnExpandTableExpenditure })
            {
                if (BtnExpandAll.Checked)
                {
                    // set location as expand location of each btn
                    btnDownArrow.Top = expandLocationList[Convert.ToChar(btnDownArrow.Tag)];
                    btnDownArrow.Image = Properties.Resources.Collapse_arrow;
                    btnDownArrow.Parent.Size = btnDownArrow.Parent.MaximumSize;
                }
                else
                {
                    // set collapse location
                    btnDownArrow.Top = collapseLocation;
                    btnDownArrow.Image = Properties.Resources.Expand_arrow;
                    btnDownArrow.Parent.Size = btnDownArrow.Parent.MinimumSize;
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            exportForm.availabilityOfTables.Clear();
            exportForm.tableList.Clear();

            for (byte i = 0; i < 4; i++)
            {
                exportForm.availabilityOfTables.Add(tableList[i].Tag.ToString(), checkBoxList[i].Checked);
                exportForm.tableList.Add(tableList[i].Tag.ToString(), tableList[i]);
            }

            exportForm.selectedMonth = btnSelectMonth.Text;
            exportForm.ShowDialog();
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            BudgetSummery form = new BudgetSummery();
            form.selectedYear = Convert.ToInt16(btnSelectedYear.Text);
            form.selectedMonth = Convert.ToByte(commenMethods.FindMonth(btnSelectMonth.Text));
            form.ShowDialog();
        }
    }
}
