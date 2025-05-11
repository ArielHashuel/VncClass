

using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VncClassManager.Handlers;

namespace VncClassManager
{

    public partial class ScreenView : UserControl
    {
        public readonly VncClient vnc;
        private Point last;
        private bool MouseEnabled;
        private bool InputEnabled;
        private int messages;

        public bool IsMessageShow { get => MsgPanel.Visible; private set => MsgPanel.Visible = value; }
        public bool KeyboardEnabled { get; set; }
        public bool IsFull { get; set; }
        public int Messages
        {
            get => messages;
            set
            {
                messages = value;
                ToolBtn.Text = value > 99 ? "..." : value.ToString();
            }
        }

        public ScreenView(VncClient vnc)
        {
            this.vnc = vnc ?? throw new ArgumentNullException(nameof(vnc));
            InitializeComponent();
            this.vnc.VncScreen = this;
            MouseEnabled = KeyboardEnabled = IsFull = false;
            InputEnabled = true;
            ClientIp.Text = $"IP: {vnc.ClientIp}";
        }

        private void Screen_MouseMove(object sender, MouseEventArgs e)
        {
            if (vnc is not null && MouseEnabled)
            {
                MessageType t = e.Button switch
                {
                    MouseButtons.Left => MessageType.MouseLClick,
                    MouseButtons.Right => MessageType.MouseRClick,
                    _ => MessageType.MouseMove,
                };
                vnc.SendData(BitConverter.GetBytes(e.Location.X)
                    .Concat(BitConverter.GetBytes(e.Location.Y))
                    .Concat(BitConverter.GetBytes(Screen.Size.Width))
                    .Concat(BitConverter.GetBytes(Screen.Size.Height))
                    .ToArray(), t);
            }
        }

        private void Screen_MouseClick(object sender, MouseEventArgs e)
        {
            if (vnc is not null && MouseEnabled)
            {
                Screen_MouseMove(sender, e);
            }
        }

        public void SetImg(Image img)
        {
            if (Screen.Image != img)
            {
                Screen.Image?.Dispose();

                Screen.Image = null;
                Screen.Image = img;
            }
        }

        private void ToolBtn_DoubleClick(object sender, EventArgs e)
        {
            ScreenStateMenuItem.Text = IsFull ? "Maximize" : "Minimize";
            VncView? view = (VncView)Parent.Parent;
            if (!IsFull)
            {
                if (IsMessageShow)
                {
                    IsMessageShow = false;
                    Width -= 160;
                    ShowMessagesMenuItem.Text = "Show Messages";
                }
                last = Location;
                ClientSize = Parent.ClientSize;
                Location = Point.Empty;
                view.PauseViews(this);
                IsFull = true;
                ScreenMenuStrip.Items.Remove(ShowMessagesMenuItem);
            }
            else
            {
                ClientSize = new(IsMessageShow ? 488 : 328, 212);
                Location = last;
                IsFull = false;
                view.ResumeViews();
                ScreenMenuStrip.Items.Add(ShowMessagesMenuItem);
            }
            UpdateSize();
        }

        private void ScreenStateMenuItem_Click(object sender, EventArgs e)
        {
            ToolBtn_DoubleClick(sender, e);
        }

        public void UpdateStateMenuItem_Click(object sender, EventArgs e)
        {
            UpdateScreen = !UpdateScreen;
        }

        public bool UpdateScreen
        {
            get => vnc.UpdateScreen;
            set
            {
                if (!vnc.StreamTask)
                {
                    UpdateStateMenuItem.Text = value ? "Pause" : "Resume";
                    vnc.UpdateScreen = value;
                    StateLbl.Visible = !value;
                }
            }
        }

        private void ServerMouseMenuItem_Click(object sender, EventArgs e)
        {
            ServerMouseMenuItem.Text = MouseEnabled ? "Enable mouse control" : "Disable mouse control";
            MouseEnabled = !MouseEnabled;
        }

        private void ServerKeyboardMenuItem_Click(object sender, EventArgs e)
        {
            ServerKeyboardMenuItem.Text = KeyboardEnabled ? "Enable keyboard control" : "Disable keyboard control";
            KeyboardEnabled = !KeyboardEnabled;

        }

        public void DenyInputMenuItem_Click(object sender, EventArgs e)
        {
            DenyInputMenuItem.Text = InputEnabled ? "Allow input" : "Deny input";
            InputEnabled = !InputEnabled;
            vnc.ChangeInputState(InputEnabled);
        }

        private void SendMessageMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsMessageShow)
            {
                IsMessageShow = true;
                Width += 160;
                UpdateSize();
            }
            ComBox.Text = "-p ";
            ComBox.Focus();
        }

        public void SendScreenMenuItem_Click(object sender, EventArgs e)
        {
            vnc.SendScreen();
        }

        public void StreamScreenMenuItem_Click(object sender, EventArgs e)
        {
            StreamScreen(!vnc.StreamTask);
        }

        public void StreamScreen(bool stream)
        {
            vnc.StreamTask = stream;
            vnc.UpdateScreen = UpdateStateMenuItem.Enabled = !stream;
            if (stream)
            {
                vnc.StreamScreen();
                StreamScreenMenuItem.Text = "Stop stream screen";
            }
            else
            {
                StreamScreenMenuItem.Text = "Start stream screen";
            }
        }

        public void UpdateSize()
        {
            ScreenPanel.Size = new(Width - (IsMessageShow ? 163 : 3), Height - 12);
            ToolBtn.Location = new(ScreenPanel.Width - 25, ScreenPanel.Height - 15); // 300, 185
            ClientIp.Location = new(5, ScreenPanel.Height - 14);
        }

        private void UHideMsg()
        {
            ShowMessagesMenuItem.Text = IsMessageShow ? "Show Messages" : "Hide Messages";
            if (IsMessageShow)
            {
                IsMessageShow = false;
                Width -= 160;
                UpdateSize();
            }
            else
            {
                IsMessageShow = true;
                Width += 160;
                UpdateSize();
            }
        }

        private void ShowMessagesMenuItem_Click(object sender, EventArgs e)
        {
            UHideMsg();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            IsMessageShow = false;
            Width -= 160;
            UpdateSize();
        }

        private void SendMsg()
        {
            if (string.IsNullOrEmpty(ComBox.Text) || ComBox.Text.Trim() == "-p")
            {
                MessageBox.Show("Enter message");
                return;
            }

            if (ComBox.Text.Contains("-p"))
            {
                vnc.SendMessage(ComBox.Text[2..], MessageType.PopupMsg);
                DataBox.AppendText($"(p) Administrator> {ComBox.Text[2..]}{Environment.NewLine}");
            }
            else
            {
                vnc.SendMessage(ComBox.Text, MessageType.RegularMsg);
                DataBox.AppendText($"Administrator> {ComBox.Text}{Environment.NewLine}");
            }
            ComBox.Clear();
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            SendMsg();
        }

        private void ComBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' && !string.IsNullOrEmpty(ComBox.Text.Trim()))
            {
                SendMsg();
                ComBox.Text = string.Empty;
                e.Handled = true;
            }
        }


    }
}