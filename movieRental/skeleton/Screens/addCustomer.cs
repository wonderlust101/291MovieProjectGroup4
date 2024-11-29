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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace movieRental
{
    public partial class addCustomer : UserControl
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        // Data
        public List<Movie> Movies;

        // Custom Fonts
        private Font outfitFontS30Bold;
        private Font outfitFontS14Bold;
        private Font outfitFontS10Bold;
        private Font outfitFontS8Bold;

        private Font outfitFontS12;
        private Font outfitFontS14;

        public addCustomer()
        {
            InitializeComponent();

            Movies = RetrieveMovies();

            LoadCustomFont();
            ApplyFonts();
        }

        //Custom Fonts
        private void LoadCustomFont()
        {
            PrivateFontCollection pfcOutfit = new PrivateFontCollection();
            string outfitFontPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Outfit-VariableFont_wght.ttf");
            pfcOutfit.AddFontFile(outfitFontPath);

            outfitFontS30Bold = new Font(pfcOutfit.Families[0], 30f, FontStyle.Bold);
            outfitFontS14Bold = new Font(pfcOutfit.Families[0], 14f, FontStyle.Bold);
            outfitFontS10Bold = new Font(pfcOutfit.Families[0], 10f, FontStyle.Bold);
            outfitFontS8Bold = new Font(pfcOutfit.Families[0], 8f, FontStyle.Bold);

            outfitFontS12 = new Font(pfcOutfit.Families[0], 12f, FontStyle.Regular);
            outfitFontS14 = new Font(pfcOutfit.Families[0], 14f, FontStyle.Regular);
        }

        private void ApplyFonts()
        {
            EmpTabName.Font = outfitFontS30Bold;

            CustomerLabel.Font = outfitFontS8Bold;
            MovieLabel.Font = outfitFontS8Bold;
            RentalLabel.Font = outfitFontS8Bold;
            ReportLabel.Font = outfitFontS8Bold;
            LogoutLabel.Font = outfitFontS8Bold;

            FirstNameLabel.Font = outfitFontS14Bold;
            LastNameLabel.Font = outfitFontS14Bold;
            AddressLabel.Font = outfitFontS14Bold;
            CityLabel.Font = outfitFontS14Bold;
            ProvinceLabel.Font = outfitFontS14Bold;
            PostalCodeLabel.Font = outfitFontS14Bold;
            EmailLabel.Font = outfitFontS14Bold;
            PhoneLabel.Font = outfitFontS14Bold;

            FirstNameInput.Font = outfitFontS14;
            LastNameInput.Font = outfitFontS14;
            AddressInput.Font = outfitFontS14;
            CityInput.Font = outfitFontS14;
            ProvinceInput.Font = outfitFontS14;
            PostalCodeInput.Font = outfitFontS14;
            EmailInput.Font = outfitFontS14;
            PhoneNumberInput.Font = outfitFontS14;

            addCustomerButton.Font = outfitFontS10Bold;
            addPhoneNumberButton.Font = outfitFontS8Bold;
        }

        // Data Source
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void empLabel_Click(object sender, EventArgs e)
        {

        }

        private void addCustomer_Load(object sender, EventArgs e)
        {

        }

        private void LogOutButton_Click(object sender, EventArgs e)
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

        private void tableLayoutPanel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void roundedPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void EmpTabName_Click(object sender, EventArgs e)
        {

        }

        private void roundedTextBox1__TextChanged(object sender, EventArgs e)
        {

        }

        private void addCustomerClick(object sender, EventArgs e)
        {
            if (fieldValidation())
            {

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string accountNumber = "2552221";
                        string creditCardNum = "4545";
                        string creditCardExp = "2022";
                        string creditCardCvv = "455";

                        string query = "INSERT INTO Customer (FirstName, FamilyName, Address, City, Province, PostalCode, AccountNumber, EmailAddress, CreditCardNum, CreditCardExp, CreditCardCvv) VALUES (@firstName, @lastName, @address, @city, @province, @postalCode, @accountNumber, @emailAddress, @creditCardNum, @creditCardExp, @creditCardCvv)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Add parameters to prevent SQL injection
                            command.Parameters.AddWithValue("@firstName", FirstNameInput.Text);
                            command.Parameters.AddWithValue("@lastName", LastNameInput.Text);
                            command.Parameters.AddWithValue("@address", AddressInput.Text);
                            command.Parameters.AddWithValue("@city", CityInput.Text);
                            command.Parameters.AddWithValue("@province", ProvinceInput.Text);
                            command.Parameters.AddWithValue("@postalCode", PostalCodeInput.Text);
                            command.Parameters.AddWithValue("@accountNumber", accountNumber);
                            command.Parameters.AddWithValue("@emailAddress", EmailInput.Text);
                            command.Parameters.AddWithValue("@creditCardNum", creditCardNum);
                            command.Parameters.AddWithValue("@creditCardExp", creditCardExp);
                            command.Parameters.AddWithValue("@creditCardCvv", creditCardCvv);


                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Record inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearFormFields();
                            }
                            else
                            {
                                MessageBox.Show("No records were inserted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                
            }
        }

        private bool fieldValidation()
        {
            if (!string.IsNullOrEmpty(FirstNameInput.Text) &&
                !string.IsNullOrEmpty(LastNameInput.Text) &&
                !string.IsNullOrEmpty(EmailInput.Text))
            {
                return true;
            }

            return false;
        }

        private void ClearFormFields()
        {
            FirstNameInput.Text = string.Empty;
            LastNameInput.Text = string.Empty;
            AddressInput.Text = string.Empty;
            CityInput.Text = string.Empty;
            ProvinceInput.Text = string.Empty;
            PostalCodeInput.Text = string.Empty;
            EmailInput.Text = string.Empty;
        }
    }
}
