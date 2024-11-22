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
            userLabel.Font = new Font("Newake Demo", 15.7310925F);
            userLabel.ForeColor = Color.White;
            userLabel.Location = new Point(796, 273);
            userLabel.Name = "userLabel";
            userLabel.Size = new Size(128, 26);
            userLabel.TabIndex = 2;
            userLabel.Text = "Username";
            // 
            // passLabel
            // 
            passLabel.AutoSize = true;
            passLabel.Font = new Font("Newake Demo", 15.7310925F);
            passLabel.ForeColor = Color.White;
            passLabel.Location = new Point(796, 393);
            passLabel.Name = "passLabel";
            passLabel.Size = new Size(122, 26);
            passLabel.TabIndex = 3;
            passLabel.Text = "Password";
            // 
            // loginButton
            // 
            loginButton.BackColor = Color.FromArgb(84, 80, 164);
            loginButton.FlatAppearance.BorderColor = Color.Black;
            loginButton.FlatAppearance.BorderSize = 0;
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.Font = new Font("Outfit ExtraBold", 12F, FontStyle.Bold);
            loginButton.ForeColor = Color.White;
            loginButton.Location = new Point(796, 510);
            loginButton.Name = "loginButton";
            loginButton.Padding = new Padding(4);
            loginButton.Size = new Size(389, 48);
            loginButton.TabIndex = 4;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += loginClick;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Newake Demo", 32.0672226F, FontStyle.Regular, GraphicsUnit.Point, 0);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(109, 67);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(317, 53);
            titleLabel.TabIndex = 5;
            titleLabel.Text = "Movie Rental";
            // 
            // empLabel
            // 
            empLabel.AutoSize = true;
            empLabel.Font = new Font("Newake Demo", 32.0672226F, FontStyle.Regular, GraphicsUnit.Point, 0);
            empLabel.ForeColor = Color.White;
            empLabel.Location = new Point(109, 332);
            empLabel.Name = "empLabel";
            empLabel.Size = new Size(382, 53);
            empLabel.TabIndex = 6;
            empLabel.Text = "Employee Login";
            // 
            // helpLabel
            // 
            helpLabel.AutoSize = true;
            helpLabel.Font = new Font("Outfit", 12.1008387F, FontStyle.Regular, GraphicsUnit.Point, 0);
            helpLabel.ForeColor = Color.White;
            helpLabel.Location = new Point(109, 410);
            helpLabel.Name = "helpLabel";
            helpLabel.Size = new Size(50, 25);
            helpLabel.TabIndex = 7;
            helpLabel.Text = "help";
            // 
            // userName
            // 
            userName.BackColor = Color.FromArgb(25, 26, 63);
            userName.BorderStyle = BorderStyle.None;
            userName.Font = new Font("Outfit", 15.7310915F);
            userName.ForeColor = Color.White;
            userName.Location = new Point(796, 316);
            userName.Margin = new Padding(3, 4, 3, 4);
            userName.Name = "userName";
            userName.PlaceholderText = "Enter username";
            userName.Size = new Size(389, 33);
            userName.TabIndex = 8;
            // 
            // passWord
            // 
            passWord.BackColor = Color.FromArgb(25, 26, 63);
            passWord.BorderStyle = BorderStyle.None;
            passWord.Font = new Font("Outfit", 15.7310915F);
            passWord.Location = new Point(796, 443);
            passWord.Margin = new Padding(3, 4, 3, 4);
            passWord.Name = "passWord";
            passWord.PlaceholderText = "..........";
            passWord.Size = new Size(389, 33);
            passWord.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 44, 91);
            ClientSize = new Size(1282, 753);
            Controls.Add(passWord);
            Controls.Add(userName);
            Controls.Add(helpLabel);
            Controls.Add(empLabel);
            Controls.Add(titleLabel);
            Controls.Add(loginButton);
            Controls.Add(passLabel);
            Controls.Add(userLabel);
            ForeColor = Color.FromArgb(118, 119, 141);
            Name = "Form1";
            Text = "Movie Rental System";
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
