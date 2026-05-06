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
    public partial class ReviewsForm : Form
    {
        OleDbConnection connection;

        public ReviewsForm(int igraId)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=GameShop.accdb;");

            InitializeComponent();

            LoadReviews(igraId);

            MainForm.ApplyThemeToControl(this);
        }

        private void LoadReviews(int igraId)
        {
            rtbReviewsDisplay.Clear();

            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();

                OleDbCommand cmd = connection.CreateCommand();
                cmd.CommandText = (@"
                        SELECT Recenzije.*, Korisnici.KorisnickoIme 
                        FROM Recenzije 
                        INNER JOIN Korisnici ON Recenzije.KorisnikID = Korisnici.KorisnikID 
                        WHERE Recenzije.IgraID = @IgraID");

                cmd.Parameters.AddWithValue("@IgraID", igraId);

                OleDbDataReader reader = cmd.ExecuteReader();

                int count = 1;

                while (reader.Read())
                {
                    string komentar = reader["Komentar"].ToString();
                    int ocjena = Convert.ToInt32(reader["Ocjena"]);
                    string korisnickoIme = reader["KorisnickoIme"].ToString();

                    rtbReviewsDisplay.AppendText(korisnickoIme + ": [" + ocjena + "★] " + komentar + "\r\n\r\n");
                    count++;
                }

                if (count == 1)
                {
                    rtbReviewsDisplay.Text = "There are no reviews for this game yet.";
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju recenzija: " + ex.Message);
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
