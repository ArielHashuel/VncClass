namespace VncClassManager
{
    partial class SendMessageBox
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
            this.Message = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.TypePick = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Message
            // 
            this.Message.Location = new System.Drawing.Point(10, 50);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(269, 23);
            this.Message.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(276, 159);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Send_Click);
            // 
            // TypePick
            // 
            this.TypePick.FormattingEnabled = true;
            this.TypePick.Items.AddRange(new object[] {
            "- Select message type -",
            "Regular message",
            "Popup message"});
            this.TypePick.Location = new System.Drawing.Point(14, 90);
            this.TypePick.Name = "TypePick";
            this.TypePick.Size = new System.Drawing.Size(171, 23);
            this.TypePick.TabIndex = 2;
            this.TypePick.SelectedIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Message:";
            // 
            // SendMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 185);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TypePick);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Message);
            this.Name = "SendMessageBox";
            this.Text = "SendMessageBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Message;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox TypePick;
        private System.Windows.Forms.Label label1;
    }
}