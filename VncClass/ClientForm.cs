using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VncClass
{
    public partial class ClientForm : Form
    {
        public VncHost? Vnc;
        private delegate void UpdateData(string message);

        private const int port = 5500;
        private const string ip = "10.100.102.4";

        public ClientForm()
        {
            InitializeComponent();
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            TcpClient tcp = new();
            tcp.BeginConnect(IPAddress.Parse(ip), port, ConnectCallback, tcp);
        }

        private async void ConnectCallback(IAsyncResult result)
        {
            TcpClient? tcp = (TcpClient?)result.AsyncState;
            if (tcp is not null)
            {
                if (tcp.Connected)
                {
                    Socket s = tcp.Client;
                    Vnc = new VncHost(s);
                    ClientIp.Invoke(delegate { ClientIp.Text += ip; });
                }
                else
                {
                    await Task.Delay(1000);
                    tcp.BeginConnect(IPAddress.Parse(ip), port, ConnectCallback, tcp);
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateSize();
        }

        private void UpdateSize()
        {
            ScreenPanel.Size = new(Width - (MsgPanel.Visible ? 312 : 20), Height - 45);
            ToolBtn.Location = new(ScreenPanel.Width - 30, ScreenPanel.Height - 20);
            ClientIp.Location = new(5, ScreenPanel.Height - 20);
        }

        private void ToolBtn_Click(object sender, EventArgs e)
        {
            if (MsgPanel.Visible)
            {
                MsgPanel.Visible = false;
                Width -= 292;
                UpdateSize();
            }
            else
            {
                MsgPanel.Visible = true;
                Width += 292;
                UpdateSize();
            }
        }

        public void UpdateLog(string s)
        {
            DataBox.AppendText(s + Environment.NewLine);
            Debug.WriteLine(s);
        }

        private void SendMsg()
        {
            DataBox.Invoke(delegate { UpdateLog($"You> {ComBox.Text}"); });
            Vnc?.SendMessage(ComBox.Text);
            ComBox.Text = string.Empty;
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

        private void SendBtn_Click(object sender, EventArgs e)
        {
            SendMsg();
        }
    }
}
