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
    public partial class WishlistForm : Form
    {
        public WishlistForm()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            InitializeComponent();
            RefreshWishlist();
            MainForm.ApplyThemeToControl(this);
        }

        private void RefreshWishlist()
        {
            flowWishlist.Controls.Clear();

            if (MainForm.wishlist.Count == 0)
            {
                lblEmptyWishlist.Visible = true;
                flowWishlist.Visible = false;
                return;
            }
            else
            {
                lblEmptyWishlist.Visible = false;
                flowWishlist.Visible = true;
            }

            foreach (Game game in MainForm.wishlist)
            {
                Game currentGame = game;

                Panel panel = new Panel();
                panel.Width = 180;
                panel.Height = 220;
                panel.Margin = new Padding(30);
                panel.BackColor = MainForm.DarkMode
                    ? Color.FromArgb(45, 45, 45)
                    : Color.WhiteSmoke;

                panel.Tag = currentGame;

                PictureBox pic = new PictureBox();
                pic.Width = 160;
                pic.Height = 100;
                pic.Top = 10;
                pic.Left = 10;
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.ImageLocation = currentGame.ImagePath;
                pic.Cursor = Cursors.Hand;

                Label lblName = new Label();
                lblName.Text = currentGame.Name;
                lblName.Top = 115;
                lblName.Left = 10;
                lblName.Width = 160;
                lblName.TextAlign = ContentAlignment.MiddleCenter;
                lblName.ForeColor = MainForm.DarkMode ? Color.White : Color.Black;

                Label lblPrice = new Label();
                lblPrice.Text = currentGame.Price.ToString("0.00") + " KM";
                lblPrice.Top = 135;
                lblPrice.Left = 10;
                lblPrice.Width = 160;
                lblPrice.TextAlign = ContentAlignment.MiddleCenter;
                lblPrice.ForeColor = Color.LightGreen;

                Button btnAddToCart = new Button();
                btnAddToCart.Text = "Add to Cart";
                btnAddToCart.Cursor = Cursors.Hand;
                btnAddToCart.Width = 160;
                btnAddToCart.Height = 28;
                btnAddToCart.Top = 160;
                btnAddToCart.Left = 10;

                Button btnRemove = new Button();
                btnRemove.Text = "Remove";
                btnRemove.Cursor = Cursors.Hand;
                btnRemove.Width = 160;
                btnRemove.Height = 28;
                btnRemove.Top = 190;
                btnRemove.Left = 10;
                btnRemove.BackColor = Color.IndianRed;
                btnRemove.ForeColor = Color.White;
                btnRemove.FlatStyle = FlatStyle.Flat;

                pic.Click += (s, e) =>
                {
                    GameDetailsForm details = new GameDetailsForm(currentGame);
                    details.ShowDialog();
                };

                btnAddToCart.Click += (s, e) =>
                {
                    if (!MainForm.cart.Contains(currentGame))
                    {
                        MainForm.cart.Add(currentGame);
                        ((MainForm)this.Owner).UpdateCartStatus();
                        MessageBox.Show(currentGame.Name + " added to cart!", "Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(currentGame.Name + " is already in cart!", "Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };

                btnRemove.Click += (s, e) =>
                {
                    DialogResult result = MessageBox.Show(
                    "Are you sure you want to remove \"" + currentGame.Name + "\" from your wishlist?",
                    "Confirm Remove",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.Yes)
                    {
                        MainForm.wishlist.Remove(currentGame);
                        RefreshWishlist();
                    }
                };

                panel.Controls.Add(pic);
                panel.Controls.Add(lblName);
                panel.Controls.Add(lblPrice);
                panel.Controls.Add(btnAddToCart);
                panel.Controls.Add(btnRemove);

                flowWishlist.Controls.Add(panel);
            }

            MainForm.ApplyThemeToControl(this);
        }

    }
}
