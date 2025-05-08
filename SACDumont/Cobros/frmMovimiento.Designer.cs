namespace SACDumont.Cobros
{
    partial class frmMovimiento
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
            this.txCosto = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lbSeleccion = new System.Windows.Forms.Label();
            this.comboProductos1 = new SACDumont.Controles.ComboProductos();
            this.label1 = new System.Windows.Forms.Label();
            this.txFechaVencimiento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboCatalogos = new SACDumont.Controles.ComboCatalogos();
            this.txTotal = new System.Windows.Forms.TextBox();
            this.txImportePte = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txBeca = new System.Windows.Forms.TextBox();
            this.txImporte = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nPorcDescuento = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.txRecargo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txDescuento = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.lbIDMovimiento = new System.Windows.Forms.Label();
            this.cboAlumnos = new SACDumont.Controles.ComboAlumnos();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nPorcDescuento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // txCosto
            // 
            this.txCosto.Location = new System.Drawing.Point(7, 40);
            this.txCosto.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txCosto.Name = "txCosto";
            this.txCosto.ReadOnly = true;
            this.txCosto.Size = new System.Drawing.Size(80, 21);
            this.txCosto.TabIndex = 0;
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(7, 17);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(80, 27);
            this.lblNombre.TabIndex = 22;
            this.lblNombre.Text = "Costo:";
            // 
            // lbSeleccion
            // 
            this.lbSeleccion.Location = new System.Drawing.Point(13, 121);
            this.lbSeleccion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSeleccion.Name = "lbSeleccion";
            this.lbSeleccion.Size = new System.Drawing.Size(126, 21);
            this.lbSeleccion.TabIndex = 37;
            this.lbSeleccion.Text = "Selecciona Producto";
            // 
            // comboProductos1
            // 
            this.comboProductos1.Descripcion = null;
            this.comboProductos1.FechaVencimiento = null;
            this.comboProductos1.idGrado = null;
            this.comboProductos1.IdProductoSeleccionado = null;
            this.comboProductos1.Location = new System.Drawing.Point(138, 119);
            this.comboProductos1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboProductos1.Name = "comboProductos1";
            this.comboProductos1.Precio = null;
            this.comboProductos1.Size = new System.Drawing.Size(398, 21);
            this.comboProductos1.SqlQuery = null;
            this.comboProductos1.TabIndex = 2;
            this.comboProductos1.OnCobroSeleccionado += new System.Action<System.Data.DataRow>(this.comboProductos1_OnCobroSeleccionado_1);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 80);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Alumno:";
            // 
            // txFechaVencimiento
            // 
            this.txFechaVencimiento.Location = new System.Drawing.Point(95, 40);
            this.txFechaVencimiento.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txFechaVencimiento.Name = "txFechaVencimiento";
            this.txFechaVencimiento.ReadOnly = true;
            this.txFechaVencimiento.Size = new System.Drawing.Size(141, 21);
            this.txFechaVencimiento.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(95, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 27);
            this.label2.TabIndex = 24;
            this.label2.Text = "Fecha Vencimiento:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboCatalogos);
            this.groupBox2.Controls.Add(this.txTotal);
            this.groupBox2.Controls.Add(this.txImportePte);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txBeca);
            this.groupBox2.Controls.Add(this.txImporte);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.nPorcDescuento);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txRecargo);
            this.groupBox2.Controls.Add(this.txCosto);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txDescuento);
            this.groupBox2.Controls.Add(this.lblNombre);
            this.groupBox2.Controls.Add(this.txFechaVencimiento);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(16, 317);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(520, 136);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            // 
            // cboCatalogos
            // 
            this.cboCatalogos.Enabled = false;
            this.cboCatalogos.IDValor = null;
            this.cboCatalogos.Location = new System.Drawing.Point(244, 40);
            this.cboCatalogos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboCatalogos.Name = "cboCatalogos";
            this.cboCatalogos.Size = new System.Drawing.Size(144, 21);
            this.cboCatalogos.TabIndex = 31;
            this.cboCatalogos.TipoCatalogo = "TipoPago";
            // 
            // txTotal
            // 
            this.txTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txTotal.Location = new System.Drawing.Point(420, 100);
            this.txTotal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txTotal.Name = "txTotal";
            this.txTotal.ReadOnly = true;
            this.txTotal.Size = new System.Drawing.Size(80, 21);
            this.txTotal.TabIndex = 5;
            this.txTotal.Text = "0";
            // 
            // txImportePte
            // 
            this.txImportePte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txImportePte.ForeColor = System.Drawing.Color.Red;
            this.txImportePte.Location = new System.Drawing.Point(399, 40);
            this.txImportePte.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txImportePte.Name = "txImportePte";
            this.txImportePte.ReadOnly = true;
            this.txImportePte.Size = new System.Drawing.Size(101, 21);
            this.txImportePte.TabIndex = 6;
            this.txImportePte.Text = "0";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(417, 77);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 27);
            this.label5.TabIndex = 26;
            this.label5.Text = "Total:";
            // 
            // txBeca
            // 
            this.txBeca.Location = new System.Drawing.Point(244, 100);
            this.txBeca.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txBeca.Name = "txBeca";
            this.txBeca.ReadOnly = true;
            this.txBeca.Size = new System.Drawing.Size(80, 21);
            this.txBeca.TabIndex = 29;
            this.txBeca.Text = "0";
            // 
            // txImporte
            // 
            this.txImporte.Enabled = false;
            this.txImporte.Location = new System.Drawing.Point(7, 101);
            this.txImporte.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txImporte.Name = "txImporte";
            this.txImporte.Size = new System.Drawing.Size(80, 21);
            this.txImporte.TabIndex = 4;
            this.txImporte.Text = "0";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(396, 17);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 27);
            this.label6.TabIndex = 28;
            this.label6.Text = "Importe Pendiente:";
            // 
            // nPorcDescuento
            // 
            this.nPorcDescuento.Location = new System.Drawing.Point(94, 101);
            this.nPorcDescuento.Name = "nPorcDescuento";
            this.nPorcDescuento.ReadOnly = true;
            this.nPorcDescuento.Size = new System.Drawing.Size(55, 21);
            this.nPorcDescuento.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(241, 77);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 27);
            this.label8.TabIndex = 30;
            this.label8.Text = "Beca:";
            // 
            // txRecargo
            // 
            this.txRecargo.Location = new System.Drawing.Point(332, 100);
            this.txRecargo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txRecargo.Name = "txRecargo";
            this.txRecargo.ReadOnly = true;
            this.txRecargo.Size = new System.Drawing.Size(80, 21);
            this.txRecargo.TabIndex = 2;
            this.txRecargo.Text = "0";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(332, 77);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 27);
            this.label3.TabIndex = 24;
            this.label3.Text = "Recargo:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(7, 78);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 27);
            this.label4.TabIndex = 22;
            this.label4.Text = "Importe:";
            // 
            // txDescuento
            // 
            this.txDescuento.Location = new System.Drawing.Point(156, 100);
            this.txDescuento.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txDescuento.Name = "txDescuento";
            this.txDescuento.ReadOnly = true;
            this.txDescuento.Size = new System.Drawing.Size(80, 21);
            this.txDescuento.TabIndex = 3;
            this.txDescuento.Text = "0";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(153, 77);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 27);
            this.label7.TabIndex = 26;
            this.label7.Text = "Descuento:";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(91, 78);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 27);
            this.label9.TabIndex = 27;
            this.label9.Text = "% Dto:";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(241, 17);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 27);
            this.label10.TabIndex = 32;
            this.label10.Text = "Tipo Pago:";
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(16, 161);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.Size = new System.Drawing.Size(520, 150);
            this.dgvProductos.TabIndex = 3;
            // 
            // lbIDMovimiento
            // 
            this.lbIDMovimiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbIDMovimiento.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lbIDMovimiento.Location = new System.Drawing.Point(437, 458);
            this.lbIDMovimiento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbIDMovimiento.Name = "lbIDMovimiento";
            this.lbIDMovimiento.Size = new System.Drawing.Size(101, 27);
            this.lbIDMovimiento.TabIndex = 44;
            this.lbIDMovimiento.Text = "IDMovimiento";
            this.lbIDMovimiento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboAlumnos
            // 
            this.cboAlumnos.idGrado = null;
            this.cboAlumnos.Location = new System.Drawing.Point(138, 77);
            this.cboAlumnos.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.cboAlumnos.matricula = null;
            this.cboAlumnos.Name = "cboAlumnos";
            this.cboAlumnos.Size = new System.Drawing.Size(398, 21);
            this.cboAlumnos.SqlQuery = null;
            this.cboAlumnos.TabIndex = 1;
            this.cboAlumnos.OnAlumnoSeleccionado += new System.Action<System.Data.DataRow>(this.cboAlumnos_OnAlumnoSeleccionado);
            // 
            // frmMovimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 494);
            this.Controls.Add(this.cboAlumnos);
            this.Controls.Add(this.comboProductos1);
            this.Controls.Add(this.lbIDMovimiento);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbSeleccion);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmMovimiento";
            this.Text = "frmMovimiento";
            this.Load += new System.EventHandler(this.frmMovimiento_Load);
            this.Controls.SetChildIndex(this.lbSeleccion, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.dgvProductos, 0);
            this.Controls.SetChildIndex(this.lbIDMovimiento, 0);
            this.Controls.SetChildIndex(this.comboProductos1, 0);
            this.Controls.SetChildIndex(this.cboAlumnos, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nPorcDescuento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txCosto;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lbSeleccion;
        private Controles.ComboProductos comboProductos1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txFechaVencimiento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txImporte;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txImportePte;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txRecargo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txDescuento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Label lbIDMovimiento;
        private Controles.ComboAlumnos cboAlumnos;
        private System.Windows.Forms.TextBox txBeca;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nPorcDescuento;
        private System.Windows.Forms.Label label9;
        private Controles.ComboCatalogos cboCatalogos;
        private System.Windows.Forms.Label label10;
    }
}