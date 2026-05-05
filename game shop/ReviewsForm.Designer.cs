namespace game_shop
{
    partial class ReviewsForm
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
            this.rtbReviewsDisplay = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbReviewsDisplay
            // 
            this.rtbReviewsDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.rtbReviewsDisplay.ForeColor = System.Drawing.Color.White;
            this.rtbReviewsDisplay.Location = new System.Drawing.Point(52, 27);
            this.rtbReviewsDisplay.Name = "rtbReviewsDisplay";
            this.rtbReviewsDisplay.ReadOnly = true;
            this.rtbReviewsDisplay.Size = new System.Drawing.Size(636, 431);
            this.rtbReviewsDisplay.TabIndex = 0;
            this.rtbReviewsDisplay.Text = "";
            // 
            // ReviewsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(743, 516);
            this.Controls.Add(this.rtbReviewsDisplay);
            this.Name = "ReviewsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reviews";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbReviewsDisplay;
    }
}