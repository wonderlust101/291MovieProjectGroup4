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
    public partial class customerScreen : UserControl
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        //Data
        public List<Customer> Customers;

        // Custom Fonts
        private Font outfitFontS30Bold;
        private Font outfitFontS10Bold;
        private Font outfitFontS8Bold;

        private Font outfitFontS12;

        public customerScreen()
        {
            InitializeComponent();

            Customers = RetrieveCustomers();
            EmpDataView.DataSource = Customers;

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
            outfitFontS10Bold = new Font(pfcOutfit.Families[0], 10f, FontStyle.Bold);
            outfitFontS8Bold = new Font(pfcOutfit.Families[0], 8f, FontStyle.Bold);

            outfitFontS12 = new Font(pfcOutfit.Families[0], 12f, FontStyle.Regular);
        }

        private void ApplyFonts()
        {
            EmpTabName.Font = outfitFontS30Bold;

            CustomerLabel.Font = outfitFontS8Bold;
            MovieLabel.Font = outfitFontS8Bold;
            RentalLabel.Font = outfitFontS8Bold;
            ReportLabel.Font = outfitFontS8Bold;
            LogoutLabel.Font = outfitFontS8Bold;

            customerSearch.Font = outfitFontS12;
            addCustomer.Font = outfitFontS10Bold;
        }

        // Data Source
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

        private void customerScreen_Load(object sender, EventArgs e)
        {

        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
        }

        private void CustomersButton_Click(object sender, EventArgs e)
        {
            customerScreen customerScreenInstance = new customerScreen();
            Form parentForm = this.FindForm();

            if (parentForm != null)
            {
                parentForm.Controls.Clear();
                parentForm.Controls.Add(customerScreenInstance);
                customerScreenInstance.Dock = DockStyle.Fill;
            }
        }

        private void MoviesButton_Click(object sender, EventArgs e)
        {
            moviesScreen moviesScreenInstance = new moviesScreen();
            Form parentForm = this.FindForm();

            if (parentForm != null)
            {
                parentForm.Controls.Clear();
                parentForm.Controls.Add(moviesScreenInstance);
                moviesScreenInstance.Dock = DockStyle.Fill;
            }
        }

        private void RentalsButton_Click(object sender, EventArgs e)
        {
            rentalScreen rentalScreenInstance = new rentalScreen();
            Form parentForm = this.FindForm();

            if (parentForm != null)
            {
                parentForm.Controls.Clear();
                parentForm.Controls.Add(rentalScreenInstance);
                rentalScreenInstance.Dock = DockStyle.Fill;
            }
        }

        private void ReportsButton_Click(object sender, EventArgs e)
        {
            reportScreen reportScreenInstance = new reportScreen();
            Form parentForm = this.FindForm();

            if (parentForm != null)
            {
                parentForm.Controls.Clear();
                parentForm.Controls.Add(reportScreenInstance);
                reportScreenInstance.Dock = DockStyle.Fill;
            }
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
    }
}
