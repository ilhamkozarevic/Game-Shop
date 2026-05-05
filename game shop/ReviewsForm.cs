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
    public partial class ReviewsForm : Form
    {
        public ReviewsForm(string gameName)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            InitializeComponent();

            LoadReviews(gameName);

            MainForm.ApplyThemeToControl(this);
        }

        private void LoadReviews(string gameName)
        {
        rtbReviewsDisplay.Clear();
        if (!System.IO.File.Exists("reviews.txt")) return;

        string[] lines = System.IO.File.ReadAllLines("reviews.txt");
        int count = 1;

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length != 3) continue;

            if (parts[0] == gameName)
            {
                rtbReviewsDisplay.AppendText("Oblutak " + count + ": [" + parts[1] + "★] " + parts[2] + "\r\n\r\n");

                count++;
            }
        }

        if (count == 1) rtbReviewsDisplay.Text = "There are no reviews for this game yet.";
        }
     }
}
