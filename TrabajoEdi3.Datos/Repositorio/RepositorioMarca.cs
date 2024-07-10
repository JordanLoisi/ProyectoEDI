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
    public class RepositorioMarca : IMarcaRepositorio
    {
        private readonly DbContex _Context;

        public RepositorioMarca(DbContex Context)
        {
            _Context = Context;
        }
        public void Agregar(Marca marca)
        {
            _Context.marcas.Add(marca);
        }

        public void Borrar(Marca marca)
        {
            _Context.marcas.Remove(marca);
        }

        public void Editar(Marca marca)
        {
            _Context.marcas.Update(marca);
        }

        public bool EstaRelacionado(Marca marca)
        {
            return _Context.zapatillas
                .Any(p => p.MarcaId == marca.MarcaId);
        }

        public bool Existe(Marca marca)
        {
            if (marca.MarcaId == 0)
            {
                return _Context.marcas
                    .Any(t => t.MarcaNombre == marca.MarcaNombre);
            }
            return _Context.marcas
                .Any(t => t.MarcaNombre == marca.MarcaNombre &&
                    t.MarcaId != marca.MarcaId);
        }

        public int GetCantidad()
        {
            return _Context.deportes.Count();
        }

        public int GetCantidadFiltro(Func<Marca, bool>? filtro = null)
        {
            if (filtro != null)
            {
                return _Context.marcas.Count(filtro);
            }
            else
            {
                return _Context.marcas.Count();
            }
        }

        public List<Marca> GetLista()
        {
            return _Context.marcas
               .AsNoTracking()
               .ToList();
        }

        public Marca? GetMarcaPorId(int idEditar)
        {
            return _Context.marcas
                .FirstOrDefault(t => t.MarcaId == idEditar);
        }

        public Marca? GetMarcaPorNombre(string nombreMarca)
        {
            return _Context.marcas
                 .FirstOrDefault(t => t.MarcaNombre == nombreMarca);
        }
    }
}
