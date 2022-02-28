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
    public partial class IncomeSource : Form
    {
        CommenMethods commenMethods = new CommenMethods();

        public IncomeSource()
        {
            InitializeComponent();
        }

        private void IncomeSource_Load(object sender, EventArgs e)
        {
            FindSourceData();
        }

        void CleanTableSelected()
        {
            if (TableSources.SelectedRows.Count > 0)
            {
                TableSources.SelectedRows[0].Selected = false;
            }
        }

        void CleanControls()
        {
            txtSource.Clear();
            txtSection.Clear();
            txtIncomeBudget.Clear();
            btnAddSource.Enabled = btnAddChild.Enabled = btnDelete.Enabled = btnSave.Enabled = false;            
        }

        void FindSourceData()
        {
            CleanControls();

            commenMethods.RetrieveDataOnDataGridView(String.Format(
                "SELECT Source.SourceID,SourceYear.SourceYearID," +
                "Source.SourceName,Source.Section,SourceYear.IncomeBudget " +
                "FROM SourceYear,Source " +
                "WHERE Source.SourceID=SourceYear.SourceID AND SourceYear.Year='{0}'",
                btnSelectedYear.Text), TableSources, 1, 5);

            CleanTableSelected();
            TableSources.Rows[0].Selected = true;
        }

        private void btnSelectedYear_Click(object sender, EventArgs e)
        {
            SelectMonth form = new SelectMonth();

            form.txtSelectedYear.Text = btnSelectedYear.Text;
            form.ShowDialog();

            if (form.UpdateEnabled)
            {
                btnSelectedYear.Text = form.txtSelectedYear.Text;
                btnAddSource.Checked = false;
                FindSourceData();
            }
        }

        private void TableSources_SelectionChanged(object sender, EventArgs e)
        {
            CleanControls();

            if (TableSources.SelectedRows.Count > 0)
            {
                if (TableSources.SelectedRows[0].Index < TableSources.RowCount - 1
                    && TableSources.SelectedRows[0].Cells[3].Value != null)
                {
                    txtSource.Text = TableSources.SelectedRows[0].Cells["Source"].Value.ToString();
                    txtSection.Text = TableSources.SelectedRows[0].Cells["Section"].Value.ToString();
                    txtIncomeBudget.Text = 
                        commenMethods.SetAsNumber(TableSources.SelectedRows[0].Cells["IncomeBudget"].Value.ToString());

                    btnAddChild.Enabled = btnDelete.Enabled = true;
                }

                btnAddSource.Enabled = true;
            }
        }

        private void SourceInputTextBox_TextChanged(object sender, EventArgs e)
        {
            Guna2TextBox selectedTextBox = (Guna2TextBox)sender;

            if (TableSources.SelectedRows.Count > 0 
                && TableSources.SelectedRows[0].Index < TableSources.RowCount - 1 
                && !btnSave.Enabled)
            {
                string currentText = selectedTextBox.Text,
                    savedText = TableSources.SelectedRows[0].Cells[selectedTextBox.Tag.ToString()].Value.ToString();

                if (selectedTextBox.Tag.ToString() == "IncomeBudget")
                {
                    currentText = commenMethods.SetAsNumber(currentText);
                    savedText = commenMethods.SetAsNumber(savedText);
                }

                if (currentText != savedText)
                {
                    btnSave.Enabled = true;
                }
            }

            if (selectedTextBox.Tag.ToString() == "IncomeBudget")
            {
                selectedTextBox.Text = commenMethods.SaveOnlyIntegers(selectedTextBox.Text);
            }

            if (btnAddSource.Checked && txtIncomeBudget.Text.Trim() != "" && txtSource.Text.Trim() != "")
            {
                btnSave.Enabled = true;
            }
        }

        private void btnAddSource_CheckedChanged(object sender, EventArgs e)
        {
            if (btnAddSource.Checked)
            {
                CleanTableSelected();
                btnAddSource.Enabled = true;
                TableSources.Enabled = false;
            }
            else
            {
                TableSources.Rows[0].Selected = true;
                TableSources.Enabled = true;
            }
        }

        private void btnAddChild_CheckedChanged(object sender, EventArgs e)
        {
            if (btnAddChild.Checked)
            {
                TableSources.SelectedRows[0].DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 210, 21);

                string tempSection = txtSection.Text;
                txtSection.ReadOnly = true;

                CleanTableSelected();
                btnAddChild.Enabled = true;
                TableSources.Enabled = false;

                txtSection.Text = tempSection;
            }
            else
            {
                TableSources.Enabled = true;
                TableSources.Rows[0].Selected = true;
                txtSection.ReadOnly = false;

                TableSources.SelectedRows[0].DefaultCellStyle.SelectionBackColor = Color.FromArgb(58, 190, 240);
            }
        }

        void ExecuteQueryList(List<string> queryList, string successedMsg, string msgTitle)
        {
            byte errorCount = 0;
            foreach (string query in queryList)
            {
                if (!commenMethods.ExecuteSQL(query))
                {
                    errorCount += 1;
                }
            }

            if (errorCount == 0)
            {
                MessageBox.Show(successedMsg, msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                FindSourceData();
                btnAddSource.Checked = false;
            }
            else
            {
                commenMethods.UpdateErrorMessageShow();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<string> queryList = new List<string> { };
            int sourceID, sourceYearID;

            if (btnAddSource.Checked)
            {
                // insert new main source
                sourceID = CheckAvaiableInDatabase();

                if (sourceID == -1)
                {
                    // insert data into database
                    sourceID = NextID("Source");

                    queryList.Add(String.Format(
                        "INSERT INTO Source (SourceID,SourceName,Section) VALUES ('{0}','{1}','{2}')",
                        sourceID, txtSource.Text.Trim(), txtSection.Text.Trim()));

                }
                else
                {
                    // avaiable in database
                    AddUpdateQuery();
                }

                queryList.Add(String.Format(
                    "INSERT INTO SourceYear (SourceYearID,SourceID,Year,IncomeBudget) VALUES ('{0}','{1}','{2}','{3}')",
                    NextID("SourceYear"), sourceID, btnSelectedYear.Text.Trim(), txtIncomeBudget.Text.Trim()));

            }
            else
            {
                // update main source
                sourceID = Convert.ToInt32(TableSources.SelectedRows[0].Cells[1].Value);
                sourceYearID = Convert.ToInt32(TableSources.SelectedRows[0].Cells[2].Value);

                AddUpdateQuery();

                queryList.Add(String.Format(
                    "UPDATE SourceYear SET IncomeBudget='{0}' WHERE SourceYearID='{1}'",
                    txtIncomeBudget.Text.Trim(), sourceYearID));

            }

            ExecuteQueryList(queryList, "Successfully saved data", "Saved");
            btnAddChild.Checked = btnAddSource.Checked = false;

            void AddUpdateQuery()
            {
                queryList.Add(String.Format(
                    "UPDATE Source SET SourceName='{0}', Section='{1}' WHERE SourceID='{2}'",
                    txtSource.Text.Trim(), txtSection.Text.Trim(), sourceID));                
            }

            int CheckAvaiableInDatabase()
            {
                List<string> returnDataArray = 
                    commenMethods.SQLRead(String.Format("SELECT SourceID,Section FROM Source WHERE SourceName='{0}'",
                    txtSource.Text.Trim()), "SourceID Section");

                if (!commenMethods.ReturnListHasError(returnDataArray))
                {
                    if (returnDataArray[1] != txtSection.Text.Trim())
                    {
                        return -1;
                    }

                    return Convert.ToInt32(returnDataArray[0]);
                }

                return -1;
            }

            int NextID(string tableName)
            {
                List<string> arrayOfMaximumSourceID =
                    commenMethods.SQLRead(String.Format("SELECT MAX({0}.{0}ID) AS LastID FROM {0}", tableName), "LastID");

                if (!commenMethods.ReturnListHasError(arrayOfMaximumSourceID))
                {
                    return Convert.ToInt32(arrayOfMaximumSourceID[0]) + 1;
                }

                return 0;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<string> queryList = new List<string> { };

            string sourceYearID = TableSources.SelectedRows[0].Cells[2].Value.ToString(),
                sourceID = TableSources.SelectedRows[0].Cells[1].Value.ToString();

            // from remove MonthlyIncome table
            queryList.Add(String.Format("DELETE FROM MonthlyIncome WHERE SourceYearID='{0}'", sourceYearID));

            // from remove SourceYear table
            queryList.Add(String.Format("DELETE FROM SourceYear WHERE SourceYearID='{0}'", sourceYearID));

            // for check sourceID count in SourceYear table
            List<string> arrayOFSourceID = commenMethods.SQLRead(String.Format(
                "SELECT SourceID FROM SourceYear WHERE SourceID='{0}'", sourceID), "SourceID");

            if (!commenMethods.ReturnListHasError(arrayOFSourceID))
            {
                // if more than 1 remove sources in SourceYear table don't remove source from source table
                if (arrayOFSourceID.Count == 1)
                {
                    queryList.Add(String.Format("DELETE FROM Source WHERE SourceID='{0}'", sourceID));
                }
            }

            ExecuteQueryList(queryList, "Successfully removed source", "Remove");

            FindSourceData();
        }
    }
}
