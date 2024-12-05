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

namespace movieRental
{
    public partial class customerQueue : UserControl
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        // Data
        public List<Employee> Employees { get; private set; }
        public List<CustomerQueue> CurrentCustomerQueue { get; private set; }
        public Customer CurrentCustomer { get; private set; }


        public customerQueue(Customer customer)
        {
            InitializeComponent();

            CurrentCustomer = customer;
            CustomerTabName.Text = $"{CurrentCustomer.firstName}'s Queue";

            Employees = RetrieveEmployees();
            CurrentCustomerQueue = RetrieveCustomerQueue();

            customerQueueDataView.AutoGenerateColumns = false;
            customerQueueDataView.DataSource = CurrentCustomerQueue;
            employeeSelector.DataSource = Employees;

            addAttributeColoumns();
            AddEditButtonColumn();
        }

        // Data Source
        private List<Employee> RetrieveEmployees()
        {
            var employees = new List<Employee>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String nameQuery =
                    "SELECT EID, FirstName, FamilyName FROM Employee";
                using (SqlCommand cmd = new SqlCommand(nameQuery, conn))
                {

                    try
                    {
                        SqlDataReader myReader = cmd.ExecuteReader();

                        while (myReader.Read())
                        {
                            employees.Add(new Employee()
                            {
                                id = myReader.GetInt32(0),
                                firstName = myReader.GetString(1),
                                lastName = myReader.GetString(2)
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

        private List<CustomerQueue> RetrieveCustomerQueue()
        {
            var queue = new List<CustomerQueue>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String nameQuery =
                    "SELECT Movie.Name, Movie.Type, Movie.NumOfCopies, " +
                    "(Movie.NumOfCopies - (SELECT COUNT(*) FROM Ordered WHERE Ordered.MovieID = Queue.MovieID AND ReturnDate is null)) as CopiesAvailable, " + "Queue.DateTimeAdded, Movie.MID FROM Movie, Queue " +
                  $"WHERE Movie.MID = Queue.MovieID AND Queue.CustomerID = " + CurrentCustomer.id + " AND Queue.Waiting = 1";

                using (SqlCommand cmd = new SqlCommand(nameQuery, conn))
                {

                    try
                    {
                        SqlDataReader myReader = cmd.ExecuteReader();

                        while (myReader.Read())
                        {
                            queue.Add(new CustomerQueue()
                            {
                                MovieName = myReader.GetString(0),
                                MovieGenre = myReader.GetString(1),
                                TotalCopies = myReader.GetInt32(2),
                                CopiesAvailable = myReader.GetInt32(3),
                                DateAdded = myReader.GetDateTime(4),
                                MovieID = myReader.GetInt32(5)
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
            return queue;
        }

        // Add certain attribute coloumns manually
        private void addAttributeColoumns()
        {
            customerQueueDataView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Movie Name",
                DataPropertyName = "MovieName", // Matches the computed property in the Customer class
            });


            customerQueueDataView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Movie Genre",
                DataPropertyName = "MovieGenre",
            });

            customerQueueDataView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Total Copies",
                DataPropertyName = "TotalCopies",
            });

            customerQueueDataView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Copies Available",
                DataPropertyName = "CopiesAvailable",
            });

            customerQueueDataView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Date Added",
                DataPropertyName = "DateAdded",
            });
        }

        // Add a button column for editing
        private void AddEditButtonColumn()
        {
            DataGridViewButtonColumn RentButton = new DataGridViewButtonColumn();

            RentButton.Name = "RentButton";
            RentButton.HeaderText = "";
            RentButton.Text = "Rent Movie Out";
            RentButton.UseColumnTextForButtonValue = true;

            customerQueueDataView.Columns.Add(RentButton);
        }

        // Remove from queue / Add to order
        private bool RentMovieFromQueue(int customerID, int movieID, int employeeID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String nameQuery =
                    $"UPDATE Queue SET Waiting = 0 WHERE CustomerID = {customerID} AND MovieID = {movieID};" +
                    $"INSERT INTO Ordered (CustomerID, MovieID, EmployeeID) " + "" +
                    $"VALUES ({customerID}, {movieID}, {employeeID});";
                using (SqlCommand cmd = new SqlCommand(nameQuery, conn))
                {

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        MessageBox.Show($"Movie was rented out!");
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                        return false;
                    }
                }
            }
            return true;
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

        private void customerQueue_Load(object sender, EventArgs e)
        {

        }

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

        private void LogOutButton_Click(object sender, EventArgs e)
        {
        }

        private void customerQueueDataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && customerQueueDataView.Columns[e.ColumnIndex].Name == "RentButton")
            {

                int row = e.RowIndex;
                int copiesAvailable =
                    (int)customerQueueDataView.Rows[row].Cells[3].Value;

                if (copiesAvailable <= 0)
                {
                    MessageBox.Show($"No Copies Available to rent out!");
                }
                else
                {
                    var queue = (CustomerQueue)customerQueueDataView.CurrentRow.DataBoundItem;
                    Employee employee = (Employee)employeeSelector.SelectedItem;
                    bool rented = RentMovieFromQueue(CurrentCustomer.id, queue.MovieID, employee.id);

                    if (rented)
                    {
                        CurrentCustomerQueue = RetrieveCustomerQueue();
                        customerQueueDataView.DataSource = CurrentCustomerQueue;
                    }
                }

            }
        }

        private void movieSearch__TextChanged(object sender, EventArgs e)
        {
            var temp = CurrentCustomerQueue.Where(
                c => c.MovieName.Contains(movieSearch.Text))
                .ToList();
            customerQueueDataView.DataSource = temp;
        }
    }
}
