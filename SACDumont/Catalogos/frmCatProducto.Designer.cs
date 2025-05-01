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
            this.txConcepto = new System.Windows.Forms.TextBox();
            this.txDescripcion = new System.Windows.Forms.TextBox();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApPaterno = new System.Windows.Forms.Label();
            this.lblApMaterno = new System.Windows.Forms.Label();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.dtFechaVenci = new System.Windows.Forms.DateTimePicker();
            this.lblFechaNac = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbProductoID
            // 
            this.lbProductoID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbProductoID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProductoID.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lbProductoID.Location = new System.Drawing.Point(382, 235);
            this.lbProductoID.Name = "lbProductoID";
            this.lbProductoID.Size = new System.Drawing.Size(100, 23);
            this.lbProductoID.TabIndex = 34;
            this.lbProductoID.Text = "lbProductoID";
            this.lbProductoID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txConcepto
            // 
            this.txConcepto.Location = new System.Drawing.Point(12, 94);
            this.txConcepto.Name = "txConcepto";
            this.txConcepto.Size = new System.Drawing.Size(361, 20);
            this.txConcepto.TabIndex = 57;
            // 
            // txDescripcion
            // 
            this.txDescripcion.Location = new System.Drawing.Point(12, 144);
            this.txDescripcion.Name = "txDescripcion";
            this.txDescripcion.Size = new System.Drawing.Size(361, 20);
            this.txDescripcion.TabIndex = 59;
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(12, 194);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(145, 20);
            this.txtCosto.TabIndex = 61;
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
            // chkActivo
            // 
            this.chkActivo.Checked = true;
            this.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivo.Location = new System.Drawing.Point(12, 231);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(100, 24);
            this.chkActivo.TabIndex = 68;
            this.chkActivo.Text = "Activo";
            // 
            // dtFechaVenci
            // 
            this.dtFechaVenci.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaVenci.Location = new System.Drawing.Point(188, 194);
            this.dtFechaVenci.Name = "dtFechaVenci";
            this.dtFechaVenci.Size = new System.Drawing.Size(185, 20);
            this.dtFechaVenci.TabIndex = 70;
            // 
            // lblFechaNac
            // 
            this.lblFechaNac.Location = new System.Drawing.Point(188, 174);
            this.lblFechaNac.Name = "lblFechaNac";
            this.lblFechaNac.Size = new System.Drawing.Size(168, 23);
            this.lblFechaNac.TabIndex = 69;
            this.lblFechaNac.Text = "Fecha Vencimiento:";
            // 
            // frmCatProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 267);
            this.Controls.Add(this.dtFechaVenci);
            this.Controls.Add(this.lblFechaNac);
            this.Controls.Add(this.chkActivo);
            this.Controls.Add(this.txConcepto);
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
            this.Controls.SetChildIndex(this.txConcepto, 0);
            this.Controls.SetChildIndex(this.chkActivo, 0);
            this.Controls.SetChildIndex(this.lblFechaNac, 0);
            this.Controls.SetChildIndex(this.dtFechaVenci, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbProductoID;
        private System.Windows.Forms.TextBox txConcepto;
        private System.Windows.Forms.TextBox txDescripcion;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApPaterno;
        private System.Windows.Forms.Label lblApMaterno;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.DateTimePicker dtFechaVenci;
        private System.Windows.Forms.Label lblFechaNac;
    }
}