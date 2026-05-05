namespace game_shop
{
    partial class CartForm
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
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.flowCart = new System.Windows.Forms.FlowLayoutPanel();
            this.lblEmptyCart = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(12, 487);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(116, 21);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "Total: 0.00 KM";
            // 
            // btnCheckout
            // 
            this.btnCheckout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(167)))), ((int)(((byte)(45)))));
            this.btnCheckout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.Location = new System.Drawing.Point(326, 459);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(120, 40);
            this.btnCheckout.TabIndex = 3;
            this.btnCheckout.Text = "Checkout";
            this.btnCheckout.UseVisualStyleBackColor = false;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // flowCart
            // 
            this.flowCart.AutoScroll = true;
            this.flowCart.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowCart.Location = new System.Drawing.Point(0, 0);
            this.flowCart.Name = "flowCart";
            this.flowCart.Size = new System.Drawing.Size(458, 452);
            this.flowCart.TabIndex = 4;
            // 
            // lblEmptyCart
            // 
            this.lblEmptyCart.AutoSize = true;
            this.lblEmptyCart.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblEmptyCart.ForeColor = System.Drawing.Color.Gray;
            this.lblEmptyCart.Location = new System.Drawing.Point(128, 455);
            this.lblEmptyCart.Name = "lblEmptyCart";
            this.lblEmptyCart.Size = new System.Drawing.Size(180, 23);
            this.lblEmptyCart.TabIndex = 0;
            this.lblEmptyCart.Text = "Your cart is empty...";
            // 
            // CartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(458, 517);
            this.Controls.Add(this.lblEmptyCart);
            this.Controls.Add(this.flowCart);
            this.Controls.Add(this.btnCheckout);
            this.Controls.Add(this.lblTotal);
            this.Name = "CartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Your Cart";
            this.Load += new System.EventHandler(this.CartForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.FlowLayoutPanel flowCart;
        private System.Windows.Forms.Label lblEmptyCart;
    }
}