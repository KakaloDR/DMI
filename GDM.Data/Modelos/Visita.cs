using System;

namespace GDM.Data.Modelos
{
    /// <summary>
    /// Representa un registro de visita transaccional del dispensario médico.
    /// </summary>
    public class Visita
    {
        public int ID_Visita { get; set; }
        public int FK_Medico { get; set; }
        public int FK_Paciente { get; set; }
        public DateTime Fecha_Visita { get; set; } = DateTime.Today;
        public TimeSpan Hora_Visita { get; set; } = DateTime.Now.TimeOfDay;
        public string Sintomas { get; set; } = string.Empty;
        public int FK_Medicamento { get; set; }
        public string Recomendaciones { get; set; } = string.Empty;
        public string Estado { get; set; } = "Activo"; // Activo, Inactivo

        // Propiedades de navegación de sólo lectura para mostrar descripciones en UI/Grillas
        public string MedicoNombre { get; set; } = string.Empty;
        public string PacienteNombre { get; set; } = string.Empty;
        public string MedicamentoDescripcion { get; set; } = string.Empty;
    }
}
