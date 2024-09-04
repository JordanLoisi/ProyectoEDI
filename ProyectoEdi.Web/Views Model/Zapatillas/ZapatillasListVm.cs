namespace ProyectoEdi.Web.Views_Model.Zapatillas
{
    public class ZapatillasListVm
    {
        public int ZapatillaId { get; set; }
        public string Descripcion { get; set; } = null!;
        public string? Modelo { get; set; }
        public decimal Precio { get; set; }
        public string Marca { get; set; } = null!;
        public string Deporte { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string Genero{ get; set; } = null!;

    }
}
