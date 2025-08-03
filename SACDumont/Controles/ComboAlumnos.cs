using DocumentFormat.OpenXml.Wordprocessing;
using SACDumont.Clases;
using SACDumont.modulos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SACDumont.Controles
{
    public partial class ComboAlumnos : UserControl
    {
        private Form popup;

        public event Action<DataRow> OnAlumnoSeleccionado;
        public int? idGrado { get; set; }
        public int? matricula
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
                    DataRow row = _datos.AsEnumerable().FirstOrDefault(r => r.Field<int>("matricula") == value);
                    if (row != null)
                    {
                        txProducto.Text = row["Alumno"].ToString();
                    }
                }
                else
                {
                    txProducto.Text = string.Empty;
                }
            }
        }
        public string SqlQuery { get; set; }

        DataTable _datos = new DataTable();
        BindingSource bd = new BindingSource();
        public ComboAlumnos()
        {
            InitializeComponent();
        }
        public void Inicializar()
        {
            if (string.IsNullOrEmpty(SqlQuery))
            {
                SqlQuery = $@"SELECT al.matricula, al.appaterno + ' ' + al.apmaterno + ' ' + al.nombre AS Alumno, cat.valor AS Grado, cat.descripcion AS DescripcionGrado, 
                                    ins.id_grupo AS Grupo, catG.descripcion AS DescripcionGrupo, ce.ciclo
                                    FROM alumnos al
                                    INNER JOIN inscripciones ins ON al.matricula = ins.matricula
                                    LEFT JOIN catalogos cat ON cat.valor = ins.id_grado AND cat.tipo_catalogo = 'Grado' 
                                    LEFT JOIN catalogos catG ON catG.valor = ins.id_grupo AND catG.tipo_catalogo = 'Grupo' 
                                    LEFT JOIN ciclos_escolares ce ON ins.id_ciclo = ce.id_ciclo
                                    WHERE ins.id_ciclo = {basGlobals.iCiclo}";
            }
            //if (txProducto.Text.Length > 0)
            //{
            //    SqlQuery = SqlQuery + $@" AND (al.appaterno + ' ' + al.apmaterno + ' ' + al.nombre LIKE '%{txProducto.Text}%')";
            //}
            CargarDatos();
        }

        public void CargarDatos()
        {
            _datos.Clear();
            _datos = sqlServer.ExecSQLReturnDT(SqlQuery, "Productos");
            bd.DataSource = _datos;
        }

        private void FormatoCeldas(DataGridView dgv)
        {
            dgv.Columns["matricula"].HeaderText = "Matricula";
            dgv.Columns["Alumno"].HeaderText = "Alumno";
            dgv.Columns["Grado"].HeaderText = "Grado";
            dgv.Columns["Grupo"].HeaderText = "Grupo";

            AjustarAlturaPanel(dgv);
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

        private void txProducto_Click(object sender, EventArgs e)
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

            var grid = new DataGridView
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
            grid.DataSource = bd;
            FormatoCeldas(grid);
            AjustarAlturaPanel(grid);
            var screenPoint = this.PointToScreen(new Point(txProducto.Left, txProducto.Bottom));
            form.Location = screenPoint;

            grid.CellDoubleClick += (s, e) =>
            {
                if (grid.SelectedRows.Count == 0) return;
                var row = ((DataRowView)grid.SelectedRows[0].DataBoundItem).Row;
                matricula = Convert.ToInt32(row["matricula"]);
                idGrado = Convert.ToInt32(row["Grado"]);
                txProducto.Text = row["Alumno"].ToString();
                OnAlumnoSeleccionado?.Invoke(row);
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
                this.Inicializar();
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

            bd.Filter = $"Alumno LIKE '%{txProducto.Text}%'";
        }

        private void txProducto_Enter(object sender, EventArgs e)
        {

        }
    }
}
