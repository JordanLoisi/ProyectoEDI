using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoEdi3.Entidades;

namespace TrabajoEdi3.Servicios.Interfaces
{
    public interface IServicioDeporte
    {
        int GetCantidadFiltro(Func<Deporte, bool>? filtro = null);

        int GetCantidad();
        List<Deporte> GetLista();
        void Guardar(Deporte deporte);
        void Borrar(Deporte deporte);
        bool Existe(Deporte deporte);
        Deporte? GetDeportePorId(int idEditar);
        Deporte? GetDeportePorNombre(string deporte);
        bool EstaRelacionado(Deporte deporte);
    }
}
