namespace skeleton
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            userLabel = new Label();
            passLabel = new Label();
            loginButton = new Button();
            titleLabel = new Label();
            empLabel = new Label();
            helpLabel = new Label();
            userName = new TextBox();
            passWord = new TextBox();
            SuspendLayout();
            // 
            // userLabel
            // 
            userLabel.AutoSize = true;
            userLabel.Font = new Font("Cooper Black", 13.8F);
            userLabel.ForeColor = Color.White;
            userLabel.Location = new Point(729, 206);
            userLabel.Name = "userLabel";
            userLabel.Size = new Size(107, 21);
            userLabel.TabIndex = 2;
            userLabel.Text = "Username";
            // 
            // passLabel
            // 
            passLabel.AutoSize = true;
            passLabel.Font = new Font("Cooper Black", 13.8F);
            passLabel.ForeColor = Color.White;
            passLabel.Location = new Point(729, 298);
            passLabel.Name = "passLabel";
            passLabel.Size = new Size(104, 21);
            passLabel.TabIndex = 3;
            passLabel.Text = "Password";
            // 
            // loginButton
            // 
            loginButton.BackColor = Color.FromArgb(84, 80, 164);
            loginButton.Font = new Font("Cooper Black", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loginButton.ForeColor = Color.White;
            loginButton.Location = new Point(729, 414);
            loginButton.Margin = new Padding(3, 2, 3, 2);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(234, 31);
            loginButton.TabIndex = 4;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += loginClick;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Cooper Black", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(12, 48);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(225, 36);
            titleLabel.TabIndex = 5;
            titleLabel.Text = "Movie Rental";
            // 
            // empLabel
            // 
            empLabel.AutoSize = true;
            empLabel.Font = new Font("Cooper Black", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            empLabel.ForeColor = Color.White;
            empLabel.Location = new Point(144, 194);
            empLabel.Name = "empLabel";
            empLabel.Size = new Size(271, 36);
            empLabel.TabIndex = 6;
            empLabel.Text = "Employee Login";
            // 
            // helpLabel
            // 
            helpLabel.AutoSize = true;
            helpLabel.Font = new Font("Microsoft JhengHei", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            helpLabel.ForeColor = Color.White;
            helpLabel.Location = new Point(144, 277);
            helpLabel.Name = "helpLabel";
            helpLabel.Size = new Size(38, 18);
            helpLabel.TabIndex = 7;
            helpLabel.Text = "help";
            // 
            // userName
            // 
            userName.BackColor = Color.FromArgb(25, 26, 63);
            userName.BorderStyle = BorderStyle.None;
            userName.Font = new Font("Lucida Sans Unicode", 12F, FontStyle.Bold);
            userName.Location = new Point(729, 251);
            userName.Name = "userName";
            userName.PlaceholderText = "Enter username";
            userName.Size = new Size(180, 25);
            userName.TabIndex = 8;
            // 
            // passWord
            // 
            passWord.BackColor = Color.FromArgb(25, 26, 63);
            passWord.BorderStyle = BorderStyle.None;
            passWord.Font = new Font("Lucida Sans Unicode", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            passWord.Location = new Point(729, 351);
            passWord.Name = "passWord";
            passWord.PlaceholderText = "..........";
            passWord.Size = new Size(180, 25);
            passWord.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 44, 91);
            ClientSize = new Size(1122, 565);
            Controls.Add(passWord);
            Controls.Add(userName);
            Controls.Add(helpLabel);
            Controls.Add(empLabel);
            Controls.Add(titleLabel);
            Controls.Add(loginButton);
            Controls.Add(passLabel);
            Controls.Add(userLabel);
            ForeColor = Color.FromArgb(118, 119, 141);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            Load += formLoad;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label userLabel;
        private Label passLabel;
        private Button loginButton;
        private Label titleLabel;
        private Label empLabel;
        private Label helpLabel;
        private TextBox userName;
        private TextBox passWord;
    }
}
