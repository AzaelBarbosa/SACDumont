using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACDumont.Dtos
{
    public class GeneralDTO
    {
    }

    public class CiclosEscolaresDTO
    {
        public int IdCiclo { get; set; }
        public string Ciclo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
