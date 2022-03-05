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
using System.IO;
using System.Diagnostics;

namespace MASLMonthlyCapitalExpenditureStatement
{
    public partial class ExportWindow : Form
    {
        public ExportWindow()
        {
            InitializeComponent();
        }

        public Dictionary<string, bool> availabilityOfTables = new Dictionary<string, bool> { };
        public Dictionary<string, Guna2DataGridView> tableList = new Dictionary<string, Guna2DataGridView> { };

        public string selectedMonth = "JAN";

        List<Guna2CustomCheckBox> checkBoxList;

        private void ExportWindow_Load(object sender, EventArgs e)
        {
            checkBoxList = new List<Guna2CustomCheckBox> { MainTableCheckBox, BudgetTableCheckBox, IncomeTableCheckBox, ExpenditureTableCheckBox };

            // changed checked value of availability check boxes acording to the value of parent form availability check boxes
            for (byte i = 0; i < 4; i++)
            {
                checkBoxList[i].Checked = availabilityOfTables[checkBoxList[i].Tag.ToString()];
            }
        }

        private void AvailabilityCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // change value of availabilityOfTables array for the selected check box
            Guna2CustomCheckBox selectedAvailabilityCheckBox = (Guna2CustomCheckBox)sender;
            availabilityOfTables[selectedAvailabilityCheckBox.Tag.ToString()] = selectedAvailabilityCheckBox.Checked;
        }

        public static async Task PerpairingExportData(
            Dictionary<string, string[]> arrayOfOutputStrings,
            List<Guna2CustomCheckBox> checkBoxList,
            Dictionary<string, Guna2DataGridView> tableList,
            Guna2ProgressBar ProgressBarStatusOfExportProcess)
        {
            Guna2DataGridView selectedTable;
            string columnNames;
            string[] outputCsv;
            DataGridViewCell selectedCell;

            await Task.Run(() =>
            {          
                for (byte i = 0; i < 4; i++)
                {
                    if (checkBoxList[i].Checked)
                    {
                        selectedTable = tableList[checkBoxList[i].Tag.ToString()];
                        ProgressBarStatusOfExportProcess.Maximum = selectedTable.RowCount;

                        columnNames = "";
                        outputCsv = new string[selectedTable.Rows.Count + 1];

                        for (int j = 0; j < selectedTable.Columns.Count; j++)
                        {
                            columnNames += selectedTable.Columns[j].HeaderText.ToString().Replace(',', '\0') + ",";
                        }
                        outputCsv[0] += columnNames;

                        ProgressBarStatusOfExportProcess.Value = 0;

                        for (int j = 1; (j - 1) < selectedTable.Rows.Count; j++)
                        {
                            for (int k = 0; k < selectedTable.Columns.Count; k++)
                            {
                                selectedCell = selectedTable.Rows[j - 1].Cells[k];

                                if (selectedCell.Value != null)
                                {
                                    outputCsv[j] += selectedCell.Value.ToString().Trim().Replace(',', '\0') + ",";
                                }
                                else
                                {
                                    selectedCell.Value = "";
                                    outputCsv[j] += ',';
                                }
                            }

                            ProgressBarStatusOfExportProcess.Value += 1;
                        }

                        arrayOfOutputStrings.Add(checkBoxList[i].Tag.ToString(), outputCsv);
                    }
                }
            });
        }

        private async void btnExport_Click(object sender, EventArgs e)
        {
            Dictionary<string, string[]> arrayOfOutputStrings = new Dictionary<string, string[]> { };
            string savedFilePath;

            lblStatus.Text = "Perpairing Data ...";
            await PerpairingExportData(arrayOfOutputStrings, checkBoxList, tableList, ProgressBarStatusOfExportProcess);
            
            lblStatus.Text = "Saving Data ...";

            // create save file
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV (*.csv)|*.csv";
            bool fileError = false;

            if (ToggleSwitchIsSingleFile.Checked)
            {
                sfd.FileName = String.Format("Expenditure Report {0} {1}.csv",
                    selectedMonth, DateTime.Now.Date.ToString("yyyy-MM-dd"));

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." +
                                ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    if (!fileError)
                    {
                        try
                        {
                            int count = 0;
                            int totalRowCount = 0;

                            foreach (KeyValuePair<string, Guna2DataGridView> keyValuePair in tableList)
                            {
                                totalRowCount += keyValuePair.Value.RowCount;
                            }
                            string[] outputString = new string[totalRowCount + 8];

                            for (byte i = 0; i < 4; i++)
                            {
                                if (checkBoxList[i].Checked)
                                {
                                    foreach (string cellData in arrayOfOutputStrings[checkBoxList[i].Tag.ToString()])
                                    {
                                        outputString[count] += cellData + ',';
                                        count += 1;
                                    }

                                    outputString[count] += ",";
                                    count += 1;
                                }
                            }

                            File.WriteAllLines(sfd.FileName, outputString, Encoding.UTF8);

                            savedFilePath = sfd.FileName;

                            OpenExportedFile();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message, "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                sfd.FileName = String.Format("Expenditure Report {0}.csv", selectedMonth);

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        savedFilePath = Path.GetDirectoryName(sfd.FileName) + '\\' + selectedMonth + " sExpenditure Report";
                        List<string> arraySaveFileNames = new List<string>
                            {
                                "Table Last Month Total Expenditure", "Table Budget Details",
                                "Table Income Details", "Table Details of Expenditures of Activties"
                            };

                        if (Directory.Exists(savedFilePath))
                        {
                            try
                            {
                                Directory.Delete(savedFilePath);
                            }
                            catch (Exception ex)
                            {
                                fileError = true;
                                MessageBox.Show("It wasn't possible to write the data to the disk." +
                                    ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            Directory.CreateDirectory(savedFilePath);
                        }

                        if (!fileError)
                        {
                            for (byte i = 0; i < 4; i++)
                            {
                                if (checkBoxList[i].Checked)
                                {
                                    File.WriteAllLines(savedFilePath + '\\' + arraySaveFileNames[i] + ".csv", arrayOfOutputStrings[checkBoxList[i].Tag.ToString()], Encoding.UTF8);
                                }
                            }

                            OpenExportedFile();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error :" + ex.Message, "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }

            void OpenExportedFile()
            {
                lblStatus.Text = "Saved";

                // Open Exported file
                if (MessageBox.Show("Data Exported Successfully! Do You Want To Open It?",
                    "Information", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information) == DialogResult.Yes && !fileError)
                {
                    try
                    {
                        if (ToggleSwitchIsSingleFile.Checked)
                        {
                            Process.Start(savedFilePath);
                        }
                        else
                        {
                            openInExplorer(savedFilePath);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Can't Open Saved File" + ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        static void openInExplorer(string path)
        {
            string cmd = "explorer.exe";
            string arg = "/select, " + path;
            Process.Start(cmd, arg);
        }
    }
}
