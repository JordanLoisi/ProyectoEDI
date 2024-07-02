using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoEdi3.Entidades
{
    public class Zapatilla
    {
        [Key]
        public int ZapatillaId { get; set; }
        public int MarcaId { get; set; }
        public int DeporteId { get; set; }
        public int GeneroId { get; set; }
        public int ColoresId { get; set; }
        public string Modelo { get; set; } = null!;
        [StringLength(150)]
        public string Description { get; set; } = null!;
        public decimal Precio { get; set; }
        public Marca Marca { get; set; }
        public Deporte Deporte { get; set; }
        public Genero Genero { get; set; }
        public Color Colores { get; set; }
        public ICollection<ZapatillasTalles> zapatillastalles { get; set; } = new List<ZapatillasTalles>();
    }
}
