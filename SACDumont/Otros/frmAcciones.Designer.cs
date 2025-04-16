namespace SACDumont.Otros
{
    partial class frmAcciones
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
            this.dgvAcciones = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcciones)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAcciones
            // 
            this.dgvAcciones.AllowUserToAddRows = false;
            this.dgvAcciones.AllowUserToDeleteRows = false;
            this.dgvAcciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAcciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAcciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAcciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAcciones.Location = new System.Drawing.Point(0, 59);
            this.dgvAcciones.Name = "dgvAcciones";
            this.dgvAcciones.ReadOnly = true;
            this.dgvAcciones.Size = new System.Drawing.Size(445, 370);
            this.dgvAcciones.TabIndex = 2;
            // 
            // frmAcciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 429);
            this.Controls.Add(this.dgvAcciones);
            this.Name = "frmAcciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAcciones";
            this.Load += new System.EventHandler(this.frmAcciones_Load);
            this.Controls.SetChildIndex(this.dgvAcciones, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAcciones;
    }
}