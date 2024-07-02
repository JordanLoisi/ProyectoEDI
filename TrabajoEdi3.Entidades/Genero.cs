using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoEdi3.Entidades
{
    public class Genero
    {
        [Key]
        public int GeneroId { get; set; }

        [StringLength(10)]
        public string GeneroNombre { get; set; } = null!;


        public ICollection<Zapatilla> zapatillas { get; set; }
    }
}
