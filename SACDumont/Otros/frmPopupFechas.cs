using SACDumont.Base;
using SACDumont.Modulos;
using System;
using System.Windows.Forms;

namespace SACDumont.Otros
{
    public partial class frmPopupFechas : frmBaseGeneral
    {
        protected override void Guardar()
        {
            try
            {
                if (basFunctions.ValidaCierrePorFecha(dtFecha.Value))
                {
                    basFunctions.PreparaReporteCierreFecha(dtFecha.Value);
                }
                else
                {
                    MessageBox.Show($"No ah realizado el Corte del dia: {dtFecha.Value.ToShortDateString()}, no es posible realizar el reporte.", "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
