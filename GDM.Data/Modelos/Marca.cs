namespace GDM.Data.Modelos
{
    /// <summary>
    /// Representa una marca o laboratorio fabricante de medicamentos (Ej: Pfizer, Bayer).
    /// </summary>
    public class Marca
    {
        public int ID_Marca { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string Estado { get; set; } = "Activo";
    }
}
