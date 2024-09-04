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
        [DisplayName("Descripcion")]
        public string Descripcion { get; set; } = null!;

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(200, ErrorMessage = "{0} must have between {2} and {1} characters", MinimumLength = 3)]
        public string Modelo { get; set; } = null!;

        //[MaxLength(20, ErrorMessage = "{0} must have at least {1} characters")]

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(10, ErrorMessage = "{0} must have between {2} and {1} characters", MinimumLength = 3)]
        [DisplayName("Zip Code")]
        public decimal Precio { get; set; } 

        [Required(ErrorMessage = "Marca is required")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a country")]
        [DisplayName("Country")]
        public int MarcaId { get; set; }

        [Required(ErrorMessage = "Deporte is required")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a state")]
        [DisplayName("State")]
        public int DeporteId { get; set; }

        [Required(ErrorMessage = "Color is required")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a city")]
        [DisplayName("City")]
        public int ColorId { get; set; }

        [Required(ErrorMessage = "Genero is required")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a city")]
        [DisplayName("City")]
        public int GeneroId { get; set; }


        [ValidateNever]
        public IEnumerable<SelectListItem> Countries { get; set; } = null!;

        [ValidateNever]
        public IEnumerable<SelectListItem> States { get; set; } = null!;

        [ValidateNever]
        public IEnumerable<SelectListItem> Cities { get; set; } = null!;
    }
}
