using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MASLMonthlyCapitalExpenditureStatement
{
    public partial class BudgetSummery : Form
    {
        public short selectedYear = 2020;
        public byte selectedMonth = 1;

        CommenMethods commenMethods = new CommenMethods();

        List<string> arrayOfSeriesNames = new List<string> { "Capital", "Recurrent" };

        List<string> queryArray;
        List<string> returnValueArray;

        public BudgetSummery()
        {
            InitializeComponent();
        }

        private void BudgetSummery_Load(object sender, EventArgs e)
        {
            ChartBudget.Titles[0].Text = 
                String.Format("Budget {0} {1}", selectedYear, commenMethods.MonthList[selectedMonth - 1]);

            queryArray = new List<string>
            {
                String.Format("SELECT Capital FROM AllocationBudget WHERE Year='{0}'", selectedYear),
                String.Format("SELECT Recurrent FROM AllocationBudget WHERE Year='{0}'", selectedYear)
            };

            returnValueArray = new List<string> { "Capital", "Recurrent" };

            foreach (string seriesName in arrayOfSeriesNames)
            {
                ComboBoxSource.Items.Add(seriesName);
            }

            ComboBoxSource.SelectedIndex = 0;
        }

        private void ComboBoxSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxSource.SelectedIndex >= 0)
            {
                UpdateChart(Convert.ToByte(ComboBoxSource.SelectedIndex));
            }
        }

        void UpdateChart(byte selectedSeriesIndex)
        {
            ChartBudget.Series.Clear();

            ChartBudget.Series.Add("Budget");
            ChartBudget.Series[0].ChartType = SeriesChartType.Line;
            ChartBudget.Series[0].BorderWidth = 3;

            List<string> returnValueList =
                    commenMethods.SQLRead(queryArray[selectedSeriesIndex], returnValueArray[selectedSeriesIndex]);

            if (!commenMethods.ReturnListHasError(returnValueList))
            {
                decimal budgetCapitalOfYear = Convert.ToDecimal(returnValueList[0]) / 12;

                for (byte i = 0; i < 12; i++)
                {
                    ChartBudget.Series[0].Points.AddXY(commenMethods.MonthList[i], budgetCapitalOfYear * (i + 1));
                }

                ChartBudget.Series.Add("Progress");
                ChartBudget.Series[1].ChartType = SeriesChartType.Line;
                ChartBudget.Series[1].BorderWidth = 3;

                List<string> monthlyTotalExpenditure;
                decimal cumulativeExpenditure = 0;

                if (selectedSeriesIndex == 0)
                {
                    for (byte i = 1; i <= 12; i++)
                    {
                        monthlyTotalExpenditure = commenMethods.SQLRead(String.Format(
                            "SELECT SUM(ExpenditureMonth.Expenditure) AS TotalExpenditure " +
                            "FROM ExpenditureMonth,ActivityCode,MainActivity " +
                            "WHERE ExpenditureMonth.ActivityCodeID=ActivityCode.ActivityCodeID " +
                            "AND MainActivity.ActivityID=ActivityCode.ActivityID " +
                            "AND MainActivity.Year='{0}' " +
                            "AND ExpenditureMonth.Month='{1}'",
                            selectedYear, i), "TotalExpenditure");

                        if (!commenMethods.ReturnListHasError(monthlyTotalExpenditure))
                        {
                            cumulativeExpenditure += Convert.ToDecimal(monthlyTotalExpenditure[0]);
                        }

                        ChartBudget.Series[1].Points.AddXY(commenMethods.MonthList[i - 1], cumulativeExpenditure);
                    }
                }
                else
                {
                    for (byte i = 1; i <= 12; i++)
                    {
                        monthlyTotalExpenditure = commenMethods.SQLRead(String.Format(
                            "SELECT RecurrentExpenditure FROM MonthyBudget " +
                            "WHERE Year='{0}' AND Month='{1}'", selectedYear, i), "RecurrentExpenditure");

                        if (!commenMethods.ReturnListHasError(monthlyTotalExpenditure))
                        {
                            cumulativeExpenditure += Convert.ToDecimal(monthlyTotalExpenditure[0]);
                        }

                        ChartBudget.Series[1].Points.AddXY(commenMethods.MonthList[i - 1], cumulativeExpenditure);
                    }
                }

            }
            else
            {
                MessageBox.Show("Can't show results. Something went wrong.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
