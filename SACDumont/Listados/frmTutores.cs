using SACDumont.Base;
using SACDumont.Catalogos;
using SACDumont.Clases;
using SACDumont.Dtos;
using SACDumont.Models;
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

namespace SACDumont.Listados
{
    public partial class frmTutores : frmListados
    {
        #region Variables
        DataTable dtTutores = new DataTable("Tutores");
        List<TutoresDTO> listaTutores = new List<TutoresDTO>();
        BindingSource bs = new BindingSource();
        int idTutor = 0;
        #endregion
        protected override void Nuevo()
        {

        }
        protected override void Guardar()
        {
            // Implementar la lógica para guardar el registro de alumno
        }
        protected override void Eliminar()
        {
            // Implementar la lógica para eliminar el registro de alumno
        }
        protected override void Imprimir()
        {
            // Implementar la lógica para imprimir el listado de alumnos
        }
        protected override void Cerrar()
        {
            this.Close();
        }

        protected override void CargarComboFiltro()
        {
            if (cboFiltros.SelectedIndex >= 0)
            {
                cboBusqueda.Visible = false;
            }
        }

        protected override void Busqueda()
        {
            string texto = txBusqueda.Text.ToLower();
            if (cboFiltros.SelectedItem == null) return;
            string campoSeleccionado = cboFiltros.SelectedItem.ToString();

            bs.Filter = $"{campoSeleccionado} LIKE '%{texto}%'";
        }

        protected override void BusquedaCombo()
        {

        }

        public frmTutores()
        {
            InitializeComponent();
        }

        #region "Metodos"
        private void CargarTutores()
        {
            using (var db = new DumontContext())
            {
                listaTutores = db.Tutores.ToList().Select(t => new TutoresDTO
                {
                    IdTutor = t.id_tutor,
                    NombreCompleto = $"{t.appaterno} {t.apmaterno} {t.nombre}",
                    Telefono = t.telefono1,
                    FechaNacimiento = t.fecha_nacimiento,
                    Sexo = t.sexo.ToString() ?? ""
                }).ToList();
            }

            if (listaTutores.Count == 0)
            {
                MessageBox.Show("No se encontraron tutores registrados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dtTutores = basFunctions.ConvertToDataTable(listaTutores);
            bs.DataSource = dtTutores;
            dgvTutores.DataSource = bs;
            FormatGrid();
        }

        private void FormatGrid()
        {
            dgvTutores.Columns["IdTutor"].Visible = false;
            dgvTutores.Columns["NombreCompleto"].HeaderText = "Nombre Completo";
            dgvTutores.Columns["FechaNacimiento"].HeaderText = "Fecha Nacimiento";
            dgvTutores.Columns["Telefono"].HeaderText = "Telefono";
            dgvTutores.Columns["Sexo"].HeaderText = "Sexo";
        }

        private void CargarMenu()
        {
            guardarToolStripMenuItem.Visible = false;
            nuevoToolStripMenuItem.Visible = false;
            btTicketImpresora.Visible = false;
        }

        private void CargarElementosBusqueda()
        {
            var ignorar = new[] { "IdTutor", "Sexo", "Telefono", "FechaNacimiento" };

            var propiedades = typeof(TutoresDTO)
                 .GetProperties()
                 .Select(p => p.Name)
                 .Where(nombre => !ignorar.Contains(nombre))
                 .ToList();

            foreach (var item in propiedades)
            {
                cboFiltros.Items.Add(item.ToString());
            }
        }
        #endregion

        private void frmTutores_Load(object sender, EventArgs e)
        {
            CargarMenu();
            CargarTutores();
            CargarElementosBusqueda();
        }

        private void frmTutores_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void frmTutores_Activated(object sender, EventArgs e)
        {

        }

        private void dgvTutores_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvTutores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvTutores.Rows[e.RowIndex];

                // Suponiendo que la columna se llama "matricula"
                idTutor = int.Parse(fila.Cells["IdTutor"].Value?.ToString());

                // Abrimos el formulario y le pasamos la matrícula
                frmCatTutores frm = new frmCatTutores(0, idTutor);
                frm.ShowDialog();
                CargarTutores();
            }
        }
    }
}
