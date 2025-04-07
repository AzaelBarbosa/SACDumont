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

}
