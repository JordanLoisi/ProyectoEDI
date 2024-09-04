using AutoMapper;
using ProyectoEdi.Web.Views_Model.Color;
using ProyectoEdi.Web.Views_Model.Deporte;
using ProyectoEdi.Web.Views_Model.Generos;
using ProyectoEdi.Web.Views_Model.Marca;
using ProyectoEdi.Web.Views_Model.Talles;
using TrabajoEdi3.Entidades;
namespace ProyectoEdi.Web.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            LoadMarcaMapping();
            LoadDeporteMapping();
            LoadColorMapping();
            LoadGeneroMapping();
            LoadTalleMapping();
        }

        private void LoadTalleMapping()
        {
            CreateMap<Talles, TallesListVm>();
            CreateMap<Talles, TallesEditVm>().ReverseMap(); 
        }

        private void LoadGeneroMapping()
        {
            CreateMap<Genero, GenerosListVm>();
            CreateMap<Genero, GenerosEditVm>().ReverseMap();
        }

        private void LoadColorMapping()
        {
            CreateMap<Color, ColorListVm>();
            CreateMap<Color, ColorEditVm>().ReverseMap();
        }

        private void LoadDeporteMapping()
        {
            CreateMap<Deporte, DeporteListVm>();
            CreateMap<Deporte,DeporteEditVm>().ReverseMap();
        }

        private void LoadMarcaMapping()
        {
            CreateMap<Marca, MarcaListVm>();
            CreateMap<Marca, MarcaEditVm>().ReverseMap();
        }


    }
}
