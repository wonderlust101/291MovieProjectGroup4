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
            empButton = new PictureBox();
            moviesButton = new PictureBox();
            panel1 = new Panel();
            reportButton = new PictureBox();
            dataGridView1 = new DataGridView();
            logoutButton = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)empButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)moviesButton).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)reportButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logoutButton).BeginInit();
            SuspendLayout();
            // 
            // empButton
            // 
            empButton.Image = Properties.Resources.emp;
            empButton.Location = new Point(0, 1);
            empButton.Name = "empButton";
            empButton.Size = new Size(46, 37);
            empButton.SizeMode = PictureBoxSizeMode.Zoom;
            empButton.TabIndex = 0;
            empButton.TabStop = false;
            // 
            // moviesButton
            // 
            moviesButton.Image = Properties.Resources.film;
            moviesButton.Location = new Point(0, 70);
            moviesButton.Name = "moviesButton";
            moviesButton.Size = new Size(46, 45);
            moviesButton.SizeMode = PictureBoxSizeMode.Zoom;
            moviesButton.TabIndex = 1;
            moviesButton.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(40, 44, 91);
            panel1.Controls.Add(reportButton);
            panel1.Controls.Add(moviesButton);
            panel1.Controls.Add(empButton);
            panel1.Location = new Point(20, 55);
            panel1.Name = "panel1";
            panel1.Size = new Size(47, 461);
            panel1.TabIndex = 3;
            // 
            // reportButton
            // 
            reportButton.Image = Properties.Resources.clipboard;
            reportButton.Location = new Point(0, 161);
            reportButton.Name = "reportButton";
            reportButton.Size = new Size(46, 43);
            reportButton.SizeMode = PictureBoxSizeMode.Zoom;
            reportButton.TabIndex = 2;
            reportButton.TabStop = false;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.FromArgb(40, 44, 91);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(176, 56);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(906, 460);
            dataGridView1.TabIndex = 4;
            // 
            // logoutButton
            // 
            logoutButton.BackColor = Color.Transparent;
            logoutButton.Image = Properties.Resources.logout2;
            logoutButton.Location = new Point(23, 440);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(41, 44);
            logoutButton.SizeMode = PictureBoxSizeMode.Zoom;
            logoutButton.TabIndex = 5;
            logoutButton.TabStop = false;
            // 
            // mainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 26, 63);
            Controls.Add(logoutButton);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Name = "mainMenu";
            Size = new Size(1138, 604);
            ((System.ComponentModel.ISupportInitialize)empButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)moviesButton).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)reportButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)logoutButton).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox empButton;
        private PictureBox moviesButton;
        private Panel panel1;
        private PictureBox reportButton;
        private DataGridView dataGridView1;
        private PictureBox logoutButton;
    }
}
