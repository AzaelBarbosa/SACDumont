using SACDumont.Models;
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

namespace SACDumont.Otros
{
    public partial class frmPinRecargos : Form
    {
        public string pinText = "";
        public string usuario = "";
        List<Usuarios> usuarios = new List<Usuarios>();
        public frmPinRecargos()
        {
            InitializeComponent();
        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            pinText = txtPin.Text;
            usuario = cboUsuario.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void frmPinRecargos_Load(object sender, EventArgs e)
        {
            using (var db = new DumontContext())
            {
                usuarios = db.Usuarios.Where(u => u.id_perfil == (int)Perfiles.Administrador).ToList();

                cboUsuario.DataSource = usuarios;
                cboUsuario.DisplayMember = "usuario";
                cboUsuario.ValueMember = "usuario";
            }
        }
    }
}
