using SACDumont.Controles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SACDumont.Base
{
    public partial class frmBaseConsulta : Form
    {
        protected virtual void Eliminar() { }
        protected virtual void Imprimir() { }
        protected virtual void Cerrar() { }
        protected virtual void ImprimirTicket() { }
        protected virtual void Busqueda() { }
        protected virtual void BusquedaCombo() { }

        public frmBaseConsulta()
        {
            InitializeComponent();
        }

        private void frmBaseConsulta_Load(object sender, EventArgs e)
        {

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void btTicketImpresora_Click(object sender, EventArgs e)
        {
            ImprimirTicket();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cerrar();
        }
    }
}
