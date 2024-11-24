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

namespace movieRental
{
    public partial class mainMenu : UserControl
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        public List<Customer> Customers;
        public List<Movie> Movies;
        public mainMenu()
        {
            InitializeComponent();

            Customers = RetrieveCustomers();
            Movies = RetrieveMovies();
            EmpDataView.DataSource = Customers;

        }

        private List<Movie> RetrieveMovies()
        {
            var movies = new List<Movie>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String nameQuery = "SELECT * FROM Movie";
                using (SqlCommand cmd = new SqlCommand(nameQuery, conn))
                {

                    try
                    {
                        SqlDataReader myReader = cmd.ExecuteReader();

                        while (myReader.Read())
                        {
                            movies.Add(new Movie()
                            {
                                Title = myReader.GetString(1),
                                Genre = myReader.GetString(2),
                                Fee = myReader.GetDecimal(3),
                                TotalCopies = myReader.GetInt32(4)
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

        private List<Customer>? RetrieveCustomers()
        {
            var customers = new List<Customer>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String nameQuery = "SELECT * FROM Customer";
                using (SqlCommand cmd = new SqlCommand(nameQuery, conn))
                {

                    try
                    {
                        SqlDataReader myReader = cmd.ExecuteReader();

                        while (myReader.Read())
                        {
                            customers.Add(new Customer()
                            {
                                Name = myReader.GetString(1) + " " + myReader.GetString(2),
                                Email = myReader.GetString(8),
                                AccountNumber = myReader.GetInt32(7),
                                CreationDate = myReader.GetDateTime(12)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void empLabel_Click(object sender, EventArgs e)
        {

        }

        private void mainMenu_Load(object sender, EventArgs e)
        {

        }

        private void customerLabel_Click(object sender, EventArgs e)
        {

        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
        }

        private void CustomersButton_Click(object sender, EventArgs e)
        {
            EmpTabName.Text = "Customers";
            EmpDataView.DataSource = Customers;
        }

        private void EmpMovieButton_Click(object sender, EventArgs e)
        {
            EmpTabName.Text = "Movies";
            EmpDataView.DataSource = Movies;
        }

        private void EmpRentalsButton_Click(object sender, EventArgs e)
        {
            EmpTabName.Text = "Rentals";
        }

        private void ReportsButton_Click(object sender, EventArgs e)
        {
            EmpTabName.Text = "Reports";
        }
    }
}
