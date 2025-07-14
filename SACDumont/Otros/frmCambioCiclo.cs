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
using SACDumont.Clases;
using SACDumont.modulos;
using SACDumont.Modulos;
using static SACDumont.Modulos.basConfiguracion;

namespace SACDumont.Otros
{
    public partial class frmCambioCiclo : frmBaseGeneral
    {
        DataTable dtCiclos = new DataTable();
        protected override void Guardar()
        {
            try
            {
                basConfiguracion.IdCiclo = int.Parse(cboCiclos.SelectedValue.ToString());
                basGlobals.iCiclo = int.Parse(cboCiclos.SelectedValue.ToString());
                basConfiguracion.InformacionHeader = "SAC - DUMONT || " + basConfiguracion.Nombre + " || Ciclo: " + cboCiclos.Text;
                MessageBox.Show("Cambio de ciclo exitoso.", "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public frmCambioCiclo()
        {
            InitializeComponent();
        }

        private void frmCambioCiclo_Load(object sender, EventArgs e)
        {
            dtCiclos = sqlServer.ExecSQLReturnDT("SELECT id_ciclo, ciclo FROM ciclos_escolares", "Ciclos");
            if (dtCiclos.Rows.Count == 0)
            {
                MessageBox.Show("No hay ciclos escolares disponibles.", "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            else
            {
                cboCiclos.DataSource = dtCiclos;
                cboCiclos.DisplayMember = "ciclo";
                cboCiclos.ValueMember = "id_ciclo";
                cboCiclos.SelectedIndex = -1;
            }
        }
    }
}
