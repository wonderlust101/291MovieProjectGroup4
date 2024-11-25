namespace movieRental
{
    partial class CustomerMenu
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CustomerDataView = new DataGridView();
            panel1 = new Panel();
            LogOutButton = new PictureBox();
            CustomerRentalsPicture = new PictureBox();
            CustomerMoviePicture = new PictureBox();
            CustomerTabName = new Label();
            dataGridView2 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)CustomerDataView).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LogOutButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CustomerRentalsPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CustomerMoviePicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // CustomerDataView
            // 
            CustomerDataView.BackgroundColor = Color.FromArgb(40, 44, 91);
            CustomerDataView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CustomerDataView.Location = new Point(99, 129);
            CustomerDataView.Margin = new Padding(3, 4, 3, 4);
            CustomerDataView.Name = "CustomerDataView";
            CustomerDataView.RowHeadersWidth = 51;
            CustomerDataView.Size = new Size(1182, 656);
            CustomerDataView.TabIndex = 10;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(40, 44, 91);
            panel1.Controls.Add(LogOutButton);
            panel1.Controls.Add(CustomerRentalsPicture);
            panel1.Controls.Add(CustomerMoviePicture);
            panel1.Location = new Point(19, 20);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(63, 765);
            panel1.TabIndex = 8;
            // 
            // LogOutButton
            // 
            LogOutButton.Image = Properties.Resources.logout;
            LogOutButton.Location = new Point(11, 696);
            LogOutButton.Margin = new Padding(3, 4, 3, 4);
            LogOutButton.Name = "LogOutButton";
            LogOutButton.Size = new Size(40, 40);
            LogOutButton.SizeMode = PictureBoxSizeMode.CenterImage;
            LogOutButton.TabIndex = 4;
            LogOutButton.TabStop = false;
            // 
            // CustomerRentalsPicture
            // 
            CustomerRentalsPicture.Image = Properties.Resources.rental;
            CustomerRentalsPicture.Location = new Point(11, 109);
            CustomerRentalsPicture.Margin = new Padding(3, 4, 3, 4);
            CustomerRentalsPicture.Name = "CustomerRentalsPicture";
            CustomerRentalsPicture.Size = new Size(40, 40);
            CustomerRentalsPicture.SizeMode = PictureBoxSizeMode.CenterImage;
            CustomerRentalsPicture.TabIndex = 2;
            CustomerRentalsPicture.TabStop = false;
            CustomerRentalsPicture.Click += CustomerRentalsPicture_Click;
            // 
            // CustomerMoviePicture
            // 
            CustomerMoviePicture.Image = Properties.Resources.movies;
            CustomerMoviePicture.Location = new Point(11, 32);
            CustomerMoviePicture.Margin = new Padding(3, 4, 3, 4);
            CustomerMoviePicture.Name = "CustomerMoviePicture";
            CustomerMoviePicture.Size = new Size(40, 40);
            CustomerMoviePicture.SizeMode = PictureBoxSizeMode.CenterImage;
            CustomerMoviePicture.TabIndex = 1;
            CustomerMoviePicture.TabStop = false;
            CustomerMoviePicture.Click += CustomerMoviePicture_Click;
            // 
            // CustomerTabName
            // 
            CustomerTabName.AutoSize = true;
            CustomerTabName.BackColor = Color.FromArgb(40, 44, 91);
            CustomerTabName.Font = new Font("Microsoft Sans Serif", 32.0672226F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CustomerTabName.ForeColor = Color.White;
            CustomerTabName.Location = new Point(117, 31);
            CustomerTabName.Name = "CustomerTabName";
            CustomerTabName.Size = new Size(196, 61);
            CustomerTabName.TabIndex = 12;
            CustomerTabName.Text = "Movies";
            // 
            // dataGridView2
            // 
            dataGridView2.BackgroundColor = Color.FromArgb(40, 44, 91);
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(99, 20);
            dataGridView2.Margin = new Padding(3, 4, 3, 4);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(1182, 92);
            dataGridView2.TabIndex = 11;
            // 
            // CustomerMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 26, 63);
            Controls.Add(CustomerTabName);
            Controls.Add(dataGridView2);
            Controls.Add(CustomerDataView);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CustomerMenu";
            Size = new Size(1301, 805);
            Load += CustomerMenu_Load;
            ((System.ComponentModel.ISupportInitialize)CustomerDataView).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LogOutButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)CustomerRentalsPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)CustomerMoviePicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView CustomerDataView;
        private Panel panel1;
        private PictureBox LogOutButton;
        private PictureBox CustomerRentalsPicture;
        private PictureBox CustomerMoviePicture;
        private Label CustomerTabName;
        private DataGridView dataGridView2;
    }
}
