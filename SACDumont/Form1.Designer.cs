namespace SACDumont
{
    partial class frmMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btInscripcion = new System.Windows.Forms.ToolStripMenuItem();
            this.btNuevoIngreso = new System.Windows.Forms.ToolStripMenuItem();
            this.btReinscripcion = new System.Windows.Forms.ToolStripMenuItem();
            this.btCobros = new System.Windows.Forms.ToolStripMenuItem();
            this.btCobroColegiatura = new System.Windows.Forms.ToolStripMenuItem();
            this.btCobroInscripcion = new System.Windows.Forms.ToolStripMenuItem();
            this.btCobroProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.btCobroAbonos = new System.Windows.Forms.ToolStripMenuItem();
            this.btCatalogos = new System.Windows.Forms.ToolStripMenuItem();
            this.btCatalogosProducto = new System.Windows.Forms.ToolStripMenuItem();
            this.btCatalogosAlumnos = new System.Windows.Forms.ToolStripMenuItem();
            this.btCatalogosTutores = new System.Windows.Forms.ToolStripMenuItem();
            this.btCatalogosUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.btReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.btReimpresionTickets = new System.Windows.Forms.ToolStripMenuItem();
            this.btRptAcdemicos = new System.Windows.Forms.ToolStripMenuItem();
            this.btRptAcdemicosAsistencia = new System.Windows.Forms.ToolStripMenuItem();
            this.btRptAcdemicosCumple = new System.Windows.Forms.ToolStripMenuItem();
            this.btRptAcdemicosAlumnos = new System.Windows.Forms.ToolStripMenuItem();
            this.btRptAdministrativo = new System.Windows.Forms.ToolStripMenuItem();
            this.btRptAdministrativoCorte = new System.Windows.Forms.ToolStripMenuItem();
            this.btRptAdministrativoCorteDirio = new System.Windows.Forms.ToolStripMenuItem();
            this.btRptAdministrativoCorteFecha = new System.Windows.Forms.ToolStripMenuItem();
            this.btRptAdministrativoBecas = new System.Windows.Forms.ToolStripMenuItem();
            this.btRptAdministrativoFacturas = new System.Windows.Forms.ToolStripMenuItem();
            this.btRptAdministrativoUniformes = new System.Windows.Forms.ToolStripMenuItem();
            this.btRptAdministrativoActividad = new System.Windows.Forms.ToolStripMenuItem();
            this.btConfiguracion = new System.Windows.Forms.ToolStripMenuItem();
            this.btCerarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.btSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btInscripcion,
            this.btCobros,
            this.btCatalogos,
            this.btReportes,
            this.btConfiguracion,
            this.btCerarSesion,
            this.btSalir});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(981, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btInscripcion
            // 
            this.btInscripcion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btNuevoIngreso,
            this.btReinscripcion});
            this.btInscripcion.Image = global::SACDumont.Properties.Resources.estudiante_universitario;
            this.btInscripcion.Name = "btInscripcion";
            this.btInscripcion.Size = new System.Drawing.Size(93, 20);
            this.btInscripcion.Text = "Inscripcion";
            // 
            // btNuevoIngreso
            // 
            this.btNuevoIngreso.Name = "btNuevoIngreso";
            this.btNuevoIngreso.Size = new System.Drawing.Size(151, 22);
            this.btNuevoIngreso.Text = "Nuevo Ingreso";
            // 
            // btReinscripcion
            // 
            this.btReinscripcion.Name = "btReinscripcion";
            this.btReinscripcion.Size = new System.Drawing.Size(151, 22);
            this.btReinscripcion.Text = "Reinscripcion";
            // 
            // btCobros
            // 
            this.btCobros.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btCobroColegiatura,
            this.btCobroInscripcion,
            this.btCobroProducts,
            this.btCobroAbonos});
            this.btCobros.Image = global::SACDumont.Properties.Resources.cuenta_por_cobrar;
            this.btCobros.Name = "btCobros";
            this.btCobros.Size = new System.Drawing.Size(73, 20);
            this.btCobros.Text = "Cobros";
            // 
            // btCobroColegiatura
            // 
            this.btCobroColegiatura.Image = global::SACDumont.Properties.Resources.salario_del_usuario;
            this.btCobroColegiatura.Name = "btCobroColegiatura";
            this.btCobroColegiatura.Size = new System.Drawing.Size(135, 22);
            this.btCobroColegiatura.Text = "Colegiatura";
            // 
            // btCobroInscripcion
            // 
            this.btCobroInscripcion.Image = global::SACDumont.Properties.Resources.salario__1_;
            this.btCobroInscripcion.Name = "btCobroInscripcion";
            this.btCobroInscripcion.Size = new System.Drawing.Size(135, 22);
            this.btCobroInscripcion.Text = "Inscripcion";
            // 
            // btCobroProducts
            // 
            this.btCobroProducts.Image = global::SACDumont.Properties.Resources.salario;
            this.btCobroProducts.Name = "btCobroProducts";
            this.btCobroProducts.Size = new System.Drawing.Size(135, 22);
            this.btCobroProducts.Text = "Productos";
            // 
            // btCobroAbonos
            // 
            this.btCobroAbonos.Image = global::SACDumont.Properties.Resources.salario_bajo;
            this.btCobroAbonos.Name = "btCobroAbonos";
            this.btCobroAbonos.Size = new System.Drawing.Size(135, 22);
            this.btCobroAbonos.Text = "Abonos";
            // 
            // btCatalogos
            // 
            this.btCatalogos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btCatalogosProducto,
            this.btCatalogosAlumnos,
            this.btCatalogosTutores,
            this.btCatalogosUsuarios});
            this.btCatalogos.Image = global::SACDumont.Properties.Resources.libro_y_lapiz;
            this.btCatalogos.Name = "btCatalogos";
            this.btCatalogos.Size = new System.Drawing.Size(88, 20);
            this.btCatalogos.Text = "Catalogos";
            // 
            // btCatalogosProducto
            // 
            this.btCatalogosProducto.Image = global::SACDumont.Properties.Resources.caja_de_entrega;
            this.btCatalogosProducto.Name = "btCatalogosProducto";
            this.btCatalogosProducto.Size = new System.Drawing.Size(128, 22);
            this.btCatalogosProducto.Text = "Productos";
            // 
            // btCatalogosAlumnos
            // 
            this.btCatalogosAlumnos.Image = global::SACDumont.Properties.Resources.estudiante_universitario;
            this.btCatalogosAlumnos.Name = "btCatalogosAlumnos";
            this.btCatalogosAlumnos.Size = new System.Drawing.Size(128, 22);
            this.btCatalogosAlumnos.Text = "Alumnos";
            this.btCatalogosAlumnos.Click += new System.EventHandler(this.btCatalogosAlumnos_Click);
            // 
            // btCatalogosTutores
            // 
            this.btCatalogosTutores.Image = global::SACDumont.Properties.Resources.tutor;
            this.btCatalogosTutores.Name = "btCatalogosTutores";
            this.btCatalogosTutores.Size = new System.Drawing.Size(128, 22);
            this.btCatalogosTutores.Text = "Tutores";
            this.btCatalogosTutores.Click += new System.EventHandler(this.btCatalogosTutores_Click);
            // 
            // btCatalogosUsuarios
            // 
            this.btCatalogosUsuarios.Image = global::SACDumont.Properties.Resources.silueta_de_multiples_usuarios;
            this.btCatalogosUsuarios.Name = "btCatalogosUsuarios";
            this.btCatalogosUsuarios.Size = new System.Drawing.Size(128, 22);
            this.btCatalogosUsuarios.Text = "Usuarios";
            // 
            // btReportes
            // 
            this.btReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btReimpresionTickets,
            this.btRptAcdemicos,
            this.btRptAdministrativo});
            this.btReportes.Image = global::SACDumont.Properties.Resources.reportes;
            this.btReportes.Name = "btReportes";
            this.btReportes.Size = new System.Drawing.Size(81, 20);
            this.btReportes.Text = "Reportes";
            // 
            // btReimpresionTickets
            // 
            this.btReimpresionTickets.Image = global::SACDumont.Properties.Resources.factura;
            this.btReimpresionTickets.Name = "btReimpresionTickets";
            this.btReimpresionTickets.Size = new System.Drawing.Size(179, 22);
            this.btReimpresionTickets.Text = "Reimpresion Tickets";
            // 
            // btRptAcdemicos
            // 
            this.btRptAcdemicos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btRptAcdemicosAsistencia,
            this.btRptAcdemicosCumple,
            this.btRptAcdemicosAlumnos});
            this.btRptAcdemicos.Image = global::SACDumont.Properties.Resources.academic;
            this.btRptAcdemicos.Name = "btRptAcdemicos";
            this.btRptAcdemicos.Size = new System.Drawing.Size(179, 22);
            this.btRptAcdemicos.Text = "Academicos";
            // 
            // btRptAcdemicosAsistencia
            // 
            this.btRptAcdemicosAsistencia.Image = global::SACDumont.Properties.Resources.contrato;
            this.btRptAcdemicosAsistencia.Name = "btRptAcdemicosAsistencia";
            this.btRptAcdemicosAsistencia.Size = new System.Drawing.Size(168, 22);
            this.btRptAcdemicosAsistencia.Text = "Lista Asistencia";
            // 
            // btRptAcdemicosCumple
            // 
            this.btRptAcdemicosCumple.Image = global::SACDumont.Properties.Resources.cumpleanos;
            this.btRptAcdemicosCumple.Name = "btRptAcdemicosCumple";
            this.btRptAcdemicosCumple.Size = new System.Drawing.Size(168, 22);
            this.btRptAcdemicosCumple.Text = "Lista Cumpleaños";
            // 
            // btRptAcdemicosAlumnos
            // 
            this.btRptAcdemicosAlumnos.Image = global::SACDumont.Properties.Resources.contrato;
            this.btRptAcdemicosAlumnos.Name = "btRptAcdemicosAlumnos";
            this.btRptAcdemicosAlumnos.Size = new System.Drawing.Size(168, 22);
            this.btRptAcdemicosAlumnos.Text = "Lista Alumnos";
            // 
            // btRptAdministrativo
            // 
            this.btRptAdministrativo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btRptAdministrativoCorte,
            this.btRptAdministrativoBecas,
            this.btRptAdministrativoFacturas,
            this.btRptAdministrativoUniformes,
            this.btRptAdministrativoActividad});
            this.btRptAdministrativo.Image = global::SACDumont.Properties.Resources.administrativo;
            this.btRptAdministrativo.Name = "btRptAdministrativo";
            this.btRptAdministrativo.Size = new System.Drawing.Size(179, 22);
            this.btRptAdministrativo.Text = "Administrtivo";
            // 
            // btRptAdministrativoCorte
            // 
            this.btRptAdministrativoCorte.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btRptAdministrativoCorteDirio,
            this.btRptAdministrativoCorteFecha});
            this.btRptAdministrativoCorte.Name = "btRptAdministrativoCorte";
            this.btRptAdministrativoCorte.Size = new System.Drawing.Size(167, 22);
            this.btRptAdministrativoCorte.Text = "Corte";
            // 
            // btRptAdministrativoCorteDirio
            // 
            this.btRptAdministrativoCorteDirio.Name = "btRptAdministrativoCorteDirio";
            this.btRptAdministrativoCorteDirio.Size = new System.Drawing.Size(126, 22);
            this.btRptAdministrativoCorteDirio.Text = "Diario";
            // 
            // btRptAdministrativoCorteFecha
            // 
            this.btRptAdministrativoCorteFecha.Name = "btRptAdministrativoCorteFecha";
            this.btRptAdministrativoCorteFecha.Size = new System.Drawing.Size(126, 22);
            this.btRptAdministrativoCorteFecha.Text = "Por Fecha";
            // 
            // btRptAdministrativoBecas
            // 
            this.btRptAdministrativoBecas.Image = global::SACDumont.Properties.Resources.beca_educativa;
            this.btRptAdministrativoBecas.Name = "btRptAdministrativoBecas";
            this.btRptAdministrativoBecas.Size = new System.Drawing.Size(167, 22);
            this.btRptAdministrativoBecas.Text = "Becas";
            // 
            // btRptAdministrativoFacturas
            // 
            this.btRptAdministrativoFacturas.Image = global::SACDumont.Properties.Resources.facturacion;
            this.btRptAdministrativoFacturas.Name = "btRptAdministrativoFacturas";
            this.btRptAdministrativoFacturas.Size = new System.Drawing.Size(167, 22);
            this.btRptAdministrativoFacturas.Text = "Facturas";
            // 
            // btRptAdministrativoUniformes
            // 
            this.btRptAdministrativoUniformes.Image = global::SACDumont.Properties.Resources.camisa;
            this.btRptAdministrativoUniformes.Name = "btRptAdministrativoUniformes";
            this.btRptAdministrativoUniformes.Size = new System.Drawing.Size(167, 22);
            this.btRptAdministrativoUniformes.Text = "Uniformes";
            // 
            // btRptAdministrativoActividad
            // 
            this.btRptAdministrativoActividad.Image = global::SACDumont.Properties.Resources.lista_de_asistentes;
            this.btRptAdministrativoActividad.Name = "btRptAdministrativoActividad";
            this.btRptAdministrativoActividad.Size = new System.Drawing.Size(167, 22);
            this.btRptAdministrativoActividad.Text = "Actividad Usuario";
            // 
            // btConfiguracion
            // 
            this.btConfiguracion.Image = global::SACDumont.Properties.Resources.configuracion_del_documento;
            this.btConfiguracion.Name = "btConfiguracion";
            this.btConfiguracion.Size = new System.Drawing.Size(111, 20);
            this.btConfiguracion.Text = "Configuracion";
            // 
            // btCerarSesion
            // 
            this.btCerarSesion.Image = global::SACDumont.Properties.Resources.bloquear;
            this.btCerarSesion.Name = "btCerarSesion";
            this.btCerarSesion.Size = new System.Drawing.Size(104, 20);
            this.btCerarSesion.Text = "Cerrar Sesion";
            // 
            // btSalir
            // 
            this.btSalir.Image = global::SACDumont.Properties.Resources.apagar;
            this.btSalir.Name = "btSalir";
            this.btSalir.Size = new System.Drawing.Size(57, 20);
            this.btSalir.Text = "Salir";
            this.btSalir.Click += new System.EventHandler(this.btSalir_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tlUsuario});
            this.statusStrip1.Location = new System.Drawing.Point(0, 595);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(981, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(52, 17);
            this.toolStripStatusLabel1.Text = "Usuario:";
            // 
            // tlUsuario
            // 
            this.tlUsuario.Name = "tlUsuario";
            this.tlUsuario.Size = new System.Drawing.Size(57, 17);
            this.tlUsuario.Text = "lbUsuario";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 617);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "SAC Dumont";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btInscripcion;
        private System.Windows.Forms.ToolStripMenuItem btCobros;
        private System.Windows.Forms.ToolStripMenuItem btCatalogos;
        private System.Windows.Forms.ToolStripMenuItem btReportes;
        private System.Windows.Forms.ToolStripMenuItem btConfiguracion;
        private System.Windows.Forms.ToolStripMenuItem btCerarSesion;
        private System.Windows.Forms.ToolStripMenuItem btSalir;
        private System.Windows.Forms.ToolStripMenuItem btNuevoIngreso;
        private System.Windows.Forms.ToolStripMenuItem btReinscripcion;
        private System.Windows.Forms.ToolStripMenuItem btCobroColegiatura;
        private System.Windows.Forms.ToolStripMenuItem btCobroInscripcion;
        private System.Windows.Forms.ToolStripMenuItem btCobroProducts;
        private System.Windows.Forms.ToolStripMenuItem btCobroAbonos;
        private System.Windows.Forms.ToolStripMenuItem btCatalogosProducto;
        private System.Windows.Forms.ToolStripMenuItem btCatalogosAlumnos;
        private System.Windows.Forms.ToolStripMenuItem btCatalogosTutores;
        private System.Windows.Forms.ToolStripMenuItem btCatalogosUsuarios;
        private System.Windows.Forms.ToolStripMenuItem btReimpresionTickets;
        private System.Windows.Forms.ToolStripMenuItem btRptAcdemicos;
        private System.Windows.Forms.ToolStripMenuItem btRptAcdemicosAsistencia;
        private System.Windows.Forms.ToolStripMenuItem btRptAcdemicosCumple;
        private System.Windows.Forms.ToolStripMenuItem btRptAcdemicosAlumnos;
        private System.Windows.Forms.ToolStripMenuItem btRptAdministrativo;
        private System.Windows.Forms.ToolStripMenuItem btRptAdministrativoCorte;
        private System.Windows.Forms.ToolStripMenuItem btRptAdministrativoCorteDirio;
        private System.Windows.Forms.ToolStripMenuItem btRptAdministrativoCorteFecha;
        private System.Windows.Forms.ToolStripMenuItem btRptAdministrativoBecas;
        private System.Windows.Forms.ToolStripMenuItem btRptAdministrativoFacturas;
        private System.Windows.Forms.ToolStripMenuItem btRptAdministrativoUniformes;
        private System.Windows.Forms.ToolStripMenuItem btRptAdministrativoActividad;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tlUsuario;
    }
}

