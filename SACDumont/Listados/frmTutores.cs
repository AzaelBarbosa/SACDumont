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
    public partial class frmTutores : frmListados
    {
        DataTable dtTutores = new DataTable("Tutores");

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
        public frmTutores()
        {
            InitializeComponent();
        }

        #region "Metodos"
        private void CargarTutores()
        {
            dtTutores = sqlServer.ExecSQLReturnDT("SELECT t.id_tutor AS ID, t.appaterno + ' ' + t.apmaterno + ' ' + t.nombre AS [Nombre Tutor], t.denomsocial AS [Denominacion Social], e.Nombre, t.calle AS Calle, t.colonia AS Colonia, t.ciudad AS Ciudad, t.rfc AS RFC, t.telefono1 AS Telefono1, t.telefono2 AS Telefono2, t.telefono3 AS Telefono3, t.sexo AS Sexo FROM tutores t INNER JOIN estados e ON e.Id = t.estado", "Tutores");
            dgvTutores.DataSource = dtTutores;
            dgvTutores.Refresh();
        }

        private void CargarMenu()
        {
            guardarToolStripMenuItem.Visible = false;
            nuevoToolStripMenuItem.Visible = false;
        }
        #endregion

        private void frmTutores_Load(object sender, EventArgs e)
        {
            CargarMenu();
            CargarTutores();
        }

        private void frmTutores_FormClosed(object sender, FormClosedEventArgs e)
        {
        
        }

        private void frmTutores_Activated(object sender, EventArgs e)
        {
          
        }
    }
}
