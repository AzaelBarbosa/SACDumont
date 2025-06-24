using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACDumont.Models
{
    public class movimiento_productos
    {
        [Key]
        public int id { get; set; }
        public int id_producto { get; set; }
        public int id_movimiento { get; set; }
        public int cantidad { get; set; }
        public decimal monto { get; set; }
        public decimal monto_recargo { get; set; }

        [NotMapped]
        public string descriptionProducto { get; set; }
    }

    public class cobros
    {
        [Key]
        public int id_cobro { get; set; }
        public int id_movimiento { get; set; }
        public decimal monto { get; set; }
        public int tipopago { get; set; }

        [NotMapped]
        public string descripcionPago { get; set; }
    }

    public class Movimientos
    {
        [Key]
        public int id_registros { get; set; }
        public int id_tipomovimiento { get; set; }
        public int id_estatusmovimiento { get; set; }
        public DateTime fechahora { get; set; }
        public int id_usuario { get; set; }
        public int id_matricula { get; set; }
        public int id_ciclo { get; set; }
        public string digitoscuenta { get; set; }
        public decimal montoTotal { get; set; }
        public decimal porcentaje_descuento { get; set; }
        public decimal monto_descuento { get; set; }
        public decimal beca_descuento { get; set; }
    }

    internal class clsModels
    {
       
    }
}
