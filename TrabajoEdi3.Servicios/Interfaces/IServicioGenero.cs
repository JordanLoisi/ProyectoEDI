using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoEdi3.Entidades;

namespace TrabajoEdi3.Servicios.Interfaces
{
    public interface IServicioGenero
    {
        int GetCantidadFiltro(Func<Genero, bool>? filtro = null);
        int GetCantidad();
        List<Genero> GetLista();
        void Guardar(Genero genero);
        void Borrar(Genero genero);
        bool Existe(Genero genero);
        Genero? GetGeneroPorId(int idEditar);
        Genero? GetGeneroPorNombre(string genero);
        bool EstaRelacionado(Genero genero);
    }
}
