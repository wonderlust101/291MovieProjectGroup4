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
    public partial class rentalScreen : UserControl
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        // Data [Main and searchView]
        public List<Customer> Customers { get; private set; }
        public List<Customer> CustomerSearchView { get; private set; }

        // Stores customer info for order history/queue
        public Customer CurrentCustomer { get; private set; }

        public rentalScreen()
        {
            InitializeComponent();

            // Retrieves Customer data
            Customers = RetrieveCustomers();
            CustomerSearchView = new List<Customer>(Customers);

            // Sets Data Source for Customer table
            customerDataView.AutoGenerateColumns = false;
            customerDataView.DataSource = CustomerSearchView;

            addAttributeColoumns();
            AddEditButtonColumn();
        }

        private void rentalScreen_Load(object sender, EventArgs e)
        {

        }


        // Data Source
        private List<Customer>? RetrieveCustomers()
        {
            var customers = new List<Customer>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String nameQuery = "SELECT CID, FirstName, FamilyName, AccountNumber FROM Customer";
                using (SqlCommand cmd = new SqlCommand(nameQuery, conn))
                {

                    try
                    {
                        SqlDataReader myReader = cmd.ExecuteReader();

                        while (myReader.Read())
                        {
                            customers.Add(new Customer()
                            {
                                id = myReader.GetInt32(0),
                                firstName = myReader.GetString(1),
                                lastName = myReader.GetString(2),
                                accountNumber = myReader.GetInt32(3)
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
            return customers;
        }

        private List<CustomerOrder> RetrieveCustomerOrders(int customerID)
        {
            var orders = new List<CustomerOrder>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String nameQuery =
                    $"SELECT Movie.Name, Ordered.MovieRating, Ordered.CheckOutDate, Ordered.ReturnDate " +
                    $"FROM Ordered, Movie " +
                    $"WHERE Ordered.MovieID = Movie.MID and CustomerID = {customerID}";

                using (SqlCommand cmd = new SqlCommand(nameQuery, conn))
                {

                    try
                    {
                        SqlDataReader myReader = cmd.ExecuteReader();

                        while (myReader.Read())
                        {
                            var temp = new CustomerOrder()
                            {
                                MovieName = myReader.GetString(0),
                                CheckOutDate = myReader.GetDateTime(2)
                            };

                            // Have to check if null for both Rating & returnDate
                            if (myReader.IsDBNull(1)) temp.CustomerRating = null;
                            else temp.CustomerRating = myReader.GetInt32(1);

                            if (myReader.IsDBNull(3)) temp.ReturnDate = null;
                            else temp.ReturnDate = myReader.GetDateTime(3);

                            orders.Add(temp);
                        }

                        myReader.Close();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
            return orders;

        }

        private List<CustomerQueue> RetrieveCustomerQueue()
        {
            throw new NotImplementedException();
        }

        // Add certain attribute coloumns manually
        private void addAttributeColoumns()
        {
            customerDataView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Name",
                DataPropertyName = "fullName", // Matches the computed property in the Customer class
            });


            customerDataView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Account Number",
                DataPropertyName = "accountNumber", // Matches the property in the Customer class
            });
        }

        // Add a button column for editing
        private void AddEditButtonColumn()
        {
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();

            editButtonColumn.Name = "ViewButton";
            editButtonColumn.HeaderText = "";
            editButtonColumn.Text = "View";
            editButtonColumn.UseColumnTextForButtonValue = true;

            customerDataView.Columns.Add(editButtonColumn);
        }

        // Order History datagrid
        private void SetOrderTable(int customerID)
        {
            List<CustomerOrder> order = RetrieveCustomerOrders(customerID);
            rentalHistoryDataView.DataSource = order;
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
            if (CurrentCustomer == null)
            {
                MessageBox.Show("No customer selected!");
            }
            else
            {
                SwitchToScreen(new customerQueue(CurrentCustomer));
            }
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
        }

        private void customerDataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && customerDataView.Columns[e.ColumnIndex].Name == "ViewButton")
            {
                int row = e.RowIndex;
                int column = e.ColumnIndex;
                int accountNumber = (int)customerDataView.Rows[row].Cells[1].Value;

                // Sets Current Customer for Order History
                CurrentCustomer = Customers.First(customer => customer.accountNumber == accountNumber);

                SetOrderTable(CurrentCustomer.id);
                rentalHistoryLabel.Text = $"{CurrentCustomer.firstName}'s Rental History";

            }
        }

        private void customerSearch__TextChanged(object sender, EventArgs e)
        {
            CustomerSearchView = Customers.Where(
                c => c.fullName.Contains(customerSearch.Text))
                .ToList();
            customerDataView.DataSource = CustomerSearchView;
        }

        private void logOutClick(object sender, EventArgs e)
        {
            // Dispose of current controls if needed
            foreach (Control control in this.Controls.OfType<UserControl>().ToList())
            {
                control.Dispose();
            }

            // Clear all controls on the current form
            this.Controls.Clear();

            // Create and add the Login control back to the form
            LoginUserControl loginScreen = new LoginUserControl();
            this.Controls.Add(loginScreen);
            loginScreen.Dock = DockStyle.Fill;
        }
    }
}
