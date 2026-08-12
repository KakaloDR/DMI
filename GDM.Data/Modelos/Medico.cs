namespace GDM.Data.Modelos
{
    /// <summary>
    /// Representa un médico o personal de asistencia asignado al dispensario.
    /// </summary>
    public class Medico
    {
        public int ID_Medico { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public string Tanda_Labor { get; set; } = "Matutina"; // Matutina, Vespertina, Nocturna
        public string Especialidad { get; set; } = string.Empty;
        public string Estado { get; set; } = "Activo"; // Activo, Inactivo
    }
}
