using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProyectoEdi.Web.Views_Model.Marca
{
    public class MarcaEditVm
    {
        public int MarcaId { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(200, ErrorMessage = "{0} must have between {2} and {1} characters", MinimumLength = 3)]
        [DisplayName("Nombre Marca")]
        public string MarcaNombre { get; set; } = null!;



        [Display(Name = "Image")]
        public string? ImageUrl { get; set; }

        public IFormFile? ImageFile { get; set; }  // Propiedad para la imagen

        [Display(Name = "Remove Image")]
        public bool RemoveImage { get; set; }  // Propiedad para borrar imagen cargada
    }

}
