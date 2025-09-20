using System;
using System.ComponentModel.DataAnnotations;

namespace SACDumont.Models
{
    internal class clsSACModels
    {
    }

    public class ALUMNOS
    {
        [Key]
        public int matri { get; set; }
        public string nombre { get; set; }
        public string appat { get; set; }
        public string apmat { get; set; }
        public int? dia { get; set; }
        public string mes { get; set; }
        public int? año { get; set; }
        public string lugnac { get; set; }
        public string sexo { get; set; }
        public string curp { get; set; }
        public string dompart { get; set; }
        public string telcel { get; set; }
        public string telcasa { get; set; }
        public string email { get; set; }
        public string tipo { get; set; }
        public bool? activo { get; set; }
        public bool? beca { get; set; }
        public float? porcent { get; set; }
        public bool? becasep { get; set; }
        public float? porcentsep { get; set; }
        public bool? becainscr { get; set; }
        public float? porcentinscr { get; set; }
        public DateTime? fechainsc { get; set; }
        public bool? reprobado { get; set; }

    }

}
