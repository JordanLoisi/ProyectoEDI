using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoEdi3.Entidades;
using TrabajoEdi3.Entidades.Enums;

namespace TrabajoEdi3.Servicios.Interfaces
{
    public interface ITallesServicio
    {
        void Guardar(Talles talles);
        void Borrar(Talles talles);
        bool Existe(Talles talles);
        List<Talles> GetLista();
        Talles? GetTallesPorId(int id, bool incluyeZapatilla = false);

        int GetCantidad();
        List<Talles> GetTallesPaginadosOrdenados(int page, int pageSize, Orden? orden = null);

        bool EstaRelacionado(Talles talles);

        void EditarStocks(ZapatillasTalles zapatillasTalles);
    }
}
