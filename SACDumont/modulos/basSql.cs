using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SACDumont.Clases;

namespace SACDumont.modulos
{
    internal class basSql
    {
        public DataSet GetMovimientoDetalle(int idRegistro)
        {
            DataSet ds = new DataSet("MovimientoDetalle");
            string strSQL;
            DataTable dsTemp = new DataTable("Temp");

            //Movimiento
            strSQL = $@"SELECT a.matricula, m.id_registros ,m.fechahora AS Fecha, a.apmaterno + ' ' + a.apmaterno + ' ' + a.nombre AS Alumno, cat.descripcion AS Grado, catG.descripcion AS Grupo, p.descripcion AS Descripcion, 
                        m.montoTotal - (SELECT SUM(monto) FROM cobros WHERE id_movimiento = m.id_registros) AS MontoPendiente, m.montoTotal AS Total, catP.descripcion AS FormaPago, catE.descripcion AS Estatus, p.descripcion AS Producto, m.porcentaje_descuento AS Descuento,
                        m.monto_descuento AS MontoDescuento, m.beca_descuento AS BecaDescuento
                        FROM movimientos m
                        INNER JOIN movimiento_productos mp ON m.id_registros = mp.id_movimiento
                        INNER JOIN productos p ON p.id_producto = mp.id_producto
                        INNER JOIN alumnos a ON a.matricula = m.id_matricula
                        INNER JOIN inscripciones i ON i.matricula = a.matricula
                        LEFT JOIN catalogos cat ON cat.valor = i.id_grado AND cat.tipo_catalogo = 'Grado' 
                        LEFT JOIN catalogos catG ON catG.valor = i.id_grupo AND catG.tipo_catalogo = 'Grupo' 
                        LEFT JOIN catalogos catP ON catP.valor = m.id_tipopago AND catP.tipo_catalogo = 'TipoPago' 
                        LEFT JOIN catalogos catE ON catE.valor = m.id_estatusmovimiento AND catE.tipo_catalogo = 'EstatusMovimiento'
                        WHERE m.id_ciclo = {basGlobals.iCiclo} AND m.id_registros = {idRegistro}";
            dsTemp = sqlServer.ExecSQLReturnDT(strSQL,"Movimiento");
            ds.Tables.Add(dsTemp);

            //Productos
            strSQL = $@"SELECT p.concepto AS Concepto, p.descripcion AS Producto, mp.cantidad, mp.id_movimiento, mp.monto, mp.monto_recargo
                        FROM movimientos m
                        INNER JOIN movimiento_productos mp ON m.id_registros = mp.id_movimiento
                        INNER JOIN productos p ON p.id_producto = mp.id_producto
                        WHERE m.id_registros = {idRegistro}";
            dsTemp = sqlServer.ExecSQLReturnDT(strSQL, "Productos");
            ds.Tables.Add(dsTemp);

            //Cobros
            strSQL = $@"SELECT c.id_cobro, c.monto, catP.descripcion AS FormaPago
                        FROM movimientos m
                        INNER JOIN cobros c ON c.id_movimiento = m.id_registros
                        LEFT JOIN catalogos catP ON catP.valor = m.id_tipopago AND catP.tipo_catalogo = 'TipoPago' 
                        WHERE m.id_registros = {idRegistro}";
            dsTemp = sqlServer.ExecSQLReturnDT(strSQL, "Cobros");
            ds.Tables.Add(dsTemp);

            return ds;
        }

        public DataSet GetMovimientoProductos(int idRegistro)
        {
            DataSet ds = new DataSet("MovimientoProductos");
            string strSQL;
            DataTable dsTemp = new DataTable("Temp");

            //Productos
            strSQL = $@"SELECT p.concepto AS Concepto, p.descripcion AS Producto, mp.cantidad, mp.id_movimiento, mp.monto, mp.monto_recargo
                        FROM movimientos m
                        INNER JOIN movimiento_productos mp ON m.id_registros = mp.id_movimiento
                        INNER JOIN productos p ON p.id_producto = mp.id_producto
                        WHERE m.id_registros = {idRegistro}";
            dsTemp = sqlServer.ExecSQLReturnDT(strSQL, "Productos");
            ds.Tables.Add(dsTemp);

            return ds;
        }

        public DataSet GetMovimientosPagos(int idRegistro)
        {
            DataSet ds = new DataSet("MovimientoDetalle");
            string strSQL;
            DataTable dsTemp = new DataTable("Temp");

            //Cobros
            strSQL = $@"SELECT c.id_cobro, c.monto, catP.descripcion AS FormaPago
                        FROM movimientos m
                        INNER JOIN cobros c ON c.id_movimiento = m.id_registros
                        LEFT JOIN catalogos catP ON catP.valor = m.id_tipopago AND catP.tipo_catalogo = 'TipoPago' 
                        WHERE m.id_registros = {idRegistro}";
            dsTemp = sqlServer.ExecSQLReturnDT(strSQL, "Cobros");
            ds.Tables.Add(dsTemp);

            return ds;
        }
    }
}
