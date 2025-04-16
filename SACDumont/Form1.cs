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

namespace SACDumont
{
    public partial class frmMain: Form
    {
        public frmMain(DataRow drUsuario)
        {
            // Esta llamada es requerida por el diseñador
            InitializeComponent();

            // Inicialización personalizada
            tlUsuario.Text = drUsuario["nombre_usuario"].ToString();
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

        }

        private void btCatalogosAlumnos_Click(object sender, EventArgs e)
        {
            AbrirUnicoFormularioHijo<frmAlumnos>();
        }

        private void btCatalogosTutores_Click(object sender, EventArgs e)
        {
            AbrirUnicoFormularioHijo<frmTutores>();
        }
    }
}
