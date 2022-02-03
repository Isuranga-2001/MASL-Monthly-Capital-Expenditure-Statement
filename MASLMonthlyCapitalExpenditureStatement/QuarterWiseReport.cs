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
        public List<Guna2Button> arrayOfBtnSelectedQuarter;

        public QuarterWiseReport()
        {
            InitializeComponent();

            arrayOfBtnSelectedQuarter = new List<Guna2Button>
            {
                btnQ1, btnQ2, btnQ3, btnQ4
            };
        }
    }
}
