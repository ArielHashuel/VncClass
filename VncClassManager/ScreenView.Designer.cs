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
            components = new System.ComponentModel.Container();
            ToolBtn = new System.Windows.Forms.Button();
            ScreenMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
            ScreenStateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            UpdateStateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ServerMouseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ServerKeyboardMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            DenyInputMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            SendScreenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ShowMessagesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            SendMessageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            StreamScreenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            Screen = new System.Windows.Forms.PictureBox();
            ScreenPanel = new System.Windows.Forms.Panel();
            StateLbl = new System.Windows.Forms.Label();
            ClientIp = new System.Windows.Forms.Label();
            MsgPanel = new System.Windows.Forms.Panel();
            ComBox = new System.Windows.Forms.TextBox();
            SendBtn = new System.Windows.Forms.Button();
            DataBox = new System.Windows.Forms.TextBox();
            ScreenMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Screen).BeginInit();
            ScreenPanel.SuspendLayout();
            MsgPanel.SuspendLayout();
            SuspendLayout();
            // 
            // ToolBtn
            // 
            ToolBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            ToolBtn.BackColor = System.Drawing.Color.Black;
            ToolBtn.ContextMenuStrip = ScreenMenuStrip;
            ToolBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ToolBtn.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            ToolBtn.ForeColor = System.Drawing.Color.IndianRed;
            ToolBtn.Location = new System.Drawing.Point(300, 185);
            ToolBtn.Margin = new System.Windows.Forms.Padding(0);
            ToolBtn.Name = "ToolBtn";
            ToolBtn.Size = new System.Drawing.Size(23, 18);
            ToolBtn.TabIndex = 5;
            ToolBtn.UseVisualStyleBackColor = false;
            ToolBtn.DoubleClick += ToolBtn_DoubleClick;
            // 
            // ScreenMenuStrip
            // 
            ScreenMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { ScreenStateMenuItem, UpdateStateMenuItem, ServerMouseMenuItem, ServerKeyboardMenuItem, DenyInputMenuItem, SendScreenMenuItem, ShowMessagesMenuItem, SendMessageMenuItem, StreamScreenMenuItem });
            ScreenMenuStrip.Name = "contextMenuStrip1";
            ScreenMenuStrip.Size = new System.Drawing.Size(203, 202);
            // 
            // ScreenStateMenuItem
            // 
            ScreenStateMenuItem.Name = "ScreenStateMenuItem";
            ScreenStateMenuItem.Size = new System.Drawing.Size(202, 22);
            ScreenStateMenuItem.Text = "Maximize";
            ScreenStateMenuItem.Click += ScreenStateMenuItem_Click;
            // 
            // UpdateStateMenuItem
            // 
            UpdateStateMenuItem.Name = "UpdateStateMenuItem";
            UpdateStateMenuItem.Size = new System.Drawing.Size(202, 22);
            UpdateStateMenuItem.Text = "Pause";
            UpdateStateMenuItem.Click += UpdateStateMenuItem_Click;
            // 
            // ServerMouseMenuItem
            // 
            ServerMouseMenuItem.Name = "ServerMouseMenuItem";
            ServerMouseMenuItem.Size = new System.Drawing.Size(202, 22);
            ServerMouseMenuItem.Text = "Enable mouse control";
            ServerMouseMenuItem.Click += ServerMouseMenuItem_Click;
            // 
            // ServerKeyboardMenuItem
            // 
            ServerKeyboardMenuItem.Name = "ServerKeyboardMenuItem";
            ServerKeyboardMenuItem.Size = new System.Drawing.Size(202, 22);
            ServerKeyboardMenuItem.Text = "Enable keyboard control";
            ServerKeyboardMenuItem.Click += ServerKeyboardMenuItem_Click;
            // 
            // DenyInputMenuItem
            // 
            DenyInputMenuItem.Name = "DenyInputMenuItem";
            DenyInputMenuItem.Size = new System.Drawing.Size(202, 22);
            DenyInputMenuItem.Text = "Deny input";
            DenyInputMenuItem.Click += DenyInputMenuItem_Click;
            // 
            // SendScreenMenuItem
            // 
            SendScreenMenuItem.Name = "SendScreenMenuItem";
            SendScreenMenuItem.Size = new System.Drawing.Size(202, 22);
            SendScreenMenuItem.Text = "Send screen";
            SendScreenMenuItem.Click += SendScreenMenuItem_Click;
            // 
            // ShowMessagesMenuItem
            // 
            ShowMessagesMenuItem.Name = "ShowMessagesMenuItem";
            ShowMessagesMenuItem.Size = new System.Drawing.Size(202, 22);
            ShowMessagesMenuItem.Text = "Show messages";
            ShowMessagesMenuItem.Click += ShowMessagesMenuItem_Click;
            // 
            // SendMessageMenuItem
            // 
            SendMessageMenuItem.Name = "SendMessageMenuItem";
            SendMessageMenuItem.Size = new System.Drawing.Size(202, 22);
            SendMessageMenuItem.Text = "Send popup message";
            SendMessageMenuItem.Click += SendMessageMenuItem_Click;
            // 
            // StreamScreenMenuItem
            // 
            StreamScreenMenuItem.Name = "StreamScreenMenuItem";
            StreamScreenMenuItem.Size = new System.Drawing.Size(202, 22);
            StreamScreenMenuItem.Text = "Start stream screen";
            StreamScreenMenuItem.Click += StreamScreenMenuItem_Click;
            // 
            // Screen
            // 
            Screen.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            Screen.Location = new System.Drawing.Point(3, 3);
            Screen.Margin = new System.Windows.Forms.Padding(0);
            Screen.Name = "Screen";
            Screen.Size = new System.Drawing.Size(320, 180);
            Screen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            Screen.TabIndex = 3;
            Screen.TabStop = false;
            Screen.MouseClick += Screen_MouseClick;
            Screen.MouseMove += Screen_MouseMove;
            // 
            // ScreenPanel
            // 
            ScreenPanel.Controls.Add(StateLbl);
            ScreenPanel.Controls.Add(ToolBtn);
            ScreenPanel.Controls.Add(Screen);
            ScreenPanel.Controls.Add(ClientIp);
            ScreenPanel.Location = new System.Drawing.Point(3, 3);
            ScreenPanel.Name = "ScreenPanel";
            ScreenPanel.Size = new System.Drawing.Size(325, 205);
            ScreenPanel.TabIndex = 11;
            // 
            // StateLbl
            // 
            StateLbl.AutoSize = true;
            StateLbl.Dock = System.Windows.Forms.DockStyle.Right;
            StateLbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            StateLbl.Location = new System.Drawing.Point(266, 0);
            StateLbl.Name = "StateLbl";
            StateLbl.Size = new System.Drawing.Size(59, 21);
            StateLbl.TabIndex = 6;
            StateLbl.Text = "Paused";
            StateLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            StateLbl.Visible = false;
            // 
            // ClientIp
            // 
            ClientIp.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            ClientIp.AutoSize = true;
            ClientIp.Location = new System.Drawing.Point(5, 186);
            ClientIp.Name = "ClientIp";
            ClientIp.Size = new System.Drawing.Size(23, 15);
            ClientIp.TabIndex = 4;
            ClientIp.Text = "IP: ";
            // 
            // MsgPanel
            // 
            MsgPanel.Controls.Add(ComBox);
            MsgPanel.Controls.Add(SendBtn);
            MsgPanel.Controls.Add(DataBox);
            MsgPanel.Location = new System.Drawing.Point(331, 3);
            MsgPanel.Name = "MsgPanel";
            MsgPanel.Size = new System.Drawing.Size(154, 205);
            MsgPanel.TabIndex = 10;
            // 
            // ComBox
            // 
            ComBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ComBox.BackColor = System.Drawing.Color.FromArgb(61, 61, 61);
            ComBox.ForeColor = System.Drawing.Color.White;
            ComBox.Location = new System.Drawing.Point(3, 180);
            ComBox.Name = "ComBox";
            ComBox.Size = new System.Drawing.Size(98, 23);
            ComBox.TabIndex = 4;
            ComBox.KeyPress += ComBox_KeyPress;
            // 
            // SendBtn
            // 
            SendBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            SendBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            SendBtn.Location = new System.Drawing.Point(102, 180);
            SendBtn.Name = "SendBtn";
            SendBtn.Size = new System.Drawing.Size(50, 23);
            SendBtn.TabIndex = 3;
            SendBtn.Text = "Send";
            SendBtn.UseVisualStyleBackColor = true;
            SendBtn.Click += SendBtn_Click;
            // 
            // DataBox
            // 
            DataBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            DataBox.BackColor = System.Drawing.Color.FromArgb(51, 51, 51);
            DataBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            DataBox.ForeColor = System.Drawing.Color.White;
            DataBox.Location = new System.Drawing.Point(5, 3);
            DataBox.Multiline = true;
            DataBox.Name = "DataBox";
            DataBox.Size = new System.Drawing.Size(146, 177);
            DataBox.TabIndex = 0;
            // 
            // ScreenView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(ScreenPanel);
            Controls.Add(MsgPanel);
            Name = "ScreenView";
            Size = new System.Drawing.Size(488, 212);
            ScreenMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Screen).EndInit();
            ScreenPanel.ResumeLayout(false);
            ScreenPanel.PerformLayout();
            MsgPanel.ResumeLayout(false);
            MsgPanel.PerformLayout();
            ResumeLayout(false);
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
