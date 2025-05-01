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
using SACDumont.Modulos;

namespace SACDumont.Listados
{
    public partial class frmProductos : frmListados
    {
        DataTable dtProductos = new DataTable("Productos");
        int idCiclo = 0;
        protected override void Nuevo()
        {
            frmCatProducto frmCatProductos = new frmCatProducto(0);
            frmCatProductos.ShowDialog();
            CargarProductos();
        }
        protected override void Guardar()
        {
            // Implementar la lógica para guardar el producto
        }
        protected override void Eliminar()
        {
            // Implementar la lógica para eliminar el producto
        }
        protected override void Imprimir()
        {
            // Implementar la lógica para imprimir el listado de productos
        }
        protected override void Cerrar()
        {
            this.Close();
        }
    
        public frmProductos()
        {
            InitializeComponent();
        }

        private void CargarProductos()
        {
            dtProductos = sqlServer.ExecSQLReturnDT($"SELECT pr.concepto AS Concepto, pr.descripcion AS Producto, prc.precio AS Costo FROM productos pr INNER JOIN producto_ciclo prc ON pr.id_producto = prc.id_producto INNER JOIN ciclos_escolares c ON c.id_ciclo = prc.id_ciclo WHERE c.id_ciclo = {idCiclo}", "Tutores");
            dgvProductos.DataSource = dtProductos;
            dgvProductos.Refresh();
        }

        private void CargarMenu()
        {
            guardarToolStripMenuItem.Visible = false;
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            // Cargar el ciclo escolar activo
            idCiclo = basConfiguracion.IdCiclo;
            CargarProductos();
            CargarMenu();
        }
    }
}
