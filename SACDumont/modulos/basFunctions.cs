using ClosedXML.Excel;
using DocumentFormat.OpenXml.Math;
using FastReport;
using FastReport.Export.PdfSimple;
using SACDumont.Clases;
using SACDumont.Dtos;
using SACDumont.Models;
using SACDumont.modulos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SACDumont.Modulos.basConfiguracion;

namespace SACDumont.Modulos
{
    public class basFunctions
    {

        public static DataTable dtExportar;
        private const string claveSecreta = "Dumont";
        public void ConectaBD()
        {
            string sSQL = "";
            DataTable dtPaso = new DataTable();

            try
            {
                ConfigInfo config = basConfiguracion.LeerConfig(@"C:\SAC\configSecure.dll");

                // Variables para almacenar los datos
                string dbLocalHost = config.Servidor;
                string dbLocalName = config.BaseDatos;
                string dbLocalUser = config.Usuario;
                string dbLocalPassword = config.Contrasena;

                // Se establecen los parámetros de conexión a SQL Server
                sqlServer.Init(300, dbLocalName, dbLocalHost, dbLocalUser, dbLocalPassword);

                // Ejecutar consulta de prueba
                sqlServer.ExecSQL("USE " + dbLocalName);

                // Obtener número de sucursal
                sSQL = "SELECT TOP 1 * FROM Usuarios";
                //dtPaso = sqlServer.ExecSQLReturnDT(sSQL);
                if (dtPaso != null && dtPaso.Rows.Count > 0)
                {
                    // Procesamiento adicional si es necesario
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Copeland", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Environment.Exit(0); // equivalente a End
            }
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] entrada = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(entrada);
                return Convert.ToBase64String(hash);
            }
        }

        public void ExportarDataGridViewAExcel(DataGridView dgv, string rutaArchivo)
        {
            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Datos");

                // Escribir encabezados
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    ws.Cell(1, i + 1).Value = dgv.Columns[i].HeaderText;
                }

