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
            panel1 = new Panel();
            pictureBox5 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox1 = new PictureBox();
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            pictureBox2 = new PictureBox();
            customerLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)empButton).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // empButton
            // 
            empButton.Image = Properties.Resources.customers;
            empButton.Location = new Point(12, 14);
            empButton.Margin = new Padding(3, 4, 3, 4);
            empButton.Name = "empButton";
            empButton.Size = new Size(40, 40);
            empButton.SizeMode = PictureBoxSizeMode.CenterImage;
            empButton.TabIndex = 0;
            empButton.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(40, 44, 91);
            panel1.Controls.Add(pictureBox5);
            panel1.Controls.Add(pictureBox4);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(empButton);
            panel1.Location = new Point(23, 21);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(63, 766);
            panel1.TabIndex = 3;
            panel1.Paint += panel1_Paint;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.logout;
            pictureBox5.Location = new Point(12, 696);
            pictureBox5.Margin = new Padding(3, 4, 3, 4);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(40, 40);
            pictureBox5.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox5.TabIndex = 4;
            pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.report;
            pictureBox4.Location = new Point(12, 317);
            pictureBox4.Margin = new Padding(3, 4, 3, 4);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(40, 40);
            pictureBox4.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox4.TabIndex = 3;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.rental;
            pictureBox3.Location = new Point(12, 216);
            pictureBox3.Margin = new Padding(3, 4, 3, 4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(40, 40);
            pictureBox3.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.movies;
            pictureBox1.Location = new Point(12, 110);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(40, 40);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.FromArgb(40, 44, 91);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(103, 131);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1182, 656);
            dataGridView1.TabIndex = 4;
            // 
            // dataGridView2
            // 
            dataGridView2.BackgroundColor = Color.FromArgb(40, 44, 91);
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(103, 21);
            dataGridView2.Margin = new Padding(3, 4, 3, 4);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(1182, 92);
            dataGridView2.TabIndex = 6;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = Properties.Resources.customers;
            pictureBox2.Location = new Point(121, 45);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(48, 48);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // customerLabel
            // 
            customerLabel.AutoSize = true;
            customerLabel.BackColor = Color.FromArgb(40, 44, 91);
            customerLabel.Font = new Font("Newake Demo", 32.0672226F, FontStyle.Regular, GraphicsUnit.Point, 0);
            customerLabel.ForeColor = Color.White;
            customerLabel.Location = new Point(193, 42);
            customerLabel.Name = "customerLabel";
            customerLabel.Size = new Size(245, 53);
            customerLabel.TabIndex = 7;
            customerLabel.Text = "Customer";
            customerLabel.Click += customerLabel_Click;
            // 
            // mainMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 26, 63);
            Controls.Add(customerLabel);
            Controls.Add(pictureBox2);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "mainMenu";
            Size = new Size(1301, 805);
            Load += mainMenu_Load;
            ((System.ComponentModel.ISupportInitialize)empButton).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox empButton;
        private Panel panel1;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private PictureBox pictureBox5;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label customerLabel;
    }
}
