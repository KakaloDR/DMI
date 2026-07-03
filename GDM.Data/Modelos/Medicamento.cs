namespace GDM.Data.Modelos
{
    /// <summary>
    /// Representa un medicamento registrado en el inventario, con referencias a sus catálogos maestros.
    /// </summary>
    public class Medicamento
    {
        public int ID_Medicamento { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public int FK_Tipo_Farmaco { get; set; }
        public int FK_Marca { get; set; }
        public int FK_Ubicacion { get; set; }
        public string Dosis { get; set; } = string.Empty;
        public string Estado { get; set; } = "Activo"; // Activo, Inactivo

        // Propiedades de Solo Lectura para visualización en Grillas (Joins)
        public string TipoFarmacoDescripcion { get; set; } = string.Empty;
        public string MarcaDescripcion { get; set; } = string.Empty;
        public string UbicacionDescripcion { get; set; } = string.Empty;
    }
}
