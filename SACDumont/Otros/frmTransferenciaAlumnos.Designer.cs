namespace SACDumont.Otros
{
    partial class frmTransferenciaAlumnos
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
            this.dgvAlumn = new System.Windows.Forms.DataGridView();
            this.tsSearch = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.txBusqueda = new System.Windows.Forms.ToolStripTextBox();
            this.pbSpinner = new System.Windows.Forms.PictureBox();
            this.lbAgregados = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumn)).BeginInit();
            this.tsSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAlumn
            // 
            this.dgvAlumn.AllowUserToAddRows = false;
            this.dgvAlumn.AllowUserToDeleteRows = false;
            this.dgvAlumn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlumn.Location = new System.Drawing.Point(12, 76);
            this.dgvAlumn.Name = "dgvAlumn";
            this.dgvAlumn.Size = new System.Drawing.Size(832, 365);
            this.dgvAlumn.TabIndex = 2;
            // 
            // tsSearch
            // 
            this.tsSearch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.txBusqueda});
            this.tsSearch.Location = new System.Drawing.Point(0, 39);
            this.tsSearch.Name = "tsSearch";
            this.tsSearch.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tsSearch.Size = new System.Drawing.Size(856, 25);
            this.tsSearch.TabIndex = 10;
            this.tsSearch.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(54, 22);
            this.toolStripLabel1.Text = "Nombre:";
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
            this.txBusqueda.TextChanged += new System.EventHandler(this.txBusqueda_TextChanged);
            // 
            // pbSpinner
            // 
            this.pbSpinner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSpinner.BackColor = System.Drawing.Color.Transparent;
            this.pbSpinner.Image = global::SACDumont.Properties.Resources.spinner;
            this.pbSpinner.Location = new System.Drawing.Point(377, 208);
            this.pbSpinner.Name = "pbSpinner";
            this.pbSpinner.Size = new System.Drawing.Size(115, 116);
            this.pbSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSpinner.TabIndex = 15;
            this.pbSpinner.TabStop = false;
            this.pbSpinner.Visible = false;
            // 
            // lbAgregados
            // 
            this.lbAgregados.FormattingEnabled = true;
            this.lbAgregados.Location = new System.Drawing.Point(527, 76);
            this.lbAgregados.Name = "lbAgregados";
            this.lbAgregados.Size = new System.Drawing.Size(317, 368);
            this.lbAgregados.TabIndex = 16;
            // 
            // frmTransferenciaAlumnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 456);
            this.Controls.Add(this.pbSpinner);
            this.Controls.Add(this.dgvAlumn);
            this.Controls.Add(this.tsSearch);
            this.Controls.Add(this.lbAgregados);
            this.Name = "frmTransferenciaAlumnos";
            this.Text = "frmTransferenciaAlumnos";
            this.Load += new System.EventHandler(this.frmTransferenciaAlumnos_Load);
            this.Resize += new System.EventHandler(this.frmTransferenciaAlumnos_Resize);
            this.Controls.SetChildIndex(this.lbAgregados, 0);
            this.Controls.SetChildIndex(this.tsSearch, 0);
            this.Controls.SetChildIndex(this.dgvAlumn, 0);
            this.Controls.SetChildIndex(this.pbSpinner, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumn)).EndInit();
            this.tsSearch.ResumeLayout(false);
            this.tsSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpinner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAlumn;
        public System.Windows.Forms.ToolStrip tsSearch;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripTextBox txBusqueda;
        public System.Windows.Forms.PictureBox pbSpinner;
        private System.Windows.Forms.ListBox lbAgregados;
    }
}