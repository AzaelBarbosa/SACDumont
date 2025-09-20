using SACDumont.Base;
using SACDumont.Catalogos;
using SACDumont.Dtos;
using SACDumont.Models;
using SACDumont.modulos;
using SACDumont.Modulos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
        int idProdCiclo = 0;
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
                productoCiclo = db.ProductoCiclo.Find(idProdCiclo);

                List<movimiento_productos> listaMov = db.MovimientoProductos.Where(t => t.id_producto == idProducto).ToList();
                if (listaMov.Count > 0)
                {
                    MessageBox.Show($"El producto {producto.descripcion} ya se encuentra asignado a uno o mas movimientos." + Environment.NewLine + "No es posible eliminar el Producto", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show($"Esta por eliminar el producto:" + Environment.NewLine + Environment.NewLine + $"{producto.descripcion}" + Environment.NewLine + "¿Desea Continuar?", "Productos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.ProductoCiclo.Remove(productoCiclo);
                    db.Entry(productoCiclo).State = System.Data.Entity.EntityState.Deleted;
                    var result = db.SaveChanges();
                    if (result > 0)
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

        protected override void CargarComboFiltro()
        {
            if (cboFiltros.SelectedIndex >= 0)
            {
                string selectedFilter = cboFiltros.SelectedItem.ToString();
                if (selectedFilter == "Estado")
                {
                    txBusqueda.Visible = false;
                    cboBusqueda.Visible = true;
                    cboBusqueda.Items.Clear();
                    cboBusqueda.Items.Add("Todos");
                    cboBusqueda.Items.Add("Activo");
                    cboBusqueda.Items.Add("Inactivo");
                    cboBusqueda.SelectedIndex = -1; // Seleccionar el primer elemento por defecto
                }
                else if (selectedFilter == "Concepto")
                {
                    txBusqueda.Visible = false;
                    cboBusqueda.Visible = true;
                    cboBusqueda.Items.Clear();
                    cboBusqueda.Items.Add("Todos");
                    cboBusqueda.Items.AddRange(Enum.GetNames(typeof(Conceptos)));
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
            if (campoSeleccionado == "Estado")
            {
                if (cboBusqueda.SelectedItem == null || cboBusqueda.SelectedItem.ToString() == "Todos")
                {
                    bs.Filter = "";
                    return;
                }
                else if (cboBusqueda.SelectedItem.ToString() == "Activo")
                {
                    bs.Filter = $"{campoSeleccionado} = {true}";
                }
                else if (cboBusqueda.SelectedItem.ToString() == "Inactivo")
                {
                    bs.Filter = $"{campoSeleccionado} = {false}";
                }
            }
            else if (campoSeleccionado == "Concepto")
            {

                if (cboBusqueda.SelectedItem.ToString() == "Todos")
                {
                    bs.Filter = "";
                    return;
                }
                bs.Filter = $"{campoSeleccionado} LIKE '%{cboBusqueda.SelectedItem.ToString()}%'";
            }
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
                      Abrv = prc.Producto.abreviatura,
                      Concepto = prc.Producto.concepto,
                      Descripcion = prc.Producto.descripcion,
                      Estado = prc.Producto.estado,
                      Id_Producto = prc.Producto.id_producto,
                      Costo = prc.precio,
                      Id_Grupo = prc.id_grupo,
                      FechaVencimiento = prc.fecha_vencimiento,
                      Id = prc.id
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
                dtProductos = basFunctions.ConvertToDataTable(datos);
                bs.DataSource = dtProductos;
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
            dgvProductos.Columns["Id"].Visible = false; // Ocultar columna Id si no es necesaria
            dgvProductos.Columns["Concepto"].HeaderText = "Concepto";
            dgvProductos.Columns["Id_Grupo"].Visible = false;
            dgvProductos.Columns["Grupo"].HeaderText = "Grupo";
            dgvProductos.Columns["Descripcion"].HeaderText = "Nombre del Producto";
            dgvProductos.Columns["Costo"].HeaderText = "Costo";
            dgvProductos.Columns["FechaVencimiento"].HeaderText = "Fecha de Vencimiento";
            dgvProductos.Columns["Costo"].DefaultCellStyle.Format = "C2";
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarElementosBusqueda()
        {
            var ignorar = new[] { "Id_Producto", "Id_Grupo", "Costo" };

            var propiedades = typeof(ProductoDTO)
                 .GetProperties()
                 .Select(p => p.Name)
                 .Where(nombre => !ignorar.Contains(nombre))
                 .ToList();

            foreach (var item in propiedades)
            {
                this.cboFiltros.Items.Add(item.ToString());
            }
        }


        private void CargarMenu()
        {
            guardarToolStripMenuItem.Visible = false;
            reporteToolStripMenuItem.Visible = false;
            btTicketImpresora.Visible = false;
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            // Cargar el ciclo escolar activo
            idCiclo = basGlobals.iCiclo;
            basFunctions.CenterSpinnerOverGrid(this, pbSpinner);
            CargarProductos();
            CargarElementosBusqueda();
            CargarMenu();
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];
                idProducto = int.Parse(fila.Cells["Id_Producto"].Value?.ToString());
                frmCatProducto frmCatProducto = new frmCatProducto(idProducto);
                frmCatProducto.idGrupo = int.Parse(fila.Cells["Id_Grupo"].Value?.ToString());
                frmCatProducto.Text = $"Edicion de Producto: {fila.Cells["Descripcion"].Value?.ToString()}";
                frmCatProducto.ShowDialog();
                CargarProductos(); // Recargar la lista después de editar
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];
                idProducto = int.Parse(fila.Cells["Id_Producto"].Value?.ToString());
                idProdCiclo = int.Parse(fila.Cells["Id"].Value?.ToString());
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

        private void dgvProductos_Resize(object sender, EventArgs e)
        {
            basFunctions.CenterSpinnerOverGrid(this, pbSpinner);
        }
    }
}
