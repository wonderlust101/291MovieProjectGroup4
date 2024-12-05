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
    public partial class grossingMovies : UserControl
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        // Data
        public List<Movie> Movies;

        public grossingMovies()
        {
            InitializeComponent();

            PopulateMonthComboBox();
        }

        private void grossingMovies_Load(object sender, EventArgs e)
        {
        }

        // Data Source
        private List<Movie>? retrieveTopMoviesOfMonth(string selectedMonth)
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

            topMovieDataView.DataSource = null;
            topMovieDataView.Columns.Clear();

            Movies = retrieveTopMoviesOfMonth(selectedMonth);

            topMovieDataView.AutoGenerateColumns = false;
            topMovieDataView.DataSource = Movies;
            addTopMovieAttributeColoumns();
        }

        private void addTopMovieAttributeColoumns()
        {
            topMovieDataView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Title",
                DataPropertyName = "title",
            });

            topMovieDataView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Genre",
                DataPropertyName = "genre",
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
