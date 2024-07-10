using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoEdi3.Entidades;

namespace TrabajoEdi3.Datos.Intefaces
{
    public interface IColorRepositorio
    {
        int GetCantidad();
        void Agregar(Entidades.Color coloor);
        void Borrar(Entidades.Color coloor);
        void Editar(Entidades.Color coloor);
        bool Existe(Entidades.Color coloor);
        Entidades.Color? GetColorPorId(int idEditar);
        List<Entidades.Color> GetLista();
        bool EstaRelacionado(Entidades.Color coloor);
        Entidades.Color? GetColorPorNombre(string nombreColor);
        

    }
}
