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
using System.Windows.Forms.DataVisualization.Charting;

namespace MASLMonthlyCapitalExpenditureStatement
{
    public partial class Allocation : Form
    {
        CommenMethods commenMethods = new CommenMethods();

        List<Guna2TextBox> arrayOfAllocationTextBoxes;
        List<Guna2Chip> arrayOfAllocationPercentageLabels;
        List<Guna2TrackBar> arrayOfTrackBars;

        public short selectedYear;
        public decimal currentAllocation;

        bool errorFound = false, editFromText = false, isAllocatePerQuarters = false;

        public Allocation()
        {
            InitializeComponent();
        }

        private void Allocation_Load(object sender, EventArgs e)
        {
            arrayOfAllocationTextBoxes = new List<Guna2TextBox>
            {
                txtAllocationQ1, txtAllocationQ2, txtAllocationQ3, txtAllocationQ4
            };

            arrayOfAllocationPercentageLabels = new List<Guna2Chip>
            {
                lblPercentageQ1, lblPercentageQ2, lblPercentageQ3, lblPercentageQ4
            };

            arrayOfTrackBars = new List<Guna2TrackBar>
            {
                TrackBarQ1, TrackBarQ2, TrackBarQ3, TrackBarQ4
            };

            for (byte i = 0; i < 4; i++)
            {
                arrayOfTrackBars[i].Value = 0;
            }

            if (currentAllocation > 0)
            {
                SearchDetails();
            }
            else
            {
                errorFound = true;
                MessageBox.Show("Plaese enter valid allocation", "Error Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            SearchDetails();
        }

        void SearchDetails()
        {
            string[] itemNoParts = txtItemNo.Text.Split('.');

            string query = String.Format("SELECT SubActivity.Allocation,Allocation.Quarter,Allocation.QuarterAllocation " +
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

            List<string> arrayOfAllocationDetails = commenMethods.SQLRead(query + " ORDER BY Allocation.Quarter", "Allocation Quarter QuarterAllocation");

            if (!commenMethods.ReturnListHasError(arrayOfAllocationDetails))
            {
                txtAllocation.Text = commenMethods.SetAsNumber(txtAllocation.Text);

                if (txtAllocation.Text == commenMethods.SetAsNumber(arrayOfAllocationDetails[0]))
                {
                    byte quarterIndex;
                    string quarterAllocation;

                    for (byte i = 0; i < arrayOfAllocationDetails.Count; i += 3)
                    {
                        quarterIndex = Convert.ToByte(Convert.ToByte(arrayOfAllocationDetails[i + 1]) - 1);
                        quarterAllocation = arrayOfAllocationDetails[i + 2];

                        arrayOfTrackBars[quarterIndex].Value = Convert.ToInt32(Convert.ToInt32(quarterAllocation) * 100 / Convert.ToInt32(arrayOfAllocationDetails[0]));

                        arrayOfAllocationTextBoxes[quarterIndex].Text = commenMethods.SetAsNumber(quarterAllocation);

                        arrayOfAllocationPercentageLabels[quarterIndex].Text = Math.Round(Convert.ToDecimal(Convert.ToInt32(quarterAllocation) * 100 / Convert.ToInt32(arrayOfAllocationDetails[0])), 1) + "%";
                    }
                }
                else
                {
                    MessageBox.Show("Something Went Wrong", "Error Find Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorFound = true;
                }

                isAllocatePerQuarters = true;
            }
            else
            {
                for (byte i = 0; i < 4; i++)
                {
                    arrayOfTrackBars[i].Value = 25;
                }
            }
        }

        private void TrackBar_ValueChanged(object sender, EventArgs e)
        {
            Guna2TrackBar selectedTrackBar = (Guna2TrackBar)sender;
            byte selectedQuarterIndex = (byte)(Convert.ToByte(selectedTrackBar.Tag.ToString()) -1);

            arrayOfAllocationPercentageLabels[selectedQuarterIndex].Text = selectedTrackBar.Value + "%";

            if (!editFromText)
            {
                arrayOfAllocationTextBoxes[selectedQuarterIndex].Text =
                    commenMethods.SetAsNumber((selectedTrackBar.Value * currentAllocation / 100).ToString());
            }
        }

        private void PercentageLabel_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            Guna2TextBox selectedTextBox = (Guna2TextBox)sender;
            byte selectedQuarterIndex = (byte)(Convert.ToByte(selectedTextBox.Tag.ToString()) - 1);

            if (selectedTextBox.Text != "")
            {
                if (Convert.ToDecimal(commenMethods.SaveOnlyIntegers(selectedTextBox.Text)) <= currentAllocation)
                {
                    editFromText = true;
                    arrayOfTrackBars[selectedQuarterIndex].Value = Convert.ToByte(Convert.ToDecimal(commenMethods.SaveOnlyIntegers(selectedTextBox.Text)) * 100 / currentAllocation);
                    editFromText = false;
                }
                else
                {
                    selectedTextBox.Text = currentAllocation.ToString();
                }
            }
            else
            {
                editFromText = true;
                arrayOfTrackBars[selectedQuarterIndex].Value = 0;
                editFromText = false;
            }

            decimal totalAllocation = 0;

            for (byte i = 0; i < 4; i++)
            {
                if (arrayOfAllocationTextBoxes[i].Text.Trim() != "")
                {
                    totalAllocation += Convert.ToDecimal(commenMethods.SaveOnlyIntegers(arrayOfAllocationTextBoxes[i].Text));
                }
            }

            if (totalAllocation != currentAllocation || errorFound)
            {
                btnOK.Enabled = btnChart.Enabled = false;
            }
            else
            {
                btnOK.Enabled = btnChart.Enabled = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string[] itemNoParts = txtItemNo.Text.Split('.');

            string query = String.Format("SELECT ActivityCode.ActivityCodeID FROM ActivityCode,MainActivity " +
                "WHERE MainActivity.ActivityID=ActivityCode.ActivityID " +
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

            List<string> activityCode = commenMethods.SQLRead(query, "ActivityCodeID");

            if (!commenMethods.ReturnListHasError(activityCode))
            {
                try
                {
                    byte countSuccess = 0;

                    if (isAllocatePerQuarters)
                    {
                        // update
                        query = "UPDATE Allocation SET QuarterAllocation='{0}' WHERE ActivityCodeID='{1}' AND Quarter='{2}'";                        
                    }
                    else
                    {
                        // insert
                        query = "INSERT INTO Allocation (ActivityCodeID,Quarter,QuarterAllocation) VALUES ('{1}','{2}','{0}')";
                    }

                    for (byte i = 0; i < 4; i++)
                    {
                        if (commenMethods.ExecuteSQL(String.Format(query,
                            commenMethods.SaveOnlyIntegers(arrayOfAllocationTextBoxes[i].Text), activityCode[0], i + 1)))
                        {
                            countSuccess += 1;
                        }
                    }

                    if (countSuccess == 4)
                    {
                        MessageBox.Show("Database Updated Successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.Close();
                }
                catch
                {
                    commenMethods.UpdateErrorMessageShow();
                }                
            }
            else
            {
                commenMethods.UpdateErrorMessageShow();
            }
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            BudgetSummery chartform = new BudgetSummery();

            chartform.ChartBudget.Titles[0].Text = txtBudgetCode.Text + " - " + txtItemNo.Text;
            chartform.isParentAllication = true;

            chartform.ChartBudget.Series.Clear();
            chartform.ChartBudget.Series.Add("Allocation");
            chartform.ChartBudget.Series[0].ChartType = SeriesChartType.Line;
            chartform.ChartBudget.Series[0].BorderWidth = 3;

            decimal cumulativeAllocation = 0;

            for (byte i = 0; i < 12; i++)
            {
                if (i % 3 == 0)
                {
                    cumulativeAllocation += Convert.ToDecimal(arrayOfAllocationTextBoxes[i / 3].Text);
                }

                chartform.ChartBudget.Series[0].Points.AddXY(commenMethods.MonthList[i], cumulativeAllocation);
            }

            chartform.ShowDialog();
        }

    }
}
