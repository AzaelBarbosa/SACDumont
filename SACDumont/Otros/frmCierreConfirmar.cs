using DocumentFormat.OpenXml.Wordprocessing;
using SACDumont.Base;
using SACDumont.Catalogos;
using SACDumont.Models;
using SACDumont.modulos;
using SACDumont.Modulos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SACDumont.Otros
{
    public partial class frmCierreConfirmar : frmBaseGeneral
    {
        #region Variables
        cierre_diario cierreDiario;
        decimal total = 0;
        #endregion

        #region Metdo Virtuales
        protected override void Guardar()
        {
            try
            {
                if (txEfectivo.Text != txEfectivoConfirmar.Text) { MessageBox.Show("No coinciden las cantidades de Efectivo", "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txTrasnfer.Text != txTrasnferConfirma.Text) { MessageBox.Show("No coinciden las cantidades de Transferencia", "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (txGasto.Text != txGastoConfirmar.Text) { MessageBox.Show("No coinciden las cantidades de Gastos", "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                using (var db = new DumontContext())
                {
                    cierreDiario = new cierre_diario
                    {
                        total = total,
                        fechaAlta = DateTime.Now,
                        fechacorte = DateTime.Now,
                        idUsuario = basConfiguracion.UserID,
                        B1000 = Convert.ToInt32(txB1000.Text),
                        B500 = Convert.ToInt32(txB500.Text),
                        B200 = Convert.ToInt32(txB200.Text),
                        B100 = Convert.ToInt32(txB100.Text),
                        B50 = Convert.ToInt32(txB50.Text),
                        B20 = Convert.ToInt32(txB20.Text),
                        M10 = Convert.ToInt32(txM10.Text),
                        M5 = Convert.ToInt32(txM5.Text),
                        M2 = Convert.ToInt32(txM2.Text),
                        M1 = Convert.ToInt32(txM1.Text),
                        M050 = Convert.ToInt32(txM050.Text)
                    };

                    db.CierreDiario.Add(cierreDiario);
                    db.Entry(cierreDiario).State = EntityState.Added;
                    var result = db.SaveChanges();
                    if (result > 0)
                    {
                        MessageBox.Show("Se ah efectuado el Cierre, ya no podra realizar movimientos.", "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        #region Metodos Privados
        private void CargarDatos()
        {
            try
            {
                using (var db = new DumontContext())
                {
                    var resultado = (from m in db.Movimientos
                                     join mp in db.MovimientoProductos on m.id_movimiento equals mp.id_movimiento
                                     join c in db.MovimientoCobros on m.id_movimiento equals c.id_movimiento into cobrosGroup
                                     from c in cobrosGroup.DefaultIfEmpty()
                                     join cat in db.Catalogos on new { valor = (int?)c.tipopago, tipo_catalogo = "TipoPago" }
                                                                equals new { valor = (int?)cat.valor, cat.tipo_catalogo } into catalogosGroup
                                     from cat in catalogosGroup.DefaultIfEmpty()
                                     where DbFunctions.TruncateTime(m.fechahora) == DbFunctions.TruncateTime(DateTime.Now)
                                     group c by cat.descripcion into g
                                     select new
                                     {
                                         Tipo = g.Key,
                                         Monto = g.Sum(x => x != null ? x.monto : 0)
                                     }).ToList();

                    if (resultado.Count() > 0)
                    {
                        txEfectivo.Text = (resultado[0].Monto - resultado[1].Monto).ToString("C2");
                        txGasto.Text = resultado[1].Monto.ToString("C2");
                        txTrasnfer.Text = resultado[2].Monto.ToString("C2");
                        txTotales.Text = ((resultado[0].Monto + resultado[2].Monto) - resultado[1].Monto).ToString("C2");
                        total = (resultado[0].Monto + resultado[2].Monto) - resultado[1].Monto;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
        public frmCierreConfirmar()
        {
            InitializeComponent();
        }

        private void frmCierreConfirmar_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void txEfectivoConfirmar_Validated(object sender, EventArgs e)
        {
            if (decimal.TryParse(txEfectivoConfirmar.Text, out decimal monto))
            {
                txEfectivoConfirmar.Text = monto.ToString("C2"); // C2 = Moneda con 2 decimales
            }
            else
            {
                txEfectivoConfirmar.Text = "0.00";
            }
        }

        private void txTrasnferConfirma_Validated(object sender, EventArgs e)
        {
            if (decimal.TryParse(txTrasnferConfirma.Text, out decimal monto))
            {
                txTrasnferConfirma.Text = monto.ToString("C2"); // C2 = Moneda con 2 decimales
            }
            else
            {
                txTrasnferConfirma.Text = "0.00";
            }
        }

        private void txGastoConfirmar_Validated(object sender, EventArgs e)
        {
            if (decimal.TryParse(txGastoConfirmar.Text, out decimal monto))
            {
                txGastoConfirmar.Text = monto.ToString("C2"); // C2 = Moneda con 2 decimales
            }
            else
            {
                txGastoConfirmar.Text = "0.00";
            }
        }

        private void txTotalesConfirmar_Validated(object sender, EventArgs e)
        {
            if (decimal.TryParse(txTotalesConfirmar.Text, out decimal monto))
            {
                txTotalesConfirmar.Text = monto.ToString("C2"); // C2 = Moneda con 2 decimales
            }
            else
            {
                txTotalesConfirmar.Text = "0.00";
            }
        }
    }
}
