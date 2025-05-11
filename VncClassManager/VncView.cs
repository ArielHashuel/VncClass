using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using VncClassManager.Handlers;

#if DEBUG
using System.Diagnostics;
#endif

namespace VncClassManager
{
    public partial class VncView : Form
    {
        private readonly List<ScreenView> Views;
        private Point Last;
        private int messages;


        public ScreenView? FullView;
        public int Messages
        {
            get => messages;
            set
            {
                messages = value;
                ToolBtn.Text = value > 99 ? "..." : value.ToString();
            }
        }


        public bool IsViewFull { get; set; }

        public VncView()
        {
            InitializeComponent();
            Last = Point.Empty;
            IsViewFull = false;
            Views = new();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Task.Run(Start);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (IsViewFull)
            {
                if (FullView is not null)
                {
                    Screens.ClientSize = FullView.ClientSize = new(ClientSize.Width, ClientSize.Height - 40);
                    FullView.UpdateSize();
                }
            }
        }

        private void Start()
        {
            TcpListener listener = new(IPAddress.Any, 5500);
            listener.Start();
            while (true)
            {
                Socket s = listener.AcceptSocket();
                VncClient? client = new(s);
                AddScreen(client);
            }
        }

        public void AddScreen(VncClient v)
        {
            if (Last.X + (325 * (1 + (int)(Last.X / 325F))) >= Width) // 960 = Width
            {
                Last.X = 0;
                Last.Y += 205;
            }
            else if (Views.Count != 0)
            {
                Last.X += 325;
            }
            ScreenView view = new(v);
            view.Location = Last;
            view.SendMessageMenuItem.Click += ScreenViewMessages_Click;
            view.ShowMessagesMenuItem.Click += ScreenViewMessages_Click;
            Views.Add(view);
            Screens.Invoke(delegate { Screens.Controls.Add(view); });
        }

        private void ScreenViewMessages_Click(object? sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem menuItem)
            {
                if ((menuItem.Owner as ContextMenuStrip)?.SourceControl.Parent.Parent is ScreenView view)
                {
                    Messages -= view.Messages;
                    view.Messages = 0;
                }
            }
        }

        public void PauseViews(ScreenView sv)
        {
            foreach (ScreenView view in Views.Where(x => x != sv))
            {
                view.vnc.UpdateScreen = false;
                view.Visible = false;
            }

            IsViewFull = sv.IsFull = true;
            FullView = sv;
            sv.vnc.UpdateScreenRes(MessageType.Screen1080p);

        }

        public void ResumeViews()
        {
            foreach (ScreenView view in Views)
            {
                view.IsFull = false;
                view.vnc.UpdateScreenRes(MessageType.Screen720p);
                view.Visible = true;
                if (!view.vnc.UpdateScreen)
                {
                    view.vnc.UpdateScreen = true;
                }
            }
            IsViewFull = false;
            FullView = null;
        }

        public void KeysCaptured(Keys key)
        {
            if (FullView?.KeyboardEnabled ?? false)
            {
                FullView.vnc.SendKeyboard(key);
            }
        }
#if DEBUG
        public static void UpdateDebugBox(string text)
        {
            //var vnc = (VncView)Application.OpenForms["VncView"];
            //vnc?.Invoke(delegate (string text) { vnc?.UpdateDebugbox(text); }, text);
            Debug.WriteLine(text);
        }
#endif
        private void SendMessageMenuItem_Click(object sender, EventArgs e)
        {
            new SendMessageBox().ShowDialog(out string msg, out MessageType type);
            foreach (ScreenView? view in Views)
            {
                view.vnc?.SendMessage(msg, type);
                view.DataBox.AppendText($"(b{(type is MessageType.PopupMsg ? ",p) " : ") ")}Administrator> {msg}{Environment.NewLine}");
            }
        }

        private void UpdateStateMenuItem_Click(object sender, EventArgs e)
        {
            bool res = UpdateStateMenuItem.Text == "Resume";
            UpdateStateMenuItem.Text = res ? "Pause" : "Resume";
            foreach (ScreenView view in Views)
            {              
                if(view.UpdateScreen != res)
                    view.UpdateScreen = !view.UpdateScreen;
            }
        }

        private void DenyInputMenuItem_Click(object sender, EventArgs e)
        {
            DenyInputMenuItem.Text = DenyInputMenuItem.Text.StartsWith("Deny") ? "Allow input" : "Deny input";
            foreach (ScreenView? view in Views)
            {
                view.DenyInputMenuItem_Click(sender, e);
            }
        }

        private void StreamScreenMenuItem_Click(object sender, EventArgs e)
        {
            bool stream = StreamScreenMenuItem.Text.StartsWith("Start");
            StreamScreenMenuItem.Text = stream ? "Stop stream screen" : "Start stream screen";
            UpdateStateMenuItem.Enabled = !stream;
            foreach (ScreenView? view in Views)
            {
                view.StreamScreen(stream);
            }
        }

        private void SendScreenMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ScreenView? view in Views)
            {
                view.SendScreenMenuItem_Click(sender, e);
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            Program.login.Close();
            base.OnClosed(e);

        }
    }
}