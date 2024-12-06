using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace movieRental
{
    public partial class LoginUserControl : UserControl
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;


        public int AccountID = default;
        public string? UserName = default;
        public string? UserType = default;

        public LoginUserControl()
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Connection String not found");
            }

            InitializeComponent();
            helpLabel.Text = "If you are unable to login or you have forgotten your password, either email your manager or contact IT services.";

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

        private void loginClick(object sender, EventArgs e)
        {
            String name = userName.Text;
            string password = passWord.Text;
            if (name == "test")
            {
                SwitchToScreen(new customerScreen());
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String nameQuery = "SELECT * FROM Employee " +
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
                    SwitchToScreen(new customerScreen());

                }
            }
        }

        private void CreateAccount_Click(object sender, EventArgs e)
        {
            AccountCreation form = new AccountCreation();
            form.ShowDialog();
        }
    }
}
