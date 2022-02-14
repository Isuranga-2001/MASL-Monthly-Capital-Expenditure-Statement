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
    public partial class QuarterWiseReport : Form
    {
        CommenMethods commenMethods = new CommenMethods();

        public List<Guna2Button> arrayOfBtnSelectedQuarter;
        public short selectedYear;
        public decimal commitment = 0;

        SortedDictionary<byte, decimal> arrayOfAllocations = new SortedDictionary<byte, decimal> { };
        SortedDictionary<byte, decimal> arrayOfExpenditures = new SortedDictionary<byte, decimal> { };
        byte selectedQuarter = 0;
        string[] itemNoParts;
        string savedAllocation = null, savedExpenditure = null;

        public QuarterWiseReport()
        {
            InitializeComponent();

            arrayOfBtnSelectedQuarter = new List<Guna2Button>
            {
                btnQ1, btnQ2, btnQ3, btnQ4
            };
        }

        private void QuarterWiseReport_Load(object sender, EventArgs e)
        {
            itemNoParts = txtItemNo.Text.Split('.');
            PrecentageProgressBar.Value = 0;

            CheckActivityDetails();
            FindDetailsOfSelectedQuarter();

            arrayOfBtnSelectedQuarter[Convert.ToByte(DateTime.Now.Month / 4)].Checked = true;
        }

        private void btnQuarter_CheckedChanged(object sender, EventArgs e)
        {
            Guna2Button btnSelectedQuarter = (Guna2Button)sender;

            if (btnSelectedQuarter.Checked)
            {
                selectedQuarter = Convert.ToByte(btnSelectedQuarter.Tag);

                byte startIndex = Convert.ToByte((selectedQuarter - 1) * 3);

                btnQ1.Width = btnQ2.Width = btnQ3.Width = btnQ4.Width = 125;
                btnSelectedQuarter.Width = 250;

                for (byte i = 0; i < 4; i++)
                {
                    if (i > 0)
                    {
                        arrayOfBtnSelectedQuarter[i].Left = arrayOfBtnSelectedQuarter[i - 1].Right + 6;
                    }
                    arrayOfBtnSelectedQuarter[i].Text = "Quarter " + (i + 1);
                }

                btnSelectedQuarter.Text =
                    String.Format("Quarter {0} ( {1}, {2}, {3} )", selectedQuarter,
                    commenMethods.MonthList[startIndex], commenMethods.MonthList[startIndex + 1],
                    commenMethods.MonthList[startIndex + 2]);

                // Fill Controls

                if (arrayOfAllocations.Count == 4 && arrayOfExpenditures.Count == 4)
                {
                    decimal quarterallocation = Convert.ToDecimal(arrayOfAllocations[selectedQuarter]);

                    txtAllocationQ.Text = commenMethods.SetAsNumber(arrayOfAllocations[selectedQuarter].ToString());
                    txtCumulativeExpenditureQ.Text = commenMethods.SetAsNumber(arrayOfExpenditures[selectedQuarter].ToString());

                    // expenditure precentage
                    ProgressBarAllocationQ.Maximum = Convert.ToInt32(Convert.ToDecimal(savedAllocation));
                    ProgressBarAllocationQ.Value = Convert.ToInt32(quarterallocation);

                    // allocation precentage
                    ProgressBarCumuExpenditureQ.Maximum = Convert.ToInt32(Convert.ToDecimal(savedExpenditure));
                    ProgressBarCumuExpenditureQ.Value = Convert.ToInt32(Convert.ToDecimal(arrayOfExpenditures[selectedQuarter]));

                    // quarter wise progress

                    if (arrayOfAllocations[selectedQuarter] > 0)
                    {
                        short QWiseProgress = Convert.ToInt16(((arrayOfExpenditures[selectedQuarter] + commitment) / arrayOfAllocations[selectedQuarter]) * 100);

                        if (QWiseProgress > 100)
                        {
                            PrecentageProgressBar.Maximum = QWiseProgress;
                        }
                        else
                        {
                            PrecentageProgressBar.Maximum = 100;
                        }

                        PrecentageProgressBar.Value = QWiseProgress;
                    }
                    else
                    {
                        PrecentageProgressBar.Value = 0;
                    }                    
                }
                else
                {
                    ErrorMsg();
                }
            }
        }

        private void btnAllocation_Click(object sender, EventArgs e)
        {
            Allocation form = new Allocation();

            form.currentAllocation = Convert.ToDecimal(commenMethods.SaveOnlyIntegers(txtAllocation.Text));
            form.txtAllocation.Text = txtAllocation.Text;
            form.txtBudgetCode.Text = txtBudgetCode.Text;
            form.txtItemNo.Text = txtItemNo.Text;
            form.selectedYear = selectedYear;

            form.ShowDialog();
            form.Close();

            QuarterWiseReport_Load(this, null);
        }

        private void btnCumulativeExpenditure_Click(object sender, EventArgs e)
        {
            MonthlyExpenditure UpdateExpenditureForm = new MonthlyExpenditure();

            UpdateExpenditureForm.btnSelectedYear.Text = selectedYear.ToString();
            UpdateExpenditureForm.txtItemNo.Text = txtItemNo.Text;
            UpdateExpenditureForm.btnSelectMonth.Text = commenMethods.MonthList[DateTime.Now.Month - 1];

            UpdateExpenditureForm.ComboBoxBudgetCode.Items.Clear();

            UpdateExpenditureForm.ComboBoxBudgetCode.Items.Add(txtBudgetCode.Text);
            UpdateExpenditureForm.ComboBoxBudgetCode.SelectedIndex = 0;

            UpdateExpenditureForm.ShowDialog();
            UpdateExpenditureForm.Close();

            QuarterWiseReport_Load(this, null);
        }

        void CheckActivityDetails()
        {
            string query = String.Format(
                "SELECT SUM(SubActivity.Allocation) AS TotalAllocation " +
                "FROM MainActivity,ActivityCode,SubActivity " +
                "WHERE SubActivity.ActivityCodeID=ActivityCode.ActivityCodeID " +
                "AND MainActivity.ActivityID=ActivityCode.ActivityID " +
                "AND MainActivity.Year='{0}' AND MainActivity.ItemNo='{1}'",
                selectedYear, itemNoParts[0]);

            query = AddINSubToQuery(query);

            List<string> arrayOfActivityDetails = commenMethods.SQLRead(query, "TotalAllocation");

            if (!commenMethods.ReturnListHasError(arrayOfActivityDetails))
            {
                if (commenMethods.SetAsNumber(arrayOfActivityDetails[0]) != commenMethods.SetAsNumber(txtAllocation.Text))
                {
                    ErrorMsg();
                }
                else
                {
                    query = String.Format(
                        "SELECT SUM(ExpenditureMonth.Expenditure) AS CumulativeExpenditure " +
                        "FROM MainActivity,ActivityCode,ExpenditureMonth " +
                        "WHERE ExpenditureMonth.ActivityCodeID=ActivityCode.ActivityCodeID " +
                        "AND MainActivity.ActivityID=ActivityCode.ActivityID " +
                        "AND MainActivity.Year='{0}' AND MainActivity.ItemNo='{1}'",
                        selectedYear, itemNoParts[0]);

                    query = AddINSubToQuery(query);
                    arrayOfActivityDetails = commenMethods.SQLRead(query, "CumulativeExpenditure");

                    savedAllocation = commenMethods.SaveOnlyIntegers(txtAllocation.Text);
                    txtAllocation.Text = commenMethods.SetAsNumber(txtAllocation.Text);

                    if (!commenMethods.ReturnListHasError(arrayOfActivityDetails))
                    {
                        savedExpenditure = arrayOfActivityDetails[0];
                        txtCumulativeExpenditure.Text = commenMethods.SetAsNumber(arrayOfActivityDetails[0]);
                    }
                    else
                    {
                        savedExpenditure = "0";
                        txtCumulativeExpenditure.Text = commenMethods.SetAsNumber("0");
                    }
                }
            }
            else
            {
                ErrorMsg();
            }                      
        }

        string AddINSubToQuery(string query)
        {
            if (itemNoParts.Length >= 2)
            {
                query += String.Format(" AND ActivityCode.INSub1='{0}'", itemNoParts[1]);
            }
            if (itemNoParts.Length == 3)
            {
                query += String.Format(" AND ActivityCode.INSub2='{0}'", itemNoParts[2]);
            }

            return query;
        }

        void ErrorMsg()
        {
            MessageBox.Show("Something went wrong. Can't find results for your inputs",
                "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Close();
        }

        void FindDetailsOfSelectedQuarter()
        {
            // Allocation
            string query = String.Format(
                "SELECT Allocation.Quarter,SUM(Allocation.QuarterAllocation) AS TotalAllocation " +
                "FROM Allocation,SubActivity,ActivityCode,MainActivity " +
                "WHERE MainActivity.ActivityID=ActivityCode.ActivityID " +
                "AND ActivityCode.ActivityCodeID=SubActivity.ActivityCodeID " +
                "AND SubActivity.ActivityCodeID=Allocation.ActivityCodeID " +
                "AND MainActivity.Year='{0}' AND MainActivity.ItemNo='{1}'",
                selectedYear, itemNoParts[0]);

            if (itemNoParts.Length >= 2)
            {
                query += String.Format(" AND ActivityCode.INSub1='{0}'", itemNoParts[1]);
            }
            if (itemNoParts.Length == 3)
            {
                query += String.Format(" AND ActivityCode.INSub2='{0}'", itemNoParts[2]);
            }

            List<string> arrayOfAllocationDetails = 
                commenMethods.SQLRead(query + " GROUP BY Allocation.Quarter ORDER BY Allocation.Quarter",
                "Quarter TotalAllocation");

            arrayOfAllocations.Clear();

            if (!commenMethods.ReturnListHasError(arrayOfAllocationDetails))
            {
                for (byte i = 0; i < 8; i += 2)
                {
                    arrayOfAllocations.Add(Convert.ToByte(arrayOfAllocationDetails[i]), Convert.ToDecimal(arrayOfAllocationDetails[i + 1]));
                }
            }
            else
            {
                MessageBox.Show("Can't find quarter-wise allocation. Please update it and try again.",
                    "Can't Find Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (btnAllocation.Enabled)
                {
                    if (MessageBox.Show("Do you want to update quarter wise allocations", "Need Update",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        btnAllocation_Click(btnAllocation, null);
                        QuarterWiseReport_Load(this, null);
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    ErrorMsg();
                }
                
            }

            // cumulative Expenditure
            query = String.Format(
                "SELECT ExpenditureMonth.Month,SUM(ExpenditureMonth.Expenditure) AS CumulativeExpenditure " +
                "FROM ActivityCode,MainActivity,ExpenditureMonth " +
                "WHERE MainActivity.ActivityID=ActivityCode.ActivityID " +
                "AND ActivityCode.ActivityCodeID=ExpenditureMonth.ActivityCodeID " +
                "AND MainActivity.Year='{0}' AND MainActivity.ItemNo='{1}'",
                selectedYear, itemNoParts[0]);

            query = AddINSubToQuery(query);

            List<string> arrayOFExpenditureDetails = 
                commenMethods.SQLRead(query+ " GROUP BY ExpenditureMonth.Month ORDER BY ExpenditureMonth.Month",
                "Month CumulativeExpenditure");

            arrayOfExpenditures.Clear();

            if (!commenMethods.ReturnListHasError(arrayOFExpenditureDetails))
            {
                SortedDictionary<byte, decimal> tempArrayOfCumuExpenditures = new SortedDictionary<byte, decimal> { };

                for (byte i = 0; i < arrayOFExpenditureDetails.Count; i += 2)
                {
                    tempArrayOfCumuExpenditures.Add(Convert.ToByte(arrayOFExpenditureDetails[i]), Convert.ToDecimal(arrayOFExpenditureDetails[i + 1]));
                }

                decimal quarterExpenditure = 0;

                for (byte i = 1; i <= 12; i++)
                {
                    try
                    {
                        quarterExpenditure += tempArrayOfCumuExpenditures[i];
                    }
                    catch { }

                    if (i % 3 == 0)
                    {
                        arrayOfExpenditures.Add(Convert.ToByte(i / 3), quarterExpenditure);
                        quarterExpenditure = 0;
                    }
                }
            }
            else
            {
                for (byte i = 1; i <= 4; i++)
                {
                    arrayOfExpenditures.Add(i, 0);
                }
            }
        }

        private void ActivityProgressBar_ValueChanged(object sender, EventArgs e)
        {
            if (ActivityProgressBar.Value > 82)
            {
                ActivityProgressBar.TextAlign = HorizontalAlignment.Center;
                ActivityProgressBar.ForeColor = Color.White;
            }
        }
    }
}
