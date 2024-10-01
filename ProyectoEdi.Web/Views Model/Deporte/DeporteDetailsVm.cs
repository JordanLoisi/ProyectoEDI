using ProyectoEdi.Web.Views_Model.Zapatillas;
using System.ComponentModel;
using X.PagedList;

namespace ProyectoEdi.Web.Views_Model.Deporte
{
    public class DeporteDetailsVm
    {
        public int DeporteId { get; set; }
        [DisplayName("Deporte")]
        public string NombreDeporte { get; set; } = null!;

        public int CantidadZapatillas { get; set; }

        public IPagedList<ZapatillasListVm>? Zapatilla { get; set; }
    }
}
