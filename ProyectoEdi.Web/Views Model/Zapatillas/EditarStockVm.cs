using System.ComponentModel.DataAnnotations;

namespace ProyectoEdi.Web.Views_Model.Zapatillas
{
    public class EditarStockVm
    {
        public int ZapatillaId { get; set; }
        public int TallesId { get; set; }

        [Required(ErrorMessage = "El campo Stock es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")]
        public int Stok { get; set; }
    }
}
