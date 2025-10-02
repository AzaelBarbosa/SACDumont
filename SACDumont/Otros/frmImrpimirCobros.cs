using FastReport;
using FastReport.Export.PdfSimple;
using SACDumont.Dtos;
using SACDumont.Models;
using SACDumont.modulos;
using SACDumont.Modulos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SACDumont.Otros
{
    public partial class frmImrpimirCobros : Form
    {
        public int idMovimiento = 0;
        public string strConcepto = string.Empty;
        int idCobro = 0;
        int noCobro = 0;
        string nameReporte = string.Empty;
        List<cobros> movCobros = new List<cobros>();
        List<CobrosDTO> cobrosDTOs = new List<CobrosDTO>();

        public frmImrpimirCobros()
        {
            InitializeComponent();
        }

        private void frmImrpimirCobros_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            using (var db = new DumontContext())
            {

                cobrosDTOs = db.MovimientoCobros.Where(mc => mc.id_movimiento == idMovimiento).Select(t => new CobrosDTO
                {
                    IdCobro = t.id_cobro,
                    IdMovimiento = t.id_movimiento,
                    FechaCobro = t.fechaAlta.HasValue ? t.fechaAlta.Value : DateTime.MinValue,
                    Monto = t.monto,
                    MetodoPago = db.Catalogos.Where(c => c.tipo_catalogo == "TipoPago" && c.valor == t.tipopago).Select(c => c.descripcion).FirstOrDefault(),
                    PagoPor = t.pago_por,
                    NumeroCobro = t.no_cobro
                }).ToList();
            }

            CargarGrid();
        }

        private void CargarGrid()
        {
            dgvCobros.DataSource = cobrosDTOs;

            dgvCobros.Columns["IdCobro"].Visible = false;
            dgvCobros.Columns["IdMovimiento"].Visible = false;
            dgvCobros.Columns["Referencia"].Visible = false;
            dgvCobros.Columns["FechaCobro"].HeaderText = "Fecha Cobro";
            dgvCobros.Columns["MetodoPago"].HeaderText = "Metodo Pago";
            dgvCobros.Columns["PagoPor"].HeaderText = "Pago Por";
            dgvCobros.Columns["Monto"].DefaultCellStyle.Format = "C2";
        }

        private void dgvCobros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtener la fila
                DataGridViewRow fila = dgvCobros.Rows[e.RowIndex];

                // Obtener el valor de la columna "ID" (puedes usar el índice también)
                idCobro = (int)fila.Cells["IdCobro"].Value;
                noCobro = (int)fila.Cells["NumeroCobro"].Value;
            }
        }

        private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (noCobro > 1)
            {
                nameReporte = "TicketAbono.frx";
                ExportareImprimirSinAbrir();
            }
            else 
            {
                nameReporte = "TicketMovimient.frx";
                ExportareImprimirSinAbrir();
            }
        }

        private void btTicketImpresora_Click(object sender, EventArgs e)
        {

        }

        private void ExportarYMostrarPDF()
        {
            if (idMovimiento == 0) return;

            DataTable dataTable = new DataTable();
            Movimientos mov = new Movimientos();
            Inscripciones ins = new Inscripciones();
            List<ReportesDTO> reportesDTO = new List<ReportesDTO>();
            using (var db = new DumontContext())
            {
                mov = db.Movimientos.Find(idMovimiento);
                ins = db.Inscripciones.Where(i => i.matricula == mov.id_matricula && i.id_ciclo == basGlobals.iCiclo).FirstOrDefault();

                var lista = db.Movimientos
                    .Where(m => m.id_movimiento == idMovimiento)
                    .Include(m => m.MovimientosProductos)
                    .Include(m => m.MovimientosCobros)
                    .SelectMany(m => m.MovimientosProductos, (m, mp) => new ReportesDTO
                    {
                        Producto = db.Productos.Where(p => p.id_producto == mp.id_producto).Select(p => p.descripcion).FirstOrDefault(),
                        Cantidad = mp.cantidad,
                        PrecioUnitario = mp.monto,
                        Total = mp.monto + mp.monto_recargo,
                        Recargo = mp.monto_recargo,
                        Folio = m.id_movimiento,
                        Fecha = m.fechahora,
                        Grado = db.Catalogos.Where(c => c.valor == ins.id_grado && c.tipo_catalogo == "Grado").Select(c => c.descripcion).FirstOrDefault(),
                        Matricula = m.id_matricula,
                        Alumno = db.Alumnos
                                    .Where(a => a.matricula == m.id_matricula)
                                    .Select(a => a.appaterno + " " + a.apmaterno + " " + a.nombre)
                                    .FirstOrDefault(),
                        MontoPendiente = m.montoTotal - db.MovimientoCobros.Where(mc => mc.id_movimiento == m.id_movimiento).Sum(mc => mc.monto),
                        MontoPagado = db.MovimientoCobros.Where(mc => mc.id_movimiento == m.id_movimiento).Sum(mc => mc.monto),
                        PagadoPor = db.MovimientoCobros.Where(mc => mc.id_movimiento == m.id_movimiento).Select(mc => mc.pago_por).FirstOrDefault()
                    })
                    .ToList();

                reportesDTO = lista;
            }

            dataTable = basFunctions.ConvertToDataTable(reportesDTO);
            // 2. Cargar el reporte
            string rutaFrx = Path.Combine(Application.StartupPath, "Reportes", "TicketMovimientoImpresora.frx");
            Report report = new Report();
            report.Load(rutaFrx);

            report.SetParameterValue("pFolio", reportesDTO[0].Folio);
            report.SetParameterValue("pFecha", reportesDTO[0].Fecha);
            report.SetParameterValue("pGrupo", reportesDTO[0].Grupo);
            report.SetParameterValue("pGrado", reportesDTO[0].Grado);
            report.SetParameterValue("pMatricula", reportesDTO[0].Matricula);
            report.SetParameterValue("pAlumno", reportesDTO[0].Alumno);
            if (!mov.confirmado)
            {
                report.SetParameterValue("pPendienteConfirmar", "Pendiente de Confirmar");
            }
            else
            {
                report.SetParameterValue("pPendienteConfirmar", "");
            }

            report.RegisterData(dataTable, "TicketData");
            report.GetDataSource("TicketData").Enabled = true;

            // 3. Forzar carga de Microsoft.CSharp
            System.Runtime.CompilerServices.RuntimeHelpers
                .RunClassConstructor(typeof(Microsoft.CSharp.RuntimeBinder.Binder).TypeHandle);

            // 4. Preparar y exportar
            report.Prepare();
            string rutaPDF = Path.Combine(Application.StartupPath, "Ticket.pdf");
            report.Export(new PDFSimpleExport(), rutaPDF);


            // 5. Abrir visor PDF predeterminado
            Process.Start(new ProcessStartInfo
            {
                FileName = rutaPDF,
                UseShellExecute = true
            });
        }

        private void ExportareImprimirSinAbrir()
        {
            if (idMovimiento == 0) return;

            DataTable dataTable = new DataTable();
            Movimientos mov = new Movimientos();
            Inscripciones ins = new Inscripciones();
            List<ReportesDTO> reportesDTO = new List<ReportesDTO>();
            using (var db = new DumontContext())
            {
                mov = db.Movimientos.Find(idMovimiento);
                ins = db.Inscripciones.Where(i => i.matricula == mov.id_matricula && i.id_ciclo == basGlobals.iCiclo).FirstOrDefault();

                var lista = db.Movimientos
                    .Where(m => m.id_movimiento == idMovimiento)
                    .Include(m => m.MovimientosProductos)
                    .Include(m => m.MovimientosCobros)
                    .SelectMany(m => m.MovimientosProductos, (m, mp) => new ReportesDTO
                    {
                        Producto = noCobro == 1 ? db.Productos.Where(p => p.id_producto == mp.id_producto).Select(p => p.descripcion).FirstOrDefault() : "" ,
                        Cantidad = mp.cantidad,
                        PrecioUnitario = mp.monto,
                        Total = noCobro == 1 ? mp.monto + mp.monto_recargo : m.montoTotal - db.MovimientoCobros.Where(mc => mc.no_cobro < noCobro && mc.id_movimiento == m.id_movimiento).Sum(mc => mc.monto),
                        Recargo = mp.monto_recargo,
                        Folio = m.id_movimiento,
                        Fecha = noCobro == 1 ? m.fechahora : (DateTime)db.MovimientoCobros.Where(mc => mc.id_cobro == idCobro).Select(mc => mc.fechaAlta).FirstOrDefault(),
                        Grado = db.Catalogos.Where(c => c.valor == ins.id_grado && c.tipo_catalogo == "Grado").Select(c => c.descripcion).FirstOrDefault(),
                        Matricula = m.id_matricula,
                        Alumno = db.Alumnos
                                    .Where(a => a.matricula == m.id_matricula)
                                    .Select(a => a.appaterno + " " + a.apmaterno + " " + a.nombre)
                                    .FirstOrDefault(),
                        MontoPendiente = noCobro == 1 ? m.montoTotal - db.MovimientoCobros.Where(mc => mc.id_movimiento == m.id_movimiento).Sum(mc => mc.monto) : m.montoTotal - db.MovimientoCobros.Where(mc => mc.no_cobro <= noCobro && mc.id_movimiento == m.id_movimiento).Sum(mc => mc.monto),
                        MontoPagado = noCobro == 1 ? db.MovimientoCobros.Where(mc => mc.id_movimiento == m.id_movimiento).Sum(mc => mc.monto) : db.MovimientoCobros.Where(mc => mc.id_cobro == idCobro).Sum(mc => mc.monto),
                        PagadoPor = noCobro == 1 ? db.MovimientoCobros.Where(mc => mc.id_movimiento == m.id_movimiento).Select(mc => mc.pago_por).FirstOrDefault() : db.MovimientoCobros.Where(mc => mc.id_cobro == idCobro).Select(mc => mc.pago_por).FirstOrDefault(),
                        NoPago = noCobro,
                        Talla = mp.talla
                    })
                    .ToList();

                reportesDTO = lista;
            }

            if (strConcepto == Conceptos.UNIFORMES.ToString())
            {
                foreach (var item in reportesDTO)
                {
                    item.Producto = basFunctions.TextoUniformes(item.Producto, item.Talla, strConcepto);
                }
            }

            dataTable = basFunctions.ConvertToDataTable(reportesDTO);
            // 2. Cargar el reporte
            string rutaFrx = Path.Combine(Application.StartupPath, "Reportes", nameReporte);
            Report report = new Report();
            report.Load(rutaFrx);

            report.SetParameterValue("pFolio", reportesDTO[0].Folio);
            report.SetParameterValue("pFecha", reportesDTO[0].Fecha);
            report.SetParameterValue("pGrupo", reportesDTO[0].Grupo);
            report.SetParameterValue("pGrado", reportesDTO[0].Grado);
            report.SetParameterValue("pMatricula", reportesDTO[0].Matricula);
            report.SetParameterValue("pAlumno", reportesDTO[0].Alumno);
            if (!mov.confirmado)
            {
                report.SetParameterValue("pPendienteConfirmar", "Pendiente de Confirmar");
            }
            else
            {
                report.SetParameterValue("pPendienteConfirmar", "");
            }

            report.RegisterData(dataTable, "TicketData");
            report.GetDataSource("TicketData").Enabled = true;

            // 3. Forzar carga de Microsoft.CSharp
            System.Runtime.CompilerServices.RuntimeHelpers
                .RunClassConstructor(typeof(Microsoft.CSharp.RuntimeBinder.Binder).TypeHandle);

            // 4. Preparar y exportar
            report.Prepare();
            string rutaPDF = Path.Combine(Application.StartupPath, $"{reportesDTO[0].Folio}.pdf");
            report.Export(new PDFSimpleExport(), rutaPDF);

            string rutaSumatra = Path.Combine(Application.StartupPath, "PDF", "SumatraPDF.exe");

            if (!File.Exists(rutaSumatra))
            {
                MessageBox.Show("No se encontró SumatraPDF.exe. Asegúrate de colocarlo junto a la aplicación.");
                return;
            }

            var nombreImpresora = basConfiguracion.PrinterTiockets;
            var psi = new ProcessStartInfo
            {
                FileName = rutaSumatra, // ← usar el ejecutable de SumatraPDF
                Arguments = nombreImpresora == ""
                    ? $"-print-settings 2 -print-to-default \"{rutaPDF}\""
                    : $"-print-settings 2 -print-to \"{nombreImpresora}\" \"{rutaPDF}\"",
                CreateNoWindow = true,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            try
            {
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar SumatraPDF: " + ex.Message);
            }
        }
    }
}
