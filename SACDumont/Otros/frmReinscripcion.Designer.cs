namespace SACDumont.Otros
{
    partial class frmReinscripcion
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
            this.cboAlumnos = new SACDumont.Controles.ComboAlumnos();
            this.label1 = new System.Windows.Forms.Label();
            this.gbInformacion = new System.Windows.Forms.GroupBox();
            this.lbCiclo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbGradoActual = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbGrupoActual = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbAcademico = new System.Windows.Forms.GroupBox();
            this.cboGrupo = new SACDumont.Controles.ComboCatalogos();
            this.cboGrado = new SACDumont.Controles.ComboCatalogos();
            this.cboCiclo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.gbInformacion.SuspendLayout();
            this.gbAcademico.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboAlumnos
            // 
            this.cboAlumnos.idGrado = null;
            this.cboAlumnos.Location = new System.Drawing.Point(146, 78);
            this.cboAlumnos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboAlumnos.matricula = 0;
            this.cboAlumnos.Name = "cboAlumnos";
            this.cboAlumnos.Size = new System.Drawing.Size(417, 18);
            this.cboAlumnos.SqlQuery = null;
            this.cboAlumnos.TabIndex = 3;
            this.cboAlumnos.OnAlumnoSeleccionado += new System.Action<System.Data.DataRow>(this.cboAlumnos_OnAlumnoSeleccionado);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(81, 78);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Alumno:";
            // 
            // gbInformacion
            // 
            this.gbInformacion.Controls.Add(this.lbCiclo);
            this.gbInformacion.Controls.Add(this.label7);
            this.gbInformacion.Controls.Add(this.lbGradoActual);
            this.gbInformacion.Controls.Add(this.label5);
            this.gbInformacion.Controls.Add(this.lbGrupoActual);
            this.gbInformacion.Controls.Add(this.label2);
            this.gbInformacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbInformacion.Location = new System.Drawing.Point(12, 115);
            this.gbInformacion.Name = "gbInformacion";
            this.gbInformacion.Size = new System.Drawing.Size(672, 86);
            this.gbInformacion.TabIndex = 4;
            this.gbInformacion.TabStop = false;
            this.gbInformacion.Text = "Informacion:";
            this.gbInformacion.Enter += new System.EventHandler(this.gbInformacion_Enter);
            // 
            // lbCiclo
            // 
            this.lbCiclo.AutoSize = true;
            this.lbCiclo.Location = new System.Drawing.Point(518, 41);
            this.lbCiclo.Name = "lbCiclo";
            this.lbCiclo.Size = new System.Drawing.Size(26, 15);
            this.lbCiclo.TabIndex = 5;
            this.lbCiclo.Text = "N/A";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(469, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "Ciclo:";
            // 
            // lbGradoActual
            // 
            this.lbGradoActual.AutoSize = true;
            this.lbGradoActual.Location = new System.Drawing.Point(365, 41);
            this.lbGradoActual.Name = "lbGradoActual";
            this.lbGradoActual.Size = new System.Drawing.Size(26, 15);
            this.lbGradoActual.TabIndex = 3;
            this.lbGradoActual.Text = "N/A";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(266, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Grado Actual:";
            // 
            // lbGrupoActual
            // 
            this.lbGrupoActual.AutoSize = true;
            this.lbGrupoActual.Location = new System.Drawing.Point(168, 41);
            this.lbGrupoActual.Name = "lbGrupoActual";
            this.lbGrupoActual.Size = new System.Drawing.Size(26, 15);
            this.lbGrupoActual.TabIndex = 1;
            this.lbGrupoActual.Text = "N/A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Grupo Actual:";
            // 
            // gbAcademico
            // 
            this.gbAcademico.Controls.Add(this.cboGrupo);
            this.gbAcademico.Controls.Add(this.cboGrado);
            this.gbAcademico.Controls.Add(this.cboCiclo);
            this.gbAcademico.Controls.Add(this.label9);
            this.gbAcademico.Controls.Add(this.label11);
            this.gbAcademico.Controls.Add(this.label13);
            this.gbAcademico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAcademico.Location = new System.Drawing.Point(12, 207);
            this.gbAcademico.Name = "gbAcademico";
            this.gbAcademico.Size = new System.Drawing.Size(672, 97);
            this.gbAcademico.TabIndex = 6;
            this.gbAcademico.TabStop = false;
            this.gbAcademico.Text = "Información académica:";
            this.gbAcademico.Enter += new System.EventHandler(this.gbAcademico_Enter);
            // 
            // cboGrupo
            // 
            this.cboGrupo.Descripcion = null;
            this.cboGrupo.IDValor = 0;
            this.cboGrupo.Location = new System.Drawing.Point(64, 41);
            this.cboGrupo.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.cboGrupo.Name = "cboGrupo";
            this.cboGrupo.Size = new System.Drawing.Size(158, 24);
            this.cboGrupo.TabIndex = 64;
            this.cboGrupo.TipoCatalogo = "Grupo";
            // 
            // cboGrado
            // 
            this.cboGrado.Descripcion = null;
            this.cboGrado.IDValor = 0;
            this.cboGrado.Location = new System.Drawing.Point(288, 41);
            this.cboGrado.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.cboGrado.Name = "cboGrado";
            this.cboGrado.Size = new System.Drawing.Size(163, 24);
            this.cboGrado.TabIndex = 63;
            this.cboGrado.TipoCatalogo = "Grado";
            // 
            // cboCiclo
            // 
            this.cboCiclo.FormattingEnabled = true;
            this.cboCiclo.Location = new System.Drawing.Point(508, 41);
            this.cboCiclo.Name = "cboCiclo";
            this.cboCiclo.Size = new System.Drawing.Size(158, 21);
            this.cboCiclo.TabIndex = 5;
            this.cboCiclo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(459, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 15);
            this.label9.TabIndex = 4;
            this.label9.Text = "Ciclo:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(230, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 15);
            this.label11.TabIndex = 2;
            this.label11.Text = "Grado:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 44);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 15);
            this.label13.TabIndex = 0;
            this.label13.Text = "Grupo:";
            // 
            // frmReinscripcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 328);
            this.Controls.Add(this.gbAcademico);
            this.Controls.Add(this.gbInformacion);
            this.Controls.Add(this.cboAlumnos);
            this.Controls.Add(this.label1);
            this.Name = "frmReinscripcion";
            this.Text = "frmReinscripcion";
            this.Load += new System.EventHandler(this.frmReinscripcion_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cboAlumnos, 0);
            this.Controls.SetChildIndex(this.gbInformacion, 0);
            this.Controls.SetChildIndex(this.gbAcademico, 0);
            this.gbInformacion.ResumeLayout(false);
            this.gbInformacion.PerformLayout();
            this.gbAcademico.ResumeLayout(false);
            this.gbAcademico.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.ComboAlumnos cboAlumnos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbInformacion;
        private System.Windows.Forms.Label lbCiclo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbGradoActual;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbGrupoActual;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbAcademico;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboCiclo;
        private Controles.ComboCatalogos cboGrupo;
        private Controles.ComboCatalogos cboGrado;
    }
}