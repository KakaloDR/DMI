namespace GDM.Data.Modelos
{
    /// <summary>
    /// Representa la ubicación física de un fármaco (estante, tramo, celda).
    /// </summary>
    public class Ubicacion
    {
        public int ID_Ubicacion { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string Estante { get; set; } = string.Empty;
        public string Tramo { get; set; } = string.Empty;
        public string Celda { get; set; } = string.Empty;
        public string Estado { get; set; } = "Activo";
    }
}
