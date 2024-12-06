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
    public partial class editMovie : UserControl
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        // Data
        private List<Actor> Actors; // Actor
        private List<Actor> SelectedActors = new List<Actor>();
        private List<string> Genre = new List<string>()
        {
            "Comedy",
            "Drama",
            "Action",
            "Foreign"
        };
        private int minCopies;

        private Movie movieToEdit;

        public editMovie(Movie movie)
        {
            InitializeComponent();

            // Filling fields with Selected Movie
            movieToEdit = movie;
            titleInput.PlaceholderText = movieToEdit.title;
            feesInput.PlaceholderText = movieToEdit.fee.ToString();
            copiesInput.PlaceholderText = movieToEdit.totalCopies.ToString();
            minCopies = movieToEdit.totalCopies - movieToEdit.availableCopies;
            numOfCopies.Text = minCopies.ToString();

            genreSelector.DataSource = Genre;
            genreSelector.SelectedItem = movie.genre;

            // Add all actor data to checkList
            Actors = RetrieveActors();
            foreach (var actor in Actors)
            {
                actorCheckList.Items.Add(actor);
            }
            // Select actors in movie currently
            foreach (var actor in movie.actorsList)
            {
                int index = Actors.FindIndex(a => a.id == actor.id);
                actorCheckList.SetItemChecked(index, true);
                SelectedActors.Add(actor);
            }

        }
        // Data Source
        private List<Actor> RetrieveActors()
        {
            var actors = new List<Actor>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String nameQuery =
                    "SELECT * FROM Actor";
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

        // Create query string
        private string MovieUpdateQueryStringBuilder()
        {
            string name = movieToEdit.title;
            string genre = genreSelector.SelectedItem.ToString();
            string fee = movieToEdit.fee.ToString();
            string copies = movieToEdit.totalCopies.ToString();
            if (!string.IsNullOrEmpty(titleInput.Text))
                name = titleInput.Text;
            if (!string.IsNullOrEmpty(feesInput.Text))
                fee = feesInput.Text;
            if (!string.IsNullOrEmpty(copiesInput.Text))
                copies = copiesInput.Text;

            string query =
                $"UPDATE Movie SET Name = \'{name}\', Type = \'{genre}\', DistributionFee = {fee}, NumOfCopies = {copies} where MID = {movieToEdit.MovieID}; DELETE FROM AppearsIn where MovieID = {movieToEdit.MovieID}";

            foreach (var actor in SelectedActors)
            {
                query +=
                    $"INSERT INTO AppearsIn (ActorID, MovieID) " +
                    $"VALUES ({actor.id}, {movieToEdit.MovieID});";
            }

            return query;
        }

        // Insert new movie
        private bool ExecuteQuery(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String nameQuery = query;
                using (SqlCommand cmd = new SqlCommand(nameQuery, conn))
                {

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
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

        private void editMovie_Load(object sender, EventArgs e)
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

        private void deleteMovieButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            string query = "DELETE FROM Movie WHERE MID = " + movieToEdit.MovieID;
            bool deleteMovie = ExecuteQuery(query);
            if (deleteMovie)
            {
                MessageBox.Show($"Movie deleted!");
                SwitchToScreen(new moviesScreen());
            }

        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(feesInput.Text.ToString()) &&
                !decimal.TryParse(feesInput.Text.ToString(), out decimal fee))
            {
                MessageBox.Show($"{feesInput.Text} is not a number!");
                return;
            }
            int requestedCopiesChange;
            bool parsedWorked = int.TryParse(copiesInput.Text.ToString(), out requestedCopiesChange);
            if (!parsedWorked &&
                !string.IsNullOrEmpty(copiesInput.Text.ToString()))
            {
                MessageBox.Show($"{copiesInput.Text} is not an integer!");
                return;
            }
            if (!parsedWorked)
                requestedCopiesChange = movieToEdit.totalCopies;

            if (requestedCopiesChange < minCopies)
            {
                MessageBox.Show($"You can not change total number of copies to less than current number of copies rented out!");
                return;
            }
            string query = MovieUpdateQueryStringBuilder();
            bool suscessfulQuery = ExecuteQuery(query);
            if (suscessfulQuery)
            {
                MessageBox.Show("Changes saved!");
                SwitchToScreen(new moviesScreen());
            }

        }

        private void addActorButton_Click(object sender, EventArgs e)
        {
            SelectedActors = actorCheckList.CheckedItems.Cast<Actor>().ToList();

            string ActorsToAdd = "Actors Changed from: "
                + string.Join(", ", movieToEdit.actorsList)
                + Environment.NewLine +"To: "
                + string.Join(", ", SelectedActors);

            MessageBox.Show(ActorsToAdd);
        }
    }
}
