using SACDumont.Base;
using SACDumont.Catalogos;
using SACDumont.Dtos;
using SACDumont.Models;
using SACDumont.modulos;
using SACDumont.Modulos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SACDumont.Listados
{
    public partial class frmUsuarios : frmListados
    {
        #region Variables
        Usuarios usuarios = new Usuarios();
        basFunctions basFunctions;
        List<UsuariosDTO> listaUsuarios = new List<UsuariosDTO>();
        DataTable dtUsuarios = new DataTable();
        int idCiclo = 0;
        int idUsuario = 0;
        BindingSource bs = new BindingSource();
        #endregion

        #region Metodos Virtuales
        protected override void Nuevo()
        {
            frmCatUsuarios frmCatUsuarios = new frmCatUsuarios(0);
            frmCatUsuarios.Text = $"Alta de Usuario";
            frmCatUsuarios.ShowDialog();
            CargarUsuarios(); // Recargar la lista después de editar
        }
        protected override void Guardar()
        {
            // Implementar la lógica para guardar el producto
        }
        protected override void Eliminar()
        {
            // Implementar la lógica para eliminar el producto
            if (idUsuario == 0) return;

            using (var db = new DumontContext())
            {
                usuarios = db.Usuarios.Find(idUsuario);

                if (MessageBox.Show($"Esta por eliminar el Usuario:" + Environment.NewLine + Environment.NewLine + $"{usuarios.nombre_usuario}" + Environment.NewLine + "¿Desea Continuar?", "Usuarios", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.Usuarios.Remove(usuarios);
                    db.Entry(usuarios).State = System.Data.Entity.EntityState.Deleted;
                    var result = db.SaveChanges();
                    if (result == 1)
                    {
                        MessageBox.Show("Producto eliminado correctamente", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarUsuarios();
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
        #endregion

        #region Metodos Privados

        private async void CargarUsuarios()
        {
            Cursor.Current = Cursors.WaitCursor;
            pbSpinner.Visible = true;
            pbSpinner.BringToFront();

            using (var db = new DumontContext()) // Asegúrate de usar tu contexto real
            {
                var datos = await Task.Run(() =>
                {
                    listaUsuarios = db.Usuarios
                   .Select(prc => new UsuariosDTO
                   {
                       Usuario = prc.usuario,
                       Contrasena = prc.contrasena,
                       Id_Perfil = prc.id_perfil,
                       Id_Usuario = prc.id_usuario,
                       Correo = prc.correo,
                       Estatus = prc.estatus,
                       ResetContrasena = prc.reset_contrasena,
                       NombreUsuario = prc.nombre_usuario,
                   })
                   .ToList();

                    return listaUsuarios;
                });

                dtUsuarios = basFunctions.ConvertToDataTable(datos);
                pbSpinner.Visible = false;
                Cursor.Current = Cursors.Default;
                bs.DataSource = dtUsuarios;
                listaUsuarios = datos.ToList();
                dgvUsuarios.DataSource = bs;
            }

            FormatGrid();

        }

        private void CargarMenu()
        {
            guardarToolStripMenuItem.Visible = false;
            reporteToolStripMenuItem.Visible = false;
        }

        private void FormatGrid()
        {
            dgvUsuarios.Columns["Id_Usuario"].Visible = false; // Ocultar columna Id si no es necesaria
            dgvUsuarios.Columns["Id_Perfil"].Visible = false; // Ocultar columna Id si no es necesaria
            dgvUsuarios.Columns["Contrasena"].Visible = false; // Ocultar columna Id si no es necesaria
            dgvUsuarios.Columns["ResetContrasena"].Visible = false; // Ocultar columna Id si no es necesaria
            dgvUsuarios.Columns["Usuario"].HeaderText = "Usuario";
            dgvUsuarios.Columns["Correo"].HeaderText = "Correo";
            dgvUsuarios.Columns["Estatus"].HeaderText = "Estatus";
            dgvUsuarios.Columns["NombreUsuario"].HeaderText = "Nombre Usuario";
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarElementosBusqueda()
        {
            var ignorar = new[] { "Id_Usuario", "Id_Perfil", "ResetContrasena", "Estatus", "Contrasena" };

            var propiedades = typeof(UsuariosDTO)
                 .GetProperties()
                 .Select(p => p.Name)
                 .Where(nombre => !ignorar.Contains(nombre))
                 .ToList();

            foreach (var item in propiedades)
            {
                cboFiltros.Items.Add(item.ToString());
            }
        }

        #endregion

        #region Eventos Formulario
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            CargarMenu();
            CargarElementosBusqueda();
            CargarUsuarios();
        }

        #endregion

        private void txBusqueda_TextChanged(object sender, EventArgs e)
        {

            string texto = txBusqueda.Text.ToLower();
            if (cboFiltros.SelectedItem == null) return;
            string campoSeleccionado = cboFiltros.SelectedItem.ToString();

            bs.Filter = $"{campoSeleccionado} LIKE '%{texto}%'";
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvUsuarios.Rows.Count)
            {
                var promocionSeleccionada = dgvUsuarios.Rows[e.RowIndex];
                idUsuario = (int)promocionSeleccionada.Cells["Id_Usuario"].Value;
            }
        }

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvUsuarios.Rows.Count)
            {
                var promocionSeleccionada = dgvUsuarios.Rows[e.RowIndex];
                frmCatUsuarios frmCatUsuarios = new frmCatUsuarios((int)promocionSeleccionada.Cells["Id_Usuario"].Value);
                frmCatUsuarios.Text = $"Edicion de Usuario: {(string)promocionSeleccionada.Cells["NombreUsuario"].Value}";
                frmCatUsuarios.ShowDialog();
                CargarUsuarios(); // Recargar la lista después de editar
            }
        }
    }
}
