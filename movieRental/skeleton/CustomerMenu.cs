using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace movieRental
{
    public partial class CustomerMenu : UserControl
    {
        public CustomerMenu()
        {
            InitializeComponent();
        }

        private void CustomerMenu_Load(object sender, EventArgs e)
        {

        }

        private void CustomerMoviePicture_Click(object sender, EventArgs e)
        {
            CustomerTabName.Text = "Movies";
        }

        private void CustomerRentalsPicture_Click(object sender, EventArgs e)
        {
            CustomerTabName.Text = "Rentals";
        }
    }
}
