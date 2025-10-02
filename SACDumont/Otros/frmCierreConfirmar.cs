using SACDumont.Base;
using SACDumont.Models;
using SACDumont.Modulos;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
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
                        PreparaReporte();
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
                decimal cero = 0;
                using (var db = new DumontContext())
                {
                    //var resultado = db.Movimientos.Include(m => m.MovimientosCobros).Where(m => DbFunctions.TruncateTime(m.fechahora) == DbFunctions.TruncateTime(DateTime.Now))
                    //                            .SelectMany(m => m.MovimientosCobros)
                    //                            .Select(c => new CierreDTO
                    //                            {
                    //                                Tipo = db.Catalogos.Where(ca => ca.tipo_catalogo == "TipoPago" && ca.valor == c.tipopago).Select(ca => ca.descripcion).FirstOrDefault(),   // 👈 descripción desde catálogo
                    //                                Monto = c.monto
                    //                            })
                    //                            .ToList();


                    var resultado = (from m in db.Movimientos
                                     join c in db.MovimientoCobros on m.id_movimiento equals c.id_movimiento into cobrosGroup
                                     from c in cobrosGroup.DefaultIfEmpty()
                                     join cat in db.Catalogos on new { valor = (int?)c.tipopago, tipo_catalogo = "TipoPago" }
                                                                equals new { valor = (int?)cat.valor, cat.tipo_catalogo } into catalogosGroup
                                     from cat in catalogosGroup.DefaultIfEmpty()
                                     where DbFunctions.TruncateTime(m.fechahora) == DbFunctions.TruncateTime(DateTime.Now)
                                     && m.id_estatusmovimiento != 4
                                     group c by cat.descripcion into g
                                     select new
                                     {
                                         Tipo = g.Key,
                                         Monto = g.Sum(x => x != null ? x.monto : 0)
                                     }).ToList();

                    if (resultado.Count() == 0)
                    {
                        txEfectivo.Text = cero.ToString("C2");
                        txGasto.Text = cero.ToString("C2");
                        txTrasnfer.Text = cero.ToString("C2");
                        txTotales.Text = cero.ToString("C2");
                        total = cero;
                    }
                    if (resultado.Count() == 1)
                    {
                        txEfectivo.Text = (resultado[0].Monto).ToString("C2");
                        txGasto.Text = cero.ToString("C2");
                        txTrasnfer.Text = cero.ToString("C2");
                        txTotales.Text = ((resultado[0].Monto + cero) - cero).ToString("C2");
                        total = (resultado[0].Monto + cero) - cero;
                    }
                    else if (resultado.Count() == 2)
                    {
                        txEfectivo.Text = (resultado[0].Monto).ToString("C2");
                        txGasto.Text = resultado[1].Monto.ToString("C2");
                        txTrasnfer.Text = cero.ToString("C2");
                        txTotales.Text = ((resultado[0].Monto + cero) - resultado[1].Monto).ToString("C2");
                        total = (resultado[0].Monto + cero) - resultado[1].Monto;
                    }
                    else if (resultado.Count() == 3)
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

        private void PreparaReporte()
        {
            using (var db = new DumontContext())
            {
                var resumen = (from m in db.Movimientos
                               join c in db.MovimientoCobros on m.id_movimiento equals c.id_movimiento into cobrosGroup
                               from c in cobrosGroup.DefaultIfEmpty()
                               join cat in db.Catalogos on new { valor = (int?)c.tipopago, tipo_catalogo = "TipoPago" }
                                                          equals new { valor = (int?)cat.valor, cat.tipo_catalogo } into catalogosGroup
                               from cat in catalogosGroup.DefaultIfEmpty()
                               where DbFunctions.TruncateTime(m.fechahora) == DbFunctions.TruncateTime(DateTime.Now) && m.id_estatusmovimiento != 4
                               group c by cat.descripcion into g
                               select new
                               {
                                   Tipo = g.Key,
                                   Monto = g.Sum(x => x != null ? x.monto : 0)
                               }).ToList();

                var billetes = db.CierreDiario
                                 .Where(cd => DbFunctions.TruncateTime(cd.fechacorte) == DbFunctions.TruncateTime(DateTime.Now))
                                 .Select(cd => new
                                 {
                                     cd.B1000,
                                     cd.B500,
                                     cd.B200,
                                     cd.B100,
                                     cd.B50,
                                     cd.B20,
                                     cd.M10,
                                     cd.M5,
                                     cd.M2,
                                     cd.M1,
                                     cd.M050,
                                     cd.fechacorte
                                 })
                                 .ToList();

                var detalles = (from m in db.Movimientos
                                join mp in db.MovimientoProductos on m.id_movimiento equals mp.id_movimiento into mpGroup
                                from mp in mpGroup.DefaultIfEmpty()

                                join p in db.Productos on mp.id_producto equals p.id_producto into pGroup
                                from p in pGroup.DefaultIfEmpty()

                                join c in db.MovimientoCobros on m.id_movimiento equals c.id_movimiento into cGroup
                                from c in cGroup.DefaultIfEmpty()

                                join a in db.Alumnos on m.id_matricula equals a.matricula into aGroup
                                from a in aGroup.DefaultIfEmpty()

                                where DbFunctions.TruncateTime(m.fechahora) == DbFunctions.TruncateTime(DateTime.Now)
                                && m.id_estatusmovimiento != 4

                                group new { c, mp, p, a } by new
                                {
                                    Alumno = (a.appaterno ?? "") + " " + (a.apmaterno ?? "") + " " + (a.nombre ?? ""),
                                    Concepto = p.concepto,
                                    MotivoGasto = mp.descripcion,
                                    Monto = c.monto,
                                    Folio = m.id_movimiento
                                } into g

                                select new
                                {
                                    Alumno = (g.Key.Alumno == null || g.Key.Alumno.Trim() == "") ? "GASTO" : g.Key.Alumno,
                                    Concepto = g.Key.Concepto,
                                    MotivoGasto = g.Key.MotivoGasto ?? "",
                                    Monto = g.Key.Monto,
                                    Folio = g.Key.Folio
                                }).ToList();

                basFunctions.ExportarYMostrarPDF3DT("CierreDiario.frx", basFunctions.ConvertToDataTable(resumen), basFunctions.ConvertToDataTable(detalles), basFunctions.ConvertToDataTable(billetes), "Resumen", "Detalle", "Billetes");

            }
        }
        #endregion
        public frmCierreConfirmar()
        {
            InitializeComponent();
        }

        private void frmCierreConfirmar_Load(object sender, EventArgs e)
        {
            WireQty(txB1000, 1000);
            WireQty(txB500, 500);
            WireQty(txB200, 200);
            WireQty(txB100, 100);
            WireQty(txB50, 50);
            WireQty(txB20, 20);
            WireQty(txM10, 10);
            WireQty(txM5, 5);
            WireQty(txM2, 2);
            WireQty(txM1, 1);

            TxtQty(txB1000);
            TxtQty(txB500);
            TxtQty(txB200);
            TxtQty(txB100);
            TxtQty(txB50);
            TxtQty(txB20);
            TxtQty(txM10);
            TxtQty(txM5);
            TxtQty(txM2);
            TxtQty(txM1);
            TxtQty(txM050);

            CargarDatos();
            basFunctions.SelectAll(this);
        }

        private void WireQty(TextBox qtyTextBox, int denominacion)
        {
            qtyTextBox.Tag = denominacion;                 // guarda la denominación
            qtyTextBox.TextChanged += Qty_TextChanged;     // mismo handler para todas
        }

        private void TxtQty(TextBox qtyTextBox)
        {
            qtyTextBox.Validated += Qty_Validated;     // mismo handler para todas
        }

        private void Qty_Validated(object sender, EventArgs e)
        {
            var qtyBox = (TextBox)sender;
            if (int.TryParse(qtyBox.Text, out int qty))
            {
                qtyBox.Text = qty.ToString(); // C2 = Moneda con 2 decimales
            }
            else
            {
                qtyBox.Text = "0";
            }
        }

        private void Qty_TextChanged(object sender, EventArgs e)
        {
            var qtyBox = (TextBox)sender;
            int denom = (int)qtyBox.Tag;

            // Parse seguro (vacío o no numérico -> 0)
            if (!int.TryParse(qtyBox.Text, out int qty)) qty = 0;

            decimal importe = denom * qty;

            // Busca el TextBox de importe correspondiente por nombre: txCash{denom}
            var impBox = this.Controls.Find($"txCash{denom}", true).FirstOrDefault() as TextBox;
            if (impBox != null)
                impBox.Text = importe.ToString("N2");      // formateado con 2 decimales

            RecalcularTotal();
        }

        private void RecalcularTotal()
        {
            decimal total = 0m;

            // Suma todos los txtImp...
            total += ParseImporte(txCash1000);
            total += ParseImporte(txCash500);
            total += ParseImporte(txCash200);
            total += ParseImporte(txCash100);
            total += ParseImporte(txCash50);
            total += ParseImporte(txCash20);
            total += ParseImporte(txCash10);
            total += ParseImporte(txCash5);
            total += ParseImporte(txCash2);
            total += ParseImporte(txCash1);
            total += ParseImporte(txCash050);
            // agrega los que tengas

            txBilletes.Text = total.ToString("C2");          // donde quieres mostrar el total
        }

        private decimal ParseImporte(TextBox impBox)
        {
            return decimal.TryParse(impBox.Text, out decimal v) ? v: 0m;
        }


        private void txEfectivoConfirmar_Validated(object sender, EventArgs e)
        {
            if (decimal.TryParse(txEfectivoConfirmar.Text, out decimal monto))
            {
                txEfectivoConfirmar.Text = monto.ToString("C2"); // C2 = Moneda con 2 decimales
            }
            else
            {
                txEfectivoConfirmar.Text = "$0.00";
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
                txTrasnferConfirma.Text = "$0.00";
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
                txGastoConfirmar.Text = "$0.00";
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
                txTotalesConfirmar.Text = "$0.00";
            }
        }

        private void txB1000_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
