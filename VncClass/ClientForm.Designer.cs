
namespace VncClass
{
    partial class ClientForm
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
            this.ToolBtn = new System.Windows.Forms.Panel();
            this.ScreenPanel = new System.Windows.Forms.Panel();
            this.Screen = new System.Windows.Forms.PictureBox();
            this.ClientIp = new System.Windows.Forms.Label();
            this.MsgPanel = new System.Windows.Forms.Panel();
            this.ComBox = new System.Windows.Forms.TextBox();
            this.SendBtn = new System.Windows.Forms.Button();
            this.DataBox = new System.Windows.Forms.TextBox();
            this.ScreenPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Screen)).BeginInit();
            this.MsgPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBtn
            // 
            this.ToolBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ToolBtn.BackColor = System.Drawing.Color.Black;
            this.ToolBtn.Location = new System.Drawing.Point(813, 475);
            this.ToolBtn.Margin = new System.Windows.Forms.Padding(0, 0, 1, 1);
            this.ToolBtn.Name = "ToolBtn";
            this.ToolBtn.Size = new System.Drawing.Size(23, 18);
            this.ToolBtn.TabIndex = 5;
            this.ToolBtn.Click += new System.EventHandler(this.ToolBtn_Click);
            // 
            // ScreenPanel
            // 
            this.ScreenPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScreenPanel.Controls.Add(this.ToolBtn);
            this.ScreenPanel.Controls.Add(this.Screen);
            this.ScreenPanel.Controls.Add(this.ClientIp);
            this.ScreenPanel.Location = new System.Drawing.Point(3, 3);
            this.ScreenPanel.Name = "ScreenPanel";
            this.ScreenPanel.Size = new System.Drawing.Size(840, 497);
            this.ScreenPanel.TabIndex = 9;
            // 
            // Screen
            // 
            this.Screen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Screen.Location = new System.Drawing.Point(3, 3);
            this.Screen.Margin = new System.Windows.Forms.Padding(0);
            this.Screen.Name = "Screen";
            this.Screen.Size = new System.Drawing.Size(832, 468);
            this.Screen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Screen.TabIndex = 3;
            this.Screen.TabStop = false;
            // 
            // ClientIp
            // 
            this.ClientIp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ClientIp.AutoSize = true;
            this.ClientIp.Location = new System.Drawing.Point(3, 475);
            this.ClientIp.Name = "ClientIp";
            this.ClientIp.Size = new System.Drawing.Size(23, 15);
            this.ClientIp.TabIndex = 4;
            this.ClientIp.Text = "IP: ";
            // 
            // MsgPanel
            // 
            this.MsgPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MsgPanel.Controls.Add(this.ComBox);
            this.MsgPanel.Controls.Add(this.SendBtn);
            this.MsgPanel.Controls.Add(this.DataBox);
            this.MsgPanel.Location = new System.Drawing.Point(847, 3);
            this.MsgPanel.Name = "MsgPanel";
            this.MsgPanel.Size = new System.Drawing.Size(284, 497);
            this.MsgPanel.TabIndex = 8;
            // 
            // ComBox
            // 
            this.ComBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.ComBox.ForeColor = System.Drawing.Color.White;
            this.ComBox.Location = new System.Drawing.Point(3, 469);
            this.ComBox.Name = "ComBox";
            this.ComBox.Size = new System.Drawing.Size(193, 23);
            this.ComBox.TabIndex = 4;
            this.ComBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComBox_KeyPress);
            // 
            // SendBtn
            // 
            this.SendBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SendBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendBtn.Location = new System.Drawing.Point(202, 469);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(77, 23);
            this.SendBtn.TabIndex = 3;
            this.SendBtn.Text = "Send";
            this.SendBtn.UseVisualStyleBackColor = true;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // DataBox
            // 
            this.DataBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.DataBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DataBox.ForeColor = System.Drawing.Color.White;
            this.DataBox.Location = new System.Drawing.Point(5, 3);
            this.DataBox.Multiline = true;
            this.DataBox.Name = "DataBox";
            this.DataBox.Size = new System.Drawing.Size(276, 460);
            this.DataBox.TabIndex = 0;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1135, 503);
            this.Controls.Add(this.MsgPanel);
            this.Controls.Add(this.ScreenPanel);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.ScreenPanel.ResumeLayout(false);
            this.ScreenPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Screen)).EndInit();
            this.MsgPanel.ResumeLayout(false);
            this.MsgPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ToolBtn;
        private System.Windows.Forms.Label ClientIp;
        public System.Windows.Forms.PictureBox Screen;
        private System.Windows.Forms.Panel MsgPanel;
        public System.Windows.Forms.TextBox ComBox;
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.TextBox DataBox;
        private System.Windows.Forms.Panel ScreenPanel;

    }
}