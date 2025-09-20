using SACDumont.Clases;
using SACDumont.Modulos;
using System;
using System.Windows.Forms;

namespace SACDumont
{
    public partial class frmChangePassword : Form
    {
        int id_usuario;
        basFunctions basFunctions = new basFunctions();
        public frmChangePassword(int idUsuario)
        {
            id_usuario = idUsuario;
            InitializeComponent();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            if (txContrasena.Text != txContrasena2.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string strPassword = basFunctions.HashPassword(txContrasena.Text);
                string sSQL = "UPDATE usuarios SET contrasena = '" + strPassword + "', reset_contrasena = 0 WHERE id_usuario = " + id_usuario;
                sqlServer.ExecSQL(sSQL);

                MessageBox.Show("Contraseña cambiada correctamente", "SAC Dumont", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {

        }
    }
}
