using FastReport.Utils;
using SACDumont.Catalogos;
using SACDumont.Clases;
using SACDumont.Listados;
using SACDumont.Models;
using SACDumont.modulos;
using SACDumont.Modulos;
using SACDumont.Otros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SACDumont.Modulos.basConfiguracion;

namespace SACDumont
{
    public partial class frmMain : Form
    {
        basFunctions basFunctions = new basFunctions();
        basConfiguracion basConfig = new basConfiguracion();
        permisos_perfiles permisosPerfiles = new permisos_perfiles();
        int idPerfil = 0;
        private frmLogin loginForm;
        DateTime fechaCierre = DateTime.Now;
        public DateTime fechaCorte = DateTime.Now;
        public frmMain(DataRow drUsuario, frmLogin frm)
        {
            // Esta llamada es requerida por el diseñador
            InitializeComponent();

            // Inicialización personalizada
            tlUsuario.Text = drUsuario["nombre_usuario"].ToString();
            idPerfil = (int)drUsuario["id_perfil"];
            fechaCierre = basFunctions.RevisarFechaCierre();
            basConfiguracion.InformacionHeader = $"SAC - DUMONT || Usuario: {drUsuario["nombre_usuario"].ToString()} || Fecha Ultimo Cierre: {fechaCierre.ToShortDateString()}";
            this.loginForm = frm;
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }



        public void AbrirFormularioHijo<T>() where T : Form, new()
        {
            // Verifica si ya está abierto
            Form formExistente = this.MdiChildren.FirstOrDefault(f => f is T);

            if (formExistente != null)
            {
                formExistente.Activate();
            }
            else
            {
                T nuevoFormulario = new T
                {
                    MdiParent = this,
                    WindowState = FormWindowState.Maximized
                };
                nuevoFormulario.Show();
            }
        }

