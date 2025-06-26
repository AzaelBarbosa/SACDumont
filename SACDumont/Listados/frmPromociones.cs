using SACDumont.Base;
using SACDumont.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SACDumont.Catalogos;
using SACDumont.modulos;

namespace SACDumont.Listados
{
    public partial class frmPromociones : frmListados
    {
        #region Variables
        List<Promociones> listaPromociones = new List<Promociones>();
        Promociones promociones = new Promociones();
        int idPromocion = 0;
        #endregion

        #region Metodos Virtuales
        // Métodos virtuales que los hijos pueden sobreescribir
        protected override void Nuevo()
        {
            frmCatPromocion frmCatPromocion = new frmCatPromocion(0);
            frmCatPromocion.Text = "Nueva Promocion";
            frmCatPromocion.ShowDialog();
            CargarPromociones(); // Recargar la lista después de editar
        }
        protected override void Guardar()
        {
            // Implementar la lógica para guardar el registro de alumno
        }
        protected override void Eliminar()
        {
            // Implementar la lógica para eliminar el registro de alumno
            if (idPromocion == 0) return;

            using (var db = new DumontContext())
            {
                promociones = db.Promociones.Find(idPromocion);
                if (MessageBox.Show($"Esta por eliminar la promocion:" + Environment.NewLine + Environment.NewLine + $"{promociones.descripcion}" + Environment.NewLine + "¿Desea Continuar?", "Promociones", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.Promociones.Remove(promociones);
                    db.Entry(promociones).State = System.Data.Entity.EntityState.Deleted;
                    var result = db.SaveChanges();
                    if (result == 1)
                    {
                        MessageBox.Show("Promocion eliminada correctamente", "Promociones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarPromociones();
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

        private void CargarPromociones()
        {
            // Aquí se cargarían las promociones desde la base de datos o cualquier otra fuente
            // Por ejemplo:
            using (var db = new DumontContext())
            {
                listaPromociones = db.Promociones.Where(t => t.id_ciclo == basGlobals.iCiclo).ToList();
            }
            // Asignar la lista al DataGridView o cualquier otro control que se utilice para mostrar los datos
            dgvPromociones.DataSource = listaPromociones;
            FormatoGrid();
        }

        private void FormatoGrid()
        {
            // Configurar el formato del DataGridView, si es necesario
            dgvPromociones.Columns["id_promocion"].Visible = false; // Ocultar columna Id si no es necesaria
            dgvPromociones.Columns["id_ciclo"].HeaderText = "Ciclo Escolar";
            dgvPromociones.Columns["descripcion"].HeaderText = "Nombre de la Promoción";
            dgvPromociones.Columns["porcentaje_promocion"].HeaderText = "Porcentaje Promoción";
            dgvPromociones.Columns["fecha_inicio"].HeaderText = "Fecha Inicio";
            dgvPromociones.Columns["fecha_fin"].HeaderText = "Fecha Fin";
            dgvPromociones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        #endregion

        #region Eventos Formulario

        #endregion
        public frmPromociones()
        {
            InitializeComponent();
        }

        private void frmPromociones_Load(object sender, EventArgs e)
        {
            CargarMenu();
            CargarPromociones();
        }

        private void dgvPromociones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < listaPromociones.Count)
            {
                var promocionSeleccionada = listaPromociones[e.RowIndex];
                frmCatPromocion frmCatPromocion = new frmCatPromocion(promocionSeleccionada.id_promocion);
                frmCatPromocion.Text = $"Edicion de Promocion: {promocionSeleccionada.descripcion}";
                frmCatPromocion.ShowDialog();
                CargarPromociones(); // Recargar la lista después de editar
            }
        }

        private void dgvPromociones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < listaPromociones.Count)
            {
                var promocionSeleccionada = listaPromociones[e.RowIndex];
                idPromocion = promocionSeleccionada.id_promocion;
            }
        }
    }
}
