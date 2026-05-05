namespace game_shop
{
    partial class WishlistForm
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
            this.flowWishlist = new System.Windows.Forms.FlowLayoutPanel();
            this.lblEmptyWishlist = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flowWishlist
            // 
            this.flowWishlist.AutoScroll = true;
            this.flowWishlist.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowWishlist.Location = new System.Drawing.Point(0, 0);
            this.flowWishlist.Name = "flowWishlist";
            this.flowWishlist.Size = new System.Drawing.Size(504, 426);
            this.flowWishlist.TabIndex = 0;
            // 
            // lblEmptyWishlist
            // 
            this.lblEmptyWishlist.AutoSize = true;
            this.lblEmptyWishlist.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblEmptyWishlist.ForeColor = System.Drawing.Color.Gray;
            this.lblEmptyWishlist.Location = new System.Drawing.Point(145, 429);
            this.lblEmptyWishlist.Name = "lblEmptyWishlist";
            this.lblEmptyWishlist.Size = new System.Drawing.Size(227, 23);
            this.lblEmptyWishlist.TabIndex = 1;
            this.lblEmptyWishlist.Text = "\"Your wishlist is empty...\"";
            this.lblEmptyWishlist.Visible = false;
            // 
            // WishlistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(504, 461);
            this.Controls.Add(this.lblEmptyWishlist);
            this.Controls.Add(this.flowWishlist);
            this.Name = "WishlistForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wishlist";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowWishlist;
        private System.Windows.Forms.Label lblEmptyWishlist;

    }
}