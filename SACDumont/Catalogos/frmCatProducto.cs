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
using SACDumont.Modulos;

namespace SACDumont.Catalogos
{
    public partial class frmCatProducto : frmBaseCatalogos
    {
        #region "Variables"
        DataTable dtProductos = new DataTable("Productos");
        int idProducto = 0;
        basFunctions basFunctions = new basFunctions();
        sqlServer sqlServer = new sqlServer();
        #endregion
        #region "Métodos Virtuales"

        protected override void Nuevo()
        {
            frmCatProducto frm = new frmCatProducto(0);
            frm.ShowDialog();
        }
        protected override void Guardar()
        {
            // Implementar la lógica para guardar el registro de producto
        }
        protected override void Eliminar()
        {
            // Implementar la lógica para eliminar el registro de producto
        }
        protected override void Acciones()
        {
            // Implementar la lógica para imprimir el listado de productos
        }
        protected override void Cerrar()
        {
            this.Close();
        }

        #endregion

        #region "Métodos"

        private void CargarProductos()
        {
            // Implementar la lógica para cargar los productos en el DataTable
        }

        private void AsignarValoresProducto(DataRow row)
        {
            // Implementar la lógica para asignar valores a los controles del formulario
        }
        private void LimpiarControles()
        {
            // Implementar la lógica para limpiar los controles del formulario
        }
        private void CargarProducto(int idProducto)
        {
            if (idProducto == 0)
            {
                // Cargar un nuevo registro vacío
                this.Text = "Nuevo Producto";
                LimpiarControles();
                lbProductoID.Text = "0";
            }
            else
            {
                // Cargar el registro de producto existente
                string sSQL = "SELECT * FROM Productos WHERE id_producto = " + idProducto;
                dtProductos = sqlServer.ExecSQLReturnDT(sSQL, "Productos");
                this.Text = "Editar Producto";
                if (dtProductos.Rows.Count > 0)
                {
                    DataRow row = dtProductos.Rows[0];
                    AsignarValoresProducto(row);
                }
            }
        }
        private void CargarMenu()
        {
            btAddTutor.Visible = false;
        }
        #endregion

        public frmCatProducto(int idProducto)
        {
            InitializeComponent();
            this.idProducto = idProducto;
        }

        private void frmCatProducto_Load(object sender, EventArgs e)
        {
            CargarMenu();
        }
    }
}
