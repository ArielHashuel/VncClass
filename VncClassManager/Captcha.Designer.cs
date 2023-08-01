namespace VncClassManager
{
    partial class Captcha
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
            pictureBox1 = new System.Windows.Forms.PictureBox();
            hScrollBar1 = new System.Windows.Forms.HScrollBar();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            button2 = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new System.Drawing.Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(240, 135);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // hScrollBar1
            // 
            hScrollBar1.Location = new System.Drawing.Point(3, 141);
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new System.Drawing.Size(240, 30);
            hScrollBar1.TabIndex = 1;
            hScrollBar1.Scroll += HScrollBar1_Scroll;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new System.Drawing.Point(3, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(40, 30);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // button2
            // 
            button2.BackColor = System.Drawing.SystemColors.Control;
            button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button2.ForeColor = System.Drawing.SystemColors.ControlText;
            button2.Location = new System.Drawing.Point(132, 175);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(111, 30);
            button2.TabIndex = 4;
            button2.Text = "Refresh";
            button2.UseVisualStyleBackColor = false;
            button2.Click += ReloadIMG;
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.SystemColors.Control;
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.ForeColor = System.Drawing.SystemColors.ControlText;
            button1.Location = new System.Drawing.Point(3, 174);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(123, 31);
            button1.TabIndex = 3;
            button1.Text = "Toggle Guidline";
            button1.UseVisualStyleBackColor = false;
            button1.Click += Toggle_Click;
            // 
            // Captcha
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(61, 61, 61);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(hScrollBar1);
            Name = "Captcha";
            Size = new System.Drawing.Size(246, 208);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}