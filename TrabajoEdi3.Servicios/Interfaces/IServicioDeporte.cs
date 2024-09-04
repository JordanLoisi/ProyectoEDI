using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrabajoEdi3.Entidades;

namespace TrabajoEdi3.Servicios.Interfaces
{
    public interface IServicioDeporte
    {
        IEnumerable<Deporte>? GetAll(Expression<Func<Deporte, bool>>? filter = null,
          Func<IQueryable<Deporte>, IOrderedQueryable<Deporte>>? orderBy = null,
          string? propertiesNames = null);

        Deporte? Get(Expression<Func<Deporte, bool>>? filter = null,
           string? propertiesNames = null,
           bool tracked = true);
        int GetCantidadFiltro(Func<Deporte, bool>? filtro = null);

        int GetCantidad();
        List<Deporte> GetLista();
        void Guardar(Deporte deporte);
        void Borrar(Deporte deporte);
        bool Existe(Deporte deporte);
        Deporte? GetDeportePorId(int idEditar);
        Deporte? GetDeportePorNombre(string deporte);
        bool EstaRelacionado(int id);
    }
}
