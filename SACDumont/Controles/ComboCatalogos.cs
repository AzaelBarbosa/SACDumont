using SACDumont.Clases;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SACDumont.Controles
{
    public partial class ComboCatalogos : UserControl
    {
        public int? IDValor
        {
            get
            {
                return Convert.ToInt32(cboCatalogos.Tag);
            }
            set
            {
                cboCatalogos.Tag = value;
                if (value != null)
                {
                    DataRow row = _datos.AsEnumerable().FirstOrDefault(r => r.Field<int>("valor") == value);
                    if (row != null)
                    {
                        cboCatalogos.Text = row["descripcion"].ToString();
                    }
                }
                else
                {
                    cboCatalogos.Text = string.Empty;
                    cboCatalogos.SelectedIndex = -1;
                }
            }
        }
        public string Descripcion { get; set; }
        public string TipoCatalogo { get; set; }

        DataTable _datos = new DataTable();
        public ComboCatalogos()
        {
            InitializeComponent();
        }

        public void Inicializar()
        {
            CargarDatos();
        }

        public void CargarDatos()
        {
            _datos.Clear();
            _datos = sqlServer.ExecSQLReturnDT($"SELECT id_catalogo, tipo_catalogo, descripcion, valor FROM catalogos WHERE tipo_catalogo = '{TipoCatalogo}' ORDER BY valor", "Productos");
            cboCatalogos.DataSource = _datos;
            cboCatalogos.DisplayMember = "descripcion";
            cboCatalogos.ValueMember = "valor";
        }

        public void ValidarYAgregarNuevo(ComboBox combo)
        {
            DataTable dt;
            string texto = combo.Text.Trim();
            if (string.IsNullOrWhiteSpace(texto)) return;

            bool existe = false;
            foreach (DataRowView item in combo.Items)
            {
                if (item[combo.DisplayMember].ToString().Equals(texto, StringComparison.OrdinalIgnoreCase))
                {
                    existe = true;
                    break;
                }
            }

            if (!existe)
            {
                DialogResult r = MessageBox.Show(
                    $"“{texto}” no está en el catálogo de Catalogos. ¿Deseas agregarlo?",
                    "Agregar al catálogo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    dt = sqlServer.ExecSQLReturnDT($"SELECT MAX(valor) + 1 AS nuevoValor FROM catalogos WHERE tipo_catalogo = '{TipoCatalogo}'", "NuevoValor");
                    sqlServer.ExecSQL($"INSERT INTO catalogos (tipo_catalogo, descripcion, valor) VALUES ('{TipoCatalogo}','{texto}',{(int)dt.Rows[0]["nuevoValor"]})");

                    // Recargar
                    CargarDatos();
                    combo.SelectedIndex = combo.FindStringExact(texto);
                    MessageBox.Show("Elemento agregado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void cboCatalogos_Validating(object sender, CancelEventArgs e)
        {
            ValidarYAgregarNuevo(cboCatalogos);
        }

        private void cboCatalogos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCatalogos.SelectedValue != null && cboCatalogos.SelectedValue is int)
            {
                IDValor = (int)cboCatalogos.SelectedValue;
                Descripcion = cboCatalogos.Text;
            }
            else
            {
                IDValor = 0;
                Descripcion = string.Empty;
            }
        }
    }
}
