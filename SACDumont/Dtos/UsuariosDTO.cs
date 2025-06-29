using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACDumont.Dtos
{
    public class UsuariosDTO
    {
        public string NombreUsuario { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public int Id_Perfil { get; set; }
        public int Id_Usuario { get; set; }
        public string Correo { get; set; }
        public bool Estatus { get; set; }
        public bool ResetContrasena { get; set; }
    }

    public class PerfilesDTO
    {
        public int Id_Perfil { get; set; }
        public string Descripcion { get; set; }
        public bool Estatus { get; set; }
    }


}
