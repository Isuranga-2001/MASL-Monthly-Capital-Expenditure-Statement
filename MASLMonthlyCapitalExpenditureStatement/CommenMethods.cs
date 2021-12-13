using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MASLMonthlyCapitalExpenditureStatement
{
    class CommenMethods
    {
        SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = '"
                + Properties.Settings.Default.DatabaseLocation + "'; Integrated Security = True");

        public List<string> MonthList = new List<string>
        {
            "JAN","FEB","MAR","APR","MAY","JUN","JUL","AUG","SEP","OCT","NOV","DEC"
        };

        bool AllowEditing = true;

        public List<string> SQLRead(string query, string FieldNames)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    List<string> ReturnList = new List<string> { };
                    while (reader.Read())
                    {
                        string Value;
                        string[] FieldNameList = FieldNames.Split();
                        foreach (var Name in FieldNameList)
                        {
                            try
                            {
                                try
                                {
                                    Value = reader.GetString(reader.GetOrdinal(Name)).ToString();
                                }
                                catch
                                {
                                    try
                                    {
                                        Value = reader.GetDouble(reader.GetOrdinal(Name)).ToString();
                                    }
                                    catch
                                    {
                                        Value = reader.GetInt32(reader.GetOrdinal(Name)).ToString();
                                    }
                                }
                            }
                            catch
                            {
                                Value = "";
                            }
                            ReturnList.Add(Value);
                        }
                    }
                    conn.Close();
                    return ReturnList;
                }
                conn.Close();
                return new List<string> { };
            }
            catch
            {
                conn.Close();
                return null;
            }
        }

        public bool ExecuteSQL(string query)
        {
            try
            {                
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader SQL = cmd.ExecuteReader();

                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("An error found!" + e.Message, "Somthing Went Wrong!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                return false;
            }
        }

        public bool RetrieveDataOnDataGridView(string query, Guna2DataGridView SelectedDataGridView, int StartColumnIndex, int ColumnRange)
        {
            try
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable Dt = new DataTable();
                sda.Fill(Dt);

                Guna2DataGridView dataGridView = SelectedDataGridView;
                dataGridView.Rows.Clear();
                int n, j;
                foreach (DataRow items in Dt.Rows)
                {
                    n = dataGridView.Rows.Add();
                    j = 0;

                    for (var i = StartColumnIndex; i <= ColumnRange; i++) 
                    {
                        dataGridView.Rows[n].Cells[i].Value = items[j].ToString();
                        j += 1;
                    }
                }

                conn.Close();
                return true;
            }
            catch
            {
                conn.Close();
                return false;
            }
        }

        public void NavigateTo(string btnNavigationName)
        {
            if (btnNavigationName == "Dash")
            {

            }
            else if (btnNavigationName == "Expen") 
            {
                Expenditure form = new Expenditure();
                form.Show();
            }
            else if (btnNavigationName == "Act")
            {
                Activity form = new Activity();
                form.Show();
            }
            else if (btnNavigationName == "Login")
            {
                Login form = (Login)Properties.Settings.Default.LoginScreen;
                form.Show();
            }
            else if (btnNavigationName == "Inc")
            {
                Income form = new Income();
                form.Show();
            }
            else if (btnNavigationName == "Re")
            {
                Report form = new Report();
                form.Show();
            }
        }

        public string SaveOnlyIntegers(string inputString)
        {
            byte count = 0;
            foreach (char c in inputString)
            {
                if (c == '.' && count < 1)
                {
                    count += 1;
                    continue;
                }
                else if ((!Char.IsNumber(c)) && inputString.Trim() != "")
                {
                    inputString = inputString.Remove(inputString.IndexOf(c), 1);
                }
            }

            return inputString;
        }

        public void FilterOnlyInt(Guna2TextBox SelectedTextBox, int NumberOfDots, bool AddComma, int Round)
        {
            if (SelectedTextBox.Text.Trim() != "" && AllowEditing)
            {
                AllowEditing = false;

                int CountDot = NumberOfDots;
                string InputString = SelectedTextBox.Text;
                // filter only numbers and dot

                InputString = InputString.Replace(",", "");
                char[] originalText = InputString.ToCharArray();

                foreach (char c in originalText)
                {
                    if (c == '.' && CountDot > 0)
                    {
                        CountDot -= 1;
                        continue;
                    }
                    else if (!(Char.IsNumber(c)))
                    {
                        if (InputString.Trim() != "")
                            InputString = InputString.Remove(InputString.Length - 1);
                    }
                }

                if (InputString.Trim() != "")
                {
                    if (InputString[InputString.Length - 1] != '.' && NumberOfDots == 1)
                    {
                        InputString = Math.Round(float.Parse(InputString), Round).ToString();
                    }

                    if (AddComma)
                    {
                        string[] StringParts = InputString.Split('.');

                        char[] IntegerPartOfNumber = StringParts[0].ToCharArray();

                        if (IntegerPartOfNumber.Length > 3)
                        {
                            string OutputString = "";
                            int Count = StringParts[0].Length / 3;

                            for (var i = 0; i < Count; i++)
                            {
                                OutputString = "," + StringParts[0].Substring(StringParts[0].Length - 3) + OutputString;
                                StringParts[0] = StringParts[0].Remove(StringParts[0].Length - 3);
                            }
                            OutputString = StringParts[0] + OutputString;

                            if (OutputString[0] == ',')
                            {
                                OutputString = OutputString.Remove(0, 1);
                            }

                            if (StringParts.Length > 1)
                            {
                                OutputString += "." + StringParts[1];
                            }

                            SelectedTextBox.Text = OutputString;
                        }
                        else
                        {
                            SelectedTextBox.Text = InputString;
                        }
                    }
                    else
                    {
                        SelectedTextBox.Text = InputString;
                    }

                    SelectedTextBox.Select(SelectedTextBox.Text.Length, 0);
                }

                AllowEditing = true;
            }            
        }

        public bool ReturnListHasError(List<string> ReturnList)
        {
            if (ReturnList != null)
            {
                if (ReturnList.Count > 0)
                {
                    if (ReturnList[0] != "")
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public DataTable RetrieveDataOnDataTable(string query)
        {
            try
            {
                DataTable Dt = new DataTable();

                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                Dt = new DataTable();
                sda.Fill(Dt);

                conn.Close();
                return Dt;
            }
            catch
            {
                conn.Close();
                return null;
            }
        }

        public int FindMonth(string MonthName)
        {
            for (int i = 1; i <= 12; i++) 
            {
                if (MonthList[i - 1] == MonthName) 
                {
                    return i;
                }
            }

            return DateTime.Now.Month;
        }

        public void UpdateErrorMessageShow()
        {
            MessageBox.Show("Something Went Wrong. Can't update Database", "Error Found",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void UpdateChart(string[] ItemNoParts, string BudgetCode, string selectedYear, string Allocation, Chart ChartExpenditure, Guna2NotificationPaint NotificationPaintUpdateExpenditure)
        {
            string Query = String.Format("SELECT SUM(ExpenditureMonth.Expenditure) AS TotalExpenditure " +
                    "FROM ExpenditureMonth,ActivityCode,MainActivity " +
                    "WHERE ExpenditureMonth.ActivityCodeID=ActivityCode.ActivityCodeID " +
                    "AND MainActivity.ActivityID=ActivityCode.ActivityID " +
                    "AND MainActivity.Year='{0}'", selectedYear);

            if (BudgetCode != "" || ItemNoParts[0] != "") 
            {
                Query += String.Format(" AND MainActivity.BudgectCode='{0}' AND MainActivity.ActivityID='{1}'", BudgetCode, ItemNoParts[0]);
            }

            if (ItemNoParts.Length >= 2)
            {
                Query += String.Format(" AND ActivityCode.INSub1='{0}'", ItemNoParts[1]);
            }

            if (ItemNoParts.Length == 3)
            {
                Query += String.Format(" AND ActivityCode.INSub2='{0}'", ItemNoParts[2]);
            }

            float CumulativeExpenditure = 0, CumulativeAllocation = 0;

            if (Allocation.Trim() != "")
            {
                CumulativeAllocation = float.Parse(Allocation.Trim().Replace(",", "")) / 12;
            }

            List<string> ReturnValue;

            for (int i = 1; i <= 12; i++)
            {
                ChartExpenditure.Series[0].Points.AddXY(MonthList[i - 1], CumulativeAllocation * i);

                if (i <= DateTime.Now.Month)
                {
                    ReturnValue = SQLRead(Query + String.Format(" AND ExpenditureMonth.Month='{0}'", i), "TotalExpenditure");

                    if (ReturnValue != null)
                    {
                        if (ReturnValue.Count > 0)
                        {
                            if (ReturnValue[0].Trim() != "")
                            {
                                CumulativeExpenditure += float.Parse(ReturnValue[0].Trim());
                                ChartExpenditure.Series[1].Points.AddXY(MonthList[i - 1], CumulativeExpenditure);

                                continue;
                            }
                        }
                    }

                    if (i < DateTime.Now.Month)
                    {
                        ChartExpenditure.Series[1].Points.AddXY(MonthList[i - 1], CumulativeExpenditure);
                    }
                    else
                    {
                        if (NotificationPaintUpdateExpenditure != null)
                        {
                            NotificationPaintUpdateExpenditure.Visible = true;
                        }
                    }
                }
            }
        }

    }
}
