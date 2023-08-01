namespace VncClassManager
{
    partial class ScreenView
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
            this.components = new System.ComponentModel.Container();
            this.ToolBtn = new System.Windows.Forms.Button();
            this.ScreenMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ScreenStateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateStateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ServerMouseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ServerKeyboardMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DenyInputMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SendScreenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowMessagesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SendMessageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StreamScreenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Screen = new System.Windows.Forms.PictureBox();
            this.ScreenPanel = new System.Windows.Forms.Panel();
            this.StateLbl = new System.Windows.Forms.Label();
            this.ClientIp = new System.Windows.Forms.Label();
            this.MsgPanel = new System.Windows.Forms.Panel();
            this.ComBox = new System.Windows.Forms.TextBox();
            this.SendBtn = new System.Windows.Forms.Button();
            this.DataBox = new System.Windows.Forms.TextBox();
            this.ScreenMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Screen)).BeginInit();
            this.ScreenPanel.SuspendLayout();
            this.MsgPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBtn
            // 
            this.ToolBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ToolBtn.BackColor = System.Drawing.Color.Black;
            this.ToolBtn.ContextMenuStrip = this.ScreenMenuStrip;
            this.ToolBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToolBtn.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ToolBtn.ForeColor = System.Drawing.Color.IndianRed;
            this.ToolBtn.Location = new System.Drawing.Point(300, 185);
            this.ToolBtn.Margin = new System.Windows.Forms.Padding(0);
            this.ToolBtn.Name = "ToolBtn";
            this.ToolBtn.Size = new System.Drawing.Size(23, 18);
            this.ToolBtn.TabIndex = 5;
            this.ToolBtn.UseVisualStyleBackColor = false;
            this.ToolBtn.DoubleClick += new System.EventHandler(this.ToolBtn_DoubleClick);
            // 
            // ScreenMenuStrip
            // 
            this.ScreenMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ScreenStateMenuItem,
            this.UpdateStateMenuItem,
            this.ServerMouseMenuItem,
            this.ServerKeyboardMenuItem,
            this.DenyInputMenuItem,
            this.SendScreenMenuItem,
            this.ShowMessagesMenuItem,
            this.SendMessageMenuItem,
            this.StreamScreenMenuItem});
            this.ScreenMenuStrip.Name = "contextMenuStrip1";
            this.ScreenMenuStrip.Size = new System.Drawing.Size(203, 202);
            // 
            // ScreenStateMenuItem
            // 
            this.ScreenStateMenuItem.Name = "ScreenStateMenuItem";
            this.ScreenStateMenuItem.Size = new System.Drawing.Size(202, 22);
            this.ScreenStateMenuItem.Text = "Maximize";
            this.ScreenStateMenuItem.Click += new System.EventHandler(this.ScreenStateMenuItem_Click);
            // 
            // UpdateStateMenuItem
            // 
            this.UpdateStateMenuItem.Name = "UpdateStateMenuItem";
            this.UpdateStateMenuItem.Size = new System.Drawing.Size(202, 22);
            this.UpdateStateMenuItem.Text = "Pause";
            this.UpdateStateMenuItem.Click += new System.EventHandler(this.UpdateStateMenuItem_Click);
            // 
            // ServerMouseMenuItem
            // 
            this.ServerMouseMenuItem.Name = "ServerMouseMenuItem";
            this.ServerMouseMenuItem.Size = new System.Drawing.Size(202, 22);
            this.ServerMouseMenuItem.Text = "Enable mouse control";
            this.ServerMouseMenuItem.Click += new System.EventHandler(this.ServerMouseMenuItem_Click);
            // 
            // ServerKeyboardMenuItem
            // 
            this.ServerKeyboardMenuItem.Name = "ServerKeyboardMenuItem";
            this.ServerKeyboardMenuItem.Size = new System.Drawing.Size(202, 22);
            this.ServerKeyboardMenuItem.Text = "Enable keyboard control";
            this.ServerKeyboardMenuItem.Click += new System.EventHandler(this.ServerKeyboardMenuItem_Click);
            // 
            // DenyInputMenuItem
            // 
            this.DenyInputMenuItem.Name = "DenyInputMenuItem";
            this.DenyInputMenuItem.Size = new System.Drawing.Size(202, 22);
            this.DenyInputMenuItem.Text = "Deny input";
            this.DenyInputMenuItem.Click += new System.EventHandler(this.DenyInputMenuItem_Click);
            // 
            // SendScreenMenuItem
            // 
            this.SendScreenMenuItem.Name = "SendScreenMenuItem";
            this.SendScreenMenuItem.Size = new System.Drawing.Size(202, 22);
            this.SendScreenMenuItem.Text = "Send screen";
            this.SendScreenMenuItem.Click += new System.EventHandler(this.SendScreenMenuItem_Click);
            // 
            // ShowMessagesMenuItem
            // 
            this.ShowMessagesMenuItem.Name = "ShowMessagesMenuItem";
            this.ShowMessagesMenuItem.Size = new System.Drawing.Size(202, 22);
            this.ShowMessagesMenuItem.Text = "Show messages";
            this.ShowMessagesMenuItem.Click += new System.EventHandler(this.ShowMessagesMenuItem_Click);
            // 
            // SendMessageMenuItem
            // 
            this.SendMessageMenuItem.Name = "SendMessageMenuItem";
            this.SendMessageMenuItem.Size = new System.Drawing.Size(202, 22);
            this.SendMessageMenuItem.Text = "Send popup message";
            this.SendMessageMenuItem.Click += new System.EventHandler(this.SendMessageMenuItem_Click);
            // 
            // StreamScreenMenuItem
            // 
            this.StreamScreenMenuItem.Name = "StreamScreenMenuItem";
            this.StreamScreenMenuItem.Size = new System.Drawing.Size(202, 22);
            this.StreamScreenMenuItem.Text = "Start stream screen";
            this.StreamScreenMenuItem.Click += new System.EventHandler(this.StreamScreenMenuItem_Click);
            // 
            // Screen
            // 
            this.Screen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Screen.Location = new System.Drawing.Point(3, 3);
            this.Screen.Margin = new System.Windows.Forms.Padding(0);
            this.Screen.Name = "Screen";
            this.Screen.Size = new System.Drawing.Size(320, 180);
            this.Screen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Screen.TabIndex = 3;
            this.Screen.TabStop = false;
            // 
            // ScreenPanel
            // 
            this.ScreenPanel.Controls.Add(this.StateLbl);
            this.ScreenPanel.Controls.Add(this.ToolBtn);
            this.ScreenPanel.Controls.Add(this.Screen);
            this.ScreenPanel.Controls.Add(this.ClientIp);
            this.ScreenPanel.Location = new System.Drawing.Point(3, 3);
            this.ScreenPanel.Name = "ScreenPanel";
            this.ScreenPanel.Size = new System.Drawing.Size(325, 205);
            this.ScreenPanel.TabIndex = 11;
            // 
            // StateLbl
            // 
            this.StateLbl.AutoSize = true;
            this.StateLbl.Dock = System.Windows.Forms.DockStyle.Right;
            this.StateLbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StateLbl.Location = new System.Drawing.Point(266, 0);
            this.StateLbl.Name = "StateLbl";
            this.StateLbl.Size = new System.Drawing.Size(59, 21);
            this.StateLbl.TabIndex = 6;
            this.StateLbl.Text = "Paused";
            this.StateLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.StateLbl.Visible = false;
            // 
            // ClientIp
            // 
            this.ClientIp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ClientIp.AutoSize = true;
            this.ClientIp.Location = new System.Drawing.Point(5, 186);
            this.ClientIp.Name = "ClientIp";
            this.ClientIp.Size = new System.Drawing.Size(23, 15);
            this.ClientIp.TabIndex = 4;
            this.ClientIp.Text = "IP: ";
            // 
            // MsgPanel
            // 
            this.MsgPanel.Controls.Add(this.ComBox);
            this.MsgPanel.Controls.Add(this.SendBtn);
            this.MsgPanel.Controls.Add(this.DataBox);
            this.MsgPanel.Location = new System.Drawing.Point(331, 3);
            this.MsgPanel.Name = "MsgPanel";
            this.MsgPanel.Size = new System.Drawing.Size(154, 205);
            this.MsgPanel.TabIndex = 10;
            // 
            // ComBox
            // 
            this.ComBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.ComBox.ForeColor = System.Drawing.Color.White;
            this.ComBox.Location = new System.Drawing.Point(3, 180);
            this.ComBox.Name = "ComBox";
            this.ComBox.Size = new System.Drawing.Size(98, 23);
            this.ComBox.TabIndex = 4;
            this.ComBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComBox_KeyPress);
            // 
            // SendBtn
            // 
            this.SendBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SendBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendBtn.Location = new System.Drawing.Point(102, 180);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(50, 23);
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
            this.DataBox.Size = new System.Drawing.Size(146, 177);
            this.DataBox.TabIndex = 0;
            // 
            // ScreenView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ScreenPanel);
            this.Controls.Add(this.MsgPanel);
            this.Name = "ScreenView";
            this.Size = new System.Drawing.Size(488, 212);
            this.ScreenMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Screen)).EndInit();
            this.ScreenPanel.ResumeLayout(false);
            this.ScreenPanel.PerformLayout();
            this.MsgPanel.ResumeLayout(false);
            this.MsgPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button ToolBtn;
        public System.Windows.Forms.PictureBox Screen;
        private System.Windows.Forms.Panel ScreenPanel;
        private System.Windows.Forms.Label ClientIp;
        private System.Windows.Forms.Panel MsgPanel;
        public System.Windows.Forms.TextBox ComBox;
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.ContextMenuStrip ScreenMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ScreenStateMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpdateStateMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ServerMouseMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ServerKeyboardMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DenyInputMenuItem;
        public System.Windows.Forms.ToolStripMenuItem SendMessageMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SendScreenMenuItem;
        public System.Windows.Forms.ToolStripMenuItem ShowMessagesMenuItem;
        public System.Windows.Forms.TextBox DataBox;
        private System.Windows.Forms.ToolStripMenuItem StreamScreenMenuItem;
        private System.Windows.Forms.Label StateLbl;
    }
}
