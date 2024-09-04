using System.ComponentModel;

namespace ProyectoEdi.Web.Views_Model.Color
{
    public class ColorListVm
    {
        public int ColorId { get; set; }
        [DisplayName("Color")]
        public string ColorName { get; set; } = null!;
    }
}
