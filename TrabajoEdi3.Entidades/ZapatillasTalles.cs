using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoEdi3.Entidades
{
    public class ZapatillasTalles
    {
        public int ZapatillaTallesId { get; set; }

        [ForeignKey("Zapatilla")]
        public int ZapatillaId { get; set; }
        public  Zapatilla Zapatilla { get; set; }

        [ForeignKey("Size")]
        public int TallesId { get; set; }
        public  Talles Talles { get; set; }

        public int Stok { get; set; }
        
    }
}
