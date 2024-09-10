
namespace TrabajoEdi3.Entidades
{
    public class Talles
    {
        public int TallesId { get; set; }
        public decimal TallesNumbero { get; set; }

        public ICollection<ZapatillasTalles> zapatillastalles { get; set; } = new List<ZapatillasTalles>();
    }
}
