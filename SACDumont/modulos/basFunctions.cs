using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SACDumont.Clases;
using System.IO;
using System.Data.SqlClient;
using System.Security.Cryptography;
using ClosedXML.Excel;
using static SACDumont.Modulos.basConfiguracion;
using DocumentFormat.OpenXml.Math;
using System.Security.RightsManagement;

namespace SACDumont.Modulos
{
    public class basFunctions
    {
        private static readonly string clave = "TuClaveSecreta123"; // debe ser de 16, 24 o 32 caracteres
        private static readonly string iv = "VectorInicial1234";    // debe ser de 16 caracteres
        public static DataTable dtExportar;
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

    }
}
