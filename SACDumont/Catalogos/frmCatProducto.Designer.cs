namespace SACDumont.Catalogos
{
    partial class frmCatProducto
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
            this.lbProductoID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbProductoID
            // 
            this.lbProductoID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbProductoID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProductoID.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lbProductoID.Location = new System.Drawing.Point(517, 524);
            this.lbProductoID.Name = "lbProductoID";
            this.lbProductoID.Size = new System.Drawing.Size(100, 23);
            this.lbProductoID.TabIndex = 34;
            this.lbProductoID.Text = "lbProductoID";
            this.lbProductoID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmCatProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 556);
            this.Controls.Add(this.lbProductoID);
            this.Name = "frmCatProducto";
            this.Text = "frmCatProducto";
            this.Load += new System.EventHandler(this.frmCatProducto_Load);
            this.Controls.SetChildIndex(this.lbProductoID, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbProductoID;
    }
}