using System.Linq.Expressions;
using TrabajoEdi3.Entidades;
using TrabajoEdi3.Entidades.Dto;
using TrabajoEdi3.Entidades.Enums;

namespace TrabajoEdi3.Servicios.Interfaces
{
    public interface IServicioZapatilla
    {
        IEnumerable<Zapatilla>? GetAll(Expression<Func<Zapatilla, bool>>? filter = null,
       Func<IQueryable<Zapatilla>, IOrderedQueryable<Zapatilla>>? orderBy = null,
       string? propertiesNames = null);

        Zapatilla? Get(Expression<Func<Zapatilla, bool>>? filter = null,
           string? propertiesNames = null,
           bool tracked = true);
        int GetCantidad(Func<Zapatilla, bool>? filtro = null);
        void Guardar(Zapatilla zapatilla, List<Talles>? talles = null);

        void GuardarZapas(Zapatilla zapatilla);
        void Borrar(int zapatillaId);
        List<ZapatillaListDto> GetListaPaginadaOrdenadaFiltrada(int page,
            int pageSize, Orden? orden = null, Deporte? DeporteFiltro = null,
            Marca? MarcaFiltro = null, Color? colorFiltro = null, Genero? GeneroFiltro = null,Talles? talleSelec= null , Talles? tallemax= null);

        List<Zapatilla> GetLista();
        IEnumerable<object> GetListaAnonima();
        bool Existe(Zapatilla zapatilla);
        List<ZapatillaListDto> GetListaDto();
        Zapatilla? GetZapatillaPorId(int zapatillaId);
        void GuardarConTalle(Zapatilla zapatilla, Talles nuevotalle);
        void AsignarTalleAZapatilla(Zapatilla zapatillaSinProveedor, Talles nuevoTalle, int stock);
        void Editar(Zapatilla zapatilla, int? talleId);
        List<ZapatillasTalles>? GetTallesPorZapatilla(int zapatillaId);
        bool ExisteRelacion(Zapatilla zapatilla, Talles talles);

        bool EstaRelacionado(Zapatilla zapatilla);
        List<ZapatillaListDto>? GetZapatillaSinTalle();

    }
}
