using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoEdi3.Entidades;

namespace TrabajoEdi3.Datos.Intefaces
{
    public interface IGeneroRepositorio
    {
        int GetCantidadFiltro(Func<Genero, bool>? filtro = null);
        int GetCantidad();
        void Agregar(Genero genero);
        void Borrar(Genero genero);
        void Editar(Genero genero);
        bool Existe(Genero genero);
        Genero? GetGeneroPorId(int idEditar);
        List<Genero> GetLista();
        bool EstaRelacionado(Genero genero);

        Genero? GetGeneroPorNombre(string nombreGenero);

    }
}
