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
    public partial class frmListados : Form
    {

        // Métodos virtuales que los hijos pueden sobreescribir
        protected virtual void Nuevo() { }
        protected virtual void Guardar() { }
        protected virtual void Eliminar() { }
        protected virtual void Imprimir() { }


        public frmListados()
        {
            InitializeComponent();
        }

        private void frmListados_Load(object sender, EventArgs e)
        {

        }
    }
}
