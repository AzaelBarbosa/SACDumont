using SACDumont.Base;
using SACDumont.Catalogos;
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

namespace SACDumont.Otros
{
    public partial class frmGasto : frmBaseCatalogos
    {

        #region Variables
        int tipoMovimiento = (int)TipoMovimiento.Gasto;
        
        #endregion

        #region Eventos Virtuales
        protected override void Nuevo()
        {
            frmCatProducto frm = new frmCatProducto(0);
            frm.ShowDialog();
        }
        protected override void Guardar()
        {

        }
        protected override void Eliminar()
        {

        }
        protected override void Acciones()
        {
            //frmAcciones frm = new frmAcciones("Productos", idProducto);
            //frm.Text = "Acciones Producto";
            //frm.ShowDialog();
        }
        protected override void Deshabilitar()
        {

        }
        protected override void Habilitar()
        {

        }
        protected override void Cerrar()
        {
            this.Close();
        }
        #endregion

        #region Eventos Privados
        private void CargarMenu()
        {
            btAddTutor.Visible = false;
            btDeshabilitar.Visible = false;
            btHabilitar.Visible = false;
            btQuitarRecargo.Visible = false;
            btResetPass.Visible = false;
        }
        #endregion
        public frmGasto()
        {
            InitializeComponent();
        }

        private void frmGasto_Load(object sender, EventArgs e)
        {
            CargarMenu();
        }
    }
}
