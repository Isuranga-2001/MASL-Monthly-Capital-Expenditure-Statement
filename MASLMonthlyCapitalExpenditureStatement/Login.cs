﻿using System;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        CommenMethods commenMethods = new CommenMethods();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;

            List<string> sqlRead = commenMethods.SQLRead("SELECT * FROM login WHERE Username='" + txtUserName.Text + "' " +
                "AND Password='" + txtPassword.Text + "' ;", "Username Password");

            if (sqlRead == null)
            {
                MessageBox.Show("Can't Access to the Database, Please try again later.",
                    "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (sqlRead.Count > 0) 
            {
                Activity ActivityForm = new Activity();
                ActivityForm.Show();
                Properties.Settings.Default.LoginScreen = this;
                Properties.Settings.Default.Save();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect Username or Password !", "Error Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UseWaitCursor = false;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
            commenMethods.ExecuteSQL("CREATE TABLE [dbo].[AllocationBudget]([Year] INT NOT NULL PRIMARY KEY,[Capital] FLOAT NULL,[Recurrent] FLOAT NULL)");
            commenMethods.ExecuteSQL("CREATE TABLE [dbo].[MonthyBudget]([Year] INT NOT NULL,[Month] INT NOT NULL,[RecurrentExpenditure] FLOAT NULL,[RecurrentFundReceived] FLOAT NULL,[CapitalFundReceived] FLOAT NULL,PRIMARY KEY([Year], [Month]), CONSTRAINT[FK_Table_AllocationBudget] FOREIGN KEY([Year]) REFERENCES[AllocationBudget]([Year]))");

        }
    }
}
