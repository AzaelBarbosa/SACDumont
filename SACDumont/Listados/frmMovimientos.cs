using FastReport;
using FastReport.Export.PdfSimple;
using SACDumont.Base;
using SACDumont.Catalogos;
using SACDumont.Clases;
using SACDumont.Cobros;
using SACDumont.modulos;
using SACDumont.Modulos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.CSharp;

namespace SACDumont.Listados
{
    public partial class frmMovimientos : frmListados
    {
        #region Variables
        DataTable dtMovimientos = new DataTable("Movimientos");
        basGlobals basGlobals = new basGlobals();
        int idCiclo = basConfiguracion.IdCiclo;
        int tipoMovimiento = basGlobals.tipoMovimiento;
        int estatusMovimiento = basGlobals.estatusMovimiento;
        basSql sql = new basSql();
        #endregion

        #region Propiedades
        protected override void Nuevo()
        {
            frmMovimiento frmMovimiento = new frmMovimiento(0);
            frmMovimiento.ShowDialog();
            CargarMovimientos();
        }
        protected override void Guardar()
        {
            // Implementar la lógica para guardar el movimiento
        }
        protected override void Eliminar()
        {
            // Implementar la lógica para eliminar el movimiento
        }
        protected override void Imprimir()
        {
            // Implementar la lógica para imprimir el listado de movimientos
            ExportareImprimirSinAbrir();
        }
        protected override void Cerrar()
        {
            this.Close();
        }
        #endregion

        #region Eventos
        private void CargarMovimientos()
        {
            dtMovimientos = sqlServer.ExecSQLReturnDT($@"SELECT m.id_registros ,m.fechahora AS Fecha, p.descripcion AS Producto, a.apmaterno + ' ' + a.apmaterno + ' ' + a.nombre AS Alumno, cat.descripcion AS Grado, catG.descripcion AS Grupo, 
                                                        m.montoTotal AS Total, m.montoTotal - (SELECT SUM(monto) FROM cobros WHERE id_movimiento = m.id_registros) AS MontoPendiente, m.porcentaje_descuento AS Descuento, m.monto_descuento AS MontoDescuento, m.beca_descuento AS BecaDescuento,
                                                        catE.descripcion AS Estatus
                                                        FROM movimientos m
                                                        INNER JOIN movimiento_productos mp ON m.id_registros = mp.id_movimiento
                                                        INNER JOIN productos p ON p.id_producto = mp.id_producto
                                                        INNER JOIN alumnos a ON a.matricula = m.id_matricula
                                                        INNER JOIN inscripciones i ON i.matricula = a.matricula
                                                        LEFT JOIN catalogos cat ON cat.valor = i.id_grado AND cat.tipo_catalogo = 'Grado' 
                                                        LEFT JOIN catalogos catG ON catG.valor = i.id_grupo AND catG.tipo_catalogo = 'Grupo'
                                                        LEFT JOIN catalogos catE ON catE.valor = m.id_estatusmovimiento AND catE.tipo_catalogo = 'EstatusMovimiento'
                                                        WHERE m.id_ciclo = {basGlobals.iCiclo} AND p.concepto = '{basGlobals.sConcepto}'", "Movimientos");
            dgvMovimientos.DataSource = dtMovimientos;
            FormatGrid();
            dgvMovimientos.Refresh();
        }

        private void FormatGrid()
        {
            dgvMovimientos.Columns["id_registros"].Visible = false;
            dgvMovimientos.Columns["Fecha"].HeaderText = "Fecha";
            dgvMovimientos.Columns["Alumno"].HeaderText = "Alumno";
            dgvMovimientos.Columns["Grado"].HeaderText = "Grado";
            dgvMovimientos.Columns["Grupo"].HeaderText = "Grupo";
            dgvMovimientos.Columns["MontoPendiente"].HeaderText = "Monto Pendiente";
            dgvMovimientos.Columns["MontoPendiente"].DefaultCellStyle.Format = "C2";
            dgvMovimientos.Columns["Total"].HeaderText = "Total";
            dgvMovimientos.Columns["Total"].DefaultCellStyle.Format = "C2";
            dgvMovimientos.Columns["Estatus"].HeaderText = "Estatus";
            dgvMovimientos.Columns["Producto"].HeaderText = "Producto";
            dgvMovimientos.Columns["Descuento"].HeaderText = "Descuento";
            dgvMovimientos.Columns["Descuento"].DefaultCellStyle.Format = "P0";
            dgvMovimientos.Columns["MontoDescuento"].HeaderText = "Monto Descuento";
            dgvMovimientos.Columns["MontoDescuento"].DefaultCellStyle.Format = "C2";
            dgvMovimientos.Columns["BecaDescuento"].HeaderText = "Beca Descuento";
            dgvMovimientos.Columns["BecaDescuento"].DefaultCellStyle.Format = "C2";

            dgvMovimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMovimientos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvMovimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMovimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovimientos.MultiSelect = false;
        }
        private void CargarMenu()
        {
            guardarToolStripMenuItem.Visible = false;
        }
        public frmMovimientos()
        {
            InitializeComponent();
        }

        private void frmMovimientos_Load(object sender, EventArgs e)
        {
            CargarMenu();
            CargarMovimientos();
        }

        private void dgvMovimientos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = ((DataRowView)dgvMovimientos.SelectedRows[0].DataBoundItem).Row;
           
            if (dgvMovimientos.SelectedRows.Count == 0) return;
            {
                //DataSet ds = sql.GetMovimientoDetalle(Convert.ToInt32(row["id_registros"].ToString()));
                frmMovimiento frm = new frmMovimiento((int)row["id_registros"]);
                frm.ShowDialog();
                CargarMovimientos();
            }
        }

