using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace ProyectoEdi.Web.Views_Model.Zapatillas
{
    public class ZapatillaFilterVm
    {
        public IPagedList<ZapatillasListVm>? Zapatilla { get; set; }
        public List<SelectListItem>? Marca { get; set; }

        public List<SelectListItem>? Color { get; set; }

        //public IEnumerable<SelectListItem>? Genero { get; set; }
        //public IEnumerable<SelectListItem>? Color { get; set; }

    }
}
