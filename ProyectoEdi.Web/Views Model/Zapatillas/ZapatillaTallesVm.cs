using TrabajoEdi3.Entidades;

namespace ProyectoEdi.Web.Views_Model.Zapatillas
{
    public class ZapatillaTallesVm
    {
        public int ZapatillaId { get; set; }
        public string Description { get; set; } = null!;
        public string? Modelo { get; set; }
        public decimal Precio { get; set; }
        public string Marca { get; set; } = null!;
        public string Deporte { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string Genero { get; set; } = null!;

        public List <ZapatillasTalles> tallesyStock {get; set;}
        
    }
}