                // Escribir filas
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        ws.Cell(i + 2, j + 1).Value = dgv.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                wb.SaveAs(rutaArchivo);
            }
        }

        public void ExportarDataTableAExcel(DataTable dt, string rutaArchivo)
        {
            using (var wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Hoja1");
                wb.SaveAs(rutaArchivo);
            }
        }

        public void InsertarHistorial(string sAccion)
        {
            string sSQL;

            sSQL = "INSERT INTO LogFallas (idUsuario, Descripcion) VALUES(" + basConfiguracion.UserID + ",'" + sAccion + "')";
            sqlServer.ExecSQL(sSQL);

        }

        public bool DataVacio(DataTable dt)
        {
            return dt == null || dt.Rows.Count == 0;
        }

        public string DameFechaUltimoCorte()
        {
            string sSQL = "SELECT MAX(FechaCorte) AS Fecha FROM CIERREDIARIO";
            DataTable dtPaso = sqlServer.ExecSQLReturnDT(sSQL);

            if (dtPaso != null && dtPaso.Rows.Count > 0)
            {
                DataRow drPaso = dtPaso.Rows[0];
                return drPaso["Fecha"].ToString();
            }
            else
            {
                return "SIN FECHA";
            }
        }

        public void UpdateConfig(string spName, bool recargos, bool promo, int porcentajeRecargos, int diasTolerancia)
        {
            try
            {
                var parametros = new SqlParameter[]
                {
                    new SqlParameter("@Recargos", SqlDbType.Bit) { Value = recargos },
                    new SqlParameter("@Promo", SqlDbType.Bit) { Value =promo },
                    new SqlParameter("@PorcentajeRecargo", SqlDbType.Int, 100) { Value = porcentajeRecargos },
                    new SqlParameter("@DiasTolerancia", SqlDbType.Int, 100) { Value = diasTolerancia }
                };


                sqlServer.ExecSPNoQuery(spName, parametros);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SAC-Dumont", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public static void CargarCatalogo(ComboBox combo, string tabla, string campoClave, string campoTexto, string whereClause = "")
        {
            DataTable dt = new DataTable();
            dt = sqlServer.ExecSQLReturnDT($"SELECT {campoClave}, {campoTexto} FROM {tabla} {whereClause} ORDER BY {campoTexto}", "Catalogos");

            combo.DataSource = dt;
            combo.DisplayMember = campoTexto;
            combo.ValueMember = campoClave;
            combo.DropDownStyle = ComboBoxStyle.DropDown;
            combo.SelectedIndex = -1;
        }

        public static void CargarCatalogoGeneral(ComboBox combo, string tipoCatalogo)
        {
            DataTable dt = new DataTable();
            dt = sqlServer.ExecSQLReturnDT($"SELECT descripcion, valor FROM catalogos WHERE tipo_catalogo = '{tipoCatalogo}'", "Catalogos");

            combo.DataSource = dt;
            combo.DisplayMember = "descripcion";
            combo.ValueMember = "valor";
            combo.DropDownStyle = ComboBoxStyle.DropDown;
            combo.SelectedIndex = -1;
        }

        public static void CargarCatalogoAlumnos(ComboBox combo)
        {
            DataTable dt = new DataTable();
            dt = sqlServer.ExecSQLReturnDT($"SELECT matricula, a.appaterno + ' ' + a.apmaterno + ' ' + a.nombre AS nombrecompleto FROM alumnos a WHERE a.activo = 1 ORDER BY nombrecompleto", "Alumnos");

            combo.DataSource = dt;
            combo.DisplayMember = "matricula";
            combo.ValueMember = "nombrecompleto";
            combo.DropDownStyle = ComboBoxStyle.DropDown;
            combo.SelectedIndex = -1;
        }

        public static void ValidarYAgregarNuevo(ComboBox combo, string tabla, string campoTexto, int idDependiente = 0)
        {
            string texto = combo.Text.Trim();
            if (string.IsNullOrWhiteSpace(texto)) return;

            bool existe = false;
            foreach (DataRowView item in combo.Items)
            {
                if (item[combo.DisplayMember].ToString().Equals(texto, StringComparison.OrdinalIgnoreCase))
                {
                    existe = true;
                    break;
                }
            }

            if (!existe)
            {
                DialogResult r = MessageBox.Show(
                    $"“{texto}” no está en el catálogo de {tabla}. ¿Deseas agregarlo?",
                    "Agregar al catálogo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {

                    sqlServer.ExecSQL($"INSERT INTO {tabla} ({campoTexto}, PaisId) VALUES ('{texto}',{idDependiente})");

                    // Recargar
                    CargarCatalogo(combo, tabla, combo.ValueMember, combo.DisplayMember);
                    combo.SelectedIndex = combo.FindStringExact(texto);
                    MessageBox.Show("Elemento agregado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public static void ValidarYAgregarNuevoP(string valor, string valor2, string valor3, string tabla)
        {
            bool existe = false;
            using (var db = new DumontContext())
            {
                var productos = db.Productos.Where(p => p.descripcion == valor).FirstOrDefault();
                if (productos != null)
                {
                    existe = true;
                }
            }

            if (!existe)
            {
                DialogResult r = MessageBox.Show(
                    $"“{valor}” no está en el catálogo de {tabla}. ¿Deseas agregarlo?",
                    "Agregar Producto",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {

                    sqlServer.ExecSQL($"INSERT INTO {tabla} (descripcion, concepto, abreviatura) VALUES ('{valor}','{valor2}','{valor3}')");

                    MessageBox.Show("Elemento agregado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        public static void LimpiarCombo(ComboBox combo)
        {
            combo.DataSource = null;
            combo.Items.Clear();
            combo.Text = string.Empty;
            combo.SelectedIndex = -1;
        }

        public static void Registrar(int usuario, string modulo, string tipoAccion, int entidadId, string descripcion = "")
        {
            try
            {
                string sql = $"INSERT INTO acciones (fecha, id_usuario, modulo, tipo_accion, entidad_id, descripcion) VALUES (GETDATE(), {usuario}, '{modulo}', '{tipoAccion}', {entidadId}, '{descripcion}')";
                sqlServer.ExecSQL(sql);
            }
            catch (Exception ex)
            {
                // Aquí podrías registrar el error en un archivo de log o mostrar un mensaje
                Console.WriteLine("Error al registrar en la bitácora: " + ex.Message);
            }
        }

        public static void CargarAcciones(ref DataGridView dgvAcciones, string modulo, int entidadId)
        {
            try
            {
                DataTable dtAcciones = new DataTable();
                string sql = $"SELECT acc.fecha as Fecha, us.nombre_usuario AS Usuario, acc.tipo_accion AS [Tipo Movimiento], acc.descripcion AS Descripcion  FROM acciones acc INNER JOIN usuarios us ON acc.id_usuario = us.id_usuario WHERE acc.modulo = '{modulo}' AND acc.entidad_id = {entidadId} ORDER BY acc.fecha";
                dtAcciones = sqlServer.ExecSQLReturnDT(sql, "Acciones");
                dgvAcciones.DataSource = dtAcciones;
                dgvAcciones.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            }
            catch (Exception ex)
            {
                // Aquí podrías registrar el error en un archivo de log o mostrar un mensaje
                Console.WriteLine("Error al registrar en la bitácora: " + ex.Message);
            }
        }

        public static string ObtenerPin(string usuario)
        {
            // Tiempo actual en UTC para que sea igual en todas partes
            string fecha = DateTime.UtcNow.ToString("yyyyMMddHHmm");

            // Creamos la cadena base con la clave secreta y la ventana de tiempo
            string baseString = claveSecreta + usuario + fecha;

            using (SHA256 sha = SHA256.Create())
            {
                byte[] hashBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(baseString));
                int hash = BitConverter.ToInt32(hashBytes, 0);
                hash = Math.Abs(hash);

                return (hash % 10000).ToString("D4");
            }
        }

        public static bool ValidarPin(string pinIngresado, string usuario)
        {
            return ObtenerPin(usuario) == pinIngresado;
        }

        public static void CenterSpinnerOverGrid(Form form, PictureBox picture)
        {
            picture.Left = (form.ClientSize.Width - picture.Width) / 2;
            picture.Top = (form.ClientSize.Height - picture.Height) / 2;
        }

        public static DataTable ConvertToDataTable<T>(List<T> items)
        {
            var dataTable = new DataTable(typeof(T).Name);
            var propiedades = typeof(T).GetProperties();

            foreach (var prop in propiedades)
            {
                Type colType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                dataTable.Columns.Add(prop.Name, colType);
            }

            foreach (var item in items)
            {
                var values = new object[propiedades.Length];
                for (int i = 0; i < propiedades.Length; i++)
                {
                    values[i] = propiedades[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        public static void ExportarYMostrarPDF(string reporteName, DataTable datos, string nombreDatos, string PDFname)
        {

            // 2. Cargar el reporte
            string rutaFrx = Path.Combine(Application.StartupPath, "Reportes", reporteName);
            Report report = new Report();
            report.Load(rutaFrx);

            report.RegisterData(datos, nombreDatos);
            report.GetDataSource(nombreDatos).Enabled = true;
            // 3. Forzar carga de Microsoft.CSharp
            System.Runtime.CompilerServices.RuntimeHelpers
                .RunClassConstructor(typeof(Microsoft.CSharp.RuntimeBinder.Binder).TypeHandle);

            // 4. Preparar y exportar
            report.Prepare();
            string rutaPDF = Path.Combine(Application.StartupPath, $"{PDFname}.pdf");
            report.Export(new PDFSimpleExport(), rutaPDF);

            string rutaSumatra = Path.Combine(Application.StartupPath, "PDF", "SumatraPDF.exe");

            if (!File.Exists(rutaSumatra))
            {
                MessageBox.Show("No se encontró SumatraPDF.exe. Asegúrate de colocarlo junto a la aplicación.");
                return;
            }

            // 5. Abrir visor PDF predeterminado
            Process.Start(new ProcessStartInfo
            {
                FileName = rutaPDF,
                UseShellExecute = true
            });
        }

        public static void ExportarYMostrarPDF2DT(string reporteName, DataTable datos, DataTable datos2, string nombreDatos, string nombreDatos2)
        {

            // 2. Cargar el reporte
            string rutaFrx = Path.Combine(Application.StartupPath, "Reportes", reporteName);
            Report report = new Report();
            report.Load(rutaFrx);

            report.RegisterData(datos, nombreDatos);
            report.RegisterData(datos2, nombreDatos2);
            report.GetDataSource(nombreDatos).Enabled = true;
            report.GetDataSource(nombreDatos2).Enabled = true;


            // 3. Forzar carga de Microsoft.CSharp
            System.Runtime.CompilerServices.RuntimeHelpers
                .RunClassConstructor(typeof(Microsoft.CSharp.RuntimeBinder.Binder).TypeHandle);

            // 4. Preparar y exportar
            report.Prepare();
            string rutaPDF = Path.Combine(Application.StartupPath, "Reporte.pdf");
            report.Export(new PDFSimpleExport(), rutaPDF);

            string rutaSumatra = Path.Combine(Application.StartupPath, "PDF", "SumatraPDF.exe");

            if (!File.Exists(rutaSumatra))
            {
                MessageBox.Show("No se encontró SumatraPDF.exe. Asegúrate de colocarlo junto a la aplicación.");
                return;
            }

            // 5. Abrir visor PDF predeterminado
            Process.Start(new ProcessStartInfo
            {
                FileName = rutaPDF,
                UseShellExecute = true
            });
        }

        public static void ExportarYMostrarPDF3DT(string reporteName, DataTable datos, DataTable datos2, DataTable datos3, string nombreDatos, string nombreDatos2, string nombreDatos3)
        {

            // 2. Cargar el reporte
            string rutaFrx = Path.Combine(Application.StartupPath, "Reportes", reporteName);
            Report report = new Report();
            report.Load(rutaFrx);

            report.RegisterData(datos, nombreDatos);
            report.RegisterData(datos2, nombreDatos2);
            report.RegisterData(datos3, nombreDatos3);


            // 3. Forzar carga de Microsoft.CSharp
            System.Runtime.CompilerServices.RuntimeHelpers
                .RunClassConstructor(typeof(Microsoft.CSharp.RuntimeBinder.Binder).TypeHandle);

            // 4. Preparar y exportar
            report.Prepare();
            string rutaPDF = Path.Combine(Application.StartupPath, "Reporte.pdf");
            report.Export(new PDFSimpleExport(), rutaPDF);

            string rutaSumatra = Path.Combine(Application.StartupPath, "PDF", "SumatraPDF.exe");

            if (!File.Exists(rutaSumatra))
            {
                MessageBox.Show("No se encontró SumatraPDF.exe. Asegúrate de colocarlo junto a la aplicación.");
                return;
            }

            // 5. Abrir visor PDF predeterminado
            Process.Start(new ProcessStartInfo
            {
                FileName = rutaPDF,
                UseShellExecute = true
            });
        }
        public void ExportareImprimirSinAbrir(int idMov)
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

            string rutaSumatra = Path.Combine(Application.StartupPath, "PDF", "SumatraPDF.exe");

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

        public static void AlumnosExportarYMostrarPDF(int idGrupo, int idGrado)
        {
            // 1. Crear DataTable
            string nombreReporte = "Reporte";
            DataTable dataTable = new DataTable();
            List<AlumnosDTO> alumnosDTO = new List<AlumnosDTO>();
            using (var db = new DumontContext())
            {
                var lista = db.Inscripciones
                  .Where(m => m.id_ciclo == basGlobals.iCiclo && m.id_grupo == idGrupo && m.id_grado == idGrado)
                  .Include(m => m.Alumnos)
                  .Select(m => new AlumnosDTO
                  {
                      Grupo = db.Catalogos.Where(c => c.valor == idGrupo && c.tipo_catalogo == "Grupo").Select(c => c.descripcion).FirstOrDefault(),
                      Grado = db.Catalogos.Where(c => c.valor == idGrado && c.tipo_catalogo == "Grado").Select(c => c.descripcion).FirstOrDefault(),
                      Alumno = db.Alumnos
                                  .Where(a => a.matricula == m.matricula)
                                  .Select(a => a.appaterno + " " + a.apmaterno + " " + a.nombre)
                                  .FirstOrDefault(),
                      Matricula = m.matricula.ToString()
                  })
                  .ToList();

                if (lista.Count > 0)
                {
                    nombreReporte = lista[0].Grado;
                }

                alumnosDTO = lista;
            }

            dataTable = basFunctions.ConvertToDataTable(alumnosDTO);
            // 2. Cargar el reporte
            string rutaFrx = Path.Combine(Application.StartupPath, "Reportes", "Alumnos.frx");
            Report report = new Report();
            report.Load(rutaFrx);
            report.RegisterData(dataTable, "TicketData");
            report.GetDataSource("TicketData").Enabled = true;

            // 3. Forzar carga de Microsoft.CSharp
            System.Runtime.CompilerServices.RuntimeHelpers
                .RunClassConstructor(typeof(Microsoft.CSharp.RuntimeBinder.Binder).TypeHandle);

            // 4. Preparar y exportar
            report.Prepare();
            string rutaPDF = Path.Combine(Application.StartupPath, $"{nombreReporte}.pdf");
            report.Export(new PDFSimpleExport(), rutaPDF);

            // 5. Abrir visor PDF predeterminado
            Process.Start(new ProcessStartInfo
            {
                FileName = rutaPDF,
                UseShellExecute = true
            });
        }

        public static void AgregaImpresorasTickets(ToolStripMenuItem impresoraMenu)
        {
            impresoraMenu.DropDownItems.Clear();

            int maxImpresoras = 15;
            int index = 0;

            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                if (index >= maxImpresoras) break;

                ToolStripMenuItem item = new ToolStripMenuItem
                {
                    Text = printer,
                    Name = printer
                };

                // Asigna evento click
                item.Click += (sender, e) =>
                {
                    // Desmarca todas
                    foreach (ToolStripMenuItem mi in impresoraMenu.DropDownItems)
                        mi.Checked = false;

                    // Marca la seleccionada
                    item.Checked = true;

                    // Guarda el nombre seleccionado
                    basConfiguracion.PrinterTiockets = item.Name;

                    MessageBox.Show($"Impresora seleccionada: {basConfiguracion.PrinterTiockets}", "Seleccionada");
                };

                impresoraMenu.DropDownItems.Add(item);
                index++;
            }

            // Oculta extras
            for (int j = index; j < maxImpresoras; j++)
            {
                ToolStripMenuItem item = new ToolStripMenuItem
                {
                    Text = $"(Vacío {j + 1})",
                    Visible = false
                };
                impresoraMenu.DropDownItems.Add(item);
            }
        }

        public static void AgregaImpresoras(ToolStripMenuItem impresoraMenu)
        {
            impresoraMenu.DropDownItems.Clear();

            int maxImpresoras = 15;
            int index = 0;

            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                if (index >= maxImpresoras) break;

                ToolStripMenuItem item = new ToolStripMenuItem
                {
                    Text = printer,
                    Name = printer
                };

                // Asigna evento click
                item.Click += (sender, e) =>
                {
                    // Desmarca todas
                    foreach (ToolStripMenuItem mi in impresoraMenu.DropDownItems)
                        mi.Checked = false;

                    // Marca la seleccionada
                    item.Checked = true;

                    // Guarda el nombre seleccionado
                    basConfiguracion.Printer = item.Name;

                    MessageBox.Show($"Impresora seleccionada: {basConfiguracion.Printer}", "Seleccionada");
                };

                impresoraMenu.DropDownItems.Add(item);
                index++;
            }

            // Oculta extras
            for (int j = index; j < maxImpresoras; j++)
            {
                ToolStripMenuItem item = new ToolStripMenuItem
                {
                    Text = $"(Vacío {j + 1})",
                    Visible = false
                };
                impresoraMenu.DropDownItems.Add(item);
            }
        }

        public static DateTime RevisarFechaCierre()
        {
            cierre_diario ultimoCierre = new cierre_diario();
            using (var db = new DumontContext())
            {
                ultimoCierre = db.CierreDiario
                .OrderByDescending(t => t.id).FirstOrDefault();
            }

            return ultimoCierre.fechacorte;

        }

        public static bool ValidaCierre()
        {
            cierre_diario ultimoCierre = new cierre_diario();
            using (var db = new DumontContext())
            {
                ultimoCierre = db.CierreDiario.Where(cd => cd.fechacorte == DateTime.Today).FirstOrDefault();
            }

            return ultimoCierre != null;
        }

        public static void PreparaReporteCierreFecha(DateTime fecha)
        {
            try
            {


                DataTable dtResumen = new DataTable("Resumen");
                DataTable dtBilletes = new DataTable("Billetes"); ;
                DataTable dtDetalle = new DataTable("Detalle"); ;

                using (var db = new DumontContext())
                {
                    var resumen = (from m in db.Movimientos
                                   join mp in db.MovimientoProductos on m.id_movimiento equals mp.id_movimiento
                                   join c in db.MovimientoCobros on m.id_movimiento equals c.id_movimiento into cobrosGroup
                                   from c in cobrosGroup.DefaultIfEmpty()
                                   join cat in db.Catalogos on new { valor = (int?)c.tipopago, tipo_catalogo = "TipoPago" }
                                                              equals new { valor = (int?)cat.valor, cat.tipo_catalogo } into catalogosGroup
                                   from cat in catalogosGroup.DefaultIfEmpty()
                                   where DbFunctions.TruncateTime(m.fechahora) == DbFunctions.TruncateTime(fecha)
                                   group c by cat.descripcion into g
                                   select new
                                   {
                                       Tipo = g.Key,
                                       Monto = g.Sum(x => x != null ? x.monto : 0)
                                   }).ToList();

                    var billetes = db.CierreDiario
                                     .Where(cd => DbFunctions.TruncateTime(cd.fechacorte) == DbFunctions.TruncateTime(fecha))
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
                                         cd.M050
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

                                    where DbFunctions.TruncateTime(m.fechahora) == DbFunctions.TruncateTime(fecha)

                                    group new { c, mp, p, a } by new
                                    {
                                        Alumno = (a.appaterno ?? "") + " " + (a.apmaterno ?? "") + " " + (a.nombre ?? ""),
                                        Concepto = p.concepto,
                                        MotivoGasto = mp.descripcion,
                                        Monto = c.monto
                                    } into g

                                    select new
                                    {
                                        Alumno = (g.Key.Alumno == null || g.Key.Alumno.Trim() == "") ? "GASTO" : g.Key.Alumno,
                                        Concepto = g.Key.Concepto,
                                        MotivoGasto = g.Key.MotivoGasto ?? "",
                                        Monto = g.Key.Monto
                                    }).ToList();

                    dtResumen = basFunctions.ConvertToDataTable(resumen);
                    dtDetalle = basFunctions.ConvertToDataTable(detalles);
                    dtBilletes = basFunctions.ConvertToDataTable(billetes);

                    basFunctions.ExportarYMostrarPDF3DT("CierreDiario.frx", dtResumen, dtDetalle, dtBilletes, "Resumen", "Detalle", "Billetes");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static bool ValidaCierrePorFecha(DateTime date)
        {
            cierre_diario ultimoCierre = new cierre_diario();
            using (var db = new DumontContext())
            {
                ultimoCierre = db.CierreDiario.Where(cd => cd.fechacorte == DbFunctions.TruncateTime(date)).FirstOrDefault();
            }

            return ultimoCierre != null;
        }

    }
}
