using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoEdi3.Entidades;

namespace TrabajoEdi3.Servicios.Interfaces
{
    public interface IServicioMarca
    {
        int GetCantidadFiltro(Func<Marca, bool>? filtro = null);
        int GetCantidad();
        List<Marca> GetLista();
        void Guardar(Marca marca);
        void Borrar(Marca marca);
        bool Existe(Marca marca);
        Marca? GetMarcaPorId(int idEditar);
        Marca? GetMarcaPorNombre(string marca);
        bool EstaRelacionado(Marca marca);
    }
}
