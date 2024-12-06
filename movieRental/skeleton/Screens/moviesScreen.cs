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
    public partial class moviesScreen : UserControl
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        // Data
        public List<Movie> Movies;

        public moviesScreen()
        {
            InitializeComponent();

            Movies = RetrieveMovies();
            foreach(var movie in Movies)
            {
                movie.actorsList = RetrieveActors(movie.MovieID);
            }
            EmpDataView.DataSource = Movies;

            AddEditButtonColumn();
            EmpDataView.CellContentClick += EmpDataView_CellContentClick;
        }

        private void moviesScreen_Load(object sender, EventArgs e)
        {

        }

        // Data Source
        private List<Movie> RetrieveMovies()
        {
            var movies = new List<Movie>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String nameQuery = "SELECT Movie.Name, Movie.Type, Movie.DistributionFee, Movie.NumOfCopies, " +
                    "(Movie.NumOfCopies - (SELECT COUNT(*) FROM Ordered WHERE Ordered.MovieID = Movie.MID AND ReturnDate is null)) as CopiesAvailable, MID FROM Movie";
                using (SqlCommand cmd = new SqlCommand(nameQuery, conn))
                {

                    try
                    {
                        SqlDataReader myReader = cmd.ExecuteReader();

                        while (myReader.Read())
                        {
                            movies.Add(new Movie()
                            {
                                title = myReader.GetString(0),
                                genre = myReader.GetString(1),
                                fee = myReader.GetDecimal(2),
                                totalCopies = myReader.GetInt32(3),
                                availableCopies = myReader.GetInt32(4),
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
            return movies;
        }

        private List<Actor> RetrieveActors(int MID)
        {
            var actors = new List<Actor>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String nameQuery =
                    $"select Actor.* from AppearsIn, Actor where AppearsIn.ActorID = Actor.AID and MovieID = {MID}";
                using (SqlCommand cmd = new SqlCommand(nameQuery, conn))
                {

                    try
                    {
                        SqlDataReader myReader = cmd.ExecuteReader();

                        while (myReader.Read())
                        {
                            actors.Add(new Actor()
                            {
                                id = myReader.GetInt32(0),
                                firstName = myReader.GetString(1),
                                lastName = myReader.GetString(2),
                                gender = myReader.GetString(3),
                                dateOfBirth = myReader.GetDateTime(4),
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
            return actors;
        }

        // Add a button column for editing
        private void AddEditButtonColumn()
        {
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();

            editButtonColumn.Name = "Edit";
            editButtonColumn.HeaderText = "Edit";
            editButtonColumn.Text = "Edit";
            editButtonColumn.UseColumnTextForButtonValue = true;

            EmpDataView.Columns.Add(editButtonColumn);
        }

        // Handle the click event for the Edit button
        private void EmpDataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && EmpDataView.Columns[e.ColumnIndex].Name == "Edit")
            {
                Movie selectedMovie = (Movie)EmpDataView.Rows[e.RowIndex].DataBoundItem;
                SwitchToScreen(new editMovie(selectedMovie));
            }
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

        private void addMovieButton_Click(object sender, EventArgs e)
        {
            SwitchToScreen(new addMovie());
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
        }

        private void movieSearch__TextChanged(object sender, EventArgs e)
        {
            var temp = Movies.Where(
                c => c.title.Contains(movieSearch.Text))
                .ToList();
            EmpDataView.DataSource = temp;
        }
    }
}
