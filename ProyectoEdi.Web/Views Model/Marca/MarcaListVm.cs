using System.ComponentModel;

namespace ProyectoEdi.Web.Views_Model.Marca
{
    public class MarcaListVm
    {
        public int MarcaId { get; set; }
        [DisplayName("Marca")]
        public string MarcaNombre { get; set; } = null!;
    }
}
