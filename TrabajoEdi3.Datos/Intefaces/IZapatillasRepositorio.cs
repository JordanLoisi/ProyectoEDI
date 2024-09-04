using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TrabajoEdi3.Entidades;
using TrabajoEdi3.Entidades.Dto;
using TrabajoEdi3.Entidades.Enums;

namespace TrabajoEdi3.Datos.Intefaces
{
    public interface IZapatillasRepositorio: IGenericRepositorio<Zapatilla>
    {
        int GetCantidad(Func<Zapatilla, bool>? filtro = null);
        void Agregar(Zapatilla zapatilla);
        void Editar(Zapatilla zapatilla);
        void Borrar(Zapatilla zapatilla);
        List<ZapatillaListDto> GetListaPaginadaOrdenadaFiltrada(int page,
            int pageSize, Orden? orden = null, Deporte? DeporteFiltro = null,
            Marca? MarcaFiltro = null, Color? colorFiltro =null, Genero? GeneroFiltro=null, Talles? talleSelec= null, Talles? tallemax=null);
        List<Zapatilla> GetLista();
        IEnumerable<object> GetListaAnonima();
        bool Existe(Zapatilla zapatilla);
        List<ZapatillaListDto> GetListaDto();
        Zapatilla? GetZapatillaPorId(int zapatillaId);

        List<ZapatillaListDto>? GetZapatillaSinTalle();
        void AgregarTallesZapatilla(ZapatillasTalles nuevaRelacion);
        void Editar(Zapatilla zapatilla, int? TallesId);

        List<ZapatillasTalles>? GetTallesPorZapatilla(int zapatillaId);
        bool ExisteRelacion(Zapatilla zapatilla, Talles talles);
        void AgregarZapatillaTalles(Zapatilla zapatilla, List<Talles> talles);

        bool EstaRelacionado(Zapatilla zapatilla);

        void EliminarRelaciones(Zapatilla zapatilla);
    }
}
