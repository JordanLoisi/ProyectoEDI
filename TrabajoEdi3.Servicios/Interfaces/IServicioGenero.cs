using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrabajoEdi3.Entidades;

namespace TrabajoEdi3.Servicios.Interfaces
{
    public interface IServicioGenero
    {
        IEnumerable<Genero>? GetAll(Expression<Func<Genero, bool>>? filter = null,
         Func<IQueryable<Genero>, IOrderedQueryable<Genero>>? orderBy = null,
         string? propertiesNames = null);

        Genero? Get(Expression<Func<Genero, bool>>? filter = null,
           string? propertiesNames = null,
           bool tracked = true);
        int GetCantidadFiltro(Func<Genero, bool>? filtro = null);
        int GetCantidad();
        List<Genero> GetLista();
        void Guardar(Genero genero);
        void Borrar(Genero genero);
        bool Existe(Genero genero);
        Genero? GetGeneroPorId(int idEditar);
        Genero? GetGeneroPorNombre(string genero);
        bool EstaRelacionado(int id);
    }
}