        private void PreparaReporteCierre(DateTime fecha)
        {
            try
            {


                DataTable dtResumen = new DataTable("Resumen");
                DataTable dtBilletes = new DataTable("Billetes"); ;
                DataTable dtDetalle = new DataTable("Detalle"); ;

                using (var db = new DumontContext())
                {
                    var resumen = (from m in db.Movimientos
                                   join c in db.MovimientoCobros on m.id_movimiento equals c.id_movimiento into cobrosGroup
                                   from c in cobrosGroup.DefaultIfEmpty()
                                   join cat in db.Catalogos on new { valor = (int?)c.tipopago, tipo_catalogo = "TipoPago" }
                                                              equals new { valor = (int?)cat.valor, cat.tipo_catalogo } into catalogosGroup
                                   from cat in catalogosGroup.DefaultIfEmpty()
                                   where DbFunctions.TruncateTime(m.fechahora) == DbFunctions.TruncateTime(fecha)
                                   group c by cat.descripcion into g
                                   select new
                                   {
                                       Tipo = g.Key,
                                       Monto = g.Sum(x => x != null ? x.monto : 0)
                                   }).ToList();

                    var billetes = db.CierreDiario
                                     .Where(cd => DbFunctions.TruncateTime(cd.fechacorte) == DbFunctions.TruncateTime(fecha))
                                     .Select(cd => new
                                     {
                                         cd.B1000,
                                         cd.B500,
                                         cd.B200,
                                         cd.B100,
                                         cd.B50,
                                         cd.B20,
                                         cd.M10,
                                         cd.M5,
                                         cd.M2,
                                         cd.M1,
                                         cd.M050
                                     })
                                     .ToList();

                    var detalles = (from m in db.Movimientos
                                    join mp in db.MovimientoProductos on m.id_movimiento equals mp.id_movimiento into mpGroup
                                    from mp in mpGroup.DefaultIfEmpty()

                                    join p in db.Productos on mp.id_producto equals p.id_producto into pGroup
                                    from p in pGroup.DefaultIfEmpty()

                                    join c in db.MovimientoCobros on m.id_movimiento equals c.id_movimiento into cGroup
                                    from c in cGroup.DefaultIfEmpty()

                                    join a in db.Alumnos on m.id_matricula equals a.matricula into aGroup
                                    from a in aGroup.DefaultIfEmpty()

                                    where DbFunctions.TruncateTime(m.fechahora) == DbFunctions.TruncateTime(fecha)

                                    group new { c, mp, p, a } by new
                                    {
                                        Alumno = (a.appaterno ?? "") + " " + (a.apmaterno ?? "") + " " + (a.nombre ?? ""),
                                        Concepto = p.concepto,
                                        MotivoGasto = mp.descripcion,
                                        Monto = c.monto,
                                        Folio = m.id_movimiento
                                    } into g

                                    select new
                                    {
                                        Alumno = (g.Key.Alumno == null || g.Key.Alumno.Trim() == "") ? "GASTO" : g.Key.Alumno,
                                        Concepto = g.Key.Concepto,
                                        MotivoGasto = g.Key.MotivoGasto ?? "",
                                        Monto = g.Key.Monto,
                                        Folio = g.Key.Folio
                                    }).ToList();

                    dtResumen = basFunctions.ConvertToDataTable(resumen);
                    dtDetalle = basFunctions.ConvertToDataTable(detalles);
                    dtBilletes = basFunctions.ConvertToDataTable(billetes);

                    basFunctions.ExportarYMostrarPDF3DT("CierreDiario.frx", dtResumen, dtDetalle, dtBilletes, "Resumen", "Detalle", "Billetes");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void AbrirUnicoFormularioHijo<T>() where T : Form, new()
        {
            // Cierra todos los formularios MDI hijos abiertos
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }

            // Abre el nuevo formulario hijo
            T nuevoFormulario = new T
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };

            nuevoFormulario.Show();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            if (basConfiguracion.permisoUsuario != null)
            {
                btCatalogos.Visible = basConfiguracion.permisoUsuario.catalogos;
                btInscripcion.Visible = basConfiguracion.permisoUsuario.inscripcion;
                btCobros.Visible = basConfiguracion.permisoUsuario.cobros;
                btReportes.Visible = basConfiguracion.permisoUsuario.reportes;
                btConfiguracion.Visible = basConfiguracion.permisoUsuario.configuracion;
                btGastos.Visible = basConfiguracion.permisoUsuario.gastos;
                btCorteDiario.Visible = basConfiguracion.permisoUsuario.cortediario;
                btCatalogosAlumnos.Visible = basConfiguracion.permisoUsuario.cat_alumnos;
                btCatalogosUsuarios.Visible = basConfiguracion.permisoUsuario.cat_usuarios;
                btCatalogosProducto.Visible = basConfiguracion.permisoUsuario.cat_productos;
                btPromociones.Visible = basConfiguracion.permisoUsuario.cat_promociones;
                btCatalogosTutores.Visible = basConfiguracion.permisoUsuario.cat_tutores;
                btGeneral.Visible = basConfiguracion.permisoUsuario.con_general;
                btCiclosEscolares.Visible = basConfiguracion.permisoUsuario.con_ciclos;
                btTransferir.Visible = basConfiguracion.permisoUsuario.con_transferir;
            }
            else
            {
                MessageBox.Show("El usuario no tiene permisos definido", "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(0);
            }

            basFunctions.AgregaImpresorasTickets(btPrinterTickets);
            basFunctions.AgregaImpresoras(btDefinirImpresora);

            ConfigInfo config = basConfiguracion.LeerConfig(@"C:\SAC\configSecure.dll");

            using (var db = new DumontContext())
            {
                var systemConfig = db.Config.Where(c => c.id == 1).FirstOrDefault();
                basConfiguracion.Config = new Dtos.ConfigDTO
                {
                    PreEscolarClave = systemConfig.preescolar_clave,
                    PreEscolarSEP = systemConfig.preescolar_sep,
                    PrimariaClave = systemConfig.primaria_clave,
                    PrimariaSEP = systemConfig.primaria_sep,
                    SecundariaClave = systemConfig.secundaria_clave,
                    SecundariaSEP = systemConfig.secundaria_sep,
                    MaternalClave = systemConfig.maternal_clave,
                    MaternalSEP = systemConfig.maternal_sep,
                    Equipo = config.Equipo
                };

                var printers = db.ConfigEquipos.Where(ce => ce.equipo == basConfiguracion.Config.Equipo).FirstOrDefault();
                basConfiguracion.PrinterTiockets = printers.impresora_tickets;
                basConfiguracion.Printer = printers.impresora_general;

                foreach (ToolStripMenuItem item in btPrinterTickets.DropDownItems)
                {
                    // Quitar check de todos
                    item.Checked = false;

                    // Marcar solo el que coincide con el nombre guardado
                    if (item.Text.Equals(printers.impresora_tickets, StringComparison.OrdinalIgnoreCase))
                    {
                        item.Checked = true;
                    }
                }

                foreach (ToolStripMenuItem item in btDefinirImpresora.DropDownItems)
                {
                    // Quitar check de todos
                    item.Checked = false;

                    // Marcar solo el que coincide con el nombre guardado
                    if (item.Text.Equals(printers.impresora_general, StringComparison.OrdinalIgnoreCase))
                    {
                        item.Checked = true;
                    }
                }
            }

            DataTable dtConfig = sqlServer.ExecSQLReturnDT("SELECT * FROM config", "Config");
            DataTable dtCiclo = sqlServer.ExecSQLReturnDT("SELECT * FROM ciclos_escolares WHERE CAST(GETDATE() AS DATE) BETWEEN fecha_inicio AND fecha_fin", "Ciclos");

            if (!basFunctions.DataVacio(dtConfig))
            {
                basConfig.SetConfig(int.Parse(dtCiclo.Rows[0]["id_ciclo"].ToString()), bool.Parse(dtConfig.Rows[0]["aplicar_recargos"].ToString()), bool.Parse(dtConfig.Rows[0]["aplicar_promociones"].ToString()), int.Parse(dtConfig.Rows[0]["porcentaje_recargo"].ToString()), int.Parse(dtConfig.Rows[0]["dias_tolerancia"].ToString()));
                basConfiguracion.InformacionHeader = basConfiguracion.InformacionHeader + " || Ciclo Escolar: " + dtCiclo.Rows[0]["ciclo"].ToString();
            }
        }

        private void btCatalogosAlumnos_Click(object sender, EventArgs e)
        {
            AbrirUnicoFormularioHijo<frmAlumnos>();
        }

        private void btCatalogosTutores_Click(object sender, EventArgs e)
        {
            AbrirUnicoFormularioHijo<frmTutores>();
        }

        private void btConfiguracion_Click(object sender, EventArgs e)
        {

        }

        private void btCatalogosProducto_Click(object sender, EventArgs e)
        {
            AbrirUnicoFormularioHijo<frmProductos>();
        }

        private void generalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfig frmConfig = new frmConfig();
            frmConfig.Text = "Configuración General";
            frmConfig.ShowDialog();
        }

        private void cambiarCicloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCambioCiclo frmCambiarCiclo = new frmCambioCiclo();
            frmCambiarCiclo.Text = "Cambio de Ciclo Escolar";
            frmCambiarCiclo.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = basConfiguracion.InformacionHeader;
        }

