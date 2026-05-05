using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace game_shop
{
    public partial class LoginForm : Form
    {

        private bool passwordVisible = false;

        public LoginForm()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();

            txtPassword.UseSystemPasswordChar = true;

            pbShowPassword.Visible = true;
            pbShowPassword.Image = Properties.Resources.passwordNotVisible;

            pbShowPassword.Click += PbShowPassword_Click;
        }

        private void PbShowPassword_Click(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible;

            if (passwordVisible)
            {
                txtPassword.UseSystemPasswordChar = false;
                pbShowPassword.Image = Properties.Resources.passwordVisible;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                pbShowPassword.Image = Properties.Resources.passwordNotVisible;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (!File.Exists("users.txt"))
            {
                lblMessage.Text = "No users registered yet.";
                return;
            }

            var lines = File.ReadAllLines("users.txt");

            bool found = lines.Any(l =>
            {
                var parts = l.Split(';');
                return parts.Length == 2 && parts[0] == user && parts[1] == pass;
            });

            if (found)
            {
                UserSession.CurrentUsername = user;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lblMessage.Text = "Wrong username or password.";
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (user == "" || pass == "")
            {
                lblMessage.Text = "Enter username and password.";
                return;
            }

            if (File.Exists("users.txt"))
            {
                var exists = File.ReadAllLines("users.txt")
                    .Any(l => l.Split(';')[0] == user);

                if (exists)
                {
                    lblMessage.Text = "Username already exists.";
                    return;
                }
            }

            File.AppendAllText("users.txt", user + ";" + pass + Environment.NewLine);

            lblMessage.Text = "Account created! You can login now.";
        }
    }
}
