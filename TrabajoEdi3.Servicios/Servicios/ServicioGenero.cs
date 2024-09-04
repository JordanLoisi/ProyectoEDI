using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrabajoEdi3.Datos.Intefaces;
using TrabajoEdi3.Datos.UnitOfWork;
using TrabajoEdi3.Entidades;
using TrabajoEdi3.Servicios.Interfaces;

namespace TrabajoEdi3.Servicios.Servicios
{
    public class ServicioGenero : IServicioGenero
    {
        private readonly IGeneroRepositorio _repository;
        private readonly IUnitOfWork _unitOfWork;
        public ServicioGenero(IGeneroRepositorio repository,
            IUnitOfWork uniOfWork)
        {
            _repository = repository;
            _unitOfWork = uniOfWork;
        }
        public void Borrar(Genero genero)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                _repository.Borrar(genero);
                _unitOfWork.Commit();

            }
            catch (Exception)
            {
                _unitOfWork?.Rollback();
                throw;
            }
        }
    

        public bool EstaRelacionado(int id)
        {
        return _repository.EstaRelacionado(id);
        }

        public bool Existe(Genero genero)
        {
            return _repository.Existe(genero);
        }

        public int GetCantidadFiltro(Func<Genero, bool>? filtro = null)
        {
            return _repository.GetCantidadFiltro(filtro);
        }
        public int GetCantidad()
        {
            return _repository.GetCantidad();
        }
        public Genero? GetGeneroPorId(int idEditar)
        {
            return _repository.GetGeneroPorId(idEditar);
        }

        public Genero? GetGeneroPorNombre(string genero)
        {
            return _repository.GetGeneroPorNombre(genero);
        }

        public List<Genero> GetLista()
        {
            return _repository.GetLista();
        }

        public void Guardar(Genero genero)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                if (genero.GeneroId == 0)
                {
                    _repository.Agregar(genero);
                }
                else
                {
                    _repository.Editar(genero);
                }
                _unitOfWork.Commit();

            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        public IEnumerable<Genero>? GetAll(Expression<Func<Genero, bool>>? filter = null, Func<IQueryable<Genero>, IOrderedQueryable<Genero>>? orderBy = null, string? propertiesNames = null)
        {
            return _repository!.GetAll(filter, orderBy, propertiesNames);
        }

        public Genero? Get(Expression<Func<Genero, bool>>? filter = null, string? propertiesNames = null, bool tracked = true)
        {
            return _repository!.Get(filter, propertiesNames, tracked);
        }
    }
}
