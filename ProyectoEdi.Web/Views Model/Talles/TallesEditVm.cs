using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProyectoEdi.Web.Views_Model.Talles
{
    public class TallesEditVm
    {
        public int TalleId { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(200, ErrorMessage = "{0} must have between {2} and {1} characters", MinimumLength = 2)]
        [DisplayName("Numero Talles")]
        public double TallesNumero { get; set; } 
    }
}
