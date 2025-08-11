using SACDumont.Base;
using SACDumont.Models;
using SACDumont.modulos;
using SACDumont.Modulos;
using SACDumont.Otros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SACDumont.Catalogos
{
    public partial class frmCatUsuarios : frmBaseCatalogos
    {
        #region Variables
        int idUsuario = 0;
        Usuarios Usuarios = new Usuarios();
        List<perfiles> Perfiles = new List<perfiles>();
        #endregion

        #region Metodos Virtuales
        protected override void Nuevo()
        {

        }
        protected override void Guardar()
        {
            // Implementar la lógica para guardar el registro de alumno
            if (idUsuario == 0)
            {
                using (var db = new DumontContext())
                {
                    Usuarios.nombre_usuario = basFunctions.StringToLittleCase(txNombreUsuario.Text);
                    Usuarios.usuario = txUsuario.Text.ToString();
                    Usuarios.correo = txCorreo.Text;
                    Usuarios.reset_contrasena = true;
                    Usuarios.contrasena = "12345";
                    Usuarios.id_perfil = (int)cboPerfiles.SelectedValue;
                    Usuarios.estatus = true;
                    Usuarios.fecha_alta = DateTime.Now;

                    db.Usuarios.Add(Usuarios);

                    var result = db.SaveChanges();
                    if (result == 1)
                    {
                        idUsuario = Usuarios.id_usuario;
                        basFunctions.Registrar(basConfiguracion.UserID, "Usuario", "Alta", idUsuario, $"Se Creo Usuario: {Usuarios.nombre_usuario}");
                        MessageBox.Show("Usuario crecreado correctamente.", "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Close();
                }
            }
            else
            {
                using (var db = new DumontContext())
                {
                    Usuarios = db.Usuarios.Find(idUsuario);

                    Usuarios.nombre_usuario = txNombreUsuario.Text;
                    Usuarios.usuario = txUsuario.Text.ToString();
                    Usuarios.correo = txCorreo.Text;
                    Usuarios.id_perfil = (int)cboPerfiles.SelectedValue;
                    Usuarios.estatus = true;

                    db.Usuarios.Add(Usuarios);
                    db.Entry(Usuarios).State = System.Data.Entity.EntityState.Modified;

                    var result = db.SaveChanges();
                    if (result == 1)
                    {
                        basFunctions.Registrar(basConfiguracion.UserID, "Usuario", "Editar", idUsuario, $"Se modifico el usuario: {Usuarios.nombre_usuario}");
                        MessageBox.Show("Promocion modificada correctamente.", "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        protected override void Eliminar()
        {
            // Implementar la lógica para eliminar el registro de alumno
            using (var db = new DumontContext())
            {
                if (MessageBox.Show($"Esta por eliminar el Usuario:" + Environment.NewLine + Environment.NewLine + $"{Usuarios.nombre_usuario}" + Environment.NewLine + "¿Desea Continuar?", "Usuarios", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Usuarios = db.Usuarios.Find(idUsuario);
                    db.Usuarios.Remove(Usuarios);
                    db.Entry(Usuarios).State = System.Data.Entity.EntityState.Deleted;
                    var result = db.SaveChanges();
                    if (result == 1)
                    {
                        MessageBox.Show("Usuario eliminado correctamente.", "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
        }
        protected override void Acciones()
        {
            if (idUsuario == 0) return;

            frmAcciones frm = new frmAcciones("Usuario", idUsuario);
            frm.Text = $"Acciones Usuario {Usuarios.nombre_usuario}";
            frm.ShowDialog();
        }
        protected override void Deshabilitar()
        {
            using (var db = new DumontContext())
            {
                Usuarios = db.Usuarios.Find(idUsuario);

                Usuarios.estatus = false;
                db.Usuarios.Add(Usuarios);
                db.Entry(Usuarios).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                basFunctions.Registrar(basConfiguracion.UserID, "Usuario", "Editar", idUsuario, $"Se deshabilito Usuario: {Usuarios.nombre_usuario}");
                this.Close();
            }
        }
        protected override void Habilitar()
        {
            using (var db = new DumontContext())
            {
                Usuarios = db.Usuarios.Find(idUsuario);

                Usuarios.estatus = true;
                db.Usuarios.Add(Usuarios);
                db.Entry(Usuarios).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                basFunctions.Registrar(basConfiguracion.UserID, "Usuario", "Editar", idUsuario, $"Se habilito Usuario: {Usuarios.nombre_usuario}");
                this.Close();
            }
        }
        protected override void ResetContrasena()
        {
            using (var db = new DumontContext())
            {
                Usuarios = db.Usuarios.Find(idUsuario);

                Usuarios.reset_contrasena = true;
                db.Usuarios.Add(Usuarios);
                db.Entry(Usuarios).State = System.Data.Entity.EntityState.Modified;
                var result = db.SaveChanges();
                if (result > 0)
                {
                    MessageBox.Show("Se ah reseteado la contraseña del Usuario.", "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    basFunctions.Registrar(basConfiguracion.UserID, "Usuario", "Editar", idUsuario, $"Se reseteo contraseña Usuario: {Usuarios.nombre_usuario}");
                }

            }
        }
        protected override void Cerrar()
        {
            this.Close();
        }
        #endregion

        #region Metodos

        private void CargarMenu()
        {
            btAddTutor.Visible = false;
            btQuitarRecargo.Visible = false;
            if (idUsuario == 0)
            {
                btHabilitar.Visible = false;
                btDeshabilitar.Visible = false;
            }
            else
            {
                if (Usuarios.estatus)
                {
                    btHabilitar.Visible = false;
                    btDeshabilitar.Visible = true;
                }
                else
                {
                    btDeshabilitar.Visible = false;
                    btHabilitar.Visible = true;
                }
            }
        }

        private void CargarPerfiles()
        {
            using (var db = new DumontContext())
            {
                Perfiles = db.Perfiles.ToList();

                cboPerfiles.DataSource = Perfiles;
                cboPerfiles.DisplayMember = "descripcion";
                cboPerfiles.ValueMember = "id_perfil";
            }
        }

        private void CargarUsuario()
        {
            if (idUsuario == 0) return;

            using (var db = new DumontContext())
            {
                Usuarios = db.Usuarios.Find(idUsuario);
                if (Usuarios != null)
                {
                    lbIdPromo.Text = Usuarios.id_usuario.ToString();
                    txNombreUsuario.Text = Usuarios.nombre_usuario;
                    txCorreo.Text = Usuarios.correo;
                    txUsuario.Text = Usuarios.usuario;
                    cboPerfiles.SelectedValue = (int)Usuarios.id_perfil;
                }
            }
        }
        #endregion

        #region Eventos Formularios
        public frmCatUsuarios(int idUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
        }

        private void frmCatUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuario();
            CargarMenu();
            CargarPerfiles();

        }

        #endregion
    }
}
