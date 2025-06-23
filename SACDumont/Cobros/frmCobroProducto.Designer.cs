namespace SACDumont.Cobros
{
    partial class frmCobroProducto
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
            this.comboProductos1 = new SACDumont.Controles.ComboProductos();
            this.lbSeleccion = new System.Windows.Forms.Label();
            this.txCosto = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txFechaVencimiento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txRecargo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nCantidad = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.lbAtencion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // comboProductos1
            // 
            this.comboProductos1.Descripcion = null;
            this.comboProductos1.FechaVencimiento = null;
            this.comboProductos1.idGrado = null;
            this.comboProductos1.IdProductoSeleccionado = null;
            this.comboProductos1.Location = new System.Drawing.Point(138, 102);
            this.comboProductos1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboProductos1.Name = "comboProductos1";
            this.comboProductos1.Precio = null;
            this.comboProductos1.Size = new System.Drawing.Size(371, 21);
            this.comboProductos1.SqlQuery = null;
            this.comboProductos1.TabIndex = 38;
            this.comboProductos1.OnCobroSeleccionado += new System.Action<System.Data.DataRow>(this.comboProductos1_OnCobroSeleccionado);
            // 
            // lbSeleccion
            // 
            this.lbSeleccion.Location = new System.Drawing.Point(13, 104);
            this.lbSeleccion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSeleccion.Name = "lbSeleccion";
            this.lbSeleccion.Size = new System.Drawing.Size(126, 21);
            this.lbSeleccion.TabIndex = 39;
            this.lbSeleccion.Text = "Selecciona Producto";
            // 
            // txCosto
            // 
            this.txCosto.Location = new System.Drawing.Point(102, 155);
            this.txCosto.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txCosto.Name = "txCosto";
            this.txCosto.ReadOnly = true;
            this.txCosto.Size = new System.Drawing.Size(80, 20);
            this.txCosto.TabIndex = 40;
            this.txCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(102, 132);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(80, 27);
            this.lblNombre.TabIndex = 42;
            this.lblNombre.Text = "Importe:";
            // 
            // txFechaVencimiento
            // 
            this.txFechaVencimiento.Location = new System.Drawing.Point(190, 155);
            this.txFechaVencimiento.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txFechaVencimiento.Name = "txFechaVencimiento";
            this.txFechaVencimiento.ReadOnly = true;
            this.txFechaVencimiento.Size = new System.Drawing.Size(141, 20);
            this.txFechaVencimiento.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(190, 132);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 27);
            this.label2.TabIndex = 43;
            this.label2.Text = "Fecha Vencimiento:";
            // 
            // txRecargo
            // 
            this.txRecargo.Location = new System.Drawing.Point(339, 155);
            this.txRecargo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txRecargo.Name = "txRecargo";
            this.txRecargo.ReadOnly = true;
            this.txRecargo.Size = new System.Drawing.Size(80, 20);
            this.txRecargo.TabIndex = 44;
            this.txRecargo.Text = "0";
            this.txRecargo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(339, 132);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 27);
            this.label3.TabIndex = 45;
            this.label3.Text = "Recargo:";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(427, 155);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(80, 20);
            this.txtTotal.TabIndex = 46;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(427, 132);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 27);
            this.label1.TabIndex = 47;
            this.label1.Text = "Total:";
            // 
            // nCantidad
            // 
            this.nCantidad.Enabled = false;
            this.nCantidad.Location = new System.Drawing.Point(34, 156);
            this.nCantidad.Name = "nCantidad";
            this.nCantidad.Size = new System.Drawing.Size(61, 20);
            this.nCantidad.TabIndex = 48;
            this.nCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nCantidad.ValueChanged += new System.EventHandler(this.nCantidad_ValueChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(31, 133);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 27);
            this.label4.TabIndex = 49;
            this.label4.Text = "Cantidad:";
            // 
            // lbAtencion
            // 
            this.lbAtencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAtencion.ForeColor = System.Drawing.Color.Red;
            this.lbAtencion.Location = new System.Drawing.Point(31, 64);
            this.lbAtencion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAtencion.Name = "lbAtencion";
            this.lbAtencion.Size = new System.Drawing.Size(478, 32);
            this.lbAtencion.TabIndex = 50;
            this.lbAtencion.Text = "El producto seleccionado está próximo ya ha vencido.\r\nSe cobraran Recargos.";
            this.lbAtencion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbAtencion.Visible = false;
            // 
            // frmCobroProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 188);
            this.Controls.Add(this.lbAtencion);
            this.Controls.Add(this.nCantidad);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txRecargo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txCosto);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txFechaVencimiento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboProductos1);
            this.Controls.Add(this.lbSeleccion);
            this.Name = "frmCobroProducto";
            this.Text = "frmCobroProducto";
            this.Load += new System.EventHandler(this.frmCobroProducto_Load);
            this.Controls.SetChildIndex(this.lbSeleccion, 0);
            this.Controls.SetChildIndex(this.comboProductos1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txFechaVencimiento, 0);
            this.Controls.SetChildIndex(this.lblNombre, 0);
            this.Controls.SetChildIndex(this.txCosto, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txRecargo, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtTotal, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.nCantidad, 0);
            this.Controls.SetChildIndex(this.lbAtencion, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.ComboProductos comboProductos1;
        private System.Windows.Forms.Label lbSeleccion;
        private System.Windows.Forms.TextBox txCosto;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txFechaVencimiento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txRecargo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nCantidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbAtencion;
    }
}