using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using movieRental;

namespace skeleton
{
    public partial class Form1 : Form
    {
        //private string connectionString = "Server=ML;Database=movieRental;Trusted_Connection=True;";
        string connectionString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;



        public Form1()
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Connection String not found");
            }
            InitializeComponent();
            
        }

        private void loginClick(object sender, EventArgs e)
        {
            String name = userName.Text;
            String password = passWord.Text;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String nameQuery = "SELECT Employee.FirstName FROM Employee WHERE Employee.FirstName = @name";
                using (SqlCommand cmd = new SqlCommand(nameQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);

                    object result = cmd.ExecuteScalar();

                    if (result != null && result.ToString() == name)
                    {
                        MessageBox.Show($"{name} inside database !");
                        var mainMenuControl = new mainMenu();

                        this.Controls.Clear();
                        this.Controls.Add(mainMenuControl);

                    }

                    else
                    {
                        MessageBox.Show($"{name} not in database !");

                    }

                }
            }
        }

        

        private void formLoad(object sender, EventArgs e)
        {
            ActiveControl = null;
            helpLabel.Text = "If you are unable to login or you have forgotten" + Environment.NewLine + "your password either email your manager or contact IT services";
        }
    }
}

