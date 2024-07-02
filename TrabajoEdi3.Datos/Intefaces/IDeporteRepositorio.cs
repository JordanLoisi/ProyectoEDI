using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TrabajoEdi3.Entidades;

namespace TrabajoEdi3.Datos.Intefaces
{
    public interface IDeporteRepositorio
    {
        int GetCantidad(Func<Deporte, bool>? filtro = null);
        void Agregar(Deporte deporte);
        void Borrar(Deporte deporte);
        void Editar(Deporte deporte);
        bool Existe(Deporte deporte);
        Deporte? GetDeportePorId(int idEditar);
        List<Deporte> GetLista();
        bool EstaRelacionado(Deporte deporte);

        Deporte? GetDeportePorNombre(string nombreDeporte);
        //List<Deporte>? GetDeporte(Deporte? deporte);
        //int GetCantidad();

    }
}
