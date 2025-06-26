namespace SACDumont.Catalogos
{
    partial class frmCatPromocion
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
            this.txDescripcion = new System.Windows.Forms.TextBox();
            this.txMontoPromo = new System.Windows.Forms.TextBox();
            this.lblApPaterno = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.nPromo = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaNac = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lbIdPromo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nPromo)).BeginInit();
            this.SuspendLayout();
            // 
            // txDescripcion
            // 
            this.txDescripcion.Location = new System.Drawing.Point(12, 100);
            this.txDescripcion.Name = "txDescripcion";
            this.txDescripcion.Size = new System.Drawing.Size(374, 20);
            this.txDescripcion.TabIndex = 70;
            // 
            // txMontoPromo
            // 
            this.txMontoPromo.Location = new System.Drawing.Point(218, 159);
            this.txMontoPromo.Name = "txMontoPromo";
            this.txMontoPromo.Size = new System.Drawing.Size(168, 20);
            this.txMontoPromo.TabIndex = 72;
            // 
            // lblApPaterno
            // 
            this.lblApPaterno.Location = new System.Drawing.Point(218, 139);
            this.lblApPaterno.Name = "lblApPaterno";
            this.lblApPaterno.Size = new System.Drawing.Size(100, 23);
            this.lblApPaterno.TabIndex = 71;
            this.lblApPaterno.Text = "Monto Promocion:";
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(12, 80);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(100, 23);
            this.lblNombre.TabIndex = 69;
            this.lblNombre.Text = "Descripcion:";
            // 
            // nPromo
            // 
            this.nPromo.Location = new System.Drawing.Point(222, 211);
            this.nPromo.Name = "nPromo";
            this.nPromo.Size = new System.Drawing.Size(76, 20);
            this.nPromo.TabIndex = 34;
            this.nPromo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nPromo.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(219, 192);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 27);
            this.label2.TabIndex = 64;
            this.label2.Text = "Porcentaje Promocion";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(12, 159);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaInicio.TabIndex = 76;
            // 
            // lblFechaNac
            // 
            this.lblFechaNac.Location = new System.Drawing.Point(12, 139);
            this.lblFechaNac.Name = "lblFechaNac";
            this.lblFechaNac.Size = new System.Drawing.Size(168, 23);
            this.lblFechaNac.TabIndex = 75;
            this.lblFechaNac.Text = "Fecha Inicio:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(12, 211);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaFin.TabIndex = 78;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 23);
            this.label1.TabIndex = 77;
            this.label1.Text = "Fecha Fin:";
            // 
            // lbIdPromo
            // 
            this.lbIdPromo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbIdPromo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIdPromo.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lbIdPromo.Location = new System.Drawing.Point(286, 239);
            this.lbIdPromo.Name = "lbIdPromo";
            this.lbIdPromo.Size = new System.Drawing.Size(100, 23);
            this.lbIdPromo.TabIndex = 79;
            this.lbIdPromo.Text = "0";
            this.lbIdPromo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmCatPromocion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 271);
            this.Controls.Add(this.lbIdPromo);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.lblFechaNac);
            this.Controls.Add(this.nPromo);
            this.Controls.Add(this.txDescripcion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txMontoPromo);
            this.Controls.Add(this.lblApPaterno);
            this.Controls.Add(this.lblNombre);
            this.Name = "frmCatPromocion";
            this.Text = "frmCatPromocion";
            this.Load += new System.EventHandler(this.frmCatPromocion_Load);
            this.Controls.SetChildIndex(this.lblNombre, 0);
            this.Controls.SetChildIndex(this.lblApPaterno, 0);
            this.Controls.SetChildIndex(this.txMontoPromo, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txDescripcion, 0);
            this.Controls.SetChildIndex(this.nPromo, 0);
            this.Controls.SetChildIndex(this.lblFechaNac, 0);
            this.Controls.SetChildIndex(this.dtpFechaInicio, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dtpFechaFin, 0);
            this.Controls.SetChildIndex(this.lbIdPromo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nPromo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txDescripcion;
        private System.Windows.Forms.TextBox txMontoPromo;
        private System.Windows.Forms.Label lblApPaterno;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.NumericUpDown nPromo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblFechaNac;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbIdPromo;
    }
}