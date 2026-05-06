using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace game_shop
{
    public partial class CartForm : Form
    {
        private string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=GameShop.accdb;";
        private OleDbConnection connection;

        public CartForm()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            connection = new OleDbConnection(connString);

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

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                bool nestoKupljeno = false;
                bool nekaIgraPreskocena = false;

                int userId = Convert.ToInt32(UserSession.CurrentUserId);

                foreach (var game in MainForm.cart)
                {
                    if (game == null) continue;

                    OleDbCommand checkCmd = new OleDbCommand(
                        "SELECT COUNT(*) FROM Biblioteka WHERE KorisnikID = @KorisnikID AND IgraID = @IgraID",
                        connection);

                    checkCmd.Parameters.Add(new OleDbParameter("@KorisnikID", OleDbType.Integer) { Value = userId });
                    checkCmd.Parameters.Add(new OleDbParameter("@IgraID", OleDbType.Integer) { Value = game.Id });

                    int count = (int)checkCmd.ExecuteScalar();
                    checkCmd.Dispose();

                    if (count > 0 || MainForm.cartPurchased.Any(g => g.Id == game.Id))
                    {
                        MessageBox.Show("You already own the game: \"" + game.Name + "\"!", "Already Purchased", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        if (!MainForm.cartPurchased.Any(g => g.Id == game.Id))
                        {
                            MainForm.cartPurchased.Add(game);
                        }

                        nekaIgraPreskocena = true;
                        continue;
                    }

                    OleDbCommand insertCmd = new OleDbCommand(
                        "INSERT INTO Biblioteka (KorisnikID, IgraID, DatumKupovine) VALUES (@KorisnikID, @IgraID, @DatumKupovine)",
                        connection);

                    insertCmd.Parameters.Add(new OleDbParameter("@KorisnikID", OleDbType.Integer) { Value = userId });
                    insertCmd.Parameters.Add(new OleDbParameter("@IgraID", OleDbType.Integer) { Value = game.Id });
                    insertCmd.Parameters.Add(new OleDbParameter("@DatumKupovine", OleDbType.Date) { Value = DateTime.Now });

                    insertCmd.ExecuteNonQuery();
                    insertCmd.Dispose();

                    if (!MainForm.cartPurchased.Contains(game))
                    {
                        MainForm.cartPurchased.Add(game);
                    }

                    nestoKupljeno = true;
                }

                if (nestoKupljeno)
                {
                    MessageBox.Show("Thank you for your purchase! The games have been added to your library.", "Purchase complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MainForm.cart.Clear();
                    RefreshCart();
                    ((MainForm)this.Owner).UpdateCartStatus();
                }
                else if (nekaIgraPreskocena && MainForm.cart.Count > 0)
                {
                    MainForm.cart.Clear();
                    RefreshCart();
                    ((MainForm)this.Owner).UpdateCartStatus();

                    MessageBox.Show("No new games were purchased because you already own all items in the cart.", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri kupovini: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
