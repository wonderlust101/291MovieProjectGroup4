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
    public partial class recommendedMovie : UserControl
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        //Data
        public List<Customer> Customers;
        public List<Movie> Movies;

        public recommendedMovie()
        {
            InitializeComponent();

            Customers = retrieveCustomers();

            customerDataView.AutoGenerateColumns = false;
            customerDataView.DataSource = Customers;
            addCustomerAttributeColoumns();
            addEditButtonColumn();
        }

        private void recommendedMovie_Load(object sender, EventArgs e)
        {

        }

        // Data Source
        private List<Customer>? retrieveCustomers()
        {
            var customers = new List<Customer>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String query = "SELECT * FROM Customer";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    try
                    {
                        SqlDataReader myReader = cmd.ExecuteReader();

                        while (myReader.Read())
                        {
                            customers.Add(new Customer()
                            {
                                firstName = myReader.GetString(1),
                                lastName = myReader.GetString(2),
                                accountNumber = myReader.GetInt32(7),
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

        private List<Movie>? retrieveRecommendedMovies(int actorID)
        {
            var movies = new List<Movie>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String query = "SELECT * FROM Movie"; // Insert Query here
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    try
                    {
                        SqlDataReader myReader = cmd.ExecuteReader();

                        while (myReader.Read())
                        {
                            movies.Add(new Movie()
                            {
                                title = myReader.GetString(1),
                                genre = myReader.GetString(2),
                                totalCopies = myReader.GetInt32(4),
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
            return movies;
        }

        // Add certain attribute coloumns manually
        private void addCustomerAttributeColoumns()
        {

            customerDataView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Name",
                DataPropertyName = "fullName",
            });

            customerDataView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Account Number",
                DataPropertyName = "accountNumber",
            });
        }

        private void addRecommendedMovieAttributeColoumns()
        {
            recommendedMovieDataView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Title",
                DataPropertyName = "title",
            });

            recommendedMovieDataView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Genre",
                DataPropertyName = "genre",
            });

            recommendedMovieDataView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Total Copies",
                DataPropertyName = "totalCopies",
            });
        }

        // Add a button column for editing
        private void addEditButtonColumn()
        {
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();

            editButtonColumn.Name = "Select";
            editButtonColumn.HeaderText = "Select";
            editButtonColumn.Text = "Select";
            editButtonColumn.UseColumnTextForButtonValue = true;

            customerDataView.Columns.Add(editButtonColumn);
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

        private void customerDataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && customerDataView.Columns[e.ColumnIndex].Name == "Select")
            {
                var selectedCustomer = customerDataView.Rows[e.RowIndex].DataBoundItem as Customer;

                if (selectedCustomer != null)
                {
                    // Retrieve customers for the selected customer
                    var customers = retrieveRecommendedMovies(selectedCustomer.id);

                    // Clear existing data and columns
                    recommendedMovieDataView.DataSource = null;
                    recommendedMovieDataView.Columns.Clear();

                    // Configure columns and bind data
                    recommendedMovieDataView.AutoGenerateColumns = false;
                    addRecommendedMovieAttributeColoumns();
                    recommendedMovieDataView.DataSource = customers;

                    // Update label
                    recomendedMovieLabel.Text = $"Recommended for {selectedCustomer.fullName}:";
                }
            }
        }
    }
}
