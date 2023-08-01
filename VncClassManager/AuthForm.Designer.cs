namespace VncClassManager
{
    partial class AuthForm
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
            label1 = new System.Windows.Forms.Label();
            textBox1 = new System.Windows.Forms.TextBox();
            button1 = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            TitleLabel = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            label3 = new System.Windows.Forms.Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(20, 144);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(200, 20);
            label1.TabIndex = 0;
            label1.Text = "Email Address:";
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(35, 198);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(100, 23);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.SystemColors.Control;
            button1.ForeColor = System.Drawing.Color.Black;
            button1.Location = new System.Drawing.Point(141, 198);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.Location = new System.Drawing.Point(35, 164);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(200, 20);
            label2.TabIndex = 3;
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            TitleLabel.Location = new System.Drawing.Point(62, 20);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new System.Drawing.Size(190, 25);
            TitleLabel.TabIndex = 10;
            TitleLabel.Text = "- 2 Step Verification -";
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(61, 61, 61);
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(TitleLabel);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox1);
            panel1.ForeColor = System.Drawing.Color.White;
            panel1.Location = new System.Drawing.Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(314, 270);
            panel1.TabIndex = 8;
            // 
            // label3
            // 
            label3.Location = new System.Drawing.Point(20, 70);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(268, 51);
            label3.TabIndex = 11;
            label3.Text = "A code was sent to your email.\r\nWrite the code in the box below and click submit";
            // 
            // AuthForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(51, 51, 51);
            ClientSize = new System.Drawing.Size(338, 294);
            Controls.Add(panel1);
            Name = "AuthForm";
            Text = "AuthForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
    }
}