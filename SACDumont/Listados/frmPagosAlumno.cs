using Microsoft.Win32;
using SACDumont.Base;
using SACDumont.Dtos;
using SACDumont.Models;
using SACDumont.modulos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SACDumont.Listados
{
    public partial class frmPagosAlumno : frmListados
    {
        #region Variables

        DataTable dtPagosAl = new DataTable("PagosAlumnos");
        BindingSource bs = new BindingSource();
        List<PagosAlumnoDTO> listaPagos = new List<PagosAlumnoDTO>();
        int idAlumno = 0;

        #endregion

        #region Metodos Virtuales
        protected override void Nuevo()
        {

        }
        protected override void Guardar()
        {
            // Implementar la lógica para guardar el registro de alumno
        }
        protected override void Eliminar()
        {

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

        #endregion

        #region Metodos Privados
        private void CargarMenu()
        {
            nuevoToolStripMenuItem.Visible = false;
            guardarToolStripMenuItem.Visible = false;
        }

        private void CargarElementosBusqueda()
        {
            var ignorar = new[] { "id_movimiento", "BecaDescuento", "MontoDescuento", "Descuento", "Total", "MontoPendiente", "Fecha" };

            var propiedades = typeof(PagosAlumnoDTO)
                 .GetProperties()
                 .Select(p => p.Name)
                 .Where(nombre => !ignorar.Contains(nombre))
                 .ToList();

            foreach (var item in propiedades)
            {
                cboFiltros.Items.Add(item.ToString());
            }
        }

        private void CargarDatos()
        {
            using (var db = new DumontContext())
            {
                listaPagos = db.Movimientos.Where(m => m.id_ciclo == basGlobals.iCiclo && m.id_matricula == idAlumno).Include(m => m.MovimientosCobros).Include(m => m.MovimientosProductos)
                    .Select(m => new PagosAlumnoDTO
                    {
                        id_movimiento = m.id_movimiento,
                        Alumno = db.Alumnos.Where(a => a.matricula == idAlumno).Select(a => a.appaterno + ' ' + a.apmaterno + ' ' + a.nombre).FirstOrDefault(),
                        Fecha = m.fechahora
                    }).ToList();
            }
        }
        #endregion

        #region Metodos Formulario

        public frmPagosAlumno(int matricula)
        {
            InitializeComponent();
            this.idAlumno = matricula;
        }

        private void frmPagosAlumno_Load(object sender, EventArgs e)
        {
            CargarMenu();
            CargarElementosBusqueda();
        }

        #endregion
    }
}
