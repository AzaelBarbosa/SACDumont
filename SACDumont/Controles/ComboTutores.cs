using SACDumont.Dtos;
using SACDumont.Modulos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SACDumont.Controles
{
    public partial class ComboTutores : UserControl
    {
        #region Variables
        private Form popup;

        public event Action<DataRow> OnTutorSeleccionado;
        public int? IDTutor
        {
            get
            {
                return Convert.ToInt32(txTutores.Tag);
            }
            set
            {
                txTutores.Tag = value;
                if (value != null)
                {
                    DataRow row = _datos.AsEnumerable().FirstOrDefault(r => r.Field<int>("IdTutor") == value);
                    if (row != null)
                    {
                        txTutores.Text = row["NombreCompleto"].ToString();
                    }
                }
                else
                {
                    txTutores.Text = string.Empty;
                }
            }
        }

        public string SqlQuery { get; set; }

        List<TutoresDTO> _listaTutores = new List<TutoresDTO>();
        DataTable _datos = new DataTable();
        BindingSource bd = new BindingSource();

        #endregion

        #region Metodos Publicos
        public void Inicializar()
        {
            if (string.IsNullOrEmpty(txTutores.Text))
            {
                txTutores.Text = "Seleccione un tutor...";
            }
            using (var db = new DumontContext())
            {
                _listaTutores = db.Tutores.Where(t => t.acivo == true).ToList().Select(t => new TutoresDTO
                {
                    IdTutor = t.id_tutor,
                    NombreCompleto = t.apmaterno + " " + t.apmaterno + " " + t.nombre,
                    Sexo = t.sexo.ToString(),
                    CorreoElectronico = "",
                    Telefono = t.telefono1,
                    FechaNacimiento = t.fecha_nacimiento
                }).ToList();
            }

            _datos = basFunctions.ConvertToDataTable(_listaTutores);
            CargarDatos();
        }

        public void CargarDatos()
        {
            bd.DataSource = _datos;
        }


        private void FormatoCeldas(DataGridView dgv)
        {
            dgv.Columns["IdTutor"].Visible = false;
            dgv.Columns["NombreCompleto"].HeaderText = "Nombre Tutor";
            dgv.Columns["Sexo"].HeaderText = "Sexo";
            dgv.Columns["Telefono"].HeaderText = "Telefono";
            dgv.Columns["FechaNacimiento"].HeaderText = "Fecha Nacimiento";

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
            var screenPoint = this.PointToScreen(new Point(txTutores.Left, txTutores.Bottom));
            form.Location = screenPoint;

            grid.CellDoubleClick += (s, e) =>
            {
                if (grid.SelectedRows.Count == 0) return;
                var row = ((DataRowView)grid.SelectedRows[0].DataBoundItem).Row;
                IDTutor = Convert.ToInt32(row["IdTutor"]);
                txTutores.Text = row["NombreCompleto"].ToString();
                OnTutorSeleccionado?.Invoke(row);
                form.Close();
            };

            form.Deactivate += (s, e) => form.Close();

            return form;
        }
        #endregion

        #region Eventos Control

        public ComboTutores()
        {
            InitializeComponent();
        }


        #endregion

        private void txTutores_TextChanged(object sender, EventArgs e)
        {
            string texto = txTutores.Text.ToLower();

            bd.Filter = $"NombreCompleto LIKE '%{txTutores.Text}%'";
        }

        private void txTutores_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
