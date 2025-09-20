using System;

namespace SACDumont.Dtos
{
    public class MovimientosDTO
    {
        public int id_movimiento { get; set; }
        public DateTime Fecha { get; set; }
        public string Producto { get; set; }
        public string Alumno { get; set; }
        public string Grado { get; set; }
        public string Grupo { get; set; }
        public decimal Total { get; set; }
        public decimal MontoPendiente { get; set; }
        public decimal Descuento { get; set; }
        public decimal MontoDescuento { get; set; }
        public decimal BecaDescuento { get; set; }
        public string Estatus { get; set; }
        public bool confirmado { get; set; }
    }
}
