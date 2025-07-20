namespace SACDumont.Catalogos
{
    partial class frmCatProducto
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
            this.lbProductoID = new System.Windows.Forms.Label();
            this.txDescripcion = new System.Windows.Forms.TextBox();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApPaterno = new System.Windows.Forms.Label();
            this.lblApMaterno = new System.Windows.Forms.Label();
            this.dtFechaVenci = new System.Windows.Forms.DateTimePicker();
            this.lblFechaNac = new System.Windows.Forms.Label();
            this.cboGrupo = new SACDumont.Controles.ComboCatalogos();
            this.label1 = new System.Windows.Forms.Label();
            this.cboConcepto = new System.Windows.Forms.ComboBox();
            this.txAbreviatura = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbProductoID
            // 
            this.lbProductoID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbProductoID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProductoID.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lbProductoID.Location = new System.Drawing.Point(343, 248);
            this.lbProductoID.Name = "lbProductoID";
            this.lbProductoID.Size = new System.Drawing.Size(100, 23);
            this.lbProductoID.TabIndex = 34;
            this.lbProductoID.Text = "lbProductoID";
            this.lbProductoID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txDescripcion
            // 
            this.txDescripcion.Location = new System.Drawing.Point(12, 144);
            this.txDescripcion.Name = "txDescripcion";
            this.txDescripcion.Size = new System.Drawing.Size(438, 20);
            this.txDescripcion.TabIndex = 2;
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(12, 194);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(145, 20);
            this.txtCosto.TabIndex = 3;
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(12, 74);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(100, 23);
            this.lblNombre.TabIndex = 56;
            this.lblNombre.Text = "Concepto:";
            // 
            // lblApPaterno
            // 
            this.lblApPaterno.Location = new System.Drawing.Point(12, 124);
            this.lblApPaterno.Name = "lblApPaterno";
            this.lblApPaterno.Size = new System.Drawing.Size(100, 23);
            this.lblApPaterno.TabIndex = 58;
            this.lblApPaterno.Text = "Descripcion:";
            // 
            // lblApMaterno
            // 
            this.lblApMaterno.Location = new System.Drawing.Point(12, 174);
            this.lblApMaterno.Name = "lblApMaterno";
            this.lblApMaterno.Size = new System.Drawing.Size(100, 23);
            this.lblApMaterno.TabIndex = 60;
            this.lblApMaterno.Text = "Costo:";
            // 
            // dtFechaVenci
            // 
            this.dtFechaVenci.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaVenci.Location = new System.Drawing.Point(164, 194);
            this.dtFechaVenci.Name = "dtFechaVenci";
            this.dtFechaVenci.Size = new System.Drawing.Size(144, 20);
            this.dtFechaVenci.TabIndex = 4;
            // 
            // lblFechaNac
            // 
            this.lblFechaNac.Location = new System.Drawing.Point(164, 174);
            this.lblFechaNac.Name = "lblFechaNac";
            this.lblFechaNac.Size = new System.Drawing.Size(168, 23);
            this.lblFechaNac.TabIndex = 69;
            this.lblFechaNac.Text = "Fecha Vencimiento:";
            // 
            // cboGrupo
            // 
            this.cboGrupo.Descripcion = null;
            this.cboGrupo.IDValor = 0;
            this.cboGrupo.Location = new System.Drawing.Point(315, 194);
            this.cboGrupo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboGrupo.Name = "cboGrupo";
            this.cboGrupo.Size = new System.Drawing.Size(134, 21);
            this.cboGrupo.TabIndex = 5;
            this.cboGrupo.TipoCatalogo = "Grupo";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(315, 174);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 27);
            this.label1.TabIndex = 72;
            this.label1.Text = "Grupo:";
            // 
            // cboConcepto
            // 
            this.cboConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConcepto.FormattingEnabled = true;
            this.cboConcepto.Location = new System.Drawing.Point(12, 93);
            this.cboConcepto.Name = "cboConcepto";
            this.cboConcepto.Size = new System.Drawing.Size(205, 21);
            this.cboConcepto.TabIndex = 0;
            // 
            // txAbreviatura
            // 
            this.txAbreviatura.Location = new System.Drawing.Point(223, 94);
            this.txAbreviatura.Name = "txAbreviatura";
            this.txAbreviatura.Size = new System.Drawing.Size(227, 20);
            this.txAbreviatura.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(223, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 74;
            this.label2.Text = "Abreviatura:";
            // 
            // frmCatProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 280);
            this.Controls.Add(this.txAbreviatura);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboConcepto);
            this.Controls.Add(this.cboGrupo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtFechaVenci);
            this.Controls.Add(this.lblFechaNac);
            this.Controls.Add(this.txDescripcion);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblApPaterno);
            this.Controls.Add(this.lblApMaterno);
            this.Controls.Add(this.lbProductoID);
            this.Name = "frmCatProducto";
            this.Text = "frmCatProducto";
            this.Load += new System.EventHandler(this.frmCatProducto_Load);
            this.Controls.SetChildIndex(this.lbProductoID, 0);
            this.Controls.SetChildIndex(this.lblApMaterno, 0);
            this.Controls.SetChildIndex(this.lblApPaterno, 0);
            this.Controls.SetChildIndex(this.lblNombre, 0);
            this.Controls.SetChildIndex(this.txtCosto, 0);
            this.Controls.SetChildIndex(this.txDescripcion, 0);
            this.Controls.SetChildIndex(this.lblFechaNac, 0);
            this.Controls.SetChildIndex(this.dtFechaVenci, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cboGrupo, 0);
            this.Controls.SetChildIndex(this.cboConcepto, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txAbreviatura, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbProductoID;
        private System.Windows.Forms.TextBox txDescripcion;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApPaterno;
        private System.Windows.Forms.Label lblApMaterno;
        private System.Windows.Forms.DateTimePicker dtFechaVenci;
        private System.Windows.Forms.Label lblFechaNac;
        private Controles.ComboCatalogos cboGrupo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboConcepto;
        private System.Windows.Forms.TextBox txAbreviatura;
        private System.Windows.Forms.Label label2;
    }
}