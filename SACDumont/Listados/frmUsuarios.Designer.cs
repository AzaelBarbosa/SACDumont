namespace SACDumont.Listados
{
    partial class frmUsuarios
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
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.cboFiltros = new System.Windows.Forms.ToolStripComboBox();
            this.txBusqueda = new System.Windows.Forms.ToolStripTextBox();
            this.pbSpinner = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvUsuarios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsuarios.Location = new System.Drawing.Point(0, 84);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.Size = new System.Drawing.Size(800, 366);
            this.dgvUsuarios.TabIndex = 10;
            this.dgvUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellClick);
            this.dgvUsuarios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellDoubleClick);
            // 
            // cboFiltros
            // 
            this.cboFiltros.Name = "cboFiltros";
            this.cboFiltros.Size = new System.Drawing.Size(170, 23);
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
            this.pbSpinner.Location = new System.Drawing.Point(342, 210);
            this.pbSpinner.Name = "pbSpinner";
            this.pbSpinner.Size = new System.Drawing.Size(115, 115);
            this.pbSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSpinner.TabIndex = 11;
            this.pbSpinner.TabStop = false;
            this.pbSpinner.Visible = false;
            // 
            // frmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pbSpinner);
            this.Controls.Add(this.dgvUsuarios);
            this.Name = "frmUsuarios";
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.frmUsuarios_Load);
            this.Controls.SetChildIndex(this.dgvUsuarios, 0);
            this.Controls.SetChildIndex(this.pbSpinner, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpinner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.PictureBox pbSpinner;
        private System.Windows.Forms.ToolStripComboBox cboFiltros;
        private System.Windows.Forms.ToolStripTextBox txBusqueda;
    }
}