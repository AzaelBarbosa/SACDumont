using SACDumont.Base;
using SACDumont.Modulos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SACDumont.Otros
{
    public partial class frmPopupFechas : frmBaseGeneral
    {
        protected override void Guardar()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public frmPopupFechas()
        {
            InitializeComponent();
        }

        private void frmPopupFechas_Load(object sender, EventArgs e)
        {
            guardarToolStripMenuItem.Text = "Imprimir";
        }
    }
}
