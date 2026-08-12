using System;
using Microsoft.Data.SqlClient;

namespace GDM.Data
{
    /// <summary>
    /// Proporciona métodos para verificar el estado de la conexión con el servidor de base de datos.
    /// </summary>
    public static class ConexionVerificador
    {
        /// <summary>
        /// Intenta abrir una conexión con la base de datos para verificar que el servidor esté activo y accesible.
        /// </summary>
        /// <returns>true si la conexión fue exitosa; de lo contrario, false.</returns>
        public static bool ProbarConexion()
        {
            try
            {
                using (SqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
