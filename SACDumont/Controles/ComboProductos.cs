using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SACDumont.Clases;
using SACDumont.modulos;

namespace SACDumont.Controles
{
    public partial class ComboProductos : UserControl
    {
        private Form popup;
        public event Action<DataRow> OnCobroSeleccionado;
        public int? IdProductoSeleccionado
        {
            get
            {
                return Convert.ToInt32(txProducto.Tag);
            }
            set
            {
                txProducto.Tag = value;
                if (value != null)
                {
                    DataRow row = _datos.AsEnumerable().FirstOrDefault(r => r.Field<int>("id_producto") == value);
                    if (row != null)
                    {
                        txProducto.Text = row["descripcion"].ToString();
                        OnCobroSeleccionado?.Invoke(row);
                    }
                }
                else
                {
                    txProducto.Text = string.Empty;
                }
            }
        }
        public decimal? Precio { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public string Descripcion { get; set; }
        public int? idGrado { get; set; }
        public string SqlQuery { get; set; }

        DataTable _datos = new DataTable();
        BindingSource bs = new BindingSource();
        bool existeProducto = false;
        public void Inicializar()
        {
            //if (txProducto.Text.Length > 0)
            //{
            //    SqlQuery = SqlQuery + $@" AND (p.descripcion LIKE '%{txProducto.Text}%')";
            //}
            CargarDatos();
        }

        public ComboProductos()
        {
            InitializeComponent();
        }

        private void txProducto_Click(object sender, EventArgs e)
        {

        }

        public void CargarDatos()
        {
            _datos.Clear();
            _datos = sqlServer.ExecSQLReturnDT(SqlQuery, "Productos");
            bs.DataSource = _datos;
            bs.Sort = "fecha_vencimiento ASC";
        }

        private void FormatoCeldas(DataGridView dgv)
        {
            dgv.Columns["descripcion"].HeaderText = "Descripción";
            dgv.Columns["concepto"].HeaderText = "Concepto";
            dgv.Columns["fecha_vencimiento"].HeaderText = "Fecha Vencimiento";
            dgv.Columns["precio"].HeaderText = "Precio";
            dgv.Columns["id_producto"].Visible = false;
            dgv.Columns["precio"].DefaultCellStyle.Format = "C2";
            dgv.Columns["precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["fecha_vencimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        public void AjustarAlturaPanel(DataGridView grid)
        {
            int rowHeight = grid.RowTemplate.Height;
            int totalRows = grid.Rows.Count;

            // Calcular altura deseada
            int alturaDeseada = grid.ColumnHeadersHeight + (rowHeight * totalRows) + 10;
            int alturaMaxima = 200;
            grid.Height = Math.Min(alturaDeseada, alturaMaxima);

            // Calcular ancho total de columnas visibles
            int anchoDeseado = 0;
            foreach (DataGridViewColumn col in grid.Columns)
            {
                if (col.Visible)
                    anchoDeseado += col.Width;
            }

            int anchoMaximo = 900; // ajustable
            grid.Width = Math.Min(anchoDeseado + 20, anchoMaximo); // margen lateral extra
        }

        private void ComboProductos_Load(object sender, EventArgs e)
        {

        }

        private Form CrearNuevoPopup()
        {
            var form = new Form
            {
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.Manual,
                TopMost = true,
                ShowInTaskbar = false,
                Width = 700,
                Height = 300
            };

            DataGridView grid = new DataGridView
            {
                Dock = DockStyle.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                AllowUserToOrderColumns = false,
                AllowUserToResizeColumns = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
            };
            form.Controls.Add(grid);

            grid.DataSource = bs;
            FormatoCeldas(grid);
            AjustarAlturaPanel(grid);

            var screenPoint = this.PointToScreen(new Point(txProducto.Left, txProducto.Bottom));
            form.Location = screenPoint;

            grid.CellDoubleClick += (s, e) =>
            {
                if (grid.SelectedRows.Count == 0) return;
                var row = ((DataRowView)grid.SelectedRows[0].DataBoundItem).Row;
                IdProductoSeleccionado = Convert.ToInt32(row["id_producto"]);
                Precio = Convert.ToDecimal(row["precio"]);
                Descripcion = row["descripcion"].ToString();
                FechaVencimiento = Convert.ToDateTime(row["fecha_vencimiento"]);
                txProducto.Text = row["descripcion"].ToString();
                OnCobroSeleccionado?.Invoke(row);
                form.Close();
            };

            form.Deactivate += (s, e) => form.Close();

            return form;
        }

        private void txProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (popup == null || popup.IsDisposed)
                {
                    popup = CrearNuevoPopup();
                }
                popup.Show();
                popup.BringToFront();
            }
        }

        private void txProducto_TextChanged(object sender, EventArgs e)
        {
            string texto = txProducto.Text.ToLower();

            bs.Filter = $"descripcion LIKE '%{txProducto.Text}%'";

        }

        private void txProducto_Leave(object sender, EventArgs e)
        {

        }

        private void txProducto_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txProducto_Validated(object sender, EventArgs e)
        {
            Descripcion = txProducto.Text;
        }
    }
}
