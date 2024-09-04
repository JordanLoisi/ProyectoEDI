using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TrabajoEdi3.Datos.Intefaces;
using TrabajoEdi3.Entidades;

namespace TrabajoEdi3.Datos.Repositorio
{
    public class RepositorioGenero : RepositorioGenerico<Genero>, IGeneroRepositorio
    {

        private readonly DbContex _Context;

        public RepositorioGenero(DbContex Context): base (Context)
        {
            _Context = Context;
        }

        public void Agregar(Genero genero)
        {
            _Context.generos.Add(genero);
        }

        public void Borrar(Genero genero)
        {
            _Context.generos.Remove(genero);
        }

        public void Editar(Genero genero)
        {
            _Context.generos.Update(genero);
        }

        public bool EstaRelacionado(int id)
        {
            return _Context.zapatillas
                .Any(p => p.GeneroId == id);
        }

        public bool Existe(Genero genero)
        {
            if (genero.GeneroId == 0)
            {
                return _Context.generos
                    .Any(t => t.GeneroNombre == genero.GeneroNombre);
            }
            return _Context.generos
                .Any(t => t.GeneroNombre == genero.GeneroNombre &&
                    t.GeneroId != genero.GeneroId);
        }

        

        public int GetCantidad()
        {
            return _Context.generos.Count();
        }

        public int GetCantidadFiltro(Func<Genero, bool>? filtro = null)
        {
            if (filtro != null)
            {
                return _Context.generos.Count(filtro);
            }
            else
            {
                return _Context.generos.Count();
            }
        }

      

        public Genero? GetGeneroPorId(int idEditar)
        {
            return _Context.generos
                .FirstOrDefault(t => t.GeneroId == idEditar);
        }

        public Genero? GetGeneroPorNombre(string nombreGenero)
        {
            return _Context.generos
                 .FirstOrDefault(t => t.GeneroNombre == nombreGenero);
        }

        public List<Genero> GetLista()
        {
            return _Context.generos
              .AsNoTracking()
              .ToList();
        
        }
    }
}
