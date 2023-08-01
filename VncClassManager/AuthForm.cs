using System;
using System.Net.Mail;
using System.Reflection.Emit;
using System.Windows.Forms;
using VncClassManager.Handlers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VncClassManager
{
    /// <summary>
    /// 
    /// </summary>
    public partial class AuthForm : Form
    {
        private readonly string code;
        private bool pass;
        /// <summary>
        /// Indicates whether user passed 2 Step Verfecation
        /// </summary>
        public bool Pass => pass;

        /// <summary>
        /// Create new instance of <see cref="AuthForm"/>.
        /// <br>Generate 6 digit code and send it to the mail specified</br>
        /// </summary>
        /// <param name="username">user name to display in mail</param>
        public AuthForm(string username)
        {
            InitializeComponent();

            label2.Text = DatabaseHandler.GetMail(username);

            Random random = new();
            code = random.Next(100000, 999999).ToString();
#if DEBUG // No need to send mail on debugging
            textBox1.Text = code;
#else
            SendMail(username, label2.Text, code);
#endif
        }

        /// <summary>
        /// Sends authintication code.
        /// </summary>
        /// <param name="user">user name to display in mail</param>
        /// <param name="email">Recipient of the mail</param>
        /// <param name="Code">6 digit auth code</param>
        public static async void SendMail(string user, string email, string Code)
        {
            MailMessage mail = new();
            //SmtpClient SmtpServer = new("smtp-relay.sendinblue.com");
            SmtpClient SmtpServer = new("smtp-relay.brevo.com");
            mail.From = new MailAddress("NoReplay@VncClass.com");
            mail.To.Add(email);
            mail.Subject = "2 Step Verfecation";
            mail.Body = $"<html><body><table><tr><td>Verfecation code for</td><td>{user}</td></tr>" +
                $"<tr><td>Code: </td><td>{Code}</td><tr></table></body></html>";
            mail.IsBodyHtml = true;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(SmtpKey.MAIL, SmtpKey.SMTPKEY);

            SmtpServer.EnableSsl = true;
            await SmtpServer.SendMailAsync(mail);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == code)
            {
                pass = true;
                MessageBox.Show("Auth Succesfull");
                Close();
            }
        }
    }
}
