using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        Otros = 4
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
        PRODUCTOS,
        OTROS
    }

    public enum Grados
    {
        PreEscolar = 1,
        Primaria = 2,
        Secundaria = 3
    }
}
