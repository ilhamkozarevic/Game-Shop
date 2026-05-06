using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

namespace game_shop
{
    public partial class LoginForm : Form
    {

        private bool passwordVisible = false;
        private string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=GameShop.accdb;";

        private OleDbConnection connection;

        public LoginForm()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();

            connection = new OleDbConnection(connString);

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

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                lblMessage.Text = "Enter username and password.";
                return;
            }

            try
            {
                connection.Open();

                OleDbCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "SELECT * FROM Korisnici WHERE KorisnickoIme = @KorisnickoIme AND Sifra = @Sifra";

                cmd.Parameters.AddWithValue("@KorisnickoIme", user);
                cmd.Parameters.AddWithValue("@Sifra", pass);

                OleDbDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    UserSession.CurrentUsername = reader["KorisnickoIme"].ToString();
                    UserSession.CurrentUserId = Convert.ToInt32(reader["KorisnikID"]);

                    string uloga = reader["Uloga"] != DBNull.Value ? reader["Uloga"].ToString() : "Korisnik";
                    UserSession.Role = uloga;

                    reader.Close();

                    if (UserSession.Role == "Admin")
                    {
                        AdminForm adminForm = new AdminForm();
                        adminForm.Show();
                    }
                    else
                    {
                        MainForm mainForm = new MainForm();
                        mainForm.Show();
                    }

                    this.Hide();
                }
                else
                {
                    lblMessage.Text = "Wrong username or password.";
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska pri konekciji: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
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

            try
            {
                connection.Open();

                OleDbCommand checkCmd = connection.CreateCommand();
                checkCmd.CommandText = ("SELECT * FROM Korisnici WHERE KorisnickoIme = @KorisnickoIme");
                checkCmd.Parameters.AddWithValue("@KorisnickoIme", user);

                OleDbDataReader reader = checkCmd.ExecuteReader();

                if (reader.Read())
                {
                    lblMessage.Text = "Username already exists.";
                    reader.Close();
                    return;
                }
                reader.Close();

                OleDbCommand insertCmd = connection.CreateCommand();
                insertCmd.CommandText = ("INSERT INTO Korisnici (KorisnickoIme, Sifra) VALUES (@KorisnickoIme, @Sifra)");
                insertCmd.Parameters.AddWithValue("@KorisnickoIme", user);
                insertCmd.Parameters.AddWithValue("@Sifra", pass);

                insertCmd.ExecuteNonQuery();
                lblMessage.Text = "Account created! You can login now.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
