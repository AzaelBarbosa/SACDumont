using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SACDumont.Clases;
using SACDumont.Modulos;
using SACDumont.Otros;
using System.IO;
namespace SACDumont
{
    public partial class frmLogin : Form
    {
        DataSet dtPaso;
        DataRow[] drPaso;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string filePath = @"C:\SAC\configSecure.dll";
            if (!File.Exists(filePath))
            {
                MessageBox.Show("El archivo de configuración no existe.\nSe procederá a abrir el asistente para crear y configurar la conexión.",
               "SAC-Dumont",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information
                );
                frmConfig formCrear = new frmConfig();
                formCrear.ShowDialog();
            }

            basFunctions basFunc = new basFunctions();
            basFunc.ConectaBD();

            dtPaso = sqlServer.ExecSQLReturnDS(
                @"SELECT U.* 
          FROM usuarios U 
          INNER JOIN perfiles P ON P.id_perfil = U.id_perfil",
                "Usuarios");

            // Llenar ComboBox
            foreach (DataRow dr in dtPaso.Tables[0].Rows)
            {
                cboUsuarios.Items.Add(dr["usuario"].ToString());
            }
        }

        private void btEntrar_Click(object sender, EventArgs e)
        {
            string strPassword = basFunctions.HashPassword(txPassword.Text);
            if (drPaso[0]["contrasena"].ToString() == strPassword)
            {
                frmMain frmM = new frmMain(drPaso[0]);

                MessageBox.Show("Bienvenido " + drPaso[0]["nombre_usuario"], "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Information);


                basConfiguracion basConfig = new basConfiguracion();
                basConfig.SetUserSession(
                   Convert.ToInt32(drPaso[0]["id_usuario"]),
                    Convert.ToInt32(drPaso[0]["id_perfil"]),
                    drPaso[0]["nombre_usuario"].ToString()
                );

                this.Hide();
                frmM.Show();
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta", "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txPassword.Focus();
            }
        }

        private void cboUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            drPaso = dtPaso.Tables[0].Select($"usuario = '{cboUsuarios.Text}'");

            if (drPaso.Length == 0)
            {
                MessageBox.Show("El Usuario que ha seleccionado no fue encontrado.", "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btEntrar.Enabled = false;
                cboUsuarios.Focus();
            }
            else
            {
                if (Convert.ToInt32(drPaso[0]["reset_contrasena"]) == 1)
                {
                    MessageBox.Show("El Usuario ah solocitado resetar su contraseña", "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmChangePassword frmCP = new frmChangePassword(Convert.ToInt32(drPaso[0]["id_usuario"]));
                    frmCP.ShowDialog();
                    dtPaso = sqlServer.ExecSQLReturnDS(
                                @"SELECT U.* 
                          FROM usuarios U 
                          INNER JOIN perfiles P ON P.id_perfil = U.id_perfil",
                                "Usuarios");

                    // Llenar ComboBox
                    foreach (DataRow dr in dtPaso.Tables[0].Rows)
                    {
                        cboUsuarios.Items.Add(dr["usuario"].ToString());
                    }
                }
                else
                {
                    btEntrar.Enabled = true;
                }
            }
        }

        private void txPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                string strPassword = basFunctions.HashPassword(txPassword.Text);
                if (drPaso[0]["contrasena"].ToString() == strPassword)
                {
                    frmMain frmM = new frmMain(drPaso[0]);

                    MessageBox.Show("Bienvenido " + drPaso[0]["nombre_usuario"], "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    basConfiguracion basConfig = new basConfiguracion();
                    basConfig.SetUserSession(
                       Convert.ToInt32(drPaso[0]["id_usuario"]),
                        Convert.ToInt32(drPaso[0]["id_perfil"]),
                        drPaso[0]["nombre_usuario"].ToString()
                    );

                    this.Hide();
                    frmM.Show();
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta", "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txPassword.Focus();
                }
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
