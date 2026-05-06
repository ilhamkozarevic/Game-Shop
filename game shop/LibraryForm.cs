using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.OleDb;

namespace game_shop
{
    public partial class LibraryForm : Form
    {
        private string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=GameShop.accdb;";
        private OleDbConnection connection;

        public LibraryForm()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            connection = new OleDbConnection(connString);

            InitializeComponent();
            LoadLibrary();
        }

        private void LoadLibrary()
        {
            flowLibrary.Controls.Clear();

            foreach (var game in MainForm.cartPurchased)
            {
                Panel panel = new Panel();
                panel.Width = 200;
                panel.Height = 160;
                panel.Margin = new Padding(10);

                PictureBox pic = new PictureBox();
                pic.Width = 180;
                pic.Height = 120;
                pic.Top = 10;
                pic.Left = 10;
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.ImageLocation = game.ImagePath;

                Label lblName = new Label();
                lblName.Text = game.Name;
                lblName.Top = 140;
                lblName.Left = 10;
                lblName.Width = 180;

                if (MainForm.DarkMode)
                {
                    lblName.ForeColor = Color.White;
                }
                else
                {
                    lblName.ForeColor = Color.Black;
                }

                panel.Controls.Add(pic);
                panel.Controls.Add(lblName);

                flowLibrary.Controls.Add(panel);
            }
        }

        private void LibraryForm_Load(object sender, EventArgs e)
        {
            MainForm.ApplyThemeToControl(this);
            RefreshLibrary();
        }

        private void RefreshLibrary()
        {
            flowLibrary.Controls.Clear();

            List<Game> purchasedGames = new List<Game>();

            try
            {
                connection.Open();
                
                OleDbCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = (@"SELECT Igre.IgraID, Igre.Naziv, Igre.Cijena, Igre.Slika 
                         FROM Igre 
                         INNER JOIN Biblioteka ON Igre.IgraID = Biblioteka.IgraID 
                         WHERE Biblioteka.KorisnikID = @KorisnikID");

                cmd.Parameters.AddWithValue("@KorisnikID", UserSession.CurrentUserId);

                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Game g = new Game
                    {
                        Id = Convert.ToInt32(reader["IgraID"]),
                        Name = reader["Naziv"].ToString(),
                        Price = Convert.ToDouble(reader["Cijena"]),
                        ImagePath = "Images\\" + reader["Slika"].ToString()
                    };
                    purchasedGames.Add(g);
                }

                reader.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju biblioteke: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            if (purchasedGames.Count == 0)
            {
                Label lblEmpty = new Label();
                lblEmpty.Text = "Your library is empty...";
                lblEmpty.AutoSize = true;
                lblEmpty.Left = 207;
                lblEmpty.Top = 45;
                lblEmpty.Font = new Font("Arial", 14, FontStyle.Italic);
                lblEmpty.ForeColor = MainForm.DarkMode ? Color.White : Color.Black;
                lblEmpty.TextAlign = ContentAlignment.MiddleCenter;
                lblEmpty.Margin = new Padding(77, 435, 20, 20);

                flowLibrary.BackColor = MainForm.DarkMode ? Color.FromArgb(40, 40, 40) : Color.WhiteSmoke;
                flowLibrary.Controls.Add(lblEmpty);
            }
            else
            {
                foreach (Game g in purchasedGames)
                {
                    Panel panel = new Panel();
                    panel.Width = 150;
                    panel.Height = 200;
                    panel.Margin = new Padding(10);

                    PictureBox pic = new PictureBox();
                    pic.Width = 130;
                    pic.Height = 120;
                    pic.Top = 10;
                    pic.Left = 10;
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.ImageLocation = g.ImagePath;
                    pic.Cursor = Cursors.Hand;
                    pic.Tag = g;
                    pic.Click += Pic_Click;

                    Label lblName = new Label();
                    lblName.Text = g.Name;
                    lblName.Top = 135;
                    lblName.Left = 10;
                    lblName.Width = 130;
                    lblName.TextAlign = ContentAlignment.MiddleCenter;
                    lblName.ForeColor = MainForm.DarkMode ? Color.White : Color.Black;

                    panel.Controls.Add(pic);
                    panel.Controls.Add(lblName);

                    flowLibrary.Controls.Add(panel);
                }
            }
        }

        private void Pic_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            Game game = pic.Tag as Game;

            GameDetailsForm details = new GameDetailsForm(game);
            details.ShowDialog();
        }

    }
}
