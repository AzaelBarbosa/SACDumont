using FastReport;
using FastReport.Export.PdfSimple;
using Microsoft.CSharp;
using SACDumont.Base;
using SACDumont.Catalogos;
using SACDumont.Clases;
using SACDumont.Cobros;
using SACDumont.Dtos;
using SACDumont.Models;
using SACDumont.modulos;
using SACDumont.Modulos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SACDumont.Listados
{
    public partial class frmMovimientos : frmListados
    {
        #region Variables
        DataTable dtMovimientos = new DataTable("Movimientos");
        basGlobals basGlobals = new basGlobals();
        int idCiclo = basGlobals.iCiclo;
        int tipoMovimiento = basGlobals.tipoMovimiento;
        int estatusMovimiento = basGlobals.estatusMovimiento;
        basSql sql = new basSql();
        int idMov = 0;
        BindingSource bs = new BindingSource();
        #endregion

        #region Propiedades
        protected override void Nuevo()
        {
            basGlobals.Movimiento = new Movimientos();
            basGlobals.listaProductos = new List<movimiento_productos>();
            basGlobals.listaCobros = new List<cobros>();
            frmMovimiento frmMovimiento = new frmMovimiento(0);
            frmMovimiento.ShowDialog();
            CargarMovimientos();
        }
        protected override void Guardar()
        {

        }
        protected override void Eliminar()
        {
            // Implementar la lógica para eliminar el movimiento
        }
        protected override void Imprimir()
        {
            // Implementar la lógica para imprimir el listado de movimientos
            if (basConfiguracion.PrinterTiockets == null)
            {
                MessageBox.Show("Debe configurar una impresora para tickets en la configuración del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ExportareImprimirSinAbrir();
        }
        protected override void Cerrar()
        {
            this.Close();
        }

        protected override void CargarComboFiltro()
        {
            if (cboFiltros.SelectedIndex >= 0)
            {
                string selectedFilter = cboFiltros.SelectedItem.ToString();
                if (selectedFilter == "confirmado")
                {
                    txBusqueda.Visible = false;
                    cboBusqueda.Visible = true;
                    cboBusqueda.Items.Clear();
                    cboBusqueda.Items.Add("Todos");
                    cboBusqueda.Items.Add("Pendiente Confirmar");
                    cboBusqueda.Items.Add("Confirmado");
                    cboBusqueda.SelectedIndex = -1; // Seleccionar el primer elemento por defecto
                }
                else if (selectedFilter == "Estatus")
                {
                    txBusqueda.Visible = false;
                    cboBusqueda.Visible = true;
                    cboBusqueda.Items.Clear();
                    cboBusqueda.Items.Add("Todos");
                    cboBusqueda.Items.Add("Pendiente");
                    cboBusqueda.Items.Add("Liquidado");
                    cboBusqueda.Items.Add("Cancelado");
                    cboBusqueda.Items.Add("Abono");
                    cboBusqueda.SelectedIndex = -1; // Seleccionar el primer elemento por defecto
                }
                else
                {
                    txBusqueda.Visible = true;
                    cboBusqueda.Visible = false;
                }
            }
            else
            {
                txBusqueda.Visible = false;
                cboBusqueda.Visible = false;
            }
        }

        protected override void Busqueda()
        {
            string texto = txBusqueda.Text.ToLower();
            if (cboFiltros.SelectedItem == null) return;
            string campoSeleccionado = cboFiltros.SelectedItem.ToString();

            bs.Filter = $"{campoSeleccionado} LIKE '%{texto}%'";
        }

        protected override void BusquedaCombo()
        {
            string campoSeleccionado = cboFiltros.SelectedItem.ToString();
            if (campoSeleccionado == "Todos")
            {
                bs.Filter = "";
                return;
            }
            if (campoSeleccionado == "confirmado")
            {
                if (cboBusqueda.SelectedItem.ToString() == "Todos")
                {
                    bs.Filter = "";
                    return;
                }

                bool valor = cboBusqueda.SelectedItem.ToString() == "Confirmado" ? true : false;

                bs.Filter = $"{campoSeleccionado} = {valor}";
            }
            else if (campoSeleccionado == "Estatus")
            {

                if (cboBusqueda.SelectedItem.ToString() == "Todos")
                {
                    bs.Filter = "";
                    return;
                }
                bs.Filter = $"{campoSeleccionado} LIKE '%{cboBusqueda.SelectedItem.ToString()}%'";
            }
        }
        #endregion

        #region Eventos
        private void CargarMovimientos()
        {
            dtMovimientos = sqlServer.ExecSQLReturnDT($@"SELECT m.id_movimiento ,m.fechahora AS Fecha, p.descripcion AS Producto, a.appaterno + ' ' + a.apmaterno + ' ' + a.nombre AS Alumno, cat.descripcion AS Grado, catG.descripcion AS Grupo, 
                                                        m.montoTotal AS Total, m.montoTotal - (SELECT SUM(monto) FROM cobros WHERE id_movimiento = m.id_movimiento) AS MontoPendiente, m.porcentaje_descuento AS Descuento, m.monto_descuento AS MontoDescuento, m.beca_descuento AS BecaDescuento,
                                                        catE.descripcion AS Estatus, m.confirmado
                                                        FROM movimientos m
                                                        INNER JOIN movimiento_productos mp ON m.id_movimiento = mp.id_movimiento
                                                        INNER JOIN productos p ON p.id_producto = mp.id_producto
                                                        INNER JOIN alumnos a ON a.matricula = m.id_matricula
                                                        INNER JOIN inscripciones i ON i.matricula = a.matricula AND i.id_ciclo = m.id_ciclo
                                                        LEFT JOIN catalogos cat ON cat.valor = i.id_grado AND cat.tipo_catalogo = 'Grado' 
                                                        LEFT JOIN catalogos catG ON catG.valor = i.id_grupo AND catG.tipo_catalogo = 'Grupo'
                                                        LEFT JOIN catalogos catE ON catE.valor = m.id_estatusmovimiento AND catE.tipo_catalogo = 'EstatusMovimiento'
                                                        WHERE m.id_ciclo = {basGlobals.iCiclo} AND p.concepto = '{basGlobals.sConcepto}'", "Movimientos");
            bs.DataSource = dtMovimientos;
            dgvMovimientos.DataSource = bs;
            FormatGrid();
            dgvMovimientos.Refresh();
        }

        private void FormatGrid()
        {
            dgvMovimientos.Columns["id_movimiento"].Visible = false;
            dgvMovimientos.Columns["Fecha"].HeaderText = "Fecha";
            dgvMovimientos.Columns["Alumno"].HeaderText = "Alumno";
            dgvMovimientos.Columns["Grado"].HeaderText = "Grado";
            dgvMovimientos.Columns["Grupo"].HeaderText = "Grupo";
            dgvMovimientos.Columns["MontoPendiente"].HeaderText = "Monto Pendiente";
            dgvMovimientos.Columns["MontoPendiente"].DefaultCellStyle.Format = "C2";
            dgvMovimientos.Columns["Total"].HeaderText = "Total";
            dgvMovimientos.Columns["Total"].DefaultCellStyle.Format = "C2";
            dgvMovimientos.Columns["Estatus"].HeaderText = "Estatus";
            dgvMovimientos.Columns["confirmado"].HeaderText = "Confirmado";
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
            dgvMovimientos.ReadOnly = true;
            bs.Sort = "Fecha DESC"; // O ASC para ascendente
            //dgvMovimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dgvMovimientos.MultiSelect = false;

        }
        private void CargarMenu()
        {
            //reporteToolStripMenuItem.Visible = false;
            guardarToolStripMenuItem.Visible = false;
        }

        private void CargarElementosBusqueda()
        {
            var ignorar = new[] { "id_movimiento", "BecaDescuento", "MontoDescuento", "Descuento", "Total", "MontoPendiente", "Fecha" };

            var propiedades = typeof(MovimientosDTO)
                 .GetProperties()
                 .Select(p => p.Name)
                 .Where(nombre => !ignorar.Contains(nombre))
                 .ToList();

            foreach (var item in propiedades)
            {
                cboFiltros.Items.Add(item.ToString());
            }
        }
        public frmMovimientos()
        {
            InitializeComponent();
        }

        private void frmMovimientos_Load(object sender, EventArgs e)
        {
            CargarMenu();
            CargarElementosBusqueda();
            CargarMovimientos();
        }

        private void dgvMovimientos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = ((DataRowView)dgvMovimientos.SelectedRows[0].DataBoundItem).Row;

            if (dgvMovimientos.SelectedRows.Count == 0) return;
            {
                frmMovimiento frm = new frmMovimiento((int)row["id_movimiento"]);
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
                decimal decMonto = (decimal)e.Value;

                if (decMonto > 0)
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
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
            if (idMov == 0) return;

            DataTable dataTable = new DataTable();
            Movimientos mov = new Movimientos();
            Inscripciones ins = new Inscripciones();
            List<ReportesDTO> reportesDTO = new List<ReportesDTO>();
            using (var db = new DumontContext())
            {
                mov = db.Movimientos.Find(idMov);
                ins = db.Inscripciones.Where(i => i.matricula == mov.id_matricula && i.id_ciclo == basGlobals.iCiclo).FirstOrDefault();

                var lista = db.Movimientos
                  .Where(m => m.id_movimiento == idMov)
                  .Include(m => m.MovimientosProductos)
                  .Include(m => m.MovimientosCobros)
                  .SelectMany(m => m.MovimientosProductos, (m, mp) => new ReportesDTO
                  {
                      Producto = db.Productos.Where(p => p.id_producto == mp.id_producto).Select(p => p.descripcion).FirstOrDefault(),
                      Cantidad = mp.cantidad,
                      PrecioUnitario = mp.cantidad * mp.monto,
                      Total = mp.monto + mp.monto_recargo,
                      Recargo = mp.monto_recargo,
                      Folio = m.id_movimiento,
                      Fecha = m.fechahora,
                      Grupo = db.Catalogos.Where(c => c.valor == ins.id_grupo && c.tipo_catalogo == "Grupo").Select(c => c.descripcion).FirstOrDefault(),
                      Matricula = m.id_matricula,
                      Alumno = db.Alumnos
                                  .Where(a => a.matricula == m.id_matricula)
                                  .Select(a => a.appaterno + " " + a.apmaterno + " " + a.nombre)
                                  .FirstOrDefault(),
                      MontoPendiente = m.montoTotal - db.MovimientoCobros.Where(mc => mc.id_movimiento == m.id_movimiento).Sum(mc => mc.monto),
                      MontoPagado = db.MovimientoCobros.Where(mc => mc.id_movimiento == m.id_movimiento).Sum(mc => mc.monto),
                  })
                  .ToList();

                reportesDTO = lista;
            }

            dataTable = basFunctions.ConvertToDataTable(reportesDTO);
            // 2. Cargar el reporte
            string rutaFrx = Path.Combine(Application.StartupPath, "Reportes", "TicketMovimient.frx");
            Report report = new Report();
            report.Load(rutaFrx);

            report.SetParameterValue("pFolio", reportesDTO[0].Folio);
            report.SetParameterValue("pFecha", reportesDTO[0].Fecha);
            report.SetParameterValue("pGrupo", reportesDTO[0].Grupo);
            report.SetParameterValue("pMatricula", reportesDTO[0].Matricula);
            report.SetParameterValue("pAlumno", reportesDTO[0].Alumno);

            report.RegisterData(dataTable, "TicketData");
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

            var nombreImpresora = basConfiguracion.PrinterTiockets;
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

        private void dgvMovimientos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtener la fila
                DataGridViewRow fila = dgvMovimientos.Rows[e.RowIndex];

                // Obtener el valor de la columna "ID" (puedes usar el índice también)
                idMov = (int)fila.Cells["id_movimiento"].Value;
            }
        }

        private void dgvMovimientos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtener la fila
                DataGridViewRow fila = dgvMovimientos.Rows[e.RowIndex];

                // Obtener el valor de la columna "ID" (puedes usar el índice también)
                frmMovimiento frm = new frmMovimiento((int)fila.Cells["id_movimiento"].Value);
                frm.ShowDialog();
                CargarMovimientos();
            }
        }

        private void dgvMovimientos_Resize(object sender, EventArgs e)
        {
            basFunctions.CenterSpinnerOverGrid(this, pbSpinner);
        }
    }
    #endregion
}
