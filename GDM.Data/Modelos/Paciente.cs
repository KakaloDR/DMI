namespace GDM.Data.Modelos
{
    /// <summary>
    /// Representa un paciente (estudiante, empleado, profesor) registrado en el dispensario.
    /// </summary>
    public class Paciente
    {
        public int ID_Paciente { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public string No_Carnet { get; set; } = string.Empty;
        public string Tipo_Paciente { get; set; } = "Estudiante"; // Estudiante, Empleado, Profesor, Otros
        public string Estado { get; set; } = "Activo"; // Activo, Inactivo
    }
}
