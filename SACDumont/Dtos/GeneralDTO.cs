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
        public DateTime FechaNacimiento { get; set; }
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
        public DateTime FechaNacimiento { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public string Sexo { get; set; }
        public string Grupo { get; set; }
        public string Grado { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }

        public bool Activo { get; set; }
    }
}