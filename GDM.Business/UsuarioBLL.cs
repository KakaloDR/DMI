using System;
using System.Security.Cryptography;
using System.Text;
using GDM.Data;
using GDM.Data.Modelos;

namespace GDM.Business
{
    /// <summary>
    /// Gestiona la seguridad y autenticación de usuarios.
    /// Contiene la VALIDACIÓN DE SEGURIDAD del sistema DMI.
    /// </summary>
    public class UsuarioBLL
    {
        private readonly UsuarioDAL _dal = new UsuarioDAL();

        /// <summary>
        /// Valida las credenciales de acceso de un usuario.
        /// Aplica la encriptación SHA-256 y verifica que la cuenta esté activa.
        /// </summary>
        /// <param name="usuario">Nombre de usuario.</param>
        /// <param name="claveRaw">Contraseña en texto plano.</param>
        /// <returns>true si el acceso es concedido; de lo contrario, lanza una excepción.</returns>
        public bool ValidarAcceso(string usuario, string claveRaw)
        {
            if (string.IsNullOrWhiteSpace(usuario))
            {
                throw new ArgumentException("El nombre de usuario es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(claveRaw))
            {
                throw new ArgumentException("La contraseña es obligatoria.");
            }

            // 1. Obtener usuario de la base de datos
            Usuario? user = _dal.ObtenerPorUsuario(usuario.Trim());
            if (user == null)
            {
                throw new InvalidOperationException("El usuario ingresado no existe.");
            }

            // 2. Comprobar si el usuario está inactivo
            if (user.Estado != "Activo")
            {
                throw new InvalidOperationException("El acceso ha sido denegado porque el usuario se encuentra Inactivo.");
            }

            // 3. Cifrar la contraseña ingresada y comparar hashes
            string claveCifrada = CalcularSHA256(claveRaw);
            if (!user.Clave.Trim().Equals(claveCifrada.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("La contraseña ingresada es incorrecta.");
            }

            return true;
        }

        /// <summary>
        /// Genera el hash SHA-256 hexadecimal de una cadena de texto.
        /// </summary>
        /// <param name="texto">Texto plano a cifrar.</param>
        /// <returns>Hash de 64 caracteres en minúsculas.</returns>
        public string CalcularSHA256(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(texto));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
