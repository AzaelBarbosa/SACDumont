using SACDumont.Base;
using SACDumont.Models;
using SACDumont.modulos;
using SACDumont.Modulos;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SACDumont.Cobros
{
    public partial class frmMovimientoCobro : frmBaseCatalogos
    {
        decimal importePendiente = 0;
        int matricula = 0;
        decimal importeFrente = 0;
        decimal saldoFavor = 0;
        cobros movimientoCobros;
        protected override void Guardar()
        {
            // Implementar la lógica para guardar el movimiento  
            decimal total = 0;
            decimal saldo = 0;
            string rawText = txCosto.Text.Replace("$", "").Replace(",", "").Trim();
            decimal.TryParse(rawText, out total);
            string rawSaldo = txSaldoFavor.Text.Replace("$", "").Replace(",", "").Trim();
            decimal.TryParse(rawSaldo, out saldo);

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
            if (cboCatalogos.IDValor == (int)TipoPago.SaldoFavor)
            {
                if (total > saldo)
                {
                    MessageBox.Show("No cuenta con el suficiente saldo a favor para el monto ingresado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
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
                descripcionPago = Convert.ToString(cboCatalogos.Descripcion),
                fechaAlta = DateTime.Now,
                pago_por = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txRealizado.Text.ToLower()),
                no_cobro = VerificarNoPago(DateTime.Now),
            };

            basGlobals.listaCobros.Add(movimientoCobros);

            this.Close();
        }
        protected override void Cerrar()
        {
            this.Close();
        }

        public frmMovimientoCobro(decimal importePendiente, int matricula)
        {
            InitializeComponent();
            this.importePendiente = importePendiente;
            this.matricula = matricula;
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

        



        private void VerificaSaldoFavor()
        {
            using (var db = new DumontContext())
            {
                var saldoUsado = basGlobals.listaCobros.Where(lc => lc.tipopago == (int)TipoPago.SaldoFavor).Sum(lc => lc.monto);
                var saldo = db.SaldoFavor.Where(sf => sf.Matricula == matricula && sf.IdCiclo == basGlobals.iCiclo).FirstOrDefault();
                if (saldo != null)
                {
                    txSaldoFavor.Text = (saldo.Saldo - saldoUsado).ToString("C2");
                    saldoFavor = saldo.Saldo - saldoUsado;
                }
                else
                {
                    txSaldoFavor.Text = "0";
                    saldoFavor = 0;
                }
            }
        }

        private void frmMovimientoCobro_Load(object sender, EventArgs e)
        {
            GenerarMenu();
            txtTotal.Text = importePendiente.ToString("C2");
            cboCatalogos.Inicializar();
            basFunctions.SelectAll(this);
            VerificaSaldoFavor();
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

        private void txRealizado_Leave(object sender, EventArgs e)
        {
            txRealizado.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo
    .ToTitleCase(txRealizado.Text.ToLower());
        }

        private int VerificarNoPago(DateTime fecha)
        {
            // Si la lista está vacía, el primer NoPago es 1
            if (basGlobals.listaCobros == null || basGlobals.listaCobros.Count == 0)
                return 1;

            // Buscar el último cobro registrado
            var ultimoCobro = basGlobals.listaCobros.OrderByDescending(c => c.id_cobro).FirstOrDefault();
            if (ultimoCobro == null)
                return 1;

            // Si la fecha es la misma que el último cobro, usar el mismo NoPago
            if (ultimoCobro.fechaAlta.HasValue && ultimoCobro.fechaAlta.Value.Date == fecha.Date)
                return ultimoCobro.no_cobro;

            // Si la fecha es distinta, incrementar el NoPago en 1
            return ultimoCobro.no_cobro + 1;
        }
    }
}
