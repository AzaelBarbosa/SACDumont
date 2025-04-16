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
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(12, 86);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(257, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // txtApPaterno
            // 
            this.txtApPaterno.Location = new System.Drawing.Point(12, 136);
            this.txtApPaterno.Name = "txtApPaterno";
            this.txtApPaterno.Size = new System.Drawing.Size(257, 20);
            this.txtApPaterno.TabIndex = 3;
            // 
            // txtApMaterno
            // 
            this.txtApMaterno.Location = new System.Drawing.Point(12, 186);
            this.txtApMaterno.Name = "txtApMaterno";
            this.txtApMaterno.Size = new System.Drawing.Size(257, 20);
            this.txtApMaterno.TabIndex = 5;
            // 
            // dtpFechaNac
            // 
            this.dtpFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNac.Location = new System.Drawing.Point(12, 236);
            this.dtpFechaNac.Name = "dtpFechaNac";
            this.dtpFechaNac.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaNac.TabIndex = 7;
            // 
            // cmbSexo
            // 
            this.cmbSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSexo.Location = new System.Drawing.Point(12, 286);
            this.cmbSexo.Name = "cmbSexo";
            this.cmbSexo.Size = new System.Drawing.Size(200, 21);
            this.cmbSexo.TabIndex = 9;
            // 
            // cmbPais
            // 
            this.cmbPais.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPais.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPais.Location = new System.Drawing.Point(12, 336);
            this.cmbPais.Name = "cmbPais";
            this.cmbPais.Size = new System.Drawing.Size(200, 21);
            this.cmbPais.TabIndex = 11;
            this.cmbPais.SelectedValueChanged += new System.EventHandler(this.cmbPais_SelectedValueChanged);
            this.cmbPais.Validating += new System.ComponentModel.CancelEventHandler(this.cmbPais_Validating);
            // 
            // cmbEstadoNac
            // 
            this.cmbEstadoNac.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbEstadoNac.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEstadoNac.Location = new System.Drawing.Point(12, 386);
            this.cmbEstadoNac.Name = "cmbEstadoNac";
            this.cmbEstadoNac.Size = new System.Drawing.Size(200, 21);
            this.cmbEstadoNac.TabIndex = 13;
            this.cmbEstadoNac.Validating += new System.ComponentModel.CancelEventHandler(this.cmbEstadoNac_Validating);
            // 
            // txtCurp
            // 
            this.txtCurp.Location = new System.Drawing.Point(12, 436);
            this.txtCurp.Name = "txtCurp";
            this.txtCurp.Size = new System.Drawing.Size(257, 20);
            this.txtCurp.TabIndex = 15;
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(306, 86);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(378, 20);
            this.txtCalle.TabIndex = 17;
            // 
            // txtColonia
            // 
            this.txtColonia.Location = new System.Drawing.Point(306, 136);
            this.txtColonia.Name = "txtColonia";
            this.txtColonia.Size = new System.Drawing.Size(378, 20);
            this.txtColonia.TabIndex = 19;
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(306, 186);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(378, 20);
            this.txtCiudad.TabIndex = 21;
            // 
            // cmbEstado
            // 
            this.cmbEstado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbEstado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEstado.Location = new System.Drawing.Point(306, 236);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(200, 21);
            this.cmbEstado.TabIndex = 23;
            this.cmbEstado.Validating += new System.ComponentModel.CancelEventHandler(this.cmbEstado_Validating);
            // 
            // txtTel1
            // 
            this.txtTel1.Location = new System.Drawing.Point(306, 286);
            this.txtTel1.MaxLength = 10;
            this.txtTel1.Name = "txtTel1";
            this.txtTel1.Size = new System.Drawing.Size(200, 20);
            this.txtTel1.TabIndex = 25;
            // 
            // txtTel2
            // 
            this.txtTel2.Location = new System.Drawing.Point(306, 336);
            this.txtTel2.MaxLength = 10;
            this.txtTel2.Name = "txtTel2";
            this.txtTel2.Size = new System.Drawing.Size(200, 20);
            this.txtTel2.TabIndex = 27;
            // 
            // txtTel3
            // 
            this.txtTel3.Location = new System.Drawing.Point(306, 386);
            this.txtTel3.MaxLength = 10;
            this.txtTel3.Name = "txtTel3";
            this.txtTel3.Size = new System.Drawing.Size(200, 20);
            this.txtTel3.TabIndex = 29;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(306, 436);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 20);
            this.txtEmail.TabIndex = 31;
            // 
            // chkActivo
            // 
            this.chkActivo.Checked = true;
            this.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivo.Location = new System.Drawing.Point(12, 474);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(100, 24);
            this.chkActivo.TabIndex = 32;
            this.chkActivo.Text = "Activo";
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(12, 66);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(100, 23);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblApPaterno
            // 
            this.lblApPaterno.Location = new System.Drawing.Point(12, 116);
            this.lblApPaterno.Name = "lblApPaterno";
            this.lblApPaterno.Size = new System.Drawing.Size(100, 23);
            this.lblApPaterno.TabIndex = 2;
            this.lblApPaterno.Text = "Apellido Paterno:";
            // 
            // lblApMaterno
            // 
            this.lblApMaterno.Location = new System.Drawing.Point(12, 166);
            this.lblApMaterno.Name = "lblApMaterno";
            this.lblApMaterno.Size = new System.Drawing.Size(100, 23);
            this.lblApMaterno.TabIndex = 4;
            this.lblApMaterno.Text = "Apellido Materno:";
            // 
            // lblFechaNac
            // 
            this.lblFechaNac.Location = new System.Drawing.Point(12, 216);
            this.lblFechaNac.Name = "lblFechaNac";
            this.lblFechaNac.Size = new System.Drawing.Size(168, 23);
            this.lblFechaNac.TabIndex = 6;
            this.lblFechaNac.Text = "Fecha de nacimiento:";
            // 
            // lblSexo
            // 
            this.lblSexo.Location = new System.Drawing.Point(12, 266);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(100, 23);
            this.lblSexo.TabIndex = 8;
            this.lblSexo.Text = "Sexo:";
            // 
            // lblPais
            // 
            this.lblPais.Location = new System.Drawing.Point(12, 316);
            this.lblPais.Name = "lblPais";
            this.lblPais.Size = new System.Drawing.Size(144, 23);
            this.lblPais.TabIndex = 10;
            this.lblPais.Text = "País de nacimiento:";
            // 
            // lblEstadoNac
            // 
            this.lblEstadoNac.Location = new System.Drawing.Point(12, 366);
            this.lblEstadoNac.Name = "lblEstadoNac";
            this.lblEstadoNac.Size = new System.Drawing.Size(144, 23);
            this.lblEstadoNac.TabIndex = 12;
            this.lblEstadoNac.Text = "Estado de nacimiento:";
            // 
            // lblCurp
            // 
            this.lblCurp.Location = new System.Drawing.Point(12, 416);
            this.lblCurp.Name = "lblCurp";
            this.lblCurp.Size = new System.Drawing.Size(100, 23);
            this.lblCurp.TabIndex = 14;
            this.lblCurp.Text = "CURP:";
            // 
            // lblCalle
            // 
            this.lblCalle.Location = new System.Drawing.Point(306, 66);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(100, 23);
            this.lblCalle.TabIndex = 16;
            this.lblCalle.Text = "Calle:";
            // 
            // lblColonia
            // 
            this.lblColonia.Location = new System.Drawing.Point(306, 116);
            this.lblColonia.Name = "lblColonia";
            this.lblColonia.Size = new System.Drawing.Size(100, 23);
            this.lblColonia.TabIndex = 18;
            this.lblColonia.Text = "Colonia:";
            // 
            // lblCiudad
            // 
            this.lblCiudad.Location = new System.Drawing.Point(306, 166);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(100, 23);
            this.lblCiudad.TabIndex = 20;
            this.lblCiudad.Text = "Ciudad:";
            // 
            // lblEstado
            // 
            this.lblEstado.Location = new System.Drawing.Point(306, 216);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(100, 23);
            this.lblEstado.TabIndex = 22;
            this.lblEstado.Text = "Estado:";
            // 
            // lblTel1
            // 
            this.lblTel1.Location = new System.Drawing.Point(306, 266);
            this.lblTel1.Name = "lblTel1";
            this.lblTel1.Size = new System.Drawing.Size(100, 23);
            this.lblTel1.TabIndex = 24;
            this.lblTel1.Text = "Teléfono 1:";
            // 
            // lblTel2
            // 
            this.lblTel2.Location = new System.Drawing.Point(306, 316);
            this.lblTel2.Name = "lblTel2";
            this.lblTel2.Size = new System.Drawing.Size(100, 23);
            this.lblTel2.TabIndex = 26;
            this.lblTel2.Text = "Teléfono 2:";
            // 
            // lblTel3
            // 
            this.lblTel3.Location = new System.Drawing.Point(306, 366);
            this.lblTel3.Name = "lblTel3";
            this.lblTel3.Size = new System.Drawing.Size(100, 23);
            this.lblTel3.TabIndex = 28;
            this.lblTel3.Text = "Teléfono 3:";
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(306, 416);
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
            this.lbMatricula.Location = new System.Drawing.Point(592, 479);
            this.lbMatricula.Name = "lbMatricula";
            this.lbMatricula.Size = new System.Drawing.Size(100, 23);
            this.lbMatricula.TabIndex = 33;
            this.lbMatricula.Text = "lbMatricula";
            this.lbMatricula.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmCatAlumnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(704, 506);
            this.Controls.Add(this.lbMatricula);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtApPaterno);
            this.Controls.Add(this.txtApMaterno);
            this.Controls.Add(this.dtpFechaNac);
            this.Controls.Add(this.cmbSexo);
            this.Controls.Add(this.cmbPais);
            this.Controls.Add(this.cmbEstadoNac);
            this.Controls.Add(this.txtCurp);
            this.Controls.Add(this.txtCalle);
            this.Controls.Add(this.txtColonia);
            this.Controls.Add(this.txtCiudad);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.txtTel1);
            this.Controls.Add(this.txtTel2);
            this.Controls.Add(this.txtTel3);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblApPaterno);
            this.Controls.Add(this.lblApMaterno);
            this.Controls.Add(this.lblFechaNac);
            this.Controls.Add(this.lblSexo);
            this.Controls.Add(this.lblPais);
            this.Controls.Add(this.lblEstadoNac);
            this.Controls.Add(this.lblCurp);
            this.Controls.Add(this.lblCalle);
            this.Controls.Add(this.lblColonia);
            this.Controls.Add(this.lblCiudad);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblTel1);
            this.Controls.Add(this.lblTel2);
            this.Controls.Add(this.lblTel3);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.chkActivo);
            this.Name = "frmCatAlumnos";
            this.Text = "Formulario de Alumno";
            this.Load += new System.EventHandler(this.frmCatAlumnos_Load);
            this.Controls.SetChildIndex(this.chkActivo, 0);
            this.Controls.SetChildIndex(this.lblEmail, 0);
            this.Controls.SetChildIndex(this.lblTel3, 0);
            this.Controls.SetChildIndex(this.lblTel2, 0);
            this.Controls.SetChildIndex(this.lblTel1, 0);
            this.Controls.SetChildIndex(this.lblEstado, 0);
            this.Controls.SetChildIndex(this.lblCiudad, 0);
            this.Controls.SetChildIndex(this.lblColonia, 0);
            this.Controls.SetChildIndex(this.lblCalle, 0);
            this.Controls.SetChildIndex(this.lblCurp, 0);
            this.Controls.SetChildIndex(this.lblEstadoNac, 0);
            this.Controls.SetChildIndex(this.lblPais, 0);
            this.Controls.SetChildIndex(this.lblSexo, 0);
            this.Controls.SetChildIndex(this.lblFechaNac, 0);
            this.Controls.SetChildIndex(this.lblApMaterno, 0);
            this.Controls.SetChildIndex(this.lblApPaterno, 0);
            this.Controls.SetChildIndex(this.lblNombre, 0);
            this.Controls.SetChildIndex(this.txtEmail, 0);
            this.Controls.SetChildIndex(this.txtTel3, 0);
            this.Controls.SetChildIndex(this.txtTel2, 0);
            this.Controls.SetChildIndex(this.txtTel1, 0);
            this.Controls.SetChildIndex(this.cmbEstado, 0);
            this.Controls.SetChildIndex(this.txtCiudad, 0);
            this.Controls.SetChildIndex(this.txtColonia, 0);
            this.Controls.SetChildIndex(this.txtCalle, 0);
            this.Controls.SetChildIndex(this.txtCurp, 0);
            this.Controls.SetChildIndex(this.cmbEstadoNac, 0);
            this.Controls.SetChildIndex(this.cmbPais, 0);
            this.Controls.SetChildIndex(this.cmbSexo, 0);
            this.Controls.SetChildIndex(this.dtpFechaNac, 0);
            this.Controls.SetChildIndex(this.txtApMaterno, 0);
            this.Controls.SetChildIndex(this.txtApPaterno, 0);
            this.Controls.SetChildIndex(this.txtNombre, 0);
            this.Controls.SetChildIndex(this.lbMatricula, 0);
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
    }
}