        private void btCobroColegiatura_Click(object sender, EventArgs e)
        {
            basGlobals.tipoMovimiento = (int)TipoMovimiento.Colegiatura;
            basGlobals.sConcepto = Conceptos.COLEGIATURA.ToString();
            AbrirUnicoFormularioHijo<frmMovimientos>();
        }

        private void btCobroInscripcion_Click(object sender, EventArgs e)
        {
            basGlobals.tipoMovimiento = (int)TipoMovimiento.Inscripcion;
            basGlobals.sConcepto = Conceptos.INSCRIPCION.ToString();
            AbrirUnicoFormularioHijo<frmMovimientos>();
        }

        private void btCobroProducts_Click(object sender, EventArgs e)
        {
            basGlobals.tipoMovimiento = (int)TipoMovimiento.Producto;
            basGlobals.sConcepto = Conceptos.ARTICULO.ToString();
            AbrirUnicoFormularioHijo<frmMovimientos>();
        }

        private void btNuevoIngreso_Click(object sender, EventArgs e)
        {
            frmCatAlumnos frmCatAlumnos = new frmCatAlumnos(0);
            frmCatAlumnos.Text = "Nuevo Ingreso de Alumno";
            frmCatAlumnos.ShowDialog();
        }

        private void promocionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirUnicoFormularioHijo<frmPromociones>();
        }

