using System;
using System.Windows.Forms;

namespace SACDumont.Base
{
    public partial class frmBaseGeneral : Form
    {

        // Métodos virtuales que los hijos pueden sobreescribir
        protected virtual void Nuevo() { }
        protected virtual void Guardar() { }
        protected virtual void Eliminar() { }

        public frmBaseGeneral()
        {
            InitializeComponent();
        }

        private void frmBaseGeneral_Load(object sender, EventArgs e)
        {

        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Guardar();
        }
    }
}
