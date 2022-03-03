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
    public partial class Expenditure : Form
    {
        public Expenditure()
        {
            InitializeComponent();
        }

        CommenMethods commenMethods = new CommenMethods();

        public int SelectedYear = DateTime.Now.Year;

        public bool ShowMessageBox = true;

        List<string> SavedData = new List<string> { };

        private void btnNavigation_Click(object sender, EventArgs e)
        {
            Guna2Button btnNavigation = (Guna2Button)sender;
            commenMethods.NavigateTo(btnNavigation.Tag.ToString());
            this.Close();
        }

        private void Expenditure_Load(object sender, EventArgs e)
        {
            TableActivities.Rows[0].Cells[2].Value = Properties.Resources.expenditure;
            TableActivities.Rows[0].Cells[3].Value = Properties.Resources.Search;

            txtBudgetCode.Top = ComboBoxBudgetCode.Top;

            if (txtItemNo.Text == "")
            {
                RefreshBudgetCode();
                ClearData();
            }
            else
            {
                txtBudgetCode.Text = ComboBoxBudgetCode.SelectedItem.ToString();
                btnSearch_Click(btnSearch, null);
            }

            btnSelectedYear.Text = SelectedYear.ToString();

            DisableOrEnableControlButtons();
        }

        public void RefreshBudgetCode()
        {
            List<string> BudgetCodeList =
               commenMethods.SQLRead(String.Format("SELECT DISTINCT BudgectCode FROM MainActivity WHERE Year='{0}'",
               SelectedYear.ToString()), "BudgectCode");

            if (BudgetCodeList != null)
            {
                txtBudgetCode.Visible = false;
                ComboBoxBudgetCode.Visible = true;

                if (BudgetCodeList.Count == 0)
                {
                    BudgetCodeList = commenMethods.SQLRead("SELECT DISTINCT BudgectCode FROM MainActivity", "BudgectCode");
                }

                ComboBoxBudgetCode.Items.Clear();
                foreach (string BudgetCode in BudgetCodeList)
                {
                    ComboBoxBudgetCode.Items.Add(BudgetCode);
                }

                ComboBoxBudgetCode.Items.Add("Other");
            }

            ComboBoxBudgetCode.SelectedIndex = 1;
        }

        private void btnSelectMonth_Click(object sender, EventArgs e)
        {
            SelectMonth form = new SelectMonth();
            form.ShowDialog();
            btnSelectedYear.Text = Convert.ToString(form.SelectedYear);
            SelectedYear = form.SelectedYear;

            RefreshBudgetCode();
        }

        private void ComboBoxBudgetCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBudgetCode.Text = ComboBoxBudgetCode.SelectedItem.ToString();

            if (txtBudgetCode.Text == "Other")
            {
                ComboBoxBudgetCode.Visible = false;
                txtBudgetCode.Visible = true;
                txtBudgetCode.Clear();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string BudgetCode = txtBudgetCode.Text.Trim();
            string[] ItemNoParts = txtItemNo.Text.Split('.');

            List<string> QueryList = new List<string> { };
            List<string> ReturnColumnsList = new List<string> { };

            ClearData();

            switch (ItemNoParts.Length)
            {
                case 1:
                    {
                        // Fill txtActivity
                        QueryList.Add(String.Format("SELECT MainActivityName FROM MainActivity " +
                            "WHERE BudgectCode='{0}' AND ItemNo='{1}' AND Year='{2}'",
                            BudgetCode, ItemNoParts[0], SelectedYear.ToString()));

                        ReturnColumnsList.Add("MainActivityName");

                        // Fill txtAllocation And txtCommitment
                        QueryList.Add(String.Format("SELECT SUM(SubActivity.Allocation) AS TotalAllocation," +
                            "SUM(SubActivity.Commitment) AS TotalCommitment " +
                            "FROM MainActivity,ActivityCode,SubActivity " +
                            "WHERE SubActivity.ActivityCodeID=ActivityCode.ActivityCodeID " +
                            "AND MainActivity.ActivityID=ActivityCode.ActivityID " +
                            "AND MainActivity.BudgectCode='{0}' " +
                            "AND MainActivity.ItemNo='{1}' " +
                            "AND MainActivity.Year='{2}'",
                            BudgetCode, ItemNoParts[0], SelectedYear.ToString()));

                        ReturnColumnsList.Add("TotalAllocation TotalCommitment");

                        /// Fill Table
                        // Find If Table is empty or not
                        QueryList.Add(String.Format("SELECT COUNT(ActivityCode.ActivityID) AS NoOfActivities " +
                            "FROM ActivityCode,MainActivity " +
                            "WHERE MainActivity.ActivityID=ActivityCode.ActivityID " +
                            "AND MainActivity.BudgectCode='{0}' " +
                            "AND MainActivity.ItemNo='{1}' " +
                            "AND ActivityCode.INSub2 IS NULL " +
                            "AND MainActivity.Year='{2}'", 
                            BudgetCode, ItemNoParts[0], SelectedYear.ToString()));

                        ReturnColumnsList.Add("NoOfActivities");

                        // Find details of sub activities for fill table
                        QueryList.Add(String.Format("SELECT ActivityCode.INSub1,SubActivity.ActivityName " +
                            "FROM ActivityCode,MainActivity,SubActivity " +
                            "WHERE MainActivity.ActivityID=ActivityCode.ActivityID " +
                            "AND SubActivity.ActivityCodeID=ActivityCode.ActivityCodeID " +
                            "AND MainActivity.BudgectCode='{0}' " +
                            "AND MainActivity.ItemNo='{1}' " +
                            "AND ActivityCode.INSub2 IS NULL " +
                            "AND MainActivity.Year='{2}'",
                            BudgetCode, ItemNoParts[0], SelectedYear.ToString()));

                        ReturnColumnsList.Add("INSub1 ActivityName");

                        break;
                    }
                case 2:
                    {
                        // Fill txtActivity
                        QueryList.Add(String.Format("SELECT SubActivity.ActivityName,SubActivity.Allocation,SubActivity.Commitment " +
                            "FROM SubActivity,ActivityCode,MainActivity " +
                            "WHERE SubActivity.ActivityCodeID=ActivityCode.ActivityCodeID " +
                            "AND ActivityCode.ActivityID=MainActivity.ActivityID " +
                            "AND MainActivity.BudgectCode='{0}' " +
                            "AND MainActivity.ItemNo='{1}' " +
                            "AND ActivityCode.INSub1='{2}' " +
                            "AND ActivityCode.INSub2 IS NULL " +
                            "AND MainActivity.Year='{3}'",
                            BudgetCode, ItemNoParts[0], ItemNoParts[1], SelectedYear.ToString()));

                        ReturnColumnsList.Add("ActivityName");

                        // Fill txtAllocation And txtCommitment
                        QueryList.Add(String.Format("SELECT SUM(SubActivity.Allocation) AS TotalAllocation," +
                            "SUM(SubActivity.Commitment) AS TotalCommitment " +
                            "FROM SubActivity,ActivityCode,MainActivity " +
                            "WHERE SubActivity.ActivityCodeID=ActivityCode.ActivityCodeID " +
                            "AND ActivityCode.ActivityID=MainActivity.ActivityID " +
                            "AND MainActivity.BudgectCode='{0}' " +
                            "AND MainActivity.ItemNo='{1}' " +
                            "AND ActivityCode.INSub1='{2}' " +
                            "AND MainActivity.Year='{3}'",
                            BudgetCode, ItemNoParts[0], ItemNoParts[1], SelectedYear.ToString()));                        

                        ReturnColumnsList.Add("TotalAllocation TotalCommitment");

                        /// Fill Table
                        // Find Main Activity for table
                        QueryList.Add(String.Format("SELECT DISTINCT MainActivity.MainActivityName " +
                            "FROM ActivityCode,MainActivity " +
                            "WHERE MainActivity.ActivityID=ActivityCode.ActivityID " +
                            "AND MainActivity.BudgectCode='{0}' " +
                            "AND MainActivity.ItemNo='{1}' " +
                            "AND MainActivity.Year='{2}'",
                            BudgetCode, ItemNoParts[0], SelectedYear.ToString()));

                        ReturnColumnsList.Add("MainActivityName");

                        // Find If Table is empty or not
                        QueryList.Add(String.Format("SELECT COUNT(ActivityCode.ActivityID) AS NoOfActivities " +
                            "FROM ActivityCode,MainActivity " +
                            "WHERE MainActivity.ActivityID=ActivityCode.ActivityID " +
                            "AND MainActivity.BudgectCode='{0}' " +
                            "AND MainActivity.ItemNo='{1}' " +
                            "AND ActivityCode.INSub1='{2}' " +
                            "AND ActivityCode.INSub2 IS NOT NULL " +
                            "AND MainActivity.Year='{3}'",
                            BudgetCode, ItemNoParts[0], ItemNoParts[1], SelectedYear.ToString()));

                        ReturnColumnsList.Add("NoOfActivities");

                        // Find details of sub activities for fill table
                        QueryList.Add(String.Format("SELECT ActivityCode.INSub2,SubActivity.ActivityName " +
                            "FROM ActivityCode,MainActivity,SubActivity " +
                            "WHERE MainActivity.ActivityID=ActivityCode.ActivityID " +
                            "AND SubActivity.ActivityCodeID=ActivityCode.ActivityCodeID " +
                            "AND MainActivity.BudgectCode='{0}' " +
                            "AND MainActivity.ItemNo='{1}' " +
                            "AND ActivityCode.INSub1='{2}' " +
                            "AND MainActivity.Year='{3}' " +
                            "AND ActivityCode.INSub2 IS NOT NULL",
                            BudgetCode, ItemNoParts[0], ItemNoParts[1], SelectedYear.ToString()));

                        ReturnColumnsList.Add("INSub2 ActivityName");                        

                        break;
                    }
                case 3:
                    {
                        // Fill txtActitivty, txtAllocation And txtCommitment
                        QueryList.Add(String.Format("SELECT SubActivity.ActivityName,SubActivity.Allocation,SubActivity.Commitment " +
                            "FROM SubActivity,ActivityCode,MainActivity " +
                            "WHERE SubActivity.ActivityCodeID=ActivityCode.ActivityCodeID " +
                            "AND ActivityCode.ActivityID=MainActivity.ActivityID " +
                            "AND MainActivity.BudgectCode='{0}' " +
                            "AND MainActivity.ItemNo='{1}' " +
                            "AND ActivityCode.INSub1='{2}' " +
                            "AND ActivityCode.INSub2='{3}' " +
                            "AND MainActivity.Year='{4}'",
                            BudgetCode, ItemNoParts[0], ItemNoParts[1], ItemNoParts[2], SelectedYear.ToString()));

                        ReturnColumnsList.Add("ActivityName Allocation Commitment");

                        // Find Main Activity
                        QueryList.Add(String.Format("SELECT MainActivity.MainActivityName,SubActivity.ActivityName " +
                            "FROM ActivityCode,MainActivity,SubActivity " +
                            "WHERE MainActivity.ActivityID=ActivityCode.ActivityID " +
                            "AND SubActivity.ActivityCodeID=ActivityCode.ActivityCodeID " +
                            "AND MainActivity.BudgectCode='{0}' " +
                            "AND MainActivity.ItemNo='{1}' " +
                            "AND ActivityCode.INSub1='{2}' " +
                            "AND ActivityCode.INSub2 IS NULL " +
                            "AND MainActivity.Year='{3}'",
                            BudgetCode, ItemNoParts[0], ItemNoParts[1], SelectedYear.ToString()));

                        ReturnColumnsList.Add("MainActivityName ActivityName");

                        break;
                    }
            }

            if (QueryList.Count > 0 && ReturnColumnsList.Count > 0)
            {
                List<string> ReturnList;

                for (int i = 0; i < QueryList.Count; i++) 
                {
                    ReturnList = commenMethods.SQLRead(QueryList[i], ReturnColumnsList[i]);

                    if (ReturnList != null)
                    {
                        if (ReturnList.Count >= 1) 
                        {
                            if (ItemNoParts.Length == 3)
                            {                                
                                if (i == 0)
                                {
                                    txtActivity.Text = ReturnList[0].Trim();
                                    txtAllocation.Text = ReturnList[1].Trim();
                                    txtCommitment.Text = ReturnList[2].Trim();                                    
                                }
                                else
                                {
                                    // Main Activity
                                    int n = TableActivities.Rows.Add();
                                    TableActivities.Rows[n].Cells[1].Value = ReturnList[0];
                                    TableActivities.Rows[n].Cells[0].Value = ItemNoParts[0];

                                    // Sub MainActivity
                                    n = TableActivities.Rows.Add();
                                    TableActivities.Rows[n].Cells[1].Value = ReturnList[1];
                                    TableActivities.Rows[n].Cells[0].Value = ItemNoParts[0] + "." + ItemNoParts[1];

                                    TableActivities.Rows[n - 1].DefaultCellStyle.BackColor = 
                                        TableActivities.Rows[n].DefaultCellStyle.BackColor = Color.FromArgb(254, 210, 21);
                                }
                            }
                            else
                            {
                                if (i == 0)
                                {
                                    txtActivity.Text = ReturnList[0].Trim();
                                }
                                else if (i == 1)
                                {
                                    txtAllocation.Text = ReturnList[0].Trim();
                                    txtCommitment.Text = ReturnList[1].Trim();
                                }
                                else
                                {
                                    if (ItemNoParts.Length < 3)
                                    {
                                        if (ItemNoParts.Length > 1)
                                        {
                                            if (i == 2)
                                            {
                                                int n = TableActivities.Rows.Add();
                                                TableActivities.Rows[n].Cells[1].Value = ReturnList[0];
                                                TableActivities.Rows[n].Cells[0].Value = ItemNoParts[0];

                                                TableActivities.Rows[n].DefaultCellStyle.BackColor = Color.FromArgb(254, 210, 21);
                                            }
                                            else if (i == 3)
                                            {
                                                if (Convert.ToInt32(ReturnList[0].Trim()) <= 0)
                                                {
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                FillTableFormList();
                                            }
                                        }
                                        else
                                        {
                                            if (i == 2)
                                            {
                                                if (Convert.ToInt32(ReturnList[0].Trim()) <= 0)
                                                {
                                                    break;
                                                }
                                            }                                            
                                            else
                                            {
                                                FillTableFormList();
                                            }
                                        }
                                    }
                                }                                
                            }
                        }
                        else
                        {
                            MessageBox.Show("Can't Find Activities for your search", "Something went wrong",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                            break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong", "Error Found",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        break;

                    }
                }

                TableActivities.Rows[0].Selected = false;

                UpdatePrecentageChart(ItemNoParts, BudgetCode);
                commenMethods.UpdateChart(ItemNoParts, BudgetCode, SelectedYear.ToString(), txtAllocation.Text, ChartExpenditure, NotificationPaintUpdateExpenditure);

                void FillTableFormList()
                {
                    if (ReturnList[0].Trim() != "0")
                    {
                        int n;

                        for (int j = 0; j < ReturnList.Count; j += 2)
                        {
                            n = TableActivities.Rows.Add();

                            TableActivities.Rows[n].Cells[0].Value = txtItemNo.Text.Trim() + "." + ReturnList[j];
                            TableActivities.Rows[n].Cells[1].Value = ReturnList[j + 1].Trim();
                        }
                    }                    
                }
            }
            else
            {
                MessageBox.Show("Invalid Item No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtBudgetCode.Visible = false;
            ComboBoxBudgetCode.Visible = true;

            NotificationPaintNeedUpdate.Visible = false;

            SavedData = new List<string> { txtActivity.Text, txtAllocation.Text, txtCommitment.Text };            
        }

        void UpdatePrecentageChart(string[] ItemNoParts, string BudgetCode)
        {
            if (txtAllocation.Text.Trim() != "" && ItemNoParts.Length > 0 && BudgetCode.Trim() != "") 
            {
                string Query = String.Format("SELECT SUM(ExpenditureMonth.Expenditure) AS TotalExpenditure " +
                    "FROM ExpenditureMonth,ActivityCode,MainActivity " +
                    "WHERE ExpenditureMonth.ActivityCodeID=ActivityCode.ActivityCodeID " +
                    "AND MainActivity.ActivityID=ActivityCode.ActivityID " +
                    "AND MainActivity.BudgectCode='{0}' " +
                    "AND MainActivity.ItemNo='{1}' " +
                    "AND MainActivity.Year='{2}'",
                    BudgetCode, ItemNoParts[0], btnSelectedYear.Text);

                if (ItemNoParts.Length >= 2)
                {
                    Query += String.Format(" AND ActivityCode.INSub1='{0}'", ItemNoParts[1]);
                }

                if (ItemNoParts.Length == 3)
                {
                    Query += String.Format(" AND ActivityCode.INSub2='{0}'", ItemNoParts[2]);
                }

                List<string> ReturnValue = commenMethods.SQLRead(Query, "TotalExpenditure");

                if (ReturnValue != null)
                {
                    if (ReturnValue.Count > 0)
                    {
                        if (ReturnValue[0].Trim() != "")
                        {
                            float CumulativeExpenditure = float.Parse(ReturnValue[0].Trim());
                            float Allocation = float.Parse(txtAllocation.Text.Trim().Replace(",", ""));
                            float Commitment = 0;

                            if (txtCommitment.Text.Trim() != "")
                            {
                                Commitment = float.Parse(txtCommitment.Text.Trim().Replace(",", ""));
                            }

                            if (Allocation != 0)
                            {
                                float Progress = ((CumulativeExpenditure + Commitment) / Allocation) * 100;

                                if (Progress <= 100)
                                {
                                    PrecentageProgressBar.Maximum = 100;
                                    PrecentageProgressBar.Value = Convert.ToInt32(Progress);
                                }
                                else
                                {
                                    PrecentageProgressBar.Maximum = Convert.ToInt32(Progress);
                                    PrecentageProgressBar.Value = Convert.ToInt32(Progress);
                                }
                            }
                        }
                    }
                }
            }
        }

        void ClearData()
        {
            txtActivity.Clear();
            txtAllocation.Clear();
            txtCommitment.Clear();

            TableActivities.Rows.Clear();

            PrecentageProgressBar.Value = 0;

            TableActivities.Rows[0].Cells[2].Value = Properties.Resources.expenditure;
            TableActivities.Rows[0].Cells[3].Value = Properties.Resources.Search;

            ChartExpenditure.Series[0].Points.Clear();
            ChartExpenditure.Series[1].Points.Clear();

            NotificationPaintUpdateExpenditure.Visible = false;
            NotificationPaintNeedUpdate.Visible = false;

            SavedData = new List<string> { };

            lblAllocation.Text = "Allocation";
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            Guna2TextBox textBox = (Guna2TextBox)sender;

            if (textBox.Text.Length <= 0 && textBox.Name == txtBudgetCode.Name)
            {
                txtBudgetCode.Visible = true;
                ComboBoxBudgetCode.Visible = false;
            }

            if (textBox.Name == txtItemNo.Name)
            {
                commenMethods.FilterOnlyInt(txtItemNo, 2, false, 0);

                DisableOrEnableControlButtons();
            }
            else if (textBox.Name == txtBudgetCode.Name)
            {
                commenMethods.FilterOnlyInt(txtBudgetCode, 0, false, 0);
            }
        }

        void DisableOrEnableControlButtons()
        {
            if (txtItemNo.Text.Trim() == "")
            {
                btnSearch.Enabled = btnReportQ.Enabled = btnUpdate.Enabled =
                    btnExpenditure.Enabled = btnDelete.Enabled = false;
            }
            else
            {
                btnSearch.Enabled = btnReportQ.Enabled = btnUpdate.Enabled =
                    btnExpenditure.Enabled = btnDelete.Enabled = true;
            }
        }

        private void TableActivities_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow SelectedRow = TableActivities.Rows[e.RowIndex];

            if ((SelectedRow.Cells[0].Value != null && SelectedRow.Cells[0].Value.ToString().Trim() != ""))
            {
                if (e.ColumnIndex == 3)
                {
                    txtItemNo.Text = SelectedRow.Cells[0].Value.ToString().Trim();
                    btnSearch_Click(btnSearch, null);
                }
                else if (e.ColumnIndex == 2)
                {
                    ShowMonthlyExpenditureProgress(SelectedRow.Cells[0].Value.ToString().Trim());
                }
            }            
        }

        private void btnExpenditure_Click(object sender, EventArgs e)
        {
            ShowMonthlyExpenditureProgress(txtItemNo.Text);
        }

        void ShowMonthlyExpenditureProgress(string ItemNo)
        {
            MonthlyExpenditure UpdateExpenditureForm = new MonthlyExpenditure();

            UpdateExpenditureForm.btnSelectedYear.Text = btnSelectedYear.Text;
            UpdateExpenditureForm.txtItemNo.Text = ItemNo;
            UpdateExpenditureForm.btnSelectMonth.Text = commenMethods.MonthList[DateTime.Now.Month - 1];

            UpdateExpenditureForm.ComboBoxBudgetCode.Items.Clear();

            foreach (string BudgetCode in ComboBoxBudgetCode.Items)
            {
                UpdateExpenditureForm.ComboBoxBudgetCode.Items.Add(BudgetCode);
            }
            UpdateExpenditureForm.ComboBoxBudgetCode.Items.RemoveAt(UpdateExpenditureForm.ComboBoxBudgetCode.Items.Count - 1);
            UpdateExpenditureForm.ComboBoxBudgetCode.SelectedIndex = ComboBoxBudgetCode.SelectedIndex;

            UpdateExpenditureForm.ShowDialog();
            UpdateExpenditureForm.Close();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            Guna2TextBox SelectedTextBox = (Guna2TextBox)sender;
            SelectedTextBox.Text = commenMethods.SaveOnlyIntegers(SelectedTextBox.Text);

            ShowUpdateNotification(SelectedTextBox);

            if (txtAllocation.Text.Trim() == "")
            {
                lblAllocation.Text = "<b><font color='red'> Allocation  ! <font>";
            }

            if (SelectedTextBox.Name == txtAllocation.Name) 
            {
                btnAllocation.Enabled = true;

                if (txtAllocation.Text == "")
                {
                    btnAllocation.Enabled = false;
                }
                else if (Convert.ToInt32(txtAllocation.Text) == 0)
                {
                    btnAllocation.Enabled = false;
                }
                else if (NotificationPaintNeedUpdate.Visible && SavedData.Count > 0)
                {
                    btnAllocation.Enabled = false;
                }
            }
        }

        private void txtActivity_TextChanged(object sender, EventArgs e)
        {
            ShowUpdateNotification(txtActivity);
        }

        void ShowUpdateNotification(Guna2TextBox SelectedTextBox)
        {
            NotificationPaintNeedUpdate.Visible = true;
            if (SavedData.Count == 3)
            {
                if (SavedData[Convert.ToInt32(SelectedTextBox.Tag.ToString())] == SelectedTextBox.Text)
                {
                    NotificationPaintNeedUpdate.Visible = false;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string BudgetCode = txtBudgetCode.Text.Trim(),
                Allocation = txtAllocation.Text.Trim();

            string[] ItemNoParts = txtItemNo.Text.Split('.');

            if (ItemNoParts.Length > 0 && BudgetCode != "")  
            {
                if (Allocation == "" && ItemNoParts.Length > 1 && TableActivities.Rows.Count <= 2) 
                {
                    if (MessageBox.Show("Can't calculate progress without allocation, Do you want to update without Allocation",
                        "Input Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        UpdateDatabase();
                    }
                }
                else
                {
                    UpdateDatabase();
                }

                btnSearch_Click(btnSearch, null);
            }
            else
            {
                MessageBox.Show("Enter All Required Field", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            void UpdateDatabase()
            {
                string Query;

                if (ItemNoParts.Length > 1)
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

                    List<string> ActivatyCodeID = commenMethods.SQLRead(Query, "ActivityCodeID");

                    if (!commenMethods.ReturnListHasError(ActivatyCodeID))
                    {
                        if (ItemNoParts.Length == 2 && TableActivities.Rows.Count > 2)
                        {
                            Query = String.Format("UPDATE SubActivity " +
                               "SET ActivityName=N'{0}' WHERE ActivityCodeID='{1}'",
                               txtActivity.Text.Trim().Replace("'", " "), ActivatyCodeID[0]);
                        }
                        else
                        {
                            Query = String.Format("UPDATE SubActivity " +
                               "SET ActivityName=N'{0}',Allocation='{1}',Commitment='{2}' WHERE ActivityCodeID='{3}'",
                               txtActivity.Text.Trim().Replace("'", " "), Allocation.Replace(",", ""),
                               txtCommitment.Text.Trim().Replace(",", ""), ActivatyCodeID[0]);
                        }

                        ExecuteQuery();
                    }
                    else
                    {
                        MessageBox.Show("Something Went Wrong. Can't update Database", "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (TableActivities.Rows.Count > 2)
                    {
                        Query = String.Format("UPDATE MainActivity SET MainActivityName=N'{0}' " +
                            "WHERE MainActivity.BudgectCode='{1}' AND MainActivity.ItemNo='{2}' AND MainActivity.Year='{3}'",
                            txtActivity.Text.Trim().Replace("'", " "), BudgetCode, ItemNoParts[0], btnSelectedYear.Text);

                        ExecuteQuery();
                    }
                    else
                    {
                        Query = String.Format("SELECT ActivityCode.ActivityCodeID " +
                            "FROM ActivityCode,MainActivity " +
                            "WHERE MainActivity.ActivityID=ActivityCode.ActivityID " +
                            "AND MainActivity.BudgectCode='{0}' AND MainActivity.ItemNo='{1}' " +
                            "AND MainActivity.Year='{2}' AND ActivityCode.INSub1='0'",
                            BudgetCode, ItemNoParts[0], btnSelectedYear.Text);

                        List<string> ActivatyCodeID = commenMethods.SQLRead(Query, "ActivityCodeID");

                        if (!commenMethods.ReturnListHasError(ActivatyCodeID))
                        {
                            Query = String.Format("UPDATE SubActivity " +
                               "SET Allocation='{0}',Commitment='{1}' WHERE ActivityCodeID='{2}'",
                               Allocation.Replace(",", ""), txtCommitment.Text.Trim().Replace(",", ""), ActivatyCodeID[0]);

                            ExecuteQuery();
                        }
                        else
                        {
                            MessageBox.Show("Something Went Wrong. Can't update Database", "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }

                void ExecuteQuery()
                {
                    if (commenMethods.ExecuteSQL(Query))
                    {
                        MessageBox.Show("Updated Successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NotificationPaintNeedUpdate.Visible = false;
                    }
                    else
                    {
                        commenMethods.UpdateErrorMessageShow();
                    }
                }
                
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string BudgetCode = txtBudgetCode.Text.Trim();
            string[] ItemNoParts = txtItemNo.Text.Split('.');

            if (ItemNoParts.Length > 0 && BudgetCode != "" && txtActivity.Text.Trim() != "")
            {
                // Search selected activity currntly exists in database

                string QueryFindActivityCodID = String.Format("SELECT COUNT(ActivityCode.ActivityCodeID) AS NoOfActivityCodeID " +
                    "FROM ActivityCode,MainActivity " +
                    "WHERE MainActivity.ActivityID=ActivityCode.ActivityID " +
                    "AND MainActivity.Year='{0}' " +
                    "AND MainActivity.BudgectCode='{1}' " +
                    "AND MainActivity.ItemNo='{2}'",
                    btnSelectedYear.Text, ComboBoxBudgetCode.SelectedItem.ToString(), ItemNoParts[0]);
                
                if (ItemNoParts.Length == 2)
                {
                    QueryFindActivityCodID +=
                        String.Format(" AND ActivityCode.INSub1='{0}' AND (ActivityCode.INSub2 IS NULL)", ItemNoParts[1]);
                }
                else if (ItemNoParts.Length == 3)
                {
                    QueryFindActivityCodID +=
                        String.Format(" AND ActivityCode.INSub1='{0}' AND ActivityCode.INSub2='{1}'", ItemNoParts[1], ItemNoParts[2]);
                }

                List<string> ActivityCodeCount = commenMethods.SQLRead(QueryFindActivityCodID, "NoOfActivityCodeID");

                if (commenMethods.ReturnListHasError(ActivityCodeCount))
                {
                    // Has error to find selected database
                    commenMethods.UpdateErrorMessageShow();
                   
                }
                else if (ActivityCodeCount[0].Trim() == "0")
                {
                    SaveNewActivity(BudgetCode, ItemNoParts); // selected acitivity not exist in database
                }
                else // selected activity exists in database
                {
                    MessageBox.Show("Selected Budget Code and Item No is currently exists in database." +
                        " Please change Budget Code and Item No.", "Input Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }                
            }
            else
            {
                MessageBox.Show("Enter Activity Name and Allocation before save.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SaveNewActivity(string BudgetCode, string[] ItemNoParts) // add to database
        {
            if (ItemNoParts.Length == 1) // Item No Like 2
            {
                // Find Last ActivityID form MainActivity Table
                string ActivityID = (Convert.ToInt32(commenMethods.SQLRead(
                    "SELECT MAX(ActivityID) AS LastActivityID FROM MainActivity", "LastActivityID")[0]) + 1).ToString();

                // Find Last ActivityCodeID form ActivityCode Table
                string ActivityCodeID = (Convert.ToInt32(commenMethods.SQLRead("SELECT MAX(ActivityCodeID) AS LastActivityCodeID " +
                        "FROM ActivityCode", "LastActivityCodeID")[0]) + 1).ToString();

                List<string> QueryList = new List<string>
                        {
                            String.Format(
                                "INSERT INTO MainActivity (ActivityID,BudgectCode,ItemNo,MainActivityName,Year) " +
                                "VALUES ('{0}',N'{1}','{2}','{3}','{4}')",
                                ActivityID, BudgetCode, ItemNoParts[0],
                                txtActivity.Text.Trim().Replace(",", ""), btnSelectedYear.Text), // Update MainActivity

                            String.Format(
                                "INSERT INTO ActivityCode (ActivityCodeID,ActivityID,INSub1) " +
                                "VALUES ('{0}','{1}','{2}')", ActivityCodeID, ActivityID, 0), // Update ActivityCode

                            String.Format(
                                "INSERT INTO SubActivity (ActivityCodeID,ActivityName,Allocation,Commitment) " +
                                "VALUES ('{0}',N'{1}','{2}','{3}')",
                                ActivityCodeID, "-", txtAllocation.Text.Replace(",",""), txtCommitment.Text.Replace(",","")) // Update SubActivity
                        };

                bool ErrorFound = false;

                foreach (string Query in QueryList)
                {
                    if (!commenMethods.ExecuteSQL(Query))
                    {
                        // Error Found
                        commenMethods.UpdateErrorMessageShow();
                        ErrorFound = true;

                        break;
                    }
                }

                if (!ErrorFound && ShowMessageBox)
                {
                    MessageBox.Show("Activity successfully add to database", "Added Successfully",
                        MessageBoxButtons.OK, MessageBoxIcon.Information); // Complete saving
                }
            }
            else if (ItemNoParts.Length == 2) // Item No Like 2.2
            {
                List<string> ReturnValue = commenMethods.SQLRead(String.Format(
                    "SELECT ActivityID FROM MainActivity " +
                    "WHERE BudgectCode='{0}' AND ItemNo='{1}' AND Year='{2}'",
                    BudgetCode, ItemNoParts[0], btnSelectedYear.Text), "ActivityID"); // Find ActivityID

                if (!commenMethods.ReturnListHasError(ReturnValue))
                {
                    string ActivityID = ReturnValue[0].Trim();

                    string ActivityCodeID = commenMethods.SQLRead("SELECT MAX(ActivityCodeID) AS LastActivityCodeID " +
                        "FROM ActivityCode", "LastActivityCodeID")[0]; // Find Last ActivityCodeID form ActivityCode Table

                    // Find has Main activity and INSub1 is 0
                    ReturnValue = commenMethods.SQLRead(String.Format(
                        "SELECT ActivityCodeID FROM ActivityCode " +
                        "WHERE ActivityID='{0}' AND INSub1='0'", ActivityID), "ActivityCodeID");

                    if (!commenMethods.ReturnListHasError(ReturnValue))
                    {
                        // remove current data on database
                        commenMethods.ExecuteSQL(String.Format("DELETE FROM SubActivity WHERE ActivityCodeID='{0}'", ReturnValue[0]));
                        commenMethods.ExecuteSQL(String.Format("DELETE FROM ExpenditureMonth WHERE ActivityCodeID='{0}'", ReturnValue[0]));
                        commenMethods.ExecuteSQL(String.Format("DELETE FROM ActivityCode WHERE ActivityCodeID='{0}'", ReturnValue[0]));
                    }

                    // Activity Add to database
                    if (commenMethods.ExecuteSQL(String.Format(
                        "INSERT INTO ActivityCode (ActivityCodeID,ActivityID,INSub1) " +
                        "VALUES ('{0}','{1}','{2}')", Convert.ToInt32(ActivityCodeID) + 1, ActivityID, ItemNoParts[1])))
                    {
                        AddToSubActivity(ActivityCodeID);
                    }
                    else
                    {
                        commenMethods.UpdateErrorMessageShow();
                    }
                }
                else
                {
                    MessageBox.Show("First you should add main activity.", "Input Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else // Item No Like 2.2.3
            {
                // Find ActivityID
                List<string> ReturnValue = commenMethods.SQLRead(String.Format(
                    "SELECT ActivityID FROM MainActivity " +
                    "WHERE BudgectCode='{0}' AND ItemNo='{1}' AND Year='{2}'",
                    BudgetCode, ItemNoParts[0], btnSelectedYear.Text), "ActivityID");

                if (!commenMethods.ReturnListHasError(ReturnValue))
                {
                    string ActivityID = ReturnValue[0].Trim(); // ActivityID Of Main acivity

                    // Find ActivityCodeID
                    ReturnValue = commenMethods.SQLRead(String.Format(
                        "SELECT ActivityCodeID FROM ActivityCode " +
                        "WHERE ActivityID='{0}' AND INSub1='{1}'", ActivityID, ItemNoParts[1]), "ActivityCodeID");

                    if (!commenMethods.ReturnListHasError(ReturnValue))
                    {
                        string ParentActivityCodeID = ReturnValue[0].Trim(); // ActivityCodeID Of Parent activity 

                        // Find Last ActivityCodeID form ActivityCode Table
                        string ActivityCodeID = commenMethods.SQLRead("SELECT MAX(ActivityCodeID) AS LastActivityCodeID " +
                            "FROM ActivityCode", "LastActivityCodeID")[0];

                        if (!commenMethods.ReturnListHasError(ReturnValue))
                        {
                            // remove current data on database
                            commenMethods.ExecuteSQL(String.Format("UPDATE SubActivity SET Allocation='0',Commitment='0' WHERE ActivityCodeID='{0}'", ParentActivityCodeID));
                            commenMethods.ExecuteSQL(String.Format("DELETE FROM ExpenditureMonth WHERE ActivityCodeID='{0}'", ParentActivityCodeID));
                        }

                        // Activity Add to database
                        if (commenMethods.ExecuteSQL(String.Format(
                            "INSERT INTO ActivityCode (ActivityCodeID,ActivityID,INSub1,INSub2) " +
                            "VALUES ('{0}','{1}','{2}','{3}')", Convert.ToInt32(ActivityCodeID) + 1, ActivityID, ItemNoParts[1], ItemNoParts[2])))
                        {
                            AddToSubActivity(ActivityCodeID);
                        }
                        else
                        {
                            commenMethods.UpdateErrorMessageShow();
                        }
                    }
                    else
                    {
                        MessageBox.Show("First you should add main activity.", "Input Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("First you should add main activity.", "Input Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            void AddToSubActivity(string ActivityCodeID)
            {
                if (commenMethods.ExecuteSQL(String.Format(
                    "INSERT INTO SubActivity (ActivityCodeID,ActivityName,Allocation,Commitment) " +
                    "VALUES ('{0}',N'{1}','{2}','{3}')",
                    Convert.ToInt32(ActivityCodeID) + 1, txtActivity.Text.Trim().Replace(",", ""),
                    txtAllocation.Text.Replace(",", ""), txtCommitment.Text.Replace(",", ""))))
                {
                    MessageBox.Show("Activity successfully add to database", "Added Successfully",
                        MessageBoxButtons.OK, MessageBoxIcon.Information); // Complete saving
                }
                else
                {
                    commenMethods.UpdateErrorMessageShow();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string BudgetCode = txtBudgetCode.Text.Trim();
            string[] ItemNoParts = txtItemNo.Text.Split('.');

            if (MessageBox.Show("Do you want to delete selected activity.", "Conform Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes 
                && ItemNoParts.Length > 0 && BudgetCode != "") 
            {
                // Search selected activity currntly exists in database

                string QueryFindActivityCodeID = String.Format("SELECT ActivityCode.ActivityCodeID,ActivityCode.ActivityID " +
                    "FROM ActivityCode,MainActivity " +
                    "WHERE MainActivity.ActivityID=ActivityCode.ActivityID " +
                    "AND MainActivity.Year='{0}' " +
                    "AND MainActivity.BudgectCode='{1}' " +
                    "AND MainActivity.ItemNo='{2}'",
                    btnSelectedYear.Text, ComboBoxBudgetCode.SelectedItem.ToString(), ItemNoParts[0]);

                if (ItemNoParts.Length == 2)
                {
                    QueryFindActivityCodeID +=
                        String.Format(" AND ActivityCode.INSub1='{0}' AND (ActivityCode.INSub2 IS NULL)", ItemNoParts[1]);
                }
                else if (ItemNoParts.Length == 3)
                {
                    QueryFindActivityCodeID +=
                        String.Format(" AND ActivityCode.INSub1='{0}' AND ActivityCode.INSub2='{1}'", ItemNoParts[1], ItemNoParts[2]);
                }

                List<string> Activities = commenMethods.SQLRead(QueryFindActivityCodeID, "ActivityCodeID ActivityID");

                if (commenMethods.ReturnListHasError(Activities))
                {
                    // Has error to find selected database

                    MessageBox.Show("Can't Find Activities for your search", "Something went wrong",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else // selected activity exists in database
                {
                    string ActivityID = Activities[1];
                    // Find All ActivityCodeIDs From database
                    Activities = commenMethods.SQLRead(String.Format("SELECT ActivityCodeID FROM ActivityCode WHERE ActivityID='{0}'", ActivityID), "ActivityCodeID");

                    if (!commenMethods.ReturnListHasError(Activities))
                    {
                        // Delete all form SubActivities
                        for (int i = 0; i < Activities.Count; i++) 
                        {
                            commenMethods.ExecuteSQL(String.Format("DELETE FROM ExpenditureMonth WHERE ActivityCodeID='{0}'", Activities[i]));
                            commenMethods.ExecuteSQL(String.Format("DELETE FROM SubActivity WHERE ActivityCodeID='{0}'", Activities[i]));
                        }

                        // Delete All data from ActivityCode
                        commenMethods.ExecuteSQL(String.Format("DELETE FROM ActivityCode WHERE ActivityID='{0}'", ActivityID));

                        // Delete all form MainActivity
                        if (commenMethods.ExecuteSQL(String.Format(
                            "DELETE FROM MainActivity WHERE ActivityID='{0}' AND MainActivity.Year='{1}'", ActivityID, btnSelectedYear.Text))) 
                        {
                            // complete message
                            MessageBox.Show("Data removed successfully", "Successfully Removed",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            // error found
                            MessageBox.Show("Can't remove data form database", "Something went wrong",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void PrecentageProgressBar_ValueChanged(object sender, EventArgs e)
        {
            lblPrecentage.Text = PrecentageProgressBar.Value + "%";
        }

        private void btnAllocation_Click(object sender, EventArgs e)
        {
            Allocation form = new Allocation();

            form.currentAllocation = Convert.ToDecimal(commenMethods.SaveOnlyIntegers(txtAllocation.Text));
            form.txtAllocation.Text = txtAllocation.Text;
            form.txtBudgetCode.Text = txtBudgetCode.Text;
            form.txtItemNo.Text = txtItemNo.Text;
            form.selectedYear = Convert.ToInt16(btnSelectedYear.Text);

            form.ShowDialog();
        }

        private void TableActivities_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btnAllocation.Enabled = true;
            string[] ItemNoParts = txtItemNo.Text.Split('.');

            if (txtAllocation.Text == "")
            {
                btnAllocation.Enabled = false;
            }
            else if (Convert.ToInt32(txtAllocation.Text) == 0)
            {
                btnAllocation.Enabled = false;
            }            
            else if (TableActivities.Rows.Count > 2 && ItemNoParts.Length <= 2)
            {
                btnAllocation.Enabled = false;
            }
        }

        private void btnReportQ_Click(object sender, EventArgs e)
        {
            QuarterWiseReport QReport = new QuarterWiseReport();

            QReport.txtSelectedYear.Text = btnSelectedYear.Text;
            QReport.txtBudgetCode.Text = txtBudgetCode.Text;
            QReport.txtItemNo.Text = txtItemNo.Text;
            QReport.txtActivity.Text = txtActivity.Text;
            QReport.ActivityProgressBar.Maximum = PrecentageProgressBar.Maximum;
            QReport.ActivityProgressBar.Value = PrecentageProgressBar.Value;
            QReport.txtAllocation.Text = txtAllocation.Text;
            QReport.btnAllocation.Enabled = btnAllocation.Enabled;
            QReport.selectedYear = Convert.ToInt16(SelectedYear);
            QReport.commitment = Convert.ToDecimal(commenMethods.SaveOnlyIntegers(txtCommitment.Text));

            QReport.ShowDialog();
        }
    }
}
