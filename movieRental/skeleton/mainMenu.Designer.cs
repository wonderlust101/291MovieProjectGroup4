namespace movieRental
{
    partial class mainMenu
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
            CustomersButton = new PictureBox();
            panel1 = new Panel();
            LogOutButton = new PictureBox();
            ReportsButton = new PictureBox();
            EmpRentalsButton = new PictureBox();
            EmpMovieButton = new PictureBox();
            EmpDataView = new DataGridView();
            dataGridView2 = new DataGridView();
            EmpTabName = new Label();
            ((System.ComponentModel.ISupportInitialize)CustomersButton).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LogOutButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ReportsButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmpRentalsButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmpMovieButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EmpDataView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // CustomersButton
            // 
            CustomersButton.Image = Properties.Resources.customers;
            CustomersButton.Location = new Point(10, 10);
            CustomersButton.Name = "CustomersButton";
            CustomersButton.Size = new Size(35, 30);
            CustomersButton.SizeMode = PictureBoxSizeMode.CenterImage;
            CustomersButton.TabIndex = 0;
            CustomersButton.TabStop = false;
            CustomersButton.Click += CustomersButton_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(40, 44, 91);
            panel1.Controls.Add(LogOutButton);
            panel1.Controls.Add(ReportsButton);
            panel1.Controls.Add(EmpRentalsButton);
            panel1.Controls.Add(EmpMovieButton);
            panel1.Controls.Add(CustomersButton);
            panel1.Location = new Point(20, 16);
            panel1.Name = "panel1";
            panel1.Size = new Size(55, 574);
            panel1.TabIndex = 3;
            panel1.Paint += panel1_Paint;
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
            LogOutButton.Click += LogOutButton_Click;
            // 
            // ReportsButton
            // 
            ReportsButton.Image = Properties.Resources.report;
            ReportsButton.Location = new Point(10, 238);
            ReportsButton.Name = "ReportsButton";
            ReportsButton.Size = new Size(35, 30);
            ReportsButton.SizeMode = PictureBoxSizeMode.CenterImage;
            ReportsButton.TabIndex = 3;
            ReportsButton.TabStop = false;
            ReportsButton.Click += ReportsButton_Click;
            // 
            // EmpRentalsButton
            // 
            EmpRentalsButton.Image = Properties.Resources.rental;
            EmpRentalsButton.Location = new Point(10, 162);
            EmpRentalsButton.Name = "EmpRentalsButton";
            EmpRentalsButton.Size = new Size(35, 30);
            EmpRentalsButton.SizeMode = PictureBoxSizeMode.CenterImage;
            EmpRentalsButton.TabIndex = 2;
            EmpRentalsButton.TabStop = false;
            EmpRentalsButton.Click += EmpRentalsButton_Click;
            // 
            // EmpMovieButton
            // 
            EmpMovieButton.Image = Properties.Resources.movies;
            EmpMovieButton.Location = new Point(10, 82);
            EmpMovieButton.Name = "EmpMovieButton";
            EmpMovieButton.Size = new Size(35, 30);
            EmpMovieButton.SizeMode = PictureBoxSizeMode.CenterImage;
            EmpMovieButton.TabIndex = 1;
            EmpMovieButton.TabStop = false;
            EmpMovieButton.Click += EmpMovieButton_Click;
            // 
            // EmpDataView
            // 
            EmpDataView.BackgroundColor = Color.FromArgb(40, 44, 91);
            EmpDataView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            EmpDataView.Location = new Point(90, 98);
            EmpDataView.Name = "EmpDataView";
            EmpDataView.RowHeadersWidth = 51;
            EmpDataView.Size = new Size(1034, 492);
            EmpDataView.TabIndex = 4;
            // 
            // dataGridView2
            // 
            dataGridView2.BackgroundColor = Color.FromArgb(40, 44, 91);
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(90, 16);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(1034, 69);
            dataGridView2.TabIndex = 6;
            // 
            // EmpTabName
            // 
            EmpTabName.AutoSize = true;
            EmpTabName.BackColor = Color.FromArgb(40, 44, 91);
            EmpTabName.Font = new Font("Microsoft Sans Serif", 32.0672226F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EmpTabName.ForeColor = Color.White;
            EmpTabName.Location = new Point(102, 26);
            EmpTabName.Name = "EmpTabName";
            EmpTabName.Size = new Size(209, 51);
            EmpTabName.TabIndex = 7;
            EmpTabName.Text = "Customer";
            EmpTabName.Click += customerLabel_Click;
            // 
            // mainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 26, 63);
            Controls.Add(EmpTabName);
            Controls.Add(dataGridView2);
            Controls.Add(EmpDataView);
            Controls.Add(panel1);
            Name = "mainMenu";
            Size = new Size(1138, 604);
            Load += mainMenu_Load;
            ((System.ComponentModel.ISupportInitialize)CustomersButton).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LogOutButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)ReportsButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmpRentalsButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmpMovieButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)EmpDataView).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox CustomersButton;
        private Panel panel1;
        private DataGridView EmpDataView;
        private DataGridView dataGridView2;
        private PictureBox LogOutButton;
        private PictureBox ReportsButton;
        private PictureBox EmpRentalsButton;
        private PictureBox EmpMovieButton;
        private Label EmpTabName;
    }
}
