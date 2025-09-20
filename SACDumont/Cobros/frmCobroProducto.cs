using SACDumont.Base;
using SACDumont.Models;
using SACDumont.modulos;
using SACDumont.Modulos;
using SACDumont.Otros;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SACDumont.Cobros
{
    public partial class frmCobroProducto : frmBaseCatalogos
    {
        public decimal promocion = 0;
        public decimal beca = 0;
        decimal valuePromocion = 0;
        decimal valueBeca = 0;
        decimal precioConBeca = 0;
        decimal decRecargo = basConfiguracion.PorcentajeRecargo;
        int idGrupo = 0;
        string strConcepto = "";
        string strConceptoProducto = "Producto";
        string strProducto = "Producto";
        decimal decPrecio = 0;
        basGlobals basGlobals = new basGlobals();
        movimiento_productos productos;
        int idAlumno = 0;
        protected override void Nuevo()
        {

        }
        protected override void Guardar()
        {
            if (strConcepto == Conceptos.COLEGIATURA.ToString() | strConcepto == Conceptos.INSCRIPCION.ToString())
            {
                if (ValidarYaCobrado())
                {
                    MessageBox.Show("El producto seleccionado ya fue cobrado", "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!ValidarColegiaturaAnt())
                {
                    MessageBox.Show("No puede cobrar la Colegiatura seleccionada, ya que aun tiene en adeudo la colegiatura anterior", "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            // Implementar la lógica para guardar el movimiento  
            if (comboProductos1.IdProductoSeleccionado != null)
            {
                decimal total = 0;
                string rawText = txCosto.Text.Replace("$", "").Replace(",", "").Trim();
                decimal.TryParse(rawText, out total);

                var existe = basGlobals.listaProductos.FirstOrDefault(p => p.id_producto == Convert.ToInt32(comboProductos1.IdProductoSeleccionado));

                if (existe != null)
                {
                    MessageBox.Show("Ya existe un producto con esa descripción.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                productos = new movimiento_productos
                {
                    id_producto = Convert.ToInt32(comboProductos1.IdProductoSeleccionado),
                    descriptionProducto = comboProductos1.Descripcion,
                    id_movimiento = 0,
                    cantidad = Convert.ToInt32(nCantidad.Value),
                    monto = total,
                    monto_recargo = Convert.ToDecimal(txRecargo.Text.Replace("$", "").Replace(",", "").Trim()),
                    talla = txTalla.Text,
                    monto_beca = valueBeca,
                    monto_promocion = valuePromocion
                };

                basGlobals.listaProductos.Add(productos);

                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        protected override void Eliminar()
        {
            // Implementar la lógica para eliminar el movimiento  
        }
        protected override void Cerrar()
        {
            this.Close();
        }
        protected override void Deshabilitar()
        {
            // Implementar la lógica para deshabilitar el movimiento  
        }
        protected override void QuitarRecargo()
        {
            // Implementar la lógica para quitar el recargo del movimiento  
            using (var form = new frmPinRecargos())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    string pin = form.pinText;
                    if (basFunctions.ValidarPin(pin, form.usuario))
                    {
                        MessageBox.Show("Recargo quitado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txRecargo.Text = (Convert.ToDecimal(0)).ToString("C");
                        txtTotal.Text = txCosto.Text;
                    }
                    else
                    {
                        MessageBox.Show("PIN incorrecto. No se pudo quitar el recargo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public frmCobroProducto(int idGrupo, string strConcepto, int idAlumno)
        {
            InitializeComponent();
            this.idGrupo = idGrupo;
            this.strConcepto = strConcepto;
            this.idAlumno = idAlumno;
        }

        private void frmCobroProducto_Load(object sender, EventArgs e)
        {
            GenerarMenu();
            if (strConcepto == Conceptos.UNIFORMES.ToString())
            {
                gbDatos.Location = new System.Drawing.Point(16, 166);
                lbTalla.Visible = true;
                txTalla.Visible = true;
                this.Size = new System.Drawing.Size(569, 286);
            }
            else
            {
                gbDatos.Location = new System.Drawing.Point(16, 138);
                lbTalla.Visible = false;
                txTalla.Visible = false;
                this.Size = new System.Drawing.Size(569, 255);
            }

            comboProductos1.SqlQuery = $@"SELECT p.id_producto, p.descripcion, p.concepto, pc.fecha_vencimiento, pc.precio FROM productos p   
                                           INNER JOIN producto_ciclo pc ON pc.id_producto = p.id_producto   
                                           WHERE pc.id_ciclo = {basGlobals.iCiclo} AND pc.id_grupo in (4,{idGrupo}) AND p.concepto = '{strConcepto}'";
            comboProductos1.Inicializar();
        }

        private void GenerarMenu()
        {
            this.btNew.Visible = false;
            this.btDeshabilitar.Visible = false;
            this.btAcciones.Visible = false;
            this.btAddTutor.Visible = false;
            this.btDelete.Visible = false;
            this.btResetPass.Visible = false;
            this.btHabilitar.Visible = false;
            this.btDelete.Visible = false;

            if (basConfiguracion.Recargos)
            {
                this.btQuitarRecargo.Visible = true;
            }
            else
            {
                this.btQuitarRecargo.Visible = false;
            }
        }

        private bool ValidarYaCobrado()
        {
            using (var db = new DumontContext())
            {
                bool productoYaRegistrado = db.Movimientos
                .Where(m => m.id_matricula == idAlumno && m.id_ciclo == basGlobals.iCiclo && m.id_estatusmovimiento != 4)
                .SelectMany(m => m.MovimientosProductos)
                .Any(mp => mp.id_producto == comboProductos1.IdProductoSeleccionado);

                if (productoYaRegistrado) return productoYaRegistrado;

                productoYaRegistrado = basGlobals.listaProductos.Any(mp => mp.id_producto == comboProductos1.IdProductoSeleccionado);

                return productoYaRegistrado;
            }
        }

        private bool ValidarColegiaturaAnt()
        {
            using (var db = new DumontContext())
            {
                var producto = db.Productos.Find(comboProductos1.IdProductoSeleccionado);
                int productoAnterior = producto.id_producto_obligatorio ?? 0;

                if (productoAnterior == 0)
                {
                    return true;
                }

                bool productoYaRegistrado = db.Movimientos
                .Where(m => m.id_matricula == idAlumno && m.id_ciclo == basGlobals.iCiclo && m.id_estatusmovimiento != 4)
                .SelectMany(m => m.MovimientosProductos)
                .Any(mp => mp.id_producto == productoAnterior);

                if (productoYaRegistrado) return productoYaRegistrado;

                productoYaRegistrado = basGlobals.listaProductos.Any(mp => mp.id_producto == productoAnterior);

                return productoYaRegistrado;
            }
        }

        private void comboProductos1_OnCobroSeleccionado(DataRow obj)
        {

            nCantidad.Enabled = true;
            DateTime fechaVencimiento = Convert.ToDateTime(obj["fecha_vencimiento"]);
            txCosto.Text = Convert.ToDecimal(obj["precio"]).ToString("C");
            txFechaVencimiento.Text = Convert.ToDateTime(obj["fecha_vencimiento"]).ToString("dd/MM/yyyy");
            strConcepto = obj["concepto"].ToString();
            strProducto = obj["descripcion"].ToString();
            decPrecio = Convert.ToDecimal(obj["precio"]);
            DateTime fechaNuevaVencimiento = fechaVencimiento.AddDays(basConfiguracion.DiasTolerancia);

            if (basConfiguracion.Recargos)
            {
                if (DateTime.Now.Date > fechaNuevaVencimiento.Date)
                {
                    lbAtencion.Visible = true;
                    decRecargo = basConfiguracion.PorcentajeRecargo;
                    valuePromocion = (Convert.ToDecimal(obj["precio"]) * promocion / 100);
                    valueBeca = (Convert.ToDecimal(obj["precio"]) * beca / 100);
                    precioConBeca = Convert.ToDecimal(obj["precio"]) - valuePromocion - valueBeca;
                    txCosto.Text = Convert.ToDecimal(precioConBeca).ToString("C");
                    txRecargo.Text = (precioConBeca * decRecargo / 100).ToString("C");
                    txtTotal.Text = ((precioConBeca) + precioConBeca * decRecargo / 100).ToString("C");
                }
                else
                {
                    lbAtencion.Visible = false;
                    txtTotal.Text = (Convert.ToDecimal(obj["precio"])).ToString("C");
                    txRecargo.Text = (Convert.ToDecimal(0)).ToString("C");
                }
            }
            else
            {
                lbAtencion.Visible = false;
                txRecargo.Text = (Convert.ToDecimal(0)).ToString("C");
                txtTotal.Text = (Convert.ToDecimal(obj["precio"])).ToString("C");
            }
        }

        private void nCantidad_ValueChanged(object sender, EventArgs e)
        {
            if (basConfiguracion.Recargos)
            {
                txCosto.Text = (decPrecio * Convert.ToInt32(nCantidad.Value)).ToString("C");
                txtTotal.Text = (Convert.ToDecimal(txCosto.Text.Replace("$", "").Replace(",", "").Trim()) + Convert.ToDecimal(txRecargo.Text.Replace("$", "").Replace(",", "").Trim())).ToString("C");
            }
            else
            {
                txCosto.Text = (decPrecio * Convert.ToInt32(nCantidad.Value)).ToString("C");
                txtTotal.Text = (Convert.ToDecimal(txCosto.Text.Replace("$", "").Replace(",", "").Trim())).ToString("C");
            }
        }
    }
}
