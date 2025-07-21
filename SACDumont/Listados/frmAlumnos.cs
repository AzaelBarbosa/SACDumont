using SACDumont.Base;
using SACDumont.Catalogos;
using SACDumont.Clases;
using SACDumont.Dtos;
using SACDumont.Models;
using SACDumont.modulos;
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
    public partial class frmAlumnos : frmListados
    {
        DataTable dtAlumnos = new DataTable("Alumnos");
        BindingSource bs = new BindingSource();
        List<AlumnoDTO> listaAlumnos = new List<AlumnoDTO>();
        Alumnos alumnos = new Alumnos();
        List<Tutores_Alumnos> tutoresAlumnos = new List<Tutores_Alumnos>();
        int idAlumno = 0;
        protected override void Nuevo()
        {
            frmCatAlumnos frmCatAlumnos = new frmCatAlumnos(0);
            frmCatAlumnos.ShowDialog();
            CargarAlumnos();
        }
        protected override void Guardar()
        {
            // Implementar la lógica para guardar el registro de alumno
        }
        protected override void Eliminar()
        {
            using (var db = new DumontContext())
            {
                List<Movimientos> listaMov = db.Movimientos.Where(t => t.id_matricula == idAlumno).ToList();
                if (listaMov.Count > 0)
                {
                    MessageBox.Show("El Alumno que desea eliminar ya se tiene asignados uno o mas movimientos." + Environment.NewLine + "No es posible eliminar Al Alumno", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                alumnos = db.Alumnos.Find(idAlumno);
                tutoresAlumnos = db.TutoresAlumnos.Where(t => t.matricula == idAlumno).ToList();
                if (MessageBox.Show($"Esta por eliminar al Alumno:" + Environment.NewLine + Environment.NewLine + $"{alumnos.appaterno ?? ""} {alumnos.apmaterno ?? ""} {alumnos.nombre ?? ""}" + Environment.NewLine + "¿Desea Continuar?", "Alumnos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.Alumnos.Remove(alumnos);
                    db.Entry(alumnos).State = System.Data.Entity.EntityState.Deleted;
                    if (tutoresAlumnos.Count > 0)
                    {
                        db.TutoresAlumnos.RemoveRange(tutoresAlumnos);
                        db.Entry(tutoresAlumnos).State = System.Data.Entity.EntityState.Deleted;
                    }
                    var result = db.SaveChanges();
                    if (result == 1)
                    {
                        MessageBox.Show("Alumno eliminado correctamente.", "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarAlumnos();
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

        protected override void CargarComboFiltro()
        {
            if (cboFiltros.SelectedIndex >= 0)
            {
                string selectedFilter = cboFiltros.SelectedItem.ToString();
                if (selectedFilter == "Activo")
                {
                    txBusqueda.Visible = false;
                    cboBusqueda.Visible = true;
                    cboBusqueda.Items.Clear();
                    cboBusqueda.Items.Add("Todos");
                    cboBusqueda.Items.Add("Activos");
                    cboBusqueda.Items.Add("Inactivos");
                    cboBusqueda.SelectedIndex = -1; // Seleccionar el primer elemento por defecto
                }
                else
                {
                    txBusqueda.Visible = true;
                    cboBusqueda.Visible = false;
                }
            }
            else
            {
                txBusqueda.Visible = false;
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
            string campoSeleccionado = cboFiltros.SelectedItem.ToString();
            if (campoSeleccionado == "Todos")
            {
                bs.Filter = "";
                return;
            }
            if (campoSeleccionado == "Activo")
            {
                if (cboBusqueda.SelectedItem.ToString() == "Todos")
                {
                    bs.Filter = "";
                    return;
                }

                bool valor = cboBusqueda.SelectedItem.ToString() == "Activo" ? true : false;

                bs.Filter = $"{campoSeleccionado} = {valor}";
            }
        }

        public frmAlumnos()
        {
            InitializeComponent();
        }

        private void frmAlumnos_Load(object sender, EventArgs e)
        {
            CargarMenu();
            CargarElementosBusqueda();
            CargarAlumnos();
        }

        private void frmAlumnos_Activated(object sender, EventArgs e)
        {

        }

        private void frmAlumnos_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void dgvAlumnos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvAlumnos.Rows[e.RowIndex];

                // Suponiendo que la columna se llama "matricula"
                int matricula = int.Parse(fila.Cells["Matricula"].Value?.ToString());

                // Abrimos el formulario y le pasamos la matrícula
                frmCatAlumnos frm = new frmCatAlumnos(matricula);
                frm.ShowDialog();
                CargarAlumnos();
            }
        }

        private async void CargarAlumnos()
        {
            Cursor.Current = Cursors.WaitCursor;
            pbSpinner.Visible = true;
            pbSpinner.BringToFront();

            using (var db = new DumontContext())
            {

                listaAlumnos = await Task.Run(() =>
                {
                    var lista = db.Alumnos.ToList().Select(a => new AlumnoDTO
                    {
                        Matricula = a.matricula,
                        NombreCompleto = $"{a.appaterno} {a.apmaterno} {a.nombre}",
                        FechaNacimiento = a.fecha_nacimiento,
                        Sexo = a.sexo,
                        Telefono1 = a.telefono1,
                        Telefono2 = a.telefono2,
                        CorreoElectronico = a.email,
                        Activo = a.activo
                    }).OrderByDescending(a => a.Activo).ThenBy(a => a.NombreCompleto).ToList();

                    return lista;
                });
            }

            dtAlumnos = basFunctions.ConvertToDataTable(listaAlumnos);
            bs.DataSource = dtAlumnos;
            dgvAlumnos.DataSource = bs;
            FormatGrid();
            pbSpinner.Visible = false;
        }

        private void FormatGrid()
        {
            dgvAlumnos.Columns["Matricula"].HeaderText = "Matrícula";
            dgvAlumnos.Columns["NombreCompleto"].HeaderText = "Nombre Completo";
            dgvAlumnos.Columns["FechaNacimiento"].HeaderText = "Fecha Nacimiento";
            dgvAlumnos.Columns["Sexo"].HeaderText = "Sexo";
            dgvAlumnos.Columns["Telefono1"].HeaderText = "Teléfono 1";
            dgvAlumnos.Columns["Telefono2"].HeaderText = "Teléfono 2";
            dgvAlumnos.Columns["CorreoElectronico"].HeaderText = "Correo Electrónico";
            dgvAlumnos.Columns["Activo"].HeaderText = "Activo";
            dgvAlumnos.Columns["Grado"].Visible = false;
            dgvAlumnos.Columns["Grupo"].Visible = false; // Si no se usa, ocultar estas columnas
        }

        private void CargarElementosBusqueda()
        {
            var ignorar = new[] { "Telefono1", "Telefono2", "CorreoElectronico", "Sexo", "FechaNacimiento" };

            var propiedades = typeof(AlumnoDTO)
                 .GetProperties()
                 .Select(p => p.Name)
                 .Where(nombre => !ignorar.Contains(nombre))
                 .ToList();

            foreach (var item in propiedades)
            {
                cboFiltros.Items.Add(item.ToString());
            }
        }

        private void CargarMenu()
        {
            guardarToolStripMenuItem.Visible = false;
            reporteToolStripMenuItem.Visible = false;
        }

        private void dgvAlumnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvAlumnos.Rows[e.RowIndex];
                idAlumno = int.Parse(fila.Cells["Matricula"].Value?.ToString());
            }
        }
    }
}
