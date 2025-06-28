namespace SACDumont.Catalogos
{
    partial class frmCatUsuarios
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
            this.txNombreUsuario = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txCorreo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboPerfiles = new System.Windows.Forms.ComboBox();
            this.lbIdPromo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txNombreUsuario
            // 
            this.txNombreUsuario.Location = new System.Drawing.Point(12, 102);
            this.txNombreUsuario.Name = "txNombreUsuario";
            this.txNombreUsuario.Size = new System.Drawing.Size(443, 20);
            this.txNombreUsuario.TabIndex = 72;
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(12, 82);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(131, 23);
            this.lblNombre.TabIndex = 71;
            this.lblNombre.Text = "Nombre de Usuario:";
            // 
            // txUsuario
            // 
            this.txUsuario.Location = new System.Drawing.Point(12, 158);
            this.txUsuario.Name = "txUsuario";
            this.txUsuario.Size = new System.Drawing.Size(244, 20);
            this.txUsuario.TabIndex = 74;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 73;
            this.label1.Text = "Usuario:";
            // 
            // txCorreo
            // 
            this.txCorreo.Location = new System.Drawing.Point(12, 213);
            this.txCorreo.Name = "txCorreo";
            this.txCorreo.Size = new System.Drawing.Size(443, 20);
            this.txCorreo.TabIndex = 76;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 75;
            this.label2.Text = "Correo:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(262, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 77;
            this.label3.Text = "Perfil:";
            // 
            // cboPerfiles
            // 
            this.cboPerfiles.FormattingEnabled = true;
            this.cboPerfiles.Location = new System.Drawing.Point(262, 158);
            this.cboPerfiles.Name = "cboPerfiles";
            this.cboPerfiles.Size = new System.Drawing.Size(193, 21);
            this.cboPerfiles.TabIndex = 78;
            // 
            // lbIdPromo
            // 
            this.lbIdPromo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbIdPromo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIdPromo.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lbIdPromo.Location = new System.Drawing.Point(440, 265);
            this.lbIdPromo.Name = "lbIdPromo";
            this.lbIdPromo.Size = new System.Drawing.Size(100, 23);
            this.lbIdPromo.TabIndex = 80;
            this.lbIdPromo.Text = "0";
            this.lbIdPromo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmCatUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 297);
            this.Controls.Add(this.lbIdPromo);
            this.Controls.Add(this.cboPerfiles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txCorreo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txNombreUsuario);
            this.Controls.Add(this.lblNombre);
            this.Name = "frmCatUsuarios";
            this.Text = "frmCatUsuarios";
            this.Load += new System.EventHandler(this.frmCatUsuarios_Load);
            this.Controls.SetChildIndex(this.lblNombre, 0);
            this.Controls.SetChildIndex(this.txNombreUsuario, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txUsuario, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txCorreo, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cboPerfiles, 0);
            this.Controls.SetChildIndex(this.lbIdPromo, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txNombreUsuario;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txCorreo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboPerfiles;
        private System.Windows.Forms.Label lbIdPromo;
    }
}