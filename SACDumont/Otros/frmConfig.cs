using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SACDumont.Modulos;
using SACDumont.Base;
using static SACDumont.Modulos.basConfiguracion;
using System.IO;

namespace SACDumont.Otros
{
    public partial class frmConfig : frmBaseGeneral
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            try
            {
                string filePath = @"C:\SAC\configSecure.dll";

                if (!File.Exists(filePath))
                {
                    return;
                }

                ConfigInfo config = basConfiguracion.LeerConfig(@"C:\SAC\configSecure.dll");

                txServidor.Text = config.Servidor;
                txBasseDatos.Text = config.BaseDatos;
                txUsuario.Text = config.Usuario;
                txContra.Text = config.Contrasena;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Environment.Exit(0); // equivalente a End
            }
        }
    }
}
