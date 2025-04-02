using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDURechazos.Clases
{
    class sqlServer
    {
        // Shared (estáticos)
        private static string mstrConnection;
        private static SqlConnection mobjConnection;
        private static SqlTransaction mobjTransaction;
        private static string mstrModuleName;
        private static bool mblnDisposed = false;
        private static int mintTimeOut = 300;

        // No compartidos (por instancia)
        private string mstrConnection_2;
        private SqlConnection mobjConnection_2;
        private SqlTransaction mobjTransaction_2;
        private string mstrModuleName_2;
        private bool mblnDisposed_2 = false;
        private int mintTimeOut_2 = 300;

        // Constante
        private const string EXCEPTION_MSG = "There was an error in the method. " +
                                             "Please see the Application Log for details.";

        public static void Init(int intTimeOut = 300, string strCatalog = "", string strDataSrc = "", string strUserID = "", string strPW = "")
        {
            string REGPATH = @"SOFTWARE\Image Technology\VisualMatrix\Data";

            if (string.IsNullOrEmpty(strCatalog))
            {
                // strCatalog = GetReg(REGPATH, "DBCatalog", "VisualMatrix");
                strCatalog = "bd_valessa02";
            }

            if (string.IsNullOrEmpty(strDataSrc))
            {
                // strDataSrc = GetReg(REGPATH, "DBDataSource", "(LOCAL)\\VISUALMATRIX");
                strDataSrc = @"MATAPORTATIL\SQLEXPRESS2008";
                // strDataSrc += @"\SQLEXPRESS2008"; // Comentado como en VB
            }

            if (string.IsNullOrEmpty(strUserID))
            {
                // strUserID = GetReg(REGPATH, "DBUserID", "VisualMatrix");
                strUserID = "sa";
            }

            if (string.IsNullOrEmpty(strPW))
            {
                // strPW = GetVMPassword();
                // if (strPW == "") strPW = GetReg(REGPATH, "DBPassword", "VisualMatrix");
                strPW = "12345678";
            }

            // Cadena de conexión
            mstrConnection = $"Data Source={strDataSrc};Initial Catalog={strCatalog};User Id={strUserID};Password={strPW};";

            mintTimeOut = intTimeOut;

            try
            {
                mobjConnection = new SqlConnection(mstrConnection);
            }
            catch (Exception ex)
            {
                // Manejo de errores opcional
            }
        }

        #region ExecSP

        public static void ExecSP(string spName, SqlParameter[] paramValues = null)
        {
            SqlCommand objCommand;

            try
            {
                if (mblnDisposed)
                    throw new ObjectDisposedException(mstrModuleName, "This object has already been disposed.");

                if (mobjConnection.State != ConnectionState.Open)
                    mobjConnection.Open();

                objCommand = new SqlCommand(spName, mobjConnection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = mintTimeOut
                };

                if (paramValues != null)
                    AttachParameters(objCommand, paramValues);

                if (mobjTransaction != null)
                    objCommand.Transaction = mobjTransaction;

                objCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region ExecSPNoQuery

        public static List<object> ExecSPNoQuery(string spName, SqlParameter[] paramValues = null)
        {
            var objCommand = new SqlCommand(spName, mobjConnection);
            var returnValues = new List<object>();

            try
            {
                if (mobjConnection.State != ConnectionState.Open)
                    mobjConnection.Open();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandTimeout = mintTimeOut;

                if (paramValues != null)
                    AttachParameters(objCommand, paramValues);

                if (mobjTransaction != null)
                    objCommand.Transaction = mobjTransaction;

                objCommand.ExecuteNonQuery();

                foreach (SqlParameter param in objCommand.Parameters)
                {
                    if (param.Direction == ParameterDirection.Output)
                        returnValues.Add(param.Value);
                }

                return returnValues;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region ExecSPOutputValues

        public static List<object> ExecSPOutputValues(string spName, SqlParameter[] paramValues = null)
        {
            SqlCommand objCommand;
            var outputValues = new List<object>();

            try
            {
                if (mblnDisposed)
                    throw new ObjectDisposedException(mstrModuleName, "This object has already been disposed.");

                if (mobjConnection.State != ConnectionState.Open)
                    mobjConnection.Open();

                objCommand = new SqlCommand(spName, mobjConnection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = mintTimeOut
                };

                if (paramValues != null)
                    AttachParameters(objCommand, paramValues);

                if (mobjTransaction != null)
                    objCommand.Transaction = mobjTransaction;

                objCommand.ExecuteNonQuery();

                foreach (SqlParameter param in objCommand.Parameters)
                {
                    if (param.Direction == ParameterDirection.Output ||
                        param.Direction == ParameterDirection.InputOutput)
                    {
                        outputValues.Add(param.Value);
                    }
                }

                return outputValues;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region ExecSPReturnValue

        public static List<object> ExecSPReturnValue(string spName, SqlParameter[] paramValues = null)
        {
            SqlCommand objCommand;
            var returnValues = new List<object>();

            try
            {
                if (mblnDisposed)
                    throw new ObjectDisposedException(mstrModuleName, "This object has already been disposed.");

                if (mobjConnection.State != ConnectionState.Open)
                    mobjConnection.Open();

                objCommand = new SqlCommand(spName, mobjConnection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = mintTimeOut
                };

                if (paramValues != null)
                    AttachParameters(objCommand, paramValues);

                if (mobjTransaction != null)
                    objCommand.Transaction = mobjTransaction;

                objCommand.ExecuteNonQuery();

                foreach (SqlParameter param in objCommand.Parameters)
                {
                    if (param.Direction == ParameterDirection.Output ||
                        param.Direction == ParameterDirection.ReturnValue)
                    {
                        returnValues.Add(param.Value);
                    }
                }

                return returnValues;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region AssignParameterValues

        private static void AssignParameterValues(SqlParameter[] commandParameters, object[] parameterValues)
        {
            if (commandParameters == null && parameterValues == null)
                return;

            if (commandParameters.Length != parameterValues.Length)
                throw new ArgumentException("Parameter count does not match Parameter Value count.");

            for (int i = 0; i < commandParameters.Length; i++)
            {
                commandParameters[i].Value = parameterValues[i];
            }
        }

        #endregion

        #region PrepareCommand

        private static void PrepareCommand(SqlCommand command,
                                           SqlConnection connection,
                                           SqlTransaction transaction,
                                           CommandType commandType,
                                           string commandText,
                                           SqlParameter[] commandParameters)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();

            command.Connection = connection;
            command.CommandText = commandText;

            if (transaction != null)
                command.Transaction = transaction;

            command.CommandType = commandType;

            if (commandParameters != null)
                AttachParameters(command, commandParameters);
        }

        #endregion

        #region AttachParameters

        private static void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
        {
            foreach (SqlParameter p in commandParameters)
            {
                if (p.Direction == ParameterDirection.InputOutput && p.Value == null)
                {
                    p.Value = DBNull.Value; // mejor que `null` para evitar errores en SQL Server
                }

                command.Parameters.Add(p);
            }
        }

        #endregion

        #region ExecSQLReturnDT_2

        public DataTable ExecSQLReturnDT_2(string strSQL, string tableName = "")
        {
            SqlCommand objCommand;
            SqlDataAdapter objDA;
            DataTable objDT = new DataTable();

            try
            {
                if (mblnDisposed_2)
                    throw new ObjectDisposedException(mstrModuleName_2, "This object has already been disposed.");

                if (mobjConnection_2.State != ConnectionState.Open)
                    mobjConnection_2.Open();

                objCommand = new SqlCommand(strSQL, mobjConnection_2)
                {
                    CommandTimeout = 300,
                    CommandType = CommandType.Text
                };

                if (mobjTransaction_2 != null)
                    objCommand.Transaction = mobjTransaction_2;

                objDA = new SqlDataAdapter(objCommand);
                objDA.Fill(objDT);
                objDT.TableName = tableName;

                return objDT;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region ExecSQLReturnDT

        public static DataTable ExecSQLReturnDT(string strSQL, string tableName = "NewTable")
        {
            SqlCommand objCommand;
            SqlDataAdapter objDA;
            DataTable objDT = new DataTable();

            try
            {
                if (mblnDisposed)
                    throw new ObjectDisposedException(mstrModuleName, "This object has already been disposed.");

                if (mobjConnection.State != ConnectionState.Open)
                    mobjConnection.Open();

                objCommand = new SqlCommand(strSQL, mobjConnection)
                {
                    CommandTimeout = 300,
                    CommandType = CommandType.Text
                };

                if (mobjTransaction != null)
                    objCommand.Transaction = mobjTransaction;

                objDA = new SqlDataAdapter(objCommand);
                objDA.Fill(objDT);
                objDT.TableName = tableName;

                return objDT;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region ExecSQL_2

        public void ExecSQL_2(string strSQL)
        {
            SqlCommand objCommand;

            try
            {
                if (mblnDisposed_2)
                    throw new ObjectDisposedException(mstrModuleName_2, "This object has already been disposed.");

                if (mobjConnection_2.State != ConnectionState.Open)
                    mobjConnection_2.Open();

                objCommand = new SqlCommand(strSQL, mobjConnection_2)
                {
                    CommandTimeout = mintTimeOut,
                    CommandType = CommandType.Text
                };

                if (mobjTransaction_2 != null)
                    objCommand.Transaction = mobjTransaction_2;

                objCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region ExecSQL

        public static void ExecSQL(string strSQL)
        {
            SqlCommand objCommand;

            try
            {
                if (mblnDisposed)
                    throw new ObjectDisposedException(mstrModuleName, "This object has already been disposed.");

                if (mobjConnection.State != ConnectionState.Open)
                    mobjConnection.Open();

                objCommand = new SqlCommand(strSQL, mobjConnection)
                {
                    CommandTimeout = mintTimeOut,
                    CommandType = CommandType.Text
                };

                if (mobjTransaction != null)
                    objCommand.Transaction = mobjTransaction;

                objCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region ExecSQLReturnDS

        public static DataSet ExecSQLReturnDS(string strSQL, string strTableName = "Table")
        {
            SqlCommand objCommand;
            SqlDataAdapter objDA;
            DataSet objDS = new DataSet();

            try
            {
                if (mblnDisposed)
                    throw new ObjectDisposedException(mstrModuleName, "This object has already been disposed.");

                if (mobjConnection.State != ConnectionState.Open)
                    mobjConnection.Open();

                objCommand = new SqlCommand(strSQL, mobjConnection)
                {
                    CommandTimeout = mintTimeOut,
                    CommandType = CommandType.Text
                };

                if (mobjTransaction != null)
                    objCommand.Transaction = mobjTransaction;

                objDA = new SqlDataAdapter(objCommand);
                objDA.Fill(objDS, strTableName);

                return objDS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
