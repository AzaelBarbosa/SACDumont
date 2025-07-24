using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACDumont.Dtos
{
    public class ReportesDTO
    {
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Total { get; set; }
        public decimal Recargo { get; set; }
        public int Folio { get; set; }
        public DateTime Fecha { get; set; }
        public string Grupo { get; set; }
        public int Matricula { get; set; }
        public string Alumno { get; set; }
        public string Ciclo { get; set; }
        public decimal MontoPendiente { get; set; }
        public decimal MontoPagado { get; set; }
    }

    public class AlumnosDTO
    {
        public string Alumno { get; set; }
        public string Grado { get; set; }
        public string Grupo { get; set; }
        public string Ciclo { get; set; }
    }

    public class CorteDiarioDTO
    {
        public decimal MontoEfectivo { get; set; }
        public decimal MontoTransferencia { get; set; }
        public decimal MontoTarjeta { get; set; }
        public DateTime Fecha { get; set; }

    }

}
