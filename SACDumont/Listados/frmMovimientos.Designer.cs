namespace SACDumont.Listados
{
    partial class frmMovimientos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMovimientos));
            this.dgvMovimientos = new System.Windows.Forms.DataGridView();
            this.tsSearch = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cboFiltros = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.txBusqueda = new System.Windows.Forms.ToolStripTextBox();
            this.txBtnSearch = new System.Windows.Forms.ToolStripButton();
            this.pbSpinner = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).BeginInit();
            this.tsSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMovimientos
            // 
            this.dgvMovimientos.AllowUserToAddRows = false;
            this.dgvMovimientos.AllowUserToDeleteRows = false;
            this.dgvMovimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvMovimientos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovimientos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMovimientos.Location = new System.Drawing.Point(0, 84);
            this.dgvMovimientos.Name = "dgvMovimientos";
            this.dgvMovimientos.ReadOnly = true;
            this.dgvMovimientos.Size = new System.Drawing.Size(800, 366);
            this.dgvMovimientos.TabIndex = 5;
            this.dgvMovimientos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMovimientos_CellClick);
            this.dgvMovimientos.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMovimientos_CellContentDoubleClick);
            this.dgvMovimientos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMovimientos_CellDoubleClick);
            this.dgvMovimientos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvMovimientos_CellFormatting);
            this.dgvMovimientos.Resize += new System.EventHandler(this.dgvMovimientos_Resize);
            // 
            // tsSearch
            // 
            this.tsSearch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cboFiltros,
            this.toolStripSeparator1,
            this.txBusqueda,
            this.txBtnSearch});
            this.tsSearch.Location = new System.Drawing.Point(0, 59);
            this.tsSearch.Name = "tsSearch";
            this.tsSearch.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tsSearch.Size = new System.Drawing.Size(800, 25);
            this.tsSearch.TabIndex = 8;
            this.tsSearch.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(62, 22);
            this.toolStripLabel1.Text = "Busqueda:";
            // 
            // cboFiltros
            // 
            this.cboFiltros.Name = "cboFiltros";
            this.cboFiltros.Size = new System.Drawing.Size(170, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // txBusqueda
            // 
            this.txBusqueda.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txBusqueda.Name = "txBusqueda";
            this.txBusqueda.Size = new System.Drawing.Size(400, 25);
            // 
            // txBtnSearch
            // 
            this.txBtnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.txBtnSearch.Image = ((System.Drawing.Image)(resources.GetObject("txBtnSearch.Image")));
            this.txBtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.txBtnSearch.Name = "txBtnSearch";
            this.txBtnSearch.Size = new System.Drawing.Size(23, 22);
            this.txBtnSearch.Text = "toolStripButton1";
            // 
            // pbSpinner
            // 
            this.pbSpinner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSpinner.BackColor = System.Drawing.Color.Transparent;
            this.pbSpinner.Image = global::SACDumont.Properties.Resources.spinner;
            this.pbSpinner.Location = new System.Drawing.Point(351, 201);
            this.pbSpinner.Name = "pbSpinner";
            this.pbSpinner.Size = new System.Drawing.Size(115, 115);
            this.pbSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSpinner.TabIndex = 12;
            this.pbSpinner.TabStop = false;
            this.pbSpinner.Visible = false;
            // 
            // frmMovimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvMovimientos);
            this.Controls.Add(this.pbSpinner);
            this.Controls.Add(this.tsSearch);
            this.Name = "frmMovimientos";
            this.Text = "frmMovimientos";
            this.Load += new System.EventHandler(this.frmMovimientos_Load);
            this.Controls.SetChildIndex(this.tsSearch, 0);
            this.Controls.SetChildIndex(this.pbSpinner, 0);
            this.Controls.SetChildIndex(this.dgvMovimientos, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).EndInit();
            this.tsSearch.ResumeLayout(false);
            this.tsSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpinner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMovimientos;
        private System.Windows.Forms.ToolStrip tsSearch;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cboFiltros;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox txBusqueda;
        private System.Windows.Forms.ToolStripButton txBtnSearch;
        private System.Windows.Forms.PictureBox pbSpinner;
    }
}