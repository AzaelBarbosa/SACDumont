using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SACDumont.Clases;
using SACDumont.Models;

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
                        m.montoTotal - (SELECT SUM(monto) FROM cobros WHERE id_movimiento = m.id_registros) AS MontoPendiente, m.montoTotal AS Total, catE.descripcion AS Estatus, p.descripcion AS Producto, m.porcentaje_descuento AS Descuento,
                        m.monto_descuento AS MontoDescuento, m.beca_descuento AS BecaDescuento
                        FROM movimientos m
                        INNER JOIN movimiento_productos mp ON m.id_registros = mp.id_movimiento
                        INNER JOIN productos p ON p.id_producto = mp.id_producto
                        INNER JOIN alumnos a ON a.matricula = m.id_matricula
                        INNER JOIN inscripciones i ON i.matricula = a.matricula
                        LEFT JOIN catalogos cat ON cat.valor = i.id_grado AND cat.tipo_catalogo = 'Grado' 
                        LEFT JOIN catalogos catG ON catG.valor = i.id_grupo AND catG.tipo_catalogo = 'Grupo'
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
            strSQL = $@"SELECT c.id_cobro, c.monto, cat.descripcion AS FormaPago
                        FROM movimientos m
                        INNER JOIN cobros c ON c.id_movimiento = m.id_registros 
						LEFT JOIN catalogos cat ON c.tipopago = cat.valor AND cat.tipo_catalogo = 'TipoPago' 
                        WHERE m.id_registros = {idRegistro}";
            dsTemp = sqlServer.ExecSQLReturnDT(strSQL, "Cobros");
            ds.Tables.Add(dsTemp);

            return ds;
        }


        public Movimientos GetMovimiento(int idRegistro)
        {
            Movimientos Movimiento = new Movimientos();
            string strSQL;
            DataTable dsTemp = new DataTable("Temp");

            //Movimiento
            strSQL = $@"SELECT a.matricula, m.id_registros ,m.fechahora AS Fecha, a.apmaterno + ' ' + a.apmaterno + ' ' + a.nombre AS Alumno, cat.descripcion AS Grado, catG.descripcion AS Grupo, p.descripcion AS Descripcion, 
                        m.montoTotal - (SELECT SUM(monto) FROM cobros WHERE id_movimiento = m.id_registros) AS MontoPendiente, m.montoTotal AS Total, catE.descripcion AS Estatus, p.descripcion AS Producto, m.porcentaje_descuento AS Descuento,
                        m.monto_descuento AS MontoDescuento, m.beca_descuento AS BecaDescuento, m.digitoscuenta, m.id_ciclo, m.id_usuario, m.id_tipomovimiento, m.id_estatusmovimiento
                        FROM movimientos m
                        INNER JOIN movimiento_productos mp ON m.id_registros = mp.id_movimiento
                        INNER JOIN productos p ON p.id_producto = mp.id_producto
                        INNER JOIN alumnos a ON a.matricula = m.id_matricula
                        INNER JOIN inscripciones i ON i.matricula = a.matricula
                        LEFT JOIN catalogos cat ON cat.valor = i.id_grado AND cat.tipo_catalogo = 'Grado' 
                        LEFT JOIN catalogos catG ON catG.valor = i.id_grupo AND catG.tipo_catalogo = 'Grupo'
                        LEFT JOIN catalogos catE ON catE.valor = m.id_estatusmovimiento AND catE.tipo_catalogo = 'EstatusMovimiento'
                        WHERE m.id_ciclo = {basGlobals.iCiclo} AND m.id_registros = {idRegistro}";
            dsTemp = sqlServer.ExecSQLReturnDT(strSQL, "Movimiento");

            foreach (DataRow row in dsTemp.Rows)
            {
                Movimiento = new Movimientos
                {
                    id_registros = Convert.ToInt32(row["id_registros"]),
                    id_tipomovimiento = Convert.ToInt32(row["id_tipomovimiento"]),
                    id_estatusmovimiento = Convert.ToInt32(row["id_estatusmovimiento"]),
                    fechahora = Convert.ToDateTime(row["Fecha"]),
                    id_usuario = Convert.ToInt32(row["id_usuario"]),
                    id_matricula = Convert.ToInt32(row["matricula"]),
                    id_ciclo = Convert.ToInt32(row["id_ciclo"]),
                    digitoscuenta = Convert.ToString(row["digitoscuenta"]),
                    montoTotal = Convert.ToDecimal(row["Total"]),
                    porcentaje_descuento = Convert.ToDecimal(row["Descuento"]),
                    monto_descuento = Convert.ToDecimal(row["MontoDescuento"]),
                    beca_descuento = Convert.ToDecimal(row["BecaDescuento"])
                };
            }

            return Movimiento;
        }

        public List<movimiento_productos> GetMovimientoProductos(int idRegistro)
        {
            List<movimiento_productos> listaProductos = new List<movimiento_productos>();
            string strSQL;
            DataTable dsTemp = new DataTable("Temp");

            //Productos
            strSQL = $@"SELECT m.id_registros, mp.id, p.concepto AS Concepto, p.descripcion AS Producto, mp.cantidad, mp.id_movimiento, mp.monto, mp.monto_recargo,
                        mp.id_producto        
                        FROM movimientos m
                        INNER JOIN movimiento_productos mp ON m.id_registros = mp.id_movimiento
                        INNER JOIN productos p ON p.id_producto = mp.id_producto
                        WHERE m.id_registros = {idRegistro}";
            dsTemp = sqlServer.ExecSQLReturnDT(strSQL, "Productos");

            foreach (DataRow row in dsTemp.Rows)
            {
                movimiento_productos p = new movimiento_productos
                {
                    id = (int)(row["id"]),
                    id_producto = (int)(row["id_producto"]),
                    id_movimiento = (int)(row["id_movimiento"]),
                    cantidad = (int)(row["cantidad"]),
                    monto = (decimal)(row["monto"]),
                    monto_recargo = (decimal)(row["monto_recargo"]),
                    descriptionProducto = row["Producto"].ToString()
                };

                listaProductos.Add(p);
            }


            return listaProductos;
        }

        public List<cobros> GetMovimientosPagos(int idRegistro)
        {
            List<cobros> listaCobros = new List<cobros>();
            string strSQL;
            DataTable dsTemp = new DataTable("Temp");

            //Cobros
            strSQL = $@"SELECT c.id_cobro, c.monto, cat.descripcion AS FormaPago, c.id_movimiento, c.tipopago
                        FROM movimientos m
                        INNER JOIN cobros c ON c.id_movimiento = m.id_registros
                        LEFT JOIN catalogos cat ON c.tipopago = cat.valor AND cat.tipo_catalogo = 'TipoPago'
                        WHERE m.id_registros = {idRegistro}";
            dsTemp = sqlServer.ExecSQLReturnDT(strSQL, "Cobros");

            foreach (DataRow row in dsTemp.Rows)
            {
                cobros p = new cobros
                {
                    id_cobro = (int)(row["id_cobro"]),
                    id_movimiento = (int)row["id_movimiento"],
                    monto = (decimal)row["monto"],
                    tipopago = (int)row["tipopago"],
                    descripcionPago = row["FormaPago"].ToString()
                };

                listaCobros.Add(p);
            }

            return listaCobros;
        }
    }
}
