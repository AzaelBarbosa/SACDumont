using ClosedXML.Excel;
using DocumentFormat.OpenXml.Math;
using FastReport.Export.PdfSimple;
using SACDumont.Clases;
using SACDumont.Dtos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SACDumont.Modulos.basConfiguracion;
using FastReport;
using FastReport.Export.PdfSimple;
using System.Data.Entity;

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
                string sql = $"SELECT acc.fecha as Fecha, us.nombre_usuario, acc.tipo_accion AS [Tipo Movimiento], acc.descripcion AS Descripcion  FROM acciones acc INNER JOIN usuarios us ON acc.id_usuario = us.id_usuario WHERE acc.modulo = '{modulo}' AND acc.entidad_id = {entidadId} ORDER BY acc.fecha";
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

        public static string ObtenerPin()
        {
            string fecha = DateTime.Now.ToString("yyyyMMdd");
            string baseString = claveSecreta + fecha;

            // Usamos hash simple para generar PIN
            int hash = baseString.GetHashCode();
            hash = Math.Abs(hash);

            // Tomamos los últimos 4 dígitos como PIN
            return (hash % 10000).ToString("D4");
        }

        public static bool ValidarPin(string pinIngresado)
        {
            return ObtenerPin() == pinIngresado;
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

        public static void ExportareImprimirSinAbrir(int idMov)
        {
            if (idMov == 0) return;

            DataTable dataTable = new DataTable();
            List<ReportesDTO> reportesDTO = new List<ReportesDTO>();
            using (var db = new DumontContext())
            {
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
                      Grupo = db.Catalogos.Where(c => c.valor == m.id_ciclo && c.tipo_catalogo == "Grupo").Select(c => c.descripcion).FirstOrDefault(),
                      Matricula = m.id_matricula,
                      Alumno = db.Alumnos
                                  .Where(a => a.matricula == m.id_matricula)
                                  .Select(a => a.appaterno + " " + a.apmaterno + " " + a.nombre)
                                  .FirstOrDefault(),
                      MontoPendiente = m.montoTotal - db.MovimientoCobros.Where(mc => mc.id_movimiento == m.id_movimiento).Sum(mc => mc.monto),
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
}
