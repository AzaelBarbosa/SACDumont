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
            this.gbOtros.Location = new System.Drawing.Point(12, 209);
            this.gbOtros.Name = "gbOtros";
            this.gbOtros.Size = new System.Drawing.Size(519, 68);
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
            this.gbBase.Size = new System.Drawing.Size(519, 165);
            this.gbBase.TabIndex = 10;
            this.gbBase.TabStop = false;
            this.gbBase.Text = "Base de Datos SQL";
            // 
            // txContra
            // 
            this.txContra.Location = new System.Drawing.Point(112, 124);
            this.txContra.Name = "txContra";
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
            this.groupBox1.Controls.Add(this.chPromociones);
            this.groupBox1.Location = new System.Drawing.Point(12, 283);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(519, 68);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 363);
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
    }
}