namespace SACDumont.Otros
{
    partial class frmPopup
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
            this.cboGrupo = new SACDumont.Controles.ComboCatalogos();
            this.label1 = new System.Windows.Forms.Label();
            this.cboGrado = new SACDumont.Controles.ComboCatalogos();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboGrupo
            // 
            this.cboGrupo.Descripcion = null;
            this.cboGrupo.IDValor = 0;
            this.cboGrupo.Location = new System.Drawing.Point(16, 67);
            this.cboGrupo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboGrupo.Name = "cboGrupo";
            this.cboGrupo.Size = new System.Drawing.Size(144, 21);
            this.cboGrupo.TabIndex = 66;
            this.cboGrupo.TipoCatalogo = "Grupo";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 27);
            this.label1.TabIndex = 67;
            this.label1.Text = "Grupo:";
            // 
            // cboGrado
            // 
            this.cboGrado.Descripcion = null;
            this.cboGrado.IDValor = 0;
            this.cboGrado.Location = new System.Drawing.Point(182, 67);
            this.cboGrado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboGrado.Name = "cboGrado";
            this.cboGrado.Size = new System.Drawing.Size(144, 21);
            this.cboGrado.TabIndex = 64;
            this.cboGrado.TipoCatalogo = "Grado";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(179, 45);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 27);
            this.label10.TabIndex = 65;
            this.label10.Text = "Grado:";
            // 
            // frmPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 102);
            this.Controls.Add(this.cboGrupo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboGrado);
            this.Controls.Add(this.label10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmPopup";
            this.Text = "frmPopup";
            this.Load += new System.EventHandler(this.frmPopup_Load);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.cboGrado, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cboGrupo, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.ComboCatalogos cboGrupo;
        private System.Windows.Forms.Label label1;
        private Controles.ComboCatalogos cboGrado;
        private System.Windows.Forms.Label label10;
    }
}