using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProyectoEdi.Web.Views_Model.Marca
{
    public class DeporteEditVm
    {
        public int DeporteId { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(200, ErrorMessage = "{0} must have between {2} and {1} characters", MinimumLength = 3)]
        [DisplayName("Nombre Deporte")]
        public string NombreDeporte { get; set; } = null!;
    }
}
