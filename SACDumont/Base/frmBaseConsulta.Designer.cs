namespace SACDumont.Base
{
    partial class frmBaseConsulta
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
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btTicketImpresora = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSearch = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.pbSpinner = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.tsSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eliminarToolStripMenuItem,
            this.reporteToolStripMenuItem,
            this.btTicketImpresora,
            this.cerrarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(960, 59);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::SACDumont.Properties.Resources.eliminar;
            this.eliminarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(62, 55);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
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
            this.reporteToolStripMenuItem.Click += new System.EventHandler(this.reporteToolStripMenuItem_Click);
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
            this.btTicketImpresora.Click += new System.EventHandler(this.btTicketImpresora_Click);
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Image = global::SACDumont.Properties.Resources.eliminar;
            this.cerrarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(51, 55);
            this.cerrarToolStripMenuItem.Text = "Cerrar";
            this.cerrarToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.cerrarToolStripMenuItem_Click);
            // 
            // tsSearch
            // 
            this.tsSearch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator1});
            this.tsSearch.Location = new System.Drawing.Point(0, 59);
            this.tsSearch.Name = "tsSearch";
            this.tsSearch.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tsSearch.Size = new System.Drawing.Size(960, 25);
            this.tsSearch.TabIndex = 10;
            this.tsSearch.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(53, 22);
            this.toolStripLabel1.Text = "Alumno:";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // pbSpinner
            // 
            this.pbSpinner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSpinner.BackColor = System.Drawing.Color.Transparent;
            this.pbSpinner.Image = global::SACDumont.Properties.Resources.spinner;
            this.pbSpinner.Location = new System.Drawing.Point(423, 210);
            this.pbSpinner.Name = "pbSpinner";
            this.pbSpinner.Size = new System.Drawing.Size(115, 115);
            this.pbSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSpinner.TabIndex = 14;
            this.pbSpinner.TabStop = false;
            this.pbSpinner.Visible = false;
            // 
            // frmBaseConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 534);
            this.Controls.Add(this.pbSpinner);
            this.Controls.Add(this.tsSearch);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmBaseConsulta";
            this.Text = "frmBaseConsulta";
            this.Load += new System.EventHandler(this.frmBaseConsulta_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tsSearch.ResumeLayout(false);
            this.tsSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpinner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected internal System.Windows.Forms.MenuStrip menuStrip1;
        protected internal System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        protected internal System.Windows.Forms.ToolStripMenuItem reporteToolStripMenuItem;
        protected internal System.Windows.Forms.ToolStripMenuItem btTicketImpresora;
        protected internal System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        public System.Windows.Forms.ToolStrip tsSearch;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.PictureBox pbSpinner;
    }
}