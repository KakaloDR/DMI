namespace GDM.Data.Modelos
{
    /// <summary>
    /// Representa una entidad de Tipo de Fármaco (Ej: Tableta, Cápsula, Jarabe).
    /// </summary>
    public class TipoFarmaco
    {
        public int ID_Tipo_Farmaco { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string Estado { get; set; } = "Activo";
    }
}
