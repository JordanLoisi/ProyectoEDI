using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
