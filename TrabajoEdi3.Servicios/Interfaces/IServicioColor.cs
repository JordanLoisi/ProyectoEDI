using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrabajoEdi3.Entidades;


namespace TrabajoEdi3.Servicios.Interfaces
{
    public interface IServicioColor
    {
        IEnumerable<Entidades.Color>? GetAll(Expression<Func<Entidades.Color, bool>>? filter = null,
         Func<IQueryable<Entidades.Color>, IOrderedQueryable<Entidades.Color>>? orderBy = null,
         string? propertiesNames = null);

        Entidades.Color? Get(Expression<Func<Entidades.Color, bool>>? filter = null,
           string? propertiesNames = null,
           bool tracked = true);
        int GetCantidad();
        List<Entidades.Color> GetLista();
        void Guardar(Entidades.Color color);
        void Borrar(Entidades.Color color);
        bool Existe(Entidades.Color color);
        Entidades.Color? GetColorPorId(int idEditar);
        Entidades.Color? GetColorPorNombre(string ColorName);
        bool EstaRelacionado(int id);

    }
}
