using System;
using System.Collections.Generic;
using System.Linq;
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
    

        public bool EstaRelacionado(Genero genero)
        {
        return _repository.EstaRelacionado(genero);
        }

        public bool Existe(Genero genero)
        {
            return _repository.Existe(genero);
        }

        public int GetCantidad(Func<Genero, bool>? filtro = null)
        {
            return _repository.GetCantidad(filtro);
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
    }
}