        private void btCatalogosUsuarios_Click(object sender, EventArgs e)
        {
            AbrirUnicoFormularioHijo<frmUsuarios>();
        }

        private void btReinscripcion_Click(object sender, EventArgs e)
        {
            frmReinscripcion frmReinscripcion = new frmReinscripcion();
            frmReinscripcion.Text = "Reinscrpcion de Alumno";
            frmReinscripcion.ShowDialog();
        }

        private void btRptAcdemicosAlumnos_Click(object sender, EventArgs e)
        {
            frmPopup frmPopup = new frmPopup("ListaAlumno");
            frmPopup.Text = "Reporte Listado de Alumnos";
            frmPopup.ShowDialog();
        }

        private void ciclosEscolaresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirUnicoFormularioHijo<frmCiclosEscolares>();
        }

        private void uniformesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            basGlobals.tipoMovimiento = (int)TipoMovimiento.Uniformes;
            basGlobals.sConcepto = Conceptos.UNIFORMES.ToString();
            AbrirUnicoFormularioHijo<frmMovimientos>();
        }

        private void eventosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            basGlobals.tipoMovimiento = (int)TipoMovimiento.Eventos;
            basGlobals.sConcepto = Conceptos.EVENTOS.ToString();
            AbrirUnicoFormularioHijo<frmMovimientos>();
        }

        private void graduacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            basGlobals.tipoMovimiento = (int)TipoMovimiento.Graduacion;
            basGlobals.sConcepto = Conceptos.GRADUACION.ToString();
            AbrirUnicoFormularioHijo<frmMovimientos>();
        }

        private void trasnferirAlumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTransferenciaAlumnos frmPopup = new frmTransferenciaAlumnos();
            frmPopup.Text = "Trasnferencia de Alumnos";
            frmPopup.ShowDialog();
        }

        private void btCerarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
            loginForm.txPassword.Text = "";
            loginForm.Show();
        }

        private void btCorteDiario_Click(object sender, EventArgs e)
        {
            if (basFunctions.ValidaCierre())
            {
                MessageBox.Show("Ya se ah realizado el cierre del dia de hoy.", "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Desea realizar el cierre diario?", "Cierre Diario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                frmCierreConfirmar frmCierre = new frmCierreConfirmar();
                frmCierre.ShowDialog();
            }
        }

        private void btGastos_Click(object sender, EventArgs e)
        {
            basGlobals.tipoMovimiento = (int)TipoMovimiento.Gasto;
            basGlobals.sConcepto = Conceptos.GASTOS.ToString();
            AbrirUnicoFormularioHijo<frmMovimientos>();
        }

        private void btRptAdministrativoCorteDirio_Click(object sender, EventArgs e)
        {
            if (basFunctions.ValidaCierre())
            {
                PreparaReporteCierre(DateTime.Now);
            }
            else
            {
                MessageBox.Show($"No ah realizado el Corte del dia: {DateTime.Now.ToShortDateString()}, no es posible realizar el reporte.", "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btRptAcdemicosAsistencia_Click(object sender, EventArgs e)
        {
            frmPopup frmPopup = new frmPopup("ListaAsistencia");
            frmPopup.Text = "Reporte Asistencia de Alumnos";
            frmPopup.ShowDialog();
        }

        private void btRptAdministrativoCorteFecha_Click(object sender, EventArgs e)
        {
            frmPopupFechas frmFehas = new frmPopupFechas();
            frmFehas.Text = "Corte Diario por Fecha";
            frmFehas.ShowDialog();
        }
    }
}
