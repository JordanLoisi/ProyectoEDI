namespace ProyectoEdi.Web.Views_Model.Zapatillas
{
    public class AgregarTalleVm
    {
        public int ZapatillaId { get; set; }
        public List<TrabajoEdi3.Entidades.Talles> Talles { get; set; }

        public int TallesId { get; set; }

        public int Stok { get; set; }

    }
}
