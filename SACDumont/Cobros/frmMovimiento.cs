using FastReport;
using FastReport.Export.PdfSimple;
using log4net.Util;
using SACDumont.Base;
using SACDumont.Clases;
using SACDumont.Controles;
using SACDumont.Dtos;
using SACDumont.Models;
using SACDumont.modulos;
using SACDumont.Modulos;
using SACDumont.Otros;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SACDumont.Cobros
{
    public partial class frmMovimiento : frmBaseCatalogos
    {
        #region Variables

        DataTable dtMovimiento = new DataTable("Movimiento");
        int idCiclo = basGlobals.iCiclo;
        int id_estatusmovimiento = (int)EstatusMovimiento.Liquidado;
        int idMovimiento = 0;
        int idMatricula = 0;
        int idGrado = 0;
        int idGrupo = 0;
        decimal beca = 0;
        decimal promocion = 0;
        string strConcepto = "";
        DataSet dsTemp = new DataSet("Movimiento");
        basSql sql = new basSql();
        Movimientos movimiento = new Movimientos();
        List<movimiento_productos> listaProductos = new List<movimiento_productos>();
        List<cobros> listaCobros = new List<cobros>();
        bool impresionTicket = false;
        bool promocionActiva = false;
        bool becaActiva = false;
        #endregion

        #region Constructores
        protected override void Nuevo()
        {
            basGlobals.Movimiento = new Movimientos();
            basGlobals.listaProductos = new List<movimiento_productos>();
            basGlobals.listaCobros = new List<cobros>();
            frmMovimiento frmMovimiento = new frmMovimiento(0);
            frmMovimiento.ShowDialog();
        }
        protected override void Guardar()
        {
            try
            {
                // Implementar la lógica para guardar el movimiento
                if (cboAlumnos.matricula == 0)
                {
                    MessageBox.Show("Debe seleccionar un alumno antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (basGlobals.listaProductos.Count == 0 && basGlobals.listaCobros.Count == 0)
                {
                    MessageBox.Show("Debe agregar al menos un producto o cobro antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (basGlobals.listaCobros.Count > 0 && basGlobals.listaCobros.Sum(p => p.monto) <= 0)
                {
                    MessageBox.Show("El monto total de los cobros debe ser mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (basGlobals.listaProductos.Count > 0 && basGlobals.listaProductos.Sum(p => p.monto) <= 0)
                {
                    MessageBox.Show("El monto total de los productos debe ser mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if ((basGlobals.listaProductos.Sum(p => p.monto) + basGlobals.listaProductos.Sum(p => p.monto_recargo) - Convert.ToDecimal(txBeca.Text.Replace("$", "").Replace(",", "").Trim()) - Convert.ToDecimal(txDescuento.Text.Replace("$", "").Replace(",", "").Trim())) - basGlobals.listaCobros.Sum(p => p.monto) > 0)
                {
                    id_estatusmovimiento = (int)modulos.EstatusMovimiento.Abono; // Si hay saldo pendiente, el estatus es Pendiente
                }
                else
                {
                    id_estatusmovimiento = (int)modulos.EstatusMovimiento.Liquidado; // Si no hay saldo pendiente, el estatus es Liquidado
                }

                using (var db = new DumontContext())
                {
                    if (idMovimiento > 0)
                    {
                        var mov = db.Movimientos.Find(idMovimiento);
                        if (mov != null)
                        {
                            mov.porcentaje_descuento = 0;
                            mov.monto_descuento = Convert.ToDecimal(txDescuento.Text.Replace("$", "").Replace(",", "").Trim());
                            mov.beca_descuento = Convert.ToDecimal(txBeca.Text.Replace("$", "").Replace(",", "").Trim());
                            mov.digitoscuenta = "0";
                            mov.id_estatusmovimiento = id_estatusmovimiento;
                            mov.montoTotal = basGlobals.listaProductos.Sum(p => p.monto) + basGlobals.listaProductos.Sum(c => c.monto_recargo);
                            mov.confirmado = basConfiguracion.Transferencias == true ? false : chConfirmar.Checked;

                            foreach (var item in basGlobals.listaCobros)
                            {
                                if (item.id_cobro == 0) // Ya existe en la BD → actualizar
                                {
                                    item.id_movimiento = idMovimiento;
                                    db.MovimientoCobros.Add(item);
                                    impresionTicket = true;
                                }
                            }

                            var result = db.SaveChanges(); // 🔥 EF genera los INSERT automáticamente para productos y cobros);
                            if (result != 0)
                            {
                                basFunctions.Registrar(basConfiguracion.UserID, "Movimiento", "Editar", idMovimiento, $"Se realizaron cambios al Movimiento con ID: {idMovimiento}");
                                if (id_estatusmovimiento == (int)modulos.EstatusMovimiento.Liquidado)
                                {
                                    basFunctions.Registrar(basConfiguracion.UserID, "Movimiento", "Liquidacion", idMovimiento, $"Se liquido el Movimiento con ID: {idMovimiento}");
                                }
                                else if (id_estatusmovimiento == (int)modulos.EstatusMovimiento.Abono)
                                {
                                    basFunctions.Registrar(basConfiguracion.UserID, "Movimiento", "Abono", idMovimiento, $"Se realizo un abono al Movimiento con ID: {idMovimiento}");
                                }

                                if (impresionTicket) ExportareImprimirSinAbrir(idMovimiento);
                            }
                        }

                        else
                        {
                            MessageBox.Show("Movimiento no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }
                    else
                    {
                        var nuevo = new Movimientos
                        {
                            id_movimiento = 0, // Se asignará automáticamente por la base de datos
                            id_matricula = (int)cboAlumnos.matricula,
                            id_usuario = idGrupo,
                            fechahora = DateTime.Now,
                            id_ciclo = basGlobals.iCiclo,
                            montoTotal = basGlobals.listaProductos.Sum(p => p.monto) + basGlobals.listaProductos.Sum(c => c.monto_recargo),
                            porcentaje_descuento = 0, // Asignar el valor correspondiente si se aplica descuento
                            monto_descuento = Convert.ToDecimal(txDescuento.Text.Replace("$", "").Replace(",", "").Trim()), // Asignar el valor correspondiente si se aplica descuento
                            beca_descuento = Convert.ToDecimal(txBeca.Text.Replace("$", "").Replace(",", "").Trim()), // Asignar el valor correspondiente si se aplica beca
                            id_tipomovimiento = basGlobals.tipoMovimiento, // Asignar el estatus correspondiente
                            digitoscuenta = "0",
                            id_estatusmovimiento = id_estatusmovimiento, // Asignar el estatus correspondiente
                            confirmado = basConfiguracion.Transferencias == true ? false : true
                        };

                        db.Movimientos.Add(nuevo);
                        var result = db.SaveChanges(); // 🔥 EF genera el INSERT automáticamente
                        if (result != 0)
                        {
                            idMovimiento = (int)nuevo.id_movimiento;
                            basFunctions.Registrar(basConfiguracion.UserID, "Movimiento", "Alta", idMovimiento, $"Se realizo un nuevo Movimiento con ID: {idMovimiento}");
                        }

                        db.MovimientoProductos.AddRange(basGlobals.listaProductos.Select(p => new movimiento_productos
                        {
                            id_movimiento = (int)nuevo.id_movimiento,
                            id_producto = p.id_producto,
                            descriptionProducto = p.descriptionProducto,
                            cantidad = p.cantidad,
                            monto = p.monto,
                            monto_recargo = p.monto_recargo,
                            talla = p.talla
                        }));
                        db.MovimientoCobros.AddRange(basGlobals.listaCobros.Select(c => new cobros
                        {
                            id_movimiento = (int)nuevo.id_movimiento,
                            monto = c.monto,
                            tipopago = c.tipopago,
                            descripcionPago = c.descripcionPago,
                            fechaAlta = c.fechaAlta,
                            pago_por = c.pago_por
                        }));
                        var result2 = db.SaveChanges(); // 🔥 EF genera los INSERT automáticamente para productos y cobros
                        if (result2 != 0)
                        {
                            if (id_estatusmovimiento == (int)modulos.EstatusMovimiento.Liquidado)
                            {
                                basFunctions.Registrar(basConfiguracion.UserID, "Movimiento", "Liquidacion", idMovimiento, $"Se liquido el Movimiento con ID: {idMovimiento}");
                            }
                            else if (id_estatusmovimiento == (int)modulos.EstatusMovimiento.Abono)
                            {
                                basFunctions.Registrar(basConfiguracion.UserID, "Movimiento", "Abono", idMovimiento, $"Se realizo un abono al Movimiento con ID: {idMovimiento}");
                            }
                            if (basConfiguracion.PrinterTiockets == null)
                            {
                                MessageBox.Show("Debe configurar una impresora para tickets en la configuración del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            for (int i = 0; i < 2; i++)
                            {
                                ExportareImprimirSinAbrir(nuevo.id_movimiento);
                                Thread.Sleep(2000);
                            }
                        }
                    }
                }
                basConfiguracion.Transferencias = false;
                this.Close();
            }
            catch
            {

            }
        }
        protected override void Eliminar()
        {
            if (idMovimiento == 0)
            {
                MessageBox.Show("Esta dando de Alta un nuevo movomiento, no es posible Cancelar", "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var db = new DumontContext())
            {
                var movimientos = db.Movimientos.Find(idMovimiento);

                if (MessageBox.Show($"Esta por cancelar el movimiento:" + Environment.NewLine + Environment.NewLine + $"{movimientos.id_movimiento}" + Environment.NewLine + "¿Desea Continuar?", "Movimientos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    movimientos.id_estatusmovimiento = (int)EstatusMovimiento.Cancelado;
                    db.Entry(movimientos).State = System.Data.Entity.EntityState.Modified;
                    var result = db.SaveChanges();
                    if (result > 0)
                    {
                        MessageBox.Show("Movimiento cancelado correctamente", "Movimientos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        basFunctions.Registrar(basConfiguracion.UserID, "Movimiento", "Cancelar", idMovimiento, $"Se cancelo el Movimiento con ID: {idMovimiento}");
                    }
                }
            }
            // Implementar la lógica para eliminar el movimiento
        }
        protected override void Cerrar()
        {
            basGlobals.listaCobros = new List<cobros>();
            basGlobals.Movimiento = new Movimientos();
            basGlobals.listaProductos = new List<movimiento_productos>();
            this.Close();
        }
        protected override void Deshabilitar()
        {
            // Implementar la lógica para deshabilitar el movimiento
        }
        protected override void Acciones()
        {
            frmAcciones frm = new frmAcciones("Movimiento", idMovimiento);
            frm.Text = "Acciones Movimiento";
            frm.ShowDialog();
        }
        #endregion

        #region Métodos Privados
        private void CargarAlumnos()
        {
            cboAlumnos.Inicializar();
        }
        private void CargarMenu()
        {
            btAddTutor.Visible = false;
            btQuitarRecargo.Visible = false;
            btDeshabilitar.Visible = false;
            btHabilitar.Visible = false;
            btQuitarRecargo.Visible = false;
            btResetPass.Visible = false;
        }
        public frmMovimiento(int idMov)
        {
            InitializeComponent();
            this.idMovimiento = idMov;
        }

        private void DefinirVariables()
        {
            // Definir las variables necesarias para el movimiento
            if (basGlobals.tipoMovimiento == (int)modulos.TipoMovimiento.Colegiatura)
            {
                strConcepto = Conceptos.COLEGIATURA.ToString();
            }
            else if (basGlobals.tipoMovimiento == (int)modulos.TipoMovimiento.Inscripcion)
            {
                strConcepto = Conceptos.INSCRIPCION.ToString();
            }
            else if (basGlobals.tipoMovimiento == (int)modulos.TipoMovimiento.Producto)
            {
                strConcepto = Conceptos.ARTICULO.ToString();
            }
            else if (basGlobals.tipoMovimiento == (int)modulos.TipoMovimiento.Uniformes)
            {
                strConcepto = Conceptos.UNIFORMES.ToString();
            }
            else if (basGlobals.tipoMovimiento == (int)modulos.TipoMovimiento.Eventos)
            {
                strConcepto = Conceptos.EVENTOS.ToString();
            }
            else if (basGlobals.tipoMovimiento == (int)modulos.TipoMovimiento.Graduacion)
            {
                strConcepto = Conceptos.GRADUACION.ToString();
            }
        }

        private void ExportareImprimirSinAbrir(int idMov)
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
                      PrecioUnitario = mp.cantidad * mp.monto - m.beca_descuento - m.monto_descuento,
                      Total = mp.monto + mp.monto_recargo - m.beca_descuento - m.monto_descuento,
                      Recargo = mp.monto_recargo,
                      Folio = m.id_movimiento,
                      Fecha = m.fechahora,
                      Grado = db.Catalogos.Where(c => c.valor == ins.id_grado && c.tipo_catalogo == "Grado").Select(c => c.descripcion).FirstOrDefault(),
                      Matricula = m.id_matricula,
                      Alumno = db.Alumnos
                                  .Where(a => a.matricula == m.id_matricula)
                                  .Select(a => a.appaterno + " " + a.apmaterno + " " + a.nombre)
                                  .FirstOrDefault(),
                      MontoPendiente = m.montoTotal - m.beca_descuento - m.monto_descuento - db.MovimientoCobros.Where(mc => mc.id_movimiento == m.id_movimiento).Sum(mc => mc.monto),
                      MontoPagado = db.MovimientoCobros.Where(mc => mc.id_movimiento == m.id_movimiento).Sum(mc => mc.monto),
                      PagadoPor = db.MovimientoCobros.Where(mc => mc.id_movimiento == m.id_movimiento).Select(mc => mc.pago_por).FirstOrDefault()
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
            report.SetParameterValue("pGrado", reportesDTO[0].Grado);
            report.SetParameterValue("pMatricula", reportesDTO[0].Matricula);
            report.SetParameterValue("pAlumno", reportesDTO[0].Alumno);
            if (basConfiguracion.Transferencias)
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

            string rutaSumatra = Path.Combine("C:\\", "PDF\\", "SumatraPDF.exe");

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

        private void VerificarMovimiento()
        {
            if (idMovimiento == 0)
            {
                return;
            }

            basGlobals.Movimiento = sql.GetMovimiento(idMovimiento);
            basGlobals.listaProductos = sql.GetMovimientoProductos(idMovimiento);
            basGlobals.listaCobros = sql.GetMovimientosPagos(idMovimiento);

            if (movimiento != null)
            {
                lbIDMovimiento.Text = basGlobals.Movimiento.id_movimiento.ToString();
                cboAlumnos.matricula = (int)basGlobals.Movimiento.id_matricula;
                cboAlumnos.Enabled = false;
                txImporte.Text = (basGlobals.listaProductos.Sum(p => p.monto)).ToString("C2");
                txRecargo.Text = (basGlobals.listaProductos.Sum(p => p.monto_recargo)).ToString("C2");
                txImportePte.Text = (basGlobals.Movimiento.montoTotal - basGlobals.Movimiento.monto_descuento - basGlobals.Movimiento.beca_descuento - basGlobals.listaCobros.Sum(p => p.monto)).ToString("C2");
                txTotal.Text = (basGlobals.Movimiento.montoTotal - basGlobals.Movimiento.monto_descuento - basGlobals.Movimiento.beca_descuento).ToString("C");
                txDescuento.Text = (basGlobals.Movimiento.monto_descuento).ToString("C");
                txBeca.Text = (basGlobals.Movimiento.beca_descuento).ToString("C");
                chConfirmar.Checked = basGlobals.Movimiento.confirmado;
                dgvCobros.DataSource = basGlobals.listaCobros;
                dgvCobros.Columns["id_cobro"].Visible = false;
                dgvCobros.Columns["id_movimiento"].Visible = false;
                dgvCobros.Columns["tipopago"].Visible = false;
                dgvCobros.Columns["fechaAlta"].HeaderText = "Fecha Pago";
                dgvCobros.Columns["monto"].HeaderText = "Monto";
                dgvCobros.Columns["pago_por"].HeaderText = "Pago Por";
                dgvCobros.Columns["monto"].DefaultCellStyle.Format = "C2";
                dgvCobros.Columns["descripcionPago"].HeaderText = "Forma de Pago";
                dgvCobros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvCobros.RowHeadersVisible = false;
                dgvProductos.DataSource = basGlobals.listaProductos;
                dgvProductos.Columns["id_movimiento"].Visible = false;
                dgvProductos.Columns["id_producto"].Visible = false;
                dgvProductos.Columns["id"].Visible = false;
                dgvProductos.Columns["descriptionProducto"].HeaderText = "Producto";
                dgvProductos.Columns["cantidad"].HeaderText = "Qty";
                dgvProductos.Columns["cantidad"].DefaultCellStyle.Format = "N0";
                dgvProductos.Columns["monto"].HeaderText = "Monto";
                if (strConcepto == Conceptos.GASTOS.ToString())
                {
                    dgvProductos.Columns["descripcion"].HeaderText = "Descripcion";
                }
                else
                {
                    dgvProductos.Columns["descripcion"].Visible = false;
                }
                if (strConcepto == Conceptos.UNIFORMES.ToString())
                {
                    dgvProductos.Columns["talla"].HeaderText = "Talla";
                }
                else
                {
                    dgvProductos.Columns["talla"].Visible = false;
                }
                dgvProductos.Columns["monto"].DefaultCellStyle.Format = "C2";
                dgvProductos.Columns["monto_recargo"].HeaderText = "Recargo";
                dgvProductos.Columns["monto_recargo"].DefaultCellStyle.Format = "C2";
                dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvProductos.RowHeadersVisible = false;
                if (basGlobals.Movimiento.id_estatusmovimiento == (int)EstatusMovimiento.Liquidado)
                {
                    btDeleteProducto.Enabled = false;
                    btNewProducto.Enabled = false;
                    btDeletePago.Enabled = false;
                    btNewPago.Enabled = false;
                }
                else if (basGlobals.Movimiento.id_estatusmovimiento == (int)EstatusMovimiento.Abono)
                {
                    btDeleteProducto.Enabled = false;
                    btNewProducto.Enabled = false;
                    btDeletePago.Enabled = true;
                    btNewPago.Enabled = true;
                }
                else if (basGlobals.Movimiento.id_estatusmovimiento == (int)EstatusMovimiento.Cancelado)
                {
                    btDeleteProducto.Enabled = false;
                    btNewProducto.Enabled = false;
                    btDeletePago.Enabled = false;
                    btNewPago.Enabled = false;
                }
                VerificaPromociones();
            }

        }

        #endregion

        #region Eventos
        private void frmMovimiento_Load(object sender, EventArgs e)
        {
            CargarMenu();
            CargarAlumnos();
            DefinirVariables();
            VerificarMovimiento();
            //ValidaTipoMovimiento();
        }

        private void cboAlumnos_OnAlumnoSeleccionado(DataRow obj)
        {
            idMatricula = Convert.ToInt32(obj["matricula"]);
            idGrado = Convert.ToInt32(obj["Grado"]);
            idGrupo = Convert.ToInt32(obj["Grupo"]);
            lbGradoActual.Text = Convert.ToString(obj["DescripcionGrado"]);
            lbGrupoActual.Text = Convert.ToString(obj["DescripcionGrupo"]);
            this.cboAlumnos.Size = new Size(398, 21);

            using (var db = new DumontContext())
            {
                var inscripcion = db.Inscripciones.Where(i => i.id_ciclo == basGlobals.iCiclo && i.matricula == idMatricula).FirstOrDefault();
                becaActiva = inscripcion.beca;
                promocionActiva = inscripcion.promocion;

                if (promocionActiva)
                {
                    var promoAlumno = (from pa in db.PromocionesAlumnos
                                       join p in db.Promociones on pa.id_promocion equals p.id_promocion
                                       where pa.matricula == idMatricula
                                          && pa.id_ciclo == basGlobals.iCiclo
                                          && p.concepto == strConcepto
                                       select p).FirstOrDefault();
                    if (promoAlumno != null)
                    {
                        promocion = promoAlumno.porcentaje_promocion;
                        lbPromocion.Text = Convert.ToString(promoAlumno.porcentaje_promocion);
                    }
                    lbBeca.Text = "N/A";
                }

                if (becaActiva)
                {
                    var becaAlumno = db.Becas.Where(b => b.id_matricula == idMatricula && b.id_ciclo == basGlobals.iCiclo).FirstOrDefault();
                    if (becaAlumno != null)
                    {
                        beca = becaAlumno.porcentaje_beca;
                        lbBeca.Text = Convert.ToString(becaAlumno.porcentaje_beca);
                    }
                    lbPromocion.Text = "N/A";
                }
            }
        }

        private void VerificaPromociones()
        {
            using (var db = new DumontContext())
            {
                var inscripcion = db.Inscripciones.Where(i => i.id_ciclo == basGlobals.iCiclo && i.matricula == (int)basGlobals.Movimiento.id_matricula).FirstOrDefault();
                becaActiva = inscripcion.beca;
                promocionActiva = inscripcion.promocion;

                if (promocionActiva)
                {
                    var promoAlumno = (from pa in db.PromocionesAlumnos
                                       join p in db.Promociones on pa.id_promocion equals p.id_promocion
                                       where pa.matricula == (int)basGlobals.Movimiento.id_matricula
                                          && pa.id_ciclo == basGlobals.iCiclo
                                          && p.concepto == strConcepto
                                       select p).FirstOrDefault();
                    if (promoAlumno != null)
                    {
                        promocion = promoAlumno.porcentaje_promocion;
                        lbPromocion.Text = Convert.ToString(promoAlumno.porcentaje_promocion);
                    }
                    lbBeca.Text = "N/A";
                }

                if (becaActiva)
                {
                    var becaAlumno = db.Becas.Where(b => b.id_matricula == (int)basGlobals.Movimiento.id_matricula && b.id_ciclo == basGlobals.iCiclo).FirstOrDefault();
                    if (becaAlumno != null)
                    {
                        beca = becaAlumno.porcentaje_beca;
                        lbBeca.Text = Convert.ToString(becaAlumno.porcentaje_beca);
                    }
                    lbPromocion.Text = "N/A";
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (cboAlumnos.matricula == 0)
            {
                MessageBox.Show("Debe seleccionar un alumno antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmCobroProducto frmCobro = new frmCobroProducto(idGrupo, strConcepto, (int)cboAlumnos.matricula);
            frmCobro.Text = "Agregar Producto";
            frmCobro.ShowDialog();
            if (basGlobals.listaProductos.Count > 0)
            {
                dgvProductos.DataSource = null;
                dgvProductos.DataSource = basGlobals.listaProductos;
                dgvProductos.Columns["id_movimiento"].Visible = false;
                dgvProductos.Columns["id_producto"].Visible = false;
                dgvProductos.Columns["id"].Visible = false;
                dgvProductos.Columns["descriptionProducto"].HeaderText = "Producto";
                dgvProductos.Columns["cantidad"].HeaderText = "Qty";
                dgvProductos.Columns["cantidad"].DefaultCellStyle.Format = "N0";
                dgvProductos.Columns["monto"].HeaderText = "Monto";
                dgvProductos.Columns["monto"].DefaultCellStyle.Format = "C2";
                dgvProductos.Columns["monto_recargo"].HeaderText = "Recargo";
                dgvProductos.Columns["monto_recargo"].DefaultCellStyle.Format = "C2";
                if (strConcepto == Conceptos.GASTOS.ToString())
                {
                    dgvProductos.Columns["descripcion"].HeaderText = "Descripcion";
                }
                else
                {
                    dgvProductos.Columns["descripcion"].Visible = false;
                }
                if (strConcepto == Conceptos.UNIFORMES.ToString())
                {
                    dgvProductos.Columns["talla"].HeaderText = "Talla";
                }
                else
                {
                    dgvProductos.Columns["talla"].Visible = false;
                }
                dgvProductos.Columns["descriptionProducto"].Width = 220;
                dgvProductos.Columns["cantidad"].Width = 30;
                dgvProductos.Columns["monto"].Width = 110;
                dgvProductos.Columns["monto_recargo"].Width = 110;
                dgvProductos.RowHeadersVisible = false;

                txImporte.Text = basGlobals.listaProductos.Sum(p => p.monto).ToString();
                txImporte.Text = Convert.ToDecimal(txImporte.Text).ToString("C2");
                txRecargo.Text = basGlobals.listaProductos.Sum(p => p.monto_recargo).ToString();
                txRecargo.Text = Convert.ToDecimal(txRecargo.Text).ToString("C2");
                txBeca.Text = ((beca / 100m) * basGlobals.listaProductos.Sum(p => p.monto)).ToString("C2");
                txDescuento.Text = ((promocion / 100m) * basGlobals.listaProductos.Sum(p => p.monto)).ToString("C2");
                txTotal.Text = (Convert.ToDecimal(txImporte.Text.Replace("$", "").Replace(",", "").Trim()) + Convert.ToDecimal(txRecargo.Text.Replace("$", "").Replace(",", "").Trim()) - Convert.ToDecimal(txBeca.Text.Replace("$", "").Replace(",", "").Trim()) - Convert.ToDecimal(txDescuento.Text.Replace("$", "").Replace(",", "").Trim())).ToString("C2");
                txImportePte.Text = txTotal.Text;
                txImportePte.ForeColor = Color.Red;
            }
        }

        private void btNewPago_Click(object sender, EventArgs e)
        {
            decimal decImportePte = 0;

            if (dgvProductos.Rows.Count == 0)
            {
                MessageBox.Show("No hay ningun Producto para cobrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (basGlobals.listaCobros.Count > 0)
            {
                decImportePte = (Convert.ToDecimal(txTotal.Text.Replace("$", "").Replace(",", "").Trim()) - Convert.ToDecimal(basGlobals.listaCobros.Sum(p => p.monto).ToString()));
                txImportePte.Text = decImportePte.ToString("C2");

            }
            else
            {
                decImportePte = (Convert.ToDecimal(txTotal.Text.Replace("$", "").Replace(",", "").Trim()));
                txImportePte.Text = decImportePte.ToString("C2");
            }

            frmMovimientoCobro frmMovimientoCobro = new frmMovimientoCobro(decImportePte);
            frmMovimientoCobro.Text = "Agregar Cobro";
            frmMovimientoCobro.ShowDialog();
            if (basGlobals.listaCobros.Count > 0)
            {
                dgvCobros.DataSource = null;
                dgvCobros.DataSource = basGlobals.listaCobros;
                dgvCobros.Columns["id_cobro"].Visible = false;
                dgvCobros.Columns["id_movimiento"].Visible = false;
                dgvCobros.Columns["tipopago"].Visible = false;
                dgvCobros.Columns["descripcionPago"].HeaderText = "Forma de Pago";
                dgvCobros.Columns["fechaAlta"].HeaderText = "Fecha Pago";
                dgvCobros.Columns["monto"].HeaderText = "Monto";
                dgvCobros.Columns["pago_por"].HeaderText = "Pago Por";
                dgvCobros.Columns["monto"].DefaultCellStyle.Format = "C2";
                dgvCobros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvCobros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvCobros.MultiSelect = false;
                dgvCobros.RowHeadersVisible = false;
            }

            if (basGlobals.listaCobros.Count > 0)
            {
                decImportePte = (Convert.ToDecimal(txTotal.Text.Replace("$", "").Replace(",", "").Trim()) - Convert.ToDecimal(basGlobals.listaCobros.Sum(p => p.monto).ToString()));
                txImportePte.Text = decImportePte.ToString("C2");

            }
            else
            {
                decImportePte = (Convert.ToDecimal(txTotal.Text.Replace("$", "").Replace(",", "").Trim()));
                txImportePte.Text = decImportePte.ToString("C2");
            }

            if (decImportePte > 0)
            {
                txImportePte.ForeColor = Color.Red;
            }
            else
            {
                txImportePte.ForeColor = Color.Black;
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cboAlumnos_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btDeleteProducto_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                int idProducto = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["id_producto"].Value);

                basGlobals.listaProductos.RemoveAll(p => p.id_producto == idProducto);
                dgvProductos.DataSource = null;
                dgvProductos.DataSource = basGlobals.listaProductos;
                dgvProductos.Columns["id_movimiento"].Visible = false;
                dgvProductos.Columns["id_producto"].Visible = false;
                dgvProductos.Columns["id"].Visible = false;
                dgvProductos.Columns["descriptionProducto"].HeaderText = "Producto";
                dgvProductos.Columns["cantidad"].HeaderText = "Qty";
                dgvProductos.Columns["cantidad"].DefaultCellStyle.Format = "N0";
                dgvProductos.Columns["monto"].HeaderText = "Monto";
                dgvProductos.Columns["monto"].DefaultCellStyle.Format = "C2";
                dgvProductos.Columns["monto_recargo"].HeaderText = "Recargo";
                dgvProductos.Columns["monto_recargo"].DefaultCellStyle.Format = "C2";
                dgvProductos.Columns["descriptionProducto"].Width = 220;
                dgvProductos.Columns["cantidad"].Width = 30;
                dgvProductos.Columns["monto"].Width = 110;
                dgvProductos.Columns["monto_recargo"].Width = 110;
                if (strConcepto == Conceptos.GASTOS.ToString())
                {
                    dgvProductos.Columns["descripcion"].HeaderText = "Descripcion";
                }
                else
                {
                    dgvProductos.Columns["descripcion"].Visible = false;
                }
                if (strConcepto == Conceptos.UNIFORMES.ToString())
                {
                    dgvProductos.Columns["talla"].HeaderText = "Talla";
                }
                else
                {
                    dgvProductos.Columns["talla"].Visible = false;
                }
                dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvProductos.MultiSelect = false;
                txImporte.Text = basGlobals.listaProductos.Sum(p => p.monto).ToString();
                txImporte.Text = Convert.ToDecimal(txImporte.Text).ToString("C2");
                txRecargo.Text = basGlobals.listaProductos.Sum(p => p.monto_recargo).ToString();
                txRecargo.Text = Convert.ToDecimal(txRecargo.Text).ToString("C2");
                txDescuento.Text = ((promocion / 100m) * basGlobals.listaProductos.Sum(p => p.monto)).ToString("C2");
                txTotal.Text = (Convert.ToDecimal(txImporte.Text.Replace("$", "").Replace(",", "").Trim()) + Convert.ToDecimal(txRecargo.Text.Replace("$", "").Replace(",", "").Trim())).ToString("C2");
                txImportePte.Text = txTotal.Text;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btDeletePago_Click(object sender, EventArgs e)
        {
            if (dgvCobros.SelectedRows.Count > 0)
            {
                int idCobro = Convert.ToInt32(dgvCobros.SelectedRows[0].Cells["id_cobro"].Value);
                basGlobals.listaCobros.RemoveAll(p => p.id_cobro == idCobro);
                dgvCobros.DataSource = null;
                dgvCobros.DataSource = basGlobals.listaCobros;
                dgvCobros.Columns["id_cobro"].Visible = false;
                dgvCobros.Columns["id_movimiento"].Visible = false;
                dgvCobros.Columns["tipopago"].Visible = false;
                dgvCobros.Columns["descripcionPago"].HeaderText = "Forma de Pago";
                dgvCobros.Columns["fechaAlta"].HeaderText = "Fecha Pago";
                dgvCobros.Columns["monto"].HeaderText = "Monto";
                dgvCobros.Columns["pago_por"].HeaderText = "Pago Por";
                dgvCobros.Columns["monto"].DefaultCellStyle.Format = "C2";
                dgvCobros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvCobros.RowHeadersVisible = false;

                decimal decImportePte = (Convert.ToDecimal(txTotal.Text.Replace("$", "").Replace(",", "").Trim()) - Convert.ToDecimal(basGlobals.listaCobros.Sum(p => p.monto).ToString()));
                txImportePte.Text = decImportePte.ToString("C2");
                if (decImportePte > 0)
                {
                    txImportePte.ForeColor = Color.Red;
                }
                else
                {
                    txImportePte.ForeColor = Color.Black;
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un cobro para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion
    }
}
