using SACDumont.Base;
using SACDumont.Controles;
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

namespace SACDumont.Cobros
{
    public partial class frmMovimientoCobro : frmBaseCatalogos
    {
        decimal importePendiente = 0;
        decimal importeFrente = 0;
        cobros movimientoCobros;
        protected override void Guardar()
        {
            // Implementar la lógica para guardar el movimiento  
            decimal total = 0;
            string rawText = txCosto.Text.Replace("$", "").Replace(",", "").Trim();
            decimal.TryParse(rawText, out total);

            if (total <= 0)
            {
                MessageBox.Show("El monto debe ser mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (total > importePendiente)
            {
                MessageBox.Show("El monto ingresado no puede ser mayor al importe pendiente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboCatalogos.IDValor == 0)
            {
                MessageBox.Show("Por favor seleccione el tipo de pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboCatalogos.IDValor == 3)
            {
                basConfiguracion.Transferencias = true;
            }

            movimientoCobros = new cobros
            {
                id_movimiento = 0,
                monto = total,
                tipopago = Convert.ToInt32(cboCatalogos.IDValor),
                descripcionPago = Convert.ToString(cboCatalogos.Descripcion)
            };

            basGlobals.listaCobros.Add(movimientoCobros);

            this.Close();
        }
        protected override void Cerrar()
        {
            this.Close();
        }

        public frmMovimientoCobro(decimal importePendiente)
        {
            InitializeComponent();
            this.importePendiente = importePendiente;
        }

        private void GenerarMenu()
        {
            this.btNew.Visible = false;
            this.btDeshabilitar.Visible = false;
            this.btHabilitar.Visible = false;
            this.btAcciones.Visible = false;
            this.btAddTutor.Visible = false;
            this.btDelete.Visible = false;
            this.btQuitarRecargo.Visible = false;
            this.btResetPass.Visible = false;
        }

        private void frmMovimientoCobro_Load(object sender, EventArgs e)
        {
            GenerarMenu();
            txtTotal.Text = importePendiente.ToString("C2");
            cboCatalogos.Inicializar();
        }

        private void txCosto_TextChanged(object sender, EventArgs e)
        {
            if (txCosto.Text == "")
            {
                importeFrente = 0;
                return;
            }
            else
            {
                importeFrente = Convert.ToDecimal(txCosto.Text.Replace("$", "").Replace(",", "").Trim());
            }
        }

        private void txCosto_Leave(object sender, EventArgs e)
        {
            txCosto.Text = importeFrente.ToString("C2");
        }
    }
}
