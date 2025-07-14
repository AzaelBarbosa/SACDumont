namespace SACDumont.Listados
{
    partial class frmTutores
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
            this.dgvTutores = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTutores)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTutores
            // 
            this.dgvTutores.AllowUserToAddRows = false;
            this.dgvTutores.AllowUserToDeleteRows = false;
            this.dgvTutores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTutores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTutores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTutores.Location = new System.Drawing.Point(0, 84);
            this.dgvTutores.Name = "dgvTutores";
            this.dgvTutores.ReadOnly = true;
            this.dgvTutores.Size = new System.Drawing.Size(862, 517);
            this.dgvTutores.TabIndex = 2;
            this.dgvTutores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTutores_CellClick);
            this.dgvTutores.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTutores_CellDoubleClick);
            // 
            // frmTutores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 601);
            this.Controls.Add(this.dgvTutores);
            this.Name = "frmTutores";
            this.Text = "frmTutores";
            this.Activated += new System.EventHandler(this.frmTutores_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTutores_FormClosed);
            this.Load += new System.EventHandler(this.frmTutores_Load);
            this.Controls.SetChildIndex(this.dgvTutores, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTutores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTutores;
    }
}