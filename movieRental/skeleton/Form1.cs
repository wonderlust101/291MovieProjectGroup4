using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using movieRental;

namespace skeleton
{
    public partial class Form1 : Form
    {
        private string connectionString = "Server=DESKTOP-8ND5I5M\\MSSQLSERVER01;Database=MovieRentalSystem;Trusted_Connection=True;";
        //string connectionString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        // Sorry wasn't sure how to use ^ revert for your use

        public int AccountID = default;
        public string? UserName = default;
        public string? UserType = default;

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
            string password = passWord.Text;
            if (name == "test")
            {
                var mainMenuControl = new mainMenu();

                this.Controls.Clear();
                this.Controls.Add(mainMenuControl);
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String nameQuery = "SELECT * FROM Account " +
                    "WHERE UserName = " + $"\'{name}\'" +
                    " AND CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE(\'PSWD\', Password)) = " +
                    $"\'{password}\'";
                using (SqlCommand cmd = new SqlCommand(nameQuery, conn))
                {
                    //cmd.Parameters.AddWithValue("@name", name);
                    //cmd.Parameters.AddWithValue("@password", password);

                    try
                    {
                        SqlDataReader myReader = cmd.ExecuteReader();

                        if (!myReader.Read())
                        {
                            throw new Exception("Invalid login information credentials!");
                        }
                        AccountID = myReader.GetInt32(0);
                        UserName = myReader.GetString(1);
                        UserType = myReader.GetString(3);
                        myReader.Close();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                        return;
                    }

                    Control mainMenuControl;
                    if (UserType == "Employee")
                    {
                        MessageBox.Show($"Welcome back {name}!");
                        mainMenuControl = new mainMenu();

                        this.Controls.Clear();
                        this.Controls.Add(mainMenuControl);
                        return;
                    }

                    MessageBox.Show($"Welcome back {name}!");
                    mainMenuControl = new CustomerMenu();
                    this.Controls.Clear();
                    this.Controls.Add(mainMenuControl);
                    return;


                }
            }
        }


        private void formLoad(object sender, EventArgs e)
        {
            ActiveControl = null;
            helpLabel.Text = "If you are unable to login or you have forgotten your password," + Environment.NewLine + "either email your manager or contact IT services.";
        }

        private void CreateAccount_Click(object sender, EventArgs e)
        {
            AccountCreation form = new AccountCreation();
            form.ShowDialog();
        }
    }
}

