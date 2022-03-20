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
    public partial class MonthlyExpenditure : Form
    {
        public MonthlyExpenditure()
        {
            InitializeComponent();
        }

        CommenMethods commenMethods = new CommenMethods();
        int SelectedMonth = 0;
        string SavedExpenditure = "";

        private void MonthlyExpenditure_Load(object sender, EventArgs e)
        {
            ChangeExpenditureValues();
            TableActivities.Rows.Clear();

            if (txtItemNo.Text != "" && ComboBoxBudgetCode.SelectedIndex >= 0)
            {
                btnSearch_Click(btnSearch, null);
            }
        }

        void ChangeExpenditureValues()
        {
            for (int i = 1; i <= 12; i++) 
            {
                if (commenMethods.MonthList[i - 1] == btnSelectMonth.Text) 
                {
                    SelectedMonth = i;
                    break;
                }
            }

            if (SelectedMonth == 2 || SelectedMonth == 1)
            {
                lblCumulativeExp.Text = "Cumulative Exp. (JAN)";
            }
            else
            {
                lblCumulativeExp.Text = string.Format("Cumulative Exp. (JAN - {0})",
                    commenMethods.MonthList[SelectedMonth - 2]);
            }

            lblExpenditure.Text = string.Format("Expenditure For {0} {1}",
                btnSelectedYear.Text, btnSelectMonth.Text);

            SavedExpenditure = "";
            NotificationPaintNeedUpdate.Visible = false;
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

                if (txtItemNo.Text.Trim() != "")
                    ShowActivityDetails();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowActivityDetails();
            SavedExpenditure = txtExpenditure.Text;
        }

        void ShowActivityDetails()
        {
            ChangeExpenditureValues();
            TableActivities.Rows.Clear();

            string[] itemNoParts = txtItemNo.Text.Split('.');

            txtExpenditure.Clear();
            txtCulmulativeExpenditure.Clear();

            SavedExpenditure = "";

            string query = String.Format(
                "SELECT ExpenditureMonth.Month,SUM(ExpenditureMonth.Expenditure) AS CumulativeExpenditure " +
                "FROM ActivityCode,MainActivity,ExpenditureMonth " +
                "WHERE MainActivity.ActivityID=ActivityCode.ActivityID " +
                "AND ExpenditureMonth.ActivityCodeID=ActivityCode.ActivityCodeID " +
                "AND MainActivity.Year='{0}' AND MainActivity.ItemNo='{1}'",
                btnSelectedYear.Text, itemNoParts[0]);

            AddSubItemNoPartsToQueryString();

            List<string> arrayOfExpenditureDetails = 
                commenMethods.SQLRead(query + " GROUP BY ExpenditureMonth.Month ORDER BY ExpenditureMonth.Month", "Month CumulativeExpenditure");

            SortedDictionary<byte, decimal> arrayOFExpenditureAndMonth = new SortedDictionary<byte, decimal> { };

            if (!commenMethods.ReturnListHasError(arrayOfExpenditureDetails))
            {
                for (byte j = 0; j < arrayOfExpenditureDetails.Count; j += 2)
                {
                    arrayOFExpenditureAndMonth.Add(Convert.ToByte(arrayOfExpenditureDetails[j]), Convert.ToDecimal(arrayOfExpenditureDetails[j + 1]));
                }

                AddDataToTable();
            }
            else
            {
                query = String.Format("SELECT COUNT(ActivityCode.ActivityCodeID) AS NoOFActivities " +
                    "FROM ActivityCode, MainActivity " +
                    "WHERE MainActivity.ActivityID = ActivityCode.ActivityID " +
                    "AND MainActivity.Year = '{0}' AND MainActivity.ItemNo = '{1}'",
                    btnSelectedYear.Text, itemNoParts[0]);

                AddSubItemNoPartsToQueryString();

                if (Convert.ToInt32(commenMethods.SQLRead(query, "NoOFActivities")[0]) > 0)
                {
                    for (byte j = 0; j < 12; j++)
                    {
                        arrayOFExpenditureAndMonth.Add(j, 0);
                    }

                    AddDataToTable();
                }
                else
                {
                    MessageBox.Show("Can't Find Activities for your search", "Something went wrong",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            void AddSubItemNoPartsToQueryString()
            {
                if (itemNoParts.Length >= 2)
                {
                    query += String.Format(" AND ActivityCode.INSub1='{0}'", itemNoParts[1]);
                }

                if (itemNoParts.Length == 3)
                {
                    query += String.Format(" AND ActivityCode.INSub2='{0}'", itemNoParts[2]);
                }
            }

            void AddDataToTable()
            {
                decimal CumulativeExpenditure = 0;
                byte rowIndex = 0;

                for (byte i = 1; i <= 12; i++)
                {
                    rowIndex = Convert.ToByte(TableActivities.Rows.Add());

                    TableActivities.Rows[rowIndex].Cells[0].Value = commenMethods.MonthList[i - 1];

                    try
                    {
                        TableActivities.Rows[rowIndex].Cells[1].Value = arrayOFExpenditureAndMonth[i];
                        CumulativeExpenditure += arrayOFExpenditureAndMonth[i];
                    }
                    catch
                    {
                        TableActivities.Rows[rowIndex].Cells[1].Value = 0;
                    }

                    TableActivities.Rows[rowIndex].Cells[2].Value = CumulativeExpenditure;
                }

                TableActivities.Rows[SelectedMonth - 1].DefaultCellStyle.BackColor = Color.FromArgb(58, 190, 240);
            }
        }   

        private void txt_TextChanged(object sender, EventArgs e)
        {
            Guna2TextBox SelectedTextBox = (Guna2TextBox)sender;

            if (SelectedTextBox.Name == txtItemNo.Name)
            {
                commenMethods.SaveOnlyIntegers(txtItemNo.Text);
            }
            else
            {
                commenMethods.SaveOnlyIntegers(SelectedTextBox.Text);

                if (txtItemNo.Text.Trim().Split('.').Length > 1 && SelectedTextBox.Name == txtExpenditure.Name)
                {
                    if (txtExpenditure.Text == SavedExpenditure || (SavedExpenditure == "0" && txtExpenditure.Text.Trim() == "")) 
                    {
                        NotificationPaintNeedUpdate.Visible = false;
                    }
                    else
                    {
                        NotificationPaintNeedUpdate.Visible = true;
                    }
                }               
            }
        }

        private void TableActivities_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow SelectedRow = TableActivities.Rows[e.RowIndex];

            if (SelectedRow.DefaultCellStyle.BackColor != Color.FromArgb(58, 190, 240)) 
            {
                for (int i = 0; i < 12; i++)
                {
                    if (TableActivities.Rows[i].DefaultCellStyle.BackColor == Color.FromArgb(58, 190, 240))
                    {
                        TableActivities.Rows[i].DefaultCellStyle.BackColor =
                            TableActivities.Rows[i].DefaultCellStyle.SelectionBackColor;
                    }
                }

                btnSelectMonth.Text = SelectedRow.Cells[0].Value.ToString().Trim();
                txtExpenditure.Text = SelectedRow.Cells[1].Value.ToString().Trim();
                txtCulmulativeExpenditure.Text = SelectedRow.Cells[2].Value.ToString().Trim();

                SelectedRow.DefaultCellStyle.BackColor = Color.FromArgb(58, 190, 240);

                SelectedRow.Selected = false;

                ChangeExpenditureValues();
            }            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string BudgetCode = ComboBoxBudgetCode.SelectedItem.ToString().Trim();
            string[] ItemNoParts = txtItemNo.Text.Split('.');

            if (ItemNoParts.Length > 0 && BudgetCode != "")
            {
                string Query;                

                if (ItemNoParts.Length == 1)
                {
                    Query = String.Format("SELECT ActivityCode.ActivityCodeID " +
                        "FROM ActivityCode,MainActivity WHERE MainActivity.ActivityID=ActivityCode.ActivityID " +
                        "AND MainActivity.BudgectCode='{0}' AND MainActivity.ItemNo='{1}' " +
                        "AND ActivityCode.INSub2 IS NULL AND MainActivity.Year='{2}'",
                        BudgetCode, ItemNoParts[0], btnSelectedYear.Text);

                    CheckHasSubActivities();
                }
                else if (ItemNoParts.Length == 2)
                {
                    Query = string.Format("SELECT ActivityCode.ActivityCodeID " +
                        "FROM ActivityCode,MainActivity WHERE MainActivity.ActivityID=ActivityCode.ActivityID " +
                        "AND MainActivity.BudgectCode='{0}' AND MainActivity.ItemNo='{1}' " +
                        "AND ActivityCode.INSub1='{2}' AND MainActivity.Year='{3}'",
                        BudgetCode, ItemNoParts[0], ItemNoParts[1], btnSelectedYear.Text);

                    CheckHasSubActivities();
                }
                else
                {
                    UpdateDatabase(null);
                }

                void CheckHasSubActivities()
                {
                    List<string> SubActivities = commenMethods.SQLRead(Query, "ActivityCodeID");

                    if (!commenMethods.ReturnListHasError(SubActivities))
                    {
                        if (SubActivities.Count > 1)
                        {
                            MessageBox.Show("Selected activity has sub activities. Update expenditure of it.",
                                "Can't update database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (SubActivities.Count == 0)
                        {
                            MessageBox.Show("Can't Find Activities for your search", "Something went wrong",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            UpdateDatabase(SubActivities[0]);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Something Went Wrong. Can't update Database", "Error Found",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }                

                void UpdateDatabase(string ActivityCodeID)
                {
                    if (ItemNoParts.Length == 3)
                    {
                        Query = string.Format("SELECT ActivityCode.ActivityCodeID " +
                            "FROM ActivityCode,MainActivity WHERE MainActivity.ActivityID=ActivityCode.ActivityID " +
                            "AND MainActivity.BudgectCode='{0}' AND MainActivity.ItemNo='{1}' " +
                            "AND ActivityCode.INSub1='{2}' AND ActivityCode.INSub2='{3}' AND MainActivity.Year='{4}'",
                            BudgetCode, ItemNoParts[0], ItemNoParts[1], ItemNoParts[2], btnSelectedYear.Text);

                        List<string> SubActivities = commenMethods.SQLRead(Query, "ActivityCodeID");

                        if (!commenMethods.ReturnListHasError(SubActivities))
                        {
                            ActivityCodeID = SubActivities[0];
                        }
                        else
                        {
                            MessageBox.Show("Something Went Wrong. Can't update Database", "Error Found",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    if (ActivityCodeID != null)
                    {
                        int SelectedMonth = commenMethods.FindMonth(btnSelectMonth.Text);

                        Query = String.Format("SELECT Expenditure FROM ExpenditureMonth " +
                            "WHERE ActivityCodeID='{0}' AND Month='{1}'", ActivityCodeID, SelectedMonth);

                        List<string> CurrentExpenditure = commenMethods.SQLRead(Query, "Expenditure");

                        if (commenMethods.ReturnListHasError(CurrentExpenditure))
                        {
                            Query = String.Format("INSERT INTO ExpenditureMonth " +
                                "(ActivityCodeID,Month,Expenditure) VALUES ('{0}','{1}','{2}')",
                                ActivityCodeID, SelectedMonth, txtExpenditure.Text.Replace(",", ""));
                        }
                        else
                        {
                            Query = String.Format("UPDATE ExpenditureMonth SET Expenditure='{0}' " +
                                "WHERE ActivityCodeID='{1}' AND Month='{2}'",
                                txtExpenditure.Text.Replace(",", ""), ActivityCodeID, SelectedMonth);                            
                        }

                        if (commenMethods.ExecuteSQL(Query))
                        {
                            MessageBox.Show("Updated Successfully", "Updated", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            btnSearch_Click(btnSearch, null);
                        }
                        else
                        {
                            MessageBox.Show("Something Went Wrong. Can't update Database", "Error Found",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    
                }
            }
        }
    }
}
