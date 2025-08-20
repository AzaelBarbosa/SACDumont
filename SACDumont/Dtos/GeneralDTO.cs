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
    public class TutoresDTO
    {
        public int IdTutor { get; set; }
        public string NombreCompleto { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Sexo { get; set; }
    }

    public class TutorAlumnoDTO
    {
        public int IdTutor { get; set; }
        public int IdAlumno { get; set; }
        public string NombreTutor { get; set; }
        public string Parentesco { get; set; }
    }

    public class AlumnoDTO
    {
        public int Matricula { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public string Sexo { get; set; }
        public string Grupo { get; set; }
        public string Grado { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }

        public bool Activo { get; set; }
    }

    public class AlumnoSACDTO
    {
        public bool Seleccionado { get; set; }
        public int Matriula { get; set; }
        public string nombreCompleto { get; set; }
        public string nombre { get; set; }
        public string appaterno { get; set; }
        public string apmaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string curp { get; set; }
        public string calle { get; set; }
        public string colonia { get; set; }
        public string ciudad { get; set; }
        public string telefono1 { get; set; }
        public string telefono2 { get; set; }
        public string email { get; set; }
        public DateTime fechaalta { get; set; }
        public bool activo { get; set; }
    }

    public class PromoAlumnosDTO
    {
        public int id_promocion { get; set; }
        public string concepto { get; set; }
        public string descripcion { get; set; }
        public string ciclo { get; set; }
        public int id { get; set; }

    }

    public class ConfigDTO
    {
        public string PrimariaSEP { get; set; }
        public string PrimariaClave { get; set; }
        public string SecundariaSEP { get; set; }
        public string SecundariaClave { get; set; }
        public string PreEscolarSEP { get; set; }
        public string PreEscolarClave { get; set; }
        public string MaternalSEP { get; set; }
        public string MaternalClave { get; set; }
        public string Equipo { get; set; }

    }
    public class CierreDTO
    {
        public decimal Monto { get; set; }
        public string Tipo { get; set; }

    }
    public class PagosAlumnoDTO
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