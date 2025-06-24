using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using SACDumont.Base;
using SACDumont.Controles;
using SACDumont.Models;
using SACDumont.modulos;
using SACDumont.Modulos;

namespace SACDumont.Cobros
{
    public partial class frmCobroProducto : frmBaseCatalogos
    {
        decimal decRecargo = basConfiguracion.PorcentajeRecargo;
        int idGrupo = 0;
        string strConcepto = "";
        string strConceptoProducto = "Producto";
        string strProducto = "Producto";
        decimal decPrecio = 0;
        basGlobals basGlobals = new basGlobals();
        movimiento_productos productos;
        protected override void Nuevo()
        {

        }
        protected override void Guardar()
        {
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
                    monto_recargo = Convert.ToDecimal(txRecargo.Text.Replace("$", "").Replace(",", "").Trim())
                };

                basGlobals.listaProductos.Add(productos);

                //basGlobals.dsMovimiento.Tables[1].Rows.Add(
                //    strConceptoProducto,
                //    strProducto,
                //    nCantidad.Value,
                //    0,
                //    total,
                //    Convert.ToDecimal(txRecargo.Text.Replace("$", "").Replace(",", "").Trim())
                //);
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
            using (var form = new Form())
            {
                form.Text = "Autorización";
                var label = new Label() { Text = "Ingrese el PIN de autorización del día:", Dock = DockStyle.Top };
                var textBox = new TextBox() { Dock = DockStyle.Top, PasswordChar = '*' };
                var buttonOk = new Button() { Text = "OK", Dock = DockStyle.Bottom };
                buttonOk.Click += (sender, e) => form.DialogResult = DialogResult.OK;
                form.Controls.Add(label);
                form.Controls.Add(textBox);
                form.Controls.Add(buttonOk);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    string pin = textBox.Text;
                    if (basFunctions.ValidarPin(pin))
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

        public frmCobroProducto(int idGrupo, string strConcepto)
        {
            InitializeComponent();
            this.idGrupo = idGrupo;
            this.strConcepto = strConcepto;
        }

        private void frmCobroProducto_Load(object sender, EventArgs e)
        {
            GenerarMenu();
            comboProductos1.SqlQuery = $@"SELECT p.id_producto, p.descripcion, p.concepto, pc.fecha_vencimiento, pc.precio FROM productos p   
                                           INNER JOIN producto_ciclo pc ON pc.id_producto = p.id_producto  
                                           LEFT JOIN movimiento_productos mp ON mp.id_producto = p.id_producto  
                                           LEFT JOIN movimientos m ON m.id_registros = mp.id_movimiento   
                                           WHERE pc.id_ciclo = {basGlobals.iCiclo} AND pc.id_grupo = {idGrupo} AND mp.id_producto IS NULL AND p.concepto = '{strConcepto}'";
            comboProductos1.Inicializar();
        }

        private void GenerarMenu()
        {
            this.btNew.Visible = false;
            this.btDeshabilitar.Visible = false;
            this.btAcciones.Visible = false;
            this.btAddTutor.Visible = false;
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

        private void comboProductos1_OnCobroSeleccionado(DataRow obj)
        {
            nCantidad.Enabled = true;
            DateTime fechaVencimiento = Convert.ToDateTime(obj["fecha_vencimiento"]);
            txCosto.Text = Convert.ToDecimal(obj["precio"]).ToString("C");
            txFechaVencimiento.Text = Convert.ToDateTime(obj["fecha_vencimiento"]).ToString("dd/MM/yyyy");
            strConcepto = obj["concepto"].ToString();
            strProducto = obj["descripcion"].ToString();
            decPrecio = Convert.ToDecimal(obj["precio"]);
            if (basConfiguracion.Recargos)
            {
                if (fechaVencimiento < DateTime.Now.AddDays(basConfiguracion.DiasTolerancia))
                {
                    lbAtencion.Visible = true;
                    decRecargo = basConfiguracion.PorcentajeRecargo;
                    txRecargo.Text = (Convert.ToDecimal(obj["precio"]) * decRecargo / 100).ToString("C");
                    txtTotal.Text = (Convert.ToDecimal(obj["precio"]) + Convert.ToDecimal(obj["precio"]) * decRecargo / 100).ToString("C");
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
