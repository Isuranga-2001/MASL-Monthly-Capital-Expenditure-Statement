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

        List<decimal> arrayOfAllocations = new List<decimal> { };
        List<decimal> arrayOfCumuExpenditures = new List<decimal> { };
        byte selectedQuarter = 0;
        string[] itemNoParts;

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

            CheckActivityDetails();
            FindDetailsOfSelectedQuarter();
        }

        private void btnQuarter_CheckedChanged(object sender, EventArgs e)
        {
            Guna2Button btnSelectedQuarter = (Guna2Button)sender;
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
        }

        void CheckActivityDetails()
        {
            string query = String.Format(
                "SELECT SUM(SubActivity.Allocation) AS TotalAllocation," +
                "SUM(ExpenditureMonth.Expenditure) AS CumulativeExpenditure " +
                "FROM SubActivity,ActivityCode,MainActivity,ExpenditureMonth " +
                "WHERE MainActivity.ActivityID=ActivityCode.ActivityID " +
                "AND ActivityCode.ActivityCodeID=SubActivity.ActivityCodeID " +
                "AND ActivityCode.ActivityCodeID=ExpenditureMonth.ActivityCodeID " +
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

            List<string> arrayOfActivityDetails = commenMethods.SQLRead(query + " GROUP BY (MainActivity.ItemNo)", "TotalAllocation CumulativeExpenditure");

            if (!commenMethods.ReturnListHasError(arrayOfActivityDetails))
            {
                if (arrayOfActivityDetails[0] != txtAllocation.Text)
                {
                    ErrorFound();
                }
                else
                {
                    txtCumulativeExpenditure.Text = arrayOfActivityDetails[1];
                }
            }
            else
            {
                ErrorFound();
            }

            void ErrorFound()
            {
                MessageBox.Show("Something went wrong. Can't find results for your inputs",
                    "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.Close();
            }
        }

        void FindDetailsOfSelectedQuarter()
        {
            string query = String.Format("SELECT Allocation.Quarter,Allocation.QuarterAllocation " +
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

            List<string> arrayOfAllocationDetails = commenMethods.SQLRead(query + " ORDER BY Allocation.Quarter", "Quarter QuarterAllocation");

            if (!commenMethods.ReturnListHasError(arrayOfAllocationDetails))
            {

            }
            else
            {

            }
        }

        
    }
}
