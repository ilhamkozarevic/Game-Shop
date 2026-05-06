namespace game_shop
{
    partial class MainForm
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnLibrary = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnWishlist = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.cmbGenres = new System.Windows.Forms.ComboBox();
            this.btnCart = new System.Windows.Forms.Button();
            this.lblGenres = new System.Windows.Forms.Label();
            this.flowGames = new System.Windows.Forms.FlowLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslCart = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.rbSortPriceDesc = new System.Windows.Forms.RadioButton();
            this.rbSortNameDesc = new System.Windows.Forms.RadioButton();
            this.rbSortPriceAsc = new System.Windows.Forms.RadioButton();
            this.rbSortNameAsc = new System.Windows.Forms.RadioButton();
            this.btnTheme = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.flowMainVertical = new System.Windows.Forms.FlowLayoutPanel();
            this.panelFeatured = new System.Windows.Forms.Panel();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.pbFeatured = new System.Windows.Forms.PictureBox();
            this.featuredTimer = new System.Windows.Forms.Timer(this.components);
            this.lblUser = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picBanner = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.flowMainVertical.SuspendLayout();
            this.panelFeatured.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFeatured)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBanner)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.AutoScroll = true;
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.panelTop.Controls.Add(this.btnLibrary);
            this.panelTop.Controls.Add(this.pbLogo);
            this.panelTop.Controls.Add(this.btnWishlist);
            this.panelTop.Controls.Add(this.txtSearch);
            this.panelTop.Controls.Add(this.lblSearch);
            this.panelTop.Controls.Add(this.cmbGenres);
            this.panelTop.Controls.Add(this.btnCart);
            this.panelTop.Controls.Add(this.lblGenres);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(994, 90);
            this.panelTop.TabIndex = 0;
            // 
            // btnLibrary
            // 
            this.btnLibrary.BackColor = System.Drawing.Color.ForestGreen;
            this.btnLibrary.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLibrary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLibrary.ForeColor = System.Drawing.Color.White;
            this.btnLibrary.Location = new System.Drawing.Point(855, 49);
            this.btnLibrary.Name = "btnLibrary";
            this.btnLibrary.Size = new System.Drawing.Size(85, 35);
            this.btnLibrary.TabIndex = 6;
            this.btnLibrary.Text = "Library";
            this.btnLibrary.UseVisualStyleBackColor = false;
            this.btnLibrary.Click += new System.EventHandler(this.btnLibrary_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::game_shop.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(23, 3);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(166, 87);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 5;
            this.pbLogo.TabStop = false;
            // 
            // btnWishlist
            // 
            this.btnWishlist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnWishlist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWishlist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWishlist.ForeColor = System.Drawing.Color.White;
            this.btnWishlist.Location = new System.Drawing.Point(898, 8);
            this.btnWishlist.Name = "btnWishlist";
            this.btnWishlist.Size = new System.Drawing.Size(85, 35);
            this.btnWishlist.TabIndex = 4;
            this.btnWishlist.Text = "Wishlist";
            this.btnWishlist.UseVisualStyleBackColor = false;
            this.btnWishlist.Click += new System.EventHandler(this.btnWishlist_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(298, 34);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(150, 20);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.ForeColor = System.Drawing.Color.White;
            this.lblSearch.Location = new System.Drawing.Point(230, 37);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(44, 13);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Search:";
            // 
            // cmbGenres
            // 
            this.cmbGenres.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbGenres.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenres.FormattingEnabled = true;
            this.cmbGenres.Location = new System.Drawing.Point(615, 34);
            this.cmbGenres.Name = "cmbGenres";
            this.cmbGenres.Size = new System.Drawing.Size(150, 21);
            this.cmbGenres.TabIndex = 0;
            this.cmbGenres.SelectedIndexChanged += new System.EventHandler(this.cmbGenres_SelectedIndexChanged);
            // 
            // btnCart
            // 
            this.btnCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(13)))), ((int)(((byte)(173)))));
            this.btnCart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCart.ForeColor = System.Drawing.Color.White;
            this.btnCart.Location = new System.Drawing.Point(807, 8);
            this.btnCart.Name = "btnCart";
            this.btnCart.Size = new System.Drawing.Size(85, 35);
            this.btnCart.TabIndex = 1;
            this.btnCart.Text = "Cart";
            this.btnCart.UseVisualStyleBackColor = false;
            this.btnCart.Click += new System.EventHandler(this.btnCart_Click);
            // 
            // lblGenres
            // 
            this.lblGenres.AutoSize = true;
            this.lblGenres.ForeColor = System.Drawing.Color.White;
            this.lblGenres.Location = new System.Drawing.Point(525, 37);
            this.lblGenres.Name = "lblGenres";
            this.lblGenres.Size = new System.Drawing.Size(72, 13);
            this.lblGenres.TabIndex = 1;
            this.lblGenres.Text = "Select Genre:";
            // 
            // flowGames
            // 
            this.flowGames.Location = new System.Drawing.Point(3, 234);
            this.flowGames.Name = "flowGames";
            this.flowGames.Size = new System.Drawing.Size(714, 1325);
            this.flowGames.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslCart});
            this.statusStrip1.Location = new System.Drawing.Point(0, 699);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(994, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslCart
            // 
            this.tslCart.BackColor = System.Drawing.Color.Transparent;
            this.tslCart.Name = "tslCart";
            this.tslCart.Size = new System.Drawing.Size(0, 17);
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.White;
            this.lblStatus.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(91, 17);
            this.lblStatus.Text = "Games in cart: 0";
            // 
            // rbSortPriceDesc
            // 
            this.rbSortPriceDesc.AutoSize = true;
            this.rbSortPriceDesc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbSortPriceDesc.ForeColor = System.Drawing.Color.White;
            this.rbSortPriceDesc.Location = new System.Drawing.Point(332, 9);
            this.rbSortPriceDesc.Name = "rbSortPriceDesc";
            this.rbSortPriceDesc.Size = new System.Drawing.Size(109, 17);
            this.rbSortPriceDesc.TabIndex = 1;
            this.rbSortPriceDesc.Text = "Price Descending";
            this.rbSortPriceDesc.UseVisualStyleBackColor = true;
            this.rbSortPriceDesc.CheckedChanged += new System.EventHandler(this.rbSort_CheckedChanged);
            // 
            // rbSortNameDesc
            // 
            this.rbSortNameDesc.AutoSize = true;
            this.rbSortNameDesc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbSortNameDesc.ForeColor = System.Drawing.Color.White;
            this.rbSortNameDesc.Location = new System.Drawing.Point(111, 7);
            this.rbSortNameDesc.Name = "rbSortNameDesc";
            this.rbSortNameDesc.Size = new System.Drawing.Size(73, 17);
            this.rbSortNameDesc.TabIndex = 1;
            this.rbSortNameDesc.Text = "Name Z-A";
            this.rbSortNameDesc.UseVisualStyleBackColor = true;
            this.rbSortNameDesc.CheckedChanged += new System.EventHandler(this.rbSort_CheckedChanged);
            // 
            // rbSortPriceAsc
            // 
            this.rbSortPriceAsc.AutoSize = true;
            this.rbSortPriceAsc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbSortPriceAsc.ForeColor = System.Drawing.Color.White;
            this.rbSortPriceAsc.Location = new System.Drawing.Point(218, 9);
            this.rbSortPriceAsc.Name = "rbSortPriceAsc";
            this.rbSortPriceAsc.Size = new System.Drawing.Size(102, 17);
            this.rbSortPriceAsc.TabIndex = 0;
            this.rbSortPriceAsc.Text = "Price Ascending";
            this.rbSortPriceAsc.UseVisualStyleBackColor = true;
            this.rbSortPriceAsc.CheckedChanged += new System.EventHandler(this.rbSort_CheckedChanged);
            // 
            // rbSortNameAsc
            // 
            this.rbSortNameAsc.AutoSize = true;
            this.rbSortNameAsc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbSortNameAsc.ForeColor = System.Drawing.Color.White;
            this.rbSortNameAsc.Location = new System.Drawing.Point(2, 7);
            this.rbSortNameAsc.Name = "rbSortNameAsc";
            this.rbSortNameAsc.Size = new System.Drawing.Size(73, 17);
            this.rbSortNameAsc.TabIndex = 0;
            this.rbSortNameAsc.Text = "Name A-Z";
            this.rbSortNameAsc.UseVisualStyleBackColor = true;
            this.rbSortNameAsc.CheckedChanged += new System.EventHandler(this.rbSort_CheckedChanged);
            // 
            // btnTheme
            // 
            this.btnTheme.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTheme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnTheme.ForeColor = System.Drawing.Color.White;
            this.btnTheme.Location = new System.Drawing.Point(954, 184);
            this.btnTheme.Name = "btnTheme";
            this.btnTheme.Size = new System.Drawing.Size(40, 39);
            this.btnTheme.TabIndex = 7;
            this.btnTheme.Text = "☀";
            this.btnTheme.UseVisualStyleBackColor = true;
            this.btnTheme.Click += new System.EventHandler(this.btnTheme_Click);
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.AutoScrollMinSize = new System.Drawing.Size(500, 500);
            this.panelContent.Controls.Add(this.flowMainVertical);
            this.panelContent.Location = new System.Drawing.Point(0, 224);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(994, 472);
            this.panelContent.TabIndex = 0;
            // 
            // flowMainVertical
            // 
            this.flowMainVertical.AutoSize = true;
            this.flowMainVertical.Controls.Add(this.panelFeatured);
            this.flowMainVertical.Controls.Add(this.flowGames);
            this.flowMainVertical.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowMainVertical.Location = new System.Drawing.Point(175, 3);
            this.flowMainVertical.Name = "flowMainVertical";
            this.flowMainVertical.Size = new System.Drawing.Size(729, 1562);
            this.flowMainVertical.TabIndex = 9;
            this.flowMainVertical.WrapContents = false;
            // 
            // panelFeatured
            // 
            this.panelFeatured.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.panelFeatured.Controls.Add(this.btnLeft);
            this.panelFeatured.Controls.Add(this.btnRight);
            this.panelFeatured.Controls.Add(this.pbFeatured);
            this.panelFeatured.Location = new System.Drawing.Point(3, 3);
            this.panelFeatured.Name = "panelFeatured";
            this.panelFeatured.Size = new System.Drawing.Size(714, 225);
            this.panelFeatured.TabIndex = 8;
            // 
            // btnLeft
            // 
            this.btnLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.btnLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeft.ForeColor = System.Drawing.Color.White;
            this.btnLeft.Location = new System.Drawing.Point(99, 4);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(24, 218);
            this.btnLeft.TabIndex = 9;
            this.btnLeft.Text = "<";
            this.btnLeft.UseVisualStyleBackColor = false;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.btnRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRight.ForeColor = System.Drawing.Color.White;
            this.btnRight.Location = new System.Drawing.Point(553, 4);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(24, 218);
            this.btnRight.TabIndex = 10;
            this.btnRight.Text = ">";
            this.btnRight.UseVisualStyleBackColor = false;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // pbFeatured
            // 
            this.pbFeatured.Location = new System.Drawing.Point(129, 4);
            this.pbFeatured.Name = "pbFeatured";
            this.pbFeatured.Size = new System.Drawing.Size(418, 218);
            this.pbFeatured.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFeatured.TabIndex = 0;
            this.pbFeatured.TabStop = false;
            this.pbFeatured.MouseLeave += new System.EventHandler(this.pbFeatured_MouseLeave);
            this.pbFeatured.Click += new System.EventHandler(this.pbFeatured_Click_1);
            this.pbFeatured.MouseEnter += new System.EventHandler(this.pbFeatured_MouseEnter);
            // 
            // featuredTimer
            // 
            this.featuredTimer.Interval = 50;
            this.featuredTimer.Tick += new System.EventHandler(this.featuredTimer_Tick);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblUser.ForeColor = System.Drawing.Color.White;
            this.lblUser.Location = new System.Drawing.Point(47, 196);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(51, 20);
            this.lblUser.TabIndex = 8;
            this.lblUser.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::game_shop.Properties.Resources.profile_picture2;
            this.pictureBox1.Location = new System.Drawing.Point(9, 190);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // picBanner
            // 
            this.picBanner.Image = global::game_shop.Properties.Resources.banner;
            this.picBanner.Location = new System.Drawing.Point(0, 88);
            this.picBanner.Name = "picBanner";
            this.picBanner.Size = new System.Drawing.Size(1000, 95);
            this.picBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBanner.TabIndex = 2;
            this.picBanner.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSortPriceDesc);
            this.groupBox1.Controls.Add(this.rbSortNameDesc);
            this.groupBox1.Controls.Add(this.rbSortPriceAsc);
            this.groupBox1.Controls.Add(this.rbSortNameAsc);
            this.groupBox1.Location = new System.Drawing.Point(286, 184);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(455, 30);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(994, 721);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnTheme);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.picBanner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameHub Shop";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.flowMainVertical.ResumeLayout(false);
            this.panelFeatured.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbFeatured)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBanner)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnCart;
        private System.Windows.Forms.PictureBox picBanner;
        private System.Windows.Forms.FlowLayoutPanel flowGames;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ComboBox cmbGenres;
        private System.Windows.Forms.Label lblGenres;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnWishlist;
        private System.Windows.Forms.RadioButton rbSortNameDesc;
        private System.Windows.Forms.RadioButton rbSortNameAsc;
        private System.Windows.Forms.RadioButton rbSortPriceDesc;
        private System.Windows.Forms.RadioButton rbSortPriceAsc;
        private System.Windows.Forms.Button btnTheme;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelFeatured;
        private System.Windows.Forms.PictureBox pbFeatured;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Timer featuredTimer;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowMainVertical;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnLibrary;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripStatusLabel tslCart;
    }
}

