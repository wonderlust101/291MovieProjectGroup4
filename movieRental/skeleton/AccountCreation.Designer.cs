namespace movieRental
{
    partial class AccountCreation
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            UserNameTextBox = new TextBox();
            PasswordTextBox = new TextBox();
            FirstNameTextBox = new TextBox();
            FamilyNameTextBox = new TextBox();
            EmailTextBox = new TextBox();
            CCCvvTextBox = new TextBox();
            CCExpiryTextBox = new TextBox();
            CCNumTextBox = new TextBox();
            CreateAccountButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(221, 37);
            label1.TabIndex = 0;
            label1.Text = "Account Creation";
            // 
            // UserNameTextBox
            // 
            UserNameTextBox.Location = new Point(34, 72);
            UserNameTextBox.Name = "UserNameTextBox";
            UserNameTextBox.PlaceholderText = "UserName";
            UserNameTextBox.Size = new Size(100, 23);
            UserNameTextBox.TabIndex = 1;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(34, 116);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.PlaceholderText = "Password";
            PasswordTextBox.Size = new Size(100, 23);
            PasswordTextBox.TabIndex = 2;
            // 
            // FirstNameTextBox
            // 
            FirstNameTextBox.Location = new Point(34, 158);
            FirstNameTextBox.Name = "FirstNameTextBox";
            FirstNameTextBox.PlaceholderText = "First Name";
            FirstNameTextBox.Size = new Size(100, 23);
            FirstNameTextBox.TabIndex = 3;
            // 
            // FamilyNameTextBox
            // 
            FamilyNameTextBox.Location = new Point(34, 202);
            FamilyNameTextBox.Name = "FamilyNameTextBox";
            FamilyNameTextBox.PlaceholderText = "Family Name";
            FamilyNameTextBox.Size = new Size(100, 23);
            FamilyNameTextBox.TabIndex = 4;
            // 
            // EmailTextBox
            // 
            EmailTextBox.Location = new Point(34, 246);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.PlaceholderText = "Email";
            EmailTextBox.Size = new Size(100, 23);
            EmailTextBox.TabIndex = 5;
            // 
            // CCCvvTextBox
            // 
            CCCvvTextBox.Location = new Point(186, 160);
            CCCvvTextBox.Name = "CCCvvTextBox";
            CCCvvTextBox.PlaceholderText = "Credit Card CVV";
            CCCvvTextBox.Size = new Size(152, 23);
            CCCvvTextBox.TabIndex = 8;
            // 
            // CCExpiryTextBox
            // 
            CCExpiryTextBox.Location = new Point(186, 116);
            CCExpiryTextBox.Name = "CCExpiryTextBox";
            CCExpiryTextBox.PlaceholderText = "Credit Card Expiry MM/YY";
            CCExpiryTextBox.Size = new Size(152, 23);
            CCExpiryTextBox.TabIndex = 7;
            // 
            // CCNumTextBox
            // 
            CCNumTextBox.Location = new Point(186, 72);
            CCNumTextBox.Name = "CCNumTextBox";
            CCNumTextBox.PlaceholderText = "Credit Card Number";
            CCNumTextBox.Size = new Size(152, 23);
            CCNumTextBox.TabIndex = 6;
            // 
            // CreateAccountButton
            // 
            CreateAccountButton.Location = new Point(461, 221);
            CreateAccountButton.Name = "CreateAccountButton";
            CreateAccountButton.Size = new Size(199, 48);
            CreateAccountButton.TabIndex = 9;
            CreateAccountButton.Text = "Create Account";
            CreateAccountButton.UseVisualStyleBackColor = true;
            CreateAccountButton.Click += CreateAccountButton_Click;
            // 
            // AccountCreation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 44, 91);
            ClientSize = new Size(800, 450);
            Controls.Add(CreateAccountButton);
            Controls.Add(CCCvvTextBox);
            Controls.Add(CCExpiryTextBox);
            Controls.Add(CCNumTextBox);
            Controls.Add(EmailTextBox);
            Controls.Add(FamilyNameTextBox);
            Controls.Add(FirstNameTextBox);
            Controls.Add(PasswordTextBox);
            Controls.Add(UserNameTextBox);
            Controls.Add(label1);
            Name = "AccountCreation";
            Text = "AccountCreation";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox UserNameTextBox;
        private TextBox PasswordTextBox;
        private TextBox FirstNameTextBox;
        private TextBox FamilyNameTextBox;
        private TextBox EmailTextBox;
        private TextBox CCCvvTextBox;
        private TextBox CCExpiryTextBox;
        private TextBox CCNumTextBox;
        private Button CreateAccountButton;
    }
}