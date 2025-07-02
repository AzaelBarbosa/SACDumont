using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SACDumont.Base;
using SACDumont.Modulos;

namespace SACDumont.Otros
{
    public partial class frmPopup : frmBaseGeneral
    {
        // Variables de clase
        private DataSet dsTemp = new DataSet("Movimiento");

        protected override void Guardar()
        {
            try
            {
                if (cboGrupo.IDValor != 0)
                {
                    basFunctions.AlumnosExportarYMostrarPDF((int)cboGrupo.IDValor, (int)cboGrado.IDValor);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public frmPopup()
        {
            InitializeComponent();
        }

        private void frmPopup_Load(object sender, EventArgs e)
        {
            guardarToolStripMenuItem.Text = "Imprimir";
            cboGrado.Inicializar();
            cboGrupo.Inicializar();
        }
    }
}
