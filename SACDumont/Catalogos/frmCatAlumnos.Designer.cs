namespace SACDumont.Catalogos
{
    partial class frmCatAlumnos
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
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApPaterno = new System.Windows.Forms.TextBox();
            this.txtApMaterno = new System.Windows.Forms.TextBox();
            this.dtpFechaNac = new System.Windows.Forms.DateTimePicker();
            this.cmbSexo = new System.Windows.Forms.ComboBox();
            this.cmbPais = new System.Windows.Forms.ComboBox();
            this.cmbEstadoNac = new System.Windows.Forms.ComboBox();
            this.txtCurp = new System.Windows.Forms.TextBox();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.txtColonia = new System.Windows.Forms.TextBox();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.txtTel1 = new System.Windows.Forms.TextBox();
            this.txtTel2 = new System.Windows.Forms.TextBox();
            this.txtTel3 = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApPaterno = new System.Windows.Forms.Label();
            this.lblApMaterno = new System.Windows.Forms.Label();
            this.lblFechaNac = new System.Windows.Forms.Label();
            this.lblSexo = new System.Windows.Forms.Label();
            this.lblPais = new System.Windows.Forms.Label();
            this.lblEstadoNac = new System.Windows.Forms.Label();
            this.lblCurp = new System.Windows.Forms.Label();
            this.lblCalle = new System.Windows.Forms.Label();
            this.lblColonia = new System.Windows.Forms.Label();
            this.lblCiudad = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblTel1 = new System.Windows.Forms.Label();
            this.lblTel2 = new System.Windows.Forms.Label();
            this.lblTel3 = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lbMatricula = new System.Windows.Forms.Label();
            this.gbAlumno = new System.Windows.Forms.GroupBox();
            this.gbDomicilio = new System.Windows.Forms.GroupBox();
            this.gbAcademicos = new System.Windows.Forms.GroupBox();
            this.cboGrupo = new SACDumont.Controles.ComboCatalogos();
            this.label1 = new System.Windows.Forms.Label();
            this.cboGrado = new SACDumont.Controles.ComboCatalogos();
            this.label10 = new System.Windows.Forms.Label();
            this.gbFinanciero = new System.Windows.Forms.GroupBox();
            this.chBecado = new System.Windows.Forms.CheckBox();
            this.gbBecado = new System.Windows.Forms.GroupBox();
            this.nPorBeca = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.chPromocion = new System.Windows.Forms.CheckBox();
            this.gbPromocion = new System.Windows.Forms.GroupBox();
            this.cboPromocion = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbAlumno.SuspendLayout();
            this.gbDomicilio.SuspendLayout();
            this.gbAcademicos.SuspendLayout();
            this.gbFinanciero.SuspendLayout();
            this.gbBecado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nPorBeca)).BeginInit();
            this.gbPromocion.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(19, 48);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // txtApPaterno
            // 
            this.txtApPaterno.Location = new System.Drawing.Point(225, 48);
            this.txtApPaterno.Name = "txtApPaterno";
            this.txtApPaterno.Size = new System.Drawing.Size(168, 20);
            this.txtApPaterno.TabIndex = 3;
            // 
            // txtApMaterno
            // 
            this.txtApMaterno.Location = new System.Drawing.Point(399, 48);
            this.txtApMaterno.Name = "txtApMaterno";
            this.txtApMaterno.Size = new System.Drawing.Size(177, 20);
            this.txtApMaterno.TabIndex = 5;
            // 
            // dtpFechaNac
            // 
            this.dtpFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNac.Location = new System.Drawing.Point(19, 101);
            this.dtpFechaNac.Name = "dtpFechaNac";
            this.dtpFechaNac.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaNac.TabIndex = 7;
            // 
            // cmbSexo
            // 
            this.cmbSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSexo.Location = new System.Drawing.Point(225, 101);
            this.cmbSexo.Name = "cmbSexo";
            this.cmbSexo.Size = new System.Drawing.Size(168, 21);
            this.cmbSexo.TabIndex = 9;
            // 
            // cmbPais
            // 
            this.cmbPais.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPais.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPais.Location = new System.Drawing.Point(399, 101);
            this.cmbPais.Name = "cmbPais";
            this.cmbPais.Size = new System.Drawing.Size(177, 21);
            this.cmbPais.TabIndex = 11;
            this.cmbPais.Validating += new System.ComponentModel.CancelEventHandler(this.cmbPais_Validating);
            // 
            // cmbEstadoNac
            // 
            this.cmbEstadoNac.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbEstadoNac.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEstadoNac.Location = new System.Drawing.Point(19, 155);
            this.cmbEstadoNac.Name = "cmbEstadoNac";
            this.cmbEstadoNac.Size = new System.Drawing.Size(200, 21);
            this.cmbEstadoNac.TabIndex = 13;
            this.cmbEstadoNac.Validating += new System.ComponentModel.CancelEventHandler(this.cmbEstadoNac_Validating);
            // 
            // txtCurp
            // 
            this.txtCurp.Location = new System.Drawing.Point(225, 155);
            this.txtCurp.Name = "txtCurp";
            this.txtCurp.Size = new System.Drawing.Size(257, 20);
            this.txtCurp.TabIndex = 15;
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(18, 47);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(270, 20);
            this.txtCalle.TabIndex = 17;
            // 
            // txtColonia
            // 
            this.txtColonia.Location = new System.Drawing.Point(293, 47);
            this.txtColonia.Name = "txtColonia";
            this.txtColonia.Size = new System.Drawing.Size(270, 20);
            this.txtColonia.TabIndex = 19;
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(19, 100);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(270, 20);
            this.txtCiudad.TabIndex = 21;
            // 
            // cmbEstado
            // 
            this.cmbEstado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbEstado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEstado.Location = new System.Drawing.Point(295, 100);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(200, 21);
            this.cmbEstado.TabIndex = 23;
            this.cmbEstado.Validating += new System.ComponentModel.CancelEventHandler(this.cmbEstado_Validating);
            // 
            // txtTel1
            // 
            this.txtTel1.Location = new System.Drawing.Point(19, 152);
            this.txtTel1.MaxLength = 10;
            this.txtTel1.Name = "txtTel1";
            this.txtTel1.Size = new System.Drawing.Size(178, 20);
            this.txtTel1.TabIndex = 25;
            // 
            // txtTel2
            // 
            this.txtTel2.Location = new System.Drawing.Point(201, 152);
            this.txtTel2.MaxLength = 10;
            this.txtTel2.Name = "txtTel2";
            this.txtTel2.Size = new System.Drawing.Size(178, 20);
            this.txtTel2.TabIndex = 27;
            // 
            // txtTel3
            // 
            this.txtTel3.Location = new System.Drawing.Point(382, 152);
            this.txtTel3.MaxLength = 10;
            this.txtTel3.Name = "txtTel3";
            this.txtTel3.Size = new System.Drawing.Size(178, 20);
            this.txtTel3.TabIndex = 29;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(19, 204);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(360, 20);
            this.txtEmail.TabIndex = 31;
            // 
            // chkActivo
            // 
            this.chkActivo.Checked = true;
            this.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivo.Location = new System.Drawing.Point(488, 153);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(88, 24);
            this.chkActivo.TabIndex = 32;
            this.chkActivo.Text = "Activo";
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(19, 28);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(100, 23);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblApPaterno
            // 
            this.lblApPaterno.Location = new System.Drawing.Point(225, 28);
            this.lblApPaterno.Name = "lblApPaterno";
            this.lblApPaterno.Size = new System.Drawing.Size(100, 23);
            this.lblApPaterno.TabIndex = 2;
            this.lblApPaterno.Text = "Apellido Paterno:";
            // 
            // lblApMaterno
            // 
            this.lblApMaterno.Location = new System.Drawing.Point(399, 28);
            this.lblApMaterno.Name = "lblApMaterno";
            this.lblApMaterno.Size = new System.Drawing.Size(100, 23);
            this.lblApMaterno.TabIndex = 4;
            this.lblApMaterno.Text = "Apellido Materno:";
            // 
            // lblFechaNac
            // 
            this.lblFechaNac.Location = new System.Drawing.Point(19, 81);
            this.lblFechaNac.Name = "lblFechaNac";
            this.lblFechaNac.Size = new System.Drawing.Size(168, 23);
            this.lblFechaNac.TabIndex = 6;
            this.lblFechaNac.Text = "Fecha de nacimiento:";
            // 
            // lblSexo
            // 
            this.lblSexo.Location = new System.Drawing.Point(225, 81);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(100, 23);
            this.lblSexo.TabIndex = 8;
            this.lblSexo.Text = "Sexo:";
            // 
            // lblPais
            // 
            this.lblPais.Location = new System.Drawing.Point(399, 81);
            this.lblPais.Name = "lblPais";
            this.lblPais.Size = new System.Drawing.Size(144, 23);
            this.lblPais.TabIndex = 10;
            this.lblPais.Text = "País de nacimiento:";
            // 
            // lblEstadoNac
            // 
            this.lblEstadoNac.Location = new System.Drawing.Point(19, 135);
            this.lblEstadoNac.Name = "lblEstadoNac";
            this.lblEstadoNac.Size = new System.Drawing.Size(144, 23);
            this.lblEstadoNac.TabIndex = 12;
            this.lblEstadoNac.Text = "Estado de nacimiento:";
            // 
            // lblCurp
            // 
            this.lblCurp.Location = new System.Drawing.Point(225, 135);
            this.lblCurp.Name = "lblCurp";
            this.lblCurp.Size = new System.Drawing.Size(100, 23);
            this.lblCurp.TabIndex = 14;
            this.lblCurp.Text = "CURP:";
            // 
            // lblCalle
            // 
            this.lblCalle.Location = new System.Drawing.Point(18, 27);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(100, 23);
            this.lblCalle.TabIndex = 16;
            this.lblCalle.Text = "Calle:";
            // 
            // lblColonia
            // 
            this.lblColonia.Location = new System.Drawing.Point(293, 27);
            this.lblColonia.Name = "lblColonia";
            this.lblColonia.Size = new System.Drawing.Size(100, 23);
            this.lblColonia.TabIndex = 18;
            this.lblColonia.Text = "Colonia:";
            // 
            // lblCiudad
            // 
            this.lblCiudad.Location = new System.Drawing.Point(19, 80);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(100, 23);
            this.lblCiudad.TabIndex = 20;
            this.lblCiudad.Text = "Ciudad:";
            // 
            // lblEstado
            // 
            this.lblEstado.Location = new System.Drawing.Point(295, 80);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(100, 23);
            this.lblEstado.TabIndex = 22;
            this.lblEstado.Text = "Estado:";
            // 
            // lblTel1
            // 
            this.lblTel1.Location = new System.Drawing.Point(19, 132);
            this.lblTel1.Name = "lblTel1";
            this.lblTel1.Size = new System.Drawing.Size(100, 23);
            this.lblTel1.TabIndex = 24;
            this.lblTel1.Text = "Teléfono 1:";
            // 
            // lblTel2
            // 
            this.lblTel2.Location = new System.Drawing.Point(201, 132);
            this.lblTel2.Name = "lblTel2";
            this.lblTel2.Size = new System.Drawing.Size(100, 23);
            this.lblTel2.TabIndex = 26;
            this.lblTel2.Text = "Teléfono 2:";
            // 
            // lblTel3
            // 
            this.lblTel3.Location = new System.Drawing.Point(382, 132);
            this.lblTel3.Name = "lblTel3";
            this.lblTel3.Size = new System.Drawing.Size(100, 23);
            this.lblTel3.TabIndex = 28;
            this.lblTel3.Text = "Teléfono 3:";
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(19, 184);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(100, 23);
            this.lblEmail.TabIndex = 30;
            this.lblEmail.Text = "Email:";
            // 
            // lbMatricula
            // 
            this.lbMatricula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMatricula.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lbMatricula.Location = new System.Drawing.Point(490, 671);
            this.lbMatricula.Name = "lbMatricula";
            this.lbMatricula.Size = new System.Drawing.Size(100, 23);
            this.lbMatricula.TabIndex = 33;
            this.lbMatricula.Text = "lbMatricula";
            this.lbMatricula.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbAlumno
            // 
            this.gbAlumno.Controls.Add(this.chkActivo);
            this.gbAlumno.Controls.Add(this.txtNombre);
            this.gbAlumno.Controls.Add(this.txtApPaterno);
            this.gbAlumno.Controls.Add(this.txtApMaterno);
            this.gbAlumno.Controls.Add(this.dtpFechaNac);
            this.gbAlumno.Controls.Add(this.cmbSexo);
            this.gbAlumno.Controls.Add(this.cmbPais);
            this.gbAlumno.Controls.Add(this.cmbEstadoNac);
            this.gbAlumno.Controls.Add(this.txtCurp);
            this.gbAlumno.Controls.Add(this.lblCurp);
            this.gbAlumno.Controls.Add(this.lblEstadoNac);
            this.gbAlumno.Controls.Add(this.lblPais);
            this.gbAlumno.Controls.Add(this.lblSexo);
            this.gbAlumno.Controls.Add(this.lblFechaNac);
            this.gbAlumno.Controls.Add(this.lblApMaterno);
            this.gbAlumno.Controls.Add(this.lblApPaterno);
            this.gbAlumno.Controls.Add(this.lblNombre);
            this.gbAlumno.Location = new System.Drawing.Point(12, 70);
            this.gbAlumno.Name = "gbAlumno";
            this.gbAlumno.Size = new System.Drawing.Size(582, 185);
            this.gbAlumno.TabIndex = 34;
            this.gbAlumno.TabStop = false;
            this.gbAlumno.Text = "Alumno";
            // 
            // gbDomicilio
            // 
            this.gbDomicilio.Controls.Add(this.txtEmail);
            this.gbDomicilio.Controls.Add(this.lblEmail);
            this.gbDomicilio.Controls.Add(this.txtTel3);
            this.gbDomicilio.Controls.Add(this.txtTel2);
            this.gbDomicilio.Controls.Add(this.lblTel3);
            this.gbDomicilio.Controls.Add(this.txtTel1);
            this.gbDomicilio.Controls.Add(this.cmbEstado);
            this.gbDomicilio.Controls.Add(this.lblTel2);
            this.gbDomicilio.Controls.Add(this.txtCiudad);
            this.gbDomicilio.Controls.Add(this.txtColonia);
            this.gbDomicilio.Controls.Add(this.lblTel1);
            this.gbDomicilio.Controls.Add(this.txtCalle);
            this.gbDomicilio.Controls.Add(this.lblColonia);
            this.gbDomicilio.Controls.Add(this.lblEstado);
            this.gbDomicilio.Controls.Add(this.lblCiudad);
            this.gbDomicilio.Controls.Add(this.lblCalle);
            this.gbDomicilio.Location = new System.Drawing.Point(12, 261);
            this.gbDomicilio.Name = "gbDomicilio";
            this.gbDomicilio.Size = new System.Drawing.Size(582, 235);
            this.gbDomicilio.TabIndex = 35;
            this.gbDomicilio.TabStop = false;
            this.gbDomicilio.Text = "Domicilio";
            // 
            // gbAcademicos
            // 
            this.gbAcademicos.Controls.Add(this.cboGrupo);
            this.gbAcademicos.Controls.Add(this.label1);
            this.gbAcademicos.Controls.Add(this.cboGrado);
            this.gbAcademicos.Controls.Add(this.label10);
            this.gbAcademicos.Location = new System.Drawing.Point(12, 502);
            this.gbAcademicos.Name = "gbAcademicos";
            this.gbAcademicos.Size = new System.Drawing.Size(173, 165);
            this.gbAcademicos.TabIndex = 36;
            this.gbAcademicos.TabStop = false;
            this.gbAcademicos.Text = "Datos Académicos";
            // 
            // cboGrupo
            // 
            this.cboGrupo.Descripcion = null;
            this.cboGrupo.IDValor = 0;
            this.cboGrupo.Location = new System.Drawing.Point(10, 124);
            this.cboGrupo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboGrupo.Name = "cboGrupo";
            this.cboGrupo.Size = new System.Drawing.Size(144, 21);
            this.cboGrupo.TabIndex = 62;
            this.cboGrupo.TipoCatalogo = "Grupo";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 102);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 27);
            this.label1.TabIndex = 63;
            this.label1.Text = "Grupo:";
            // 
            // cboGrado
            // 
            this.cboGrado.Descripcion = null;
            this.cboGrado.IDValor = 0;
            this.cboGrado.Location = new System.Drawing.Point(10, 50);
            this.cboGrado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboGrado.Name = "cboGrado";
            this.cboGrado.Size = new System.Drawing.Size(144, 21);
            this.cboGrado.TabIndex = 60;
            this.cboGrado.TipoCatalogo = "Grado";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(7, 28);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 27);
            this.label10.TabIndex = 61;
            this.label10.Text = "Grado:";
            // 
            // gbFinanciero
            // 
            this.gbFinanciero.Controls.Add(this.chBecado);
            this.gbFinanciero.Controls.Add(this.gbBecado);
            this.gbFinanciero.Controls.Add(this.chPromocion);
            this.gbFinanciero.Controls.Add(this.gbPromocion);
            this.gbFinanciero.Location = new System.Drawing.Point(191, 502);
            this.gbFinanciero.Name = "gbFinanciero";
            this.gbFinanciero.Size = new System.Drawing.Size(403, 165);
            this.gbFinanciero.TabIndex = 37;
            this.gbFinanciero.TabStop = false;
            this.gbFinanciero.Text = "Inscripción";
            // 
            // chBecado
            // 
            this.chBecado.Location = new System.Drawing.Point(212, 16);
            this.chBecado.Name = "chBecado";
            this.chBecado.Size = new System.Drawing.Size(88, 24);
            this.chBecado.TabIndex = 33;
            this.chBecado.Text = "Becado";
            this.chBecado.CheckedChanged += new System.EventHandler(this.chBecado_CheckedChanged);
            // 
            // gbBecado
            // 
            this.gbBecado.Controls.Add(this.nPorBeca);
            this.gbBecado.Controls.Add(this.label2);
            this.gbBecado.Enabled = false;
            this.gbBecado.Location = new System.Drawing.Point(212, 19);
            this.gbBecado.Name = "gbBecado";
            this.gbBecado.Size = new System.Drawing.Size(185, 140);
            this.gbBecado.TabIndex = 68;
            this.gbBecado.TabStop = false;
            // 
            // nPorBeca
            // 
            this.nPorBeca.Location = new System.Drawing.Point(109, 40);
            this.nPorBeca.Name = "nPorBeca";
            this.nPorBeca.Size = new System.Drawing.Size(61, 20);
            this.nPorBeca.TabIndex = 34;
            this.nPorBeca.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nPorBeca.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 27);
            this.label2.TabIndex = 64;
            this.label2.Text = "Porcentaje de beca:";
            // 
            // chPromocion
            // 
            this.chPromocion.Location = new System.Drawing.Point(6, 16);
            this.chPromocion.Name = "chPromocion";
            this.chPromocion.Size = new System.Drawing.Size(88, 24);
            this.chPromocion.TabIndex = 66;
            this.chPromocion.Text = "Promocion";
            this.chPromocion.CheckedChanged += new System.EventHandler(this.chPromocion_CheckedChanged);
            // 
            // gbPromocion
            // 
            this.gbPromocion.Controls.Add(this.cboPromocion);
            this.gbPromocion.Controls.Add(this.label3);
            this.gbPromocion.Enabled = false;
            this.gbPromocion.Location = new System.Drawing.Point(6, 19);
            this.gbPromocion.Name = "gbPromocion";
            this.gbPromocion.Size = new System.Drawing.Size(200, 140);
            this.gbPromocion.TabIndex = 67;
            this.gbPromocion.TabStop = false;
            // 
            // cboPromocion
            // 
            this.cboPromocion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboPromocion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPromocion.Location = new System.Drawing.Point(59, 40);
            this.cboPromocion.Name = "cboPromocion";
            this.cboPromocion.Size = new System.Drawing.Size(135, 21);
            this.cboPromocion.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(1, 43);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 27);
            this.label3.TabIndex = 65;
            this.label3.Text = "Promoción:";
            // 
            // frmCatAlumnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(602, 698);
            this.Controls.Add(this.gbFinanciero);
            this.Controls.Add(this.gbAcademicos);
            this.Controls.Add(this.gbDomicilio);
            this.Controls.Add(this.gbAlumno);
            this.Controls.Add(this.lbMatricula);
            this.Name = "frmCatAlumnos";
            this.Text = "Formulario de Alumno";
            this.Load += new System.EventHandler(this.frmCatAlumnos_Load);
            this.Controls.SetChildIndex(this.lbMatricula, 0);
            this.Controls.SetChildIndex(this.gbAlumno, 0);
            this.Controls.SetChildIndex(this.gbDomicilio, 0);
            this.Controls.SetChildIndex(this.gbAcademicos, 0);
            this.Controls.SetChildIndex(this.gbFinanciero, 0);
            this.gbAlumno.ResumeLayout(false);
            this.gbAlumno.PerformLayout();
            this.gbDomicilio.ResumeLayout(false);
            this.gbDomicilio.PerformLayout();
            this.gbAcademicos.ResumeLayout(false);
            this.gbFinanciero.ResumeLayout(false);
            this.gbBecado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nPorBeca)).EndInit();
            this.gbPromocion.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtNombre, txtApPaterno, txtApMaterno, txtCurp, txtCalle,
          txtColonia, txtCiudad, txtTel1, txtTel2, txtTel3, txtEmail;
        private System.Windows.Forms.DateTimePicker dtpFechaNac;
        private System.Windows.Forms.ComboBox cmbSexo, cmbPais, cmbEstadoNac, cmbEstado;
        private System.Windows.Forms.CheckBox chkActivo;

        private System.Windows.Forms.Label lblNombre, lblApPaterno, lblApMaterno, lblFechaNac, lblSexo,
            lblPais, lblEstadoNac, lblCurp, lblCalle, lblColonia, lblCiudad,
            lblEstado, lblTel1, lblTel2, lblTel3, lblEmail;
        private System.Windows.Forms.Label lbMatricula;
        private System.Windows.Forms.GroupBox gbAlumno;
        private System.Windows.Forms.GroupBox gbDomicilio;
        private System.Windows.Forms.GroupBox gbAcademicos;
        private Controles.ComboCatalogos cboGrupo;
        private System.Windows.Forms.Label label1;
        private Controles.ComboCatalogos cboGrado;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox gbFinanciero;
        private System.Windows.Forms.ComboBox cboPromocion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nPorBeca;
        private System.Windows.Forms.CheckBox chBecado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chPromocion;
        private System.Windows.Forms.GroupBox gbBecado;
        private System.Windows.Forms.GroupBox gbPromocion;
    }
}