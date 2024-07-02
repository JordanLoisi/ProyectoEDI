using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoEdi3.Entidades;

namespace TrabajoEdi3.Datos.Intefaces
{
    public interface IMarcaRepositorio
    {
        int GetCantidad(Func<Marca, bool>? filtro = null);
        void Agregar(Marca marca);
        void Borrar(Marca marca);
        void Editar(Marca marca);
        bool Existe(Marca marca);
        Marca? GetMarcaPorId(int idEditar);
        List<Marca> GetLista();
        bool EstaRelacionado(Marca marca);

        Marca? GetMarcaPorNombre(string nombreMarca);
        //List<Deporte>? GetDeporte(Deporte? deporte);
        //int GetCantidad();
    }
}
