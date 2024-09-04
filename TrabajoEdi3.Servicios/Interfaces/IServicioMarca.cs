using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrabajoEdi3.Entidades;

namespace TrabajoEdi3.Servicios.Interfaces
{
    public interface IServicioMarca
    {
        IEnumerable<Marca>? GetAll(Expression<Func<Marca, bool>>? filter = null,
           Func<IQueryable<Marca>, IOrderedQueryable<Marca>>? orderBy = null,
           string? propertiesNames = null);

        Marca? Get(Expression<Func<Marca, bool>>? filter = null,
           string? propertiesNames = null,
           bool tracked = true);
        int GetCantidadFiltro(Func<Marca, bool>? filtro = null);
        int GetCantidad();
        List<Marca> GetLista();
        void Guardar(Marca marca);
        void Borrar(Marca marca);
        bool Existe(Marca marca);
        Marca? GetMarcaPorId(int idEditar);
        Marca? GetMarcaPorNombre(string marca);
        bool EstaRelacionado(int id);
    }
}
