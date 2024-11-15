namespace skeleton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void loginClick(object sender, EventArgs e)
        {

        }

        

        private void formLoad(object sender, EventArgs e)
        {
            ActiveControl = null;
            helpLabel.Text = "If you are unable to login or you have forgotten" + Environment.NewLine + "your password either email your manager or contact IT services";
        }
    }
}
