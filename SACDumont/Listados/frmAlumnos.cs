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
using SACDumont.Catalogos;
using SACDumont.Clases;

namespace SACDumont.Listados
{
    public partial class frmAlumnos : frmListados
    {
        DataTable dtAlumnos = new DataTable("Alumnos");

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
        public frmAlumnos()
        {
            InitializeComponent();
        }

        private void frmAlumnos_Load(object sender, EventArgs e)
        {
            CargarMenu();
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

        private void CargarAlumnos()
        {
            dtAlumnos = sqlServer.ExecSQLReturnDT("SELECT a.matricula AS Matricula, a.appaterno + ' ' + a.apmaterno + ' ' + a.nombre AS [Nombre Alumno], A.fecha_nacimiento AS [Fecha Nacimiento],\r\np.Nombre AS [Pais Nacimiento], e2.Nombre AS [Estado Nacimiento], a.sexo AS [Sexo], a.curp AS [CURP], a.calle + ' ' + a.colonia + ', ' + a.ciudad + ', ' + e.Nombre AS [Domicilio],\r\na.telefono1 AS [Telefono 1], a.telefono2 AS [Telefono 2], a.telefono3 AS [Telefono 3], a.email AS [Correo], a.activo AS [Estatus]\r\nFROM alumnos a\r\nINNER JOIN paises p ON a.pais_nacimiento = p.Id\r\nINNER JOIN estados e ON a.estado = e.Id\t\r\nINNER JOIN estados e2 ON a.estado_nacimiento = e2.Id\t\r\nLEFT JOIN tutores_alumnos ta ON ta.matricula = a.matricula\r\nLEFT JOIN tutores t ON t.id_tutor = ta.id_tutor", "Alumnos");
            dgvAlumnos.DataSource = dtAlumnos;
            dgvAlumnos.Refresh();
        }

        private void CargarMenu()
        {
            guardarToolStripMenuItem.Visible = false;
        }
    }
}
