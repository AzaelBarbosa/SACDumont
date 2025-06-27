using SACDumont.Base;
using SACDumont.Catalogos;
using SACDumont.Clases;
using SACDumont.Dtos;
using SACDumont.Models;
using SACDumont.Modulos;
using SACDumont.Otros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SACDumont.Listados
{
    public partial class frmProductos : frmListados
    {
        Productos producto = new Productos();
        Producto_Ciclo productoCiclo = new Producto_Ciclo();
        List<ProductoDTO> listaProductos = new List<ProductoDTO>();
        List<ProductoDTO> listaProductosCopy = new List<ProductoDTO>();
        DataTable dtProductos = new DataTable("Productos");
        int idCiclo = 0;
        int idProducto = 0;
        BindingSource bs = new BindingSource();
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
            if (idProducto == 0) return;

            using (var db = new DumontContext())
            {
                producto = db.Productos.Find(idProducto);
                productoCiclo = db.ProductoCiclo.FirstOrDefault(t => t.id_producto == idProducto && t.id_ciclo == idCiclo);

                if (MessageBox.Show($"Esta por eliminar el producto:" + Environment.NewLine + Environment.NewLine + $"{producto.descripcion}" + Environment.NewLine + "¿Desea Continuar?", "Productos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.Productos.Remove(producto);
                    db.ProductoCiclo.Remove(productoCiclo);
                    db.Entry(producto).State = System.Data.Entity.EntityState.Deleted;
                    db.Entry(productoCiclo).State = System.Data.Entity.EntityState.Deleted;
                    var result = db.SaveChanges();
                    if (result == 1)
                    {
                        MessageBox.Show("Producto eliminado correctamente", "Productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarProductos();
                    }
                }
            }
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

        private async void CargarProductos()
        {
            Cursor.Current = Cursors.WaitCursor;
            pbSpinner.Visible = true;
            pbSpinner.BringToFront();
            using (var db = new DumontContext()) // Asegúrate de usar tu contexto real
            {
                var datos = await Task.Run(() =>
                {
                    listaProductos = db.ProductoCiclo
                  .Where(prc => prc.id_ciclo == idCiclo)
                  .Select(prc => new ProductoDTO
                  {
                      Concepto = prc.Producto.concepto,
                      Descripcion = prc.Producto.descripcion,
                      Estado = prc.Producto.estado,
                      Id_Producto = prc.Producto.id_producto,
                      Costo = prc.precio,
                      Id_Grupo = prc.id_grupo
                  })
                  .ToList();

                    return listaProductos;
                });

                foreach (var item in datos)
                {
                    catalogos cat = new catalogos();
                    cat = db.Catalogos.FirstOrDefault(t => t.tipo_catalogo == "Grupo" && t.valor == item.Id_Grupo);
                    item.Grupo = cat.descripcion;
                }
                pbSpinner.Visible = false;
                Cursor.Current = Cursors.Default;
                bs.DataSource = datos.ToList();
                listaProductos = datos.ToList();
                listaProductosCopy = datos.ToList();
                dgvProductos.DataSource = bs;
            }

            //dtProductos = sqlServer.ExecSQLReturnDT($"SELECT pr.concepto AS Concepto, pr.descripcion AS Producto, prc.precio AS Costo FROM productos pr INNER JOIN producto_ciclo prc ON pr.id_producto = prc.id_producto INNER JOIN ciclos_escolares c ON c.id_ciclo = prc.id_ciclo WHERE c.id_ciclo = {idCiclo}", "Tutores");

            FormatGrid();

        }

        private void FormatGrid()
        {
            dgvProductos.Columns["Id_Producto"].Visible = false; // Ocultar columna Id si no es necesaria
            dgvProductos.Columns["Concepto"].HeaderText = "Concepto";
            dgvProductos.Columns["Id_Grupo"].Visible = false;
            dgvProductos.Columns["Grupo"].HeaderText = "Grupo";
            dgvProductos.Columns["Descripcion"].HeaderText = "Nombre del Producto";
            dgvProductos.Columns["Costo"].HeaderText = "Costo";
            dgvProductos.Columns["Costo"].DefaultCellStyle.Format = "C2";
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarElementosBusqueda()
        {

            var propiedades = typeof(ProductoDTO)
           .GetProperties()
           .Select(p => p.Name)
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

        private void frmProductos_Load(object sender, EventArgs e)
        {
            // Cargar el ciclo escolar activo
            idCiclo = basConfiguracion.IdCiclo;
            basFunctions.CenterSpinnerOverGrid(this, pbSpinner);
            CargarProductos();
            CargarElementosBusqueda();
            CargarMenu();
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < listaProductos.Count)
            {
                var productoSeleccionado = listaProductos[e.RowIndex];
                frmCatProducto frmCatProducto = new frmCatProducto(productoSeleccionado.Id_Producto);
                frmCatProducto.idGrupo = productoSeleccionado.Id_Grupo;
                frmCatProducto.Text = $"Edicion de Promocion: {productoSeleccionado.Descripcion}";
                frmCatProducto.ShowDialog();
                CargarProductos(); // Recargar la lista después de editar
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < listaProductos.Count)
            {
                var promocionSeleccionada = listaProductos[e.RowIndex];
                idProducto = promocionSeleccionada.Id_Producto;
            }
        }

        private void frmProductos_Resize(object sender, EventArgs e)
        {
            basFunctions.CenterSpinnerOverGrid(this, pbSpinner);
        }

        private void frmProductos_ResizeEnd(object sender, EventArgs e)
        {
            //basFunctions.CenterSpinnerOverGrid(this, pbSpinner);
        }

        private void txBusqueda_Click(object sender, EventArgs e)
        {

        }

        private void txBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txBusqueda.Text.Length > 0)
            {
                string texto = txBusqueda.Text.ToLower();
                if (cboFiltros.SelectedItem == null) return;
                string campoSeleccionado = cboFiltros.SelectedItem.ToString();

                listaProductos = listaProductos.Where(p =>
                {
                    var propiedad = p.GetType().GetProperty(campoSeleccionado);
                    if (propiedad == null) return false;

                    var valor = propiedad.GetValue(p);
                    return valor != null && valor.ToString().ToLower().Contains(texto);
                }).ToList();

                dgvProductos.DataSource = null;
                dgvProductos.DataSource = listaProductos;
                FormatGrid();
            }
            else
            {
                if (cboFiltros.SelectedItem == null) return;
                listaProductos = listaProductosCopy;
                dgvProductos.DataSource = null;
                dgvProductos.DataSource = listaProductos;
                FormatGrid();
            }
        }
    }
}
