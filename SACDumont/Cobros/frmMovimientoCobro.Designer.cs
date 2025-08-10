namespace SACDumont.Cobros
{
    partial class frmMovimientoCobro
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
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txCosto = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.cboCatalogos = new SACDumont.Controles.ComboCatalogos();
            this.label10 = new System.Windows.Forms.Label();
            this.txRealizado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTotal
            // 
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(13, 95);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(148, 22);
            this.txtTotal.TabIndex = 54;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 27);
            this.label1.TabIndex = 55;
            this.label1.Text = "Importe Pendiente:";
            // 
            // txCosto
            // 
            this.txCosto.Location = new System.Drawing.Point(13, 152);
            this.txCosto.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txCosto.Name = "txCosto";
            this.txCosto.Size = new System.Drawing.Size(165, 20);
            this.txCosto.TabIndex = 0;
            this.txCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txCosto.TextChanged += new System.EventHandler(this.txCosto_TextChanged);
            this.txCosto.Leave += new System.EventHandler(this.txCosto_Leave);
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(13, 129);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(80, 27);
            this.lblNombre.TabIndex = 50;
            this.lblNombre.Text = "Importe:";
            // 
            // cboCatalogos
            // 
            this.cboCatalogos.Descripcion = null;
            this.cboCatalogos.IDValor = 0;
            this.cboCatalogos.Location = new System.Drawing.Point(189, 151);
            this.cboCatalogos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboCatalogos.Name = "cboCatalogos";
            this.cboCatalogos.Size = new System.Drawing.Size(144, 21);
            this.cboCatalogos.TabIndex = 1;
            this.cboCatalogos.TipoCatalogo = "TipoPago";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(186, 129);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 27);
            this.label10.TabIndex = 57;
            this.label10.Text = "Tipo Pago:";
            // 
            // txRealizado
            // 
            this.txRealizado.Location = new System.Drawing.Point(10, 200);
            this.txRealizado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txRealizado.Name = "txRealizado";
            this.txRealizado.Size = new System.Drawing.Size(323, 20);
            this.txRealizado.TabIndex = 2;
            this.txRealizado.Leave += new System.EventHandler(this.txRealizado_Leave);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 182);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 27);
            this.label2.TabIndex = 59;
            this.label2.Text = "Relizado Por:";
            // 
            // frmMovimientoCobro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 232);
            this.Controls.Add(this.txRealizado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboCatalogos);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txCosto);
            this.Controls.Add(this.lblNombre);
            this.Name = "frmMovimientoCobro";
            this.Text = "frmMovimientoCobro";
            this.Load += new System.EventHandler(this.frmMovimientoCobro_Load);
            this.Controls.SetChildIndex(this.lblNombre, 0);
            this.Controls.SetChildIndex(this.txCosto, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtTotal, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.cboCatalogos, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txRealizado, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txCosto;
        private System.Windows.Forms.Label lblNombre;
        private Controles.ComboCatalogos cboCatalogos;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txRealizado;
        private System.Windows.Forms.Label label2;
    }
}