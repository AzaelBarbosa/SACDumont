namespace SACDumont.Otros
{
    partial class frmAsignarTutor
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
            this.cboTutores = new SACDumont.Controles.ComboTutores();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboParentesco = new SACDumont.Controles.ComboCatalogos();
            this.SuspendLayout();
            // 
            // cboTutores
            // 
            this.cboTutores.IDTutor = 0;
            this.cboTutores.Location = new System.Drawing.Point(12, 98);
            this.cboTutores.Name = "cboTutores";
            this.cboTutores.Size = new System.Drawing.Size(544, 23);
            this.cboTutores.SqlQuery = null;
            this.cboTutores.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 77;
            this.label3.Text = "Parentesco:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 79;
            this.label1.Text = "Tutor:";
            // 
            // cboParentesco
            // 
            this.cboParentesco.Descripcion = null;
            this.cboParentesco.IDValor = 0;
            this.cboParentesco.Location = new System.Drawing.Point(12, 158);
            this.cboParentesco.Name = "cboParentesco";
            this.cboParentesco.Size = new System.Drawing.Size(216, 21);
            this.cboParentesco.TabIndex = 80;
            this.cboParentesco.TipoCatalogo = "Parentesco";
            // 
            // frmAsignarTutor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 191);
            this.Controls.Add(this.cboParentesco);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboTutores);
            this.Controls.Add(this.label1);
            this.Name = "frmAsignarTutor";
            this.Text = "frmAsignarTutor";
            this.Load += new System.EventHandler(this.frmAsignarTutor_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cboTutores, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cboParentesco, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.ComboTutores cboTutores;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private Controles.ComboCatalogos cboParentesco;
    }
}