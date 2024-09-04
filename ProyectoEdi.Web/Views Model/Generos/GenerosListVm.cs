using System.ComponentModel;

namespace ProyectoEdi.Web.Views_Model.Generos
{
    public class GenerosListVm
    {
        public int GeneroId { get; set; }
        [DisplayName("Deporte")]
        public string GeneroNombre { get; set; } = null!;
    }
}
