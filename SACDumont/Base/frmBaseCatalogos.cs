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
    public partial class frmBaseCatalogos : Form
    {

        // Métodos virtuales que los hijos pueden sobreescribir
        protected virtual void Nuevo() { }
        protected virtual void Guardar() { }
        protected virtual void Eliminar() { }

        public frmBaseCatalogos()
        {
            InitializeComponent();
        }

        private void frmBaseCatalogos_Load(object sender, EventArgs e)
        {

        }
    }
}
