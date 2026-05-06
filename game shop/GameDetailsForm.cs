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
    public partial class GameDetailsForm : Form
    {
        List<string> sliderImages = new List<string>();
        int sliderIndex = 0;

        Game selectedGame;

        private List<PictureBox> starBoxes = new List<PictureBox>();
        private int selectedRating = 0;

        PictureBox[] stars = new PictureBox[5];

        OleDbConnection connection;

        public GameDetailsForm(Game game)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=GameShop.accdb;");

            InitializeComponent();

            CreateStarRating();

            selectedGame = game;

            LoadSliderImages();
            ShowSliderImage();

            sliderTimer.Tick += sliderTimer_Tick;
            sliderTimer.Start();

            pbSlider.MouseEnter += (s, e) => sliderTimer.Stop();
            pbSlider.MouseLeave += (s, e) => sliderTimer.Start();

            lblGameName.Text = game.Name;
            lblDescription.Text = game.Description;
            lblPrice.Text = game.Price.ToString("0.00") + " KM";
            picGame.ImageLocation = game.ImagePath;

            MainForm.ApplyThemeToControl(this);

            LoadAverageRating();
        }

        void LoadSliderImages()
        {
            sliderImages.Clear();

            string folderPath = Path.Combine("Images", selectedGame.Name);

            if (Directory.Exists(folderPath))
            {
                string[] files = Directory.GetFiles(folderPath);

                foreach (string file in files)
                {
                    sliderImages.Add(file);
                }
            }
        }

        private void sliderTimer_Tick(object sender, EventArgs e)
        {
            sliderIndex++;
            if (sliderIndex >= sliderImages.Count)
                sliderIndex = 0;

            ShowSliderImage();
        }

        void ShowSliderImage()
        {
            if (sliderImages.Count == 0) return;

            pbSlider.ImageLocation = sliderImages[sliderIndex];
        }

        void CreateStarRating()
        {
            for (int i = 0; i < 5; i++)
            {
                PictureBox star = new PictureBox();
                star.Width = 35;
                star.Height = 35;
                star.Left = i * 37;
                star.Top = 0;
                star.SizeMode = PictureBoxSizeMode.StretchImage;
                star.Cursor = Cursors.Hand;
                star.Tag = i + 1;

                star.ImageLocation = "Images/star_empty.png";

                star.Click += Star_Click;
                star.MouseEnter += Star_MouseEnter;
                star.MouseLeave += Star_MouseLeave;

                stars[i] = star;
                starBoxes.Add(star);
                panelStars.Controls.Add(star);
            }
        }

        void Star_Click(object sender, EventArgs e)
        {
            PictureBox clickedStar = sender as PictureBox;
            selectedRating = (int)clickedStar.Tag;

            for (int i = 0; i < 5; i++)
            {
                if (i < selectedRating)
                    stars[i].ImageLocation = "Images/star_filled.png";
                else
                    stars[i].ImageLocation = "Images/star_empty.png";
            }
        }

        private void LoadAverageRating()
        {
            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                OleDbCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = ("SELECT AVG(Ocjena) AS Prosjek, COUNT(Ocjena) AS Broj FROM Recenzije WHERE IgraID = @IgraID");

                cmd.Parameters.AddWithValue("@IgraID", selectedGame.Id);

                OleDbDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    if (reader["Prosjek"] != DBNull.Value)
                    {
                        double avg = Convert.ToDouble(reader["Prosjek"]);
                        int fullStars = (int)Math.Round(avg);
                        string stars = new string('★', fullStars).PadRight(5, '☆');

                        lblRating2.Text = stars + " (" + avg.ToString("0.0") + ")";
                    }
                    else
                    {
                        lblRating2.Text = "☆☆☆☆☆ (0.0)";
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                lblRating2.Text = "☆☆☆☆☆ (0.0)";
            }
            finally
            {
                if (connection.State == ConnectionState.Open) connection.Close();
            }
        }

        private string GetStars(double rating)
        {
            int full = (int)Math.Round(rating);
            full = Math.Max(0, Math.Min(5, full));

            string stars = "";

            for (int i = 0; i < full; i++)
                stars += "★";

            for (int i = full; i < 5; i++)
                stars += "☆";

            return stars;
        }

        private int GetRating()
        {
            return selectedRating;
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            MainForm.cart.Add(selectedGame);
            MessageBox.Show(selectedGame.Name + " has been successfully added to your cart!", "Game Added", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnAddToWishlist_Click(object sender, EventArgs e)
        {
            if (!MainForm.wishlist.Contains(selectedGame))
            {
                MainForm.wishlist.Add(selectedGame);
                MessageBox.Show(selectedGame.Name + " has been successfully added to your Wishlist!", "Wishlist Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show(selectedGame.Name + " is already in your Wishlist!", "Wishlist Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSendReview_Click(object sender, EventArgs e)
        {
            int rating = GetRating();
            string review = rtbReview.Text.Trim();

            int korisnikId = UserSession.CurrentUserId;

            if (rating == 0 || string.IsNullOrEmpty(review))
            {
                MessageBox.Show("Please select a rating and write a review!", "Review Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                OleDbCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = ("INSERT INTO Recenzije (KorisnikID, IgraID, Ocjena, Komentar) VALUES (@KorisnikID, @IgraID, @Ocjena, @Komentar)");

                cmd.Parameters.AddWithValue("@KorisnikID", korisnikId);
                cmd.Parameters.AddWithValue("@IgraID", selectedGame.Id);
                cmd.Parameters.AddWithValue("@Ocjena", rating);
                cmd.Parameters.AddWithValue("@Komentar", review);

                cmd.ExecuteNonQuery();

                rtbReview.Clear();
                selectedRating = 0;
                foreach (PictureBox star in starBoxes)
                {
                    star.ImageLocation = "Images/star_empty.png";
                }

                MessageBox.Show("Review has been added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAverageRating();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri slanju recenzije: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open) connection.Close();
            }
        }

        private void btnShowReviews_Click(object sender, EventArgs e)
        {
            ReviewsForm reviewsForm = new ReviewsForm(selectedGame.Id);
            reviewsForm.ShowDialog();
        }

        private void btnSliderRight_Click(object sender, EventArgs e)
        {
            sliderIndex--;
            if (sliderIndex < 0)
                sliderIndex = sliderImages.Count - 1;

            ShowSliderImage();
        }

        private void btnSliderLeft_Click(object sender, EventArgs e)
        {
            sliderIndex++;
            if (sliderIndex >= sliderImages.Count)
                sliderIndex = 0;

            ShowSliderImage();
        }

        void Star_MouseEnter(object sender, EventArgs e)
        {
            PictureBox hoveredStar = sender as PictureBox;
            int hoverRating = (int)hoveredStar.Tag;

            for (int i = 0; i < 5; i++)
            {
                if (i < hoverRating)
                    stars[i].ImageLocation = "Images/star_filled.png";
                else
                    stars[i].ImageLocation = "Images/star_empty.png";
            }
        }

        void Star_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                if (i < selectedRating)
                    stars[i].ImageLocation = "Images/star_filled.png";
                else
                    stars[i].ImageLocation = "Images/star_empty.png";
            }
        }

    }
}
