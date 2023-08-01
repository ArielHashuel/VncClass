namespace VncClassManager
{
    partial class Login
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
            panel1 = new System.Windows.Forms.Panel();
            button1 = new System.Windows.Forms.Button();
            RegPanel = new System.Windows.Forms.Panel();
            label6 = new System.Windows.Forms.Label();
            Mail = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            Lname = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            Fname = new System.Windows.Forms.TextBox();
            Sign = new System.Windows.Forms.Button();
            TitleLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            Password = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            Username = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            textBox3 = new System.Windows.Forms.TextBox();
            captcha1 = new Captcha();
            panel1.SuspendLayout();
            RegPanel.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(61, 61, 61);
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(captcha1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(RegPanel);
            panel1.Controls.Add(Sign);
            panel1.Controls.Add(TitleLabel);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(Password);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(Username);
            panel1.ForeColor = System.Drawing.Color.White;
            panel1.Location = new System.Drawing.Point(12, 11);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(314, 628);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.Color.White;
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.ForeColor = System.Drawing.Color.Black;
            button1.Location = new System.Drawing.Point(16, 589);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(89, 27);
            button1.TabIndex = 13;
            button1.Text = "Sign Up";
            button1.UseVisualStyleBackColor = false;
            button1.Click += Button1_Click;
            // 
            // RegPanel
            // 
            RegPanel.Controls.Add(label6);
            RegPanel.Controls.Add(Mail);
            RegPanel.Controls.Add(label5);
            RegPanel.Controls.Add(Lname);
            RegPanel.Controls.Add(label3);
            RegPanel.Controls.Add(Fname);
            RegPanel.Location = new System.Drawing.Point(25, 167);
            RegPanel.Name = "RegPanel";
            RegPanel.Size = new System.Drawing.Size(238, 116);
            RegPanel.TabIndex = 12;
            RegPanel.Visible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(5, 84);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(36, 15);
            label6.TabIndex = 15;
            label6.Text = "Email";
            // 
            // Mail
            // 
            Mail.Location = new System.Drawing.Point(77, 77);
            Mail.Name = "Mail";
            Mail.Size = new System.Drawing.Size(155, 23);
            Mail.TabIndex = 14;
            Mail.TextChanged += TextBox_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(5, 46);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(63, 15);
            label5.TabIndex = 13;
            label5.Text = "Last Name";
            // 
            // Lname
            // 
            Lname.Location = new System.Drawing.Point(77, 40);
            Lname.Name = "Lname";
            Lname.Size = new System.Drawing.Size(155, 23);
            Lname.TabIndex = 12;
            Lname.TextChanged += TextBox_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(5, 8);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(64, 15);
            label3.TabIndex = 11;
            label3.Text = "First Name";
            // 
            // Fname
            // 
            Fname.Location = new System.Drawing.Point(77, 3);
            Fname.Name = "Fname";
            Fname.Size = new System.Drawing.Size(155, 23);
            Fname.TabIndex = 10;
            Fname.TextChanged += TextBox_TextChanged;
            // 
            // Sign
            // 
            Sign.BackColor = System.Drawing.Color.White;
            Sign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Sign.ForeColor = System.Drawing.Color.Black;
            Sign.Location = new System.Drawing.Point(203, 589);
            Sign.Name = "Sign";
            Sign.Size = new System.Drawing.Size(89, 27);
            Sign.TabIndex = 11;
            Sign.Text = "Login";
            Sign.UseVisualStyleBackColor = false;
            Sign.Click += Sign_clicked;
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            TitleLabel.Location = new System.Drawing.Point(110, 20);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new System.Drawing.Size(85, 25);
            TitleLabel.TabIndex = 10;
            TitleLabel.Text = "- Login -";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(28, 138);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(57, 15);
            label2.TabIndex = 3;
            label2.Text = "Password";
            // 
            // Password
            // 
            Password.Location = new System.Drawing.Point(100, 134);
            Password.Name = "Password";
            Password.Size = new System.Drawing.Size(155, 23);
            Password.TabIndex = 2;
            Password.UseSystemPasswordChar = true;
            Password.TextChanged += TextBox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(28, 100);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(60, 15);
            label1.TabIndex = 1;
            label1.Text = "Username";
            // 
            // Username
            // 
            Username.Location = new System.Drawing.Point(100, 97);
            Username.Name = "Username";
            Username.Size = new System.Drawing.Size(155, 23);
            Username.TabIndex = 0;
            Username.TextChanged += TextBox_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(51, 201);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(60, 15);
            label4.TabIndex = 7;
            label4.Text = "Username";
            // 
            // textBox3
            // 
            textBox3.Location = new System.Drawing.Point(122, 197);
            textBox3.Name = "textBox3";
            textBox3.Size = new System.Drawing.Size(155, 23);
            textBox3.TabIndex = 6;
            // 
            // captcha1
            // 
            captcha1.BackColor = System.Drawing.Color.FromArgb(61, 61, 61);
            captcha1.Location = new System.Drawing.Point(25, 317);
            captcha1.Name = "captcha1";
            captcha1.Size = new System.Drawing.Size(246, 208);
            captcha1.TabIndex = 14;
            // 
            // Login
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(51, 51, 51);
            ClientSize = new System.Drawing.Size(338, 649);
            Controls.Add(panel1);
            Name = "Login";
            Text = "Login";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            RegPanel.ResumeLayout(false);
            RegPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button Sign;
        private System.Windows.Forms.Panel RegPanel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Mail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Lname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Fname;
        private System.Windows.Forms.Button button1;
        private Captcha captcha1;
    }
}

