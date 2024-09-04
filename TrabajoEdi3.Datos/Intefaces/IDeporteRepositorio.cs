using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TrabajoEdi3.Entidades;

namespace TrabajoEdi3.Datos.Intefaces
{
    public interface IDeporteRepositorio :IGenericRepositorio<Deporte>
    {
        int GetCantidad();

        int GetCantidadFiltro(Func<Deporte, bool>? filtro = null);
        void Agregar(Deporte deporte);
        void Borrar(Deporte deporte);
        void Editar(Deporte deporte);
        bool Existe(Deporte deporte);
        Deporte? GetDeportePorId(int idEditar);
        List<Deporte> GetLista();
        bool EstaRelacionado(int id);

        Deporte? GetDeportePorNombre(string nombreDeporte);
      

    }
}
