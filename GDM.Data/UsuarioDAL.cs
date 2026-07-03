using System;
using Microsoft.Data.SqlClient;
using GDM.Data.Modelos;

namespace GDM.Data
{
    /// <summary>
    /// Administra las operaciones de acceso a datos para la entidad Usuario (Seguridad).
    /// </summary>
    public class UsuarioDAL
    {
        /// <summary>
        /// Obtiene un usuario de la base de datos a partir de su nombre de usuario.
        /// </summary>
        /// <param name="username">El nombre de usuario a buscar.</param>
        /// <returns>La entidad Usuario si se encuentra; de lo contrario, null.</returns>
        public Usuario? ObtenerPorUsuario(string username)
        {
            if (string.IsNullOrEmpty(username)) return null;

            string query = "SELECT ID_Usuario, Usuario, Clave, Nombre, Estado FROM dbo.Usuarios WHERE Usuario = @Usuario";

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Usuario", username.Trim());
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Usuario
                            {
                                ID_Usuario = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Clave = reader.GetString(2),
                                Nombre = reader.GetString(3),
                                Estado = reader.GetString(4)
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
