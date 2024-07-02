using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoEdi3.Entidades
{
    public class Talles
    {
        public int TallesId { get; set; }
        public decimal TallesNumbero { get; set; }

        public ICollection<ZapatillasTalles> zapatillastalles { get; set; } = new List<ZapatillasTalles>();
    }
}
