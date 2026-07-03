using System;
using GDM.Data;

namespace GDM.Business
{
    /// <summary>
    /// Administra la lógica de negocio relacionada con la conectividad e infraestructura del sistema GDM.
    /// </summary>
    public class ConexionService
    {
        /// <summary>
        /// Verifica si hay conectividad con el servidor de base de datos SQL Server.
        /// </summary>
        /// <returns>true si la base de datos responde exitosamente; de lo contrario, false.</returns>
        public bool VerificarConectividad()
        {
            // Invoca al verificador en la capa de datos (DAL)
            return ConexionVerificador.ProbarConexion();
        }
    }
}
