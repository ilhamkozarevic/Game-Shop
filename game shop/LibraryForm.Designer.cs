namespace game_shop
{
    partial class LibraryForm
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
            this.flowLibrary = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLibrary
            // 
            this.flowLibrary.AutoScroll = true;
            this.flowLibrary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLibrary.Location = new System.Drawing.Point(0, 0);
            this.flowLibrary.Name = "flowLibrary";
            this.flowLibrary.Padding = new System.Windows.Forms.Padding(63, 10, 20, 10);
            this.flowLibrary.Size = new System.Drawing.Size(484, 487);
            this.flowLibrary.TabIndex = 0;
            // 
            // LibraryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(484, 487);
            this.Controls.Add(this.flowLibrary);
            this.Name = "LibraryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Library";
            this.Load += new System.EventHandler(this.LibraryForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLibrary;
    }
}