using AutoMapper;
using ProyectoEdi.Web.Views_Model.Color;
using ProyectoEdi.Web.Views_Model.Deporte;
using ProyectoEdi.Web.Views_Model.Generos;
using ProyectoEdi.Web.Views_Model.Marca;
using ProyectoEdi.Web.Views_Model.Talles;
using ProyectoEdi.Web.Views_Model.Zapatillas;
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
            LoadZapatillaMapping();
        }
        private void LoadZapatillaMapping()
        {
            CreateMap<Zapatilla, ZapatillasListVm>()
             .ForMember(dest => dest.Marca, opt => opt.MapFrom(src => src.Marca.MarcaNombre))
             .ForMember(dest => dest.Deporte, opt => opt.MapFrom(src => src.Deporte.NombreDeporte))
             .ForMember(dest => dest.Genero, opt => opt.MapFrom(src => src.Genero.GeneroNombre))
             .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Colores.ColorName));
            CreateMap<Zapatilla, ZapatillasEditVm>().ReverseMap();
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
            CreateMap<Deporte, DeporteDetailsVm>();


        }

        private void LoadMarcaMapping()
        {
            CreateMap<Marca, MarcaListVm>();
            CreateMap<Marca, MarcaEditVm>().ReverseMap();
            CreateMap<Marca, MarcaDetailsVm>();
        }


    }
}
