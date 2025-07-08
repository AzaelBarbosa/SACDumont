using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Security.Cryptography;
using System.IO;
using SACDumont.modulos;

namespace SACDumont.Modulos
{
    public class basConfiguracion
    {
        // Variables para almacenar la información del usuario
        public static int UserID;
        public static int IdPerfil;
        public static string Nombre;

        // Variables para almacenar la configuración de la aplicación
        public static string RutaArchivos;
        public static bool EnvioNominas;
        public static bool SincronizarEmpleados;
        public static string HostCorreo;
        public static int Puerto;
        public static string CorreoEnvio;
        public static string ContrasenaCorreo;
        public static int Linea;
        public static int TipoActividad;
        public static int TipoPermiso;
        public static int IdCiclo;
        public static bool Recargos;
        public static bool Promociones;
        public static int PorcentajeRecargo;
        public static int DiasTolerancia;
        public static string InformacionHeader;
        public static string PrinterTiockets;
        public static string Printer;

        private static readonly string clave = "CoDumont12345678"; // 16 caracteres
        private static readonly string iv = "CoDuVector123456";      // 16 caracteres

        public void SetUserSession(int userID, int idPerfil, string nombre)
        {
            basConfiguracion.UserID = userID;
            basConfiguracion.IdPerfil = idPerfil;
            basConfiguracion.Nombre = nombre;
        }

        public void SetConfig(int idCiclo, bool bRecargos, bool bPromociones, int porcentajeRecargo, int diasTolerancia)
        {

            basConfiguracion.IdCiclo = idCiclo;
            basConfiguracion.Recargos = bRecargos;
            basConfiguracion.Promociones = bPromociones;
            basConfiguracion.PorcentajeRecargo = porcentajeRecargo;
            basConfiguracion.DiasTolerancia = diasTolerancia;
            basGlobals.iCiclo = idCiclo;
        }

        // Método opcional para limpiar la información del usuario
        public void ClearUserSession()
        {
            basConfiguracion.UserID = 0;
            basConfiguracion.IdPerfil = 0;
            basConfiguracion.Nombre = string.Empty;
        }

        public class ConfigInfo
        {
            public string Servidor { get; set; }
            public string BaseDatos { get; set; }
            public string Usuario { get; set; }
            public string Contrasena { get; set; }
        }

        public static void GuardarConfig(ConfigInfo config, string rutaArchivo)
        {
            string json = JsonSerializer.Serialize(config);
            byte[] encrypted = Encriptar(json);
            File.WriteAllBytes(rutaArchivo, encrypted);
        }

        public static ConfigInfo LeerConfig(string rutaArchivo)
        {
            byte[] encrypted = File.ReadAllBytes(rutaArchivo);
            string json = Desencriptar(encrypted);
            return JsonSerializer.Deserialize<ConfigInfo>(json);
        }

        private static byte[] Encriptar(string texto)
        {
            var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(clave);
            aes.IV = Encoding.UTF8.GetBytes(iv);

            var encryptor = aes.CreateEncryptor();
            byte[] input = Encoding.UTF8.GetBytes(texto);
            return encryptor.TransformFinalBlock(input, 0, input.Length);
        }

        private static string Desencriptar(byte[] datos)
        {
            var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(clave);
            aes.IV = Encoding.UTF8.GetBytes(iv);

            var decryptor = aes.CreateDecryptor();
            byte[] output = decryptor.TransformFinalBlock(datos, 0, datos.Length);
            return Encoding.UTF8.GetString(output);
        }

    }
}
