using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrabajoEdi3.Entidades;
using TrabajoEdi3.Entidades.Enums;

namespace TrabajoEdi3.Servicios.Interfaces
{
    public interface ITallesServicio
    {
        IEnumerable<Talles>? GetAll(Expression<Func<Talles, bool>>? filter = null,
         Func<IQueryable<Talles>, IOrderedQueryable<Talles>>? orderBy = null,
         string? propertiesNames = null);

        Talles? Get(Expression<Func<Talles, bool>>? filter = null,
           string? propertiesNames = null,
           bool tracked = true);
        void Guardar(Talles talles);
        void Borrar(Talles talles);
        bool Existe(Talles talles);
        List<Talles> GetLista();
        Talles? GetTallesPorId(int id, bool incluyeZapatilla = false);

        int GetCantidad();
        List<Talles> GetTallesPaginadosOrdenados(int page, int pageSize, Orden? orden = null);

        bool EstaRelacionado(int id);

        void EditarStocks(ZapatillasTalles zapatillasTalles);
    }
}
