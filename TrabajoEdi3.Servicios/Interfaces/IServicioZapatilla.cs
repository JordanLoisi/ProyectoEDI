using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TrabajoEdi3.Entidades;
using TrabajoEdi3.Entidades.Dto;
using TrabajoEdi3.Entidades.Enums;

namespace TrabajoEdi3.Servicios.Interfaces
{
    public interface IServicioZapatilla
    {
        int GetCantidad(Func<Zapatilla, bool>? filtro = null);
        void Guardar(Zapatilla zapatilla,List<Talles>? talles);
        void Borrar(int zapatillaId);
        List<ZapatillaListDto> GetListaPaginadaOrdenadaFiltrada(int page,
            int pageSize, Orden? orden = null, Deporte? DeporteFiltro = null,
            Marca? MarcaFiltro = null, Color? colorFiltro = null, Genero? GeneroFiltro = null);

        List<Zapatilla> GetLista();
        IEnumerable<object> GetListaAnonima();
        bool Existe(Zapatilla zapatilla);
        List<ZapatillaListDto> GetListaDto();
        Zapatilla? GetZapatillaPorId(int zapatillaId);
        void GuardarConTalle(Zapatilla zapatilla, Talles nuevotalle);
        void AsignarTalleAZapatilla(Zapatilla zapatillaSinProveedor, Talles nuevoTalle);
        void Editar(Zapatilla zapatilla, int? talleId);
        List<Talles>? GetTallesPorZapatilla(int zapatillaId);
        bool ExisteRelacion(Zapatilla zapatilla, Talles talles);

        List<ZapatillaListDto>? GetZapatillaSinTalle();

    }
}
