namespace VncClassManager
{
    partial class VncView
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
            this.components = new System.ComponentModel.Container();
            this.Screens = new System.Windows.Forms.Panel();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.ToolBtn = new System.Windows.Forms.Button();
            this.ScreenMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.UpdateStateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DenyInputMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SendScreenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StreamScreenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SendMessageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TopPanel.SuspendLayout();
            this.ScreenMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // Screens
            // 
            this.Screens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Screens.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Screens.Location = new System.Drawing.Point(0, 40);
            this.Screens.Name = "Screens";
            this.Screens.Size = new System.Drawing.Size(981, 568);
            this.Screens.TabIndex = 1;
            // 
            // TopPanel
            // 
            this.TopPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TopPanel.Controls.Add(this.ToolBtn);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(981, 40);
            this.TopPanel.TabIndex = 2;
            // 
            // ToolBtn
            // 
            this.ToolBtn.BackColor = System.Drawing.Color.Black;
            this.ToolBtn.ContextMenuStrip = this.ScreenMenuStrip;
            this.ToolBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToolBtn.ForeColor = System.Drawing.Color.IndianRed;
            this.ToolBtn.Location = new System.Drawing.Point(0, 0);
            this.ToolBtn.Margin = new System.Windows.Forms.Padding(0);
            this.ToolBtn.Name = "ToolBtn";
            this.ToolBtn.Size = new System.Drawing.Size(40, 40);
            this.ToolBtn.TabIndex = 0;
            this.ToolBtn.Text = "0";
            this.ToolBtn.UseVisualStyleBackColor = false;
            // 
            // ScreenMenuStrip
            // 
            this.ScreenMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpdateStateMenuItem,
            this.DenyInputMenuItem,
            this.SendScreenMenuItem,
            this.StreamScreenMenuItem,
            this.SendMessageMenuItem});
            this.ScreenMenuStrip.Name = "contextMenuStrip1";
            this.ScreenMenuStrip.Size = new System.Drawing.Size(181, 136);
            // 
            // UpdateStateMenuItem
            // 
            this.UpdateStateMenuItem.Name = "UpdateStateMenuItem";
            this.UpdateStateMenuItem.Size = new System.Drawing.Size(180, 22);
            this.UpdateStateMenuItem.Text = "Pause";
            this.UpdateStateMenuItem.Click += new System.EventHandler(this.UpdateStateMenuItem_Click);
            // 
            // DenyInputMenuItem
            // 
            this.DenyInputMenuItem.Name = "DenyInputMenuItem";
            this.DenyInputMenuItem.Size = new System.Drawing.Size(180, 22);
            this.DenyInputMenuItem.Text = "Deny input";
            this.DenyInputMenuItem.Click += new System.EventHandler(this.DenyInputMenuItem_Click);
            // 
            // SendScreenMenuItem
            // 
            this.SendScreenMenuItem.Name = "SendScreenMenuItem";
            this.SendScreenMenuItem.Size = new System.Drawing.Size(180, 22);
            this.SendScreenMenuItem.Text = "Send screen";
            this.SendScreenMenuItem.Click += new System.EventHandler(this.SendScreenMenuItem_Click);
            // 
            // StreamScreenMenuItem
            // 
            this.StreamScreenMenuItem.Name = "StreamScreenMenuItem";
            this.StreamScreenMenuItem.Size = new System.Drawing.Size(180, 22);
            this.StreamScreenMenuItem.Text = "Start Stream screen";
            this.StreamScreenMenuItem.Click += new System.EventHandler(this.StreamScreenMenuItem_Click);
            // 
            // SendMessageMenuItem
            // 
            this.SendMessageMenuItem.Name = "SendMessageMenuItem";
            this.SendMessageMenuItem.Size = new System.Drawing.Size(180, 22);
            this.SendMessageMenuItem.Text = "Send message";
            this.SendMessageMenuItem.Click += new System.EventHandler(this.SendMessageMenuItem_Click);
            // 
            // VncView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 608);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.Screens);
            this.Name = "VncView";
            this.Text = "VncView";
            this.TopPanel.ResumeLayout(false);
            this.ScreenMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

#endregion

        public System.Windows.Forms.Panel Screens;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Button ToolBtn;
        private System.Windows.Forms.ContextMenuStrip ScreenMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem UpdateStateMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DenyInputMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SendScreenMenuItem;
        public System.Windows.Forms.ToolStripMenuItem SendMessageMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StreamScreenMenuItem;
#if DEBUG
#endif
    }
}