using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoEdi3.Entidades;

namespace TrabajoEdi3.Servicios.Interfaces
{
    public interface ITallesServicio
    {
        void Guardar(Talles talles);
        void Borrar(Talles talles);
        bool Existe(Talles talles);
        List<Talles> GetLista();
        Talles? GetTallesPorId(int id, bool incluyeZapatilla = false);
    }
}
