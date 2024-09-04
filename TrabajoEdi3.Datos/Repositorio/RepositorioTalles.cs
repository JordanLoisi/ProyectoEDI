using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoEdi3.Datos.Intefaces;
using TrabajoEdi3.Entidades;
using TrabajoEdi3.Entidades.Enums;

namespace TrabajoEdi3.Datos.Repositorio
{
    public class RepositorioTalles : RepositorioGenerico<Talles>,ITallesRepositores
    {
        private readonly DbContex _context;

        public RepositorioTalles(DbContex context): base (context)
        {
            _context = context;
        }
        public void Agregar(Talles talles)
        {
            _context.talles.Add(talles);
        }

        public void AgregarZapatillasTalles(ZapatillasTalles nuevaRelacion)
        {
            _context.Set<ZapatillasTalles>().Add(nuevaRelacion);
        }
    

        public void Borrar(Talles talles)
        {
          _context.talles.Remove(talles);
         }

        public void Editar(Talles talles)
        {
            _context.talles.Update(talles);
        }

        public void EditarStocks(ZapatillasTalles zapatillasTalles)
        {
            _context.zapatillastalles.Update(zapatillasTalles);
        }

        public bool EstaRelacionado(int id)
        {
            return _context.zapatillastalles.Any(ss => ss.TallesId == id);
        }

        public bool Existe(Talles talles)
        {
            return _context.talles
                 .Any(p => p.TallesNumbero == talles.TallesNumbero
                 && p.TallesId != talles.TallesId);
        }

        public int GetCantidad()
        {
            return _context.talles.Count();
        }

        public List<Talles> GetLista()
        {
            return _context.talles.ToList();
        }

        public List<Talles> GetTallesPaginadosOrdenados(int page, int pageSize, Orden? orden = null)
        {
            IQueryable<Talles> query = _context.talles;

            //ORDEN
            if (orden != null)
            {
                switch (orden)
                {
                    case Orden.AZ:
                        query = query.OrderBy(s => s.TallesNumbero);
                        break;
                    case Orden.ZA:
                        query = query.OrderByDescending(s => s.TallesNumbero);
                        break;
                    default:
                        break;
                }
            }

            //PAGINADO
            List<Talles> listaPaginada = query.AsNoTracking()
                .Skip(page * pageSize) //Saltea estos registros
                .Take(pageSize) //Muestra estos
                .ToList();

            return listaPaginada;
        }

        public Talles? GetTallesPorId(int id, bool incluyeZapatilla = false)
        {
            var query = _context.talles;
            if (incluyeZapatilla)
            {
                return query.Include(p => p.zapatillastalles)
                    .ThenInclude(pp => pp.Zapatilla)
                    .FirstOrDefault(p => p.TallesId == id);
            }
            return query
                .FirstOrDefault(p => p.TallesId == id);
        }
    }
}
