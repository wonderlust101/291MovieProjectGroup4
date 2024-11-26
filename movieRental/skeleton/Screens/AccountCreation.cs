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

namespace movieRental
{
    public partial class AccountCreation : Form
    {
        private string connectionString = "Server=DESKTOP-8ND5I5M\\MSSQLSERVER01;Database=MovieRentalSystem;Trusted_Connection=True;";
        //string connectionString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        // Sorry wasn't sure how to use ^ revert for your use

        public AccountCreation()
        {
            InitializeComponent();
        }

        private void CreateAccountButton_Click(object sender, EventArgs e)
        {
            bool loop = true;
            if (ValidUserName()
                && !string.IsNullOrEmpty(PasswordTextBox.Text)
                && !string.IsNullOrEmpty(FirstNameTextBox.Text)
                && !string.IsNullOrEmpty(FamilyNameTextBox.Text)
                && !string.IsNullOrEmpty(EmailTextBox.Text)
                && !string.IsNullOrEmpty(CCNumTextBox.Text)
                && !string.IsNullOrEmpty(CCExpiryTextBox.Text)
                && !string.IsNullOrEmpty(CCCvvTextBox.Text))
            {
                MessageBox.Show("Account Created!");
                this.Close();
            }
            else MessageBox.Show("Invalid Username or empty fields.");
            //this.Close();
        }

        private bool ValidUserName()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string userName = UserNameTextBox.Text;
                String nameQuery = $"SELECT * FROM Account WHERE UserName = \'{userName}\'";
                using (SqlCommand cmd = new SqlCommand(nameQuery, conn))
                {

                    try
                    {
                        SqlDataReader myReader = cmd.ExecuteReader();

                        if (!myReader.Read())
                        {
                            myReader.Close();
                            return true; // Empty query meaning unique username
                        }

                        myReader.Close();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                    return false;
                }
            }
        }

        private void GenerateAccount()
        {
            throw new NotImplementedException("Incomplete method don't use");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string userName = UserNameTextBox.Text;
                string password = PasswordTextBox.Text;
                String nameQuery = $"INSERT INTO ACCOUNT (UserName, Password, UserType) VALUES (\'{userName}\', ENCRYPTBYPASSPHRASE('PSWD', \'{password}\'), \'Customer\')";
                using (SqlCommand cmd = new SqlCommand(nameQuery, conn))
                {
                    cmd.ExecuteNonQuery();

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
                string First = FirstNameTextBox.Text;
                string Family = FamilyNameTextBox.Text;
                string Email = EmailTextBox.Text;
                string CCNum = CCNumTextBox.Text;
                string CCExp = CCExpiryTextBox.Text;
                string CCCvv = CCCvvTextBox.Text;
                nameQuery =
                    $"INSERT INTO Customer " +
                    $"(FirstName, FamilyName, AccountNumber, EmailAddress, CreditCardNum, CreditCardExp, CreditCardCvv) " +
                    $"VALUES (\'{First}\', \'{Family}\', " +
                    $"(select AccountID from Account where UserName = \'{userName}\'), \'{Email}\', \'{CCNum}\', \'{CCExp}\', \'{CCCvv}\')";
                using (SqlCommand cmd = new SqlCommand(nameQuery, conn))
                {
                    cmd.ExecuteNonQuery();

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
            }

        }
    }
}