        private void dgvMovimientos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvMovimientos.Columns[e.ColumnIndex].Name == "Estatus" && e.Value != null)
            {
                string estatus = e.Value.ToString();

                switch (estatus)
                {
                    case "Cancelado":
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.BackColor = Color.LightPink;
                        break;
                    case "Pendiente":
                        e.CellStyle.ForeColor = Color.Orange;
                        e.CellStyle.BackColor = Color.LightYellow;
                        break;
                    case "Liquidado":
                        e.CellStyle.ForeColor = Color.Green;
                        e.CellStyle.BackColor = Color.LightGreen;
                        break;
                    case "Abono":
                        e.CellStyle.ForeColor = Color.Blue;
                        e.CellStyle.BackColor = Color.LightBlue;
                        break;
                }
            }
            if (dgvMovimientos.Columns[e.ColumnIndex].Name == "MontoPendiente" && e.Value != null)
            {
                decimal decMonto  = (decimal)e.Value;

                if (decMonto > 0)
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void MostrarReporte()
        {
            // 1. Crear el DataTable con los datos del ticket
            DataTable dt = new DataTable("TicketData");
            dt.Columns.Add("Producto", typeof(string));
            dt.Columns.Add("Cantidad", typeof(int));
            dt.Columns.Add("PrecioUnitario", typeof(decimal));
            dt.Columns.Add("Total", typeof(decimal));

            // 2. Agregar datos de ejemplo (puedes reemplazar por tu lógica real)
            dt.Rows.Add("Inscripción", 1, 500, 500);
            dt.Rows.Add("Cuota Septiembre", 1, 800, 800);
            dt.Rows.Add("Uniforme", 2, 300, 600);

            // 3. Cargar el reporte
            Report report = new Report();
            report.Load(@"C:\Ruta\al\archivo\TicketDataSource_Only.frx"); // ⚠️ Ajusta la ruta

            // 4. Registrar el DataTable
            report.RegisterData(dt, "TicketData");

            // 5. Habilitar el datasource (si no tiene diseño aún)
            report.GetDataSource("TicketData").Enabled = true;

            // 6. Mostrar el reporte
            report.Save(@"C:\Ruta\al\archivo\TicketDataSource_Only.frx"); // ⚠️ Ajusta la ruta
        }

        private void ExportarYMostrarPDF()
        {
            // 1. Crear DataTable
            DataTable dt = new DataTable("TicketData");
            dt.Columns.Add("Producto", typeof(string));
            dt.Columns.Add("Cantidad", typeof(int));
            dt.Columns.Add("PrecioUnitario", typeof(decimal));
            dt.Columns.Add("Total", typeof(decimal));
            dt.Columns.Add("Recargo", typeof(decimal));
            dt.Rows.Add("Inscripción", 1, 500, 600, 100);
            dt.Rows.Add("Cuota Septiembre", 1, 800, 800, 0);
            dt.Rows.Add("Uniforme", 2, 300, 600, 0);

            // 2. Cargar el reporte
            string rutaFrx = Path.Combine(Application.StartupPath, "Reportes", "TicketMovimient.frx");
            Report report = new Report();
            report.Load(rutaFrx);
            report.RegisterData(dt, "TicketData");
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
            // 1. Crear DataTable
            DataTable dt = new DataTable("TicketData");
            dt.Columns.Add("Producto", typeof(string));
            dt.Columns.Add("Cantidad", typeof(int));
            dt.Columns.Add("PrecioUnitario", typeof(decimal));
            dt.Columns.Add("Total", typeof(decimal));
            dt.Columns.Add("Recargo", typeof(decimal));
            dt.Rows.Add("Inscripción", 1, 500, 600, 100);
            dt.Rows.Add("Cuota Septiembre", 1, 800, 800, 0);
            dt.Rows.Add("Uniforme", 2, 300, 600, 0);

            // 2. Cargar el reporte
            string rutaFrx = Path.Combine(Application.StartupPath, "Reportes", "TicketMovimient.frx");
            Report report = new Report();
            report.Load(rutaFrx);
            report.RegisterData(dt, "TicketData");
            report.GetDataSource("TicketData").Enabled = true;

            // 3. Forzar carga de Microsoft.CSharp
            System.Runtime.CompilerServices.RuntimeHelpers
                .RunClassConstructor(typeof(Microsoft.CSharp.RuntimeBinder.Binder).TypeHandle);

            // 4. Preparar y exportar
            report.Prepare();
            string rutaPDF = Path.Combine(Application.StartupPath, "Ticket.pdf");
            report.Export(new PDFSimpleExport(), rutaPDF);

            string rutaSumatra = Path.Combine(Application.StartupPath, "SumatraPDF.exe");

            if (!File.Exists(rutaSumatra))
            {
                MessageBox.Show("No se encontró SumatraPDF.exe. Asegúrate de colocarlo junto a la aplicación.");
                return;
            }

            var nombreImpresora = "Microsoft Print to PDF";
            var psi = new ProcessStartInfo
            {
                FileName = rutaSumatra,
                Arguments = nombreImpresora == ""
                    ? $"-print-to-default \"{rutaPDF}\""
                    : $"-print-to \"{nombreImpresora}\" \"{rutaPDF}\"",
                CreateNoWindow = true,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            Process.Start(psi);
        }


    }
    #endregion
}
