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

    public class Becas
    {
        [Key]
        public int id_beca { get; set; }
        public int id_matricula { get; set; }
        public int id_ciclo { get; set; }
        public decimal porcentaje_beca { get; set; }
        public decimal? monto_beca { get; set; }
        public DateTime? fecha_inicio { get; set; }
        public DateTime? fecha_fin { get; set; }
    }

    public class Promociones
    {
        [Key]
        public int id_promocion { get; set; }
        public int id_ciclo { get; set; }
        public decimal porcentaje_promocion { get; set; }
        public string descripcion { get; set; }
        public DateTime? fecha_inicio { get; set; }
        public DateTime? fecha_fin { get; set; }
    }

    public class Promociones_Alumnos
    {
        [Key]
        public int id { get; set; }
        public int id_promocion { get; set; }
        public int matricula { get; set; }
    }

    public class Alumnos
    {
        [Key]
        public int matricula { get; set; }
        public string nombre { get; set; }
        public string appaterno { get; set; }
        public string apmaterno { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public int pais_nacimiento { get; set; }
        public int estado_nacimiento { get; set; }
        public string sexo { get; set; }
        public string curp { get; set; }
        public string calle { get; set; }
        public string colonia { get; set; }
        public string ciudad { get; set; }
        public int estado { get; set; }
        public string telefono1 { get; set; }
        public string telefono2 { get; set; }
        public string telefono3 { get; set; }
        public string email { get; set; }
        public bool activo { get; set; }
        public DateTime fecha_alta { get; set; }
    }

    public class Tutores
    {
        [Key]
        public int id_tutor { get; set; }
        public string nombre { get; set; }
        public string appaterno { get; set; }
        public string apmaterno { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public int pais_nacimiento { get; set; }
        public int estado_nacimiento { get; set; }
        public char sexo { get; set; }
        public string rfc { get; set; }
        public string calle { get; set; }
        public string colonia { get; set; }
        public string ciudad { get; set; }
        public int estado { get; set; }
        public string telefono1 { get; set; }
        public string telefono2 { get; set; }
        public string telefono3 { get; set; }
        public string denomsocial { get; set; }
        public bool activo { get; set; }
        public bool factura { get; set; }
        public DateTime fecha_alta { get; set; }
    }

    public class Tutores_Alumnos
    {
        [Key]
        public int id { get; set; }
        public int id_tutor { get; set; }
        public int matricula { get; set; }
        public int parentesco { get; set; }
    }
    public class Productos
    {
        [Key]
        public int id_producto { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha_alta { get; set; }
        public string concepto { get; set; }
        public bool estado { get; set; }
    }
    public class Producto_Ciclo
    {
        [Key]
        public int id { get; set; }
        public int id_producto { get; set; }
        public int id_ciclo { get; set; }
        public decimal precio { get; set; }
        public DateTime fecha_vencimiento { get; set; }
        public int id_grupo { get; set; }
    }
    public class Ciclos_Escolares
    {
        [Key]
        public int id_ciclo { get; set; }
        public string ciclo { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
    }
    public class Acciones
    {
        [Key]
        public int id_accion { get; set; }
        public DateTime fecha { get; set; }
        public int id_usuario { get; set; }
        public string modulo { get; set; }
        public string tipo_accion { get; set; }
        public int entidad_id { get; set; }
        public string descripcion { get; set; }
    }

    public class Inscripciones
    {
        [Key]
        public int id { get; set; }
        public int matricula { get; set; }
        public int id_ciclo { get; set; }
        public int id_grado { get; set; }
        public int id_grupo { get; set; }
    }

    public class  Usuarios
    {
        [Key]
        public int id_usuario { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public int id_perfil { get; set; }
        public string correo { get; set; }
        public bool estatus { get; set; }
        public bool reset_contrasena { get; set; }
        public DateTime fecha_alta { get; set; }
        public string nombre_usuario { get; set; }
    }

    internal class clsModels
    {
       
    }
}
