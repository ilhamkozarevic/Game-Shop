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
    public partial class CartForm : Form
    {
        public CartForm()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            InitializeComponent();

            MainForm.ApplyThemeToControl(this);
        }

        private void CartForm_Load(object sender, EventArgs e)
        {
            RefreshCart();
        }

        private void RefreshCart()
        {
            flowCart.Controls.Clear();

            if (MainForm.cart.Count == 0)
            {
                lblEmptyCart.Visible = true;
                flowCart.Visible = false;
                lblTotal.Text = "Total: 0.00 KM";
                return;
            }
            else
            {
                lblEmptyCart.Visible = false;
                flowCart.Visible = true;
            }

            double total = 0;

            foreach (Game game in MainForm.cart)
            {
                Game currentGame = game;
                total += currentGame.Price;

                Panel panel = new Panel();
                panel.Width = 200;
                panel.Height = 250;
                panel.Margin = new Padding(10);
                panel.BackColor = MainForm.DarkMode ? Color.FromArgb(40, 40, 40) : Color.WhiteSmoke;

                panel.Tag = currentGame;

                PictureBox pic = new PictureBox();
                pic.Width = 180;
                pic.Height = 120;
                pic.Top = 10;
                pic.Left = 10;
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.ImageLocation = currentGame.ImagePath;
                pic.Cursor = Cursors.Hand;

                Label lblName = new Label();
                lblName.Text = currentGame.Name;
                lblName.Top = 140;
                lblName.Left = 10;
                lblName.Width = 180;
                lblName.ForeColor = MainForm.DarkMode ? Color.White : Color.Black;

                Label lblPrice = new Label();
                lblPrice.Text = currentGame.Price.ToString("0.00") + " KM";
                lblPrice.Top = 165;
                lblPrice.Left = 10;
                lblPrice.ForeColor = Color.LightGreen;
                lblPrice.Font = new Font(lblPrice.Font, FontStyle.Bold);

                Button btnRemove = new Button();
                btnRemove.Text = "Remove";
                btnRemove.Cursor = Cursors.Hand;
                btnRemove.Width = 180;
                btnRemove.Height = 30;
                btnRemove.Top = 195;
                btnRemove.Left = 10;
                btnRemove.BackColor = Color.IndianRed;
                btnRemove.ForeColor = Color.White;
                btnRemove.FlatStyle = FlatStyle.Flat;

                btnRemove.Click += (s, e) =>
                {
                    DialogResult result = MessageBox.Show(
                    "Are you sure you want to remove \"" + currentGame.Name + "\" from the cart?",
                    "Confirm Remove",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.Yes)
                    {
                        MainForm.cart.Remove(currentGame);
                        RefreshCart();
                        ((MainForm)this.Owner).UpdateCartStatus();
                    }
                };

                pic.Click += (s, e) =>
                {
                    GameDetailsForm details = new GameDetailsForm(currentGame);
                    details.ShowDialog();
                };

                panel.Controls.Add(pic);
                panel.Controls.Add(lblName);
                panel.Controls.Add(lblPrice);
                panel.Controls.Add(btnRemove);

                flowCart.Controls.Add(panel);
            }

            lblTotal.Text = "Total: " + total.ToString("0.00") + " KM";
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (MainForm.cart.Count == 0)
            {
                MessageBox.Show("Your cart is empty!", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var game in MainForm.cart)
            {
                if (!MainForm.cartPurchased.Contains(game))
                    MainForm.cartPurchased.Add(game);
            }

            MessageBox.Show("Thank you for your purchase!", "Purchase complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

            MainForm.cart.Clear();
            RefreshCart();
            ((MainForm)this.Owner).UpdateCartStatus();
        }

    }
}
