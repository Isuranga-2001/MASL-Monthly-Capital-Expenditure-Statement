using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MASLMonthlyCapitalExpenditureStatement
{
    public partial class MaximizedReportOFTableExpenditure : Form
    {
        public Report report;

        public MaximizedReportOFTableExpenditure()
        {
            InitializeComponent();
        }

        private void MaximizedReportOFTableExpenditure_Load(object sender, EventArgs e)
        {

        }

        private void TableExpenditure_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            report.ShowSummery(TableExpenditure, e.RowIndex);
        }
    }
}
