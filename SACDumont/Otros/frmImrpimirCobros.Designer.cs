namespace SACDumont.Otros
{
    partial class frmImrpimirCobros
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.reporteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btTicketImpresora = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvCobros = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCobros)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reporteToolStripMenuItem,
            this.btTicketImpresora});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(531, 59);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // reporteToolStripMenuItem
            // 
            this.reporteToolStripMenuItem.AutoToolTip = true;
            this.reporteToolStripMenuItem.Image = global::SACDumont.Properties.Resources.reportes;
            this.reporteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.reporteToolStripMenuItem.Name = "reporteToolStripMenuItem";
            this.reporteToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.reporteToolStripMenuItem.Size = new System.Drawing.Size(119, 55);
            this.reporteToolStripMenuItem.Text = "Reimpresion Ticket";
            this.reporteToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.reporteToolStripMenuItem.ToolTipText = "Reimpresion ticket en Impresora de Tickets";
            // 
            // btTicketImpresora
            // 
            this.btTicketImpresora.AutoToolTip = true;
            this.btTicketImpresora.Image = global::SACDumont.Properties.Resources.reportes;
            this.btTicketImpresora.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btTicketImpresora.Name = "btTicketImpresora";
            this.btTicketImpresora.Padding = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.btTicketImpresora.Size = new System.Drawing.Size(175, 55);
            this.btTicketImpresora.Text = "Reimpresion Ticket Impresora";
            this.btTicketImpresora.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btTicketImpresora.ToolTipText = "Se reimprime Ticket en Impresora";
            // 
            // dgvCobros
            // 
            this.dgvCobros.AllowUserToAddRows = false;
            this.dgvCobros.AllowUserToDeleteRows = false;
            this.dgvCobros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvCobros.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvCobros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCobros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCobros.Location = new System.Drawing.Point(0, 59);
            this.dgvCobros.Name = "dgvCobros";
            this.dgvCobros.Size = new System.Drawing.Size(531, 226);
            this.dgvCobros.TabIndex = 16;
            // 
            // frmImrpimirCobros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 285);
            this.Controls.Add(this.dgvCobros);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmImrpimirCobros";
            this.Text = "frmImrpimirCobros";
            this.Load += new System.EventHandler(this.frmImrpimirCobros_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCobros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected internal System.Windows.Forms.MenuStrip menuStrip1;
        protected internal System.Windows.Forms.ToolStripMenuItem reporteToolStripMenuItem;
        protected internal System.Windows.Forms.ToolStripMenuItem btTicketImpresora;
        private System.Windows.Forms.DataGridView dgvCobros;
    }
}