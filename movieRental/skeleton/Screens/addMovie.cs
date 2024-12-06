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
    public partial class addMovie : UserControl
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

        public addMovie()
        {
            InitializeComponent();

            genreSelector.DataSource = Genre;

            // Sets data source for selecting actors. No data source method
            Actors = RetrieveActors();
            foreach (var actor in Actors)
            {
                actorCheckBox.Items.Add(actor);
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
        private string MovieQueryStringBuilder()
        {
            string query = 
                $"INSERT INTO Movie (Name, Type, DistributionFee, NumOfCopies) " +
                $"VALUES (\'{titleInput.Text}\', \'{genreSelector.SelectedItem}\', {feeInput.Text}, {copiesInput.Text});";

            foreach(var actor in SelectedActors)
            {
                query +=
                    $"INSERT INTO AppearsIn (ActorID, MovieID) " +
                    $"VALUES ({actor.id}, (select max(MID) from Movie));";
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
                        MessageBox.Show($"Movie was added!");
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

        private void addMovie_Load(object sender, EventArgs e)
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

        private void addActorButton_Click(object sender, EventArgs e)
        {
            SelectedActors = actorCheckBox.CheckedItems.Cast<Actor>().ToList();

            string ActorsToAdd = "Actors (" +
                string.Join(", ", SelectedActors) +
                ") will be added when movie is created!";

            MessageBox.Show(ActorsToAdd);
        }

        private void addMovieButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(titleInput.Text) ||
                string.IsNullOrEmpty(feeInput.Text) ||
                string.IsNullOrEmpty(copiesInput.Text))
            {
                MessageBox.Show("Fields Cannot be left empty!");
                return;
            }
            string query = MovieQueryStringBuilder();
            bool suscessfulQuery = ExecuteQuery(query);
            if (suscessfulQuery) SwitchToScreen(new moviesScreen());
        }
    }
}
