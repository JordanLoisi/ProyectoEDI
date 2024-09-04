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
    public class RepositorioDeporte : RepositorioGenerico<Deporte>, IDeporteRepositorio
    {
        private readonly DbContex _Context;

        public RepositorioDeporte(DbContex Context): base (Context)
        {
            _Context = Context;
        }

        public void Agregar(Deporte deporte)
        {
            _Context.deportes.Add(deporte);
          
        }

        public void Borrar(Deporte deporte)
        {
            _Context.deportes.Remove(deporte);
          
        }

        public void Editar(Deporte deporte)
        {
            _Context.deportes.Update(deporte);
          
        }

        public bool EstaRelacionado(int id)
        {
            return _Context.zapatillas
                .Any(p => p.DeporteId == id);
        }

        public bool Existe(Deporte deporte)
        {
            if (deporte.DeporteId == 0)
            {
                return _Context.deportes
                    .Any(t => t.NombreDeporte == deporte.NombreDeporte);
            }
            return _Context.deportes
                .Any(t => t.NombreDeporte == deporte.NombreDeporte &&
                    t.DeporteId != deporte.DeporteId);
        }

        public int GetCantidad()
        {
            return _Context.deportes.Count();
        }

        public int GetCantidadFiltro(Func<Deporte, bool>? filtro = null)
        {
            if (filtro != null)
            {
                return _Context.deportes.Count(filtro);
            }
            else
            {
                return _Context.deportes.Count();
            }
        }

       

        public Deporte? GetDeportePorId(int IdEditar)
        {

            return _Context.deportes
                .FirstOrDefault(t => t.DeporteId == IdEditar);
        }

        public Deporte? GetDeportePorNombre(string nombreDeporte)
        {
            return _Context.deportes
                .FirstOrDefault(t => t.NombreDeporte == nombreDeporte);
        }
    

        public List<Deporte> GetLista()
        {

            return _Context.deportes
                .AsNoTracking()
                .ToList();
        }

        
    }
}
