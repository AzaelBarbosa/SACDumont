using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SACDumont.Models;

namespace SACDumont.modulos
{
    public class basGlobals
    {
        public static string sSQL;
        public static string sMatricula;
        public static int iCiclo;
        public static string sNombre;
        public static int iGrado;
        public static int tipoMovimiento;
        public static int estatusMovimiento;
        public static string sConcepto;
        public static DataSet dsMovimiento;
        public static DataSet dsMovimientoProductos;
        public static DataSet dsMovimientoPagos;
        public static List<movimiento_productos> listaProductos = new List<movimiento_productos>();
        public static Movimientos Movimiento = new Movimientos();
        public static List<cobros> listaCobros = new List<cobros>();
    }

    public enum Perfiles
    {
        Director = 1,
        Cajero = 2,
        Coordinador = 3,
        Administrador = 99,
        Academico = 4,
        Capturista = 5,
        Usuario = 6,
        Docente = 7,
        Almacen = 8
    }

    public enum TipoMovimiento
    {
        Colegiatura = 2,
        Inscripcion = 3,
        Producto = 1,
        Uniformes = 4,
        Eventos = 5,
        Graduacion = 6,
        Gasto = 7
    }

    public enum EstatusMovimiento
    {
        Abono = 1,
        Liquidado = 2,
        SinPago = 3,
        Cancelado = 4,
        Rechazado = 5,
        Pendiente = 6,
        Reembolso = 7,
    }

    public enum Conceptos
    {
        INSCRIPCION,
        COLEGIATURA,
        ARTICULO,
        UNIFORMES,
        EVENTOS,
        GRADUACION,
        GASTO
    }

    public enum Grados
    {
        Maternal = 0,
        PreEscolar = 1,
        Primaria = 2,
        Secundaria = 3
    }
}
