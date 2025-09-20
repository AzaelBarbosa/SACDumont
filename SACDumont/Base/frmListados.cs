using SACDumont.Modulos;
using System;
using System.Windows.Forms;

namespace SACDumont.Base
{
    public partial class frmListados : Form
    {

        // Métodos virtuales que los hijos pueden sobreescribir
        protected virtual void Nuevo() { }
        protected virtual void Guardar() { }
        protected virtual void Eliminar() { }
        protected virtual void Imprimir() { }
        protected virtual void Cerrar() { }
        protected virtual void ImprimirTicket() { }
        protected virtual void CargarComboFiltro() { }

        protected virtual void Busqueda() { }

        protected virtual void BusquedaCombo() { }

        public frmListados()
        {
            InitializeComponent();
        }

        private void frmListados_Load(object sender, EventArgs e)
        {
            eliminarToolStripMenuItem.Visible = basConfiguracion.permisoUsuario.eliminar;
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cerrar();
        }

        private void cboFiltros_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboFiltro();
        }

        private void txBusqueda_TextChanged(object sender, EventArgs e)
        {
            Busqueda();
        }

        private void cboBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            BusquedaCombo();
        }

        private void frmListados_Resize(object sender, EventArgs e)
        {
            basFunctions.CenterSpinnerOverGrid(this, pbSpinner);
        }

        private void btTicketImpresora_Click(object sender, EventArgs e)
        {
            ImprimirTicket();
        }
    }
}
