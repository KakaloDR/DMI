namespace GDM.Data.Modelos
{
    /// <summary>
    /// Representa un usuario registrado en el sistema con credenciales de acceso.
    /// </summary>
    public class Usuario
    {
        public int ID_Usuario { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Clave { get; set; } = string.Empty; // Hash SHA-256
        public string Nombre { get; set; } = string.Empty;
        public string Estado { get; set; } = "Activo"; // Activo, Inactivo
    }
}
