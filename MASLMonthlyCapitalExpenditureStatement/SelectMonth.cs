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
    public partial class SelectMonth : Form
    {
        public SelectMonth()
        {
            InitializeComponent();
        }

        public int SelectedYear = DateTime.Now.Year;
        public string CurrentSelectedMonth = null;
        public bool UpdateEnabled = false;

        public Guna2Button btnSelectedMonth = new Guna2Button();

        private void btnChangeSelectedYear_Click(object sender, EventArgs e)
        {            
            Guna2Button btnChangeSelectedYear = (Guna2Button)sender;

            if (btnChangeSelectedYear.Tag.ToString() == "Up")
            {
                txtSelectedYear.Text = (Convert.ToInt32(txtSelectedYear.Text) + 1).ToString();
            }
            else
            {
                txtSelectedYear.Text = (Convert.ToInt32(txtSelectedYear.Text) - 1).ToString();
            }            
        }

        private void SelectMonth_Load(object sender, EventArgs e)
        {
            txtSelectedYear.Text = SelectedYear.ToString();
            btnSelectedMonth = new Guna2Button();

            if (CurrentSelectedMonth != null)
            {
                Dictionary<string, Guna2Button> MonthList = new Dictionary<string, Guna2Button>
                {
                    {"JAN",btnJAN },{"FEB",btnFEB },{"MAR",btnMAR },{"APR",btnAPR },{"MAY",btnMAY },{"JUN",btnJUN },
                    {"JUL",btnJUL },{"AUG",btnAUG },{"SEP",btnSEP },{"OCT",btnOCT },{"NOV",btnNOV },{"DEC",btnDEC },
                };

                MonthList[CurrentSelectedMonth].Checked = true;
            }
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SelectedYear = Convert.ToInt32(txtSelectedYear.Text);
            UpdateEnabled = true;
            this.Close();
        }

        private void ChangeSelectedMonth(object sender, EventArgs e)
        {
            Guna2Button btnSelectedMonthButton = (Guna2Button)sender;

            if (btnSelectedMonthButton.Checked)
                btnSelectedMonth = btnSelectedMonthButton;
        }
    }
}
