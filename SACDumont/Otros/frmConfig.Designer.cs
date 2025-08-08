namespace SACDumont.Otros
{
    partial class frmConfig
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
            this.gbOtros = new System.Windows.Forms.GroupBox();
            this.nDiasTolerancia = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.txPorcentajeRecargo = new System.Windows.Forms.TextBox();
            this.chRecargos = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gbBase = new System.Windows.Forms.GroupBox();
            this.txEquipo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txContra = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txUsuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txBasseDatos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txServidor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chPromociones = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txZonaMat = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txSEPMat = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txZonaSec = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txSEPSecundaria = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txZonaPrim = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txSEPPrimaria = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txZonaPre = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txSEPPre = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gbOtros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nDiasTolerancia)).BeginInit();
            this.gbBase.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbOtros
            // 
            this.gbOtros.Controls.Add(this.nDiasTolerancia);
            this.gbOtros.Controls.Add(this.label6);
            this.gbOtros.Controls.Add(this.txPorcentajeRecargo);
            this.gbOtros.Controls.Add(this.chRecargos);
            this.gbOtros.Controls.Add(this.label5);
            this.gbOtros.Location = new System.Drawing.Point(12, 249);
            this.gbOtros.Name = "gbOtros";
            this.gbOtros.Size = new System.Drawing.Size(385, 68);
            this.gbOtros.TabIndex = 12;
            this.gbOtros.TabStop = false;
            this.gbOtros.Text = "Recargos";
            // 
            // nDiasTolerancia
            // 
            this.nDiasTolerancia.Enabled = false;
            this.nDiasTolerancia.Location = new System.Drawing.Point(215, 34);
            this.nDiasTolerancia.Name = "nDiasTolerancia";
            this.nDiasTolerancia.Size = new System.Drawing.Size(56, 20);
            this.nDiasTolerancia.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(212, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Dias de tolerancia";
            // 
            // txPorcentajeRecargo
            // 
            this.txPorcentajeRecargo.Enabled = false;
            this.txPorcentajeRecargo.Location = new System.Drawing.Point(112, 34);
            this.txPorcentajeRecargo.Name = "txPorcentajeRecargo";
            this.txPorcentajeRecargo.Size = new System.Drawing.Size(58, 20);
            this.txPorcentajeRecargo.TabIndex = 8;
            // 
            // chRecargos
            // 
            this.chRecargos.AutoSize = true;
            this.chRecargos.Location = new System.Drawing.Point(14, 34);
            this.chRecargos.Name = "chRecargos";
            this.chRecargos.Size = new System.Drawing.Size(72, 17);
            this.chRecargos.TabIndex = 1;
            this.chRecargos.Text = "Recargos";
            this.chRecargos.UseVisualStyleBackColor = true;
            this.chRecargos.CheckedChanged += new System.EventHandler(this.chRecargos_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(109, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Porcentaje:";
            // 
            // gbBase
            // 
            this.gbBase.Controls.Add(this.txEquipo);
            this.gbBase.Controls.Add(this.label15);
            this.gbBase.Controls.Add(this.txContra);
            this.gbBase.Controls.Add(this.label4);
            this.gbBase.Controls.Add(this.txUsuario);
            this.gbBase.Controls.Add(this.label3);
            this.gbBase.Controls.Add(this.txBasseDatos);
            this.gbBase.Controls.Add(this.label2);
            this.gbBase.Controls.Add(this.txServidor);
            this.gbBase.Controls.Add(this.label1);
            this.gbBase.Location = new System.Drawing.Point(12, 38);
            this.gbBase.Name = "gbBase";
            this.gbBase.Size = new System.Drawing.Size(385, 205);
            this.gbBase.TabIndex = 10;
            this.gbBase.TabStop = false;
            this.gbBase.Text = "Base de Datos SQL";
            // 
            // txEquipo
            // 
            this.txEquipo.Location = new System.Drawing.Point(112, 170);
            this.txEquipo.Name = "txEquipo";
            this.txEquipo.Size = new System.Drawing.Size(246, 20);
            this.txEquipo.TabIndex = 9;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(27, 173);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 13);
            this.label15.TabIndex = 8;
            this.label15.Text = "Equipo:";
            // 
            // txContra
            // 
            this.txContra.Location = new System.Drawing.Point(112, 124);
            this.txContra.Name = "txContra";
            this.txContra.PasswordChar = '*';
            this.txContra.Size = new System.Drawing.Size(246, 20);
            this.txContra.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Contraseña:";
            // 
            // txUsuario
            // 
            this.txUsuario.Location = new System.Drawing.Point(112, 96);
            this.txUsuario.Name = "txUsuario";
            this.txUsuario.Size = new System.Drawing.Size(246, 20);
            this.txUsuario.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Usuario:";
            // 
            // txBasseDatos
            // 
            this.txBasseDatos.Location = new System.Drawing.Point(112, 64);
            this.txBasseDatos.Name = "txBasseDatos";
            this.txBasseDatos.Size = new System.Drawing.Size(246, 20);
            this.txBasseDatos.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Base de Datos:";
            // 
            // txServidor
            // 
            this.txServidor.Location = new System.Drawing.Point(112, 33);
            this.txServidor.Name = "txServidor";
            this.txServidor.Size = new System.Drawing.Size(246, 20);
            this.txServidor.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Servidor:";
            // 
            // chPromociones
            // 
            this.chPromociones.AutoSize = true;
            this.chPromociones.Location = new System.Drawing.Point(14, 28);
            this.chPromociones.Name = "chPromociones";
            this.chPromociones.Size = new System.Drawing.Size(87, 17);
            this.chPromociones.TabIndex = 2;
            this.chPromociones.Text = "Promociones";
            this.chPromociones.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txZonaMat);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txSEPMat);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txZonaSec);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txSEPSecundaria);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txZonaPrim);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txSEPPrimaria);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txZonaPre);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txSEPPre);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.chPromociones);
            this.groupBox1.Location = new System.Drawing.Point(12, 323);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 256);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
            // 
            // txZonaMat
            // 
            this.txZonaMat.Location = new System.Drawing.Point(165, 215);
            this.txZonaMat.Name = "txZonaMat";
            this.txZonaMat.Size = new System.Drawing.Size(102, 20);
            this.txZonaMat.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(162, 197);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(109, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "Maternal Clave Zona:";
            // 
            // txSEPMat
            // 
            this.txSEPMat.Location = new System.Drawing.Point(14, 215);
            this.txSEPMat.Name = "txSEPMat";
            this.txSEPMat.Size = new System.Drawing.Size(147, 20);
            this.txSEPMat.TabIndex = 22;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 197);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(105, 13);
            this.label14.TabIndex = 21;
            this.label14.Text = "Maternal Clave SEP:";
            // 
            // txZonaSec
            // 
            this.txZonaSec.Location = new System.Drawing.Point(165, 169);
            this.txZonaSec.Name = "txZonaSec";
            this.txZonaSec.Size = new System.Drawing.Size(102, 20);
            this.txZonaSec.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(162, 151);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(122, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Secundaria Clave Zona:";
            // 
            // txSEPSecundaria
            // 
            this.txSEPSecundaria.Location = new System.Drawing.Point(14, 169);
            this.txSEPSecundaria.Name = "txSEPSecundaria";
            this.txSEPSecundaria.Size = new System.Drawing.Size(147, 20);
            this.txSEPSecundaria.TabIndex = 18;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 151);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "Secundaria Clave SEP:";
            // 
            // txZonaPrim
            // 
            this.txZonaPrim.Location = new System.Drawing.Point(165, 123);
            this.txZonaPrim.Name = "txZonaPrim";
            this.txZonaPrim.Size = new System.Drawing.Size(102, 20);
            this.txZonaPrim.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(162, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Primaria Clave Zona:";
            // 
            // txSEPPrimaria
            // 
            this.txSEPPrimaria.Location = new System.Drawing.Point(14, 123);
            this.txSEPPrimaria.Name = "txSEPPrimaria";
            this.txSEPPrimaria.Size = new System.Drawing.Size(147, 20);
            this.txSEPPrimaria.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Primaria Clave SEP:";
            // 
            // txZonaPre
            // 
            this.txZonaPre.Location = new System.Drawing.Point(165, 78);
            this.txZonaPre.Name = "txZonaPre";
            this.txZonaPre.Size = new System.Drawing.Size(102, 20);
            this.txZonaPre.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(162, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Pre-Escolar Clave Zona:";
            // 
            // txSEPPre
            // 
            this.txSEPPre.Location = new System.Drawing.Point(14, 78);
            this.txSEPPre.Name = "txSEPPre";
            this.txSEPPre.Size = new System.Drawing.Size(147, 20);
            this.txSEPPre.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Pre-Escolar Clave SEP:";
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 591);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbOtros);
            this.Controls.Add(this.gbBase);
            this.Name = "frmConfig";
            this.Text = "frmConfig";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.Controls.SetChildIndex(this.gbBase, 0);
            this.Controls.SetChildIndex(this.gbOtros, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.gbOtros.ResumeLayout(false);
            this.gbOtros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nDiasTolerancia)).EndInit();
            this.gbBase.ResumeLayout(false);
            this.gbBase.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbOtros;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbBase;
        private System.Windows.Forms.TextBox txContra;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txBasseDatos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txServidor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chPromociones;
        private System.Windows.Forms.CheckBox chRecargos;
        private System.Windows.Forms.TextBox txPorcentajeRecargo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nDiasTolerancia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txZonaPrim;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txSEPPrimaria;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txZonaPre;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txSEPPre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txEquipo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txZonaMat;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txSEPMat;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txZonaSec;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txSEPSecundaria;
        private System.Windows.Forms.Label label12;
    }
}