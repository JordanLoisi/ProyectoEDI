using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProyectoEdi.Web.Views_Model.Talles
{
    public class TallesEditVm
    {
        public int TallesId { get; set; }
        [Required(ErrorMessage = "{0} is required")]
       
        [DisplayName("Numero Talles")]
        public decimal TallesNumbero { get; set; } 
    }
}
