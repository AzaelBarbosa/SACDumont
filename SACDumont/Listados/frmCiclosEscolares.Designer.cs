namespace SACDumont.Listados
{
    partial class frmCiclosEscolares
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
            this.dgvCiclos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCiclos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCiclos
            // 
            this.dgvCiclos.AllowUserToAddRows = false;
            this.dgvCiclos.AllowUserToDeleteRows = false;
            this.dgvCiclos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvCiclos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvCiclos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCiclos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCiclos.Location = new System.Drawing.Point(0, 84);
            this.dgvCiclos.Name = "dgvCiclos";
            this.dgvCiclos.ReadOnly = true;
            this.dgvCiclos.Size = new System.Drawing.Size(800, 366);
            this.dgvCiclos.TabIndex = 13;
            this.dgvCiclos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCiclos_CellClick);
            this.dgvCiclos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCiclos_CellDoubleClick);
            // 
            // frmCiclosEscolares
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvCiclos);
            this.Name = "frmCiclosEscolares";
            this.Text = "frmCiclosEscolares";
            this.Load += new System.EventHandler(this.frmCiclosEscolares_Load);
            this.Resize += new System.EventHandler(this.frmCiclosEscolares_Resize);
            this.Controls.SetChildIndex(this.dgvCiclos, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCiclos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvCiclos;
    }
}