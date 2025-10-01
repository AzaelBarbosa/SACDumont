using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string talla { get; set; }
        public string descripcion { get; set; }
        public decimal monto_beca { get; set; }
        public decimal monto_promocion { get; set; }

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
        public DateTime? fechaAlta { get; set; }
        public string pago_por { get; set; }
        public int no_cobro { get; set; }

        [NotMapped]
        public string descripcionPago { get; set; }
    }

    public class Movimientos
    {
        [Key]
        public int id_movimiento { get; set; }
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
        public bool confirmado { get; set; }
        public virtual ICollection<movimiento_productos> MovimientosProductos { get; set; }
        public virtual ICollection<cobros> MovimientosCobros { get; set; }

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
        public bool activo { get; set; }
        public string concepto { get; set; }
    }

    public class Promociones_Alumnos
    {
        [Key]
        public int id { get; set; }
        public int id_promocion { get; set; }
        public int matricula { get; set; }
        public int id_ciclo { get; set; }
    }

    public class Alumnos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int matricula { get; set; }
        public string nombre { get; set; }
        public string appaterno { get; set; }
        public string apmaterno { get; set; }
        public DateTime? fecha_nacimiento { get; set; }
        public int? pais_nacimiento { get; set; }
        public int? estado_nacimiento { get; set; }
        public string sexo { get; set; }
        public string curp { get; set; }
        public string calle { get; set; }
        public string colonia { get; set; }
        public string ciudad { get; set; }
        public int? estado { get; set; }
        public string telefono1 { get; set; }
        public string telefono2 { get; set; }
        public string telefono3 { get; set; }
        public string email { get; set; }
        public bool activo { get; set; }
        public DateTime? fecha_alta { get; set; }
        public byte[] foto_alumno { get; set; }
        public virtual ICollection<Inscripciones> Inscripciones { get; set; }

    }

    public class Tutores
    {
        [Key]
        public int id_tutor { get; set; }
        public string nombre { get; set; }
        public string appaterno { get; set; }
        public string apmaterno { get; set; }
        public DateTime? fecha_nacimiento { get; set; }
        public string sexo { get; set; }
        public string rfc { get; set; }
        public string calle { get; set; }
        public string colonia { get; set; }
        public string ciudad { get; set; }
        public int? estado { get; set; }
        public string telefono1 { get; set; }
        public string telefono2 { get; set; }
        public string telefono3 { get; set; }
        public string denomsocial { get; set; }
        public bool? acivo { get; set; }
        public bool? factura { get; set; }
        public DateTime? fecha_alta { get; set; }
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
        public string abreviatura { get; set; }
        public int? id_producto_obligatorio { get; set; }
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

        public virtual Productos Producto { get; set; }
        public virtual Ciclos_Escolares CicloEscolar { get; set; }
    }
    public class Ciclos_Escolares
    {
        [Key]
        public int id_ciclo { get; set; }
        public string ciclo { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }

        public virtual ICollection<Producto_Ciclo> ProductoCiclos { get; set; }
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
        public string tipo_inscripcion { get; set; }
        public bool beca { get; set; }
        public bool promocion { get; set; }

        [ForeignKey("matricula")]
        public virtual Alumnos Alumnos { get; set; }
    }

    public class Usuarios
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

    public class catalogos
    {
        [Key]
        public int id_catalogo { get; set; }
        public string tipo_catalogo { get; set; }
        public string descripcion { get; set; }
        public int valor { get; set; }
    }

    public class perfiles
    {
        [Key]
        public int id_perfil { get; set; }
        public string descripcion { get; set; }
        public bool estatus { get; set; }
    }

    public class permisos_perfiles
    {
        [Key]
        public int id_permiso { get; set; }
        public int id_perfil { get; set; }
        public bool inscripcion { get; set; }
        public bool cobros { get; set; }
        public bool catalogos { get; set; }
        public bool reportes { get; set; }
        public bool configuracion { get; set; }
        public bool gastos { get; set; }
        public bool cat_productos { get; set; }
        public bool cat_alumnos { get; set; }
        public bool cat_tutores { get; set; }
        public bool cat_usuarios { get; set; }
        public bool cat_promociones { get; set; }
        public bool con_general { get; set; }
        public bool con_ciclos { get; set; }
        public bool con_transferir { get; set; }
        public bool cortediario { get; set; }
        public bool eliminar { get; set; }
    }

    public class cierre_diario
    {
        [Key]
        public int id { get; set; }
        public DateTime fechacorte { get; set; }
        public DateTime fechaAlta { get; set; }
        public decimal total { get; set; }
        public int idUsuario { get; set; }
        public int B1000 { get; set; }
        public int B500 { get; set; }
        public int B200 { get; set; }
        public int B100 { get; set; }
        public int B50 { get; set; }
        public int B20 { get; set; }
        public int M10 { get; set; }
        public int M5 { get; set; }
        public int M2 { get; set; }
        public int M1 { get; set; }
        public int M050 { get; set; }

    }
    public class config
    {
        [Key]
        public int id { get; set; }
        public int porcentaje_recargo { get; set; }
        public int dias_tolerancia { get; set; }
        public bool aplicar_recargos { get; set; }
        public bool aplicar_promociones { get; set; }
        public string primaria_sep { get; set; }
        public string primaria_clave { get; set; }
        public string secundaria_sep { get; set; }
        public string secundaria_clave { get; set; }
        public string preescolar_sep { get; set; }
        public string preescolar_clave { get; set; }
        public string maternal_sep { get; set; }
        public string maternal_clave { get; set; }
    }

    public class config_equipos
    {
        [Key]
        public int id { get; set; }
        public string equipo { get; set; }
        public string impresora_tickets { get; set; }
        public string impresora_general { get; set; }
    }

    public class saldo_favor
    {
        [Key]
        public int IdSaldo { get; set; }
        public int Matricula { get; set; }
        public int IdCiclo { get; set; }
        public decimal Saldo { get; set; }
        public DateTime LastUpdateUtc { get; set; }
    }

    public class saldo_mov
    {
        [Key]
        public int Id { get; set; }
        public int IdSaldo { get; set; }
        public DateTime FechaUtc { get; set; }
        public decimal Monto { get; set; }
        public string Origen { get; set; }
        public int IdMov { get; set; }
        public string Nota { get; set; }
    }
    internal class clsModels
    {

    }
}
