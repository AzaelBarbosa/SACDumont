using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SACDumont.Listados;
using SACDumont.Otros;
using SACDumont.Clases;
using SACDumont.Modulos;
using SACDumont.modulos;
using SACDumont.Catalogos;
using SACDumont.Models;

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
            using (var db = new DumontContext())
            {
                permisosPerfiles = db.PermisosPerfiles.Where(pf => pf.id_perfil == idPerfil).FirstOrDefault();
                if (permisosPerfiles != null)
                {
                    btCatalogos.Visible = permisosPerfiles.catalogos;
                    btInscripcion.Visible = permisosPerfiles.inscripcion;
                    btCobros.Visible = permisosPerfiles.cobros;
                    btReportes.Visible = permisosPerfiles.reportes;
                    btConfiguracion.Visible = permisosPerfiles.configuracion;

                }
                else
                {
                    MessageBox.Show("El usuario no tiene permisos definido", "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Environment.Exit(0);
                }
            }
            basFunctions.AgregaImpresorasTickets(btPrinterTickets);
            basFunctions.AgregaImpresoras(btDefinirImpresora);
            DataTable dtConfig = sqlServer.ExecSQLReturnDT("SELECT * FROM config", "Config");
            DataTable dtCiclo = sqlServer.ExecSQLReturnDT("SELECT * FROM ciclos_escolares WHERE GETDATE() BETWEEN fecha_inicio AND fecha_fin", "Ciclos");

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
            frmPopup frmPopup = new frmPopup();
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
            decimal total = 0;
            cierre_diario cierre_Diario;
            if (MessageBox.Show("¿Desea realizar el cierre diario?", "Cierre Diario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (var db = new DumontContext())
                {
                    total = db.MovimientoCobros.Where(c => c.fechaAlta == DateTime.Today)
                        .Sum(c => (decimal?)c.monto) ?? 0;

                    cierre_Diario = new cierre_diario
                    {
                        fechacorte = DateTime.Today,
                        total = total,
                        fechaAlta = DateTime.Now,
                        idUsuario = basConfiguracion.UserID
                    };

                    db.CierreDiario.Add(cierre_Diario);
                    var result = db.SaveChanges();
                    if (result != 0)
                    {
                        MessageBox.Show("Cierre realizado con Exito", "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
