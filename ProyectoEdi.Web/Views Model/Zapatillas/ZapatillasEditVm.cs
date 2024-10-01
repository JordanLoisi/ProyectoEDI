using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProyectoEdi.Web.Views_Model.Zapatillas
{
    public class ZapatillasEditVm
    {
        public int ZapatillaId { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(200, ErrorMessage = "{0} must have between {2} and {1} characters", MinimumLength = 3)]
        
        [DisplayName("Description")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(200, ErrorMessage = "{0} must have between {2} and {1} characters", MinimumLength = 3)]

        [DisplayName("Modelo")]
        public string Modelo { get; set; } = null!;


        [Required(ErrorMessage = "{0} is required")]
       
        [DisplayName("Precio")]
        public decimal Precio { get; set; } 

        [Required(ErrorMessage = "Marca is required")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a country")]
        [DisplayName("Marca")]
        public int MarcaId { get; set; }

        [Required(ErrorMessage = "Deporte is required")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a state")]
        [DisplayName("Deporte")]
        public int DeporteId { get; set; }

        [Required(ErrorMessage = "Color is required")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a city")]
        [DisplayName("Colores")]
        public int ColoresId { get; set; }

        [Required(ErrorMessage = "Genero is required")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a city")]
        [DisplayName("Genero")]
        public int GeneroId { get; set; }


        [ValidateNever]
        public IEnumerable<SelectListItem> Color { get; set; } = null!;

        [ValidateNever]
        public IEnumerable<SelectListItem> Marca{ get; set; } = null!;

        [ValidateNever]
        public IEnumerable<SelectListItem> Deporte { get; set; } = null!;

        [ValidateNever]
        public IEnumerable<SelectListItem> Genero { get; set; } = null!;
    }
}
