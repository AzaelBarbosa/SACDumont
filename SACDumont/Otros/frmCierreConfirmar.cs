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
            CargarDatos();
            basFunctions.SelectAll(this);
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
