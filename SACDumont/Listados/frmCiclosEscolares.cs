using SACDumont.Base;
using SACDumont.Dtos;
using SACDumont.Models;
using SACDumont.modulos;
using SACDumont.Modulos;
using SACDumont.Otros;
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
    public partial class frmCiclosEscolares : frmListados
    {
        #region Variables
        DataTable datatable = new DataTable();
        BindingSource bs = new BindingSource();
        int idCiclo = 0;
        Ciclos_Escolares Ciclos_Escolares = new Ciclos_Escolares();
        List<CiclosEscolaresDTO> ciclosEscolares = new List<CiclosEscolaresDTO>();
        #endregion

        #region Metodos Virtuales
        // Métodos virtuales que los hijos pueden sobreescribir
        protected override void Nuevo()
        {
            frmCrearCiclos frmNewCiclo = new frmCrearCiclos(0);
            frmNewCiclo.Text = "Nuevo Ciclo Escolar";
            frmNewCiclo.ShowDialog();
            CargarCiclos(); // Recargar la lista después de editar
        }
        protected override void Guardar()
        {
            // Implementar la lógica para guardar el registro de alumno
        }
        protected override void Eliminar()
        {
            // Implementar la lógica para eliminar el registro de alumno
            if (idCiclo == 0) return;

            using (var db = new DumontContext())
            {
                Ciclos_Escolares = db.CiclosEscolares.Find(idCiclo);
                if (MessageBox.Show($"Esta por eliminar el Ciclo Escolar:" + Environment.NewLine + Environment.NewLine + $"{Ciclos_Escolares.ciclo}" + Environment.NewLine + "¿Desea Continuar?", "Ciclos Escolares", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.CiclosEscolares.Remove(Ciclos_Escolares);
                    db.Entry(Ciclos_Escolares).State = System.Data.Entity.EntityState.Deleted;
                    var result = db.SaveChanges();
                    if (result == 1)
                    {
                        MessageBox.Show("Ciclo eliminado correctamente", "Ciclos Escolares", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarCiclos();
                    }
                }
            }

        }
        protected override void Imprimir()
        {
            // Implementar la lógica para imprimir el listado de alumnos
        }
        protected override void Cerrar()
        {
            this.Close();
        }

        #endregion

        #region Metodos Privados

        private void CargarMenu()
        {
            reporteToolStripMenuItem.Visible = false;
            guardarToolStripMenuItem.Visible = false;
        }

        private async void CargarCiclos()
        {
            Cursor.Current = Cursors.WaitCursor;
            pbSpinner.Visible = true;
            pbSpinner.BringToFront();

            using (var db = new DumontContext())
            {
                var datos = await Task.Run(() =>
                {
                    ciclosEscolares = db.CiclosEscolares
                   .Select(prc => new CiclosEscolaresDTO
                   {
                       IdCiclo = prc.id_ciclo,
                       Ciclo = prc.ciclo,
                       FechaInicio = prc.fecha_inicio,
                       FechaFin = prc.fecha_fin,
                   })
                   .ToList();

                    return ciclosEscolares;
                });

                datatable = basFunctions.ConvertToDataTable(datos);
                bs.DataSource = datatable;
                dgvCiclos.DataSource = bs;
                FormatoGrid();
                pbSpinner.Visible = false;
                Cursor.Current = Cursors.Default;
            }
        }

        private void FormatoGrid()
        {
            // Configurar el formato del DataGridView, si es necesario
            dgvCiclos.Columns["IdCiclo"].Visible = false; // Ocultar columna Id si no es necesaria
            dgvCiclos.Columns["Ciclo"].HeaderText = "Ciclo Escolar";
            dgvCiclos.Columns["FechaInicio"].HeaderText = "Fecha Inicio";
            dgvCiclos.Columns["FechaFin"].HeaderText = "Fecha Fin";
            dgvCiclos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarElementosBusqueda()
        {
            var ignorar = new[] { "IdCiclo", "FechaInicio", "FechaFin" };

            var propiedades = typeof(CiclosEscolaresDTO)
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

        public frmCiclosEscolares()
        {
            InitializeComponent();
        }

        private void frmCiclosEscolares_Load(object sender, EventArgs e)
        {
            CargarMenu();
            CargarElementosBusqueda();
            CargarCiclos();
        }

        private void frmCiclosEscolares_Resize(object sender, EventArgs e)
        {
            basFunctions.CenterSpinnerOverGrid(this, pbSpinner);
        }

        private void dgvCiclos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvCiclos.Rows.Count)
            {
                var cicloSeleccionado = dgvCiclos.Rows[e.RowIndex];
                frmCrearCiclos frmCrearCiclos = new frmCrearCiclos((int)cicloSeleccionado.Cells["IdCiclo"].Value);
                frmCrearCiclos.Text = $"Edicion de Ciclo: {(string)cicloSeleccionado.Cells["Ciclo"].Value}";
                frmCrearCiclos.ShowDialog();
                CargarCiclos(); // Recargar la lista después de editar
            }
        }

        private void dgvCiclos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < ciclosEscolares.Count)
            {
                var cicloSeleccionad = dgvCiclos.Rows[e.RowIndex];
                idCiclo = (int)cicloSeleccionad.Cells["IdCiclo"].Value;
            }
        }

        private void txBusqueda_TextChanged(object sender, EventArgs e)
        {
            string texto = txBusqueda.Text.ToLower();
            if (cboFiltros.SelectedItem == null) return;
            string campoSeleccionado = cboFiltros.SelectedItem.ToString();

            bs.Filter = $"{campoSeleccionado} LIKE '%{texto}%'";
        }
    }
}
