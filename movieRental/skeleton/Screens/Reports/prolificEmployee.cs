using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;
using System.Configuration;
using System.Drawing.Text;
using System.Globalization;

namespace movieRental
{
    public partial class prolificEmployee : UserControl
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        // Data
        public List<Employee> employees;

        public prolificEmployee()
        {
            InitializeComponent();

            PopulateMonthComboBox();
        }

        // Data Source
        private List<Employee>? retrieveTopEmployeesOfMonth(string selectedMonth)
        {
            var employees = new List<Employee>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String query = "SELECT * FROM Employee"; // Insert Query here
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    try
                    {
                        SqlDataReader myReader = cmd.ExecuteReader();

                        while (myReader.Read())
                        {
                            employees.Add(new Employee()
                            {
                                socialSecurityNum = myReader.GetString(1),
                                firstName = myReader.GetString(2),
                                lastName = myReader.GetString(3),
                                startDate = myReader.GetDateTime(10),
                            });

                        }

                        myReader.Close();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
            return employees;
        }

        private void prolificEmployee_Load(object sender, EventArgs e)
        {

        }

        // Switch Screen
        private void SwitchToScreen(UserControl newScreen)
        {
            Form parentForm = this.FindForm();

            if (parentForm != null)
            {
                // Dispose of existing controls
                foreach (Control control in parentForm.Controls.OfType<UserControl>().ToList())
                {
                    control.Dispose();
                }

                // Clear and add the new screen
                parentForm.Controls.Clear();
                parentForm.Controls.Add(newScreen);
                newScreen.Dock = DockStyle.Fill;
            }
        }

        // Combo Box

        private void PopulateMonthComboBox()
        {
            var months = DateTimeFormatInfo.CurrentInfo.MonthNames;

            monthComboBox.Items.Clear();

            foreach (var month in months)
            {
                if (!string.IsNullOrEmpty(month))
                {
                    monthComboBox.Items.Add(month);
                }
            }
        }

        private void monthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedMonth = monthComboBox.SelectedItem.ToString();

            topEmployeeDataView.DataSource = null;
            topEmployeeDataView.Columns.Clear();

            employees = retrieveTopEmployeesOfMonth(selectedMonth);

            topEmployeeDataView.AutoGenerateColumns = false;
            topEmployeeDataView.DataSource = employees;
            addTopEmployeesAttributeColoumns();
        }

        private void addTopEmployeesAttributeColoumns()
        {
            topEmployeeDataView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Name",
                DataPropertyName = "fullName",
            });

            topEmployeeDataView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Start Date",
                DataPropertyName = "startDate",
            });
        }

        // Buttons

        private void CustomersButton_Click(object sender, EventArgs e)
        {
            SwitchToScreen(new customerScreen());
        }

        private void MoviesButton_Click(object sender, EventArgs e)
        {
            SwitchToScreen(new moviesScreen());
        }

        private void RentalsButton_Click(object sender, EventArgs e)
        {
            SwitchToScreen(new rentalScreen());
        }

        private void ReportsButton_Click(object sender, EventArgs e)
        {
            SwitchToScreen(new reportScreen());
        }

        private void viewQueueButton_Click(object sender, EventArgs e)
        {
            // Where is this button? Delete?
            //SwitchToScreen(new customerQueue());
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
        }
    }
}
