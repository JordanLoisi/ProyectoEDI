using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoEdi3.Entidades;

namespace TrabajoEdi3.Datos.Intefaces
{
    public interface ITallesRepositores
    {
        void Agregar(Talles talles);
        void AgregarZapatillasTalles(ZapatillasTalles nuevaRelacion);
        void Borrar(Talles talles);
        void Editar(Talles talles);
        bool Existe(Talles talles);
        List<Talles> GetLista();
        Talles? GetTallesPorId(int id, bool incluyeZapatilla = false);
    }
}
