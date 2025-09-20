using SACDumont.Base;
using SACDumont.Modulos;
using System;
using System.Windows.Forms;

namespace SACDumont.Otros
{
    public partial class frmAcciones : frmListados
    {
        #region "Variables"

        int entidadId = 0;
        string modulo = string.Empty;
        basFunctions basFunctions = new basFunctions();

        #endregion

        #region "Metodos Virtuales"
        protected override void Nuevo()
        {
            // Implementar la lógica para crear una nueva acción
        }

        protected override void Guardar()
        {
            // Implementar la lógica para guardar la acción
        }

        protected override void Eliminar()
        {
            // Implementar la lógica para eliminar la acción
        }

        protected override void Imprimir()
        {
            // Implementar la lógica para imprimir la acción
        }

        protected override void Cerrar()
        {
            this.Close();
        }
        #endregion

        #region "Metodos"

        private void CargarAcciones()
        {
            nuevoToolStripMenuItem.Visible = false;
            guardarToolStripMenuItem.Visible = false;
            eliminarToolStripMenuItem.Visible = false;
            reporteToolStripMenuItem.Visible = false;
            tsSearch.Visible = false;
            btTicketImpresora.Visible = false;
        }

        private void FormatGrid()
        {
            dgvAcciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAcciones.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvAcciones.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }
        #endregion

        public frmAcciones(string modulo, int entidadId)
        {
            this.modulo = modulo;
            this.entidadId = entidadId;
            InitializeComponent();
        }

        private void frmAcciones_Load(object sender, EventArgs e)
        {
            CargarAcciones();
            basFunctions.CargarAcciones(ref dgvAcciones, modulo, entidadId);
            FormatGrid();
        }
    }
}
