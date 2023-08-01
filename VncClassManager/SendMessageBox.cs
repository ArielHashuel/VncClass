using System;
using System.Windows.Forms;
using VncClassManager.Handlers;

namespace VncClassManager
{
    public partial class SendMessageBox : Form
    {
        //private readonly VncClient client;
        public SendMessageBox()
        {
            InitializeComponent();
            //this.client = client;

        }

        private void Send_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(Message.Text))
            //{
            //    MessageBox.Show("Enter message");
            //    return;
            //}
            //if (TypePick.SelectedIndex == 0)
            //{
            //    MessageBox.Show("Select type");
            //    return;
            //}
            //client.SendMessage(Message.Text, TypePick.SelectedIndex == 1 ? MessageType.RegularMsg : MessageType.PopupMsg);
            Close();
        }

        public void ShowDialog(out string msg, out MessageType messageType)
        {
            base.ShowDialog();
            if (string.IsNullOrEmpty(Message.Text))
            {
                MessageBox.Show("Enter message");
                base.ShowDialog();
            }
            if (TypePick.SelectedIndex == 0)
            {
                MessageBox.Show("Select type");
                base.ShowDialog();
            }
            msg = Message.Text;
            messageType = TypePick.SelectedIndex == 1 ? MessageType.RegularMsg : MessageType.PopupMsg;
        }
    }
}
