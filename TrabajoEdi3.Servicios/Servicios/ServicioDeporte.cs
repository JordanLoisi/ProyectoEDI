using System;
using System.Collections.Generic;
using System.Drawing;
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
    public class ServicioDeporte : IServicioDeporte
    {
        private readonly IDeporteRepositorio _repository;
        private readonly IUnitOfWork _unitOfWork;
        public ServicioDeporte(IDeporteRepositorio repository,
            IUnitOfWork uniOfWork)
        {
            _repository = repository;
            _unitOfWork = uniOfWork;
        }
        public void Borrar(Deporte deporte)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                _repository.Borrar(deporte);
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

        public bool Existe(Deporte deporte)
        {
            return _repository.Existe(deporte);
        }

        public int GetCantidadFiltro(Func<Deporte, bool>? filtro = null)
        {
            return _repository.GetCantidadFiltro(filtro);
        }

        public int GetCantidad()
        {
            return _repository.GetCantidad();
        }

        public Deporte? GetDeportePorId(int idEditar)
        {
            return _repository.GetDeportePorId(idEditar);
        }

        public Deporte? GetDeportePorNombre(string deporte)
        {
            return _repository.GetDeportePorNombre(deporte);
        }

        public List<Deporte> GetLista()
        {
            return _repository.GetLista();
        }

        public void Guardar(Deporte deporte)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                if (deporte.DeporteId == 0)
                {
                    _repository.Agregar(deporte);
                }
                else
                {
                    _repository.Editar(deporte);
                }
                _unitOfWork.Commit();

            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        public IEnumerable<Deporte>? GetAll(Expression<Func<Deporte, bool>>? filter = null, Func<IQueryable<Deporte>, IOrderedQueryable<Deporte>>? orderBy = null, string? propertiesNames = null)
        {
            return _repository!.GetAll(filter, orderBy, propertiesNames);
        }

        public Deporte? Get(Expression<Func<Deporte, bool>>? filter = null, string? propertiesNames = null, bool tracked = true)
        {
            return _repository!.Get(filter, propertiesNames, tracked);
        }
    }
}
