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
    public partial class MainForm : Form
    {
        List<Game> games = new List<Game>();
        public static List<Game> cart = new List<Game>();

        public static bool DarkMode = true;

        public static List<Game> wishlist = new List<Game>();

        List<Game> featuredGames = new List<Game>();

        int featuredIndex = 0;

        public static List<Game> cartPurchased = new List<Game>();

        private string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=GameShop.accdb;";
        private OleDbConnection connection;

        public MainForm()
        {
            InitializeComponent();

            connection = new OleDbConnection(connString);

            pbFeatured.Cursor = Cursors.Hand;

            LoadGamesFromFile();

            List<string> genres = games.Select(g => g.Genre).Distinct().ToList();
            genres.Insert(0, "All");
            cmbGenres.DataSource = genres;
            cmbGenres.SelectedIndexChanged += cmbGenres_SelectedIndexChanged;

            DisplayGames(games);

            ApplyFilters();

            btnTheme.Text = "☼︎";
            btnTheme.ForeColor = Color.Gold;
            ApplyThemeToControl(this);

        }

        void ShowFeaturedGame()
        {
            if (featuredGames.Count == 0) return;

            Game current = featuredGames[featuredIndex];

            pbFeatured.ImageLocation = current.ImagePath;
            pbFeatured.Tag = current;
        }

        public static void ApplyThemeToControl(Control parent)
        {
            Color backColor;
            Color foreColor;
            Color panelColor;
            Color buttonColor;
            Color buttonTextColor;

            if (DarkMode)
            {
                backColor = Color.FromArgb(28, 28, 28);
                foreColor = Color.White;
                panelColor = Color.FromArgb(45, 45, 45);
                buttonColor = Color.MediumPurple;
                buttonTextColor = Color.White;
            }
            else
            {
                backColor = Color.WhiteSmoke;
                foreColor = Color.Black;
                panelColor = Color.Gainsboro;
                buttonColor = Color.SteelBlue;
                buttonTextColor = Color.White;
            }

            parent.BackColor = backColor;
            parent.ForeColor = foreColor;

            foreach (Control c in parent.Controls)
            {
                if (c is Panel)
                    c.BackColor = panelColor;

                if (c is Label || c is RadioButton || c is CheckBox)
                    c.ForeColor = foreColor;

                if (c is Button && c.Name != "btnTheme")
                {
                    c.BackColor = buttonColor;
                    c.ForeColor = buttonTextColor;
                    ((Button)c).FlatStyle = FlatStyle.Flat;
                }

                if (c.HasChildren)
                    ApplyThemeToControl(c);
            }
        }


        private void SortGames(List<Game> gamesToSort)
        {
            List<Game> currentList = new List<Game>(gamesToSort);

            if (rbSortNameAsc.Checked)
                currentList = currentList.OrderBy(g => g.Name).ToList();
            else if (rbSortNameDesc.Checked)
                currentList = currentList.OrderByDescending(g => g.Name).ToList();
            else if (rbSortPriceAsc.Checked)
                currentList = currentList.OrderBy(g => g.Price).ToList();
            else if (rbSortPriceDesc.Checked)
                currentList = currentList.OrderByDescending(g => g.Price).ToList();

            DisplayGames(currentList);
        }


        private void rbSort_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void LoadGamesFromFile()
        {
            games.Clear();

            try
            {
                connection.Open();

                OleDbCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Igre";

                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Game g = new Game();

                    g.Id = Convert.ToInt32(reader["IgraID"]);
                    g.Name = reader["Naziv"].ToString();
                    g.Price = Convert.ToDouble(reader["Cijena"]);
                    g.Description = reader["Opis"].ToString();
                    g.Genre = reader["Zanr"].ToString();

                    g.ImagePath = "Images\\" + reader["Slika"].ToString();

                    games.Add(g);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju igara: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void DisplayGames(List<Game> gamesToDisplay)
        {
            flowGames.Controls.Clear();

            foreach (Game game in gamesToDisplay)
            {

                Game currentGame = game;

                Panel panel = new Panel();
                panel.Width = 200;
                panel.Height = 250;
                panel.BackColor = DarkMode ? Color.FromArgb(40, 40, 40) : Color.WhiteSmoke;
                panel.Margin = new Padding(10);

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
                lblName.ForeColor = DarkMode ? Color.White : Color.Black;
                lblName.Top = 140;
                lblName.Left = 10;
                lblName.Width = 180;

                Label lblPrice = new Label();
                lblPrice.Text = currentGame.Price.ToString("0.00") + " KM";
                lblPrice.ForeColor = DarkMode ? Color.LightGreen : Color.DarkGreen;
                lblPrice.Top = 165;
                lblPrice.Left = 10;

                Button btnAdd = new Button();
                btnAdd.Text = "Add to Cart";
                btnAdd.Cursor = Cursors.Hand;
                btnAdd.Width = 180;
                btnAdd.Height = 30;
                btnAdd.Top = 195;
                btnAdd.Left = 10;
                btnAdd.BackColor = Color.MediumPurple;
                btnAdd.ForeColor = Color.White;
                btnAdd.FlatStyle = FlatStyle.Flat;

                btnAdd.Click += (s, e) =>
                {
                    cart.Add(currentGame);
                    UpdateCartStatus();
                    MessageBox.Show(currentGame.Name + " has been successfully added to your cart!", "Game Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };

                pic.Click += (s, e) =>
                {
                    GameDetailsForm details = new GameDetailsForm(currentGame);
                    details.ShowDialog();
                };

                panel.Controls.Add(pic);
                panel.Controls.Add(lblName);
                panel.Controls.Add(lblPrice);
                panel.Controls.Add(btnAdd);

                flowGames.Controls.Add(panel);
            }

            int gamePanelHeight = 250;
            int gamePanelMargin = 10;
            int panelsPerRow = 3;

            int numberOfGames = gamesToDisplay.Count;
            int rows = (int)Math.Ceiling((double)numberOfGames / panelsPerRow);

            flowMainVertical.Height = (gamePanelHeight + gamePanelMargin) * rows + 50;
            flowGames.Height = (gamePanelHeight + gamePanelMargin) * rows + 50;

        }


        public void UpdateCartStatus()
        {
            tslCart.Text = "Games in cart: " + cart.Count;
            tslCart.ForeColor = Color.Black;
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            CartForm cartForm = new CartForm();
            cartForm.Owner = this;
            cartForm.ShowDialog();
        }

        private void cmbGenres_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string searchText = txtSearch.Text.ToLower();
            string selectedGenre = cmbGenres.SelectedItem.ToString();

            List<Game> filteredGames = games.Where(g =>
                (selectedGenre == "All" || g.Genre == selectedGenre) &&
                g.Name.ToLower().Contains(searchText)
            ).ToList();

            DisplayGames(filteredGames);

            SortGames(filteredGames);

        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnWishlist_Click(object sender, EventArgs e)
        {
            WishlistForm wishlistForm = new WishlistForm();
            wishlistForm.Owner = this;
            wishlistForm.ShowDialog();
        }

        private void btnTheme_Click(object sender, EventArgs e)
        {
            DarkMode = !DarkMode;

            if (DarkMode)
                btnTheme.ForeColor = Color.Gold;
            else
                btnTheme.ForeColor = Color.Black;

            ApplyThemeToControl(this);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblUser.Text = UserSession.CurrentUsername;

            featuredGames = games.Take(3).ToList();
            ShowFeaturedGame();

            ShowFeaturedGame();

            featuredTimer.Interval = 4000;
            featuredTimer.Tick += featuredTimer_Tick;
            featuredTimer.Start();
        }

        private void featuredTimer_Tick(object sender, EventArgs e)
        {
            featuredIndex++;
            if (featuredIndex >= featuredGames.Count)
                featuredIndex = 0;

            ShowFeaturedGame();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            featuredIndex--;
            if (featuredIndex < 0)
                featuredIndex = featuredGames.Count - 1;

            ShowFeaturedGame();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            featuredIndex++;
            if (featuredIndex >= featuredGames.Count)
                featuredIndex = 0;

            ShowFeaturedGame();
        }

        private void pbFeatured_MouseEnter(object sender, EventArgs e)
        {
            featuredTimer.Stop();
        }

        private void pbFeatured_MouseLeave(object sender, EventArgs e)
        {
            featuredTimer.Start();
        }

        private void pbFeatured_Click_1(object sender, EventArgs e)
        {
            Game selectedGame = pbFeatured.Tag as Game;

            if (selectedGame != null)
            {
                GameDetailsForm details = new GameDetailsForm(selectedGame);
                details.ShowDialog();
            }
        }

        private void btnLibrary_Click(object sender, EventArgs e)
        {
            LibraryForm library = new LibraryForm();
            library.Owner = this;
            library.ShowDialog();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
