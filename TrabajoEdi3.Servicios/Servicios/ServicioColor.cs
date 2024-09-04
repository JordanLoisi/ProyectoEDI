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
    public class ServicioColor : IServicioColor
    {
        private readonly IColorRepositorio _repository;
        private readonly IUnitOfWork _unitOfWork;
        public ServicioColor(IColorRepositorio repository,
            IUnitOfWork uniOfWork)
        {
            _repository = repository;
            _unitOfWork = uniOfWork;
        }
        public void Borrar(Color color)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                _repository.Borrar(color);
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

        public bool Existe(Color color)
        {
            return _repository.Existe(color);
        }

        public Color? Get(Expression<Func<Color, bool>>? filter = null, string? propertiesNames = null, bool tracked = true)
        {
            return _repository!.Get(filter, propertiesNames, tracked);
        }

        public IEnumerable<Color>? GetAll(Expression<Func<Color, bool>>? filter = null, Func<IQueryable<Color>, IOrderedQueryable<Color>>? orderBy = null, string? propertiesNames = null)
        {
            return _repository!.GetAll(filter, orderBy, propertiesNames);
        }

        public int GetCantidad()
        {
            return _repository.GetCantidad();
        }

        public Color? GetColorPorId(int idEditar)
        {
            return _repository.GetColorPorId(idEditar);
        }

        public Color? GetColorPorNombre(string ColorName)
        {
            return _repository.GetColorPorNombre(ColorName);
        }

        public List<Color> GetLista()
        {
            return _repository.GetLista();
        }

        public void Guardar(Color color)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                if (color.ColorId == 0)
                {
                    _repository.Agregar(color);
                }
                else
                {
                    _repository.Editar(color);
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
