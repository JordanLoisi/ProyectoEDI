using System.ComponentModel;

namespace ProyectoEdi.Web.Views_Model.Deporte
{
    public class DeporteListVm
    {
        public int DeporteId { get; set; }
        [DisplayName("Deporte")]
        public string NombreDeporte { get; set; } = null!;
    }
}
