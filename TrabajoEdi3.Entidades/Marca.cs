using System.ComponentModel.DataAnnotations;

namespace TrabajoEdi3.Entidades
{
    public class Marca
    {
        [Key]
        public int MarcaId { get; set; }
        [StringLength(50)]
        public string MarcaNombre { get; set; } = null!;


        public ICollection<Zapatilla> zapatillas { get; set; }
    }
}
