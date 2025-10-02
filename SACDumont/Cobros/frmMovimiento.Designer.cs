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
            this.gbInformacion = new System.Windows.Forms.GroupBox();
            this.lbBeca = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbPromocion = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbGradoActual = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbGrupoActual = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.chConfirmar = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dtFechaMov = new System.Windows.Forms.DateTimePicker();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.gbProductos.SuspendLayout();
            this.gbCobros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCobros)).BeginInit();
            this.gbInformacion.SuspendLayout();
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
            this.groupBox2.Location = new System.Drawing.Point(19, 651);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(520, 82);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            // 
            // txImporte
            // 
            this.txImporte.Enabled = false;
            this.txImporte.Location = new System.Drawing.Point(3, 44);
            this.txImporte.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txImporte.Name = "txImporte";
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
            this.txTotal.Enabled = false;
            this.txTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txTotal.Location = new System.Drawing.Point(315, 44);
            this.txTotal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txTotal.Name = "txTotal";
            this.txTotal.Size = new System.Drawing.Size(83, 21);
            this.txTotal.TabIndex = 5;
            this.txTotal.Text = "0";
            this.txTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txImportePte
            // 
            this.txImportePte.Enabled = false;
            this.txImportePte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txImportePte.ForeColor = System.Drawing.Color.Red;
            this.txImportePte.Location = new System.Drawing.Point(406, 44);
            this.txImportePte.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txImportePte.Name = "txImportePte";
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
            this.txBeca.Enabled = false;
            this.txBeca.Location = new System.Drawing.Point(159, 44);
            this.txBeca.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txBeca.Name = "txBeca";
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
            this.txRecargo.Enabled = false;
            this.txRecargo.Location = new System.Drawing.Point(233, 44);
            this.txRecargo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txRecargo.Name = "txRecargo";
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
            this.txDescuento.Enabled = false;
            this.txDescuento.Location = new System.Drawing.Point(82, 44);
            this.txDescuento.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txDescuento.Name = "txDescuento";
            this.txDescuento.Size = new System.Drawing.Size(72, 21);
            this.txDescuento.TabIndex = 3;
            this.txDescuento.Text = "0";
            this.txDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(81, 17);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 27);
            this.label7.TabIndex = 26;
            this.label7.Text = "Promocion:";
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductos.Location = new System.Drawing.Point(3, 17);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(479, 245);
            this.dgvProductos.TabIndex = 3;
            // 
            // lbIDMovimiento
            // 
            this.lbIDMovimiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbIDMovimiento.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lbIDMovimiento.Location = new System.Drawing.Point(424, 735);
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
            this.cboAlumnos.Size = new System.Drawing.Size(294, 18);
            this.cboAlumnos.SqlQuery = null;
            this.cboAlumnos.TabIndex = 0;
            this.cboAlumnos.OnAlumnoSeleccionado += new System.Action<System.Data.DataRow>(this.cboAlumnos_OnAlumnoSeleccionado);
            this.cboAlumnos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboAlumnos_KeyPress);
            // 
            // gbProductos
            // 
            this.gbProductos.Controls.Add(this.dgvProductos);
            this.gbProductos.Location = new System.Drawing.Point(16, 198);
            this.gbProductos.Name = "gbProductos";
            this.gbProductos.Size = new System.Drawing.Size(485, 265);
            this.gbProductos.TabIndex = 45;
            this.gbProductos.TabStop = false;
            this.gbProductos.Text = "Productos";
            // 
            // gbCobros
            // 
            this.gbCobros.Controls.Add(this.dgvCobros);
            this.gbCobros.Location = new System.Drawing.Point(19, 469);
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
            this.dgvCobros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCobros.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvCobros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCobros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCobros.Location = new System.Drawing.Point(3, 17);
            this.dgvCobros.Name = "dgvCobros";
            this.dgvCobros.ReadOnly = true;
            this.dgvCobros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCobros.Size = new System.Drawing.Size(476, 156);
            this.dgvCobros.TabIndex = 3;
            // 
            // btNewProducto
            // 
            this.btNewProducto.ImageKey = "3.png";
            this.btNewProducto.ImageList = this.imageList1;
            this.btNewProducto.Location = new System.Drawing.Point(504, 215);
            this.btNewProducto.Name = "btNewProducto";
            this.btNewProducto.Size = new System.Drawing.Size(25, 25);
            this.btNewProducto.TabIndex = 1;
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
            this.btDeleteProducto.Location = new System.Drawing.Point(504, 246);
            this.btDeleteProducto.Name = "btDeleteProducto";
            this.btDeleteProducto.Size = new System.Drawing.Size(25, 25);
            this.btDeleteProducto.TabIndex = 2;
            this.btDeleteProducto.UseVisualStyleBackColor = true;
            this.btDeleteProducto.Click += new System.EventHandler(this.btDeleteProducto_Click);
            // 
            // btDeletePago
            // 
            this.btDeletePago.ImageKey = "4.png";
            this.btDeletePago.ImageList = this.imageList1;
            this.btDeletePago.Location = new System.Drawing.Point(507, 517);
            this.btDeletePago.Name = "btDeletePago";
            this.btDeletePago.Size = new System.Drawing.Size(25, 25);
            this.btDeletePago.TabIndex = 4;
            this.btDeletePago.UseVisualStyleBackColor = true;
            this.btDeletePago.Click += new System.EventHandler(this.btDeletePago_Click);
            // 
            // btNewPago
            // 
            this.btNewPago.ImageKey = "3.png";
            this.btNewPago.ImageList = this.imageList1;
            this.btNewPago.Location = new System.Drawing.Point(507, 486);
            this.btNewPago.Name = "btNewPago";
            this.btNewPago.Size = new System.Drawing.Size(25, 25);
            this.btNewPago.TabIndex = 3;
            this.btNewPago.UseVisualStyleBackColor = true;
            this.btNewPago.Click += new System.EventHandler(this.btNewPago_Click);
            // 
            // gbInformacion
            // 
            this.gbInformacion.Controls.Add(this.lbBeca);
            this.gbInformacion.Controls.Add(this.label12);
            this.gbInformacion.Controls.Add(this.lbPromocion);
            this.gbInformacion.Controls.Add(this.label4);
            this.gbInformacion.Controls.Add(this.lbGradoActual);
            this.gbInformacion.Controls.Add(this.label9);
            this.gbInformacion.Controls.Add(this.lbGrupoActual);
            this.gbInformacion.Controls.Add(this.label10);
            this.gbInformacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbInformacion.Location = new System.Drawing.Point(12, 104);
            this.gbInformacion.Name = "gbInformacion";
            this.gbInformacion.Size = new System.Drawing.Size(520, 88);
            this.gbInformacion.TabIndex = 51;
            this.gbInformacion.TabStop = false;
            this.gbInformacion.Text = "Informacion:";
            // 
            // lbBeca
            // 
            this.lbBeca.AutoSize = true;
            this.lbBeca.Location = new System.Drawing.Point(320, 60);
            this.lbBeca.Name = "lbBeca";
            this.lbBeca.Size = new System.Drawing.Size(26, 15);
            this.lbBeca.TabIndex = 7;
            this.lbBeca.Text = "N/A";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(193, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 15);
            this.label12.TabIndex = 6;
            this.label12.Text = "Beca:";
            // 
            // lbPromocion
            // 
            this.lbPromocion.AutoSize = true;
            this.lbPromocion.Location = new System.Drawing.Point(320, 29);
            this.lbPromocion.Name = "lbPromocion";
            this.lbPromocion.Size = new System.Drawing.Size(26, 15);
            this.lbPromocion.TabIndex = 5;
            this.lbPromocion.Text = "N/A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(193, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Promocion Activa:";
            // 
            // lbGradoActual
            // 
            this.lbGradoActual.AutoSize = true;
            this.lbGradoActual.Location = new System.Drawing.Point(108, 60);
            this.lbGradoActual.Name = "lbGradoActual";
            this.lbGradoActual.Size = new System.Drawing.Size(26, 15);
            this.lbGradoActual.TabIndex = 3;
            this.lbGradoActual.Text = "N/A";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 15);
            this.label9.TabIndex = 2;
            this.label9.Text = "Grado Actual:";
            // 
            // lbGrupoActual
            // 
            this.lbGrupoActual.AutoSize = true;
            this.lbGrupoActual.Location = new System.Drawing.Point(108, 29);
            this.lbGrupoActual.Name = "lbGrupoActual";
            this.lbGrupoActual.Size = new System.Drawing.Size(26, 15);
            this.lbGrupoActual.TabIndex = 1;
            this.lbGrupoActual.Text = "N/A";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "Grupo Actual:";
            // 
            // chConfirmar
            // 
            this.chConfirmar.AutoSize = true;
            this.chConfirmar.Location = new System.Drawing.Point(19, 739);
            this.chConfirmar.Name = "chConfirmar";
            this.chConfirmar.Size = new System.Drawing.Size(90, 19);
            this.chConfirmar.TabIndex = 52;
            this.chConfirmar.Text = "Confirmado";
            this.chConfirmar.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(380, 80);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 21);
            this.label11.TabIndex = 53;
            this.label11.Text = "Fecha:";
            // 
            // dtFechaMov
            // 
            this.dtFechaMov.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtFechaMov.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaMov.Location = new System.Drawing.Point(425, 80);
            this.dtFechaMov.Name = "dtFechaMov";
            this.dtFechaMov.Size = new System.Drawing.Size(108, 21);
            this.dtFechaMov.TabIndex = 54;
            // 
            // frmMovimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 767);
            this.Controls.Add(this.dtFechaMov);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.chConfirmar);
            this.Controls.Add(this.gbInformacion);
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
            this.Controls.SetChildIndex(this.gbInformacion, 0);
            this.Controls.SetChildIndex(this.chConfirmar, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.dtFechaMov, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.gbProductos.ResumeLayout(false);
            this.gbCobros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCobros)).EndInit();
            this.gbInformacion.ResumeLayout(false);
            this.gbInformacion.PerformLayout();
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
        private System.Windows.Forms.GroupBox gbInformacion;
        private System.Windows.Forms.Label lbPromocion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbGradoActual;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbGrupoActual;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbBeca;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chConfirmar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtFechaMov;
    }
}