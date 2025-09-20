using SACDumont.Base;
using SACDumont.Models;
using SACDumont.modulos;
using SACDumont.Modulos;
using System;

namespace SACDumont.Otros
{
    public partial class frmGasto : frmBaseCatalogos
    {

        #region Variables
        int tipoMovimiento = (int)TipoMovimiento.Gasto;
        Movimientos movimientos;
        movimiento_productos movimientosProductos;
        cobros movientoCobro;

        #endregion

        #region Eventos Virtuales
        protected override void Nuevo()
        {

        }
        protected override void Guardar()
        {
            using (var db = new DumontContext())
            {
                movimientos = new Movimientos
                {
                    id_tipomovimiento = tipoMovimiento,
                    fechahora = DateTime.Now,
                    id_estatusmovimiento = (int)EstatusMovimiento.Liquidado,
                    id_usuario = basConfiguracion.UserID,
                    id_ciclo = basGlobals.iCiclo,
                    id_matricula = 0,
                    digitoscuenta = "0",
                    montoTotal = Convert.ToDecimal(txImporte.Text),
                    porcentaje_descuento = 0,
                    monto_descuento = 0,
                    beca_descuento = 0,
                    confirmado = true
                };

                db.Movimientos.Add(movimientos);
                db.SaveChanges();

                movimientosProductos = new movimiento_productos
                {
                    id_producto = 92,
                    id_movimiento = movimientos.id_movimiento,
                    cantidad = 1,
                    monto = Convert.ToDecimal(txImporte.Text),
                    monto_recargo = 0,
                    descripcion = txDescripcion.Text
                };

                movientoCobro = new cobros
                {
                    id_movimiento = movimientos.id_movimiento,
                    monto = Convert.ToDecimal(txImporte.Text),
                    tipopago = (int)TipoPago.Gasto,
                    fechaAlta = DateTime.Now
                };

                db.MovimientoProductos.Add(movimientosProductos);
                db.MovimientoCobros.Add(movientoCobro);
                db.SaveChanges();
            }
            this.Close();
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
