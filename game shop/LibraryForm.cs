using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace game_shop
{
    public partial class LibraryForm : Form
    {
        public LibraryForm()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

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

            if (MainForm.cartPurchased.Count == 0)
            {
                Label lblEmpty = new Label();
                lblEmpty.Text = "Your library is empty...";
                lblEmpty.AutoSize = true;
                lblEmpty.Left = 207;
                lblEmpty.Top = 45;
                lblEmpty.Font = new Font("Arial", 14, FontStyle.Italic);
                if (MainForm.DarkMode)
                    lblEmpty.ForeColor = Color.White;
                else
                    lblEmpty.ForeColor = Color.Black;
                lblEmpty.TextAlign = ContentAlignment.MiddleCenter;
                lblEmpty.Margin = new Padding(77, 435, 20, 20);

                if (MainForm.DarkMode)
                    flowLibrary.BackColor = Color.FromArgb(40, 40, 40);
                else
                    flowLibrary.BackColor = Color.WhiteSmoke;

                flowLibrary.Controls.Add(lblEmpty);
            }
            else
            {
                foreach (Game g in MainForm.cartPurchased)
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
