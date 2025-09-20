using SACDumont.Base;
using SACDumont.Clases;
using SACDumont.Modulos;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using static SACDumont.Modulos.basConfiguracion;

namespace SACDumont.Otros
{
    public partial class frmConfig : frmBaseGeneral
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        protected override void Guardar()
        {
            try
            {
                string rutaArchivo = @"C:\SAC\configSecure.dll";

                var config = new ConfigInfo
                {
                    Servidor = txServidor.Text,
                    BaseDatos = txBasseDatos.Text,
                    Usuario = txUsuario.Text,
                    Contrasena = txContra.Text,
                    Equipo = txEquipo.Text

                };

                basConfiguracion.GuardarConfig(config, rutaArchivo);
                basFunctions basFunctions = new basFunctions();
                basFunctions.ConectaBD();
                basFunctions.UpdateConfig("sp_Config_Update", chRecargos.Checked, chPromociones.Checked, int.Parse(txPorcentajeRecargo.Text), int.Parse(nDiasTolerancia.Value.ToString()), txSEPPrimaria.Text, txZonaPrim.Text, txSEPMat.Text, txZonaMat.Text, txSEPPre.Text, txZonaPre.Text, txSEPSecundaria.Text, txZonaPre.Text);
                MessageBox.Show($"Configuración guardada de forma segura. {Environment.NewLine} Por favor reinicie el sistema para que los cambios surtan efecto.", "Copeland", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
                txEquipo.Text = config.Equipo;

                // Cargar configuraciones adicionales
                DataTable dt = sqlServer.ExecSQLReturnDT("SELECT * FROM config", "Config");
                if (dt.Rows.Count > 0)
                {
                    chRecargos.Checked = Convert.ToBoolean(dt.Rows[0]["aplicar_recargos"]);
                    chPromociones.Checked = Convert.ToBoolean(dt.Rows[0]["aplicar_promociones"]);
                    txPorcentajeRecargo.Text = dt.Rows[0]["porcentaje_recargo"].ToString();
                    nDiasTolerancia.Value = Convert.ToInt32(dt.Rows[0]["dias_tolerancia"]);
                    txSEPMat.Text = dt.Rows[0]["maternal_sep"].ToString();
                    txSEPPre.Text = dt.Rows[0]["preescolar_sep"].ToString();
                    txSEPPrimaria.Text = dt.Rows[0]["primaria_sep"].ToString();
                    txSEPSecundaria.Text = dt.Rows[0]["secundaria_sep"].ToString();
                    txZonaMat.Text = dt.Rows[0]["maternal_clave"].ToString();
                    txZonaPre.Text = dt.Rows[0]["preescolar_clave"].ToString();
                    txZonaPrim.Text = dt.Rows[0]["primaria_clave"].ToString();
                    txZonaSec.Text = dt.Rows[0]["secundaria_clave"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Environment.Exit(0); // equivalente a End
            }
        }

        private void chRecargos_CheckedChanged(object sender, EventArgs e)
        {
            if (chRecargos.Checked)
            {
                txPorcentajeRecargo.Enabled = true;
                nDiasTolerancia.Enabled = true;
            }
            else
            {
                txPorcentajeRecargo.Enabled = false;
                nDiasTolerancia.Enabled = false;
            }
        }
    }
}
