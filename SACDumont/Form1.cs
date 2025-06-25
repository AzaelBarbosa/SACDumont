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

namespace SACDumont
{
    public partial class frmMain : Form
    {
        basFunctions basFunctions = new basFunctions();
        basConfiguracion basConfig = new basConfiguracion();
        public frmMain(DataRow drUsuario)
        {
            // Esta llamada es requerida por el diseñador
            InitializeComponent();

            // Inicialización personalizada
            tlUsuario.Text = drUsuario["nombre_usuario"].ToString();
            basConfiguracion.InformacionHeader = "SAC - DUMONT || " + drUsuario["nombre_usuario"].ToString();
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
            basGlobals.sConcepto = Conceptos.PRODUCTO.ToString();
            AbrirUnicoFormularioHijo<frmMovimientos>();
        }

        private void btNuevoIngreso_Click(object sender, EventArgs e)
        {
            frmCatAlumnos frmCatAlumnos = new frmCatAlumnos(0);
            frmCatAlumnos.Text = "Nuevo Ingreso de Alumno";
            frmCatAlumnos.ShowDialog();
        }
    }
}
