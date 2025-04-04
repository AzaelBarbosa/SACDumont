using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Security.Cryptography;
using System.IO;

namespace CDURechazos.Modulos
{
    public class basConfiguracion
    {
        // Variables para almacenar la información del usuario
        public static int UserID;
        public static string NumEmpleado;
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
        public static int ModoConexion = 0;

        private static readonly string clave = "CopeLand12345678"; // 16 caracteres
        private static readonly string iv = "CoLaVector123456";      // 16 caracteres

        public void SetUserSession(int userID, string numEmpleado, string nombre)
        {
            basConfiguracion.UserID = userID;
            basConfiguracion.NumEmpleado = numEmpleado;
            basConfiguracion.Nombre = nombre;
        }

        public void SetConfig(string rutaArchivos, bool envioNominas, bool sincroEmpleados, string hostCorreo, int puerto, string correo, string contrasena)
        {
            basConfiguracion.RutaArchivos = rutaArchivos;
            basConfiguracion.EnvioNominas = envioNominas;
            basConfiguracion.SincronizarEmpleados = sincroEmpleados;
            basConfiguracion.HostCorreo = hostCorreo;
            basConfiguracion.Puerto = puerto;
            basConfiguracion.CorreoEnvio = correo;
            basConfiguracion.ContrasenaCorreo = contrasena;
        }

        // Método opcional para limpiar la información del usuario
        public void ClearUserSession()
        {
            basConfiguracion.UserID = 0;
            basConfiguracion.NumEmpleado = string.Empty;
            basConfiguracion.Nombre = string.Empty;
        }

        public class ConfigInfo
        {
            public string Servidor { get; set; }
            public string BaseDatos { get; set; }
            public string Usuario { get; set; }
            public string Contrasena { get; set; }
            public string pgUrl { get; set; }
            public int ModoConexion { get; set; }
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
