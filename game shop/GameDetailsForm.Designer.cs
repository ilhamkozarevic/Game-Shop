namespace game_shop
{
    partial class GameDetailsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblGameName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.picGame = new System.Windows.Forms.PictureBox();
            this.lblRating = new System.Windows.Forms.Label();
            this.lblWriteReview = new System.Windows.Forms.Label();
            this.rtbReview = new System.Windows.Forms.RichTextBox();
            this.btnSendReview = new System.Windows.Forms.Button();
            this.btnAddToWishlist = new System.Windows.Forms.Button();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.btnShowReviews = new System.Windows.Forms.Button();
            this.lblRating2 = new System.Windows.Forms.Label();
            this.panelStars = new System.Windows.Forms.Panel();
            this.pbSlider = new System.Windows.Forms.PictureBox();
            this.btnSliderLeft = new System.Windows.Forms.Button();
            this.btnSliderRight = new System.Windows.Forms.Button();
            this.sliderTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGameName
            // 
            this.lblGameName.AutoSize = true;
            this.lblGameName.Font = new System.Drawing.Font("Bauhaus 93", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameName.ForeColor = System.Drawing.Color.White;
            this.lblGameName.Location = new System.Drawing.Point(13, 287);
            this.lblGameName.Name = "lblGameName";
            this.lblGameName.Size = new System.Drawing.Size(70, 24);
            this.lblGameName.TabIndex = 1;
            this.lblGameName.Text = "label1";
            // 
            // lblDescription
            // 
            this.lblDescription.ForeColor = System.Drawing.Color.LightGray;
            this.lblDescription.Location = new System.Drawing.Point(15, 342);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(288, 62);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "label1";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.lblPrice.Location = new System.Drawing.Point(20, 466);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(65, 25);
            this.lblPrice.TabIndex = 3;
            this.lblPrice.Text = "label1";
            // 
            // picGame
            // 
            this.picGame.Location = new System.Drawing.Point(514, 21);
            this.picGame.Name = "picGame";
            this.picGame.Size = new System.Drawing.Size(212, 250);
            this.picGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picGame.TabIndex = 0;
            this.picGame.TabStop = false;
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.ForeColor = System.Drawing.Color.White;
            this.lblRating.Location = new System.Drawing.Point(501, 293);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(41, 13);
            this.lblRating.TabIndex = 6;
            this.lblRating.Text = "Rating:";
            // 
            // lblWriteReview
            // 
            this.lblWriteReview.AutoSize = true;
            this.lblWriteReview.ForeColor = System.Drawing.Color.White;
            this.lblWriteReview.Location = new System.Drawing.Point(548, 327);
            this.lblWriteReview.Name = "lblWriteReview";
            this.lblWriteReview.Size = new System.Drawing.Size(78, 13);
            this.lblWriteReview.TabIndex = 7;
            this.lblWriteReview.Text = "Write a review:";
            // 
            // rtbReview
            // 
            this.rtbReview.Location = new System.Drawing.Point(551, 347);
            this.rtbReview.Name = "rtbReview";
            this.rtbReview.Size = new System.Drawing.Size(180, 96);
            this.rtbReview.TabIndex = 8;
            this.rtbReview.Text = "";
            // 
            // btnSendReview
            // 
            this.btnSendReview.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSendReview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendReview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendReview.Location = new System.Drawing.Point(679, 420);
            this.btnSendReview.Name = "btnSendReview";
            this.btnSendReview.Size = new System.Drawing.Size(52, 23);
            this.btnSendReview.TabIndex = 9;
            this.btnSendReview.Text = "SEND";
            this.btnSendReview.UseVisualStyleBackColor = false;
            this.btnSendReview.Click += new System.EventHandler(this.btnSendReview_Click);
            // 
            // btnAddToWishlist
            // 
            this.btnAddToWishlist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAddToWishlist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddToWishlist.ForeColor = System.Drawing.Color.White;
            this.btnAddToWishlist.Location = new System.Drawing.Point(397, 459);
            this.btnAddToWishlist.Name = "btnAddToWishlist";
            this.btnAddToWishlist.Size = new System.Drawing.Size(150, 45);
            this.btnAddToWishlist.TabIndex = 5;
            this.btnAddToWishlist.Text = "Add to Wishlist";
            this.btnAddToWishlist.UseVisualStyleBackColor = false;
            this.btnAddToWishlist.Click += new System.EventHandler(this.btnAddToWishlist_Click);
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(13)))), ((int)(((byte)(173)))));
            this.btnAddToCart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddToCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToCart.ForeColor = System.Drawing.Color.White;
            this.btnAddToCart.Location = new System.Drawing.Point(581, 459);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(150, 45);
            this.btnAddToCart.TabIndex = 4;
            this.btnAddToCart.Text = "Add to Cart";
            this.btnAddToCart.UseVisualStyleBackColor = false;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // btnShowReviews
            // 
            this.btnShowReviews.BackColor = System.Drawing.Color.SteelBlue;
            this.btnShowReviews.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowReviews.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowReviews.Location = new System.Drawing.Point(452, 374);
            this.btnShowReviews.Name = "btnShowReviews";
            this.btnShowReviews.Size = new System.Drawing.Size(75, 40);
            this.btnShowReviews.TabIndex = 10;
            this.btnShowReviews.Text = "Show reviews";
            this.btnShowReviews.UseVisualStyleBackColor = true;
            this.btnShowReviews.Click += new System.EventHandler(this.btnShowReviews_Click);
            // 
            // lblRating2
            // 
            this.lblRating2.AutoSize = true;
            this.lblRating2.Location = new System.Drawing.Point(16, 420);
            this.lblRating2.Name = "lblRating2";
            this.lblRating2.Size = new System.Drawing.Size(35, 13);
            this.lblRating2.TabIndex = 16;
            this.lblRating2.Text = "label6";
            // 
            // panelStars
            // 
            this.panelStars.BackColor = System.Drawing.Color.Transparent;
            this.panelStars.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelStars.Location = new System.Drawing.Point(551, 280);
            this.panelStars.Name = "panelStars";
            this.panelStars.Size = new System.Drawing.Size(219, 37);
            this.panelStars.TabIndex = 17;
            // 
            // pbSlider
            // 
            this.pbSlider.Location = new System.Drawing.Point(36, 21);
            this.pbSlider.Name = "pbSlider";
            this.pbSlider.Size = new System.Drawing.Size(439, 250);
            this.pbSlider.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSlider.TabIndex = 18;
            this.pbSlider.TabStop = false;
            // 
            // btnSliderLeft
            // 
            this.btnSliderLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSliderLeft.Location = new System.Drawing.Point(482, 21);
            this.btnSliderLeft.Name = "btnSliderLeft";
            this.btnSliderLeft.Size = new System.Drawing.Size(18, 250);
            this.btnSliderLeft.TabIndex = 19;
            this.btnSliderLeft.Text = ">";
            this.btnSliderLeft.UseVisualStyleBackColor = true;
            this.btnSliderLeft.Click += new System.EventHandler(this.btnSliderLeft_Click);
            // 
            // btnSliderRight
            // 
            this.btnSliderRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSliderRight.Location = new System.Drawing.Point(11, 21);
            this.btnSliderRight.Name = "btnSliderRight";
            this.btnSliderRight.Size = new System.Drawing.Size(18, 250);
            this.btnSliderRight.TabIndex = 20;
            this.btnSliderRight.Text = "<";
            this.btnSliderRight.UseVisualStyleBackColor = true;
            this.btnSliderRight.Click += new System.EventHandler(this.btnSliderRight_Click);
            // 
            // sliderTimer
            // 
            this.sliderTimer.Interval = 2500;
            // 
            // GameDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(743, 516);
            this.Controls.Add(this.btnSliderRight);
            this.Controls.Add(this.btnSliderLeft);
            this.Controls.Add(this.pbSlider);
            this.Controls.Add(this.panelStars);
            this.Controls.Add(this.lblRating2);
            this.Controls.Add(this.btnShowReviews);
            this.Controls.Add(this.btnSendReview);
            this.Controls.Add(this.rtbReview);
            this.Controls.Add(this.lblWriteReview);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.btnAddToWishlist);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblGameName);
            this.Controls.Add(this.picGame);
            this.Name = "GameDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Game Details";
            ((System.ComponentModel.ISupportInitialize)(this.picGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picGame;
        private System.Windows.Forms.Label lblGameName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Label lblWriteReview;
        private System.Windows.Forms.RichTextBox rtbReview;
        private System.Windows.Forms.Button btnSendReview;
        private System.Windows.Forms.Button btnAddToWishlist;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.Button btnShowReviews;
        private System.Windows.Forms.Label lblRating2;
        private System.Windows.Forms.Panel panelStars;
        private System.Windows.Forms.PictureBox pbSlider;
        private System.Windows.Forms.Button btnSliderLeft;
        private System.Windows.Forms.Button btnSliderRight;
        private System.Windows.Forms.Timer sliderTimer;
    }
}