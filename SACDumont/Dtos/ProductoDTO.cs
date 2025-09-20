using System;

namespace SACDumont.Dtos
{
    public class ProductoDTO
    {
        public string Abrv { get; set; }
        public string Concepto { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public int Id_Producto { get; set; }
        public bool Estado { get; set; }
        public int Id_Grupo { get; set; }
        public string Grupo { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int Id { get; set; }
    }
}
