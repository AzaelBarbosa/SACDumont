using SACDumont.Modulos;
using System;
using System.Windows.Forms;

namespace SACDumont.Base
{
    public partial class frmBaseCatalogos : Form
    {

        // Métodos virtuales que los hijos pueden sobreescribir
        protected virtual void Nuevo() { }
        protected virtual void Guardar() { }
        protected virtual void Eliminar() { }
        protected virtual void AgregarTutor() { }
        protected virtual void Cerrar() { }
        protected virtual void Deshabilitar() { }
        protected virtual void Habilitar() { }
        protected virtual void QuitarRecargo() { }
        protected virtual void Acciones() { }
        protected virtual void ResetContrasena() { }
        public frmBaseCatalogos()
        {
            InitializeComponent();
        }

        private void frmBaseCatalogos_Load(object sender, EventArgs e)
        {
            btDelete.Visible = basConfiguracion.permisoUsuario.eliminar;
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void agregarTutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarTutor();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cerrar();
        }

        private void btDeshabilitar_Click(object sender, EventArgs e)
        {
            Deshabilitar();
        }

        private void btAcciones_Click(object sender, EventArgs e)
        {
            Acciones();
        }

        private void btQuitarRecargo_Click(object sender, EventArgs e)
        {
            QuitarRecargo();
        }

        private void btHabilitar_Click(object sender, EventArgs e)
        {
            Habilitar();
        }

        private void btResetPass_Click(object sender, EventArgs e)
        {
            ResetContrasena();
        }
    }
}
