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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMovimiento));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txImporte = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txTotal = new System.Windows.Forms.TextBox();
            this.txImportePte = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txBeca = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txRecargo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txDescuento = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.lbIDMovimiento = new System.Windows.Forms.Label();
            this.cboAlumnos = new SACDumont.Controles.ComboAlumnos();
            this.gbProductos = new System.Windows.Forms.GroupBox();
            this.gbCobros = new System.Windows.Forms.GroupBox();
            this.dgvCobros = new System.Windows.Forms.DataGridView();
            this.btNewProducto = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btDeleteProducto = new System.Windows.Forms.Button();
            this.btDeletePago = new System.Windows.Forms.Button();
            this.btNewPago = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.gbProductos.SuspendLayout();
            this.gbCobros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCobros)).BeginInit();
            this.SuspendLayout();
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txImporte);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txTotal);
            this.groupBox2.Controls.Add(this.txImportePte);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txBeca);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txRecargo);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txDescuento);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(19, 572);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(520, 82);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            // 
            // txImporte
            // 
            this.txImporte.Location = new System.Drawing.Point(3, 44);
            this.txImporte.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txImporte.Name = "txImporte";
            this.txImporte.ReadOnly = true;
            this.txImporte.Size = new System.Drawing.Size(72, 21);
            this.txImporte.TabIndex = 31;
            this.txImporte.Text = "0";
            this.txImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(2, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 27);
            this.label2.TabIndex = 32;
            this.label2.Text = "Importe:";
            // 
            // txTotal
            // 
            this.txTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txTotal.Location = new System.Drawing.Point(315, 44);
            this.txTotal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txTotal.Name = "txTotal";
            this.txTotal.ReadOnly = true;
            this.txTotal.Size = new System.Drawing.Size(83, 21);
            this.txTotal.TabIndex = 5;
            this.txTotal.Text = "0";
            this.txTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txImportePte
            // 
            this.txImportePte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txImportePte.ForeColor = System.Drawing.Color.Red;
            this.txImportePte.Location = new System.Drawing.Point(406, 44);
            this.txImportePte.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txImportePte.Name = "txImportePte";
            this.txImportePte.ReadOnly = true;
            this.txImportePte.Size = new System.Drawing.Size(107, 21);
            this.txImportePte.TabIndex = 6;
            this.txImportePte.Text = "0";
            this.txImportePte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(312, 17);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 27);
            this.label5.TabIndex = 26;
            this.label5.Text = "Total:";
            // 
            // txBeca
            // 
            this.txBeca.Location = new System.Drawing.Point(159, 44);
            this.txBeca.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txBeca.Name = "txBeca";
            this.txBeca.ReadOnly = true;
            this.txBeca.Size = new System.Drawing.Size(66, 21);
            this.txBeca.TabIndex = 29;
            this.txBeca.Text = "0";
            this.txBeca.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(403, 17);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 27);
            this.label6.TabIndex = 28;
            this.label6.Text = "Importe Pendiente:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(164, 17);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 27);
            this.label8.TabIndex = 30;
            this.label8.Text = "Beca:";
            // 
            // txRecargo
            // 
            this.txRecargo.Location = new System.Drawing.Point(233, 44);
            this.txRecargo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txRecargo.Name = "txRecargo";
            this.txRecargo.ReadOnly = true;
            this.txRecargo.Size = new System.Drawing.Size(74, 21);
            this.txRecargo.TabIndex = 2;
            this.txRecargo.Text = "0";
            this.txRecargo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(230, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 27);
            this.label3.TabIndex = 24;
            this.label3.Text = "Recargo:";
            // 
            // txDescuento
            // 
            this.txDescuento.Location = new System.Drawing.Point(79, 44);
            this.txDescuento.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txDescuento.Name = "txDescuento";
            this.txDescuento.ReadOnly = true;
            this.txDescuento.Size = new System.Drawing.Size(72, 21);
            this.txDescuento.TabIndex = 3;
            this.txDescuento.Text = "0";
            this.txDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(76, 17);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 27);
            this.label7.TabIndex = 26;
            this.label7.Text = "Descuento:";
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductos.Location = new System.Drawing.Point(3, 17);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.Size = new System.Drawing.Size(479, 245);
            this.dgvProductos.TabIndex = 3;
            // 
            // lbIDMovimiento
            // 
            this.lbIDMovimiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbIDMovimiento.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lbIDMovimiento.Location = new System.Drawing.Point(434, 657);
            this.lbIDMovimiento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbIDMovimiento.Name = "lbIDMovimiento";
            this.lbIDMovimiento.Size = new System.Drawing.Size(101, 23);
            this.lbIDMovimiento.TabIndex = 44;
            this.lbIDMovimiento.Text = "IDMovimiento";
            this.lbIDMovimiento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboAlumnos
            // 
            this.cboAlumnos.idGrado = null;
            this.cboAlumnos.Location = new System.Drawing.Point(78, 80);
            this.cboAlumnos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboAlumnos.matricula = 0;
            this.cboAlumnos.Name = "cboAlumnos";
            this.cboAlumnos.Size = new System.Drawing.Size(417, 18);
            this.cboAlumnos.SqlQuery = null;
            this.cboAlumnos.TabIndex = 1;
            this.cboAlumnos.OnAlumnoSeleccionado += new System.Action<System.Data.DataRow>(this.cboAlumnos_OnAlumnoSeleccionado);
            this.cboAlumnos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboAlumnos_KeyPress);
            // 
            // gbProductos
            // 
            this.gbProductos.Controls.Add(this.dgvProductos);
            this.gbProductos.Location = new System.Drawing.Point(16, 119);
            this.gbProductos.Name = "gbProductos";
            this.gbProductos.Size = new System.Drawing.Size(485, 265);
            this.gbProductos.TabIndex = 45;
            this.gbProductos.TabStop = false;
            this.gbProductos.Text = "Productos";
            // 
            // gbCobros
            // 
            this.gbCobros.Controls.Add(this.dgvCobros);
            this.gbCobros.Location = new System.Drawing.Point(19, 390);
            this.gbCobros.Name = "gbCobros";
            this.gbCobros.Size = new System.Drawing.Size(482, 176);
            this.gbCobros.TabIndex = 46;
            this.gbCobros.TabStop = false;
            this.gbCobros.Text = "Pagos";
            // 
            // dgvCobros
            // 
            this.dgvCobros.AllowUserToAddRows = false;
            this.dgvCobros.AllowUserToDeleteRows = false;
            this.dgvCobros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCobros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCobros.Location = new System.Drawing.Point(3, 17);
            this.dgvCobros.Name = "dgvCobros";
            this.dgvCobros.ReadOnly = true;
            this.dgvCobros.Size = new System.Drawing.Size(476, 156);
            this.dgvCobros.TabIndex = 3;
            // 
            // btNewProducto
            // 
            this.btNewProducto.ImageKey = "3.png";
            this.btNewProducto.ImageList = this.imageList1;
            this.btNewProducto.Location = new System.Drawing.Point(504, 136);
            this.btNewProducto.Name = "btNewProducto";
            this.btNewProducto.Size = new System.Drawing.Size(25, 25);
            this.btNewProducto.TabIndex = 47;
            this.btNewProducto.UseVisualStyleBackColor = true;
            this.btNewProducto.Click += new System.EventHandler(this.button1_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1.png");
            this.imageList1.Images.SetKeyName(1, "2.png");
            this.imageList1.Images.SetKeyName(2, "3.png");
            this.imageList1.Images.SetKeyName(3, "4.png");
            this.imageList1.Images.SetKeyName(4, "5.png");
            this.imageList1.Images.SetKeyName(5, "6.png");
            this.imageList1.Images.SetKeyName(6, "7.png");
            this.imageList1.Images.SetKeyName(7, "8.png");
            this.imageList1.Images.SetKeyName(8, "9.png");
            this.imageList1.Images.SetKeyName(9, "10.png");
            this.imageList1.Images.SetKeyName(10, "11.png");
            this.imageList1.Images.SetKeyName(11, "12.png");
            this.imageList1.Images.SetKeyName(12, "13.png");
            this.imageList1.Images.SetKeyName(13, "14.png");
            this.imageList1.Images.SetKeyName(14, "15.png");
            this.imageList1.Images.SetKeyName(15, "16.png");
            this.imageList1.Images.SetKeyName(16, "17.png");
            // 
            // btDeleteProducto
            // 
            this.btDeleteProducto.ImageKey = "4.png";
            this.btDeleteProducto.ImageList = this.imageList1;
            this.btDeleteProducto.Location = new System.Drawing.Point(504, 167);
            this.btDeleteProducto.Name = "btDeleteProducto";
            this.btDeleteProducto.Size = new System.Drawing.Size(25, 25);
            this.btDeleteProducto.TabIndex = 48;
            this.btDeleteProducto.UseVisualStyleBackColor = true;
            // 
            // btDeletePago
            // 
            this.btDeletePago.ImageKey = "4.png";
            this.btDeletePago.ImageList = this.imageList1;
            this.btDeletePago.Location = new System.Drawing.Point(507, 438);
            this.btDeletePago.Name = "btDeletePago";
            this.btDeletePago.Size = new System.Drawing.Size(25, 25);
            this.btDeletePago.TabIndex = 50;
            this.btDeletePago.UseVisualStyleBackColor = true;
            // 
            // btNewPago
            // 
            this.btNewPago.ImageKey = "3.png";
            this.btNewPago.ImageList = this.imageList1;
            this.btNewPago.Location = new System.Drawing.Point(507, 407);
            this.btNewPago.Name = "btNewPago";
            this.btNewPago.Size = new System.Drawing.Size(25, 25);
            this.btNewPago.TabIndex = 49;
            this.btNewPago.UseVisualStyleBackColor = true;
            this.btNewPago.Click += new System.EventHandler(this.btNewPago_Click);
            // 
            // frmMovimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 689);
            this.Controls.Add(this.btDeletePago);
            this.Controls.Add(this.btNewPago);
            this.Controls.Add(this.btDeleteProducto);
            this.Controls.Add(this.btNewProducto);
            this.Controls.Add(this.gbCobros);
            this.Controls.Add(this.gbProductos);
            this.Controls.Add(this.cboAlumnos);
            this.Controls.Add(this.lbIDMovimiento);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmMovimiento";
            this.Text = "frmMovimiento";
            this.Load += new System.EventHandler(this.frmMovimiento_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.lbIDMovimiento, 0);
            this.Controls.SetChildIndex(this.cboAlumnos, 0);
            this.Controls.SetChildIndex(this.gbProductos, 0);
            this.Controls.SetChildIndex(this.gbCobros, 0);
            this.Controls.SetChildIndex(this.btNewProducto, 0);
            this.Controls.SetChildIndex(this.btDeleteProducto, 0);
            this.Controls.SetChildIndex(this.btNewPago, 0);
            this.Controls.SetChildIndex(this.btDeletePago, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.gbProductos.ResumeLayout(false);
            this.gbCobros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCobros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
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
        private System.Windows.Forms.GroupBox gbProductos;
        private System.Windows.Forms.GroupBox gbCobros;
        private System.Windows.Forms.DataGridView dgvCobros;
        private System.Windows.Forms.Button btNewProducto;
        private System.Windows.Forms.Button btDeleteProducto;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btDeletePago;
        private System.Windows.Forms.Button btNewPago;
        private System.Windows.Forms.TextBox txImporte;
        private System.Windows.Forms.Label label2;
    }
}