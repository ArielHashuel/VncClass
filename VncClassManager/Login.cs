using System;
using System.Drawing;
using System.Windows.Forms;
using VncClassManager.Handlers;

namespace VncClassManager
{
    public partial class Login : Form
    {
        public readonly VncView vncView;
        public Login()
        {
            InitializeComponent();
            vncView = new();
#if DEBUG
            Username.Text = "Ariel";
            Password.Text = "1234";
#endif
        }

        private void Sign_clicked(object sender, EventArgs e)
        {
            if (Sign.Text == "Login" && CheckFields(Username, Password))
            {
                if (!captcha1.PassCaptcha)
                {
                    MessageBox.Show("Captcha Verfecation Failed. Please try again.");
                    return;
                }
                
                if (DatabaseHandler.IsExist(Username.Text, Password.Text))
                {
                    AuthForm authForm = new(Username.Text);
                    authForm.ShowDialog();

                    if (!authForm.Pass) // Check if the 2-Step Verification is successful
                    {
                        MessageBox.Show("Authentication Failed. Please try again.");
                        return;
                    }
                    //Vclient.ClientName = Username.Text;
                    vncView.Show();
                    Hide();
                }
                else
                {
                    if (MessageBox.Show("Login not Succesfull \nregister?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        button1.Text = Sign.Text;
                        TitleLabel.Text = Sign.Text = "Sign Up";
                        RegPanel.Visible = true;
                    }
                }
            }
            else
            {
                if (CheckFields(Username, Password, Fname, Lname, Mail))
                {
                    if (!DatabaseHandler.Insert(Username.Text, Password.Text, $"{Fname.Text} {Lname.Text}", Mail.Text))
                    {
                        MessageBox.Show("Username already exists");
                        return;
                    }

                    RegPanel.Visible = false;
                    Fname.Text = Lname.Text = Mail.Text = string.Empty;
                    if (!DatabaseHandler.IsExist(Username.Text, Password.Text))
                    {
                        MessageBox.Show("Registration failed");
                        return;
                    }
                    MessageBox.Show("Success, logging in..");
                    vncView.Show();
                    Hide();
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Sign Up")
            {
                button1.Text = Sign.Text;
                TitleLabel.Text = Sign.Text = "Sign Up";
                RegPanel.Visible = true;
            }
            else
            {
                TitleLabel.Text = Sign.Text = "Login";
                button1.Text = "Sign Up";
                RegPanel.Visible = false;
                Fname.Text = Lname.Text = Mail.Text = string.Empty;
            }
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox box)
            {
                box.BackColor = Color.White;
            }
        }

        private static bool CheckFields(params TextBox[] textBoxes)
        {
            bool isFilled = true;
            foreach (TextBox box in textBoxes)
            {
                if (string.IsNullOrEmpty(box.Text))
                {
                    box.BackColor = Color.Red;
                    isFilled = false;
                }
            }
            return isFilled;
        }
    }
}
