using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoEdi3.Entidades
{
    public class Deporte
    {
        [Key]
        public int DeporteId { get; set; }
        [StringLength(20)]
        public string NombreDeporte { get; set; } = null!;


        public ICollection<Zapatilla> zapatillas { get; set; }
    }
}
