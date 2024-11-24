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
            CustomerTabName = new Label();
            dataGridView2 = new DataGridView();
            CustomerDataView = new DataGridView();
            panel1 = new Panel();
            LogOutButton = new PictureBox();
            CustomerRentalsPicture = new PictureBox();
            CustomerMoviePicture = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CustomerDataView).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LogOutButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CustomerRentalsPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CustomerMoviePicture).BeginInit();
            SuspendLayout();
            // 
            // CustomerTabName
            // 
            CustomerTabName.AutoSize = true;
            CustomerTabName.BackColor = Color.FromArgb(40, 44, 91);
            CustomerTabName.Font = new Font("Microsoft Sans Serif", 32.0672226F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CustomerTabName.ForeColor = Color.White;
            CustomerTabName.Location = new Point(102, 23);
            CustomerTabName.Name = "CustomerTabName";
            CustomerTabName.Size = new Size(160, 51);
            CustomerTabName.TabIndex = 12;
            CustomerTabName.Text = "Movies";
            // 
            // dataGridView2
            // 
            dataGridView2.BackgroundColor = Color.FromArgb(40, 44, 91);
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(87, 15);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(1034, 69);
            dataGridView2.TabIndex = 11;
            // 
            // CustomerDataView
            // 
            CustomerDataView.BackgroundColor = Color.FromArgb(40, 44, 91);
            CustomerDataView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CustomerDataView.Location = new Point(87, 97);
            CustomerDataView.Name = "CustomerDataView";
            CustomerDataView.RowHeadersWidth = 51;
            CustomerDataView.Size = new Size(1034, 492);
            CustomerDataView.TabIndex = 10;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(40, 44, 91);
            panel1.Controls.Add(LogOutButton);
            panel1.Controls.Add(CustomerRentalsPicture);
            panel1.Controls.Add(CustomerMoviePicture);
            panel1.Location = new Point(17, 15);
            panel1.Name = "panel1";
            panel1.Size = new Size(55, 574);
            panel1.TabIndex = 8;
            // 
            // LogOutButton
            // 
            LogOutButton.Image = Properties.Resources.logout;
            LogOutButton.Location = new Point(10, 522);
            LogOutButton.Name = "LogOutButton";
            LogOutButton.Size = new Size(35, 30);
            LogOutButton.SizeMode = PictureBoxSizeMode.CenterImage;
            LogOutButton.TabIndex = 4;
            LogOutButton.TabStop = false;
            // 
            // CustomerRentalsPicture
            // 
            CustomerRentalsPicture.Image = Properties.Resources.rental;
            CustomerRentalsPicture.Location = new Point(10, 82);
            CustomerRentalsPicture.Name = "CustomerRentalsPicture";
            CustomerRentalsPicture.Size = new Size(35, 30);
            CustomerRentalsPicture.SizeMode = PictureBoxSizeMode.CenterImage;
            CustomerRentalsPicture.TabIndex = 2;
            CustomerRentalsPicture.TabStop = false;
            CustomerRentalsPicture.Click += CustomerRentalsPicture_Click;
            // 
            // CustomerMoviePicture
            // 
            CustomerMoviePicture.Image = Properties.Resources.movies;
            CustomerMoviePicture.Location = new Point(10, 24);
            CustomerMoviePicture.Name = "CustomerMoviePicture";
            CustomerMoviePicture.Size = new Size(35, 30);
            CustomerMoviePicture.SizeMode = PictureBoxSizeMode.CenterImage;
            CustomerMoviePicture.TabIndex = 1;
            CustomerMoviePicture.TabStop = false;
            CustomerMoviePicture.Click += CustomerMoviePicture_Click;
            // 
            // CustomerMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 26, 63);
            Controls.Add(CustomerTabName);
            Controls.Add(dataGridView2);
            Controls.Add(CustomerDataView);
            Controls.Add(panel1);
            Name = "CustomerMenu";
            Size = new Size(1138, 604);
            Load += CustomerMenu_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)CustomerDataView).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LogOutButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)CustomerRentalsPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)CustomerMoviePicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CustomerTabName;
        private DataGridView dataGridView2;
        private DataGridView CustomerDataView;
        private Panel panel1;
        private PictureBox LogOutButton;
        private PictureBox CustomerRentalsPicture;
        private PictureBox CustomerMoviePicture;
    }
}
