using SACDumont.Base;
using SACDumont.Dtos;
using SACDumont.Models;
using SACDumont.Modulos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SACDumont.Otros
{
    public partial class frmTransferenciaAlumnos : frmBaseGeneral
    {
        #region Variables
        List<AlumnoSACDTO> listaAlumnoSAC = new List<AlumnoSACDTO>();
        List<Alumnos> transferAlumnoSAC = new List<Alumnos>();
        Alumnos alumnos = new Alumnos();
        DataTable dtAlumnos = new DataTable();
        List<DataRow> filasSeleccionadas = new List<DataRow>();
        BindingSource bs = new BindingSource();
        int alAgregados = 0;
        int alExistentes = 0;
        #endregion

        #region Metodos Virtuales
        protected override void Guardar()
        {
            try
            {
                if (MessageBox.Show("¿Está seguro de transferir los alumnos seleccionados al sistema SAC?", "SAC-Dumont", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return; // Si el usuario cancela, no hacer nada
                }

                dgvAlumn.EndEdit();
                dgvAlumn.Size = new Size(509, 365); // Ajustar el tamaño del DataGridView
                lbAgregados.Items.Clear(); // Limpiar el ListBox de agregados

                RevisarFilas();
                using (var db = new DumontContext())
                {
                    foreach (var fila in filasSeleccionadas)
                    {
                        // Obtener la matrícula del DataRow
                        string matricula = fila["Matriula"].ToString();
                        string nombre = fila["nombre"].ToString().ToUpper();
                        string appaterno = fila["appaterno"].ToString().ToUpper();
                        string apmaterno = fila["apmaterno"].ToString().ToUpper();

                        var existente = db.Alumnos.FirstOrDefault(a => a.appaterno.ToUpper() == appaterno && a.apmaterno.ToUpper() == apmaterno && a.nombre.ToUpper() == nombre);
                        // Buscar el alumno en la lista de alumnos
                        if (existente == null)
                        {
                            // Crear un nuevo objeto ALUMNOS para la transferencia
                            Alumnos nuevoAlumno = new Alumnos
                            {
                                matricula = (int)fila["Matriula"],
                                appaterno = fila["appaterno"].ToString().ToUpper(),
                                apmaterno = fila["apmaterno"].ToString().ToUpper(),
                                nombre = fila["nombre"].ToString().ToUpper(),
                                curp = fila["curp"].ToString(),
                                telefono1 = fila["telefono1"].ToString(),
                                telefono2 = fila["telefono2"].ToString(),
                                email = fila["email"].ToString(),
                                activo = true, // Asignar activo como true
                                fecha_alta = DateTime.Now, // Asignar fecha actual
                                fecha_nacimiento = DateTime.Now, // Asignar fecha de nacimiento actual (puedes cambiar esto si tienes la fecha de nacimiento real)
                            };
                            // Agregar el nuevo alumno a la lista de transferencias
                            transferAlumnoSAC.Add(nuevoAlumno);
                            lbAgregados.Items.Add($"Alumno {appaterno} {apmaterno} {nombre} transferido correctamente.");
                            alAgregados++;
                        }
                        else
                        {
                            // Si el alumno ya existe, incrementar el contador
                            alExistentes++;
                            lbAgregados.Items.Add($"El alumno {appaterno} {apmaterno} {nombre} ya existe en la base de datos. No se transferirá.");
                        }
                    }
                    // Guardar los cambios en la base de datos
                    db.Alumnos.AddRange(transferAlumnoSAC);
                    var result = db.SaveChanges();
                    if (result > 0)
                    {
                        lbAgregados.Items.Add($"Total de alumnos transferidos: {alAgregados}");
                        lbAgregados.Items.Add($"Total de alumnos existentes: {alExistentes}");
                        guardarToolStripMenuItem.Enabled = false; // Deshabilitar el botón de guardar después de la transferencia
                        lbAgregados.Refresh();
                    }
                    else
                    {
                        lbAgregados.Items.Add($"Total de alumnos transferidos: {alAgregados}");
                        lbAgregados.Items.Add($"Total de alumnos existentes: {alExistentes}");
                        guardarToolStripMenuItem.Enabled = false; // Deshabilitar el botón de guardar después de la transferencia
                        lbAgregados.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion

        #region Metodos Privados

        private async void CargarDatosAlumnos()
        {
            try
            {
                pbSpinner.Visible = true;
                pbSpinner.BringToFront();

                using (var dbSAC = new SACContext())
                {
                    listaAlumnoSAC = await Task.Run(() =>
                    {
                        var lista = dbSAC.Alumnos
                        .Where(a => a.activo == true && a.dia != null).ToList().Where(a => !string.IsNullOrWhiteSpace(a.nombre)).Select(a => new AlumnoSACDTO
                        {
                            Matriula = a.matri,
                            nombreCompleto = $"{a.appat} {a.apmat} {a.nombre}",
                            appaterno = a.appat,
                            apmaterno = a.apmat,
                            nombre = a.nombre,
                            curp = a.curp,
                            telefono1 = a.telcel,
                            telefono2 = a.telcasa,
                            email = a.email,
                            activo = (bool)a.activo,
                        })
                        .OrderBy(a => a.nombreCompleto)
                        .ToList();

                        return lista;
                    });

                    if (listaAlumnoSAC.Count == 0)
                    {
                        MessageBox.Show("No hay alumnos activos en el ciclo seleccionado.", "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    // Aquí puedes cargar los datos en un control, por ejemplo un DataGridView
                    dtAlumnos = basFunctions.ConvertToDataTable(listaAlumnoSAC);
                    bs.DataSource = dtAlumnos;
                    dgvAlumn.DataSource = bs;
                    FormatGrit();
                    pbSpinner.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FormatGrit()
        {
            dgvAlumn.Columns["Matriula"].Visible = false; // Ocultar columna Matricula si no es necesaria
            dgvAlumn.Columns["nombreCompleto"].HeaderText = "Nombre Completo";
            dgvAlumn.Columns["nombreCompleto"].ReadOnly = true;
            dgvAlumn.Columns["appaterno"].Visible = false;
            dgvAlumn.Columns["apmaterno"].Visible = false;
            dgvAlumn.Columns["nombre"].Visible = false;
            dgvAlumn.Columns["curp"].Visible = false;
            dgvAlumn.Columns["telefono1"].HeaderText = "Teléfono 1";
            dgvAlumn.Columns["telefono1"].ReadOnly = true;
            dgvAlumn.Columns["telefono2"].Visible = false;
            dgvAlumn.Columns["email"].Visible = false;
            dgvAlumn.Columns["calle"].Visible = false;
            dgvAlumn.Columns["colonia"].Visible = false;
            dgvAlumn.Columns["ciudad"].Visible = false;
            dgvAlumn.Columns["fechaalta"].Visible = false;
            dgvAlumn.Columns["FechaNacimiento"].Visible = false;
            dgvAlumn.Columns["activo"].Visible = false;

            // Ajustar el ancho de las columnas
            foreach (DataGridViewColumn column in dgvAlumn.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        private DateTime ConvertirFecha(int day, string mont, int year)
        {
            var cultura = new System.Globalization.CultureInfo("es-ES");
            // Convertir el mes de texto a número
            int month = DateTime.ParseExact(mont, "MMMM", cultura).Month;
            // Crear la fecha
            DateTime fecha = new DateTime(year, month, day);

            return fecha;
        }
        private void RevisarFilas()
        {
            filasSeleccionadas.Clear();
            foreach (DataGridViewRow row in dgvAlumn.Rows)
            {
                // Evitar filas nuevas sin datos
                if (!row.IsNewRow)
                {
                    var cellValue = row.Cells[0].Value;
                    bool seleccionado = cellValue != null && (bool)cellValue;

                    if (seleccionado)
                    {
                        // Obtener la DataRow original desde el DataBoundItem
                        var dataRowView = row.DataBoundItem as DataRowView;
                        if (dataRowView != null)
                        {
                            filasSeleccionadas.Add(dataRowView.Row);
                        }
                    }
                }
            }
        }
        #endregion


        #region Eventos Formulario
        public frmTransferenciaAlumnos()
        {
            InitializeComponent();
        }

        private void frmTransferenciaAlumnos_Load(object sender, EventArgs e)
        {
            CargarDatosAlumnos();
        }

        #endregion

        private void txBusqueda_TextChanged(object sender, EventArgs e)
        {
            string texto = txBusqueda.Text.ToLower();

            bs.Filter = $"nombreCompleto LIKE '%{texto}%'";
        }

        private void frmTransferenciaAlumnos_Resize(object sender, EventArgs e)
        {
            basFunctions.CenterSpinnerOverGrid(this, pbSpinner);
        }
    }
}
