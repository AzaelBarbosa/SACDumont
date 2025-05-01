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
using SACDumont.Otros;

namespace SACDumont.Catalogos
{
    public partial class frmCatProducto : frmBaseCatalogos
    {
        #region "Variables"
        DataTable dtProductos = new DataTable("Productos");
        DataTable dtProductosCiclo = new DataTable("ProductoCiclo");
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
            // Validaciones...
            if (txConcepto.Text == "") { MessageBox.Show("El campo Concepto es obligatorio."); txConcepto.Focus(); return; }
            if (txDescripcion.Text == "") { MessageBox.Show("El campo Descripcion es obligatorio."); txDescripcion.Focus(); return; }
            if (txtCosto.Text == "") { MessageBox.Show("El campo Costo es obligatorio."); txtCosto.Focus(); return; }

            bool esNuevo = idProducto == 0;
            int idProd = esNuevo ? 0 : Convert.ToInt32(idProducto);

            if (esNuevo)
            {

                dtProductos = sqlServer.ExecSQLReturnDT("SELECT * FROM productos WHERE 1=0");
                dtProductosCiclo = sqlServer.ExecSQLReturnDT("SELECT * FROM producto_ciclo WHERE 1=0");
                DataRow newRow = dtProductos.NewRow();
                DataRow newRowCiclo = dtProductosCiclo.NewRow();
                newRow["id_producto"] = 0; // Placeholder
                newRowCiclo["id"] = 0; // Placeholder
                AsignarValoresProducto(newRow);
                dtProductos.Rows.Add(newRow);
                sqlServer.InsertByDataTable(ref dtProductos, "productos");

                // Obtener la matrícula generada
                int nuevoProducto = Convert.ToInt32(dtProductos.Rows[0]["id_producto"]);
                lbProductoID.Text = nuevoProducto.ToString();

                //Guardo relacion Costo Ciclo
                AsignarValoresProductoCiclo(newRowCiclo);
                dtProductosCiclo.Rows.Add(newRowCiclo);
                sqlServer.InsertByDataTable(ref dtProductosCiclo, "producto_ciclo");
                
                //Registrar el nuevo producto
                basFunctions.Registrar(basConfiguracion.UserID, "Productos", "Alta", nuevoProducto, "Se registró un nuevo producto: " + dtProductos.Rows[0]["descripcion"]);
                MessageBox.Show("Producto registrado correctamente con ID " + nuevoProducto);
                this.Close();
                
            }
            else
            {
                dtProductos = sqlServer.ExecSQLReturnDT($"SELECT * FROM productos WHERE id_producto = {idProducto}");
                dtProductosCiclo = sqlServer.ExecSQLReturnDT($"SELECT * FROM producto_ciclo WHERE id_producto = {idProducto} AND id_ciclo = {basConfiguracion.IdCiclo}");
                if (dtProductos.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontró el producto para actualizar.");
                    return;
                }

                DataRow existingRow = dtProductos.Rows[0];
                DataRow existingRowCiclo = dtProductosCiclo.Rows[0];
                AsignarValoresProducto(existingRow);
                AsignarValoresProductoCiclo(existingRowCiclo);
                //existingRow.SetModified(); // importante

                sqlServer.InsertByDataTable(ref dtProductos, "alumnos");
                sqlServer.InsertByDataTable(ref dtProductosCiclo, "producto_ciclo");
                basFunctions.Registrar(basConfiguracion.UserID, "Productos", "Editar", idProducto);
                MessageBox.Show("Producto actualizado correctamente.");
            }
        }
        protected override void Eliminar()
        {
            // Implementar la lógica para eliminar el registro de producto
        }
        protected override void Acciones()
        {
            frmAcciones frm = new frmAcciones("Acciones", idProducto);
            frm.Text = "Acciones Producto";
            frm.ShowDialog();
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
            var valores = new Dictionary<string, object>
            {
                ["descripcion"] = txDescripcion.Text,
                ["concepto"] = txConcepto.Text,
                ["estado"] = chkActivo.Checked
            };

            foreach (var item in valores)
            {
                row[item.Key] = item.Value ?? DBNull.Value;
            }
        }

        private void AsignarValoresProductoCiclo(DataRow row)
        {
            var valores = new Dictionary<string, object>
            {
                ["id_producto"] = idProducto,
                ["id_ciclo"] = basConfiguracion.IdCiclo,
                ["precio"] = txtCosto.Text,
                ["fecha_vencimiento"] = dtFechaVenci.Value
            };
            foreach (var item in valores)
            {
                row[item.Key] = item.Value ?? DBNull.Value;
            }
        }
        private void LimpiarControles()
        {
            txDescripcion.Text = string.Empty;
            txConcepto.Text = string.Empty;
            txtCosto.Text = string.Empty;
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
                string sSQL = "SELECT * FROM productos WHERE id_producto = " + idProducto;
                dtProductos = sqlServer.ExecSQLReturnDT(sSQL, "Productos");
                this.Text = "Editar Producto";
                if (dtProductos.Rows.Count > 0)
                {
                    DataRow row = dtProductos.Rows[0];
                    AsignarValoresProducto(row);
                }
                lbProductoID.Text = idProducto.ToString();
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
            CargarProducto(idProducto);
        }
    }
}
