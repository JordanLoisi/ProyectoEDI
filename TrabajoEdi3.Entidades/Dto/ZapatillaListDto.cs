using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoEdi3.Entidades.Dto
{
    public class ZapatillaListDto
    {
        public int ZapatillaId { get; set; }
        public string Marca { get; set; }
        public string Deporte{ get; set; }
        public string Genero { get; set; }
        public string Colores { get; set; }
        public string Modelo { get; set; } = null!;
        [StringLength(150)]
        public string Description { get; set; } = null!;
        public decimal Precio { get; set; }

        public int CantidadTalles {  get; set; }
        

    }
}
