using System;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace GDM.Data
{
    /// <summary>
    /// Proporciona la conexión centralizada y segura a la base de datos SQL Server del Dispensario Médico.
    /// </summary>
    public static class ConexionBD
    {
        private static readonly string ConnectionString;

        static ConexionBD()
        {
            // Lee la cadena de conexión desde el archivo de configuración global (App.config)
            var connectionSetting = ConfigurationManager.ConnectionStrings["GDM_Connection"];
            if (connectionSetting == null || string.IsNullOrEmpty(connectionSetting.ConnectionString))
            {
                throw new InvalidOperationException("La cadena de conexión 'GDM_Connection' no está configurada en el archivo App.config.");
            }
            ConnectionString = connectionSetting.ConnectionString;
        }

        /// <summary>
        /// Crea y devuelve una nueva instancia de SqlConnection configurada y lista para usarse.
        /// El invocador es responsable de abrir y liberar la conexión (preferiblemente usando bloques using).
        /// </summary>
        /// <returns>Una instancia de SqlConnection.</returns>
        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
