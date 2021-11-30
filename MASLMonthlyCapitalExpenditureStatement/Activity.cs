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
    public partial class Activity : Form
    {
        public Activity()
        {
            InitializeComponent();
        }

        CommenMethods commenMethods = new CommenMethods();

        int SelectedYear = DateTime.Now.Year, SelectedRowIndex = 0;
        bool InputEnabled = false;

        List<int> ExpandableRows = new List<int> { };
        List<string> BudgetCodeList = new List<string> { };

        private void Activity_Load(object sender, EventArgs e)
        {
            btnSelectedYear.Text = SelectedYear.ToString();

            RefreshTable(String.Format("SELECT BudgectCode,ItemNo,MainActivityName " +
                "FROM MainActivity WHERE Year='{0}'", SelectedYear));
        }

        void RefreshTable(string Query)
        {
            InputEnabled = false;
            commenMethods.RetrieveDataOnDataGridView(Query, TableActivities, 1, 3);

            for (int i = 0; i < TableActivities.RowCount; i++)
            {
                TableActivities.Rows[i].Cells[0].Value = Properties.Resources.Expand;
                TableActivities.Rows[i].Cells[4].Value = Properties.Resources.Save;
                TableActivities.Rows[i].Cells[5].Value = Properties.Resources.Details; 
            }

            ExpandableRows.Clear();

            TableActivities.Rows[TableActivities.RowCount - 1].Cells[0].Value = Properties.Resources.Empty;

            if (TableActivities.Rows.Count == 1 &&
                MessageBox.Show(String.Format("Can't Find Activities for {0}. ", btnSelectedYear.Text) +
                "Please give permission for copy activities form previous year or any other year.",
                "Permission Required", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
            {
                // copy activities form previous year
            }

            InputEnabled = true;

            BudgetCodeList = commenMethods.SQLRead(String.Format(
                "SELECT DISTINCT BudgectCode FROM MainActivity WHERE Year='{0}'", btnSelectedYear.Text), "BudgectCode");

            if (!commenMethods.ReturnListHasError(BudgetCodeList))
            {
                MenuSuggestBudgetCode.Items.Clear();

                foreach (string BudgetCode in BudgetCodeList)
                {
                    MenuSuggestBudgetCode.Items.Add(BudgetCode);
                }
            }

            TableActivities_SelectionChanged(TableActivities, null);
        }

        private void btnNavigationButton_Click(object sender, EventArgs e)
        {
            Guna2Button btnNavigation = (Guna2Button)sender;
            commenMethods.NavigateTo(btnNavigation.Tag.ToString());
            this.Close();            
        }

        private void TableActivities_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {            
            TableActivities.Rows[e.RowIndex].Cells[0].Value = Properties.Resources.Empty;
            TableActivities.Rows[e.RowIndex].Cells[4].Value = Properties.Resources.Save;
            TableActivities.Rows[e.RowIndex].Cells[5].Value = Properties.Resources.Details;

            if (InputEnabled)
            {
                if (TableActivities.Rows[0].DefaultCellStyle.BackColor == Color.FromArgb(254, 210, 21))
                {
                    TableActivities.Rows[e.RowIndex - 1].Cells[1].Value = TableActivities.Rows[0].Cells[1].Value;

                    if (TableActivities.Rows.Count > 3)
                    {
                        if (TableActivities.Rows[0].Cells[2].Value.ToString().Trim().Split('.').Length == 1)
                        {
                            TableActivities.Rows[e.RowIndex - 1].Cells[2].Value =
                                (Math.Round(float.Parse(TableActivities.Rows[e.RowIndex - 2].Cells[2].Value.ToString().Trim()) + 0.1, 1)).ToString();
                        }
                        else
                        {
                            string[] LastItemNoParts = TableActivities.Rows[e.RowIndex - 2].Cells[2].Value.ToString().Trim().Split('.');

                            TableActivities.Rows[e.RowIndex - 1].Cells[2].Value = LastItemNoParts[0] + "." + LastItemNoParts[1] +
                                "." +( Convert.ToInt32(LastItemNoParts[2]) + 1).ToString();
                        }
                    }
                    else
                    {
                        TableActivities.Rows[e.RowIndex - 1].Cells[2].Value = TableActivities.Rows[0].Cells[2].Value.ToString().Trim() + ".1";
                    }
                }
                else if (TableActivities.Rows.Count > 3) 
                {
                    TableActivities.Rows[e.RowIndex - 1].Cells[1].Value = TableActivities.Rows[e.RowIndex - 2].Cells[1].Value;

                    TableActivities.Rows[e.RowIndex - 1].Cells[2].Value = 
                        (Convert.ToInt32(TableActivities.Rows[e.RowIndex - 2].Cells[2].Value.ToString().Trim()) + 1).ToString();
                }
            }            
        }

        private void btnSelectMonth_Click(object sender, EventArgs e)
        {
            SelectMonth form = new SelectMonth();
            form.ShowDialog();
            btnSelectedYear.Text = Convert.ToString(form.SelectedYear);
            SelectedYear = form.SelectedYear;

            RefreshTable(String.Format("SELECT BudgectCode,ItemNo,MainActivityName " +
                "FROM MainActivity WHERE Year='{0}'", SelectedYear));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshTable(String.Format("SELECT BudgectCode,ItemNo,MainActivityName FROM MainActivity " +
                "WHERE Year='{0}' AND MainActivityName LIKE'%{1}%'", SelectedYear, txtSearch.Text.Trim()));
        }

        void SaveSelectedActivity(DataGridViewRow SelectedRow)
        {
            string BudgetCode = SelectedRow.Cells[1].Value.ToString().Trim();
            string[] ItemNoParts = SelectedRow.Cells[2].Value.ToString().Trim().Split('.');

            string Activity = "";
            string Query;

            if (SelectedRow.Cells[3].Value != null)
                Activity = SelectedRow.Cells[3].Value.ToString().Trim().Replace("'", " ");

            if (Activity == "")
            {
                MessageBox.Show("Can't save empty activity name on database", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!IsCurrentlyAvaiableOnDatabase()) // Insert new activity into database
            {
                Expenditure form = new Expenditure();
                form.btnSelectedYear.Text = btnSelectedYear.Text;
                form.txtActivity.Text = SelectedRow.Cells[3].Value.ToString().Trim();
                form.SaveNewActivity(BudgetCode, ItemNoParts);
            }
            else // update current value of activity name
            {
                if (ItemNoParts.Length == 1)
                {
                    Query = String.Format("UPDATE MainActivity SET MainActivityName=N'{0}' " +
                        "WHERE MainActivity.BudgectCode='{1}' AND MainActivity.ItemNo='{2}' AND MainActivity.Year='{3}'",
                        Activity, BudgetCode, ItemNoParts[0], btnSelectedYear.Text);
                }
                else
                {
                    List<string> ActivatyCodeID = FindActivityCodeID();

                    if (!commenMethods.ReturnListHasError(ActivatyCodeID))
                    {
                        Query = String.Format("UPDATE SubActivity SET ActivityName=N'{0}' WHERE ActivityCodeID='{1}'",
                            Activity, ActivatyCodeID[0]);
                    }
                    else
                    {
                        Query = null;
                        commenMethods.UpdateErrorMessageShow();
                    }
                }

                if (Query != null)
                {
                    if (commenMethods.ExecuteSQL(Query))
                    {
                        MessageBox.Show("Updated Successfully", "Updated", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        commenMethods.UpdateErrorMessageShow();
                    }
                }
            }

            List<string> FindActivityCodeID()
            {
                Query = String.Format("SELECT ActivityCode.ActivityCodeID " +
                        "FROM ActivityCode,MainActivity " +
                        "WHERE MainActivity.ActivityID=ActivityCode.ActivityID " +
                        "AND MainActivity.BudgectCode='{0}' AND MainActivity.ItemNo='{1}' " +
                        "AND MainActivity.Year='{2}' AND ActivityCode.INSub1='{3}'",
                        BudgetCode, ItemNoParts[0], btnSelectedYear.Text, ItemNoParts[1]);

                if (ItemNoParts.Length > 2)
                {
                    Query += String.Format(" AND ActivityCode.INSub2='{0}'", ItemNoParts[2]);
                }

                return commenMethods.SQLRead(Query, "ActivityCodeID");
            }

            bool IsCurrentlyAvaiableOnDatabase()
            {
                if (ItemNoParts.Length == 1)
                {
                    if (!commenMethods.ReturnListHasError(commenMethods.SQLRead(
                        String.Format("SELECT ActivityID FROM MainActivity " +
                        "WHERE BudgectCode='{0}' AND ItemNo='{1}' AND Year='{2}'",
                        BudgetCode, ItemNoParts[0], btnSelectedYear.Text), "ActivityID")))
                    {
                        return true;
                    }
                }
                else
                {
                    string QueryFindActivityCodID = String.Format("SELECT ActivityCode.ActivityCodeID " +
                        "FROM ActivityCode,MainActivity " +
                        "WHERE MainActivity.ActivityID=ActivityCode.ActivityID " +
                        "AND MainActivity.Year='{0}' " +
                        "AND MainActivity.BudgectCode='{1}' " +
                        "AND MainActivity.ItemNo='{2}'",
                        btnSelectedYear.Text, BudgetCode, ItemNoParts[0]);

                    if (ItemNoParts.Length == 2)
                    {
                        QueryFindActivityCodID +=
                            String.Format(" AND ActivityCode.INSub1='{0}' AND (ActivityCode.INSub2 IS NULL)", ItemNoParts[1]);
                    }
                    else
                    {
                        QueryFindActivityCodID +=
                            String.Format(" AND ActivityCode.INSub1='{0}' AND ActivityCode.INSub2='{1}'", ItemNoParts[1], ItemNoParts[2]);
                    }

                    if (!commenMethods.ReturnListHasError(commenMethods.SQLRead(QueryFindActivityCodID, "ActivityCodeID")))
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        void ShowActivityDetails(DataGridViewRow SelectedRow)
        {
            UseWaitCursor = true;

            Expenditure form = new Expenditure();

            form.btnSelectedYear.Text = btnSelectedYear.Text;
            form.txtItemNo.Text = SelectedRow.Cells[2].Value.ToString();
            form.RefreshBudgetCode();
            form.ComboBoxBudgetCode.SelectedItem = SelectedRow.Cells[1].Value.ToString();

            form.Show();
            this.Close();
        }

        private void TableActivities_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < TableActivities.Rows.Count - 1)
            {
                if (e.ColumnIndex == 0)
                {
                    if (TableActivities.Rows[0].DefaultCellStyle.BackColor != Color.FromArgb(254, 210, 21))
                    {
                        DataGridViewRow SelectedRow = TableActivities.Rows[e.RowIndex];

                        ExpandRows(SelectedRow, String.Format("SELECT MainActivity.BudgectCode,MainActivity.ItemNo,ActivityCode.INSub1," +
                            "ActivityCode.INSub2,SubActivity.ActivityName FROM MainActivity,ActivityCode,SubActivity " +
                            "WHERE MainActivity.ActivityID=ActivityCode.ActivityID AND " +
                            "ActivityCode.ActivityCodeID=SubActivity.ActivityCodeID AND " +
                            "MainActivity.BudgectCode='{0}' AND MainActivity.ItemNo='{1}' AND ActivityCode.INSub1<>'0'",
                            SelectedRow.Cells[1].Value.ToString().Trim(), SelectedRow.Cells[2].Value.ToString().Trim()), false);

                        TableActivities.Rows[TableActivities.RowCount - 1].Cells[0].Value = Properties.Resources.Empty;
                    }
                    else if (e.RowIndex == 0)
                    {
                        RefreshTable(String.Format("SELECT BudgectCode,ItemNo,MainActivityName " +
                            "FROM MainActivity WHERE Year='{0}'", SelectedYear));
                    }
                    else if (TableActivities.Rows[0].DefaultCellStyle.BackColor == Color.FromArgb(254, 210, 21))
                    {
                        foreach (int ExpandableRowNo in ExpandableRows)
                        {
                            if (ExpandableRowNo == e.RowIndex)
                            {
                                DataGridViewRow SelectedRow = TableActivities.Rows[e.RowIndex];

                                string[] ItemNo = SelectedRow.Cells[2].Value.ToString().Trim().Split('.');

                                if (ItemNo.Length >= 3)
                                {
                                    MessageBox.Show(String.Format("Something went wrong. Can't expand {0}.",
                                        SelectedRow.Cells[2].Value.ToString().Trim()),
                                        "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    ExpandRows(SelectedRow, String.Format("SELECT MainActivity.BudgectCode,MainActivity.ItemNo,ActivityCode.INSub1," +
                                        "ActivityCode.INSub2,SubActivity.ActivityName FROM MainActivity,ActivityCode,SubActivity " +
                                        "WHERE MainActivity.ActivityID=ActivityCode.ActivityID AND " +
                                        "ActivityCode.ActivityCodeID=SubActivity.ActivityCodeID AND " +
                                        "MainActivity.BudgectCode='{0}' AND MainActivity.ItemNo='{1}' AND ActivityCode.INSub1='{2}'",
                                        SelectedRow.Cells[1].Value.ToString().Trim(), ItemNo[0], ItemNo[1]), true);

                                    TableActivities.Rows.RemoveAt(1);

                                    TableActivities.Rows[TableActivities.RowCount - 1].Cells[0].Value = Properties.Resources.Empty;

                                    ExpandableRows.Clear();
                                }

                                break;
                            }
                        }
                    }
                }
                else if (e.ColumnIndex == 5)
                {
                    ShowActivityDetails(TableActivities.Rows[e.RowIndex]);
                }
                else if (e.ColumnIndex == 4)
                {
                    SaveSelectedActivity(TableActivities.Rows[e.RowIndex]);
                }
                else if (e.ColumnIndex == 1)
                {
                    if (TableActivities.Rows[0].DefaultCellStyle.BackColor != Color.FromArgb(254, 210, 21))
                    {
                        SelectedRowIndex = e.RowIndex;

                        MenuSuggestBudgetCode.Visible = true;
                        MenuSuggestBudgetCode.Top = MousePosition.Y;
                        MenuSuggestBudgetCode.Left = MousePosition.X;
                    }
                }
            }           
        }

        private void MenuSuggestBudgetCode_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            TableActivities.Rows[SelectedRowIndex].Cells[1].Value = e.ClickedItem.Text;
        }

        private void TableActivities_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex < TableActivities.Rows.Count - 1)
            {
                if (TableActivities.Rows[e.RowIndex].Cells[2].Value.ToString().Split('.').Length == 2)
                {
                    MenuTableRightClick.Items[2].Enabled = true;
                }
                else
                {
                    MenuTableRightClick.Items[2].Enabled = false;
                }

                MenuTableRightClick.Tag = e.RowIndex;
                MenuTableRightClick.Visible = true;
                MenuTableRightClick.Top = MousePosition.Y;
                MenuTableRightClick.Left = MousePosition.X;
            }
        }

        private void MenuTableRightClick_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Tag.ToString())
            {
                case "Save":
                    {
                        SaveSelectedActivity(TableActivities.Rows[Convert.ToInt32(MenuTableRightClick.Tag)]);
                        break;
                    }
                case "Details":
                    {
                        ShowActivityDetails(TableActivities.Rows[Convert.ToInt32(MenuTableRightClick.Tag)]);
                        break;
                    }
                case "UpdateExpen":
                    {
                        MonthlyExpenditure UpdateExpenditure = new MonthlyExpenditure();

                        UpdateExpenditure.txtItemNo.Text = 
                            TableActivities.Rows[Convert.ToInt32(MenuTableRightClick.Tag)].Cells[2].Value.ToString();

                        UpdateExpenditure.ComboBoxBudgetCode.Items.Clear();

                        foreach (string BudgetCode in BudgetCodeList)
                        {
                            UpdateExpenditure.ComboBoxBudgetCode.Items.Add(BudgetCode);
                        }

                        UpdateExpenditure.ComboBoxBudgetCode.SelectedItem = 
                            TableActivities.Rows[Convert.ToInt32(MenuTableRightClick.Tag)].Cells[1].Value.ToString();

                        UpdateExpenditure.btnSelectedYear.Text = btnSelectedYear.Text;

                        UpdateExpenditure.ShowDialog();

                        break;
                    }
                case "AddSub":
                    {
                        DataGridViewRow SelectedRow = TableActivities.Rows[Convert.ToInt32(MenuTableRightClick.Tag)];

                        string[] ItemNo = SelectedRow.Cells[2].Value.ToString().Split('.');

                        ExpandRows(SelectedRow, String.Format("SELECT MainActivity.BudgectCode,MainActivity.ItemNo,ActivityCode.INSub1," +
                            "ActivityCode.INSub2,SubActivity.ActivityName FROM MainActivity,ActivityCode,SubActivity " +
                            "WHERE MainActivity.ActivityID=ActivityCode.ActivityID AND " +
                            "ActivityCode.ActivityCodeID=SubActivity.ActivityCodeID AND " +
                            "MainActivity.BudgectCode='{0}' AND MainActivity.ItemNo='{1}' AND ActivityCode.INSub1='{2}'",
                            SelectedRow.Cells[1].Value.ToString().Trim(), ItemNo[0], ItemNo[1]), true);

                        TableActivities.Rows.RemoveAt(1);

                        TableActivities.Rows[TableActivities.RowCount - 1].Cells[0].Value = Properties.Resources.Empty;

                        break;
                    }
            }
        }

        private void TableActivities_SelectionChanged(object sender, EventArgs e)
        {
            if (TableActivities.SelectedRows.Count > 0)
            {
                short selectedRowIndex = Convert.ToInt16(TableActivities.SelectedRows[0].Index);

                txtActivity.Tag = selectedRowIndex;

                if (selectedRowIndex >= 0 && TableActivities.Rows[selectedRowIndex].Cells[3].Value != null)
                {
                    txtActivity.Text = TableActivities.Rows[selectedRowIndex].Cells[3].Value.ToString();
                }
                else
                {
                    txtActivity.Text = "";
                }
            }
        }

        private void txtActivity_TextChanged(object sender, EventArgs e)
        {
            TableActivities.Rows[Convert.ToInt16(txtActivity.Tag)].Cells[3].Value = txtActivity.Text.Trim();
        }

        void ExpandRows(DataGridViewRow SelectedRow, string Query, bool AllowThirdIndexNo)
        {
            InputEnabled = false;
            TableActivities.Rows.Clear();

            Guna2DataGridView TableSubActivities = new Guna2DataGridView();

            TableSubActivities.Columns.Add("BC", "BC");
            TableSubActivities.Columns.Add("IN", "IN");
            TableSubActivities.Columns.Add("Sub1", "Sub1");
            TableSubActivities.Columns.Add("Sub2", "Sub3");
            TableSubActivities.Columns.Add("Name", "Name");

            commenMethods.RetrieveDataOnDataGridView(Query, TableSubActivities, 0, 4);

            TableActivities.Rows.Add(SelectedRow);
            TableActivities.Rows[0].DefaultCellStyle.BackColor = Color.FromArgb(254, 210, 21);
            TableActivities.Rows[0].Cells[0].Value = Properties.Resources.Collapse;
            TableActivities.Rows[1].Selected = true;

            int RowNo;

            foreach (DataGridViewRow TableSubActivitiesRow in TableSubActivities.Rows)
            {
                if (TableSubActivitiesRow == TableSubActivities.Rows[TableSubActivities.Rows.Count - 1])
                {
                    break;
                }

                TableActivities.Rows.Add();
                RowNo = TableActivities.Rows.Count - 2;

                TableActivities.Rows[RowNo].Cells[0].Value = Properties.Resources.Empty;

                TableActivities.Rows[RowNo].Cells[1].Value = TableSubActivitiesRow.Cells[0].Value.ToString().Trim();

                if (TableSubActivitiesRow.Cells[3].Value == null && TableSubActivitiesRow.Cells[2].Value == null)
                {
                    TableSubActivitiesRow.Cells[1].Value = TableSubActivitiesRow.Cells[1].Value.ToString().Trim();
                }
                else if (TableSubActivitiesRow.Cells[3].Value == null)
                {
                    TableSubActivitiesRow.Cells[1].Value = TableSubActivitiesRow.Cells[1].Value.ToString().Trim() + "." +
                        TableSubActivitiesRow.Cells[2].Value.ToString().Trim();
                }
                else if (TableSubActivitiesRow.Cells[3].Value.ToString().Trim() == "")
                {
                    TableSubActivitiesRow.Cells[1].Value = TableSubActivitiesRow.Cells[1].Value.ToString().Trim() + "." +
                        TableSubActivitiesRow.Cells[2].Value.ToString().Trim();
                }
                else
                {
                    if (AllowThirdIndexNo)
                    {
                        TableSubActivitiesRow.Cells[1].Value = TableSubActivitiesRow.Cells[1].Value.ToString().Trim() + "." +
                            TableSubActivitiesRow.Cells[2].Value.ToString().Trim() + "." + TableSubActivitiesRow.Cells[3].Value.ToString().Trim();
                    }
                    else
                    {
                        int ParentRowNo = RowNo - 1;

                        for (int i = 0; i < TableActivities.Rows.Count - 1; i++)
                        {
                            if (TableActivities.Rows[i].Cells[2].Value.ToString() == 
                                TableSubActivitiesRow.Cells[1].Value.ToString() + "." + TableSubActivitiesRow.Cells[2].Value.ToString())
                            {
                                ParentRowNo = i;
                                break;
                            }
                        }

                        TableActivities.Rows[ParentRowNo].Cells[0].Value = Properties.Resources.Expand;
                        TableActivities.Rows.RemoveAt(RowNo);

                        bool ExpendableRowNoIsSaved = false;

                        foreach (int ExpendableRowNo in ExpandableRows)
                        {
                            if (ParentRowNo == ExpendableRowNo)
                            {
                                ExpendableRowNoIsSaved = true;
                                break;
                            }
                        }

                        if (!ExpendableRowNoIsSaved)
                        {
                            ExpandableRows.Add(ParentRowNo);
                        }

                        continue;
                    }
                }

                TableActivities.Rows[RowNo].Cells[2].Value = TableSubActivitiesRow.Cells[1].Value.ToString().Trim();
                TableActivities.Rows[RowNo].Cells[3].Value = TableSubActivitiesRow.Cells[4].Value.ToString().Trim();
            }

            InputEnabled = true;
        }        
    }
}
