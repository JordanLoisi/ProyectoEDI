using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoEdi3.Datos.Intefaces;
using TrabajoEdi3.Entidades;

namespace TrabajoEdi3.Datos.Repositorio
{
    public class RepositorioTalles : ITallesRepositores
    {
        private readonly DbContex _context;

        public RepositorioTalles(DbContex context)
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

        public bool Existe(Talles talles)
        {
            return _context.talles
                 .Any(p => p.TallesId == talles.TallesNumbero
                 && p.TallesId != talles.TallesId);
        }

        public List<Talles> GetLista()
        {
            return _context.talles.ToList();
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
