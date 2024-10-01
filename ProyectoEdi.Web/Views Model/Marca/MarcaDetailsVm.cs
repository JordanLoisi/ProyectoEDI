using ProyectoEdi.Web.Views_Model.Zapatillas;
using System.ComponentModel;
using X.PagedList;

namespace ProyectoEdi.Web.Views_Model.Marca
{
    public class MarcaDetailsVm
    {
        public int MarcaId { get; set; }
        [DisplayName("Marca")]
        public string MarcaNombre { get; set; } = null!;

        public int CantidadZapatillas { get; set; }

        public IPagedList<ZapatillasListVm>? Zapatilla { get; set; }
    }
}
